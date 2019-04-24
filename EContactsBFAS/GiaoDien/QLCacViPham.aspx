<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="QLCacViPham.aspx.cs" Inherits="GiaoDien_QLCacViPham" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div class="tieude">
        Các vi phạm của học sinh
        
   </div>
   <table style="width:100%">
        <tr>
            <td class="tentruong">
                Tên các lỗi vi phạm:
            </td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtLoiVP" Width="500px" 
                    Height="30px" ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tentruong">
                Ghi chú:
            </td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtGhiChu" Width="500px" 
                    Height="50px" ></asp:TextBox></td>
        </tr>
        
        <tr>
        <td class="tentruong"></td>
            <td class="dongdieukhien" >
                <asp:Button runat="server" ID="btnThem" Text="Thêm" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnSua" Text="Sửa" Width="70px" Height="25px" Font-Size="15px"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnXoa" Text="Xóa" Width="70px" Height="25px" Font-Size="15px"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="70px" Height="25px" Font-Size="15px"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:UpdatePanel runat="server" ID="uppl1">
            <ContentTemplate>
                <asp:GridView ID="grvLoiVP" runat="server" AutoGenerateColumns="False"
                AllowPaging="true" PageSize="10" 
                      Width="100%"
                     ForeColor="#333333" 
                     Height="28px" ShowFooter="True" 
                    onpageindexchanging="grvLoiVP_PageIndexChanging"  >
                    
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField> 
                        
                      
                        
                        <asp:TemplateField HeaderText="Tên lỗi vi phạm" SortExpression="ViolationID">
                        <ItemTemplate>
                            <%#Eval("ViolationName") %>
                        <asp:Label runat="server" ID="lblMaVP" Text='<%#Bind("ViolationID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ghi chú" SortExpression="">
                        <ItemTemplate>
                            <%#Eval("Description") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                         <asp:CommandField HeaderText="Chọn" ShowSelectButton="true" />
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                        BorderColor="Blue" Height="30px" />
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
   </table>
</div>
</asp:Content>

