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

public partial class GiaoDien_PhanCongGiangDay : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LamMoi();
            LoadNam();
            LoadLop();
            LoadcbKy();
            //cls.LoadCbMon(cboMon);
            LoadCBMon();
            LoadGV();
            LoadGridView();
            //btnHuy.Enabled = false;
            //cboMon.Enabled = true;
            //cboNam.Enabled = true;
            //cboKy.Enabled = true;
            //cboLop.Enabled = true;
            //cboGV.Enabled = true;
          
        }
    }
   
    protected void btnPhanCong_Click(object sender, EventArgs e)
    {
        bool kt = true;
        kt = kiemtratrung();
        if (kt == false) return;
        int t = db.InsertTeacherSujects(cboGV.SelectedValue.ToString()
                    ,int.Parse(cboMon.SelectedValue.ToString())
                    ,int.Parse(cboKy.SelectedValue.ToString())
                    ,int.Parse(cboNam.SelectedValue.ToString()), 
                     int.Parse(cboLop.SelectedValue.ToString()));
        if (t == 1)
        {
            lblThongBao.Text = "Bạn chọn thiếu thông tin";
        }
        else if (t == 2)
        {
            lblThongBao.Text = "GV này đang giảng dạy hoặc môn học đã có GV dạy";
        }
        else
        {
            LoadGridView();
            lblThongBao.Text = "Bạn vừa phân công GV"+" "+cboGV.SelectedItem.Text+" "+"dạy môn"+" "+cboMon.SelectedItem.Text+" "+"lớp"+" "+cboLop.SelectedItem.Text+" "+"tại kỳ"+" "+cboKy.SelectedItem.Text;
        }
        
    }
    void LoadNam()
    {
        var c = from i in
                    (from p in db.ClassDepartments select new { p.SchoolYearID, p.SchoolYear.SchoolYearName })
                group i by new { i.SchoolYearID, i.SchoolYearName } into gr
                select new { gr.Key.SchoolYearID, gr.Key.SchoolYearName };
        //var c = from p in db.SchoolYears select new { p.SchoolYearID, p.SchoolYearName };
        if (c.Count() != 0)
        {
            cboNam.DataValueField = "SchoolYearID";
            cboNam.DataTextField = "SchoolYearName";
            //cboNam.DataSource = db.NamMoi();
            cboNam.DataSource = c;
            cboNam.DataBind();
        }
    }
    void LoadcbKy()
    {
        var c = from t in db.Semesters select t;
        if (c.Count() != 0)
        {
            cboKy.DataTextField = "SemesterName";
            cboKy.DataValueField = "SemesterID";
            cboKy.DataSource = c;
            cboKy.DataBind();
        }
    }
    void LoadLop()
    {
        var c = from p in db.ClassDepartments
                where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                select new {p.ClassID,p.Class.ClassName };
        if (c.Count() != 0)
        {
            cboLop.DataTextField = "ClassName";
            cboLop.DataValueField = "ClassID";
            //cboLop.DataSource = db.PhanMon();
            cboLop.DataSource = c;
            cboLop.DataBind();
        }
    }
    void LoadCBMon()
    {
        var maban = from p in db.ClassDepartments
                    where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString())
                    && p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                    select p.DepartmentID;
        if(maban.Count()!=0)
        {
        //Response.Write(maban.ToString());
        var mon = from p1 in db.DepartmentSubjects
                  where p1.DepartmentID == maban.First()
                  select new { p1.SubjectID, p1.Subject.SubjectName };
        if (mon.Count() != 0)
        {
            cboMon.DataTextField = "SubjectName";
            cboMon.DataValueField = "SubjectID";
            cboMon.DataSource = mon;
            cboMon.DataBind();
        }
        }
    }
    void LoadGV()
    {
        var c = from t in db.Users_UserGroups where t.UserGroupID==3 &&
                t.SchoolYearID==int.Parse(cboNam.SelectedItem.Value.ToString())
                select new {t.Teacher.TeacherName,t.TeacherID };
        if (c.Count() != 0)
        {
            cboGV.DataTextField = "TeacherName";
            cboGV.DataValueField = "TeacherID";
            cboGV.DataSource = c;
            cboGV.DataBind();
        }
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        GridViewRow row = grvChuyenMon.SelectedRow;
        Label MaNam = (Label)row.FindControl("lblMaNam");
        Label MaKy = (Label)row.FindControl("lblMaKy");
        Label MaLop = (Label)row.FindControl("lblMaLop");
        Label MaMon = (Label)row.FindControl("lblMaMon");
        Label MaGV = (Label)row.FindControl("lblMaGV");
        Label Nam=(Label)row.FindControl("lblNam");
        Label Lop = (Label)row.FindControl("lblLop") ;
        Label Ky = (Label)row.FindControl("lblKy");
        Label GV = (Label)row.FindControl("lblGV");
        Label Mon = (Label)row.FindControl("lblMon"); ;
        TeacherSubject ts = db.TeacherSubjects.SingleOrDefault(p => p.SchoolYearID == int.Parse(MaNam.Text)
       && p.SemesterID == int.Parse(MaKy.Text) && p.ClassID == int.Parse(MaLop.Text)
       && p.TeacherID == MaGV.Text && p.SubjectID == int.Parse(MaMon.Text));
        db.TeacherSubjects.DeleteOnSubmit(ts);
        db.SubmitChanges();
        btnPhanCong.Enabled = true;
        btnHuy.Enabled = false;
        cboMon.Enabled = true;
        cboNam.Enabled = true;
        cboKy.Enabled = true;
        cboLop.Enabled = true;
        cboGV.Enabled = true; 
        lblThongBao.Text = "Bạn vừa hủy phân công với giáo viên"+" "+GV.Text+" "+"dạy môn"+" "+Mon.Text+" "+"lớp"+" "+Lop.Text+" "+"tại kỳ"+" "+Ky.Text;
    }
    void LoadGridView()
    {
        var c = from p in db.TeacherSubjects
                where p.SchoolYearID==int.Parse(cboNam.SelectedItem.Value.ToString())
                
                select new
                {
                    p.SchoolYearID,
                    p.SemesterID,
                    p.SubjectID,
                    p.TeacherID,
                    p.ClassID,
                    p.Class.ClassName,
                    p.SchoolYear.SchoolYearName,
                    p.Semester.SemesterName,
                    p.Subject.SubjectName,
                    p.Teacher.TeacherName
                };
        //var c = from p in db.TeacherSubjects where p.SchoolYear.BeginDate<=DateTime.Today &&p.SchoolYear.EndDate>DateTime.Today
        //        select new {p.SchoolYearID,p.SemesterID,p.SubjectID
        //        ,p.TeacherID,p.ClassID,p.Class.ClassName,
        //         p.SchoolYear.SchoolYearName,p.Semester.SemesterName,
        //         p.Subject.SubjectName,p.Teacher.TeacherName };
        grvChuyenMon.DataSource = c;
        grvChuyenMon.DataBind();
    }

    protected void grvChuyenMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            GridViewRow row = grvChuyenMon.SelectedRow;
            Label MaNam = (Label)row.FindControl("lblMaNam");
            Label MaKy = (Label)row.FindControl("lblMaKy");
            Label MaLop = (Label)row.FindControl("lblMaLop");
            Label MaMon = (Label)row.FindControl("lblMaMon");
            Label MaGV = (Label)row.FindControl("lblMaGV");
            Label Nam = (Label)row.FindControl("lblNam");
            Label Ky = (Label)row.FindControl("lblKy");
            //var c = (from t in db.TeacherSubjects
            //         where t.SchoolYearID == int.Parse(MaNam.Text)
            //             && t.SemesterID == int.Parse(MaKy.Text) && t.SubjectID == int.Parse(MaMon.Text)
            //             && t.TeacherID == MaGV.Text
            //         select new {t.SchoolYear.SchoolYearName,t.Class.ClassName,t.Semester.SemesterName,t.Teacher.TeacherName,t.Subject.SubjectName}).First();
            btnHuy.Enabled = true;
            btnSua.Enabled = true;
            btnPhanCong.Enabled = false;
            //cboGV.Enabled = false;
            cboNam.Enabled = false;
            cboLop.Enabled = false;
            cboKy.Enabled = false;
            cboMon.Enabled = false;
            cboKy.SelectedValue = MaKy.Text;
            cboLop.SelectedValue = MaLop.Text;
            cboNam.SelectedValue = MaNam.Text;
            cboGV.SelectedValue = MaGV.Text;
            cboMon.SelectedValue = MaMon.Text;
        
    }
   bool  kiemtratrung()
    {
        bool kt = true;
        var c = from p in db.TeacherSubjects
                where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                    && p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                    p.SubjectID == int.Parse(cboMon.SelectedItem.Value.ToString())&&
                    p.SemesterID==int.Parse(cboKy.SelectedItem.Value.ToString())&&
                    p.TeacherID==cboGV.SelectedItem.Value.ToString()
                select p;
        if (c.Count() != 0)
        {
            kt = false;
            lblThongBao.Text = "Môn học này đã được phân công giáo viên!";
        }
        return kt;
    }

   protected void cboNam_SelectedIndexChanged(object sender, EventArgs e)
   {
       lblThongBao.Text = "";
       LoadLop();
       LoadCBMon();
       LoadGridView();
   }
   protected void cboLop_SelectedIndexChanged(object sender, EventArgs e)
   {
       lblThongBao.Text = "";
       LoadCBMon();
       LoadGridView();
   }
   void LamMoi()
   {
       cboGV.Enabled = true;
       cboKy.Enabled = true;
       cboLop.Enabled = true;
       cboMon.Enabled = true;
       cboNam.Enabled = true;
       btnHuy.Enabled = false;
       btnSua.Enabled = false;
       btnPhanCong.Enabled = true;
   }
   protected void btnSua_Click(object sender, EventArgs e)
   {
       TeacherSubject ts = db.TeacherSubjects.SingleOrDefault(p=>p.ClassID==int.Parse(cboLop.SelectedItem.Value.ToString())
           &&p.SchoolYearID==int.Parse(cboNam.SelectedItem.Value.ToString())
           &&p.SemesterID==int.Parse(cboKy.SelectedItem.Value.ToString())
           &&p.SubjectID==int.Parse(cboMon.SelectedItem.Value.ToString()));
       ts.TeacherID = cboGV.SelectedItem.Value.ToString();
       db.SubmitChanges();
       LoadGridView();
       LamMoi();
           
   }
   protected void btnMoi_Click(object sender, EventArgs e)
   {
       LamMoi();
   }
   protected void grvChuyenMon_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
       grvChuyenMon.PageIndex = e.NewPageIndex;
       this.LoadGridView();
   }
}
