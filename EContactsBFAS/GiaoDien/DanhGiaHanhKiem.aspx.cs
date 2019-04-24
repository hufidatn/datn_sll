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

public partial class GiaoDien_DanhGiaHanhKiem : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    protected void Page_Load(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        if (!IsPostBack)
        {
            cls.LoadCBNamTheoGV(c.First(),cboNam);
            cls.LoadComBoxKy(cboKy);
            cls.LoadCBLopTheoGV(c.First(),cboLop,cboNam);
            LoadComBoxHS();
            LoadGridHK();
        }
        
    }
    void LoadComBoxHS()
    {

        var c = from p in db.ClassStudents
                where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                select new { p.StudentID, p.Student.StudentName };
        if (c.Count() != 0)
        {
            cboTenHS.DataTextField = "StudentName";
            cboTenHS.DataValueField = "StudentID";
            cboTenHS.DataSource = c;
            cboTenHS.DataBind();
        }
    }
    protected void cboLop_SelectedIndexChanged(object sender, EventArgs e)
    {
         LoadComBoxHS();
        
    }
    protected void cboNam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        cls.LoadCBLopTheoGV(c.First(), cboLop, cboNam);
        //cls.LoadCbLop(cboLop,cboNam.SelectedItem.Value.ToString());
        
         LoadComBoxHS(); 
    }
    void DanhGia()
    {
        int tongdiem = int.Parse(txtDG1.Text) + int.Parse(txtDG2.Text) + int.Parse(txtDG3.Text) + int.Parse(txtDG4.Text) + int.Parse(txtDG5.Text) + int.Parse(txtDG6.Text);
        txtTongDiem.Text = tongdiem.ToString();
        if(ckSP1.Checked==false&&ckSP2.Checked==false&&ckSP3.Checked==false&&ckSP4.Checked==false&&ckSP5.Checked==false)
        {
            if (tongdiem >= 90)
            {
                rdoTot.Checked= true;
            }
            if (tongdiem >= 80 && tongdiem < 90)
            {
                rdoKha.Checked = true;

            }
            if (tongdiem >= 65 && tongdiem < 80)
            {
                rdoTrungBinh.Checked=true;           }
        }
        if (ckSP1.Checked == true || ckSP2.Checked == true || ckSP3.Checked == true || ckSP4.Checked == true || ckSP5.Checked == true)
        {
            rdoKem.Checked=true;
        }

    }
    protected void btnDanhGia_Click(object sender, EventArgs e)
    {
        bool kt = true;
        kt = kiemtratrong();
        if (kt == false) return;
        if (KiemTra() == true)
        {
            //DanhGia();
            Conduct cd = new Conduct();
            cd.ClassID = int.Parse(cboLop.SelectedItem.Value.ToString());
            //cd.Conduct1 = txtHanhKiem.Text;
            if (rdoTot.Checked == true)
            { cd.Conduct1 = "T"; }
            if (rdoKha.Checked == true)
            { cd.Conduct1 = "K"; }
            if (rdoTrungBinh.Checked == true)
            { cd.Conduct1 = "TB"; }
            if (rdoKem.Checked == true)
            { cd.Conduct1 = "K"; }
            cd.SchoolYearID = int.Parse(cboNam.SelectedItem.Value.ToString());
            cd.SemesterID = int.Parse(cboKy.SelectedItem.Value.ToString());
            cd.StudentID = cboTenHS.SelectedItem.Value.ToString();
            db.Conducts.InsertOnSubmit(cd);
            db.SubmitChanges();
            LoadGridHK();
        }
        else if(KiemTra()==false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Học sinh này đã được đánh giá!');", true);
            //txtHanhKiem.Text = "";
            txtTongDiem.Text = "";
        }
    }
    void LoadGridHK()
    {
        var c = from p in db.Conducts
                where p.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString())
                    && p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                    && p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString())
                select new { p.StudentID, p.Student.StudentName, p.Conduct1 };
        grvHanhKiem.DataSource = c;
        grvHanhKiem.DataBind();
    }
    bool KiemTra()
    {
        bool kt = true;
        var c = from p in db.Conducts
                where p.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString())
                    && p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                    && p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString())
                    && p.StudentID==cboTenHS.SelectedItem.Value.ToString()
                    select p;
        
        if (c.Count() != 0)
        {
            kt = false;
        }
        if (c.Count() == 0)
        { kt = true; }
        return kt;
    }
    void DanhGiaLai()
    {
        ckSP1.Checked = false;
        ckSP2.Checked = false;
        ckSP3.Checked = false;
        ckSP4.Checked = false;
        ckSP5.Checked = false;
        txtDG1.Text = "20";
        txtDG2.Text = "20";
        txtDG3.Text = "20";
        txtDG4.Text = "20";
        txtDG5.Text = "10";
        txtDG6.Text = "10";
        //txtHanhKiem.Text = "";
        txtTongDiem.Text = "";
    }
    protected void btnDanhGiaLai_Click(object sender, EventArgs e)
    {
        DanhGiaLai();
    }
    protected void lkbLoiVP_Click(object sender, EventArgs e)
    {
        if (KiemTraLoiVP() == true)
        {
            Response.Redirect("DanhSachLoiVP.aspx?SchoolYearID="+this.cboNam.SelectedItem.Value.ToString()
                +"&ClassID="+this.cboLop.SelectedItem.Value.ToString()+"&StudentID="+this.cboTenHS.SelectedItem.Value.ToString()
                +"&StudentName="+this.cboTenHS.SelectedItem.Text+"&SchoolYearName="+cboNam.SelectedItem.Text
                +"&ClassName="+cboLop.SelectedItem.Text);

        }
    }
    bool KiemTraLoiVP()
    {
        bool kt = true;
        lblThongBao.InnerText = "";
        if (cboTenHS.Text == "")
        {
            kt = false;
            lblThongBao.InnerText = "Lớp học này chưa có học sinh";
        }
        else
        {
            var c = from p in db.Sanctions
                    where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                    && p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString())
                    && p.StudentID == (cboTenHS.SelectedItem.Value.ToString())
                    //&& p.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString())
                    select new { p.Violation.ViolationName, p.DateViolation, p.Number, p.Subject.SubjectName };
            if (c.Count() == 0)
            {
                kt = false;
                lblThongBao.InnerText = "Học sinh này không vi phạm lỗi";
            }
            if (c.Count() != 0)
            {
                kt = true;
            }
        }
        return kt;
    }
    bool kiemtratrong()
    {
        bool kt = true;
        lblThongBao2.InnerText = "";
        if (cboTenHS.Text == "")
        {
            kt = false;
            lblThongBao2.InnerText = "Lớp này chưa có học sinh";
        }
        if (rdoKha.Checked == false && rdoTot.Checked == false && rdoKem.Checked == false && rdoTrungBinh.Checked == false)
        {
            kt = false;
            lblThongBao2.InnerText = "Bạn chưa đánh giá hạnh kiểm";
        }
        return kt;
        
    }
    protected void btnTongDiem_Click(object sender, EventArgs e)
    {
        DanhGia();
    }
    protected void grvHanhKiem_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
