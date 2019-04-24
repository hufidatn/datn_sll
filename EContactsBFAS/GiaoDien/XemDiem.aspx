<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Client.master" AutoEventWireup="true" CodeFile="XemDiem.aspx.cs" Inherits="GiaoDien_XemDiem" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Client.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="divKhungChinh">
<div class="titleDiem">
    Xem điểm
</div>
    
<div id="divChon">
    <table style="float:left;" >
        <tr>
            <td class="tenTruong">Niên khóa:</td>
            <td class="DieuKhien">
            <asp:ComboBox ID="cboNienKhoa" runat="server" Height="25px" AutoPostBack="True" 
                    onselectedindexchanged="cboNienKhoa_SelectedIndexChanged">
            </asp:ComboBox>
            </td>
            <td class="tenTruong">Lớp học</td>
            <td class="DieuKhien">
            <asp:ComboBox ID="cboLopHoc" runat="server" Height="25px"
                    onselectedindexchanged="cboLopHoc_SelectedIndexChanged" 
                    AutoPostBack="True">
            </asp:ComboBox>
            </td> &nbsp;&nbsp;
            <td class="DieuKhien"  ><asp:Button ID="btnTim" runat="server" 
                    Text="Tìm kiếm" Width="100px" Height="30px" onclick="btnTim_Click" /></td>
        </tr>
        <tr>
            <td class="tenTruong">Mã học sinh:</td>
            <td class="DieuKhien">
            <asp:TextBox runat="server" ID="txtMaHS" Height="25px" ></asp:TextBox>
            </td>
            <td class="tenTruong">Tên học sinh</td>
            <td class="DieuKhien">
            <asp:TextBox runat="server" ID="txtTenHS" Width="300px" Height="25px" 
                    AutoPostBack="True" ontextchanged="txtTenHS_TextChanged" ></asp:TextBox>
            </td>
            <td></td>
            
        </tr>
    </table>
</div>
    <div id="divGridView" style="font-size:17px;">
    <asp:UpdatePanel runat="server" ID="udpl">
    <ContentTemplate>
            <asp:GridView ID="grvXemDiem" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" AllowPaging="True" BorderStyle="Solid" 
                Font-Overline="False" Font-Strikeout="False" Height="25px" 
                HorizontalAlign="Center" 
                onselectedindexchanged="grvXemDiem_SelectedIndexChanged" 
                onpageindexchanging="grvXemDiem_PageIndexChanging">
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
                            <asp:LinkButton runat="server" ID="lkbXemDiem" Text="Xem điểm" PostBackUrl='<%#"~/GiaoDien/XemDiemChiTiet.aspx?StudentID="+Eval("StudentID")+"&SchoolYearID="+this.cboNienKhoa.SelectedItem.Value.ToString()
                            +"&ClassID="+this.cboLopHoc.SelectedItem.Value.ToString() +"&StudentName="+Eval("StudentName")
                            +"&ClassName="+this.cboLopHoc.SelectedItem.Text%>' ></asp:LinkButton>
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
                </ContentTemplate>
                </asp:UpdatePanel>  
    </div>
</div>
</asp:Content>

