using Microsoft.CSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZNS.CodeGenerator.Utils;
using ZSN.CodeGenerator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Data.SqlClient;
using System.Xml;

namespace CodeGenerator
{
    public partial class FormMain : Form
    {
        private FormLogin _serverLoginForm;
        private readonly DbHelper _db = new DbHelper();

        private string _company = "";
        private string _project = "";
        private string _buildPath = "";

        private readonly string _basePath = Directory.GetCurrentDirectory();
        private string _templatePath = "";

        private string _tempPath = "";

        private readonly Dictionary<string, DataTable> _tableInfos = new Dictionary<string, DataTable>();

        public string Namespace => $"{_company}.{_project}";

        private DataTable _currentTable = null;

        private static string[] edbAry = new String[] { "Entity", "DAL", "BLL" };
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this._templatePath = Path.Combine(this._basePath,
                                                    "Template",
                                                    "_project_");
            this._tempPath = Path.Combine(this._basePath, "Temp");
            CheckTemplate();
            CheckServerLogin();
            textBox_ConnectionName.Text = ConfigHelper.GetString("DefaultConnectionName");
            textBox_Company.Text = ConfigHelper.GetString("DefaultCompany");
            textBox_Project.Text = ConfigHelper.GetString("DefaultProject");
            textBox_BuildPath.Text = ConfigHelper.GetString("DefaultBuildPath");
        }

        #region 初始化

