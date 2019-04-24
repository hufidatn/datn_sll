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

public partial class GiaoDien_PhanLop : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnXoa.Visible = false;
            LoadComboxNam(cboNamHoc);
            LoadCbLop(cboTenLop);
            cls.LoadCBBan(cboBan);
            LoadComboboxGVCN();
            LoadGrid();
            LamMoi();
        }
    }
    void LoadCbLop(AjaxControlToolkit.ComboBox cboLop)
    {
        var c = from p in db.Classes select p;
        cboLop.DataTextField = "ClassName";
        cboLop.DataValueField = "ClassID";
        cboLop.DataSource = c;
        cboLop.DataBind();
    }
    void LoadComboxNam(AjaxControlToolkit.ComboBox cboNam)
    {
        var c = from p in db.SchoolYears select p;
        cboNam.DataTextField = "SchoolYearName";
        cboNam.DataValueField = "SchoolYearID";
        cboNam.DataSource = c;
        cboNam.DataBind();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool kt = true;
        kt = kiemtraMatrung();
        if (kt == false) return;
        kt = kiemtragv();
        if (kt == false) return;
        ClassDepartment cd = new ClassDepartment();
        cd.SchoolYearID =int.Parse( cboNamHoc.SelectedItem.Value.ToString());
        cd.DepartmentID =int.Parse( cboBan.SelectedItem.Value.ToString());
        cd.ClassID =int.Parse( cboTenLop.SelectedItem.Value.ToString());
        cd.TeacherID = cboGVCN.SelectedItem.Value.ToString();
        db.ClassDepartments.InsertOnSubmit(cd);
        db.SubmitChanges();
        LoadGrid();
        //XoaDk();//Download source code tại Sharecode.vn
        LamMoi();
    }
    void LoadGrid()
    {
        var t = from p in db.ClassDepartments select new { p.Department.DepartmentName,p.Class.ClassName,p.SchoolYear.SchoolYearName,p.ClassID,p.SchoolYearID,p.Teacher.TeacherName};
        grvPLTB.DataSource = t;
        grvPLTB.DataBind();
    }
    void XoaDk()
    {
        cboTenLop.Text = "";
        cboNamHoc.Text = "";
        cboBan.Text = "";
    }
 
     protected void  grvPLTB_SelectedIndexChanged(object sender, EventArgs e)
     {
         GridViewRow gr = grvPLTB.SelectedRow;
         Label Nam = (Label)gr.FindControl("lblMaNam");
         Label Lop = (Label)gr.FindControl("lblMaLop");
         var p = (from t in db.ClassDepartments where t.ClassID == int.Parse(Lop.Text) && t.SchoolYearID==int.Parse(Nam.Text) select t).First();
         cboTenLop.SelectedValue = p.ClassID.ToString();
         cboNamHoc.SelectedValue = p.SchoolYearID.ToString();
         cboBan.SelectedValue = p.DepartmentID.ToString();
         cboGVCN.SelectedValue = p.TeacherID.ToString();
         btnSua.Enabled = true ;
         btnXoa.Enabled = true;
         btnThem.Enabled = false;
     }

     protected void btnSua_Click(object sender, EventArgs e)
     {
         bool kt = true;
         //kt = kiemtraMatrung();
         //if (kt == false) return;
         kt = kiemtragv();
         if (kt == false) return;
         ClassDepartment cd = db.ClassDepartments.SingleOrDefault(p => p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString()));
         //cd.SchoolYearID =int.Parse( cboNamHoc.Text);
         cd.DepartmentID =int.Parse( cboBan.Text);
         //cd.ClassID =int.Parse( cboTenLop.Text);
         cd.TeacherID = cboGVCN.SelectedItem.Value.ToString();
         db.SubmitChanges();
         LoadGrid();
         LamMoi();
     }
     protected void btnXoa_Click(object sender, EventArgs e)
     {
         ClassDepartment cd = db.ClassDepartments.SingleOrDefault(p => p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString()));
         db.ClassDepartments.DeleteOnSubmit(cd);
         db.SubmitChanges();
         LamMoi();
     }
     void LoadComboboxGVCN()
     {
         var c = from p in db.Users_UserGroups where p.UserGroupID==2 select new { p.TeacherID, p.Teacher.TeacherName };
         cboGVCN.DataTextField = "TeacherName";
         cboGVCN.DataValueField = "TeacherID";
         cboGVCN.DataSource = c;
         cboGVCN.DataBind();
     }
     bool kiemtragv()
     {
         bool kt = true;
         lblThongBao.InnerText = "";
         var c = from p in db.ClassDepartments
                 where p.TeacherID == cboGVCN.SelectedItem.Value.ToString()&&p.ClassID==int.Parse(cboTenLop.SelectedItem.Value.ToString())
                 && p.SchoolYearID==int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                 select p.TeacherID;
         if (c.Count() != 0)
         {
             kt = false;
             lblThongBao.InnerText = "Giáo viên này đã được phân công chủ nhiệm";
         }
         return kt;
         
 
     }
     bool kiemtraMatrung()
     {
         bool kt = true;
         lblThongBao.InnerText = "";
         var c = from p in db.ClassDepartments
                 where p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                 select new { p.SchoolYearID,p.ClassID};
         if (c.Count() != 0)
         {
             kt = false;
             lblThongBao.InnerText = "Lớp học này đã tồn tại";
         }
         return kt;


     }
     void LamMoi()
     {
         btnThem.Enabled = true ;
         btnXoa.Enabled = false ;
         btnSua.Enabled = false;
     }
}
