using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System .Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class QuanTri_User_UserGroups : System.Web.UI.Page
    
{
    EContactDataContext db=new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLencboNhom();
            LoadLencboNhomQuyen();
            LoadLencboNam();
            //LoadGrid();
            LoadgrvPhanQuyen();
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        Users_UserGroup us;
        //var c = (from t in db.Users_UserGroups where t.UserGroupID==int.Parse(cboNhom.SelectedValue.ToString()) select t.TeacherID).First();
        for (int i = 0; i < grvNguoiDung.Rows.Count; i++)
        {
                Label Ma = (Label)grvNguoiDung.Rows[i].Cells[4].FindControl("lblMa");
                CheckBox ck = (CheckBox)grvNguoiDung.Rows[i].Cells[0].FindControl("ckbTao");
                us = new Users_UserGroup();
                us.UserGroupID = int.Parse(cboNhom.SelectedValue.ToString());
                us.SchoolYearID = int.Parse(cboNam.SelectedValue.ToString());
                us.TeacherID = Ma.Text;
                db.Users_UserGroups.InsertOnSubmit(us);
                db.SubmitChanges();
                lblHienThi.Text = "Đã phân quyền thành công";
        }
        ckTatCa.Checked = false;
        LoadgrvPhanQuyen();
        LoadgrvNguoiDung();
        btnXoa.Enabled = true;
        ckQuyen.Items[0].Enabled = true; ;
        ckQuyen.Items[1].Enabled = true;
        ckQuyen.Items[2].Enabled = true;
        ckQuyen.Items[3].Enabled = true;
        ckQuyen.Items[4].Enabled = true;
        ckQuyen.Items[5].Enabled = true;
        ckQuyen.Items[6].Enabled = true;
        ckQuyen.Items[7].Enabled = true;
        ckQuyen.Items[8].Enabled = true;
        ckQuyen.Items[9].Enabled = true;
        ckQuyen.Items[10].Enabled = false;
        ckQuyen.Items[0].Selected = false;
        ckQuyen.Items[1].Selected = false;
        ckQuyen.Items[2].Selected = false;
        ckQuyen.Items[3].Selected = false;
        ckQuyen.Items[4].Selected = false;
        ckQuyen.Items[5].Selected = false;
        ckQuyen.Items[6].Selected = false;
        ckQuyen.Items[7].Selected = false;
        ckQuyen.Items[8].Selected = false;
        ckQuyen.Items[9].Selected = false;
        ckQuyen.Items[10].Selected = false;
    }
    void LoadgrvPhanQuyen()
    {
        grvPhanQuyen.DataSource = db.LoadgrvPhanQuyen();
        grvPhanQuyen.DataBind();
    }
    void LoadgrvNguoiDung()
    {
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 1)
        {
            grvNguoiDung.DataSource = db.LoadAdmin();
            grvNguoiDung.DataBind();
        }
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 2)
        {
            grvNguoiDung.DataSource = db.NhomGVCN();
            grvNguoiDung.DataBind();
        }
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 3)
        {

            grvNguoiDung.DataSource = db.gvlopmon();
            grvNguoiDung.DataBind();
        }
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 4)
        {
            grvNguoiDung.DataSource = db.canbo();
            grvNguoiDung.DataBind();
        }
    }
    void LoadLencboNhom()
    {
        var c = from p in db.UserGroups select new{p.UserGroupID,p.UserGroupName};
        cboNhom.DataTextField = "UserGroupName";
        cboNhom.DataValueField = "UserGroupID";
        cboNhom.DataSource = c;
        cboNhom.DataBind();
    }
    void LoadLencboNhomQuyen()
    {
        var c = from p in db.UserGroups select p.RoleName;
        cboNhómQuyền.DataSource = c;
        cboNhómQuyền.DataBind();
    }
    void LoadLencboNam()
    {
        cboNam.DataTextField = "SchoolYearName";
        cboNam.DataValueField = "SchoolYearID";
        cboNam.DataSource = db.NamMoi();
        cboNam.DataBind();
    }
    protected void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 1)
        {
            grvNguoiDung.DataSource = db.LoadAdmin();
            grvNguoiDung.DataBind();
        }
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 2)
        {
            grvNguoiDung.DataSource = db.NhomGVCN();
            grvNguoiDung.DataBind();
        }
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 3)
        {

            grvNguoiDung.DataSource = db.gvlopmon();
            grvNguoiDung.DataBind();
        }
        if (int.Parse(cboNhom.SelectedValue.ToString()) == 4)
        {
            grvNguoiDung.DataSource = db.canbo();
            grvNguoiDung.DataBind();
        }
    }
    protected void cboNhómQuyền_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboNhómQuyền.SelectedIndex == 0)
        {
            ckQuyen.Items[0].Selected = true;
            ckQuyen.Items[1].Selected = true; 
            ckQuyen.Items[2].Selected = true;
            ckQuyen.Items[3].Selected = true;
            ckQuyen.Items[4].Selected = true;
            ckQuyen.Items[5].Selected = true;
            ckQuyen.Items[6].Enabled = false;
            ckQuyen.Items[7].Enabled = false;
            ckQuyen.Items[8].Enabled = false;
            ckQuyen.Items[9].Enabled = false;
            ckQuyen.Items[10].Enabled = false;
            ckQuyen.Items[5].Selected = true;
            ckQuyen.Items[0].Enabled = true;
            ckQuyen.Items[1].Enabled = true;
            ckQuyen.Items[2].Enabled = true;
            ckQuyen.Items[3].Enabled = true;
            ckQuyen.Items[4].Enabled = true;
            ckQuyen.Items[5].Enabled = true;

           
            ckQuyen.Items[6].Selected = false;
            ckQuyen.Items[7].Selected = false;
            ckQuyen.Items[8].Selected = false;
            ckQuyen.Items[9].Selected = false;
            ckQuyen.Items[10].Selected = false;
           
        }
        if (cboNhómQuyền.SelectedIndex == 1)
        {
            ckQuyen.Items[0].Selected = false; ;
            ckQuyen.Items[1].Selected = false; ;
            ckQuyen.Items[2].Selected=false;
            ckQuyen.Items[3].Selected = false; ;
           
            ckQuyen.Items[0].Enabled = false;
            ckQuyen.Items[1].Enabled = false;
            ckQuyen.Items[2].Enabled = false;
            ckQuyen.Items[3].Enabled = false;
            ckQuyen.Items[4].Selected = true;

            ckQuyen.Items[5].Enabled = true; ;
            ckQuyen.Items[6].Enabled = true; ;
            ckQuyen.Items[7].Enabled = true; ;
            ckQuyen.Items[8].Enabled = false;
            ckQuyen.Items[9].Enabled = false;
            ckQuyen.Items[10].Enabled = false;
            ckQuyen.Items[5].Selected = true;
            ckQuyen.Items[6].Selected = true;
            ckQuyen.Items[7].Selected = true;
            ckQuyen.Items[8].Enabled = false;
            ckQuyen.Items[9].Enabled = false;
            ckQuyen.Items[10].Enabled = false;
            ckQuyen.Items[8].Selected = false;
            ckQuyen.Items[9].Selected = false;
            ckQuyen.Items[10].Selected = false;
        }
        if (cboNhómQuyền.SelectedIndex == 2)
        {
            ckQuyen.Items[0].Enabled = false;
            ckQuyen.Items[1].Enabled = false;
            ckQuyen.Items[2].Enabled = false;
            ckQuyen.Items[3].Enabled = false;
            ckQuyen.Items[4].Enabled = false;
            ckQuyen.Items[5].Enabled = false;
            ckQuyen.Items[6].Enabled = false;
            ckQuyen.Items[7].Enabled = false;

            ckQuyen.Items[0].Selected=false;
            ckQuyen.Items[1].Selected=false;
            ckQuyen.Items[2].Selected = false; ;
            ckQuyen.Items[3].Selected = false; ;
            ckQuyen.Items[4].Selected=false;
            ckQuyen.Items[5].Selected=false;
            ckQuyen.Items[6].Selected = false; ;
            ckQuyen.Items[7].Selected=false;

            ckQuyen.Items[8].Enabled = true;
            ckQuyen.Items[9].Enabled = true;

            ckQuyen.Items[8].Selected = true;
            ckQuyen.Items[9].Selected = true;
            ckQuyen.Items[10].Enabled = false;
            ckQuyen.Items[10].Selected = false;
        }
        if (cboNhómQuyền.SelectedIndex == 3)
        {
            ckQuyen.Items[0].Selected=false;
            ckQuyen.Items[1].Selected=false;
            ckQuyen.Items[2].Selected=false;
            ckQuyen.Items[3].Selected = false;
            ckQuyen.Items[4].Selected= false;
            ckQuyen.Items[5].Selected = false;
            ckQuyen.Items[6].Selected= false;
            ckQuyen.Items[7].Selected = false;
            ckQuyen.Items[8].Selected = false;
            ckQuyen.Items[9].Selected = false;

            ckQuyen.Items[0].Enabled = false;
            ckQuyen.Items[1].Enabled = false;
            ckQuyen.Items[2].Enabled = false;
            ckQuyen.Items[3].Enabled = false;
            ckQuyen.Items[4].Enabled = false;
            ckQuyen.Items[5].Enabled = false;
            ckQuyen.Items[6].Enabled = false;
            ckQuyen.Items[7].Enabled = false;
            ckQuyen.Items[8].Enabled = false;
            ckQuyen.Items[9].Enabled = false;

            ckQuyen.Items[10].Selected = true;
            ckQuyen.Items[10].Enabled = true;
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        var c = (from t in db.Users_UserGroups select new { t.UserGroupID,t.Teacher.UserName }).First();
            GridViewRow row = grvPhanQuyen.SelectedRow;
            Label Ma=(Label)row.FindControl("lblMa");
            Label Us = (Label)row.FindControl("lblTenDN");
            if ((Ma.Text == c.UserGroupID.ToString() && Us.Text==c.UserName)||c!=null )
            {
                Users_UserGroup us = db.Users_UserGroups.SingleOrDefault(p => p.UserGroupID ==int.Parse( Ma.Text)&&p.Teacher.UserName==Us.Text);
                db.Users_UserGroups.DeleteOnSubmit(us);
                db.SubmitChanges();
                lblHienThi.Text = "Hủy quyền thành công";
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this,this.GetType(),"Arlet","arlet('Người dùng này chưa được phân quyền')",true);
            }
            LoadgrvNguoiDung();
            LoadgrvPhanQuyen();
           
        
    }
    protected void grvPhanQuyen_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow row = grvPhanQuyen.SelectedRow;
        Label Ma = (Label)row.FindControl("lblMa");
        var c = from p in db.Users_UserGroups where p.TeacherID == Ma.Text select p;
        btnThem.Enabled = false;
        btnXoa.Enabled = true;
    }
    protected void ckTatCa_CheckedChanged(object sender, EventArgs e)
    {
        if (ckTatCa.Checked == true)
        {
            for (int i = 0; i < grvNguoiDung.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)grvNguoiDung.Rows[i].Cells[0].FindControl("ckbTao");
                cb.Checked = true;
            }
        }
        else
            for (int i = 0; i < grvNguoiDung.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)grvNguoiDung.Rows[i].Cells[0].FindControl("ckbTao");
                cb.Checked = false;
            }
    }
}