        private void CheckServerLogin()
        {
            var rst = DShowServerLogin();
            if (rst == DialogResult.OK)
            {
                _db.Server = DBServer.Current;
                InitTableList();
                InitTemplateList();
                textBox_ConnectionName.Text = "BaseDb";
            }
            else if (rst == DialogResult.Cancel)
            {
                Close();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(DBServer.Current.ServerDbName))
                {
                    CheckServerLogin();
                }
            }
        }

        private void CheckTemplate()
        {
            var isCleanTemplate = ConfigHelper.GetInt("IsCleanTemplate") == 1;

            if (Directory.Exists(_templatePath) && isCleanTemplate)
            {
                DeleteDirectory(_templatePath);
            }
            if (!Directory.Exists(_templatePath))
            {
                Directory.CreateDirectory(_templatePath);
                var sourceDic = new DirectoryInfo(this._basePath + @"/Template/_project_");
                CopyFolder(sourceDic.FullName, this._basePath + "/Template/");
            }
            DeleteDirectory(_tempPath);
        }

        public DialogResult DShowServerLogin()
        {
            if (_serverLoginForm == null)
            {
                _serverLoginForm = new FormLogin(this);
            }

            _serverLoginForm.Visible = false;
            _serverLoginForm.StartPosition = FormStartPosition.CenterScreen;
            _serverLoginForm.MaximizeBox = false;
            _serverLoginForm.MinimizeBox = false;
            _serverLoginForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            _serverLoginForm.AutoSize = false;

            return _serverLoginForm.ShowDialog();
        }

        /// <summary>
        /// 取模板文件列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateFileList()
        {
            List<string> fileList = new List<string>();
            //foreach (string f in Directory.GetDirectories(_templatePath))
            //{
            //    var n = Path.GetFileName(f);
            //    if (n.FirstOrDefault() != '.')
            //        fileList.Add(n);
            //}
            var templates = (JObject)ReadJson("TemplateList");
            foreach (var obj in templates)
            {
                fileList.Add(obj.Key);
            }
            return fileList;
        }

        /// <summary>
        /// 获取所有表信息
        /// </summary>
        public void InitTableList()
        {
            var tableList = _db.GetAllTable();

            treeView_tableList.Nodes.Clear();

            _db.Server = DBServer.Current;
            var root = treeView_tableList.Nodes.Add(DBServer.Current.ServerDbName);

            var ignoredTables = ((JArray)ReadJson("IgnoredTable")).Select(t => t.ToString());
            tableList = tableList.OrderBy(t => t).ToList();
            foreach (string table in tableList)
            {
                if (!ignoredTables.Contains(table))
                    root.Nodes.Add(table);
            }

            treeView_tableList.Refresh();
            treeView_tableList.ExpandAll();

            // 预加载表信息
            _tableInfos.Clear();
            foreach (var table in tableList)
            {
                _tableInfos.Add(table, _db.GetAllField(table));
            }
        }

        /// <summary>
        /// 获取所有字段信息
        /// </summary>
        public void InitTableFieldList(string tableName)
        {
            _currentTable = _tableInfos[tableName];
            dataGridView_tableInfo.DataSource = _currentTable;
            if (_currentTable.Rows.Count > 0)
            {
                dataGridView_tableInfo.Rows[0].Selected = true;
            }
        }

        public void InitTemplateList()
        {
            List<string> tl = GetTemplateFileList();
            checkedListBox_template.Items.Clear();
            foreach (string n in tl)
            {
                checkedListBox_template.Items.Add(n);
            }
        }


        /// <summary>
        /// 将 sourceFolder 复制到 destFolder
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destFolder"></param>
        private void CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                string folderName = Path.GetFileName(sourceFolder);
                string destfolderdir = Path.Combine(destFolder, folderName);
                string[] filenames = Directory.GetFileSystemEntries(sourceFolder);
                foreach (string file in filenames)// 遍历所有的文件和目录
                {
                    if (Directory.Exists(file))
                    {
                        string currentdir = Path.Combine(destfolderdir, Path.GetFileName(file));
                        if (!Directory.Exists(currentdir))
                        {
                            Directory.CreateDirectory(currentdir);
                        }
                        CopyFolder(file, destfolderdir);
                    }
                    else
                    {
                        string srcfileName = Path.Combine(destfolderdir, Path.GetFileName(file));
                        if (!Directory.Exists(destfolderdir))
                        {
                            Directory.CreateDirectory(destfolderdir);
                        }
                        File.Copy(file, srcfileName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        private void treeView_tableList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Parent == null)
                return;
            string table = e.Node.Text;
            _currentTable = _tableInfos[table];
            InitTableFieldList(table);
        }

        private void treeView_tableList_DoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
            e.Node.Checked = !e.Node.Checked;
            e.Node.ExpandAll();
        }

        private void treeView_tableList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Nodes.Count != 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        #region 生成模板

        /// <summary>
        /// 生成模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            labelLoading.Text = "loading...";

            _company = textBox_Company.Text.Trim();
            //_company = _company != "" ? _company + "." : "";

            _project = textBox_Project.Text.Trim();
            //_project = _project != "" ? _project + "." : "";

            _buildPath = Path.Combine(textBox_BuildPath.Text.Trim(), _project);
            DeleteDirectory(_buildPath);
            Directory.CreateDirectory(_buildPath);

            if (checkedListBox_template.CheckedItems.Count == 0)
            {
                MessageBox.Show("请先选择模板!");
                return;
            }

            #region 模板

            var makerProjects = GetSelectTemplate();

            foreach (var dirName in makerProjects)
            {
                var dirPath = Path.Combine(_templatePath, dirName);
                if (File.Exists(dirPath))
                {
                    var f = new FileInfo(dirPath);
                    if (f.Extension.Contains(".git"))
                    {
                        f.CopyTo(Path.Combine(_buildPath, f.Name), true);
                    }
                    else if (f.Extension.Contains(".sln"))
                    {
                        var contents = File.ReadAllText(f.FullName);
                        contents = ReplaceNamespace(contents);
                        File.WriteAllText(Path.Combine(_buildPath, _project + ".sln"), contents);
                    }
                }
                else if (Directory.Exists(dirPath))
                {
                    CreateProject(dirPath, _buildPath);
                }
            }

            #endregion

            labelLoading.Text = "";
            MessageBox.Show("生成结束!");
            var dic = new DirectoryInfo(textBox_BuildPath.Text.Trim());
            System.Diagnostics.Process.Start("explorer.exe", dic.FullName);
        }

        /// <summary>
        /// 获取选中的模板
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectTemplate()
        {
            var templates = (JObject)ReadJson("TemplateList");
            var tpls = new List<string>();
            foreach (var obj in templates)
            {
                if (checkedListBox_template.CheckedItems.Contains(obj.Key))
                {
                    var arys = (JArray)obj.Value["Projects"];
                    tpls.AddRange(arys.Select(t => t.ToString()));
                }
            }
            return tpls.Select(t => t.Replace("{Database}", DBServer.Current.ServerType)).Distinct().ToList();
        }

        /// <summary>
        /// 获取表的所有字段名称
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private List<string> GetFieldStrArray(string tableName)
        {
            List<string> re = new List<string>();
            var selectTable = _tableInfos[tableName];
            if (selectTable.Rows.Count > 0)
            {
                foreach (DataRow dr in selectTable.Rows)
                {
                    re.Add(dr["FieldName"].ToString());
                }
            }
            return re;
        }

        /// <summary>
        /// 替换命名空间
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private string ReplaceNamespace(string content)
        {
            content = content.Replace("_company_", _company);
            content = content.Replace("_project_", _project);
            return content;
        }

        /// <summary>
        /// 递归复制文件夹和文件
        /// 模板替换
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destFolder"></param>
        private void CreateProject(string sourceFolder, string destFolder)
        {
            try
            {
                string folderName = Path.GetFileName(sourceFolder);
                string destfolderdir = Path.Combine(destFolder, ReplaceNamespace(folderName));
                string[] filenames = Directory.GetFileSystemEntries(sourceFolder);
                foreach (string file in filenames)// 遍历所有的文件和目录
                {
                    if (Directory.Exists(file))
                    {
                        string currentdir = Path.Combine(destfolderdir, ReplaceNamespace(Path.GetFileName(file)));
                        if (!Directory.Exists(currentdir))
                        {
                            Directory.CreateDirectory(currentdir);
                        }
                        CreateProject(file, destfolderdir);
                    }
                    else
                    {
                        string srcfileName = Path.Combine(destfolderdir, ReplaceNamespace(Path.GetFileName(file)));
                        if (!Directory.Exists(destfolderdir))
                        {
                            Directory.CreateDirectory(destfolderdir);
                        }
                        BuildFile(file, srcfileName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 文件内容处理
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destFile"></param>
        private void BuildFile(string sourceFile, string destFile)
        {
            var file = new FileInfo(sourceFile);
            var ext = file.Extension.ToLower();
            if (!ext.EndsWith("pt") && checkedListBox_template.CheckedItems.Cast<string>().All(t => edbAry.Contains(t)))
            {
                return;
            }
            switch (ext)
            {
                case ".csproj":
                    CopyPrjFile(sourceFile, destFile);
                    break;
                case ".cs":
                    CopyCsFile(sourceFile, destFile);
                    break;
                case ".cshtml":
                    CopyCsFile(sourceFile, destFile);
                    break;
                case ".cspt":
                    CopyCsptFile(sourceFile, destFile);
                    break;
                case ".bpt":
                    CopyBptFile(sourceFile, destFile);
                    break;
                case ".dpt":
                    CopyDptFile(sourceFile, destFile);
                    break;
                case ".ipt":
                    CopyIptFile(sourceFile, destFile);
                    break;
                case ".dppt":
                    CopyDpptFile(sourceFile, destFile);
                    break;
                case ".ept":
                    CopyEptFile(sourceFile, destFile);
                    break;
                case ".json":
                    CopyJsonFile(sourceFile, destFile);
                    break;
                default:
                    File.Copy(sourceFile, destFile);
                    break;
            }
        }

        #region 模板文件替换


        private void CopyCsFile(string sourceFile, string destFile)
        {
            var content = ReplaceNamespace(FileHelper.GetUtf8Content(sourceFile));
            File.WriteAllText(destFile, content, Encoding.GetEncoding("utf-8"));
            return;
        }

        private void CopyCsptFile(string sourceFile, string destFile)
        {
            var temStr = BuildTemplateFile(sourceFile);
            var file = Path.Combine(Path.GetDirectoryName(destFile), Path.GetFileNameWithoutExtension(destFile));
            CompileFileAsync(temStr, file, GetSelectTable()[0]);
            return;
        }

        private void CopyBptFile(string sourceFile, string destFile)
        {
            var tableList = GetSelectTable();
            var temStr = BuildTemplateFile(sourceFile);
            foreach (var t in tableList)
            {
                var tc = GetTableClassName(t);
                var file = Path.Combine(Path.GetDirectoryName(destFile), $"{tc}Business.cs");
                CompileFileAsync(temStr, file, t);
            }
            return;
        }

        private void CopyDptFile(string sourceFile, string destFile)
        {
            var tableList = GetSelectTable();
            var temStr = BuildTemplateFile(sourceFile);
            foreach (var t in tableList)
            {
                var tc = GetTableClassName(t);
                var file = Path.Combine(Path.GetDirectoryName(destFile), $"{tc}Manage.cs");
                CompileFileAsync(temStr, file, t);
            }
            return;
        }

        private void CopyIptFile(string sourceFile, string destFile)
        {
            var tableList = GetSelectTable();
            var temStr = BuildTemplateFile(sourceFile);
            foreach (var t in tableList)
            {
                var tc = GetTableClassName(t);
                var file = Path.Combine(Path.GetDirectoryName(destFile), $"I{tc}Manage.cs");
                CompileFileAsync(temStr, file, t);
            }
            return;
        }

        private void CopyDpptFile(string sourceFile, string destFile)
        {
            var tableList = GetSelectTable();
            var temStr = BuildTemplateFile(sourceFile);
            foreach (var t in tableList)
            {
                var tc = GetTableClassName(t);
                var file = Path.Combine(Path.GetDirectoryName(destFile), $"{tc}Provider.cs");
                CompileFileAsync(temStr, file, t);
            }
            return;
        }

        private void CopyEptFile(string sourceFile, string destFile)
        {
            var tableList = GetSelectTable();
            var temStr = BuildTemplateFile(sourceFile);
            foreach (var t in tableList)
            {
                var tc = GetTableClassName(t);
                var file = Path.Combine(Path.GetDirectoryName(destFile), $"{tc}.cs");
                CompileFileAsync(temStr, file, t);
            }
            return;
        }

        private void CopyPrjFile(string sourceFile, string destFile)
        {
            var lines = File.ReadAllLines(sourceFile);
            var newLines = new List<string>();
            foreach (var line in lines)
            {
                if (DBServer.Current.IsMySql && line.Contains("SqlServer.csproj")
                    || DBServer.Current.IsSqlServer && line.Contains("MySql.csproj"))
                {
                    // 忽略
                }
                else
                {
                    newLines.Add(ReplaceNamespace(line));
                }
            }

            File.WriteAllLines(destFile, newLines.ToArray());
            return;
        }

        private void CopyJsonFile(string sourceFile, string destFile)
        {
            if (DBServer.Current.IsSqlServer || Path.GetFileName(sourceFile) != "appsettings.json")
            {
                File.Copy(sourceFile, destFile);
                return;
            }
            var str = File.ReadAllText(sourceFile, Encoding.Default);
            var obj = (JObject)JsonConvert.DeserializeObject(str);
            if (!obj.ContainsKey("DbConnectionStrings"))
                File.Copy(sourceFile, destFile);
            obj["DbConnectionStrings"]["BaseDb"]["DbType"] = "MySql";
            obj["DbConnectionStrings"]["BaseDb"]["Connection"] = $"server={DBServer.Current.ServerIp};userid={DBServer.Current.ServerUser};password={DBServer.Current.ServerPwd};database={DBServer.Current.ServerDbName}";
            obj["DbConnectionStrings"]["LogBaseDb"]["DbType"] = "MySql";
            obj["DbConnectionStrings"]["LogBaseDb"]["Connection"] = $"server={DBServer.Current.ServerIp};userid={DBServer.Current.ServerUser};password={DBServer.Current.ServerPwd};database=logbasedb";
            File.WriteAllText(destFile, JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented));
            return;
        }

        #endregion

        #region 模板引擎执行

        /// <summary>
        /// 生成模板文件对应cs文件
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        private string BuildTemplateFile(string templateName)
        {
            var newFilePath = Path.Combine(_tempPath, "Template", Path.GetFileNameWithoutExtension(templateName));
            if (!Directory.Exists(Path.Combine(_tempPath, "Template")))
            {
                Directory.CreateDirectory(Path.Combine(_tempPath, "Template"));
            }
            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
            File.Copy(templateName, newFilePath);
            var template = new SysFileTemplate();
            // 生成cs文件
            var templateFileStr = template.GetTemplate(_tempPath, "", Path.GetFileNameWithoutExtension(templateName), 1, 0, $"{Namespace}");
            return templateFileStr;
        }

        /// <summary>
        /// 执行模板文件
        /// </summary>
        /// <param name="templateFileStr">模板文件位置</param>
        /// <param name="destFile">目标文件位置</param>
        /// <param name="tableName">当前表</param>
        private void CompileFile(string templateFileStr, string destFile, string tableName)
        {
            var fileStr = "";

            if (templateFileStr.Trim() != "")
            {
                var objCSharpCodePrivoder = new CSharpCodeProvider();
                var objCompilerParameters = new CompilerParameters();
                objCompilerParameters.ReferencedAssemblies.Add("System.dll");
                objCompilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                objCompilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
                objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                objCompilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                objCompilerParameters.ReferencedAssemblies.Add("System.Linq.dll");
                objCompilerParameters.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");

                objCompilerParameters.GenerateExecutable = false;
                objCompilerParameters.GenerateInMemory = true;

                var cresult = objCSharpCodePrivoder.CompileAssemblyFromSource(objCompilerParameters, templateFileStr);

                if (cresult.Errors.HasErrors)
                {
                    foreach (CompilerError err in cresult.Errors)
                    {
                        MessageBox.Show(err.ErrorText);
                    }
                }
                else
                {
                    try
                    {
                        List<string> fieldStr = this.GetFieldStrArray(tableName);
                        var selectedTable = _tableInfos[tableName];
                        var pkRow = selectedTable.Rows.Cast<DataRow>().FirstOrDefault(t => t["IsPKey"].ToString() == "y") ?? selectedTable.Rows[0];

                        Assembly objAssembly = cresult.CompiledAssembly;
                        object obj = objAssembly.CreateInstance("DoCode.Do");
                        MethodInfo objMi = obj.GetType().GetMethod("initTemplateStr");
                        object reStr = objMi.Invoke(obj,
                            new object[]
                            {
                                selectedTable,
                                Namespace,
                                tableName,
                                GetTableClassName(tableName),
                                fieldStr,
                                textBox_ConnectionName.Text,
                                pkRow["FieldCSName"].ToString().ToFirstLower(),
                                pkRow
                            });
                        if (reStr != null)
                        {
                            fileStr = (string)reStr;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message + "\n" + e.InnerException.Message);
                    }
                }
            }

            File.WriteAllText(destFile, fileStr, Encoding.Default);
            return;
        }
        private async Task CompileFileAsync(string templateFileStr, string destFile, string tableName)
        {
            var fileStr = "";

            if (templateFileStr.Trim() != "")
            {
                // 创建一个C#语法树
                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(templateFileStr);

                // 引用必要的元数据
                MetadataReference[] references = new MetadataReference[]
                {

                MetadataReference.CreateFromFile(typeof(Enumerable).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(SqlConnection).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(DataRowExtensions).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(XmlDocument).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Form).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(File).GetTypeInfo().Assembly.Location), // System.IO

                };

                // 创建编译选项
                CSharpCompilationOptions options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

                // 创建一个编译对象
                CSharpCompilation compilation = CSharpCompilation.Create(
                    "DynamicAssembly",
                    syntaxTrees: new[] { syntaxTree },
                    references: references,
                    options: options
                    );

                // 编译代码
                using (MemoryStream ms = new MemoryStream())
                {
                    EmitResult result = compilation.Emit(ms);

                    if (!result.Success)
                    {
                        // 编译失败，处理错误
                        IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                            diagnostic.IsWarningAsError ||
                            diagnostic.Severity == DiagnosticSeverity.Error);

                        foreach (Diagnostic diagnostic in failures)
                        {
                            Console.Error.WriteLine($"编译错误: {diagnostic}");
                        }
                    }
                    else
                    {
                        // 编译成功，加载编译后的程序集
                        ms.Seek(0, SeekOrigin.Begin);
                        Assembly assembly = Assembly.Load(ms.ToArray());

                        List<string> fieldStr = this.GetFieldStrArray(tableName);
                        var selectedTable = _tableInfos[tableName];
                        var pkRow = selectedTable.Rows.Cast<DataRow>().FirstOrDefault(t => t["IsPKey"].ToString() == "y") ?? selectedTable.Rows[0];

                        object obj = assembly.CreateInstance("DoCode.Do");
                        MethodInfo objMi = obj.GetType().GetMethod("initTemplateStr");
                        object reStr = objMi.Invoke(obj,
                            new object[]
                            {
                                selectedTable,
                                Namespace,
                                tableName,
                                GetTableClassName(tableName),
                                fieldStr,
                                textBox_ConnectionName.Text,
                                pkRow["FieldCSName"].ToString().ToFirstLower(),
                                pkRow
                            });
                        if (reStr != null)
                        {
                            fileStr = (string)reStr;
                        }
                    }
                }
            }
            File.WriteAllText(destFile, fileStr, Encoding.Default);
            return;
        }
        #endregion

        /// <summary>
        /// 所有选中的表的名称
        /// </summary>
        /// <returns></returns>
        private List<string> GetSelectTable()
        {
            return treeView_tableList.Nodes[0].Nodes.Cast<TreeNode>().Where(t => t.Checked).Select(t => t.Text)
                .ToList();
        }

        public JToken ReadJson(string key)
        {
            string jsonfile = "./template.json";//JSON文件路径
            var str = File.ReadAllText(jsonfile, Encoding.Default);
            var o = (JObject)JsonConvert.DeserializeObject(str);
            return o[key];
        }

        public string GetTableClassName(string table)
        {
            if (table.Contains("_"))
            {
                table = string.Join("", table.Split('_').Where(t => !string.IsNullOrEmpty(t)).Select(t => t.ToFirstUpper()).ToList());
            }
            var pre = this.textBox_pre.Text.Trim();
            if (string.IsNullOrEmpty(pre))
                return table;
            if (table.ToLower().IndexOf(pre.ToLower()) == 0)
            {
                return table.Substring(pre.Length);
            }
            return table;
        }

        /// <summary>
        /// 如果存在该文件夹，删除完整文件夹及其内容。
        /// </summary>
        /// <param name="path"></param>
        public void DeleteDirectory(string path)
        {
            if (!Directory.Exists(path))
                return;
            Directory.Delete(path, true);
            while (Directory.Exists(path))
            {
                Thread.Sleep(500);
            }
        }

        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            CheckServerLogin();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox_template.Items.Count; i++)
            {
                checkedListBox_template.SetItemChecked(i, !checkedListBox_template.GetItemChecked(i));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox_template.Items.Count; i++)
            {
                var name = checkedListBox_template.Items[i].ToString();
                if (edbAry.Contains(name))
                {
                    checkedListBox_template.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox_template.SetItemChecked(i, false);
                }
            }
        }
    }
}
