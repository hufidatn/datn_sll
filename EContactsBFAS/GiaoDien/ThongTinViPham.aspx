<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="ThongTinViPham.aspx.cs" Inherits="GiaoDien_ThongTinViPham" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="khungchinh">
    <div class="tieude">
        Thông tin vi phạm của học sinh
    </div>
    <table style="width:100%;border:1 thin blue;">
        
        <tr>
            <td class="tentruong"> Năm học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboNamHoc" runat="server" Height="25px" AutoPostBack="True" 
                    onselectedindexchanged="cboNamHoc_SelectedIndexChanged">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Tên lớp:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboTenLop" runat="server" Height="25px" AutoPostBack="True" 
                    onselectedindexchanged="cboTenLop_SelectedIndexChanged">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong">Học sinh vi phạm:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboHocSinh" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong">Môn học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboMonHoc" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
        <%--<tr>
            <td class="tentruong">Giáo viên chủ nhiệm:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboGVCN" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>
        --%>
        <tr>
            <td class="tentruong"> Ngày vi phạm:</td>
            <td class="dieukhien">
                <asp:TextBox runat="server" ID="txtNgayThang" Height="25px"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="cld1" TargetControlID="txtNgayThang" Format="dd/MM/yyyy" Enabled="true"></asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Hình thức vi phạm:</td>
            <td class="dieukhien">
                <asp:ComboBox runat="server" ID="cboViPham" Width="300px" Height="25px"></asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Số lần vi phạm:</td>
            <td class="dieukhien">
                <asp:TextBox runat="server" ID="txtSL" Width="300px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Đề xuất xử lý:</td>
            <td class="dieukhien">
                <asp:TextBox runat="server" ID="txtXuLy" Width="400px" Height="40px"  ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Trạng thái gửi:</td>
            <td class="dieukhien">
                <asp:CheckBox runat="server" ID="ckTrangThaiGui" Height="25px" />
                <asp:Label runat="server" ID="lblMaVPh" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center"><label id="lblThongBao" runat="server" style="color:Red;"></label></td>
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
                <asp:Button runat="server" ID="btnSMS" Text="Gửi SMS" onclick="btnSMS_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <asp:UpdatePanel runat="server" ID="uppl1">
            <ContentTemplate>
            <asp:GridView ID="grvTTVP" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="Both" BorderStyle="Solid"
                      Font-Overline="False" Font-Strikeout="False" AllowPaging="true" PageSize="10"
                    onselectedindexchanged="grvTTVP_SelectedIndexChanged" 
                    onpageindexchanging="grvTTVP_PageIndexChanging">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Mã HS" SortExpression="StudentID">
                        <ItemTemplate>
                            <%#Eval("StudentID") %>
                            <asp:Label runat="server" ID="lblMaVP" Text='<%#Bind("SanctionID") %>' Visible="false" ></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên HS" SortExpression="StudentName" >
                        <ItemTemplate>
                            <%#Eval("StudentName") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lỗi VP" SortExpression="ViolationName">
                        <ItemTemplate>
                            <%#Eval("ViolationName") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ngày VP" SortExpression="DateViolation">
                        <ItemTemplate>
                            <%#String.Format("{0:dd/MM/yyyy}",Eval("DateViolation"))%>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Môn học" SortExpression="SubjectName">
                        <ItemTemplate>
                            <%#Eval("SubjectName") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Xử lý" SortExpression="SanctionName">
                        <ItemTemplate>
                            <%#Eval("SanctionName") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TT chờ gửi" SortExpression="StateMessage">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="ckTTCho" Enabled="false" Checked='<%#Bind("StateMessage") %>'  />
                        </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="TT gửi" SortExpression="StateSendMessage">
                        <ItemTemplate>
                           <asp:CheckBox runat="server" ID="ckTTGui" Enabled="false" Checked='<%#Bind("StateSendMessage") %>' />
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Số lần" SortExpression="Number">
                        <ItemTemplate>
                            <%#Eval("Number") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="true" />
                           
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

