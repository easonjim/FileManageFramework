
#region Comment

/*
 * Project：    FileManageFramework
 * 
 * FileName:    Left.aspx.cs
 * CreatedOn:   2012-10-20
 * CreatedBy:   EasonJim
 * 
 * 
 * Description：
 *      ->
 *      文件列表
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

namespace FileManageFramework.FileManage
{
    /// <summary>
    /// 文件列表页面
    /// </summary>
    public partial class Left : System.Web.UI.Page
    {
        private Business businuess = new Business();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                businuess.InitTree(this.Page,this.ltlScript);
            }
        }
    }
}