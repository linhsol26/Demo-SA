<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SongForm.aspx.cs" Inherits="SongSite.SongForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Song Site</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>SONG LIST</h1>
        <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
        <asp:Button ID ="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"></asp:Button>
        <br />
        <br />
        <asp:GridView ID="gvSongs" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvSongs_SelectedIndexChanged"></asp:GridView>
        <br />
        <table>
            <tr>
                <td>Id</td>
                <td>
                    <asp:TextBox ID="txtID" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Title</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Singer</td>
                <td>
                    <asp:TextBox ID="txtSinger" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Genre</td>
                <td>
                    <asp:TextBox ID="txtGenre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Album</td>
                <td>
                    <asp:TextBox ID="txtAlbum" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID ="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"></asp:Button>
        <asp:Button ID ="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"></asp:Button>
        <asp:Button ID ="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"></asp:Button>
    </form>
</body>
</html>
