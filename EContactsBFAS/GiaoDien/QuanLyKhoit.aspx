<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="QuanLyKhoit.aspx.cs" Inherits="GiaoDien_QuanLyKhoit" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="khungchinh">
<div class="tieude">
        Quản lý khối học
    </div>
    <table style="width:100%;border:1 thin blue;">
        <tr>
            <td class="tentruong" style=""> Mã khối:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtMaKhoi" Width="300px" Height="25px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tentruong"> Tên khối:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtTenKhoi" Width="300px" Height="25px"></asp:TextBox></td>
        </tr>
        
        <tr>
        <td class="tentruong"></td>
            <td class="dongdieukhien">
                <asp:Button runat="server" ID="btnThem" Text="Thêm" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnSua" Text="Sửa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnSua_Click" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnXoa" Text="Xóa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnXoa_Click"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="70px" 
                    Height="25px" Font-Size="15px" onclick="btnMoi_Click"/>
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:GridView ID="grvKhoi" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="None" onselectedindexchanged="grvKhoi_SelectedIndexChanged" 
                    >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checked" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                        <asp:TemplateField HeaderText="Mã khối" SortExpression="GradeSchoolID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMa" Text='<%#Bind("GradeSchoolID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên khối học" SortExpression="GradeSchoolName">
                            <ItemTemplate><%#Eval("GradeSchoolName")%></ItemTemplate>
                        </asp:TemplateField>
                         <asp:CommandField ShowSelectButton="true" HeaderText="Chọn" />
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
</asp:Content>

