<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="GroupUsers.aspx.cs" Inherits="QuanTri_Roles" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<div class="tieude">
        Quản lý nhóm người dùng
    </div>
    <table style="width:100%;border:1 thin blue;">
       <tr>
           <td style="height:30px"></td>
       </tr>
        <tr>
            <td class="tentruong"> Tên nhóm:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtTenQuyen" Width="300px" Height="25px"></asp:TextBox>
            <asp:Label ID="lblMa" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="tentruong">
           Tên quyền:
          </td>
          <td class="dieukhien">
           <asp:TextBox runat="server" ID="txtGhichu" Width="300px" Height="25px"></asp:TextBox>
          </td>
        </tr>
         <tr>
           <td style="height:5px"></td>
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
            <asp:GridView ID="grvQuyen" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" onselectedindexchanged="grvQuyen_SelectedIndexChanged" 
                    >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="Mã nhóm">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMa" Text='<%#Bind("UserGroupID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên nhóm" >
                            <ItemTemplate><%#Eval("UserGroupName")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên quyền" >
                            <ItemTemplate><%#Eval("RoleName") %></ItemTemplate>
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

