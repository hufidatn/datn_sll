<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="DanhSachHocSinh.aspx.cs" Inherits="GiaoDien_DanhSachHocSinh" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="khungchinh">
    <div class="tieude">
        Danh sách học sinh trong một lớp
    </div>
    <table style="width:100%;border:1 thin blue;">
       
        <tr>
            <td class="tentruong" style="width:50%"> Năm học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboNamHoc" runat="server" Height="25px" AutoPostBack="True" 
                    onselectedindexchanged="cboNamHoc_SelectedIndexChanged">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong" style="width:50%"> Tên lớp:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboLop" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
       
        <tr>
       
            <td class="dongdieukhien" colspan="2" align="center" >
                <asp:Button runat="server" ID="btnThem" Text="Hiển thị" Width="150px" Height="25px" 
                    onclick="btnThem_Click"/>&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnXuatEcel" Text="Xuất ra excel" 
                    Width="150px" Height="25px" onclick="btnXuatEcel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                <asp:Label runat="server" ID="lblSTT" Text='<%# Container.DataItemIndex + 1 %>'>   </asp:Label>  
                                </ItemTemplate>   
                    </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Mã học sinh" SortExpression="StudentID">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMaHS" Text='<%#Bind("StudentID") %>'></asp:Label>
                        </ItemTemplate>
                            <ControlStyle Height="25px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên học sinh" SortExpression="StudentName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTenHS" Text='<%#Bind("StudentName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày sinh" SortExpression="DateOfBirth">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNgaySinh" Text=' <%#String.Format("{0:dd/MM/yyyy}",Eval("DateOfBirth"))%>'></asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giới tính" SortExpression="Gender">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblGioi" Text='<%#Bind("Gender")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Địa chỉ" SortExpression="Address">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDC" Text='<%#Bind("Address")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>
