using System.Text;
using System.Text.RegularExpressions;

namespace ZNS.CodeGenerator.Utils
{
    /// <summary>
    /// 模板生成类
    /// </summary>
    public class SysFileTemplate : FileTemplate
    {
        /// <summary>
        /// 解析特殊变量
        /// </summary>
        /// <param name="skinName">皮肤名</param>
        /// <param name="strTemplate">模板内容</param>
        /// <returns></returns>
        public override string ReplaceSpecialTemplate(string syspath, string skinName, string strTemplate)
        {
            Regex r;
            Match m;
            StringBuilder sb = new StringBuilder();
            sb.Append(strTemplate);
            return sb.ToString();
        }


        /// <summary>
        /// 获取模板内容
        /// </summary>
        /// <param name="skinName">皮肤名</param>
        /// <param name="templateName">模板名</param>
        /// <param name="nest">嵌套次数</param>
        /// <param name="templateid">皮肤id</param>
        /// <returns></returns>
        public override string GetTemplate(string syspath, string skinName, string templateName, int nest, int templateid, string Inherits)
        {
            return base.GetTemplate(syspath, skinName, templateName, nest, templateid, Inherits);
        }

    }
}
