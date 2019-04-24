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

public partial class GiaoDien_QLCacViPham : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
        }

    }
    string MaTuTang()
    {
        string ma = "";
        var c = from p in db.Violations select p.ViolationID;
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

    void Them()
    {
        Violation vi=new Violation();
        vi.ViolationID = int.Parse(MaTuTang());
        vi.ViolationName = txtLoiVP.Text;
        vi.Description = txtGhiChu.Text;
        db.Violations.InsertOnSubmit(vi);
        db.SubmitChanges();
        LoadGrid();


    }
    void LoadGrid()
    {
        var c = from p in db.Violations select p;
        grvLoiVP.DataSource = c;
        grvLoiVP.DataBind();
        refresh();
    }
    void refresh()
    {
        //txtMaNam.Text = "";
        txtLoiVP.Text = "";
        btnSua.Enabled = false;
        btnXoa.Enabled = false;
        btnThem.Enabled = true;

    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Them();
        refresh();
    }
    protected void grvLoiVP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvLoiVP.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }
}
