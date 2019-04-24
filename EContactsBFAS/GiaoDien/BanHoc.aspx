<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="BanHoc.aspx.cs" Inherits="GiaoDien_BanHoc" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<div class="tieude">
        Quản lý ban học
    </div>
    <table style="width:100%;border:1 thin blue;">
        <%--<tr>
            <td class="tentruong" style=""> Mã ban:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtMaBan" Width="300px" Height="25px"></asp:TextBox></td>
        </tr>--%>
        <tr>
            <td class="tentruong"> Tên ban:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtTenBan" Width="300px" Height="25px"></asp:TextBox>
            <asp:Label runat="server" ID="lblMaBan" Visible="false"></asp:Label></td>
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
            <asp:GridView ID="grvBan" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="Both" BorderStyle="Solid"
                      Font-Overline="False" Font-Strikeout="False"
                    onselectedindexchanged="grvBan_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checked" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                        </asp:TemplateField> 
                        
                        <%--<asp:TemplateField HeaderText="Mã ban">   
                          <ItemTemplate>
                            <asp:Label runat="server" ID="lblMa" Text='<%#Bind("DepartmentID") %>' ></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Tên ban">   
                          <ItemTemplate>
                            <asp:Label runat="server" ID="lblTen" Text='<%#Bind("DepartmentName") %>' ></asp:Label>
                            <asp:Label runat="server" ID="lblMa" Text='<%#Bind("DepartmentID") %>' Visible="false" ></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:CommandField ShowSelectButton="true" HeaderText="Chọn"  />
                        <%--<asp:CheckBoxField HeaderText="Chọn" ShowHeader="true" Visible="true" />--%>
                           
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#c6deff" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>

