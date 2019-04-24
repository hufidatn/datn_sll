<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="NienHoc.aspx.cs" Inherits="GiaoDien_NienHoc" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="khungchinh">
<div class="tieude">
        Quản lý năm học
    </div>
    <table style="width:100%;border:1 thin blue;">
        <%--<tr>
            <td class="tentruong" style=""> Mã năm:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtMaNam" Width="300px" Height="25px"></asp:TextBox></td>
        </tr>--%>
        <tr>
            <td class="tentruong"> Tên năm:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtTenNam" Width="300px" Height="25px"></asp:TextBox>
            <asp:Label runat="server" ID="lblMaNam" Text="0"></asp:Label></td>
        </tr>
        <tr>
            <td class="tentruong"> Ngày bắt đầu:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtNgayBD" Width="150px" Height="25px"></asp:TextBox>
            <asp:CalendarExtender runat="server" ID="cld1" TargetControlID="txtNgayBD" Format="dd/MM/yyyy" Enabled="true"></asp:CalendarExtender></td>
        </tr>
        <tr>
            <td class="tentruong"> Ngày kết thúc:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtNgayKT" Width="150px" Height="25px"></asp:TextBox>
            <asp:CalendarExtender runat="server" ID="cld2" TargetControlID="txtNgayKT" Format="dd/MM/yyyy" Enabled="true"></asp:CalendarExtender></td>
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
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:GridView ID="grvNamHoc" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" BorderStyle="Solid"
                      Font-Overline="False" Font-Strikeout="False" 
                    onselectedindexchanged="grvNamHoc_SelectedIndexChanged" EnableModelValidation="True">
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
                        <asp:TemplateField HeaderText="Mã năm học" SortExpression="SchoolYearID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMaNam" Text='<%#Bind("SchoolYearID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên năm học" SortExpression="SchoolYearName">
                            <ItemTemplate><%#Eval("SchoolYearName")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày BĐ" SortExpression="BeginDate">
                        <ItemTemplate>
                            <%#String.Format("{0:dd/MM/yyyy}",Eval("BeginDate"))%>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày KT" SortExpression="EndDate">
                        <ItemTemplate>
                            <%#String.Format("{0:dd/MM/yyyy}",Eval("EndDate"))%>
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

