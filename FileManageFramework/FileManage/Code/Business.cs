
#region Comment

/*
 * Project：    FileManageFramework
 * 
 * FileName:    Business.cs
 * CreatedOn:   2012-10-20
 * CreatedBy:   EasonJim
 * 
 * 
 * Description：
 *      ->
 *      核心代码实现业务逻辑类
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace FileManageFramework.FileManage
{
    /// <summary>
    /// FileManageFramework核心业务逻辑实现类
    /// </summary>
    public class Business
    {
        #region 通过递归舒适化zTree控件

        /// <summary>
        /// 初始化文件树
        /// </summary>
        /// <param name="page">当前页面对象</param>
        /// <param name="ltlScript">Asp.Net的Literal控件</param>
        public void InitTree(Page page, Literal ltlScript)
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script type=\"text/javascript\"><!--\r\nvar setting = {};var nodes = [");
            script.Append("{name:\"" + GetAssemblyName() + "\",open:true,children:[");
            script.Append(GetFolders(page.Server.MapPath("~/")));
            script.Append("," + GetFiles(page.Server.MapPath("~/")));
            script.Append("]}];$(document).ready(function(e){$.fn.zTree.init($(\"#fileTree\"),setting,nodes)});\r\n//--></script>");
            ltlScript.Text = script.ToString();
        }

        /// <summary>
        /// 递归获取文件夹
        /// </summary>
        /// <param name="serverMapPath">服务器的物理路径</param>
        /// <returns>string</returns>
        private string GetFolders(string serverMapPath)
        {
            DirectoryInfo info = new DirectoryInfo(serverMapPath);
            DirectoryInfo[] infos = info.GetDirectories();
            StringBuilder script = new StringBuilder();
            foreach (DirectoryInfo item in infos)
            {
                if (CheckFolders(item.Name))//判断需要显示的文件夹
                {
                    script.Append("{name:\"" + item.Name + "\"");
                    if (ExistFolder(item.FullName))//判断是否还有文件夹
                    {
                        script.Append(",children:[");
                        script.Append(GetFolders(item.FullName));
                        script.Append(!String.IsNullOrEmpty(GetFiles(item.FullName)) ? "," + GetFiles(item.FullName) : String.Empty);
                        script.Append("]},");
                    }
                    else
                    {
                        script.Append(",children:[");
                        script.Append(GetFiles(item.FullName));
                        script.Append("]");
                        script.Append(String.IsNullOrEmpty(GetFiles(item.FullName)) ? ",isParent:true" : "");
                        script.Append("},");
                    }
                }
            }

            return script.Length > 0 ? script.ToString().Substring(0, script.Length - 1) : script.ToString();
        }

        /// <summary>
        /// 文件夹目录里是否还存在文件夹
        /// </summary>
        /// <param name="folderPath">文件夹目录</param>
        /// <returns>bool</returns>
        private bool ExistFolder(string folderPath)
        {
            DirectoryInfo info = new DirectoryInfo(folderPath);
            DirectoryInfo[] infos = info.GetDirectories();
            return infos.Length > 0 ? true : false;
        }

        /// <summary>
        /// 获取指定目录下的文件
        /// </summary>
        /// <param name="serverMapPath">服务器的物理路径</param>
        /// <returns>string</returns>
        private string GetFiles(string serverMapPath)
        { 
            DirectoryInfo info = new DirectoryInfo(serverMapPath);
            FileInfo[] infos = info.GetFiles();
            StringBuilder script = new StringBuilder();
            foreach (FileInfo item in infos)
            {
                if (CheckFiles(item.Name))
                {
                    script.Append("{name:\"" + item.Name + "\",url:\"Center.aspx?FilePath=" + item.FullName.Replace("\\","\\\\") + "\",target:\"center\",icon:\"Images/page.png\"},");
                }
            }
            return script.Length > 0 ? script.ToString().Substring(0, script.Length - 1) : script.ToString();
        }

        /// <summary>
        /// 检查不需要显示的文件夹
        /// 不需要显示为false
        /// 需要显示为true
        /// </summary>
        /// <param name="folderName">文件夹名</param>
        /// <returns>bool</returns>
        private bool CheckFolders(string folderName)
        {
            if (String.IsNullOrEmpty(folderName))
            {
                return true;
            }
            string[] floders = ConfingHelper.GetKeyValue("Folders").Split(",".ToCharArray());
            foreach (string item in floders)
            {
                if (item.Equals(folderName))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检查不需要显示的文件
        /// 不需要显示为false
        /// 需要显示为true
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>bool</returns>
        private bool CheckFiles(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return true;
            }
            string[] files = ConfingHelper.GetKeyValue("Files").Split(",".ToCharArray());
            foreach (string item in files)
            {
                if (item.Equals(fileName.Substring(fileName.LastIndexOf(".") + 1)))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region 获取项目名称

        /// <summary>
        /// 获取程序集名称
        /// </summary>
        /// <returns>string</returns>
        private static string GetAssemblyName()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(Business));
            return assembly.GetName().Name;
        }

        #endregion 

        #region 设置返回按钮

        /// <summary>
        /// 设置返回按钮
        /// </summary>
        /// <param name="btnBack">Asp.Net的Button控件</param>
        public void SetBackButton(Button btnBack)
        {
            btnBack.Visible = ConfingHelper.GetKeyBoolean("IsBackButton");
            btnBack.PostBackUrl = ConfingHelper.GetKeyValue("BackButtonURL");
        }

        #endregion

        #region 文件内容操作

        /// <summary>
        /// 设置文本框
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="txtContent">Asp.Net的TextBox控件</param>
        public void SetTextBox(string filePath,TextBox txtContent)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                txtContent.Text = reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 保存内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="txtContent">Asp.Net的TextBox控件</param>
        /// <returns>bool</returns>
        public bool SaveContent(string filePath, TextBox txtContent)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine(txtContent.Text);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}