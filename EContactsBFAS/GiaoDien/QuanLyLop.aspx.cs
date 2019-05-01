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

public partial class GiaoDien_QuanLyLop : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //MaTuTang();
            LoadGrid();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
           // txtMaLop.Enabled = false;
        }
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();
        refresh();
    }
    void LoadGrid()
    {
        var c = from p in db.Classes select p;
        grvLop.DataSource = c;
        grvLop.DataBind();

    }
    void Them()
    {
        Class cls = new Class();
        cls.ClassID = int.Parse(MaTuTang());
        cls.ClassName = txtTenLop.Text;
        db.Classes.InsertOnSubmit(cls);
        db.SubmitChanges();
        LoadGrid();
        
    }
    void refresh()
    {
        //txtMaLop.Text = "";
        txtTenLop.Text = "";
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnThem.Enabled = true;
        //MaTuTang();

    }
    string  MaTuTang()
    {
        string ma = "";
        var c = from p in db.Classes select p.ClassID;
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
        Class cls = db.Classes.SingleOrDefault(p=>p.ClassID==int.Parse(lblMaLop.Text));
        cls.ClassName = txtTenLop.Text;
        db.SubmitChanges();
        LoadGrid();
        refresh();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        Class cls = db.Classes.SingleOrDefault(p=>p.ClassID==int.Parse(lblMaLop.Text));
        db.Classes.DeleteOnSubmit(cls);
        db.SubmitChanges();
        LoadGrid();
        refresh();
    }
    //protected void btnXoa_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnXoa_Click(object sender, EventArgs e)
    //{

    //}
    protected void grvLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvLop.SelectedRow;
        Label lbma = (Label)row.FindControl("lblMa");
        var c=(from p in db.Classes where p.ClassID==int.Parse(lbma.Text) select p).First() ;
        lblMaLop.Text = c.ClassID.ToString();
        txtTenLop.Text = c.ClassName;
        btnSua.Enabled = true;
        btnXoa.Enabled = true;
        btnThem.Enabled = false;
    }
}
