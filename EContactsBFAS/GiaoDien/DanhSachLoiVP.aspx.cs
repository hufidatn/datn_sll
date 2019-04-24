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

public partial class GiaoDien_DanhSachLoiVP : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        string manam=Request.QueryString["SchoolYearID"];
        string tennam = Request.QueryString["SchoolYearName"];
        string malop = Request.QueryString["ClassID"];
        string tenlop = Request.QueryString["ClassName"];
        string mahs = Request.QueryString["StudentID"];
        string tenhs = Request.QueryString["StudentName"];
        if (!IsPostBack)
        {
            lblMa.Text = mahs;
            lblTenHS.Text = tenhs;
            lblNamHoc.Text = tennam;
            lblLopHoc.Text = tenlop;
            
            var c = from p in db.Sanctions
                    where p.SchoolYearID == int.Parse(manam) &&
                   // p.SemesterID == int.Parse(maky) &&
                    p.ClassID == int.Parse(malop) &&
                    p.StudentID == mahs
                    select new { p.Violation.ViolationName, p.DateViolation, p.Number, p.Subject.SubjectName };
            grvLoiVP.DataSource = c;
            grvLoiVP.DataBind();
                 
        }
    }
}
