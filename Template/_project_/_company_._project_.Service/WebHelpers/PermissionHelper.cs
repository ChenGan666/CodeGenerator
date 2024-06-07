using System.Collections.Generic;
using _company_._project_.BLL;
using _company_._project_.Entity;

namespace _company_._project_.Service.WebHelpers
{
    public class PermissionHelper
    {
        private static List<LayuiTreeData> _layuiTreeDataList;

        public static List<LayuiTreeData> GetLayuiTreeDataList(string permissionStr)
        {
            var pList =  PermissionInfoBussiness.GetList("ParentID = 0");
            var layuiTree = new List<LayuiTreeData>();
            LoopLayuiTreeDataList(permissionStr,pList, layuiTree,false);
            return layuiTree;
        }

        private static void LoopLayuiTreeDataList(string permissionStr, List<PermissionInfo> pList, List<LayuiTreeData> childTreeList, bool disabled)
        {
            
            for (int j=0;j< pList.Count; j++)
            {
                string disabledflag = (!pList[j].IsUse || disabled) ? "true" : "";
                bool CheckedStr = false;
                if (permissionStr.Trim() != "")
                {
                    CheckedStr = ("," + permissionStr + ",").IndexOf("," + pList[j].PermissionID.ToString() + ",") > -1 ? true : false;
                }
                childTreeList.Add(new LayuiTreeData
                {
                    title = pList[j].PermissionName,
                    id = pList[j].PermissionID.ToString(),
                    field = "Permission",
                    spread = true,
                    Checked = CheckedStr,
                    disabled = disabledflag,
                    children = new List<LayuiTreeData> ()
                });
                List<PermissionInfo> ChildList = PermissionInfoBussiness.GetList("ParentID = " + pList[j].PermissionID);
                if (ChildList.Count>0)
                {
                    disabled = disabledflag == "true" ? true : false;


                    LoopLayuiTreeDataList(permissionStr,ChildList, childTreeList[j].children, disabled);
                }
            }
       
        }

        public static List<zTreeData> GetzTreeDataList(string permissionStr)
        {
            List<PermissionInfo> pList = PermissionInfoBussiness.GetList("ParentID = 0");
            List<zTreeData> zTreeData = new List<zTreeData>();
            LoopzTreeDataList(permissionStr, pList, zTreeData, false);
            return zTreeData;
        }

        private static void LoopzTreeDataList(string permissionStr, List<PermissionInfo> pList, List<zTreeData> childTreeList, bool disabled)
        {

            for (int j = 0; j < pList.Count; j++)
            {
                bool disabledflag = (!pList[j].IsUse || disabled) ?true : false;
                bool CheckedStr = false;
                if (permissionStr.Trim() != "")
                {
                    CheckedStr = ("," + permissionStr + ",").IndexOf("," + pList[j].PermissionID.ToString() + ",") > -1 ? true : false;
                }
                childTreeList.Add(new zTreeData
                {
                    name = pList[j].PermissionName,
                    id = pList[j].PermissionID,
                    pId = pList[j].ParentID,
                    open = true,
                    Checked = CheckedStr,
                    chkDisabled = disabledflag,
                    children = new List<zTreeData>()
                });
                List<PermissionInfo> ChildList = PermissionInfoBussiness.GetList("ParentID = " + pList[j].PermissionID);
                if (ChildList.Count > 0)
                {
                    LoopzTreeDataList(permissionStr, ChildList, childTreeList[j].children, disabledflag);
                }
            }
        }
    }


    public partial class LayuiTreeData
    {
        public LayuiTreeData() { }

        public string title { get; set; }
        public string id { get; set; }
        public string field { get; set; }

        public bool spread { get; set; } = false;
        public bool Checked { get; set; } = false;

        public List<LayuiTreeData> children { get; set; } = null;

        public string disabled { get; set; } = "";
    }

    public partial class zTreeData
    {
        public zTreeData() { }

        public int id { get; set; }
        public string name { get; set; }

        public int pId { get; set; } 
        public bool Checked { get; set; } = false;

        public List<zTreeData> children { get; set; } = null;

        public bool open { get; set; } = true;

        public bool chkDisabled { get; set; } = false;
    }

}