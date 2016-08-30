<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Center.aspx.cs" Inherits="FileManageFramework.FileManage.Center" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文件编辑</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="center">
        <asp:Button ID="btnBack" runat="server" Text="返回" />      
    </div>
    <div class="center">
        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="99%" Height="500px"></asp:TextBox>    
    </div>
    <div class="center">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" onclick="btnSave_Click" />
        <input type="reset" name="reset" value="重置" />
    </div>
    </form>
</body>
</html>


