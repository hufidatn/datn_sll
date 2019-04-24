<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="QuanLyGiaoVien.aspx.cs" Inherits="GiaoDien_QuanLyGiaoVien" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="khungchinh">
    
    <div class="tieude">
        Quản lý thông tin giáo viên
    </div>
    <table style="width:100%;border:1 thin blue;">

        
        <tr>
            <td class="tentruong"> Họ tên giáo viên:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtHoTen" Width="300px" Height="25px"></asp:TextBox>
            <label runat="server" id="lblChuThichTenGV" style="color:Red;" ></label></td>
            <asp:Label runat="server" ID="lblMa" Visible="false" ></asp:Label>
            
        </tr>

        <tr>
            <td class="tentruong">Email:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtEmail" Width="300px" Height="25px"></asp:TextBox>
            <label runat="server" id="lblChuThichEmail" style="color:Red"></label> </td>
        </tr>
       
        <tr>
            <td class="tentruong"> Số điện thoại:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtSDTDD" Width="150px" Height="25px"></asp:TextBox>
            <label runat="server" id="lblChuThichSDT" style="color:Red;" ></label> </td>
        </tr>   
        <tr>
            <td colspan="2" style="text-align:center">
            <label runat="server" id="lblThongBao" style="color:Red;text-align:center" ></label></td>
            
        </tr>
        <tr>
        <td class="tentruong"></td>
            <td  colspan="2" >
                <span >
                <asp:Button runat="server" ID="btnThem" Text="Thêm" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click"  />&nbsp;&nbsp;
                    </span>
                <asp:Button runat="server" ID="btnSua" Text="Sửa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnSua_Click"  />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnXoa" Text="Xóa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnXoa_Click" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="70px" 
                    Height="25px" Font-Size="15px" onclick="btnMoi_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="gridview">
           
            <asp:UpdatePanel runat="server" ID="uppl1">
            <ContentTemplate>
            <asp:GridView ID="grvGiaoVien" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="Vertical" AllowPaging="True" 
                         PageSize="10" 
                    onselectedindexchanged="grvGiaoVien_SelectedIndexChanged" onpageindexchanging="grvGiaoVien_PageIndexChanging" 
                      >
                   
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                    <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField>    
                            <asp:TemplateField HeaderText="Họ tên GV" SortExpression="StudentName">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TeacherName") %>' ID="lblTenGV"></asp:Label>
                                    <asp:Label runat="server" Text='<%#Bind("TeacherID") %>' ID="lblMaGV" Visible="false"></asp:Label>
                                </ItemTemplate>
                               
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <ItemTemplate>
                                    <%#Eval("Email")%></ItemTemplate>
                                    </asp:TemplateField>                               
                            <asp:TemplateField HeaderText="Số điện thoại" SortExpression="Phone">
                                <ItemTemplate>
                                    <%#Eval("Phone")%></ItemTemplate>
                                    </asp:TemplateField>
                        
                            <asp:CommandField ShowSelectButton="true" HeaderText="Chọn"  />
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#c6deff" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>

