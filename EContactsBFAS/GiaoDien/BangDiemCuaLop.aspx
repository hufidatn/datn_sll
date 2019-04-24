<%@ Page Language="C#"  MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="BangDiemCuaLop.aspx.cs" Inherits="GiaoDien_BangDiemCuaLop" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css"/>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <div>
        <div class="tieude">
     Thông tin điểm theo học kỳ
    </div>
    <table>
    <tr>
      <td class="tentruong">
        Năm học:
      </td>
      <td class="dieukhien">
       <asp:ComboBox ID="cboNam" runat="server" Width="300px" Height="25px" 
              AutoPostBack="True" onselectedindexchanged="cboNam_SelectedIndexChanged">
       </asp:ComboBox>
      </td>
    </tr>
     
     <tr>
      <td class="tentruong">
         Kỳ học:
      </td>
      <td class="dieukhien">
       <asp:ComboBox ID="cboKy" runat="server" Width="300px" Height="25px">
       </asp:ComboBox>
      </td>
    </tr>
     <tr> 
      <td class="tentruong">
         Tên lớp:
      </td>
      <td class="dieukhien">
       <asp:ComboBox ID="cboLop" runat="server" Width="300px" Height="25px">
       </asp:ComboBox>
      </td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
    <tr> 
    <td class="tentruong"></td>
       <td colspan="2" class="dongdieukhien">
       <asp:Button ID="btnHienThi" Text="Hiện thị bảng điểm" runat="server" Width="125px" 
               Height="25px" onclick="btnHienThi_Click" />&nbsp;
        <asp:Button ID="btnExport" Text="Xuất ra Excel" runat="server" 
               onclick="btnExport_Click" />
       </td>
    </tr>
    <tr>
    <td class="tentruong"></td>
        <td> <label id="lblThongBao" style="color:Red" runat="server"></label></td>
    </tr> 
  </table>
  <div style="padding:5px;text-align:center">
  <asp:UpdatePanel runat="server" ID="udpl1">
  <ContentTemplate>
       <asp:GridView ID="grvThanhvien" runat="server" Width="100%"  
                        AllowPaging="True" AutoGenerateColumns="False"
                         PageSize="15" 
           onpageindexchanging="grvThanhvien_PageIndexChanging">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                        <asp:TemplateField HeaderText="STT" SortExpression="STT">
                                <ItemTemplate>
                                <%#Eval("STT") %>
                                 </ItemTemplate>
                                
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MãHS" SortExpression="MaHS">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblMa" Text='<%#Bind("MaHS") %>' ></asp:Label>
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TênHS" SortExpression="TenLD">
                                <ItemTemplate>
                                <%#Eval("TenHS") %>
                                 </ItemTemplate>
                                
                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Toán" SortExpression="Toan"> 
                                    <ItemTemplate>
                                    <%#Eval("Toan") %>                              
                                     </ItemTemplate>
                            </asp:TemplateField>
                             
                                    <asp:TemplateField HeaderText="Ngữ văn" SortExpression="Van"> 
                                    <ItemTemplate>
                                        <%#Eval("Van") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                             
                                    <asp:TemplateField HeaderText="Vật lý" SortExpression="Ly"> 
                                    <ItemTemplate>
                                        <%#Eval("Ly") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                              
                                    <asp:TemplateField HeaderText="Hóa học" SortExpression="Hoa"> 
                                    <ItemTemplate>
                                        <%#Eval("Hoa") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                              
                                    <asp:TemplateField HeaderText="Lịch sử" SortExpression="LichSu"> 
                                    <ItemTemplate>
                                        <%#Eval("LichSu") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                             
                                    <asp:TemplateField HeaderText="Địa lý" SortExpression="DiaLy"> 
                                    <ItemTemplate>
                                        <%#Eval("DiaLy") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                             
                                    <asp:TemplateField HeaderText="Sinh học" SortExpression="Sinh"> 
                                    <ItemTemplate>
                                        <%#Eval("Sinh") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                           
                                    <asp:TemplateField HeaderText="Ngoại ngữ" SortExpression="NgoaiNgu"> 
                                    <ItemTemplate>
                                        <%#Eval("NgoaiNgu") %>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                             
                                    <asp:TemplateField HeaderText="GDCD" SortExpression="GDCN"> 
                                    <ItemTemplate>
                                        <%#Eval("GDCD") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                             
                                    <asp:TemplateField HeaderText="Tin học" SortExpression="Tin"> 
                                    <ItemTemplate>
                                        <%#Eval("Tin") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                            
                                    <asp:TemplateField HeaderText="Công nghệ" SortExpression="CongNghe"> 
                                    <ItemTemplate>
                                        <%#Eval("CongNghe") %>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                            
                                    <asp:TemplateField HeaderText="Thể dục" SortExpression="TheDuc"> 
                                    <ItemTemplate>
                                        <%#Eval("TheDuc") %>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                            
                                    <asp:TemplateField HeaderText="GDQP" SortExpression="GDQP"> 
                                    <ItemTemplate>
                                        <%#Eval("GDQP") %>
                                    </ItemTemplate>
                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ĐTB" SortExpression="DTB"> 
                                    <ItemTemplate>
                                        <%#Eval("DTB") %>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="HL" SortExpression="HL"> 
                                    <ItemTemplate>
                                        <%#Eval("HL") %>
                                    </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="HK" SortExpression="HK"> 
                                    <ItemTemplate>
                                        <%#Eval("HK") %>
                                    </ItemTemplate>
                            </asp:TemplateField>   
                            
                                   <%-- <asp:TemplateField HeaderText="Toán" SortExpression="Toan1"> 
                                    <ItemTemplate>
                                        <%#Eval("Toan1") %>
                                    </ItemTemplate>
                            </asp:TemplateField>   --%>   
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    </ContentTemplate>
                    </asp:UpdatePanel>
 </div>
 </div>
</asp:Content>

