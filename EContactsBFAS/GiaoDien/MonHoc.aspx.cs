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

public partial class GiaoDien_MonHoc : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            LoadGrid();
        }
    }
    void LoadGrid()
    {
        var c = from p in db.Subjects select p;
        grvMonHoc.DataSource = c;
        grvMonHoc.DataBind();
    }
    void Them()
    {
        Subject sb = new Subject();
        sb.SubjectID = int.Parse(MaTuTang());
        sb.SubjectName = txtTenMon.Text;
        db.Subjects.InsertOnSubmit(sb);
        db.SubmitChanges();
        LoadGrid();

    }
    void Refresh()
    {
        //txtMaMon.Text = "";
        txtTenMon.Text = "";
        btnXoa.Enabled = false;
        btnThem.Enabled = true;
        btnSua.Enabled = false;
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();
        Refresh();
    }
    string MaTuTang()
    {
        string ma = "";
        var c = from p in db.Subjects select p.SubjectID;
        if (c.Count() == 0)
        {
            ma = "1";
        }
        else
        {
            int max = 0;

            foreach (var con in c)
            {
                max = con + 1;

            }

            ma = max.ToString();
        }
        return ma;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        Subject sb = db.Subjects.SingleOrDefault(p=>p.SubjectID==int.Parse(lblMaMon.Text));
        sb.SubjectName = txtTenMon.Text;
        db.SubmitChanges();
        LoadGrid();
        Refresh();
        
    }
    protected void grvMonHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvMonHoc.SelectedRow;
        Label lbMa = (Label)row.FindControl("lblMaMon");
        var c=(from p in db.Subjects where p.SubjectID==int.Parse(lbMa.Text) select p).First();
        lblMaMon.Text = c.SubjectID.ToString();
        txtTenMon.Text = c.SubjectName;
        btnThem.Enabled = false;
        btnXoa.Enabled = true;
        btnSua.Enabled = true;
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        Subject sb = db.Subjects.SingleOrDefault(p=>p.SubjectID==int.Parse(lblMaMon.Text));
        db.Subjects.DeleteOnSubmit(sb);
        db.SubmitChanges();
        LoadGrid();
        Refresh();
        //btnSua.Enabled = false;
        //btnThem.Enabled = true;
        //btnXoa.Enabled = false;
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Refresh();
    }
}
