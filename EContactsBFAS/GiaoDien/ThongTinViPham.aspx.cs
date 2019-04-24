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
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;


public partial class GiaoDien_ThongTinViPham : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    int ma1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        if (!IsPostBack)
        {
            cls.LoadCBNamTheoGV(c.First().ToString().Trim(), cboNamHoc);
            if (cboNamHoc.Text != "")
            {
                cls.LoadCBLopTheoGV(c.First().ToString().Trim(), cboTenLop, cboNamHoc);
                //cls.LoadComboxNam(cboNamHoc);
                //cls.LoadCbLop(cboTenLop,cboNamHoc.SelectedItem.Value.ToString());
                LoadComBoxHS();
                LoadCBLoiVP();
                LoadGrid();
            }
            else { lblThongBao.InnerText = "Bạn chưa được phân công chủ nhiệm lớp"; }
           
            
           // LoadCBMon();
            //cboMonHoc.SelectedIndex = -1;
           
        }
    }
    void LoadComBoxHS()
    {

        var c = from p in db.ClassStudents
                where p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString()) &&
                p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                select new { p.StudentID, p.Student.StudentName };
        if (c.Count() != 0)
        {
            cboHocSinh.DataTextField = "StudentName";
            cboHocSinh.DataValueField = "StudentID";
            cboHocSinh.DataSource = c;
            cboHocSinh.DataBind();
        }
    }
    void LoadCBLoiVP()
    {
        var c = from p in db.Violations select new { p.ViolationID,p.ViolationName};
        cboViPham.DataTextField = "ViolationName";
        cboViPham.DataValueField = "ViolationID";
        cboViPham.DataSource = c;
        cboViPham.DataBind();
    }
    void LoadCBMon()
    {
        var c = from p in db.ClassDepartments
                where p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString()) &&
                p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                select p.DepartmentID;
        var c1 = from p1 in db.DepartmentSubjects
                 where p1.DepartmentID == c.First()
                 select new {p1.SubjectID, p1.Subject.SubjectName };
        cboMonHoc.Items.Add("Chọn môn học");
        cboMonHoc.DataTextField = "SubjectName";
        cboMonHoc.DataValueField = "SubjectID";
        //foreach (var con in c1)
        //{
        //    cboMonHoc.Items.Add(con.ToString());
        //}

        cboMonHoc.DataSource = c1;
        cboMonHoc.DataBind();
      
    }
    string MaTuTang()
    {
        string ma = "";
        List<string> list = new List<string>();
        string[] a = DateTime.Now.ToShortDateString().Split('/');
        string dau = a[2].Substring(2, 2) + a[0] + a[1];
        string madautien = dau + "001";
        var c = from p in db.Sanctions select p.SanctionID;
        foreach (var con in c)
        {

            if (con.ToString().Substring(0, 6) == dau)
            {
                list.Add(con.ToString());
            }
        }
        if (list.Count == 0)
        {
            ma = madautien;
        }
        else
            if (list.Count > 0)
            {

                ma = (int.Parse(list[list.Count - 1]) + 1).ToString();

            }
        return ma;

    }
    void ThemTTVP()
    {
        Sanction sa = new Sanction();
        sa.SanctionID = int.Parse(MaTuTang());
        sa.SchoolYearID=int.Parse(cboNamHoc.SelectedItem.Value.ToString());
        sa.ClassID=int.Parse(cboTenLop.SelectedItem.Value.ToString());
        sa.StudentID = cboHocSinh.SelectedItem.Value.ToString();
        if(cboMonHoc.Text!="")
        {
            sa.SubjectID = int.Parse(cboMonHoc.SelectedItem.Value.ToString());
        }
        sa.ViolationID = int.Parse(cboViPham.SelectedItem.Value.ToString());
        sa.DateViolation = DateTime.Parse(txtNgayThang.Text);
        sa.SanctionName = txtXuLy.Text;
        if (ckTrangThaiGui.Checked == true)
        {
            sa.StateMessage = true;
        }
        else { sa.StateMessage = false; }
        sa.StateSendMessage = false;
        if (txtSL.Text != "")
        {
            sa.Number = int.Parse(txtSL.Text);
        }
        db.Sanctions.InsertOnSubmit(sa);
        db.SubmitChanges();

    }
    void LoadGrid()
    {
        var c = from p in db.Sanctions
                where (p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                    && p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString())&& p.StateSendMessage==false)
                select new {p.SanctionID,p.StudentID,p.Student.StudentName,p.Subject.SubjectName,p.SanctionName,p.Violation.ViolationName,p.DateViolation,p.StateMessage,p.Number };
        grvTTVP.DataSource = c;
        grvTTVP.DataBind();
    }

    bool kiemtra()
    {
        bool kt = true;
        var c=from p in db.Sanctions where p.SchoolYearID==int.Parse(cboNamHoc.SelectedItem.Value.ToString())
              &&p.ClassID==int.Parse(cboTenLop.SelectedItem.Value.ToString())&&
              p.StudentID==cboHocSinh.SelectedItem.Value.ToString()&&p.DateViolation==DateTime.Parse(txtNgayThang.Text)
              &&p.ViolationID==int.Parse(cboViPham.SelectedItem.Value.ToString())
              select p;
        if (c.Count() == 1)
        {
            kt = false;
        }
        return kt;
    }
    bool kiemtratrong()
    {
        bool kt = true;
        lblThongBao.InnerText = "";
        if (cboNamHoc.Text == "" || cboTenLop.Text == "" || cboHocSinh.Text == "")
        {
            kt = false;
        }
        return true;

    }
    void refresh()
    {
        txtNgayThang.Text = "";
        txtSL.Text = "";
        txtXuLy.Text = "";
        ckTrangThaiGui.Checked = false;
        cboMonHoc.SelectedIndex = 0;
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        if (kiemtratrong() == true)
        {
            if (kiemtra() == true)
            {
                ThemTTVP();
                LoadGrid();
                refresh();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Lỗi VP này đã được nhập!');", true);
                refresh();
            }
        }
        else
        {
            lblThongBao.InnerText = "Các trường thông tin không được để trống!";
            cboNamHoc.Enabled = false;
        }
    }
    
    protected void grvTTVP_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grvTTVP.SelectedRow;
        Label lblMa = (Label)row.FindControl("lblMaVP");
        var c = (from p in db.Sanctions
                where p.SanctionID == int.Parse(lblMa.Text)
                select new {p.SanctionID, p.StudentID,p.SubjectID, p.Number, p.DateViolation, p.ViolationID, p.StateMessage, p.SanctionName }).First();
        cboHocSinh.SelectedItem.Value = c.StudentID.ToString();
        cboViPham.SelectedItem.Value = c.ViolationID.ToString();
        txtNgayThang.Text = c.DateViolation.ToShortDateString();
        txtSL.Text = c.Number.ToString();
        txtXuLy.Text = c.SanctionName.ToString();
        ma1 = c.SanctionID;
        lblMaVPh.Text = ma1.ToString();
        Response.Write(ma1.ToString());
        if (c.StateMessage == true)
            ckTrangThaiGui.Checked = true;
        if (c.StateMessage == false)
            ckTrangThaiGui.Checked = false;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
       // Response.Write(ma1.ToString());
        Sanction sa = db.Sanctions.SingleOrDefault(p => p.SanctionID == int.Parse(lblMaVPh.Text));
        
        sa.StudentID = cboHocSinh.SelectedItem.Value.ToString();
        sa.SubjectID =int.Parse( cboMonHoc.SelectedItem.Value.ToString());
        sa.DateViolation = DateTime.Parse(txtNgayThang.Text);
        sa.Number =int.Parse( txtSL.Text);
        sa.SanctionName = txtXuLy.Text;
        if (ckTrangThaiGui.Checked == true)
        {
            sa.StateMessage = true;
        }
        else
        {
            sa.StateMessage = false;
        }
        db.SubmitChanges();
    }
    protected void btnSMS_Click(object sender, EventArgs e)
    {
        //string chuoikn = @"Data Source=.\SQLEXPRESS;Initial Catalog=SMS;Integrated Security=True";
        //try
        //{
            //Connect to the database
           // OleDbConnection conn = new OleDbConnection();
        SqlConnection conn = new SqlConnection();
         conn.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SMS;Integrated Security=True";
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                //Send the message
                SqlCommand cmd = new  SqlCommand();
                cmd.Connection = conn;
                string SQLInsert =
                "INSERT INTO " +
                "SendMessages(PhoneReceive,Message,State) " +
                "VALUES " +
                "('+84938328438','Ngu Ngoc','send')";
                cmd.CommandText = SQLInsert;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Message sent");
            }

            //Disconnect from the database
            conn.Close();
        //}
        //catch (Exception ex)
        //{
        //    //MessageBox.Show(ex.Message);
        //}


    }
    protected void cboTenLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboNamHoc.Text != "")
        {
            LoadComBoxHS();
            LoadCBMon();
        }
    }
    protected void grvTTVP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTTVP.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }
    protected void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        cls.LoadCBLopTheoGV(c.First().ToString().Trim(),cboTenLop,cboNamHoc);
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        Sanction sa = db.Sanctions.SingleOrDefault(p=>p.SanctionID==int.Parse(lblMaVPh.Text));
        db.Sanctions.DeleteOnSubmit(sa);
        db.SubmitChanges();
        LoadGrid();
    }
}
