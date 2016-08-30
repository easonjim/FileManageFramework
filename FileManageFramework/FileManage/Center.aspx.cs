
#region Comment

/*
 * Project：    FileManageFramework
 * 
 * FileName:    Center.aspx.cs
 * CreatedOn:   2012-10-20
 * CreatedBy:   EasonJim
 * 
 * 
 * Description：
 *      ->
 *      文件内容编辑
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
    /// 文件内容编辑页面
    /// </summary>
    public partial class Center : System.Web.UI.Page
    {
        private Business business = new Business();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InitButton();
                if (!String.IsNullOrEmpty(Request.QueryString["FilePath"]))
                {
                    this.SetContent(Request.QueryString["FilePath"].ToString());
                }
            }
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitButton()
        {
            business.SetBackButton(this.btnBack);
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        private void SetContent(string filePath)
        {
            business.SetTextBox(filePath, this.txtContent);
        }

        /// <summary>
        /// 确认保存按钮
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["FilePath"]))
            {
                if (business.SaveContent(Request.QueryString["FilePath"], this.txtContent))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ok", "alert('修改成功！')", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "error", "alert('修改失败！')", true);
                }
            }
            
        }
    }
}