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

public partial class QuanTri_Roles : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MaTang(lblMa.Text);
            LoadGrid();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        UserGroup ug = new UserGroup();
        ug.UserGroupID = int.Parse(lblMa.Text);
        ug.UserGroupName = txtTenQuyen.Text;
        ug.RoleName = txtGhichu.Text;
        db.UserGroups.InsertOnSubmit(ug);
        db.SubmitChanges();
        LoadGrid();
        MaTang(lblMa.Text);
        txtTenQuyen.Text = "";
        txtGhichu.Text = "";
    }
    void LoadGrid()
    {
        var c = from p in db.UserGroups select p;
        grvQuyen.DataSource = c;
        grvQuyen.DataBind();

    }
    void MaTang(string ma)
    {

        var t = from p in db.UserGroups orderby p.UserGroupID descending select p.UserGroupID;
        string tmp = t.FirstOrDefault().ToString();
        if (tmp == "")
        {
            lblMa.Text = "1";
        }
        else
            lblMa.Text = (int.Parse(tmp.Trim()) + 1).ToString();
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        UserGroup rl = db.UserGroups.SingleOrDefault(p=>p.UserGroupID==int.Parse(lblMa.Text));
        rl.UserGroupName = txtTenQuyen.Text;
        rl.RoleName = txtGhichu.Text;
        db.SubmitChanges();
        LoadGrid();
        txtTenQuyen.Text = "";
        txtGhichu.Text = "";
    }
    protected void grvQuyen_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvQuyen.SelectedRow;
        Label Ma = (Label)row.FindControl("lblMa");
        var c = (from p in db.UserGroups where p.UserGroupID ==int.Parse( Ma.Text) select p).First();
        lblMa.Text = c.UserGroupID.ToString();
        txtTenQuyen.Text = c.UserGroupName;
        txtGhichu.Text = c.RoleName;
        db.SubmitChanges();  
        btnXoa.Enabled = true;
        btnSua.Enabled = true;
        btnThem.Enabled = false;
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        UserGroup  rl = db.UserGroups.SingleOrDefault(p => p.UserGroupID==int.Parse(lblMa.Text));
        db.UserGroups.DeleteOnSubmit(rl);
        db.SubmitChanges();
        txtTenQuyen.Text = "";
        txtGhichu.Text = "";
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtTenQuyen.Text = "";
        txtGhichu.Text = "";
    }
}
