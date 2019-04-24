<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="Acounts.aspx.cs" Inherits="QuanTri_GroupUsers" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<div class="tieude">
        Tạo tài khoản cho người dùng
    </div>
    <table style="width:100%;border:1 thin blue;">
       <tr>
           <td style="height:30px"></td>
       </tr>
        <tr>
            <td class="tentruong">Mã người dùng:</td>
            <td class="dieukhien">
                <asp:TextBox ID="txtMa" runat="server" Width="300px" Height="25px"></asp:TextBox>
                </td>
        </tr>
        <tr>
          <td class="tentruong">
           Tên người dùng:
          </td>
          <td class="dieukhien">
           <asp:TextBox runat="server" ID="txtNguoiDung" Width="300px" Height="25px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="tentruong">
           Tên đăng nhập:
          </td>
          <td class="dieukhien">
           <asp:TextBox runat="server" ID="txtDangNhap" Width="300px" Height="25px"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="tentruong">
           Mật khẩu:
          </td>
          
          <td class="dieukhien">
           <asp:TextBox runat="server" ID="txtMatKhau" Width="300px" Height="25px" 
                  TextMode="Password"></asp:TextBox>
          </td>
        </tr>
         <tr>
           <td style="height:5px"></td>
       </tr>
        <tr>
        <td class="tentruong"></td>
            <td class="dongdieukhien">
                <asp:Button runat="server" ID="btnThem" Text="Tạo TK" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click" />&nbsp;&nbsp;
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
            <asp:GridView ID="grvTaiKhoan" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" 
                    onselectedindexchanged="grvTaiKhoan_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                    <asp:TemplateField HeaderText="STT">
                         <ItemTemplate> <%# Container.DataItemIndex + 1 %> </ItemTemplate>
                         </asp:TemplateField>
                        <asp:TemplateField HeaderText="Họ và tên">
                            <ItemTemplate>
                               <asp:Label ID="lblTen" Text='<%#Bind("TeacherName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên đăng nhập" >
                            <ItemTemplate>
                               <asp:Label ID="lblUser" Text='<%#Bind("UserName") %>' runat="server"></asp:Label>
                           </ItemTemplate>
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

