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

public partial class GiaoDien_PhanLopChoHS : System.Web.UI.Page
{
    clsThaoTac cls = new clsThaoTac();
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadKhoiMoi();
            LoadNamCu();
            LoadNamMoi();
            cls.LoadCbKhoi(cboKhoi1);
            // LoadGVCNMoi();
        }
    }
    /// <summary>
    /// Chọn rdoHSMoi Load HS mới lên gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoHocSinhMoi_CheckedChanged(object sender, EventArgs e)
    {

        //cboKhoi1.Enabled = false;
        cboNamHoc.Enabled = false;
        cboLop.Enabled = false;
        cboKhoi.Enabled = false;
        grvHocSinh.DataSource = db.dbo_funcStudent();
        grvHocSinh.DataBind();
        // cls.LoadCbKhoi(cboKhoi1);
    }
    /// <summary>
    /// chọn rdoHocSinh1011Cu load hs lớp 10 hoặc 11 lên 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoHocSinh1011Cu_CheckedChanged(object sender, EventArgs e)
    {
        cboKhoi.Enabled = true;
        cboLop.Enabled = true;
        cboNamHoc.Enabled = true;
        LoadcbKhoiHS1011();
        LoadNamCu();
        // LoadKhoiMoi();
    }
    void LoadNamCu()
    {
        cboNamHoc.DataTextField = "SchoolYearName";
        cboNamHoc.DataValueField = "SchoolYearID";
        cboNamHoc.DataSource = db.NamCu();
        cboNamHoc.DataBind();
    }
    void LoadLopTheoKhoi()
    {
        cboLop.DataTextField = "ClassName";
        cboLop.DataValueField = "ClassID";
        cboLop.DataSource = db.LopHS1011Cu(int.Parse(cboKhoi.SelectedValue.ToString())
        , int.Parse(cboNamHoc.SelectedValue.ToString()));

        cboLop.DataBind();
    }
    protected void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        // cboLop.DataSource= "";
    }
    protected void cboKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLopTheoKhoi();
    }
    protected void cboLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvHocSinh.DataSource = db.LoadGridViewCu(
           int.Parse(cboNamHoc.SelectedValue.ToString())
          , int.Parse(cboKhoi.SelectedValue.ToString())
          , int.Parse(cboLop.SelectedValue.ToString()));
        grvHocSinh.DataBind();

    }
    protected void btnTimTheoTen_Click(object sender, EventArgs e)
    {
        if (rdoHocSinhMoi.Checked == true)
        {
            var c1 = from p in db.dbo_funcStudent()
                     where p.StudentName == txtTim.Text
                     select new { p.StudentID, p.StudentName };
            grvHocSinh.DataSource = c1;
            grvHocSinh.DataBind();
        }
        if (rdoHocSinh1011Cu.Checked == true)
        {

            var t3 = from p in db.ClassStudents
                     where p.Class.GradeSchoolID == int.Parse(cboKhoi.SelectedValue.ToString())
                     && p.ClassID == int.Parse(cboLop.SelectedValue.ToString())
                     && p.SchoolYearID == int.Parse(cboNamHoc.SelectedValue.ToString())
                     && p.Student.StudentName == txtTim.Text
                     select new { p.StudentID, p.Student.StudentName };
            grvHocSinh.DataSource = t3;
            grvHocSinh.DataBind();

        }
    }
    protected void btnTimTheoMa_Click(object sender, EventArgs e)
    {

        if (rdoHocSinhMoi.Checked == true)
        {
            var c2 = from p in db.dbo_funcStudent()
                     where p.StudentID == txtTim.Text
                     select new { p.StudentID, p.StudentName };
            grvHocSinh.DataSource = c2;
            grvHocSinh.DataBind();
        }
        if (rdoHocSinh1011Cu.Checked == true)
        {
            var t3 = from p in db.ClassStudents
                     where p.ClassID == int.Parse(cboLop.SelectedValue.ToString())
                     && p.Class.GradeSchoolID == int.Parse(cboKhoi.SelectedValue.ToString()
                     ) && p.SchoolYearID == int.Parse(cboNamHoc.SelectedValue.ToString())
                     && p.StudentID == txtTim.Text
                     select new { p.StudentID, p.Student.StudentName };
            grvHocSinh.DataSource = t3;
            grvHocSinh.DataBind();

        }
    }
    void LoadcbKhoiHS1011()
    {
        var c = from p in db.GradeSchools
                where p.GradeSchoolID == 1 || p.GradeSchoolID == 2
                select new { p.GradeSchoolID, p.GradeSchoolName };
        cboKhoi.DataTextField = "GradeSchoolName";
        cboKhoi.DataValueField = "GradeSchoolID";
        cboKhoi.DataSource = c;
        cboKhoi.DataBind();
    }
    protected void btnChuyen_Click(object sender, EventArgs e)
    {
        if (grvHocSinh.Rows.Count <= 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Chưa có học sinh nào để chuyển');", true);
        }
        else
        {
            for (int i = 0; i < grvHocSinh.Rows.Count; i++)
            {
                        ClassStudent cl = new ClassStudent();
                        Label Ma = (Label)grvHocSinh.Rows[i].Cells[1].FindControl("lblMaHS");
                        CheckBox ck = (CheckBox)grvHocSinh.Rows[i].Cells[0].FindControl("ckChonHS");
                        cl = new ClassStudent();
                        cl.ClassID = int.Parse(cboLopMoi.SelectedValue.ToString());
                        cl.SchoolYearID = int.Parse(cboNam1.SelectedValue.ToString());

                        cl.StudentID = Ma.Text;
                        db.ClassStudents.InsertOnSubmit(cl);
                        db.SubmitChanges();
                }
            }
               
            ckAll.Checked = false;
            LoadLenGridMoi();
            if (rdoHocSinh1011Cu.Checked == true)
            {
             grvHocSinh.DataSource = db.LoadGridViewCu(
             int.Parse(cboNamHoc.SelectedValue.ToString())
            , int.Parse(cboKhoi.SelectedValue.ToString())
            , int.Parse(cboLop.SelectedValue.ToString())); ;
              grvHocSinh.DataBind();
            }
            if (rdoHocSinhMoi.Checked == true)
            {
                grvHocSinh.DataSource = db.dbo_funcStudent();
                grvHocSinh.DataBind();
            }
            rdoHocSinh1011Cu.Checked = false;
            rdoHocSinhMoi.Checked = false;
        }
    //}
    //kiểm tra khi chọn 1 bản ghi
    bool Checkone()
    {
        bool Ck = false;
        for (int i = 0; i < grvHocSinh.Rows.Count; i++)
        {
            CheckBox ck1 = (CheckBox)grvHocSinh.Rows[i].Cells[0].FindControl("ckChonHS");
            if (ck1.Checked == true)
            {
                Ck = true; break;
            }
        }
        return Ck;
    }
    //khi load cả grid vào csdl
    void CheckTatCa()
    {
        for (int i = 0; i < grvHocSinh.Rows.Count; i++)
        {
            if (i >= 5)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ckAll.Checked == true)
                    {
                        CheckBox ck = (CheckBox)grvHocSinh.Rows[j].Cells[0].FindControl("ckChonHS");
                        ck.Checked = true;
                    }
                    else
                    {
                        CheckBox ck = (CheckBox)grvHocSinh.Rows[j].Cells[0].FindControl("ckChonHS");
                        ck.Checked = false;
                    }
                }
            }
            else if (grvHocSinh.Rows.Count>0&&grvHocSinh.Rows.Count<5)
            {
                for (int k = 0; k < grvHocSinh.Rows.Count; k++)
                {
                    if (ckAll.Checked == true)
                    {
                        CheckBox ck = (CheckBox)grvHocSinh.Rows[k].Cells[0].FindControl("ckChonHS");
                        ck.Checked = true;
                    }
                    else 
                    {
                        CheckBox ck = (CheckBox)grvHocSinh.Rows[k].Cells[0].FindControl("ckChonHS");
                        ck.Checked = false;
                    }
                }
            }
        }
    }
    void LoadLenGridMoi()
    {
            var c = from p in db.ClassStudents
                    where
                    p.SchoolYearID == int.Parse(cboNam1.SelectedValue.ToString())
                    && p.ClassID == int.Parse(cboLopMoi.SelectedValue.ToString())
                    && p.Class.GradeSchoolID == int.Parse(cboKhoi1.SelectedValue.ToString())
                    select new { p.StudentID, p.Student.StudentName};
                GrvHSChuyen.DataSource = c;
                GrvHSChuyen.DataBind();

    }
    void LoadNamMoi()
    {
        cboNam1.DataTextField = "SchoolYearName";
        cboNam1.DataValueField = "SchoolYearID";
        cboNam1.DataSource = db.NamMoi();
        cboNam1.DataBind();
    }

    void LoadLopMoi()
    {
        cboLopMoi.DataTextField = "ClassName";
        cboLopMoi.DataValueField = "ClassID";
        cboLopMoi.DataSource = db.LoadLop(int.Parse(cboKhoi1.SelectedValue.ToString()));
        cboLopMoi.DataBind();
    }
    void LoadKhoiMoi()
    {
        var c = from p in db.GradeSchools
                where p.GradeSchoolID == 2 || p.GradeSchoolID == 3
                select new { p.GradeSchoolID, p.GradeSchoolName };
        cboKhoi1.DataTextField = "GradeSchoolName";
        cboKhoi1.DataValueField = "GradeSchoolID";
        cboKhoi1.DataSource = c;
    }

    protected void cboKhoi1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadLopMoi();
    }
    protected void rdLopCu_CheckedChanged(object sender, EventArgs e)
    {
        cboLopMoi.DataTextField = "ClassName";
        cboLopMoi.DataValueField = "ClassID";
        cboLopMoi.DataSource = db.LopcoHSnhohon50
            (int.Parse(cboKhoi1.SelectedValue.ToString())
            , int.Parse(cboNam1.SelectedValue.ToString()));
        cboLopMoi.DataBind();
        // LaySiSo(lblSL.Text);
    }
    int LaySiSo(int Ma)
    {
        int dem = (from p in db.ClassStudents
                   where p.ClassID == int.Parse(cboLopMoi.SelectedValue.ToString())
                   select p.StudentID).Count();
        return dem;
    }
    int DemHSCu()
    {
        int dem = 0;
        for (int i = 0; i < grvHocSinh.Rows.Count; i++)
        {
            CheckBox ck = (CheckBox)grvHocSinh.Rows[i].FindControl("ckChonHS");
            Label ma = (Label)grvHocSinh.Rows[i].FindControl("lblMaHS");
            if (ck.Checked == true)
            {
                dem = (from p in db.ClassStudents where p.StudentID == ma.Text select p.StudentID).Count();

            }
        }
        return dem;

    }
    void KiemTra()
    {
        if (rdLopCu.Checked == true)
        {
            if (LaySiSo(int.Parse(lblSL.Text)) + DemHSCu() > 50)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Lớp bạn chọn đã đủ số lượng,bạn hãy chọn lớp khác');", true);
            }
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
                ClassStudent cl=db.ClassStudents.SingleOrDefault(p=>p.ClassID==int.Parse(cboLopMoi.SelectedValue.ToString())
                                                        && p.SchoolYearID==int.Parse(cboNam1.SelectedValue.ToString())
                                                        && p.Class.GradeSchoolID==int.Parse(cboKhoi1.SelectedValue.ToString()));
                db.ClassStudents.DeleteOnSubmit(cl);
                db.SubmitChanges();
       
                   LoadLenGridMoi();
                    if (rdoHocSinhMoi.Checked == true)
                    {
                        grvHocSinh.DataSource = db.dbo_funcStudent();
                        grvHocSinh.DataBind();
                    }
                    if (rdoHocSinh1011Cu.Checked == true)
                    {
                        grvHocSinh.DataSource = db.LoadGridViewCu(
                                        int.Parse(cboNamHoc.SelectedValue.ToString())
                                       , int.Parse(cboKhoi.SelectedValue.ToString())
                                        , int.Parse(cboLop.SelectedValue.ToString())); ;
                        grvHocSinh.DataBind();
                    }
                    if (rdoHocSinhMoi.Checked == true)
                    {
                        grvHocSinh.DataSource = db.dbo_funcStudent();
                        grvHocSinh.DataBind();
                    }
                    if (rdoHocSinh1011Cu.Checked == true)
                    {
                        grvHocSinh.DataSource = db.LoadGridViewCu(
                        int.Parse(cboNamHoc.SelectedValue.ToString())
                       , int.Parse(cboKhoi.SelectedValue.ToString())
                       , int.Parse(cboLop.SelectedValue.ToString())); ;
                        grvHocSinh.DataBind();    
                    }
        }
    protected void rdLopMoi_CheckedChanged(object sender, EventArgs e)
    {
        LoadLopMoi();
    }
    protected void ckAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckTatCa();
    }
    protected void Xoa_CheckedChanged(object sender, EventArgs e)
    {
        Xoatat();
    }
    void Xoatat()
    {
        for (int i = 0; i < GrvHSChuyen.Rows.Count; i++)
        {
            if (Xoa.Checked == true)
            {
                CheckBox ck = (CheckBox)GrvHSChuyen.Rows[i].Cells[0].FindControl("ChonHS");
                ck.Checked = true;
            }
            else
            {
                CheckBox ck = (CheckBox)GrvHSChuyen.Rows[i].Cells[0].FindControl("ChonHS");
                ck.Checked = false;
            }
        }
    }
}
