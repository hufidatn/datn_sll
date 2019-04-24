<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="PhieuDiemCuaTungHocSinh.aspx.cs" Inherits="GiaoDien_PhieuDiemCuaTungHocSinh" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<div class="tieude">
    Thông tin của học sinh
 </div>
 <table style="width:100%;border:1 thin blue;">
        
        <tr>
            
            <td class="tentruong"> Năm học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboNienKhoa" runat="server" Height="25px" AutoPostBack="True" 
                    onselectedindexchanged="cboNienKhoa_SelectedIndexChanged">
                </asp:ComboBox>
            </td>
        </tr>
       <%-- <tr>
            <td class="tentruong"> Kỳ học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboKy" runat="server" Height="25px">
                </asp:ComboBox>
            </td>
        </tr>--%>
        <tr>
            <td class="tentruong"> Lớp học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboLopHoc" runat="server" Height="25px" AutoPostBack="True" 
                    onselectedindexchanged="cboLopHoc_SelectedIndexChanged">
                </asp:ComboBox>
            </td>
        </tr>
      
        <tr>
            <td class="tentruong"> Tên học sinh:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboTenHS" runat="server" Height="25px" Width="250px">
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
        <td class="tentruong"></td>
        <td class="dongdieukhien">
        <asp:Button runat="server" ID="btnTimKiem" Text="Tìm kiếm" Height="25px" 
                Width="150px" onclick="btnTimKiem_Click" />
        </td>
        </tr>
        </table>
        <div id="divGridView" style="font-size:17px;">
            <asp:GridView ID="grvPhieuDiem" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" AllowPaging="True" BorderStyle="Solid" 
                Font-Overline="False" Font-Strikeout="False" Height="25px" 
                HorizontalAlign="Center" >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
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
                                    <%#String.Format("{0:dd/MM/yyyy}",Eval("DateOfBirth"))%>
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
                        <asp:TemplateField HeaderText="Xem điểm">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lkbXemDiem" Text="Xem điểm" PostBackUrl='<%#"~/GiaoDien/PhieuDiemChiTiet.aspx?StudentID="+Eval("StudentID")+"&SchoolYearID="+this.cboNienKhoa.SelectedItem.Value.ToString()
                            +"&ClassID="+this.cboLopHoc.SelectedItem.Value.ToString() +"&StudentName="+Eval("StudentName")
                            +"&ClassName="+this.cboLopHoc.SelectedItem.Text +"&SchoolYearName="+this.cboNienKhoa.SelectedItem.Text %> '></asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                           
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" Font-Size="17px" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                </asp:GridView>    
    </div>
</div>
</asp:Content>

