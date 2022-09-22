<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookHandle.aspx.cs" Inherits="Semester_Project_BookStore.BookHandle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
                <tr>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text="Enter Id"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Enter Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblGenre" runat="server" Text="Enter Genre"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtGenre" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblAuthor" runat="server" Text="Enter Author"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                        <asp:Label ID="lbl" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Enter Description"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrice" runat="server" Text="Enter Price"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:FileUpload ID="fileUpload" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>

                    <td>
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                        &nbsp;
                    <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_Click" />
                        &nbsp;
                    <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" />
                        &nbsp;
                    <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gridViewProduct" runat="server"></asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td></td>
                </tr>
            </table>
</asp:Content>
