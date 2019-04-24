<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Client.master" AutoEventWireup="true" CodeFile="SoLienLac.aspx.cs" Inherits="GiaoDien_SoLienLac" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Client.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="divKhungChinh">
<div class="titleDiem">
    Sổ liên lạc &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Họ và tên:&nbsp;&nbsp;<asp:Label runat="server" ID="lblTen"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Lớp:&nbsp;&nbsp;<asp:Label runat="server" ID="lblLop"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Năm học: &nbsp;&nbsp;<asp:Label runat="server" ID="lblNamHoc"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
    
</div>
<div style="margin:10px auto; height:500px">

<div id="divKhungDiem" >
    <div  style="border-bottom:solid 1px green; height:25px; width:450px; margin:5px;font-size:17px; padding-left:5px;-moz-border-radius:10px;" >Điểm trung bình các môn</div>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>
                        
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="MonHoc" HeaderText="Môn học" />
                        <asp:BoundField DataField="DTBK1" HeaderText="ĐTB kỳ I" />
                        <asp:BoundField DataField="DTBK2" HeaderText="ĐTB kỳ II" />
                        <asp:BoundField DataField="DTBCN" HeaderText="ĐTB cả năm" />
                        
                        
                            
                        </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>  
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
    <div style="float:left; margin:5px auto 5px 10px;border:solid 1px green; font-size:17px; padding-left:5px">
        <div style="border-bottom:solid 1px green; height:25px; width:435px; margin:5px;" >Các lỗi vi phạm</div>
        <div id="divViPham" style="width:440px;height:308px;" ></div>
    </div>
    
</div>
    
    
    <div class="divNhanXet" style="float:left;margin:5px auto 5px 20px;border:solid 1px green;font-size:17px; padding-left:5px">
    <div id="divtieude" style="border-bottom:solid 1px green; height:25px; width:900px; margin:5px;"> 
        Nhận xét đánh giá của giáo viên
    </div>
    <div id="divNDNX" style="width:927px;height:200px;" >
    </div>
        
    </div> 
</div>
</asp:Content>

