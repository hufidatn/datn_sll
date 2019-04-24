<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="KetQuaRenLuyen.aspx.cs" Inherits="GiaoDien_Tongdiem" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
   <div class="tieude">
        Kết quả đánh giá của học sinh
        
   </div>
   <table>
      <%--<tr> 
         <td class="tentruong">
          Tên ban:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboBan" runat="server"  Width="300px" Height="25px">
             </asp:ComboBox>
         </td>
      </tr>--%>
      <tr> 
         <td class="tentruong">
          Năm học:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboNam" runat="server"  Width="300px" Height="25px" 
                 AutoPostBack="True" onselectedindexchanged="cboNam_SelectedIndexChanged">
             </asp:ComboBox>
         </td>
      </tr>
      <tr> 
         <td class="tentruong">
          Tên lớp:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboLop" runat="server"  Width="300px" Height="25px">
             </asp:ComboBox>
         </td>
      </tr>
      
      <tr> <td class="tentruong">
          
         </td>
            <td class="dieukhien" colspan="2">
            <asp:Button Text="Hiện thị" ID="btnTinh" runat="server" Height="25px" 
                    Width="125px" onclick="btnTinh_Click" />&nbsp;&nbsp;
                    <asp:Button Text="Xuất ra excel" runat="server" ID="btnXuatExcel" 
                    Width="125px" Height="25px" onclick="btnXuatExcel_Click" />
            </td>
      </tr>
      <tr>
            <td colspan="2" align="center"> <label id="lblThongBao" runat="server" style="color:Red;font-size:20px"></label></td>
      </tr>
   </table>
   <div style="padding:5px;text-align:center">
   <asp:Panel ID="Panel1" runat="server" Width="760px">
       <asp:GridView ID="grvTV" runat="server" Width="100%" 
                        AllowPaging="True" AutoGenerateColumns="False"
                         PageSize="5">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <asp:Label runat="server" ID="lblSTT" Text='<%# Container.DataItemIndex + 1 %>'>   </asp:Label> 
                               <%--<%# Container.DataItemIndex + 1 %>--%>
                                </ItemTemplate>   
                         </asp:TemplateField> 
                            <asp:TemplateField HeaderText="MaHS" SortExpression="MaHS">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("MaHS") %>' ID="lblMaHS"></asp:Label>
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TênHS" SortExpression="TenHS">
                                <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Bind("TenHS") %>' ID="lblTenHS"></asp:Label>
                                   <%-- <%#Eval("TenHS")%>--%>
                                    </ItemTemplate>
                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TBMHK1" SortExpression="TBMHK1">
                                    <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("TBMHK1") %>' ID="lblTBMHK1"></asp:Label>
                                    <%--<%#Eval("TBMHK1")%>--%>
                                    </ItemTemplate> 
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="TBMHK2" SortExpression="TBMHK2">
                              <ItemTemplate>
                               <asp:Label runat="server" Text='<%#Bind("TBMHK2") %>' ID="lblTBMHK2"></asp:Label>
                                    <%--<%#Eval("TBMHK2")%>--%>
                                    </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="TBMCN" SortExpression="TBMCN">
                              <ItemTemplate>
                               <asp:Label runat="server" Text='<%#Bind("TBMCN") %>' ID="lblTBMCN"></asp:Label>
                                   <%-- <%#Eval("TBMCN")%>--%>
                                    </ItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="Học lực" SortExpression="HLCN">
                            <ItemTemplate>
                             <asp:Label runat="server" Text='<%#Bind("HLCN") %>' ID="lblHLCN"></asp:Label>
                                    <%--<%#Eval("HLCN")%>--%>
                                    </ItemTemplate>
                            </asp:TemplateField>   
                            <asp:TemplateField HeaderText="Hạnh kiểm" SortExpression="HKCN">
                            <ItemTemplate>
                             <asp:Label runat="server" Text='<%#Bind("HKCN") %>' ID="lblHKCN"></asp:Label>
                                   <%-- <%#Eval("HKCN")%>--%>
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
   </asp:Panel>
 </div>
</div>

</asp:Content>

