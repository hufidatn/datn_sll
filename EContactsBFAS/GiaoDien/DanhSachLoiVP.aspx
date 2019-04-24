<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="DanhSachLoiVP.aspx.cs" Inherits="GiaoDien_DanhSachLoiVP" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css"  rel="Stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
     <div class="tieude">
     Thông tin vi phạm của học sinh
    </div>
    <table style="width:100%;border:1 thin blue;">
        <tr>
      <td class="tentruong" style="width:50%; text-align:right">
        Năm học:
      </td>
      <td class="dieukhien" style="padding-left:10px;">
       <asp:Label runat="server" ID="lblNamHoc"></asp:Label>
      </td>
    </tr>
    <tr>
      <td class="tentruong" style="width:50%; text-align:right">
        Lớp học:
      </td>
      <td class="dieukhien" style="padding-left:10px;">
       <asp:Label runat="server" ID="lblLopHoc"></asp:Label>
      </td>
    </tr>
    <tr>
      <td class="tentruong" style="width:50%; text-align:right">
        Mã học sinh:
      </td>
      <td class="dieukhien" style="padding-left:10px;">
       <asp:Label runat="server" ID="lblMa"></asp:Label>
      </td>
    </tr>
    <tr>
      <td class="tentruong" style="width:50%; text-align:right">
        Tên học sinh:
      </td>
      <td class="dieukhien" style="padding-left:10px;">
       <asp:Label runat="server" ID="lblTenHS"></asp:Label>
      </td>
    </tr>
    <tr>
        <td colspan="2">
        <asp:GridView ID="grvLoiVP" runat="server" AutoGenerateColumns="False"
                        Width="100%"
                     ForeColor="#333333" GridLines="Both" BorderStyle="Solid"
                      Font-Overline="False" Font-Strikeout="False" AllowPaging="true" PageSize="10"
                    >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
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
                        
                        <asp:TemplateField HeaderText="Số lần" SortExpression="Number">
                        <ItemTemplate>
                            <%#Eval("Number") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
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
    <tr>
        <td colspan="2" align="center">
        <br />
         <asp:Button runat="server" ID="btnBack" Height="25px" Width="200px" Text="Quay lại trang trước" /></td>
    </tr>
    </table>
</div>
</asp:Content>

