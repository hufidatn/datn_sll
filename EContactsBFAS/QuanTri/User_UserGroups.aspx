<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="User_UserGroups.aspx.cs" Inherits="QuanTri_User_UserGroups" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<div class="tieude">
        Phân quyền cho người dùng
    </div>
    <table style="width:100%;border:1px thin #5f9ae0">
       <tr>
           <td style="height:30px"></td>
       </tr>
        <tr >
            <td class="tentruong">Tên nhóm người dùng:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboNhom" runat="server" Width="250px" AutoPostBack="True" 
                    onselectedindexchanged="cboNhom_SelectedIndexChanged">
                </asp:ComboBox>
                </td>
        </tr>
        <tr>
          <td class="tentruong">
           Năm phân quyền:
          </td>
          <td class="dieukhien">
              <asp:ComboBox ID="cboNam" runat="server" Width="250px">
              </asp:ComboBox>
          </td>
        </tr>
         <tr>
           <td class="tentruong">
           Tên quyền:
           </td>
           <td class="dieukhien">
               <asp:ComboBox ID="cboNhómQuyền" runat="server" AutoPostBack="True" Width="250px" Height="30px"
                   onselectedindexchanged="cboNhómQuyền_SelectedIndexChanged">
               </asp:ComboBox>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
               <br />
               <asp:CheckBoxList id="ckQuyen" runat="server">
               <asp:ListItem Value="0">Tạo tài khoản</asp:ListItem>
               <asp:ListItem Value="1">Phân quyền</asp:ListItem>
               <asp:ListItem Value="2">Quản lý thông tin:Ban-Khối-Lớp-Năm-Môn-Loại Điểm</asp:ListItem>
               <asp:ListItem Value="3">Gửi bảng điểm</asp:ListItem>
               <asp:ListItem Value="4">Đăng nhập</asp:ListItem>
               <asp:ListItem Value="5">Thay đổi mật khẩu</asp:ListItem>
               <asp:ListItem Value="6">Xem và tính DTBHK,DTBCN cho 1 lớp</asp:ListItem>
               <asp:ListItem Value="7">Đánh giá kết quả rèn luyện của 1 lớp</asp:ListItem>
               <asp:ListItem Value="8">Cập nhật điểm cho 1 môn</asp:ListItem>
               <asp:ListItem Value="9">Nhận xét thông qua môn </asp:ListItem>
               <asp:ListItem Value="10">Xem thống kê điểm,học lực hạnh kiểm</asp:ListItem>
               </asp:CheckBoxList>
           <br />
          </td>
       </tr>
       <tr>
       <td></td>
           <td class="dieukhien"><asp:Label ID="lblHienThi" runat="server"></asp:Label></td>
       </tr>
        <tr>
        <td class="tentruong"></td>
            <td class="dongdieukhien">
                <asp:Button runat="server" ID="btnThem" Text="Cập nhật" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnXoa" Text="Hủy" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnXoa_Click"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="70px" 
                    Height="25px" Font-Size="15px" />
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
        <td style="color:Blue">
         Thông tin người dùng
        </td>
        <td class="dieukhien">
        <asp:CheckBox ID="ckTatCa" Text="Phân quyền cho tất cả
        " runat="server" AutoPostBack="True" oncheckedchanged="ckTatCa_CheckedChanged" />
        </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:GridView ID="grvNguoiDung" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" 
                    >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:CheckBox ID="ckbTao" runat="server" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT">
                         <ItemTemplate> <%# Container.DataItemIndex + 1 %> </ItemTemplate>
                         </asp:TemplateField>
                           <asp:TemplateField HeaderText="Tên đăng nhập">
                            <ItemTemplate>
                               <asp:Label ID="lblTenDN" Text='<%#Bind("UserName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Họ và tên">
                            <ItemTemplate>
                               <asp:Label ID="lblTenND" Text='<%#Bind("TeacherName") %>' runat="server"></asp:Label>
                                <asp:Label ID="lblMa" Text='<%#Eval("TeacherID") %>' Width="0px" runat="server" Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr> 
            <td></td>
        </tr>
        <tr> 
           <td style="color:Blue">
           Thông về phân nhóm người dùng
           </td>
        </tr>
        <tr>
        <td colspan="2" class="gridview">
            <asp:GridView ID="grvPhanQuyen" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" onselectedindexchanged="grvPhanQuyen_SelectedIndexChanged1" 
                    >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                    <asp:TemplateField HeaderText="STT">
                         <ItemTemplate> <%# Container.DataItemIndex + 1 %> </ItemTemplate>
                         </asp:TemplateField>
                           <asp:TemplateField HeaderText="Tên đăng nhập">
                            <ItemTemplate>
                               <asp:Label ID="lblTenDN" Text='<%#Bind("UserName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Họ và tên">
                            <ItemTemplate>
                               <asp:Label ID="lblTenND" Text='<%#Eval("TeacherName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Năm phân quyền">
                            <ItemTemplate>
                               <asp:Label ID="lblTen" Text='<%#Eval("SchoolYearName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quyền">
                        <ItemTemplate>
                        <%#Eval("RoleName") %>
                          <asp:Label ID="lblMa" Text='<%#Bind("UserGroupID") %>' runat="server" Visible="false"></asp:Label>
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

