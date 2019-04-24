﻿<%@ Page Language="C#" MasterPageFile="~/GiaoDien/Admin.master" AutoEventWireup="true" CodeFile="NhapTTHS.aspx.cs" Inherits="GiaoDien_NhapTTHS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Admin.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
    function ktDL()
    {
         var check=true;
         lblThongBao.innerHTML="";
         var cboNgay=document.getElementById('<%=cboNgay.ClientID%>');
         var cboThang=document.getElementById('<%=cboThang.ClientID%>');
         var cboNam=document.getElementById('<%=cboNam.ClientID%>');
        if(isNaN(cboNgay.Text)==true||isNaN(cboNam.Text)==true||isNaN(cboThang.Text)==true)
        {
             
             lblThongBao.innerHTML="Bạn phải chọn ngày tháng";
             check=false;
        }
         
        return check;
            
    }
//    function isNgay(val,min,max)
//    {
//        if(val>=min&&val<=max)
//        {return true;}
//        else return false;
//    }
   
     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="khungchinh">
    
    <div class="tieude">
        Quản lý thông tin học sinh
    </div>
    <table style="width:100%;border:1 thin blue;">

        <tr>
            <td class="tentruong"> Mã học sinh:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtMaHS" Width="300px" Height="25px" Enabled="false" ></asp:TextBox></td>
            
        </tr>
        <tr>
            <td class="tentruong"> Họ tên học sinh:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtHoTen" Width="300px" Height="25px"></asp:TextBox>
            <label runat="server" id="lblChuThichHocSinh" style="color:Red;"></label></td>
          <%--  <td><p id="ckTen">* </p></td>--%>
        </tr>
        <tr>
            <td class="tentruong"> Ngày sinh:</td>
            <td class="dieukhien"><asp:ComboBox runat="server" ID="cboNgay" Width="60px"></asp:ComboBox>&nbsp;
                                    <asp:ComboBox runat="server" ID="cboThang" Width="70px"></asp:ComboBox>&nbsp;
                                    <asp:ComboBox runat="server" ID="cboNam" Width="70px"></asp:ComboBox>
                                    <label runat="server" id="lblChuThichNgaySinh" style="color:Red;"></label></td>
            <%--<td><p id="ckNgaySinh">* </p></td>--%>
            
        </tr>
        <tr>
            <td class="tentruong"> Giới tính:</td>
            <td class="dieukhien"><asp:RadioButton runat="server" ID="rdoNam" Text="Nam" 
                    GroupName="Gender" />&nbsp;&nbsp;&nbsp;<asp:RadioButton runat="server" 
                    ID="rdoNu" Text="Nữ" GroupName="Gender"/>
                    <label runat="server" id="lblChuThichGioiTinh" style="color:Red;"></label></td>
            <%--<td><p id="ckGioi">* </p></td>--%>
        </tr>
        <tr>
            <td class="tentruong">Quê quán:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtQueQuan" Width="300px" Height="25px"></asp:TextBox>
            <label runat="server" id="lblChuThichQueQuan"></label> </td>
           <%-- <td><p id="ckQQ">* </p></td>--%>
        </tr>
        <tr>
            <td class="tentruong"> Số điện thoại cố định:</td>
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtSDT" Width="150px" Height="25px"></asp:TextBox>
            <label runat="server" id="lblChuThichSDTCD" style="color:Red;"></label> </td>
            <td></td>
        </tr>
        <tr>
            <td class="tentruong"> Số điện thoại di động:</td>
            
            <td class="dieukhien"><asp:TextBox runat="server" ID="txtSDTDD" Width="150px" Height="25px"></asp:TextBox>
            <label runat="server" id="lblChuThichDTDD" style="color:Red;"></label>  </td>
            <td></td>
        </tr>
        <tr>
            <td class="tentruong"> Nhập từ excel:</td>
            <td class="dieukhien"> 
                <asp:CheckBox runat="server" ID="ckExcel" Text="chọn" 
                    oncheckedchanged="ckExcel_CheckedChanged" AutoPostBack="True" />
                    </td>
        </tr>
        <tr>
            <td class="tentruong"> Đường dẫn:</td>
            <td class="dieukhien"><asp:FileUpload runat="server" ID="fuNhapExcel" Width="300px" Height="25px" /> 
            <label runat="server" id="lblChuThichNhapExcel" style="color:Red;"></label></td>
        </tr>
     
        <tr>
            <td colspan="2" style="text-align:center"><label runat="server" id="lblThongBao" style="color:Red;text-align:center" ></label></td>
        </tr>
        <tr>
        <td class="tentruong"></td>
            <td  colspan="2" >
               
                <asp:Button runat="server" ID="btnThem" Text="Thêm" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnThem_Click" />&nbsp;&nbsp;
              
                <asp:Button runat="server" ID="btnSua" Text="Sửa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnSua_Click" OnClientClick="return ktDL();" />&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnXoa" Text="Xóa" Width="70px" Height="25px" 
                    Font-Size="15px" onclick="btnXoa_Click"/>&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnMoi" Text="Tạo mới" Width="70px" Height="25px" Font-Size="15px" onclick="btnMoi_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="gridview">
           <%--<asp:UpdatePanel runat="server" ID="uppl1">
           <ContentTemplate>--%>
            <asp:GridView ID="grvHocSinh" runat="server" AutoGenerateColumns="False" 
                      Width="100%"
                     ForeColor="#333333" GridLines="Vertical" AllowPaging="True" 
                         PageSize="10" 
                    
                    onselectedindexchanged="grvHocSinh_SelectedIndexChanged" 
                    onrowcommand="grvHocSinh_RowCommand" 
                    onpageindexchanging="grvHocSinh_PageIndexChanging"   >
                    <%--onrowdeleting="grvHocSinh_RowDeleting" 
                    onrowupdating="grvHocSinh_RowUpdating" 
                    onrowediting="grvHocSinh_RowEditing" 
                    onrowcancelingedit="grvHocSinh_RowCancelingEdit"--%>
                   
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                    <asp:TemplateField HeaderText="STT">   
                                 <ItemTemplate>   
                                 <%# Container.DataItemIndex + 1 %>   
                                </ItemTemplate>   
                    </asp:TemplateField>    
                            <asp:TemplateField HeaderText="Mã SV" SortExpression="StudentID">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("StudentID") %>' ID="lblMa"></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:Label runat="server" Text='<%#Bind("StudentID") %>' ID="lblMa" Width="100px" ></asp:Label></EditItemTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Họ và Tên" SortExpression="StudentName">
                                <ItemTemplate>
                                    <%#Eval("StudentName")%></ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("StudentName")%>' ID="txtHoTen1" Width="60px" ></asp:TextBox></EditItemTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ngày sinh" SortExpression="DateOfBirth">
                                <ItemTemplate>
                                    <%#String.Format("{0:dd/MM/yyyy}",Eval("DateOfBirth"))%></ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("DateOfBirth")%>' ID="txtNgaySinh1" Width="60px" ></asp:TextBox></EditItemTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Giới tính" SortExpression="Gender">
                                <ItemTemplate>
                                <%#Eval("Gender") %></ItemTemplate>
                     
                                <%--<EditItemTemplate>
                                    <asp:DropDownList runat="server"  ID="ddlGioi1" Width="60px" ></asp:DropDownList></EditItemTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Địa chỉ" SortExpression="Address">
                                <ItemTemplate>
                                    <%#Eval("Address")%></ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("Address")%>' ID="txtDiaChi1" Width="60px"  ></asp:TextBox></EditItemTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SĐTCĐ" SortExpression="PhoneFixe">
                                <ItemTemplate>
                                    <%#Eval("PhoneFixe")%></ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("PhoneFixe")%>' ID="txtCD" Width="60px" ></asp:TextBox></EditItemTemplate>--%>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SĐTDĐ" SortExpression="MobilePhone">
                                <ItemTemplate>
                                    <%#Eval("MobilePhone")%></ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox runat="server" Text='<%#Bind("MobilePhone")%>' ID="txtDD" Width="60px" ></asp:TextBox></EditItemTemplate>--%>
                            </asp:TemplateField>                           
                            <%--<asp:CommandField InsertText="" ShowEditButton="True" EditText="Sửa"
                                HeaderText="Chọn" />
                            <asp:CommandField HeaderText="Xóa" ShowDeleteButton="true" />--%>
                            <asp:CommandField ShowSelectButton="true" HeaderText="Chọn"  />
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#c6deff" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>
