<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Client.master" AutoEventWireup="true" CodeFile="XemDiemChiTiet.aspx.cs" Inherits="GiaoDien_XemDiemChiTiet" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
    
<link href="../CSS/Client.css" rel="Stylesheet" type="text/css" />
<link href="../CSS/Tab.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="divKhungChinh">
<div class="titleDiem"  >
    Xem điểm
</div>
<div id="divChon">
    <table>
        <tr>
            <td>Niên khóa:</td>
            <td>
            <asp:ComboBox ID="cboNienKhoa" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="cboNienKhoa_SelectedIndexChanged">
            </asp:ComboBox>
            </td>
            <td>Lớp học:</td>
            <td>
            <asp:ComboBox ID="cboLopHoc" runat="server">
            </asp:ComboBox>
            </td>
            <td class="DieuKhien" rowspan="2"><asp:Button ID="btnTim" runat="server" 
                    Text="Tìm kiếm" Height="25px" Width="150px" onclick="btnTim_Click" /></td>
        </tr>
        <tr>
            <td class="tenTruong">Mã học sinh:</td>
            <td class="DieuKhien">
            <asp:TextBox runat="server" ID="txtMaHS" Height="25px"></asp:TextBox>
            </td>
            <td class="tenTruong">Tên học sinh:</td>
            <td class="DieuKhien">
            <asp:TextBox runat="server" ID="txtTenHS" Width="300px" Height="25px" AutoPostBack="True" 
                    ontextchanged="txtTenHS_TextChanged" ></asp:TextBox>
            </td>
            
        </tr>
    </table>
</div>
<div class ="titleDiem">
   <table>
        <tr>
            <td>Thông tin của học sinh trong năm học:</td> 
             
              
              <td style="text-align:left; width:200px;padding-left:20px"> <asp:Label runat="server" ID="lblNam" > </asp:Label></td>     
        </tr>
        
   </table>
   
</div>
<div id="divGiua" >
<div style="float:left;" id="divThongTin">
    <table>
        <tr>
            <td> Mã học sinh:</td>
            <td><asp:Label runat="server" ID="lblMa" Font-Size="20px" ForeColor="Blue" ></asp:Label></td>
        </tr>
        <tr>
            <td> Họ và tên:</td>
            <td><asp:Label runat="server" ID="lblHoTen" Font-Size="20px" ForeColor="#0000CC" ></asp:Label></td>
        </tr>
        <tr>
            <td> Lớp:</td>
            <td><asp:Label runat="server" ID="lblLop" Font-Size="20px" ForeColor="#0000CC" ></asp:Label></td>
        </tr>
    </table>
    </div>
    <div style="float:right" class="divDanhGia">
        <table border="1px" style="height:150px;width:450px;" >
        
            <tr>
                <td style="width:115px; height:25px; text-align:center;">Bảng đánh giá</td>
                <td style="width:100px; height:25px;text-align:center;">Học Kỳ I</td>
                <td style="width:100px; height:25px;text-align:center;">Hoc Kỳ II</td>
                <td style="width:100px; height:25px;text-align:center;">Cả năm</td>
            </tr>
            <tr >
                <td align="center">Điểm TB</td>
                <td align="center"><asp:Label runat="server" ID="lblDTBKy1" ></asp:Label></td>
                <td align="center"><asp:Label runat="server" ID="lblDTBKy2"></asp:Label></td>
                <td align="center"><asp:Label runat="server" ID="lblDTBCaNam"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">Hạnh kiểm</td>
                <td align="center"><asp:Label runat="server" ID="lblHK1" ></asp:Label></td>
                <td align="center"><asp:Label runat="server" ID="lblHK2"></asp:Label></td>
                <td align="center"><asp:Label runat="server" ID="lblHKCN"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">Học lực</td>
                <td align="center"><asp:Label runat="server" ID="lblHL1" ></asp:Label></td>
                <td align="center"><asp:Label runat="server" ID="lblHL2"></asp:Label></td>
                <td align="center"><asp:Label runat="server" ID="lblHLCN"></asp:Label></td>
            </tr>
        </table>
    </div>
</div>
<div>
<div style="float:left; margin-bottom:10px;">
    <div style="width:950px; height:auto; margin:5px auto 10px 20px;">
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
             Font-Size="30px"  CssClass="Tab">
            <asp:TabPanel runat="server" ID="tbHK1" HeaderText="Học kỳ I" Font-Size="20px" Height="30px">
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
     </div>
  <div style="font-size:20px; margin-left:20px; height:25px;float:left">Thông tin về lỗi vi phạm của học sinh</div>
    <div style="width:950px; height:auto; margin:5px auto 10px 20px;">
         <asp:GridView ID="grvLoiVP" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" Font-Size="17px" HorizontalAlign="Left">
                           <Columns>
                                 <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                                 </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Lỗi vi phạm" SortExpression="ViolationName">
                                <ItemTemplate>
                                    <%#Eval("ViolationName")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Ngày vi phạm" SortExpression="DateViolation">
                                <ItemTemplate>
                                    <%#String.Format("{0:dd/MM/yyyy}", Eval("DateViolation"))%></ItemTemplate>
                                
                            </asp:TemplateField> 
                               <asp:TemplateField HeaderText="Số lần" SortExpression="Number">
                                <ItemTemplate>
                                    <%#Eval("Number")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                               
                               <asp:TemplateField HeaderText="Xử lý" SortExpression="SanctionName">
                                <ItemTemplate>
                                    <%#Eval("SanctionName")%></ItemTemplate>
                                
                            </asp:TemplateField> 
                            
                           </Columns>
                           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                Height="30px" />
                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#EFF3FB" />
                       </asp:GridView>
    </div>
 </div>
 <div style="float:left;margin-left:400px;">
   <center>
        <asp:Button runat="server" ID="btnBack" Text="Quay lại trang trước" 
            Height="25px" Width="200px" onclick="btnBack_Click" /></center>
 </div>
 </div>  
</div>
</asp:Content>

