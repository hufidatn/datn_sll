
<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="NhapDiem.aspx.cs" Inherits="GiaoDien_NhapDiem" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript" >
 function ktdiemkhongdetrong()
    {
    //tên không được trống
    var check=true;
     var txtDiem=document.getElementById('<%=txtDiem.ClientID%>');
     var lblDiem=document.getElementById('<%=lblDiem.ClientID%>');
     if(txtDiem.value=="")
     {
     lblDiem.innerHTML="Điểm không được để trống!";
     check=false;
     }
     if(isNaN(txtDiem.value)==true)
        {
        lblDiem.innerHTML="Điểm số phải nằm trong khoảng từ 0--->10!";
        check=false;
        }
     if(ktDiemtu0den10(txtDiem.value,0,10)==false)
     {
     lblDiem.innerHTML="Điểm số phải nằm trong khoảng từ 0--->10!";
     check=false;
     }
     return check;
  
} 
    function ktDiemtu0den10(val,min,max)
    {
        if(val>=min&&val<=max)
        {
            return true;
        }
        else return false;
    }
</script>
    <div style="margin-bottom:5px;">
<div class="tieude">
        
        Nhập điểm cho học sinh
    </div>
    <table style="width:100%;border:1 thin blue;">
        
        <tr>
            <td class="tentruong"> Năm học:</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboNam" runat="server" Width="130px" Height="25px" 
                    AutoPostBack="True" onselectedindexchanged="cboNam_SelectedIndexChanged">
            </asp:ComboBox>
            </td>
        </tr>
       
        <tr>
            <td class="tentruong"> Kỳ học</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboKy" runat="server" AutoPostBack="True" Width="130px" Height="25px"
                    onselectedindexchanged="cboKy_SelectedIndexChanged">
            </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Lớp học:</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboLop" runat="server" AutoPostBack="True" Width="130px" Height="25px"
                    onselectedindexchanged="cboLop_SelectedIndexChanged">
            </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Môn học:</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboMonHoc" runat="server" Width="200px" Height="25px" 
                    onselectedindexchanged="cboMonHoc_SelectedIndexChanged">
            </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Họ và tên học sinh:</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboTenHS" runat="server" Width="250px" Height="25px" 
                    onselectedindexchanged="cboTenHS_SelectedIndexChanged">
            </asp:ComboBox>
            
            
            <asp:Label runat="server" ID="lblMaHS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Loại điểm:</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboLoaiDiem" runat="server" Width="130px" Height="25px"> 
            </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Số điểm:</td>
            <td class="dieukhien">
            <span>
            <asp:TextBox runat="server" ID="txtDiem" Width="130px" Height="25px"></asp:TextBox>
            </span>
            <label id="lblDiem" runat="server" style="color:Red;" ></label>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Nhập từ excel:</td>
            <td class="dieukhien">
           
            <asp:FileUpload runat="server" ID="fuNhapExcel"  Width="300px" Height="25px"/>
            <label id="lblNhapExcel" runat="server" style="color:Red"></label>
            
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center"><label runat="server" id="lblThongBao"></label></td>
        </tr>
        <tr>
        
            <td class="dongdieukhien" colspan="2" style="text-align:center;">
            <span>
                <asp:Button runat="server" ID="btnThem" Text="Nhập" Width="150px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click" OnClientClick="return ktdiemkhongdetrong();" />&nbsp;&nbsp;
             </span>   
             <asp:Button runat="server" ID="btnNhapEcel" Text="Nhập từ excel" Width="150px" Height="25px" 
                    Font-Size="15px" onclick="btnNhapEcel_Click"  />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="150px" 
                    Height="25px" Font-Size="15px" onclick="btnMoi_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="gridview">
            <%--<asp:UpdatePanel runat="server" ID="uppl1">
            <ContentTemplate>--%>
            <asp:GridView ID="grvNhapDiem" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" 
                    onselectedindexchanged="grvNhapDiem_SelectedIndexChanged" 
                    AllowPaging="True" Height="28px" ShowFooter="True" 
                    onpageindexchanged="grvNhapDiem_PageIndexChanged" 
                    onpageindexchanging="grvNhapDiem_PageIndexChanging" 
                    onselectedindexchanging="grvNhapDiem_SelectedIndexChanging">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField> 
                        
                      
                        <asp:TemplateField HeaderText="Năm học" SortExpression="SchoolYearName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNam" Text='<%#Bind("SchoolYearName") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblMaNam" Text='<%#Bind("SchoolYearID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kỳ học" SortExpression="SemesterName">
                        <ItemTemplate>
                          <%#Eval("SemesterName")%>
                          <asp:Label runat="server" ID="lblMaKy" Text='<%#Bind("SemesterID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lớp học" SortExpression="ClassName">
                        <ItemTemplate>
                            <%#Eval("ClassName") %>
                            <asp:Label runat="server" ID="lblMaLop" Text='<%#Bind("ClassID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Môn học" SortExpression="SubjectName">
                        <ItemTemplate>
                            <%#Eval("SubjectName") %>
                            <asp:Label runat="server" ID="lblMaMon" Text='<%#Bind("SubjectID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Chi tiết">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkDiemChiTiet" 
                            PostBackUrl='<%#"~/GiaoDien/DiemChiTiet.aspx?SchoolYearID="+Eval("SchoolYearID")
                            +"&ClassID="+Eval("ClassID")+"&SemesterID="+Eval("SemesterID")+"&SubjectID="+Eval("SubjectID")%>'
                             Text="Chi tiết điểm"></asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                        BorderColor="Blue" Height="30px" />
                </asp:GridView>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>

