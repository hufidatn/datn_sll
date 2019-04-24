<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Client.master" AutoEventWireup="true" CodeFile="TrangChu.aspx.cs" Inherits="GiaoDien_TrangChu" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/StyleTrangChu.css" rel="Stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
 <div id="contentTop1">
<div class="Top1left">
<div >
<div class="slideshow" id="SlideJquery">
        <img src="../image/75284187-ams15.jpg" alt="anhQC" title="1"/>
        <img src="../image/image00412.jpg" alt="anhQC" title="2"/>
        <img src="../image/hoaphuongdo.jpg" alt="anhQC" title="3" />
        <%--<img src="../Image/AnhQC/slide4.jpg" alt="anhQC" title="4"/>
        <img src="../Image/AnhQC/slide5.jpg" alt="anhQC" title="5"/>
        --%>
    </div>
</div>
</div>
<div class="Top1right" style=" width:370px; height:350px; background-color:#5197ff; margin-left:3px"> 
<div class="title" style="width:370px;padding-top:10px">ĐĂNG NHẬP</div>
<div style="margin-top:5px">

    <table style="width:350px">
        <tr>
            <td class="ten">Tên đăng nhập:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtTenDN" Width="150px" Height="25px"></asp:TextBox></td>
        </tr> 
        <tr>
            <td class="ten">Mật khẩu:</td>
            <td class="dieukhien" style="color:black"><asp:TextBox runat="server" ID="txtMK" Width="150px" 
                    Height="25px" TextMode="Password"></asp:TextBox></td>
        </tr> 
        <tr>
            <td class="ten"></td>
            <td class="dieukhien"><asp:CheckBox runat="server" ID="ckGhiNho" Text="Ghi nhớ mật khẩu" CssClass="dieukhien" Font-Size="17px" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
            <label runat="server" id="lblThongBao" style="color:Red;font-size:17px"> </label>
            </td>
        </tr>  
        <tr>
            <td class="ten"></td>
            <%--<td class="dieukhien"><asp:Button runat="server" ID="btnDN" Text="Đăng nhập" 
                    BackColor="#FFFFCC" Font-Size="17px" 
                    ForeColor="#0033CC"  /></td>--%>
                    <td>
                        <%--<asp:ImageButton runat="server" ID="imbDN"
                            CssClass="btn btn-success" onclick="imbDN_Click" />--%>
                        <asp:Button runat="server" ID="imbDN"
                            CssClass="btn btn-success" onclick="imbDN_Click" Text="Đăng nhập" />
<%--                        <button type="submit" class="btn btn-success" style="font-size:14px; width:auto" runat="server" ID="imbDN" onclick="imbDN_Click" >Login </button>--%>
                    </td>
        </tr>   
    </table>
</div>
</div>
</div>
    <div class="row" style="margin-top:10px;">
        <div class="col-md-3 panel" id="newsleft" >
            <div class="panel-primary panel-heading" >Tin mới nhất</div>
            <div class="panel-body" id="tin">
                <table>
                    <tr>
                        <td class="dau">*</td>
                        <td class="muctin">&nbsp;&nbsp;&nbsp;Đảo tiết không khoa học</td>
                    </tr>
                    <tr>
                    <td></td>
                        <td class="noidungtin" ><p>&nbsp;&nbsp;&nbsp;Phân phối chương trình môn sinh học lớp 6 đã được Bộ GD-ĐT đảo tiết sai logic về mạch kiến thức, gây phản khoa học.</p> </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td class="dau" >*</td>
                        <td class="muctin">&nbsp;&nbsp;&nbsp;Còn nhiều chỉ tiêu trước giờ G</td>
                    </tr>
                    <tr>
                    <td></td>
                        <td class="noidungtin" ><p>&nbsp;&nbsp;&nbsp;Vẫn còn nhiều ngành số HS nộp vào chỉ đếm trên đầu ngón tay.</p> </td>
                    </tr>
                </table>
                <br />
                    <table>
                    <tr>
                        <td class="dau" >*</td>
                        <td class="muctin">&nbsp;&nbsp;&nbsp;Giảm tải và chấm dứt lạm thu</td>
                    </tr>
                    <tr>
                    <td></td>
                        <td class="noidungtin" ><p>&nbsp;&nbsp;&nbsp; Giảm tải nội dung sách giáo khoa, chống lạm thu, đổi mới thi cử là những vấn đề được Bộ GD-ĐT tập trung giải đáp </p> </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="col-md-9" id="newsright">
        <div class="panel-primary panel-heading" style="width:330px;"><div style="margin-left:100px;width:220px;">Tin giáo dục</div> </div>
        <div class="panel panel-body">
            <table>
            <tr>
                    <td rowspan="2"><img src="../image/co-dan-be-vao-lop-1_791e8_18112011073957AM.jpg" width="130px" height="100px"  /></td>
                    <td class="tieude1"> Mẹ-Cô giáo của con!</td>
                </tr>
                <tr>
                    
                    <td class="nd1"><p>Con đã trưởng thành từ những bài giảng, những lời dạy bảo của mẹ. Cùng lúc, mẹ gánh vác trên vai hai trách nhiệm, đó là trách nhiệm của một người giáo viên, và của một người mẹ.</p></td>
                </tr>
                
            </table>
            <br />
            <table>
                <tr>
                    <td rowspan="2"> <img src="../image/dieu-duong_16008_18112011074055AM1.jpg" alt="an" /></td>
                    <td class="tieude1"> Trừ chỉ tiêu tuyển sinh năm 2012 với các trường vi phạm liên kết đào tạo</td>
                </tr>
                <tr>
                    
                    <td class="nd1"><p>Bộ GD-ĐT vừa có công văn gửi các đại học, học viện, các trường đại học, cao đẳng yêu cầu chấn chỉnh liên kết đào tạo đại học, cao đẳng. Theo đó, trừ chỉ tiêu tuyển sinh năm 2012 đối với các trường vi phạm qui định</p></td>
                </tr>
                
            </table>
            </div>
        </div>
    </div>
</div>
</asp:Content>

