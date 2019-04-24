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

public partial class GiaoDien_QuanLyKhoit : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Loadgrid();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKhoi.Enabled = false;

        }

    }
    void Them()
    {
        GradeSchool gr = new GradeSchool();
        gr.GradeSchoolID = int.Parse(txtMaKhoi.Text);
        gr.GradeSchoolName = txtTenKhoi.Text;
        db.GradeSchools.InsertOnSubmit(gr);
        db.SubmitChanges();
        Loadgrid();
    }
    void refresh()
    {
        txtTenKhoi.Text = "";
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnThem.Enabled = true;;
        MaTuTang();
    }
    void MaTuTang()
    {
        var c = from p in db.GradeSchools select p.GradeSchoolID;
        if (c.Count() == 0)
        {
            txtMaKhoi.Text = "1";
        }
        else
        {
            int max = 0;

            foreach (var con in c)
            {
                max = con + 1;

            }
            //Download source code tại Sharecode.vn
            txtMaKhoi.Text = max.ToString();
        }
    }
    void Loadgrid()
    {
        var c = from p in db.GradeSchools select p;
        grvKhoi.DataSource = c;
        grvKhoi.DataBind();
        MaTuTang();

    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();;
        refresh();

    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        GradeSchool gr = db.GradeSchools.SingleOrDefault(p=>p.GradeSchoolID==int.Parse(txtMaKhoi.Text));
        gr.GradeSchoolName = txtTenKhoi.Text;
        db.SubmitChanges();
        Loadgrid();
        refresh();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        GradeSchool gr = db.GradeSchools.SingleOrDefault(p => p.GradeSchoolID == int.Parse(txtMaKhoi.Text));
        db.GradeSchools.DeleteOnSubmit(gr);
        db.SubmitChanges();
        Loadgrid();
        refresh();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        refresh();
    }
    protected void grvKhoi_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvKhoi.SelectedRow;
        Label lbma = (Label)row.FindControl("lblMa");
        var c=(from p in db.GradeSchools where p.GradeSchoolID==int.Parse(lbma.Text)
                  select p).First();
        txtMaKhoi.Text = c.GradeSchoolID.ToString();
        txtTenKhoi.Text = c.GradeSchoolName;
        btnSua.Enabled = true;
        btnXoa.Enabled = true;
        btnThem.Enabled = false;
    }
}
