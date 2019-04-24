<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="DanhGiaHanhKiem.aspx.cs" Inherits="GiaoDien_DanhGiaHanhKiem" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css"  rel="Stylesheet" type="text/css"/>
    <style type="text/css">
        .style1
        {
            text-align: right;
            height: 30px;
            font-size: 17px;
            width: 332px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-bottom:5px;">
    <div class="tieude">    
        Đánh giá hạnh kiểm
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
            <asp:ComboBox ID="cboKy" runat="server" Width="130px" Height="25px" >
            </asp:ComboBox>
            </td>
        </tr>
        <tr>
            <td class="tentruong"> Lớp học:</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboLop" runat="server" AutoPostBack="True" Width="130px" 
                    Height="25px" onselectedindexchanged="cboLop_SelectedIndexChanged" >
            </asp:ComboBox>
            </td>
        </tr>
        
        <tr>
            <td class="tentruong"> Họ và tên học sinh:</td>
            <td class="dieukhien">
            <asp:ComboBox ID="cboTenHS" runat="server" Width="250px" Height="25px" >
            </asp:ComboBox>
            
            
            <asp:Label runat="server" ID="lblMaHS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center"> <asp:LinkButton runat="server" ID="lkbLoiVP" 
                    Text="Xem thông tin vi phạm của học sinh này" onclick="lkbLoiVP_Click"></asp:LinkButton></td>
         
        </tr>
        <tr>
            <td colspan="2" align="center"><label runat="server" id="lblThongBao" style="color:Red"></label></td>
         
        </tr>
     
        </table>
        <br />
        <hr />
        <table border="1px">
            <tr>
                <td colspan="2" class="table" style="text-align:center;font-size:20px">Các tiêu chí đánh giá</td>
            </tr>
            <tr>
                <td class="table">1.Luôn kính trọng người trên, thầy giáo, cô giáo, cán bộ và nhân viên nhà trường; thương yêu và giúp đỡ các em nhỏ tuổi; có ý thức xây dựng tập thể, đoàn kết với các bạn, được các bạn tin yêu.</td>
                <td class="table1"> <asp:TextBox runat="server" ID="txtDG1" Text="20" Width="50px" Height="25px" ></asp:TextBox>
                <asp:NumericUpDownExtender runat="server" ID="nmDG1" Maximum="20" Minimum="10"  TargetControlID="txtDG1"
                       Width="100"></asp:NumericUpDownExtender>
               
                </td>
            </tr>
            <tr>
                <td class="table" >2.Tích cực rèn luyện phẩm chất đạo đức, có lối sống lành mạnh, trung thực, giản dị, khiêm tốn</td>
                <td class="table1"><asp:TextBox runat="server" ID="txtDG2" Text="20" Width="50px" Height="25px"></asp:TextBox>
                <asp:NumericUpDownExtender runat="server" ID="NumericUpDownExtender1" Maximum="20" Minimum="10"  TargetControlID="txtDG2"
                       Width="100"   ></asp:NumericUpDownExtender></td>
            </tr>
            <tr>
                <td class="table">3.Hoàn thành đầy đủ nhiệm vụ học tập, cố gắng vươn lên trong học tập</td>
                <td class="table1"><asp:TextBox runat="server" ID="txtDG3" Text="20" Width="50px" Height="25px"></asp:TextBox>
                <asp:NumericUpDownExtender runat="server" ID="NumericUpDownExtender2" Maximum="20" Minimum="10"  TargetControlID="txtDG3"
                       Width="100"   ></asp:NumericUpDownExtender></td>
            </tr>
            <tr>
                <td class="table">4.Thực hiện nghiêm túc nội quy nhà trường; chấp hành tốt luật pháp, quy định về trật tự, an toàn xã hội, an toàn giao thông; tích cực tham gia đấu tranh, phòng chống tội phạm, tệ nạn xã hội và tiêu cực trong học tập, kiểm tra, thi cử</td>
                <td class="table1"><asp:TextBox runat="server" ID="txtDG4" Text="20" Width="50px" Height="25px"></asp:TextBox>
                <asp:NumericUpDownExtender runat="server" ID="NumericUpDownExtender3" Maximum="20" Minimum="10"  TargetControlID="txtDG4"
                       Width="100"   ></asp:NumericUpDownExtender></td>
            </tr>
            <tr>
                <td class="table">5.Tích cực rèn luyện thân thể, giữ gìn vệ sinh và bảo vệ môi trường</td>
                <td class="table1"><asp:TextBox runat="server" ID="txtDG5" Text="10" Width="50px" Height="25px"></asp:TextBox>
                <asp:NumericUpDownExtender runat="server" ID="NumericUpDownExtender4" Maximum="10" Minimum="0"  TargetControlID="txtDG5"
                       Width="100"   ></asp:NumericUpDownExtender></td>
            </tr>
            <tr>
                <td class="table">6.Tham gia đầy đủ các hoạt động giáo dục quy định trong Kế hoạch giáo dục, các hoạt động chính trị, xã hội do nhà trường tổ chức; tích cực tham gia các hoạt động của Đội Thiếu niên tiền phong Hồ Chí Minh, Đoàn Thanh niên cộng sản Hồ Chí Minh; chăm lo giúp đỡ gia đình</td>
                <td class="table1"><asp:TextBox runat="server" ID="txtDG6" Text="10" Width="50px" Height="25px"></asp:TextBox>
                <asp:NumericUpDownExtender runat="server" ID="NumericUpDownExtender5" Maximum="10" Minimum="0"  TargetControlID="txtDG6"
                       Width="100"   ></asp:NumericUpDownExtender></td>
            </tr>
            <tr>
                <td class="table">7.Có sai phạm với tính chất nghiêm trọng hoặc lặp lại nhiều lần trong việc thực hiện quy định trên, được giáo dục nhưng chưa sửa chữa</td>
                <td class="table2"><asp:CheckBox runat="server" ID="ckSP1" Width="50px" Height="30px" /></td>
            </tr>
             <tr>
                <td class="table">8.Vô lễ, xúc phạm nhân phẩm, danh dự, xâm phạm thân thể của giáo viên, nhân viên nhà trường</td>
                <td class="table2"><asp:CheckBox runat="server" ID="ckSP2" Width="50px" Height="30px"/></td>
            </tr>
             <tr>
                <td class="table">9.Gian lận trong học tập, kiểm tra, thi cử</td>
                <td class="table2"><asp:CheckBox runat="server" ID="ckSP3" Width="50px" Height="30px"/></td>
            </tr>
            <tr>
                <td class="table">10.Xúc phạm danh dự, nhân phẩm của bạn hoặc của người khác; đánh nhau, gây rối trật tự, trị an trong nhà trường hoặc ngoài xã hội</td>
                <td class="table2"><asp:CheckBox runat="server" ID="ckSP4" Width="50px" Height="30px" /></td>
            </tr>
            <tr>
                <td class="table">11.Đánh bạc; vận chuyển, tàng trữ, sử dụng ma tuý, vũ khí, chất nổ, chất độc hại; lưu hành văn hoá phẩm độc hại, đồi truỵ hoặc tham gia tệ nạn xã hội</td>
                <td class="table2"><asp:CheckBox runat="server" ID="ckSP5" Width="50px" Height="30px" /></td>
            </tr>
            <tr>
                <td colspan="2" align="right" style="padding-right:10px;">
                <asp:Button runat="server" ID="btnTongDiem" Text="Tổng điểm đánh giá" 
                        onclick="btnTongDiem_Click" /> &nbsp;&nbsp;&nbsp;
                    <asp:TextBox runat="server" ID="txtTongDiem">
                    
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right" style="padding-right:10px;">
                    Xếp loại:&nbsp;&nbsp;&nbsp;
                    
                    <asp:RadioButton runat="server" ID="rdoTot" Text="Tốt" GroupName="HanhKiem" />&nbsp;&nbsp;
                    <asp:RadioButton runat="server" ID="rdoKha" Text="Khá" GroupName="HanhKiem" />&nbsp;&nbsp;
                    <asp:RadioButton runat="server" ID="rdoTrungBinh" Text="Trung bình" GroupName="HanhKiem" />&nbsp;&nbsp;
                    
                    <asp:RadioButton runat="server" ID="rdoKem" Text="Kém" GroupName="HanhKiem" />
                  
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <label id="lblThongBao2" runat="server" style="color:Red"></label>
                </td>
            </tr>
        </table>
        <br />
        <table style="width:100%" >
            <tr>
            <td class="style1"></td>
            <td class="dongdieukhien">
            <span>
                <asp:Button runat="server" ID="btnDanhGia" Text="Đánh giá" Width="114px" Height="25px" 
                    Font-Size="15px" onclick="btnDanhGia_Click"  />&nbsp;&nbsp;
             </span>   
                <asp:Button runat="server" ID="btnDanhGiaLai" Text="Đánh giá lại" Width="105px" 
                    Height="25px" Font-Size="15px" onclick="btnDanhGiaLai_Click" />
            </td>
            </tr>
            <%--<tr>
                <td class="style1"> Tổng điểm đánh giá</td>
                <td class="dieukhien"><asp:TextBox runat="server" ID="txtTongDiem"></asp:TextBox></td>
            </tr>--%>
            <%--<tr>
                <td class="style1"> Hạnh kiểm</td>
                <td class="dieukhien"><asp:TextBox runat="server" ID="txtHanhKiem"></asp:TextBox></td>
            </tr>--%>
            <tr>
                <td colspan="2" class="gridview">
           
                <asp:GridView ID="grvHanhKiem" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" 
                    AllowPaging="True" Height="28px" ShowFooter="True" 
                        onselectedindexchanged="grvHanhKiem_SelectedIndexChanged"  >
                    
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField> 
                        
                      
                        
                        <asp:TemplateField HeaderText="Mã học sinh" SortExpression="StudentID">
                        <ItemTemplate>
                            <%#Eval("StudentID") %>
                        
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên học sinh" SortExpression="StudentName">
                        <ItemTemplate>
                            <%#Eval("StudentName") %>
                        
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hạnh kiểm" SortExpression="StudentName">
                        <ItemTemplate>
                            <%#Eval("Conduct1") %>
                        
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:CommandField HeaderText="Chọn" ShowSelectButton="true" />
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                        BorderColor="Blue" Height="30px" />
                </asp:GridView>
               
            </td>
            </tr>
        </table>
</div>
</asp:Content>

