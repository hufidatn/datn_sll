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

public partial class GiaoDien_PhieuDiemCuaTungHocSinh : System.Web.UI.Page
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
            cls.LoadCBNamTheoGV(c.First(),cboNienKhoa);
            cls.LoadCBLopTheoGV(c.First(), cboLopHoc, cboNienKhoa);
            //cls.LoadComboxNam(cboNienKhoa);
            //cls.LoadCbLop(cboLopHoc, cboNienKhoa.SelectedItem.Value.ToString());
            cls.LoadComBoxHS(cboTenHS, cboNienKhoa.SelectedItem.Value.ToString(), cboLopHoc.SelectedItem.Value.ToString());

 
        }

    }
    protected void cboNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        cls.LoadCBLopTheoGV(c.First(), cboLopHoc, cboNienKhoa);
        //cls.LoadCbLop(cboLopHoc, cboNienKhoa.SelectedItem.Value.ToString());
        cls.LoadComBoxHS(cboTenHS, cboNienKhoa.SelectedItem.Value.ToString(), cboLopHoc.SelectedItem.Value.ToString());
    }
    protected void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls.LoadComBoxHS(cboTenHS, cboNienKhoa.SelectedItem.Value.ToString(), cboLopHoc.SelectedItem.Value.ToString());
    }
    void LoadgridHS()
    {
        var c = from p in db.ClassStudents
                where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString())
                select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.Address, p.Student.DateOfBirth };
        grvPhieuDiem.DataSource = c;
        grvPhieuDiem.DataBind();
    }

    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        LoadgridHS();
    }
}
