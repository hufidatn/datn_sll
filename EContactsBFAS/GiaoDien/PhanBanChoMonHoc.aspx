<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="PhanBanChoMonHoc.aspx.cs" Inherits="GiaoDien_PhanBan" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="khungchinh">
    <div class="tieude">
        Thông tin phân môn cho ban
         
    </div>
    <table style="width:100%;border:1 thin blue;">
        
        <tr>
            <td class="tentruong"> Ban:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboBan" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Môn học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboMon" runat="server" Height="25px" Width="300px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Hệ số:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboHeSo" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
        <td class="tentruong"></td>
            <td class="dongdieukhien" >
                <asp:Button runat="server" ID="btnThem" Text="Thêm" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click"/>&nbsp;&nbsp;
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
            <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="Both" BorderStyle="Solid"
                      Font-Overline="False" Font-Strikeout="False"
                    onselectedindexchanged="grvHocSinh_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checked" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Ban" SortExpression="departmentID">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMaBan" Text='<%#Bind("DepartmentID") %>' Visible="false" ></asp:Label>
                            <asp:Label runat="server" ID="lblTenBan" Text='<%#Bind("DepartmentName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Môn" SortExpression="SubjectID">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMaMon" Text='<%#Bind("SubjectID") %>' Visible="false" ></asp:Label>
                            <asp:Label runat="server" ID="lblTenMon" Text='<%#Bind("SubjectName") %>' ></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hệ số" SortExpression="Multiplier">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblHeSo" Text='<%#Bind("Multiplier") %>' ></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="true" HeaderText="Chọn" />
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

