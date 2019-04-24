using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class GiaoDien_Client : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        lbtDangXuat.Visible = false;
        lblTenDN.Visible = false;
        lkbQuanLy.Visible = false;
        text.Visible = false;
        
            if (Session["UserName"] != null && Session.Contents["TrangThai"].ToString() == "DaDangNhap")
            {
                text.Visible = true;
                lblTenDN.Text = Session["TeacherName"].ToString();
                lkbQuanLy.Visible = true;
                lbtDangXuat.Visible = true;
            }
            else
                if (Session["UserName"] == null && Session.Contents["TrangThai"].ToString() == "ChuaDangNhap")
                {
                    Response.Redirect("TrangChu.aspx?url=" + Request.Url.PathAndQuery);
                }
        
    }
    protected void lbtDangXuat_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/GiaoDien/TrangChu.aspx");
        Session.Abandon();
    }
    protected void lkbQuanLy_Click(object sender, EventArgs e)
    {
        if (Session["UserName"] != null && Session.Contents["TrangThai"].ToString() == "DaDangNhap")
        {
            Response.Redirect("~/GiaoDien/Default.aspx");
        }
    }
}
