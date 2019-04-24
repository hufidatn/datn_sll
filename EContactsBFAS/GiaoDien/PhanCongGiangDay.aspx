<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="PhanCongGiangDay.aspx.cs" Inherits="GiaoDien_PhanCongGiangDay" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
   <div class="tieude">
      Phân công cho giáo viên bộ môn
   </div>
   <table style="width:100%;border:1 thin blue;">
      <tr>
         <td class="tentruong">
          Năm học:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboNam" runat="server" Width="200px" Height="25px" 
                 AutoPostBack="True" onselectedindexchanged="cboNam_SelectedIndexChanged" 
                 
             >
             </asp:ComboBox>
         </td>
      </tr>
      <tr>
         <td class="tentruong">
          Kỳ học:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboKy" runat="server" Width="200PX" Height="25px" 
    >
             </asp:ComboBox>
         </td>
      </tr>
      <tr>
         <td class="tentruong">
          Lớp học:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboLop" runat="server" Width="200PX" Height="25px" 
                 AutoPostBack="True" onselectedindexchanged="cboLop_SelectedIndexChanged">
             </asp:ComboBox>
         </td>
      </tr>
      <tr>
         <td class="tentruong">
          Môn học:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboMon" runat="server" Width="200PX" Height="25px">
             </asp:ComboBox>
         </td>
      </tr>
      <tr>
         <td class="tentruong">
          Giáo viên:
         </td>
         <td class="dieukhien">
             <asp:ComboBox ID="cboGV" runat="server" Width="200PX" Height="25px">
             </asp:ComboBox>
         </td>
      </tr>
      <tr>
         <td style="text-align:center;color:Red" colspan="2">
          <asp:Label ID="lblThongBao" runat="server"></asp:Label>
         </td>
      </tr>
      <tr> 
         
         <td class="" colspan="2" align="center">
           <asp:Button runat="server" ID="btnPhanCong" Text="Phân công" Width="120px" 
                 onclick="btnPhanCong_Click"/>&nbsp;&nbsp;
                 <asp:Button runat="server" ID="btnSua" Text="Sửa" Width="120px" onclick="btnSua_Click" 
                 />&nbsp;&nbsp;
           <asp:Button runat="server" ID="btnHuy" Text="Hủy phân công" Width="120px" 
                 onclick="btnHuy_Click"/> &nbsp;&nbsp;
                 <asp:Button runat="server" ID="btnMoi" Width="120px" Text="Làm mới" 
                 onclick="btnMoi_Click" />
         </td>
      </tr>
      <tr>
      <td class="gridview" colspan="2">
      <%--<asp:UpdatePanel runat="server" ID="upnlPhanMon">
      <ContentTemplate>--%>
        <asp:GridView ID="grvChuyenMon" runat="server" AutoGenerateColumns="False" 
                      Width="100%" AllowPaging="true" PageSize="10"
                     ForeColor="#333333" GridLines="Both" BorderStyle="Solid"
                      Font-Overline="False" Font-Strikeout="False" 
              onselectedindexchanged="grvChuyenMon_SelectedIndexChanged" onpageindexchanging="grvChuyenMon_PageIndexChanging"
                    >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Năm học">   
                          <ItemTemplate>
                         <asp:Label runat="server" ID="lblNam" Text='<%#Bind("SchoolYearName")%>'></asp:Label>
                            <asp:Label runat="server" ID="lblMaNam" Text='<%#Bind("SchoolYearID")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kỳ học">   
                          <ItemTemplate>
                          <asp:Label runat="server" ID="lblKy" Text='<%#Bind("SemesterName")%>'></asp:Label>
                            <asp:Label runat="server" ID="lblMaKy" Text='<%#Bind("SemesterID") %>' Visible="false"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Lớp học">   
                          <ItemTemplate>
                           <asp:Label runat="server" ID="lblLop" Text='<%#Bind("ClassName")%>' ></asp:Label>
                           <asp:Label runat="server" ID="lblMaLop" Text='<%#Bind("ClassID") %>' Visible="false"></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Môn học">   
                          <ItemTemplate>
                          <asp:Label runat="server" ID="lblMon" Text='<%#Bind("SubjectName")%>' ></asp:Label>
                            <asp:Label runat="server" ID="lblMaMon" Text='<%#Bind("SubjectID") %>' Visible="false" ></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="Giáo viên">   
                          <ItemTemplate>
                           <asp:Label runat="server" ID="lblGV" Text='<%#Bind("TeacherName")%>'></asp:Label>
                            <asp:Label runat="server" ID="lblMaGV" Text='<%#Bind("TeacherID") %>' Visible="false" ></asp:Label>
                          </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:CommandField ShowSelectButton="true" HeaderText="Chọn"  />  
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#c6deff" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
               <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
      </tr>
   </table>
</div>
</asp:Content>

