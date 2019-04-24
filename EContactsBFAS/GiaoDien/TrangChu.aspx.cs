using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class GiaoDien_TrangChu : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtMK.Attributes.Add("value", txtMK.Text);
        if (!IsPostBack)
        {
            //if (Request.Cookies["DangNhap"] != null)
            //{
            //    ckGhiNho.Checked = true;
            //    Request.Cookies["DangNhap"]["UserName"] = txtTenDN.Text;
            //    Request.Cookies["DangNhap"]["PassWord"] = txtMK.Text;
            //}
        }
    }
    protected void imbDN_Click(object sender, ImageClickEventArgs e)
    {
        
       txtMK.Attributes.Add("value", txtMK.Text);
       lblThongBao.InnerText = "";
       if (KiemTra() == true)
       {
           var c = from t in db.Teachers select t;
           foreach (var c1 in c)
           {
               if ((txtTenDN.Text == c1.UserName.Trim()) && (txtMK.Text == c1.PassWord.Trim()))
               {
                   // kt = true;
                   var c2 = from p in db.Users_UserGroups
                           where p.TeacherID.Trim() == c1.TeacherID
                               && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date>DateTime.Now.Date
                           select p;
                   if (c2.Count() !=0)
                   {
                       Session["UserName"] = txtTenDN.Text.ToString();
                       Session.Contents["TrangThai"] = "DaDangNhap";
                       Session["TeacherName"] = c1.TeacherName;
                       string url = Request.QueryString["url"];
                       if (!string.IsNullOrEmpty(url))
                           Response.Redirect(url);
                       else
                           Response.Redirect("Default.aspx");
                   }
                   else if(c2.Count()==0)
                   {
                       ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn không được phép truy cập hệ thống!');", true);
                       txtTenDN.Focus();
                       //lblThongBao.InnerText = "Bạn không được phép truy cập vào hệ thống!";
                   }
               }
               else
               {
                   if (txtTenDN.Text == c1.UserName.Trim()||txtMK.Text == c1.PassWord.Trim() )
                   {
                       ScriptManager.RegisterStartupScript(this, this.GetType(), "Arlet", "arlet('Tên đăng nhập hoặc mật khẩu chưa đúng');", true);
                       lblThongBao.InnerText = "Tên đăng nhập hoặc mật khẩu chưa đúng!";
                       txtTenDN.Text = "";
                       txtMK.Text = "";
                       //
                   }
                   
               }
               if (ckGhiNho.Checked == true)
               {
                   Request.Cookies["DangNhap"]["UserName"] = txtTenDN.Text;
                   Request.Cookies["DangNhap"]["PassWord"] = txtMK.Text;
               }
           }
       }
        else
       {
           //ScriptManager.RegisterStartupScript(this, this.GetType(), "Arlet", "arlet('Bạn nhập thiếu thông tin');", true);
           lblThongBao.InnerText = "Bạn phải đầy đủ thông tin !";
           txtTenDN.Focus();
           txtMK.Text = "";

       }

      
    }
    bool KiemTra()
    {
        bool kt = true;
        txtMK.Attributes.Add("value", txtMK.Text);
        if (txtTenDN.Text == "" && txtMK.Text == "")
        {
            kt = false;
             //ScriptManager.RegisterStartupScript(this, this.GetType(), "Arlet", "arlet('Bạn nhập thiếu thông tin');", true);     
        }
        else if (txtTenDN.Text == "" && txtMK.Text != "")
        {
            kt = false;
        }
        else if (txtTenDN.Text != "" && txtMK.Text == "")
        {
            kt = false;
        }

        else if (txtMK.Text != "" && txtTenDN.Text != "")
        {
            kt = true;
        }
        return kt;
    }


    protected void imbDN_Click(object sender, EventArgs e)
    {
        txtMK.Attributes.Add("value", txtMK.Text);
        lblThongBao.InnerText = "";
        if (KiemTra() == true)
        {
            var c = from t in db.Teachers select t;
            foreach (var c1 in c)
            {
                if ((txtTenDN.Text == c1.UserName.Trim()) && (txtMK.Text == c1.PassWord.Trim()))
                {
                    // kt = true;
                    var c2 = from p in db.Users_UserGroups
                             where p.TeacherID.Trim() == c1.TeacherID
                                 && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date > DateTime.Now.Date
                             select p;
                    if (c2.Count() != 0)
                    {
                        Session["UserName"] = txtTenDN.Text.ToString();
                        Session.Contents["TrangThai"] = "DaDangNhap";
                        Session["TeacherName"] = c1.TeacherName;
                        string url = Request.QueryString["url"];
                        if (!string.IsNullOrEmpty(url))
                            Response.Redirect(url);
                        else
                            Response.Redirect("Default.aspx");
                    }
                    else if (c2.Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn không được phép truy cập hệ thống!');", true);
                        txtTenDN.Focus();
                        //lblThongBao.InnerText = "Bạn không được phép truy cập vào hệ thống!";
                    }
                }
                else
                {
                    if (txtTenDN.Text == c1.UserName.Trim() || txtMK.Text == c1.PassWord.Trim())
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Arlet", "arlet('Tên đăng nhập hoặc mật khẩu chưa đúng');", true);
                        lblThongBao.InnerText = "Tên đăng nhập hoặc mật khẩu chưa đúng!";
                        txtTenDN.Text = "";
                        txtMK.Text = "";
                        //
                    }

                }
                if (ckGhiNho.Checked == true)
                {
                    Request.Cookies["DangNhap"]["UserName"] = txtTenDN.Text;
                    Request.Cookies["DangNhap"]["PassWord"] = txtMK.Text;
                }
            }
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Arlet", "arlet('Bạn nhập thiếu thông tin');", true);
            lblThongBao.InnerText = "Bạn phải đầy đủ thông tin !";
            txtTenDN.Focus();
            txtMK.Text = "";

        }

    }
}
