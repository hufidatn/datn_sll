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

public partial class GiaoDien_DoiMatKhau : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDoiMK_Click(object sender, EventArgs e)
    {
        txtMatKhauCu.Attributes.Add("value",txtMatKhauCu.Text);
        txtMatKhauMoi.Attributes.Add("value",txtMatKhauMoi.Text);
        txtNhapLai.Attributes.Add("value",txtNhapLai.Text);
        Teacher tc = db.Teachers.SingleOrDefault(p=>p.UserName.Trim()==txtTenDN.Text.Trim()&&p.PassWord.Trim()==txtMatKhauCu.Text.Trim());
        if (txtNhapLai.Text == txtMatKhauMoi.Text)
        {
            tc.PassWord = txtMatKhauMoi.Text;
            db.SubmitChanges();
            lblThongBao.Text = "Đổi mật khẩu thành công";
            txtTenDN.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLai.Text = "";
            txtMatKhauCu.Text = "";
        }
        else if (txtTenDN.Text == "" || txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLai.Text == "")
        {
            lblThongBao.Text = "Nhập thiếu thông tin";
            txtTenDN.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLai.Text = "";
            txtMatKhauCu.Text = "";//Download source code tại Sharecode.vn
        }
        else if (txtTenDN.Text != tc.UserName.Trim())
        {
            lblThongBao.Text = "Tên đăng nhập không đúng";
            txtTenDN.Text = "";
        }
        else if (txtMatKhauCu.Text != tc.PassWord.Trim())
        {
            lblThongBao.Text = "Mật khẩu cũ chưa đúng";
            txtMatKhauCu.Text = "";
        }
        else if (txtNhapLai.Text != txtMatKhauMoi.Text)
        {
            lblThongBao.Text = "Nhập lại mật khẩu mới chưa đúng";
            txtNhapLai.Text = "";
        }
    }
}
