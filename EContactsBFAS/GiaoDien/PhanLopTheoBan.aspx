<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="PhanLopTheoBan.aspx.cs" Inherits="GiaoDien_PhanLop" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="khungchinh">
    <div class="tieude">
        Thông tin phân lớp
    </div>
    <table style="width:100%;border:1 thin blue;">
       
        <tr>
            <td class="tentruong"> Năm học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboNamHoc" runat="server" Height="25px">
                </asp:ComboBox>
                <%--<asp:ComboBox ID="cboNamHoc" runat="server" Height="25px">
                </asp:ComboBox>--%>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Tên lớp:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboTenLop" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Ban học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboBan" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Giáo viên chủ nhiệm:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboGVCN" runat="server" Height="25px" Width="200px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <label id="lblThongBao" runat="server" style="color:Red"></label>
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
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="70px" Height="25px" Font-Size="15px"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:GridView ID="grvPLTB" runat="server" AllowPaging="true" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="Both" BorderStyle="Solid"
                      Font-Overline="False" Font-Strikeout="False" PageIndex="10" 
                    onselectedindexchanged="grvPLTB_SelectedIndexChanged">
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
                        <asp:TemplateField HeaderText="Năm học">
                        <ItemTemplate>
                        <asp:Label ID="lblMaNam" runat="server" Visible="false" Text='<%#Eval("SchoolYearID") %>'></asp:Label>
                         <asp:Label ID="lblNam" runat="server" Text='<%#Eval("SchoolYearName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên lớp">
                        <ItemTemplate>
                        <asp:Label ID="lblMaLop" runat="server" Visible="false" Text='<%#Eval("ClassID") %>'></asp:Label>
                        <asp:Label ID="lblLop" runat="server" Text='<%#Eval("ClassName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ban học">
                        <ItemTemplate>
                        <asp:Label ID="lblBan" runat="server" Text='<%#Eval("DepartmentName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ban học">
                        <ItemTemplate>
                        <asp:Label ID="lblGVCN" runat="server" Text='<%#Eval("TeacherName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Chọn" ShowSelectButton="true" />
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

