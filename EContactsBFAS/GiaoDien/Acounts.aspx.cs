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

public partial class QuanTri_GroupUsers : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadgrvTaiKhoan();
            btnXoa.Enabled = false;
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        if (KiemTraMa(txtMa.Text) == true)
        {
            ScriptManager.RegisterStartupScript(this,this.GetType(),"Alert","alert('Người này đã được tạo tài khoản')",true);
        }
        else
        {
            Teacher tc = db.Teachers.SingleOrDefault(p => p.TeacherID == txtMa.Text);
            tc.UserName = txtDangNhap.Text;
            tc.PassWord = txtMatKhau.Text;
            db.SubmitChanges();
            LoadgrvTaiKhoan();
            Xoa();
        }
    }
    void LoadgrvTaiKhoan()
    {
        var c = from p in db.Teachers select new {p.UserName,p.TeacherName };
        grvTaiKhoan.DataSource = c;
        grvTaiKhoan.DataBind();
    }
    bool KiemTraMa(string ma)
    {    bool kt=false;
        var d = (from p in db.Teachers select p.TeacherID).First();
        if (d ==ma)
        {
            kt = true;
        }
        return kt;
    }
    void Xoa()
    {
        txtMa.Text = "";
        txtMatKhau.Text = "";
        txtMatKhau.Attributes.Add("value",txtMatKhau.Text);
        txtDangNhap.Text = "";
        txtNguoiDung.Text = "";
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        Teacher tc = db.Teachers.SingleOrDefault(p=>p.TeacherID==txtMa.Text);
        tc.UserName = "";
        tc.PassWord = "";
        db.SubmitChanges();
        LoadgrvTaiKhoan();
        Xoa();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Xoa();
    }
    protected void grvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvTaiKhoan.SelectedRow;
        Label lblNguoiDung = (Label)row.FindControl("lblTen");
        var c = (from p in db.Teachers
                 where p.TeacherName==lblNguoiDung.Text
                 select p).First();
        txtMa.Text = c.TeacherID;
        txtNguoiDung.Text = c.TeacherName;
        txtDangNhap.Text = c.UserName;
        txtMatKhau.Text = c.PassWord.Trim();
        txtMatKhau.Attributes.Add("value",txtMatKhau.Text);
        txtNguoiDung.Enabled = false;
        txtMa.Enabled = false;
        btnXoa.Enabled = true;
    }
}
