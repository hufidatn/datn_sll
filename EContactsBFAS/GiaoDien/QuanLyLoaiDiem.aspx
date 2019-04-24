<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="QuanLyLoaiDiem.aspx.cs" Inherits="GiaoDien_QuanLyLoaiDiem" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1
        {
            text-align: right;
            padding: 10px;
            font-size: 17px;
            width: 265px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
 <div class="tieude">
 Quản lý loại điểm
 </div>
 <table style="margin-top:20PX">
   <tr>
     <td class="style1">
     Tên loại điểm:
     </td>
     <td>
        <asp:TextBox ID="txtTenLD" runat="server" Width="300px" Height="25px"></asp:TextBox>&nbsp
        <asp:Label ID="lbMaLD" Text="lbMa" runat="server" Visible="false"></asp:Label>
     </td>
   </tr>
   <tr>
   <td class="tentruong"></td>
     <td  class="dieukhien">
       <asp:Button runat="server" Text="Thêm" ID="btnThem" Width="79px" Height="25px" 
             onclick="btnThem_Click" />&nbsp&nbsp&nbsp
             <asp:Button runat="server" Text="Sửa" ID="btnSua" Width="79px" 
             Height="25px" onclick="btnSua_Click" 
             />&nbsp&nbsp&nbsp
             <asp:Button runat="server" Text="Xóa" ID="btnXoa" Width="79px" 
             Height="25px" onclick="btnXoa_Click" 
             />&nbsp&nbsp&nbsp
      <asp:Button runat="server" Text="Tạo mới" ID="btnMoi" Width="70px" Height="25px" 
             onclick="btnMoi_Click" />
     </td>
   </tr>
 </table>
 <div style="padding:5px;text-align:center">
   <asp:Panel ID="Panel1" runat="server" Width="760px">
       <asp:GridView ID="grvLoaiDiem" runat="server" Width="100%" 
                        AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="5" 
           onpageindexchanging="grvLoaiDiem_PageIndexChanging" 
           onselectedindexchanged="grvLoaiDiem_SelectedIndexChanged"
                        >
                       
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:TemplateField HeaderText="Mã loại điểm" SortExpression="MaLD">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TypeScoreID") %>'  ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TypeScoreID") %>' ID="lblMa"></asp:Label></EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên loại điểm" SortExpression="TenLD">
                                <ItemTemplate>
                                <%#Eval("TypeScoreName") %>
                                  </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("TypeScoreName") %>' ID="txtLD"></asp:TextBox></EditItemTemplate>
                            </asp:TemplateField>
                                                  
                            <asp:CommandField InsertText="" ShowSelectButton="True"
                                HeaderText="Chọn" />
                            
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
   </asp:Panel>
 </div>
 </div>
</asp:Content>


