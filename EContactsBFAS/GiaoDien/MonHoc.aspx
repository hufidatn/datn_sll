<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="MonHoc.aspx.cs" Inherits="GiaoDien_MonHoc" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<div class="tieude">
        Quản lý môn học
    </div>
    <table style="width:100%;border:1 thin blue;">
        <%--<tr>
            <td class="tentruong" style=""> Mã môn:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtMaMon" Width="300px" Height="25px"></asp:TextBox></td>
        </tr>--%>
        <tr>
            <td class="tentruong"> Tên môn:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtTenMon" Width="300px" Height="25px"></asp:TextBox>
            <asp:Label runat="server" ID="lblMaMon"></asp:Label></td>
        </tr>
        
        <tr>
        <td class="tentruong"></td>
            <td class="dongdieukhien">
                <asp:Button runat="server" ID="btnThem" Text="Thêm" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnSua" Text="Sửa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnSua_Click"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnXoa" Text="Xóa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnXoa_Click"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="70px" 
                    Height="25px" Font-Size="15px" onclick="btnMoi_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:GridView ID="grvMonHoc" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="grvMonHoc_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                       <%-- <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checked" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                         <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                        </asp:TemplateField> 
                        <%--<asp:TemplateField HeaderText="Mã môn">
                        <ItemTemplate >
                            <asp:Label runat="server" ID="lblMaMon" Text='<%#Bind("SubjectID") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Tên môn">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTenMon" Text='<%#Bind("SubjectName") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblMaMon" Text='<%#Bind("SubjectID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                           <asp:CommandField  HeaderText="Chọn" ShowSelectButton="true"/> 
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>

