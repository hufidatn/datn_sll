<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="NhapHSTheoLopExcel.aspx.cs" Inherits="GiaoDien_NhapHSTheoLopExcel" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div class="tieude">    
        Nhập danh sách học sinh theo lớp
    </div>
    <div style="font-size:20px; font-style:italic; height:30px;padding-left:10px;">    
        <asp:LinkButton runat="server" ID="lkbtNhap" Text="Trang phân lớp" PostBackUrl="~/GiaoDien/ChuyenLopChoHS.aspx"></asp:LinkButton><= Nhập từ excel
    </div>
    <table style="width:100%">
        <tr>
            <td class="tentruong" style="width:50%"> Năm học:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboNamHoc" runat="server" Height="25px" AutoPostBack="True" Width="120px" >
                    
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong" style="width:50%"> Tên lớp mới:</td>
            <td class="dieukhien">
                <asp:ComboBox ID="cboTenLop" runat="server" AutoPostBack="True" Width="120px" Height="25px" >
                    
                </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong" style="width:50%"> Đường dẫn file: </td>
            <td class="dieukhien"> 
               <asp:FileUpload runat="server" ID="fuDSHS" Width="300px" Height="25px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center"> <label id="lblThongBao" runat="server" style="color:Red"></label></td>
        </tr>
        <tr>
            <td class="tentruong"></td>
            <td><asp:Button runat="server" ID="btnNhapExcel" Text="Nhập từ file excel" 
                    onclick="btnNhapExcel_Click" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="width:100%;font-size:25px">Danh sách lớp vừa nhập </td>
        </tr>
        <tr>
            <td colspan="2" style="width:100%">
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

