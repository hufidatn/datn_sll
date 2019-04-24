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
public partial class GiaoDien_NienHoc : System.Web.UI.Page
{
    
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //MaTuTang();
            LoadGrid();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
           // txtMaNam.Enabled = false;
        }
    }


    string MaTuTang()
    {
        string ma = "";
        var c = from p in db.SchoolYears select p.SchoolYearID;
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

            ma= max.ToString();
        }
        return ma;
    }

    void Them()
    {
        SchoolYear sh = new SchoolYear();
        sh.SchoolYearID = int.Parse(MaTuTang());
        sh.SchoolYearName = txtTenNam.Text;
        db.SchoolYears.InsertOnSubmit(sh);
        db.SubmitChanges();
        LoadGrid();
       
        
    }
    void LoadGrid()
    {
        var c = from p in db.SchoolYears select p;
        grvNamHoc.DataSource = c;
        grvNamHoc.DataBind();
        refresh();
    }
    void refresh()
    {
        //txtMaNam.Text = "";
        txtTenNam.Text = "";
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnThem.Enabled = true;
        //MaTuTang();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();
    }
    protected void grvNamHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSua.Enabled = true;
        btnXoa.Enabled = true;
        btnThem.Enabled = false;
        GridViewRow row = grvNamHoc.SelectedRow;
        Label lbma = (Label)row.FindControl("lblMaNam");
        var c = (from p in db.SchoolYears 
                 where p.SchoolYearID == int.Parse(lbma.Text) 
                 select p).First();
        lblMaNam.Text = c.SchoolYearID.ToString();
        txtTenNam.Text = c.SchoolYearName;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        SchoolYear sh = db.SchoolYears.SingleOrDefault(p=>p.SchoolYearID==int.Parse(lblMaNam.Text));
        sh.SchoolYearName = txtTenNam.Text;
        db.SubmitChanges();
        LoadGrid();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        SchoolYear sh = db.SchoolYears.SingleOrDefault(p=>p.SchoolYearID==int.Parse(lblMaNam.Text));
        db.SchoolYears.DeleteOnSubmit(sh);
        db.SubmitChanges();
        LoadGrid();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        refresh();
    }
    
}
