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

public partial class GiaoDien_PhanBan : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            LoadCBBan();
            LoadCBMon();
            LoadCBHeSo();
        }
    }
    void LoadCBBan()
    {
        var c = from p in db.Departments select p;
        cboBan.DataTextField = "DepartmentName";
        cboBan.DataValueField = "DepartmentID";
        cboBan.DataSource = c;
        cboBan.DataBind();
    }
    void LoadCBMon()
    {
        var c = from p in db.Subjects select p;
        cboMon.DataTextField = "SubjectName";
        cboMon.DataValueField = "SubjectID";
        cboMon.DataSource = c;
        cboMon.DataBind();
    }
    void LoadCBHeSo()
    {
        cboHeSo.Items.Add("1");
        cboHeSo.Items.Add("2");
        cboHeSo.Items.Add("3");
    }
    void LoadGrid()
    {
        var c = from p in db.DepartmentSubjects
                select new { p.Multiplier, p.Department.DepartmentName, p.Subject.SubjectName,p.SubjectID,p.DepartmentID };
        grvHocSinh.DataSource = c;
        grvHocSinh.DataBind();
        cboBan.Enabled = true;
        cboMon.Enabled = true;
    }
    void Them()
    {
        DepartmentSubject dp = new DepartmentSubject();
        dp.SubjectID = int.Parse(cboMon.SelectedItem.Value.ToString());
        dp.DepartmentID = int.Parse(cboBan.SelectedItem.Value.ToString());
        dp.Multiplier = int.Parse(cboHeSo.Text);
        db.DepartmentSubjects.InsertOnSubmit(dp);
        db.SubmitChanges();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();
        LoadGrid();

    }
    protected void grvHocSinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboMon.Enabled = false;
        cboBan.Enabled = false;
        GridViewRow row = grvHocSinh.SelectedRow;
        Label lbmamon = (Label)row.FindControl("lblMaMon");
        Label lbmaban = (Label)row.FindControl("lblMaBan");
        var c = from p in db.DepartmentSubjects
                where p.DepartmentID == int.Parse(lbmaban.Text) && p.SubjectID == int.Parse(lbmamon.Text)
                select new { p.SubjectID, p.DepartmentID, p.Multiplier };
        cboBan.SelectedValue = c.First().DepartmentID.ToString();
        cboMon.SelectedValue = c.First().SubjectID.ToString();
        cboHeSo.SelectedItem.Text = c.First().Multiplier.ToString();
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        DepartmentSubject dps = db.DepartmentSubjects.SingleOrDefault(p => p.DepartmentID == int.Parse(cboBan.SelectedItem.Value.ToString())
            && p.SubjectID == int.Parse(cboMon.SelectedItem.Value.ToString()));
        dps.Multiplier = int.Parse(cboHeSo.Text);
        db.SubmitChanges();
        LoadGrid();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        cboMon.Enabled = true;
        cboBan.Enabled = true;
    }
}
