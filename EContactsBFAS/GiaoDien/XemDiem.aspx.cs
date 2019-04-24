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

public partial class GiaoDien_XemDiem : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    string manam;
    string malop;
    string tenhs;
    string mahs;
    protected void Page_Load(object sender, EventArgs e)
    {
        manam = Request.QueryString["SchoolYearID"] ;
        malop=Request.QueryString["ClassID"];
        tenhs = Request.QueryString["StudentName"];
        mahs=Request.QueryString["StudentID"];
        
        if (!IsPostBack)
        {
            cboLopHoc.SelectedValue = malop;
            cboNienKhoa.SelectedValue = manam;
            txtTenHS.Text = tenhs;
            txtMaHS.Text = mahs;
            cls.LoadComboxNam(cboNienKhoa);
            cls.LoadCbLop(cboLopHoc,cboNienKhoa.SelectedItem.Value.ToString());
            LoadHS();
            txtMaHS.Text = "";
            txtTenHS.Text = "";
            //LoadCBTenHS();
            //Download source code tại Sharecode.vn
        }
    }
    void LoadHS()
    {
        if (txtMaHS.Text == "" && txtTenHS.Text == "")
        {
       
        var c = from p in db.ClassStudents
                where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString())
                select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.Address,p.Student.DateOfBirth };
        grvXemDiem.DataSource = c;
        grvXemDiem.DataBind();
        }
        else
        {
            if (txtMaHS.Text != "" && txtTenHS.Text == "")
            {
                var c1 = from p in db.ClassStudents
                         where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString())
                         && p.StudentID==txtMaHS.Text
                         select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.Address, p.Student.DateOfBirth };
                grvXemDiem.DataSource = c1;
                grvXemDiem.DataBind();
            }
            if (txtMaHS.Text == "" && txtTenHS.Text != "")
            {
                var c2 = from p in db.ClassStudents
                         where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString())
                         && p.Student.StudentName == txtTenHS.Text
                         select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.Address, p.Student.DateOfBirth };
                grvXemDiem.DataSource = c2;
                grvXemDiem.DataBind();
            }
            if (txtTenHS.Text != "" && txtMaHS.Text != "")
            {
                var c3 = from p in db.ClassStudents
                         where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString())
                         && p.StudentID == txtMaHS.Text &&p.Student.StudentName==txtTenHS.Text
                         select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.Address, p.Student.DateOfBirth };
                grvXemDiem.DataSource = c3;
                grvXemDiem.DataBind();
            }
        }
    }
    void LoadHS1()
    {
        
            var c = from p in db.ClassStudents
                    where p.ClassID == int.Parse(malop) && p.SchoolYearID == int.Parse(manam) && p.Student.StudentName == tenhs
                    select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.Address, p.Student.DateOfBirth };
            grvXemDiem.DataSource = c;
            grvXemDiem.DataBind();
        
    }
    protected void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadCBTenHS();
    }
    //void LoadCBTenHS()
    //{

    //    var c = from p in db.ClassStudents
    //            where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString())
    //            group p by p.Student.StudentName into g
    //            select g.Key;
    //    foreach (var con in c)
    //    {
    //        cboTenHS.Items.Add(con);
        //}
                
    //}
    protected void btnTim_Click(object sender, EventArgs e)
    {
        if (cboNienKhoa.Text != "" && cboLopHoc.Text != "")
        {
            LoadHS();
            txtTenHS.Text ="";
            txtMaHS.Text = "";
        }
    }
    protected void cboTenHS_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var c = from p in db.ClassStudents
        //        where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString()) && p.Student.StudentName == cboTenHS.SelectedItem.Text
        //        select new { p.StudentID,p.Student.StudentName,p.Student.Gender,p.Student.DateOfBirth,p.Student.Address};
        //grvXemDiem.DataSource = c;
        //grvXemDiem.DataBind();
    }
    protected void cboTenHS_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void grvXemDiem_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow row = grvXemDiem.SelectedRow;
        //Label lblMaHS = (Label)row.FindControl("lblMaHS");
        //Response.Redirect("DiemChiTiet.aspx?SchoolYearID=" + this.cboNienKhoa.SelectedItem.Value.ToString() + "&ClassID=" + this.cboLopHoc.SelectedItem.Value.ToString()+"&StudentID="+lblMaHS.Text );
    }
    protected void txtTenHS_TextChanged(object sender, EventArgs e)
    {
        var c = from p in db.ClassStudents
                where p.ClassID == int.Parse(cboLopHoc.SelectedItem.Value.ToString()) && p.SchoolYearID == int.Parse(cboNienKhoa.SelectedItem.Value.ToString()) && p.Student.StudentName == txtTenHS.Text
                select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.DateOfBirth, p.Student.Address };
        grvXemDiem.DataSource = c;
        grvXemDiem.DataBind();
    }
    protected void cboNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls.LoadCbLop(cboLopHoc, cboNienKhoa.SelectedItem.Value.ToString());
        //LoadHS();
    }
    protected void grvXemDiem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvXemDiem.PageIndex = e.NewPageIndex;
        this.LoadHS();
    }
}
