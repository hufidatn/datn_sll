<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="ChuyenLopChoHS.aspx.cs" Inherits="GiaoDien_PhanLopChoHS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
    <div class="tieude">
        &nbsp;Phân lớp cho học sinh
    </div>
    <div style="font-size:20px; font-style:italic; height:30px;padding-left:10px;">
        Phân lớp cho học sinh=> <asp:LinkButton runat="server" ID="lkbtNhapExel" Text="Chọn nhập từ excel" PostBackUrl="~/GiaoDien/NhapHSTheoLopExcel.aspx" ></asp:LinkButton>
    </div>
    
        <div style="float:left;width:100%">
        <div style="border:solid 1px #686; float:left; width:320px;height:auto; margin-top:5px;">
          
          <div style="text-align:center; padding:5px">Thông tin lớp cũ</div>
            <table style="width:320px">
            
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:RadioButton GroupName="rd"  runat="server" ID="rdoHocSinhMoi" Text="HS mới" 
                            oncheckedchanged="rdoHocSinhMoi_CheckedChanged" AutoPostBack="True"/>
                    <asp:RadioButton GroupName="rd"  runat="server" ID="rdoHocSinh1011Cu" 
                            Text="HS khối 10+11 cũ" AutoPostBack="True" 
                            oncheckedchanged="rdoHocSinh1011Cu_CheckedChanged"/>
                    </td>
                </tr> 
                <tr>
                    <td class="dong">Năm học</td>
                    <td><asp:ComboBox runat="server" ID="cboNamHoc"
                            onselectedindexchanged="cboNamHoc_SelectedIndexChanged" 
                            AutoPostBack="True"></asp:ComboBox></td>
                </tr>
                <tr>  
                    <td class="dong">Khối học</td>
                    <td><asp:ComboBox runat="server" ID="cboKhoi"
                            onselectedindexchanged="cboKhoi_SelectedIndexChanged" AutoPostBack="True"></asp:ComboBox></td>
                 </tr>
                 <tr>
                    <td class="dong">Lớp học</td>
                    <td><asp:ComboBox runat="server" ID="cboLop" AutoPostBack="True" 
                            onselectedindexchanged="cboLop_SelectedIndexChanged"></asp:ComboBox></td>
                </tr>
                
                <tr>
                    <td colspan="2" class="dong"><asp:TextBox ID="txtTim" runat="server" Width="270px">Nhập 
                        tên hoặc mã HS</asp:TextBox></td>
                </tr> 
                <tr>
                
                    <td><center><asp:Button runat="server" ID="btnTimTheoTen" Text="Tìm theo tên" 
                            onclick="btnTimTheoTen_Click" /></center></td>
                    <td><asp:Button runat="server" ID="btnTimTheoMa" Text="Tìm theo mã" 
                            onclick="btnTimTheoMa_Click" /></td>
                </tr>
                <tr>
                <td> <asp:CheckBox runat="server" ID="ckAll" AutoPostBack="true" 
                        oncheckedchanged="ckAll_CheckedChanged" />
                </td>
                </tr>
                <tr>
                    <td colspan="2" style="border-top:solid 1px #686 ">
                    
                        <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                         <asp:TemplateField>
                           <ItemTemplate>
                             <asp:CheckBox ID="ckChonHS" runat="server" />
                           </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="STT">
                         <ItemTemplate> <%# Container.DataItemIndex + 1 %> </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Mã học sinh">
                         <ItemTemplate>
                         <asp:Label runat="server" ID="lblMaHS" Text='<%#Eval("StudentID") %>'></asp:Label>
                         </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tên học sinh">
                         <ItemTemplate><asp:Label runat="server" ID="lblTenHS" Text='<%#Eval("StudentName")%>'></asp:Label></ItemTemplate>
                         </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                    </td>
                </tr>        
            </table>
        </div>
        <div  style=" float:left; width:105px;height:auto; margin:50px auto auto 5px">
            
            <table style="margin-top:100px;">
                <tr>
                    <td><asp:Button runat="server" ID="btnChuyen" Text="Chuyển lớp" Width="100px" 
                            onclick="btnChuyen_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button runat="server" ID="btnXoa" Text="Xóa" Width="100px" 
                            onclick="btnXoa_Click" /></td>
                </tr>
               <%-- <tr>
                    <td><asp:Button runat="server" ID="btnLuu" Text="Lưu" Width="100px" /></td>
                </tr>--%>
            </table>
        </div>
        <div style="border:solid 1px #333333; float:right; width:320px;height:auto; margin-top:5px;">
  
            <div style="text-align:center; padding:5px">  Thông tin lớp mới</div>
            <table style="width:320px">
                <tr>
                   <td></td>
                   
                </tr>
                <tr>
                    <td class="dong">Năm học</td>
                    <td><asp:ComboBox runat="server" ID="cboNam1"></asp:ComboBox></td>
                </tr>
                <tr>  
                    <td class="dong">Khối học</td>
                    <td><asp:ComboBox runat="server" ID="cboKhoi1" 
                            onselectedindexchanged="cboKhoi1_SelectedIndexChanged"></asp:ComboBox></td>
                 </tr>
                 <tr>
                    <td class="dong">Lớp học</td>
                    <td><asp:ComboBox runat="server" ID="cboLopMoi"></asp:ComboBox>&nbsp&nbsp
                    <asp:Label ID="lblSL" Enabled="false" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                 <td colspan="2"><center><asp:RadioButton GroupName="rd2" ID="rdLopCu" 
                         runat="server" Text="Lớp cũ" AutoPostBack="True" 
                         oncheckedchanged="rdLopCu_CheckedChanged" />&nbsp&nbsp
                 <asp:RadioButton GroupName="rd2" runat="server" ID="rdLopMoi" Text="Lớp mới" 
                         AutoPostBack="True" oncheckedchanged="rdLopMoi_CheckedChanged" />
                 </center> 
                 </td>
                </tr>
                  <tr>
                   <td><asp:CheckBox ID="Xoa" runat="server" AutoPostBack="True" oncheckedchanged="Xoa_CheckedChanged" 
                           />
                   </td>
                  </tr>
                <tr>
                    <td colspan="2" style="border-top:solid 1px #686 ">
                        <asp:GridView ID="GrvHSChuyen" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="ChonHS" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="STT">
                         <ItemTemplate> <%# Container.DataItemIndex + 1 %> </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Mã học sinh">
                         <ItemTemplate> <asp:Label runat="server" ID="lblMaHSMoi" Text='<%#Eval("StudentID") %>'></asp:Label></ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tên học sinh">
                         <ItemTemplate><asp:Label runat="server" ID="lblTenHSMoi" Text='<%#Eval("StudentName")%>'></asp:Label></ItemTemplate>
                         </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                    </td>
                </tr>        
            </table>
        </div>
        </div> 
 </div>   
</asp:Content>

