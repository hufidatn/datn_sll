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
using System.Collections.Generic;
using System.Net.Mail;


public partial class GiaoDien_QuanLyGiaoVien : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            //btnMoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

    }
    string MaTuTang()
    {
        string madiem = "";
        List<string> list = new List<string>();
        string[] a = DateTime.Now.ToShortDateString().Split('/');
        string dau = a[2].Substring(2, 2) + a[0] + a[1];
        string madautien = dau + "001";
        var c = from p in db.Teachers select p.TeacherID;
        
        foreach (var con in c)
        {

            if (con.ToString().Substring(0, 5) == dau)
            {
                list.Add(con.ToString());
            }
        }
        if (list.Count == 0)
        {
            madiem = madautien;
        }
        else
            if (list.Count > 0)
            {

                madiem = (int.Parse(list[list.Count - 1]) + 1).ToString();

            }
        return madiem;

    }
    void Them()
    {
        Teacher tch = new Teacher();
        tch.TeacherID = MaTuTang();
        tch.TeacherName = txtHoTen.Text;
        tch.Email = txtEmail.Text;
        tch.Phone = txtSDTDD.Text;
        db.Teachers.InsertOnSubmit(tch);
        db.SubmitChanges();
    }
    bool kiemtraemail()
    {
        bool kt=true;
        lblChuThichEmail.InnerText = "";
        var c = from p in db.Teachers
                where p.Email == txtEmail.Text
                select p.Email;
        if (c.Count() != 0)
        {
            kt = false;
            lblChuThichEmail.InnerText = "Email đã tồn tại!";
        }
        if (cls.CheckEmail(txtEmail.Text) == false)
        {
            kt = false;
            lblChuThichEmail.InnerText = "Email không hợp lệ!";
        }
        if (txtEmail.Text == "")
        {
            kt = false;
            lblChuThichEmail.InnerText = "Bạn phải nhập email";
        }
        return kt;
    }
    bool kiemtrasodienthoai()
    {
        bool kt = true;
        lblChuThichSDT.InnerText = "";
        if (txtSDTDD.Text == "")
        {
            kt = false;
            lblChuThichSDT.InnerText = "Số điện thoại không được để trống";
        }
        if (cls.CheckPhone(txtSDTDD.Text) == false)
        {
            kt = false;
            lblChuThichSDT.InnerText = "Số điện thoại nhập không đúng định dạng";
        }
        return kt;
    }
    bool kiemtrahoten()
    {
        bool kt = true;
        lblChuThichTenGV.InnerText = "";
        if (txtHoTen.Text == "")
        {
            kt = false;
            lblChuThichTenGV.InnerText = "Họ tên không được để trống";
        }
        return kt;
    }
    void LoadGrid()
    {
        var c = from p in db.Teachers
                select new { p.TeacherName, p.TeacherID, p.Email, p.Phone };
        grvGiaoVien.DataSource = c;
        grvGiaoVien.DataBind();
        LamMoi();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool kt = true;
        
        kt = kiemtrahoten();
        if (kt == false)
            return;
        kt = kiemtraemail();
        if (kt == false)
            return;
        kt = kiemtrasodienthoai();
        if (kt == false)
            return;
        //if (kiemtraemail() == true)
        //{
        if (kt == true)
        {
            Them();
            LoadGrid();
        }
       

    }
    void LamMoi()
    {
        txtHoTen.Text = "";
        txtSDTDD.Text = "";
        txtEmail.Text = "";
        btnXoa.Enabled = false;
        btnSua.Enabled = false;

    }
    //string ma = "";
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool kt = true;

        kt = kiemtrahoten();
        if (kt == false)
            return;
        kt = kiemtraemail();
        if (kt == false)
            return;
        kt = kiemtrasodienthoai();
        if (kt == false)
            return;
        Teacher tch = db.Teachers.SingleOrDefault(p => p.TeacherID == lblMa.Text);
        tch.TeacherName = txtHoTen.Text;
        tch.Phone = txtSDTDD.Text;
        tch.Email = txtEmail.Text;
        db.SubmitChanges();
        LoadGrid();

    }
    protected void grvGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSua.Enabled = true;
        btnXoa.Enabled = true;
        btnThem.Enabled = false;
        GridViewRow row = grvGiaoVien.SelectedRow;
        Label lbl = (Label)row.FindControl("lblMaGV");
        var c = (from p in db.Teachers where p.TeacherID == lbl.Text
              select new {p.TeacherName,p.Phone,p.Email,p.TeacherID}).First();
        txtEmail.Text = c.Email;
        txtHoTen.Text = c.TeacherName;
        txtSDTDD.Text = c.Phone;
        //ma = c.TeacherID.ToString().Trim();
        lblMa.Text = "19425001  ";
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        Teacher tch = db.Teachers.SingleOrDefault(p=>p.TeacherID== lblMa.Text);
        db.Teachers.DeleteOnSubmit(tch);
        db.SubmitChanges();
        LoadGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        LamMoi();
    }
    protected void grvGiaoVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGiaoVien.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }
}
