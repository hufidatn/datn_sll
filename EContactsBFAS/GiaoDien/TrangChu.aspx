<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Client.master" AutoEventWireup="true" CodeFile="TrangChu.aspx.cs" Inherits="GiaoDien_TrangChu" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../CSS/StyleTrangChu.css" rel="Stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="wrapper">
        <div id="contentTop1">
            <div class="Top1left">
                <%--<div>
                    <div class="slideshow" id="SlideJquery">
                        <img src="../image/75284187-ams15.jpg" alt="anhQC" title="1" />
                        <img src="../image/image00412.jpg" alt="anhQC" title="2" />
                        <img src="../image/hoaphuongdo.jpg" alt="anhQC" title="3" />
                    </div>
                </div>--%>
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
        </ol>
        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <a href="#">
                    <img src="../image/slider1.jpg" width="100%" height="400" alt="Panel_1" />
                </a>
            </div>
            <div class="item">
                <a href="#">
                    <img src="../image/slider2.jpg" width="100%" height="400" alt="Panel_2" />
                </a>
            </div>
            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
            </div>
            <div class="Top1right" style="width: 370px; height: 350px; background-color: #fff0f0; margin-left: 3px">
                <%--<div class="title" style="width:370px;padding-top:10px">ĐĂNG NHẬP</div>--%>
                <div style="margin-top: 5px">
                    <div class="col-md-12 mx-auto">
                        <div id="first">
                            <div class="myform form ">
                                <div class="logo mb-3">
                                    <div class="col-md-12 text-center">
                                        <h1>Đăng nhập</h1>
                                    </div>
                                </div>
                                <form action="" method="post" name="login">
                                    <div class="form-group col-md-12">
                                        <label for="exampleInputEmail1" style="font-size: 16px">Tài khoản</label>
                                        <asp:textbox runat="server" id="txtTenDN" height="25px" class="form-control"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <label for="exampleInputEmail1" style="font-size: 16px">Mật khẩu</label>
                                        <asp:textbox runat="server" id="txtMK" height="25px" textmode="Password" class="form-control"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <asp:checkbox runat="server" id="ckGhiNho" text=" Ghi nhớ mật khẩu" cssclass="dieukhien" font-size="14px" />
                                        <br>
                                        <label runat="server" id="lblThongBao" style="color: Red; font-size: 17px"></label>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <asp:button runat="server" id="Button1" cssclass="btn btn-success btn-block" onclick="imbDN_Click" text="Đăng nhập" />
                                    </div>
                                    <div class="col-md-12 ">
                                        <div class="login-or">
                                            <hr class="hr-or">
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 10px;">
            <div class="col-md-5">
                <div class="panel panel-default" id="newsleft">
                <div class="panel-heading">Tin mới nhất</div>
                <div class="panel-body" id="tin">
                    <table>
                        <tr>
                            <td class="dau">*</td>
                            <td class="muctin">&nbsp;&nbsp;&nbsp;Thay đổi tiết không khoa học</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="noidungtin">
                                <p>&nbsp;&nbsp;&nbsp;Phân phối chương trình môn sinh học lớp 6 đã được Bộ GD-ĐT đảo tiết sai logic về mạch kiến thức, gây phản khoa học.</p>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td class="dau">*</td>
                            <td class="muctin small">&nbsp;&nbsp;&nbsp;Còn nhiều chỉ tiêu</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="noidungtin">
                                <p>&nbsp;&nbsp;&nbsp;Vẫn còn nhiều ngành số HS nộp vào chỉ đếm trên đầu ngón tay.</p>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td class="dau">*</td>
                            <td class="muctin">&nbsp;&nbsp;&nbsp;Giảm tải</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="noidungtin">
                                <p>&nbsp;&nbsp;&nbsp; Giảm tải nội dung sách giáo khoa, chống lạm thu, đổi mới thi cử là những vấn đề được Bộ GD-ĐT tập trung giải đáp </p>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            </div>
            <div class="col-md-7">
            <div class="panel panel-default" id="newsright">
                <div class="panel-heading">Tin giáo dục</div>
                <div class="panel panel-body">
                    <table>
                        <tr>
                            <td rowspan="2">
                                <img src="../image/co-dan-be-vao-lop-1_791e8_18112011073957AM.jpg" width="130px" height="100px" /></td>
                            <td class="tieude1">Cô giáo của con!</td>
                        </tr>
                        <tr>

                            <td class="nd1">
                                <p>Con đã trưởng thành từ những bài giảng, những lời dạy bảo của mẹ. Cùng lúc, mẹ gánh vác trên vai hai trách nhiệm, đó là trách nhiệm của một người giáo viên, và của một người mẹ.</p>
                            </td>
                        </tr>

                    </table>
                    <br />
                    <table>
                        <tr>
                            <td rowspan="2">
                                <img src="../image/dieu-duong_16008_18112011074055AM1.jpg" alt="an" /></td>
                            <td class="tieude1">Giảm chỉ tiêu tuyển sinh năm 2019 với các trường vi phạm liên kết đào tạo</td>
                        </tr>
                        <tr>

                            <td class="nd1">
                                <p>Bộ GD-ĐT vừa có công văn gửi các đại học, học viện, các trường đại học, cao đẳng yêu cầu chấn chỉnh liên kết đào tạo đại học, cao đẳng. Theo đó, trừ chỉ tiêu tuyển sinh năm 2019 đối với các trường vi phạm qui định</p>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>

