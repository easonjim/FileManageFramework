
#region Comment

/*
 * Project：    FileManageFramework
 * 
 * FileName:    ConfingHelper.cs
 * CreatedOn:   2012-10-20
 * CreatedBy:   EasonJim
 * 
 * 
 * Description：
 *      ->
 *      web.config文件访问类
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
using System.Configuration;

namespace FileManageFramework.FileManage
{
    /// <summary>
    /// web.config访问类
    /// </summary>
    public class ConfingHelper
    {
        /// <summary>
        /// 获取键值字符串
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>string</returns>
        public static string GetKeyValue(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();        
        }

        /// <summary>
        /// 获取键值真假
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>bool</returns>
        public static bool GetKeyBoolean(string key)
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings[key].ToString().ToLower());
        }
    }
}