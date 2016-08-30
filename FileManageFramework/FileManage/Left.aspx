<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="FileManageFramework.FileManage.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文件列表</title>
    <link rel="stylesheet" href="Script/zTree/css/zTreeStyle/zTreeStyle.css" type="text/css" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Script/zTree/js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="Script/zTree/js/jquery.ztree.core-3.4.min.js"></script>
    <asp:Literal ID="ltlScript" runat="server"></asp:Literal>
</head>
<body>
    <table border="0" height="600px" align="left">
        <tr>
            <td width="260px" align="left" valign="top" class="td">
                <ul id="fileTree" class="ztree"></ul>
            </td>
        </tr>
    </table>
</body>
</html>
