<%@ Page Language="C#" EnableEventValidation  ="false" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="BangDiemTheoMonHoc.aspx.cs" Inherits="GiaoDien_BangDiemTheoMonHoc" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            border-left: 0.01px solid #6495ed;
            border-bottom: 0.01px solid #6495ed;
            padding: 1px;
            border-top: 0px;
            border-right: 0px;
            text-align: left;
            width: 226px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
 <div class="tieude">
 Thông tin điểm theo môn học
 </div>
 <table style="width:100%">
 <tr>
     <td class="tentruong">
     Năm học:
     </td>
     <td class="dieukhien">
         <asp:ComboBox ID="cboNam" runat="server"  Width="100px" Height="25px" 
             AutoPostBack="True" onselectedindexchanged="cboNam_SelectedIndexChanged">
         </asp:ComboBox>
     </td>
   </tr>
   <tr>
     <td class="tentruong">
     Học kỳ:
     </td>
     <td class="dieukhien">
         <asp:ComboBox ID="cboKy" runat="server"  Width="100px" Height="25px" 
             AutoPostBack="True" onselectedindexchanged="cboKy_SelectedIndexChanged">
         </asp:ComboBox>
     </td>
   </tr>
   <tr>
     <td class="tentruong">
     Tên Lớp:
     </td>
     <td class="dieukhien">
         <asp:ComboBox ID="cboLop" runat="server"  Width="100px" Height="25px" 
             AutoPostBack="True" onselectedindexchanged="cboLop_SelectedIndexChanged">
         </asp:ComboBox>
     </td>
   </tr>
   <tr>
     <td class="tentruong">
     Mã học sinh:
     </td>
     <td class="dieukhien">
         <asp:ComboBox ID="cboMaHS" runat="server"  Width="150px" Height="25px">
         </asp:ComboBox>
     </td>
   </tr>
   <tr>
     <td class="tentruong">
     Môn học:
     </td>
     <td class="dieukhien">
         <asp:ComboBox ID="cboMon" runat="server"  Width="200px" Height="25px" 
             onselectedindexchanged="cboMon_SelectedIndexChanged">
         </asp:ComboBox>
     </td>
   </tr>
   
   <tr>
        <td colspan="2" align="center"><label  id="lblThongBao" runat="server" style="color:Red;height:25px; font-size:17px;" ></label></td>
   </tr>
   <tr>
        
     <td colspan="2" align="center" class="dongdieukhien">
         
             <asp:Button runat="server" ID="btnHS" Height="25px" Width="150px" Text="Điểm của một học sinh" 
             onclick="btnHS_Click" />&nbsp;&nbsp;
             <asp:Button runat="server" ID="btnMon" Height="25px" Width="150px" Text="Điểm của một lớp" 
             onclick="btnMon_Click" />&nbsp;&nbsp;
             <asp:Button runat="server" ID="btnXuatExcel" Height="25px" Width="150px" 
             Text="Xuất ra Excel" onclick="btnXuatExcel_Click" />
             
     </td>
   </tr>
 </table>
 <div style="padding:5px;text-align:center">
   <asp:UpdatePanel runat="server" ID="upl1">
   <ContentTemplate>
       <asp:GridView ID="grvThanhvien" runat="server" Width="100%" 
                        AllowPaging="True" AutoGenerateColumns="False"
                         PageSize="10" 
           onselectedindexchanging="grvThanhvien_SelectedIndexChanging" 
           onpageindexchanging="grvThanhvien_PageIndexChanging" >
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <asp:Label runat="server" ID="lblSTT" Text='<%# Container.DataItemIndex + 1 %>'>   </asp:Label> 
                               <%--<%# Container.DataItemIndex + 1 %>--%>
                                </ItemTemplate>   
                         </asp:TemplateField> 
                            <asp:TemplateField HeaderText="MãHS" SortExpression="MaHS">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lblMaHS" Text='<%#Bind("MaHS") %>'></asp:Label>
                                    <%--<%#Eval("MaHS") %>--%>
                                </ItemTemplate>
                              
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TênHS" SortExpression="TenHS">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lblTenHS" Text='<%#Bind("TenHS") %>'></asp:Label>
                                    <%--<%#Eval("TenHS")%>--%>
                                    </ItemTemplate>
                                
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="M" SortExpression="DM">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lblDM" Text='<%#Bind("DM") %>'></asp:Label>
                                   <%-- <%#Eval("DM")%>--%>
                                    </ItemTemplate>
                                
                            </asp:TemplateField>
                            
                              
                              <asp:TemplateField HeaderText="15'" SortExpression="D15p">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lblD15p" Text='<%#Bind("D15p") %>'></asp:Label>
                                    <%--<%#Eval("D15p")%>--%>
                                    </ItemTemplate>
                                
                            </asp:TemplateField> 
                              <asp:TemplateField HeaderText="Đ45p" SortExpression="D45p">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lblD45p" Text='<%#Bind("D45p") %>'></asp:Label>
                                   <%-- <%#Eval("DM")%>--%>
                                    </ItemTemplate>
                                
                            </asp:TemplateField>
                            
                             
                              <asp:TemplateField HeaderText="ĐHK" SortExpression="DHK">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lblDHK" Text='<%#Bind("DHK") %>'></asp:Label>
                                    <%--<%#Eval("DHK")%>--%>
                                    </ItemTemplate>
                                
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="ĐTB" SortExpression="DTB">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lblDTB" Text='<%#Bind("DTB") %>'></asp:Label>
                                    <%--<%#Eval("DTB")%>--%>
                                    </ItemTemplate>
                                
                            </asp:TemplateField> 
                             
                            <%--<asp:TemplateField HeaderText="ĐTL" SortExpression="DiemTL">
                                <ItemTemplate>
                                    <%#Eval("DTL")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="ĐTBL" SortExpression="DiemTB">
                                <ItemTemplate>
                                    <%#Eval("DTBL")%></ItemTemplate>
                                
                            </asp:TemplateField>  --%>       
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



