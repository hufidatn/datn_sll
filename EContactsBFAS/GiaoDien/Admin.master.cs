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

public partial class GiaoDien_Admin : System.Web.UI.MasterPage
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null && Session.Contents["TrangThai"].ToString() == "DaDangNhap")
        {
            var c = from t in db.Users_UserGroups where t.Teacher.UserName == Session["UserName"] select t.UserGroupID;
            Quantri.Visible = false;
            NguoiDung.Visible = false;
            PhanQuyen.Visible = false;
            HanhKiem.Visible = false;
            KQRLCua1Lop.Visible = false;
            Vipham.Visible = false;
            DiemTheoMon.Visible = false;
            NhapDiem.Visible = false;
            PhieuDiem.Visible = false;
            KQRLCuaLop.Visible = false;
            foreach (var c1 in c)
            {
                if (c1 == 1)
                {
                    Quantri.Visible = true;
                    NguoiDung.Visible = true;
                    PhanQuyen.Visible = true;
                    //HanhKiem.Visible = false;
                    KQRLCua1Lop.Visible = true;
                    KQRLCuaLop.Visible = true;
                    //Vipham.Visible = false;
                    //DiemTheoMon.Visible = false;
                    //NhapDiem.Visible = false;
                    PhieuDiem.Visible = true;
                }
                if (c1 == 2)
                {
                    //Download source code tại Sharecode.vn
                    //Quantri.Visible = false;
                    NguoiDung.Visible = true;
                    //PhanQuyen.Visible = false;
                    HanhKiem.Visible = true;
                    KQRLCua1Lop.Visible = true;
                    KQRLCuaLop.Visible = true;
                    Vipham.Visible = true;
                    //DiemTheoMon.Visible = false;
                    //NhapDiem.Visible = false;
                    PhieuDiem.Visible = true;
                }
                if (c1 == 3)
                {
                    //Quantri.Visible = false;
                    NguoiDung.Visible = true;
                    //PhanQuyen.Visible = false;
                    //HanhKiem.Visible = false;
                    //KQRLCua1Lop.Visible = false;
                    //KQRLCuaLop.Visible = false;
                    //Vipham.Visible = false;
                    DiemTheoMon.Visible = true;
                    NhapDiem.Visible = true;
                    //PhieuDiem.Visible = false;
                }
                if (c1 == 4)
                {

                    //Quantri.Visible = false;
                    NguoiDung.Visible = true;
                    //PhanQuyen.Visible = false;
                    //HanhKiem.Visible = false;
                    KQRLCua1Lop.Visible = true;
                    //Vipham.Visible = false;
                    //DiemTheoMon.Visible = false;
                    //NhapDiem.Visible = false;
                    //PhieuDiem.Visible = true;
                }
            }
            
            lblTenDN.Text = Session["TeacherName"].ToString();
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
}
