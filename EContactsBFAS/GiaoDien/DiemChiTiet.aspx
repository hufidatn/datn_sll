<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="DiemChiTiet.aspx.cs" Inherits="GiaoDien_DiemChiTiet" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="khungchinh">
    
    <div class="tieude">
        Chi tiết điểm của học sinh
    </div>
    <table style="width:100%;border:1 thin blue;">
        <tr>
            <td class="tentruong"> Năm học:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtNamHoc" Width="100px" Height="25px"></asp:TextBox></td>
            <td class="" style="width:150px;text-align:right"> Kỳ:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtKy" Width="100px" Height="25px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tentruong"> Lớp:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtLop" Width="100px" Height="25px"></asp:TextBox></td>
            <td class="" style="width:150px;text-align:right"> Môn học:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtMonHoc" Width="250px" Height="25px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tentruong"> Mã học sinh:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtMaHS" Width="100px" Height="25px"></asp:TextBox></td>
            <td class="" style="width:150px;text-align:right"> Tên học sinh:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtTenHS" Width="250px" Height="25px"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td class="tentruong">Điểm miệng:</td>
            <td class="dieukhien" colspan="3">
            <asp:TextBox runat="server" ID="txtDiemM1" Width="100px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtDiemM2" Width="100px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtDiemM3" Width="100px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtDiemM4" Width="100px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td class="tentruong">Điểm 15':</td>
            <td class="dieukhien" colspan="3">
            <asp:TextBox runat="server" ID="txtDiem15L1" Width="100px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtDiem15L2" Width="100px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtDiem15L3" Width="100px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txtDiem15L4" Width="100px" Height="25px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
        <td class="tentruong">Điểm 45':</td>
            <td class="dieukhien" colspan="3">
            <asp:TextBox runat="server" ID="txtDiem45L1" Width="100px" Height="25px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            
            <asp:TextBox runat="server" ID="txtDiem45L2" Width="100px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td class="tentruong">Điểm thi cuối kỳ:</td>
            <td class="dieukhien" colspan="3">
            
            <asp:TextBox runat="server" ID="txtDiemThi" Width="100px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td class="tentruong">Điểm thi lại:</td>
            <td class="dieukhien" colspan="3">
            <asp:TextBox runat="server" ID="txtThiLai" Width="100px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="dongdieukhien" colspan="4" align="center">
                
                <asp:Button runat="server" ID="btnBack" Text="Quay lai trang cũ" Width="150px" 
                    Height="25px" Font-Size="15px" onclick="btnBack_Click" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnSua" Text="Sửa điểm" Width="150px" 
                    Height="25px" Font-Size="15px" onclick="btnSua_Click" />&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnMoi" Text="Làm mới" Width="150px" 
                    Height="25px" Font-Size="15px" onclick="btnMoi_Click"  />&nbsp;&nbsp;
                
        
            </td>
        </tr>
        <tr>
            <td colspan="4" class="gridview">
            <asp:GridView ID="grvDiemChiTiet" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" 
                    onselectedindexchanged="grvDiemChiTiet_SelectedIndexChanged" Height="25px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField> 
                       <%--<asp:TemplateField HeaderText="Tên HS" SortExpression="StudentName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNam" Text='<%#Bind("StudentName") %>'></asp:Label>
                            
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Mã HS" SortExpression="MaHS">
                        <ItemTemplate>
                        <asp:Label runat="server" ID="lblMaHS" Text='<%# Bind("MaHS") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên HS" SortExpression="TenHS">
                        <ItemTemplate>
                        <asp:Label runat="server" ID="lblTenHS" Text='<%# Bind("TenHS") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Điểm miệng" SortExpression="DM1">
                        <ItemTemplate>
                        <asp:Label runat="server" ID="lblDM" Text='<%# Bind("DM1") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="M2" SortExpression="DM2">
                        <ItemTemplate>
                           <asp:Label runat="server" ID="lbM2" Text='<%# Bind("DM2") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="M3" SortExpression="DM3">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbM3" Text='<%# Bind("DM3") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="M4" SortExpression="DM4">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbM4" Text='<%# Bind("DM4") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Điểm 15'" SortExpression="D15p1">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblD15" Text='<%# Bind("D15p1") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="15'2" SortExpression="D15p2">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lb152" Text='<%# Bind("D15p2") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="15'3" SortExpression="D15p3">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lb153" Text='<%# Bind("D15p3") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="15'4" SortExpression="D15p4">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lb154" Text='<%# Bind("D15p4") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Điểm 45'" SortExpression="D45p1">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblD45" Text='<%# Bind("D45p1") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="45'2" SortExpression="D45p2">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lb452" Text='<%# Bind("D45p2") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="THK" SortExpression="DHK">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDHK" Text='<%# Bind("DHK") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thi lại" SortExpression="DiemThiLai">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTL" Text='<%# Bind("DiemThiLai") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:CommandField ShowSelectButton="true" HeaderText="Chọn" />
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                        Height="30px" />
                </asp:GridView>
                &nbsp;</td>
        </tr>
  </table>
 </div>
 </asp:Content>
        

