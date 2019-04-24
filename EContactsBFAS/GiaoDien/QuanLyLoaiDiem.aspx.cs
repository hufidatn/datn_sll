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

public partial class GiaoDien_QuanLyLoaiDiem : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnXoa.Visible = false;
            TangMa(lbMaLD);
            LoadGrid();
        }
    }


    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();
        LoadGrid();
    }
    void Them()
    {
        TypeScore tc = new TypeScore();
        tc.TypeScoreID = int.Parse(lbMaLD.Text);
        tc.TypeScoreName = txtTenLD.Text;
        db.TypeScores.InsertOnSubmit(tc);
        db.SubmitChanges();
        txtTenLD.Text = "";
    }
    void LoadGrid()
    {
        var t = from p in db.TypeScores select p;
        grvLoaiDiem.DataSource = t;
        grvLoaiDiem.DataBind();
    }
    void TangMa(Label ma)
    {
        var t = from p in db.TypeScores orderby p.TypeScoreID descending select p.TypeScoreID;
        string tmp = t.FirstOrDefault().ToString();
        if (tmp == "")
        {
            lbMaLD.Text = "1";
        }
        else
            lbMaLD.Text = (int.Parse(tmp.Trim()) + 1).ToString();
    }
    protected void grvLoaiDiem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvLoaiDiem.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        TypeScore tc = db.TypeScores.SingleOrDefault(t => t.TypeScoreID == int.Parse(lbMaLD.Text));
        tc.TypeScoreName = txtTenLD.Text;
        db.SubmitChanges();
        //grvLoaiDiem.EditIndex = -1; 
        LoadGrid();
    }
    protected void grvLoaiDiem_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvLoaiDiem.SelectedRow;
        Label lblMaLD = (Label)row.FindControl("lblMa");
        TypeScore tc = db.TypeScores.SingleOrDefault(p => p.TypeScoreID == int.Parse(lblMaLD.Text));
        lblMaLD.Text = tc.TypeScoreID.ToString();
        txtTenLD.Text = tc.TypeScoreName.ToString();
        // grvLoaiDiem.EditIndex = e.NewEditIndex;
        LoadGrid();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        btnXoa.Visible = false;
        TypeScore tc = db.TypeScores.SingleOrDefault(p => p.TypeScoreID == int.Parse(lbMaLD.Text));
        db.TypeScores.DeleteOnSubmit(tc);
        db.SubmitChanges();

        //lblMaLD.Text = tc.TypeScoreID.ToString();
        //txtTenLD.Text = tc.TypeScoreName.ToString();
        // grvLoaiDiem.EditIndex = e.NewEditIndex;
        LoadGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        txtTenLD.Text = "";

    }
}
