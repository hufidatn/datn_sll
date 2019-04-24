<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="PhieuDiemChiTiet.aspx.cs" Inherits="GiaoDien_PhieuDiemChiTiet" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
<link href="../CSS/Tab.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<div class="tieude">
    Chi tiết điểm của học sinh
 </div>
 <div>
   <table style="width:100%;">
        <tr>
            <td class="tentruong" style="width:50%;text-align:right;padding-left:10px;" >Năm học:</td>
            <td><asp:Label runat="server" ID="lblNamHoc" Font-Size="20px" ForeColor="Blue" ></asp:Label></td>
        </tr>
        <tr>
            <td class="tentruong" style="width:50%;text-align:right;padding-left:10px;"> Mã học sinh:</td>
            <td><asp:Label runat="server" ID="lblMa" Font-Size="20px" ForeColor="Blue" ></asp:Label></td>
        </tr>
        <tr>
            <td class="tentruong" style="width:50%;text-align:right;padding-left:10px;"> Họ và tên:</td>
            <td><asp:Label runat="server" ID="lblHoTen" Font-Size="20px" ForeColor="#0000CC" ></asp:Label></td>
        </tr>
        <tr>
            <td class="tentruong" style="width:50%;text-align:right;padding-left:10px;"> Lớp:</td>
            <td><asp:Label runat="server" ID="lblLop" Font-Size="20px" ForeColor="#0000CC" ></asp:Label></td>
        </tr>
        <tr>
               
        
    <%--<div>
    <div style="width:100%; height:auto; margin:5px auto 10px 0px;float:left">--%>
    <td colspan="2">
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
             Font-Size="30px"  CssClass="Tab">
            <asp:TabPanel runat="server" ID="tbHK1" HeaderText="Học kỳ I" >
                <ContentTemplate>
                   <div style="font-size:20px">
                        
                        <asp:Label runat="server" ID="lblThongBao1" ForeColor="Red" ></asp:Label>
                   </div>
                   <div class="div1">
    
                    <asp:GridView ID="grvHK1" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" HorizontalAlign="Left" Font-Size="17px">
                    <Columns>
                    <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Môn học" SortExpression="TenMon">
                         <ItemTemplate>
                                    <%#Eval("TenMon")%>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Điểm Miệng" SortExpression="DiemMieng">
                         <ItemTemplate>
                                    <%#Eval("DM")%>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Điểm 15'" SortExpression="Diem15">
                                <ItemTemplate>
                                    <%#Eval("D15p")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Điểm 45'" SortExpression="Diem45">
                                <ItemTemplate>
                                    <%#Eval("D45p")%></ItemTemplate>
                                
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="ĐHK" SortExpression="DiemHK">
                                <ItemTemplate>
                                    <%#Eval("DHK")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="ĐTB" SortExpression="DiemTB">
                                <ItemTemplate>
                                    <%#Eval("DTB")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                             
                        </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="30px" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
                    <RowStyle BackColor="#EFF3FB" />
                       </asp:GridView>    
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            
            <asp:TabPanel runat="server" ID="TabPanel1" HeaderText="Học kỳ II" >
                <ContentTemplate>
                   <div style="font-size:20px">
                        
                        <asp:Label runat="server" ID="lblThongBao2" ForeColor="Red" ></asp:Label>
                   </div>
                   <div class="div1">
    
                    <asp:GridView ID="grvHK2" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" HorizontalAlign="Left" Font-Size="17px">
                    <Columns>
                    <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Môn học" SortExpression="TenMon">
                         <ItemTemplate>
                                    <%#Eval("TenMon")%>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Điểm Miệng" SortExpression="DiemMieng">
                         <ItemTemplate>
                                    <%#Eval("DM")%>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Điểm 15'" SortExpression="Diem15">
                                <ItemTemplate>
                                    <%#Eval("D15p")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Điểm 45'" SortExpression="Diem45">
                                <ItemTemplate>
                                    <%#Eval("D45p")%></ItemTemplate>
                                
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="ĐHK" SortExpression="DiemHK">
                                <ItemTemplate>
                                    <%#Eval("DHK")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="ĐTB" SortExpression="DiemTB">
                                <ItemTemplate>
                                    <%#Eval("DTB")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                             
                        </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="30px" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
                    <RowStyle BackColor="#EFF3FB" />
                       </asp:GridView>    
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" ID="TabPanel2" HeaderText="Cả năm"   >
                <ContentTemplate>
                   <div style="font-size:20px" >
       
                        <asp:Label runat="server" ID="lblThongBaoCN" ForeColor="Red" ></asp:Label>
                   </div>
                   <div class="div1">
                       <asp:GridView ID="grvHK3" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" Font-Size="17px" HorizontalAlign="Left">
                           <Columns>
                                 <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                                 </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Môn Học" SortExpression="MonHoc">
                                <ItemTemplate>
                                    <%#Eval("MonHoc")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                               <asp:TemplateField HeaderText="ĐTBHKI" SortExpression="DTBHK1">
                                <ItemTemplate>
                                    <%#Eval("DTBHK1")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                               <asp:TemplateField HeaderText="ĐTBHKII" SortExpression="DTBHK2">
                                <ItemTemplate>
                                    <%#Eval("DTBHK2")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                               
                               <asp:TemplateField HeaderText="ĐTBCN" SortExpression="ĐTBCN">
                                <ItemTemplate>
                                    <%#Eval("DTBCN")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                            
                           </Columns>
                           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                Height="30px" />
                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#EFF3FB" />
                       </asp:GridView>
                    </div>
                
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
        </td>
     </tr>
    
    
    </table> 
    
        <table style="width:100%">
             <tr>
            <td class="dtb">Điểm trung bình học kỳ 1:</td>
            <td><asp:Label runat="server" ID="lblDTBKy1"></asp:Label></td>
        </tr>
        <tr>
            <td class="dtb">Điểm trung bình học kỳ 2:</td>
            <td><asp:Label runat="server" ID="lblDTBKy2"></asp:Label></td>
        </tr>
        <tr>
            <td class="dtb">Điểm trung bình cả năm học:</td>
            <td><asp:Label runat="server" ID="lblDTBCaNam"></asp:Label></td>
        </tr>
        <tr>
            <td class="dtb"></td>
            <td> <asp:Button runat="server" ID="btnBack" Text="Trang trước" Width="150px" Height="25px"
                    onclick="btnBack_Click" /> </td>
        </tr>
     
        </table>
    </div>
   
</div>
</asp:Content>

