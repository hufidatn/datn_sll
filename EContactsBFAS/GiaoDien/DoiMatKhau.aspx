<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="DoiMatKhau.aspx.cs" Inherits="GiaoDien_DoiMatKhau" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
  <div class="tieude">
     Đổi mật khẩu
  </div>
   <table>
      <tr>
         <td class="tentruong">
           Tên đăng nhập:
         </td>
         <td class="dieukhien">
           <asp:TextBox runat="server" ID="txtTenDN" Width="240px" Height="25px"></asp:TextBox>
         </td>
      </tr>
      <tr>
         <td class="tentruong"> Mật khẩu cũ:</td>
         <td class="dieukhien"><asp:TextBox runat="server" ID="txtMatKhauCu" Width="240px" 
                 Height="25px" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
         <td class="tentruong">Mật khẩu mới:</td>
         <td class="dieukhien"><asp:TextBox runat="server" ID="txtMatKhauMoi" Width="240px" 
                 Height="25px" TextMode="Password"></asp:TextBox></td>
      </tr>
       <tr>
         <td class="tentruong">Nhập lại khẩu mới:</td>
         <td class="dieukhien"><asp:TextBox runat="server" ID="txtNhapLai" Width="240px" 
                 Height="25px" TextMode="Password"></asp:TextBox></td>
      </tr>
      <tr>
      <td></td>
        <td class="dongdieukhien">&nbsp&nbsp&nbsp
         <asp:Button runat="server" ID="btnDoiMK" Text="Đổi mật khẩu" 
                onclick="btnDoiMK_Click" />
        </td>
      </tr>
       <tr>
      <td></td>
        <td class="dongdieukhien" style="color:Red">&nbsp&nbsp&nbsp
          <asp:Label runat="server" ID="lblThongBao"></asp:Label>
        </td>
      </tr>
   </table>
</div>
</asp:Content>

