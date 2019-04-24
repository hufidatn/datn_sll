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

public partial class GiaoDien_BanHoc : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // MaTuTang();
            LoadGrid();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

    }
    void Them()
    {
        Department dp = new Department();
        dp.DepartmentID = int.Parse(MaTuTang());
        dp.DepartmentName = txtTenBan.Text;
        db.Departments.InsertOnSubmit(dp);
        db.SubmitChanges();
        LoadGrid();
    }
    string MaTuTang()
    {
        string ma="";
        var c = from p in db.Departments select p.DepartmentID;
        if (c.Count() == 0)
        {
            ma = "1";
        }
        else 
        {
            int max = 0;
            
            foreach (var con in c)
            {
                max = con+1;

            }
           
            ma = max.ToString();
        }
        //Download source code tại Sharecode.vn
        return ma;
 
    }
    void LoadGrid()
    {
        var c = from p in db.Departments select p;
        grvBan.DataSource = c;
        grvBan.DataBind();
    }
    void Refresh()
    {
        txtTenBan.Text = "";
        btnThem.Enabled = true;
        btnXoa.Enabled = false;
        btnSua.Enabled = false;
        //MaTuTang();
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();
        Refresh();
       // MaTuTang();
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        Department dp = db.Departments.SingleOrDefault(p=>p.DepartmentID==int.Parse(lblMaBan.Text));
        dp.DepartmentName = txtTenBan.Text;
        db.SubmitChanges();
        LoadGrid();
        Refresh();
        //MaTuTang();
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        Department dp = db.Departments.SingleOrDefault(p=>p.DepartmentID==int.Parse(lblMaBan.Text));
        db.Departments.DeleteOnSubmit(dp);
        db.SubmitChanges();
        LoadGrid();
        Refresh();
        //MaTuTang();
    }
    protected void grvBan_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnXoa.Enabled = true;
        btnSua.Enabled = true;
        btnThem.Enabled = false;
        GridViewRow row = grvBan.SelectedRow;
        Label ma = (Label)row.FindControl("lblMa");
        var c = (from p in db.Departments where p.DepartmentID==int.Parse(ma.Text) select p).First();
        lblMaBan.Text = c.DepartmentID.ToString();
        txtTenBan.Text = c.DepartmentName;

    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Refresh();
        btnSua.Enabled = false;
        btnThem.Enabled = true;
        btnXoa.Enabled = false;
        //MaTuTang();
    }
}
