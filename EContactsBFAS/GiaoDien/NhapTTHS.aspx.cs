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
using System.Data.OleDb;
using Microsoft.Office.Interop;
using System.IO;

public partial class GiaoDien_NhapTTHS : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtMaHS.Enabled = false;
            MaTuTang();
            cls.LoadCbCity(cboTP);
            cls.LoadCbQuan(cboQuan);
            //LoadTime();
            LoadGrid();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
    void Insert()
    {
        lblUpload.InnerText = "";
        if (FileUpload1.HasFile)
        {
            string file = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (file == ".jpg" || file == ".png")
            {
                //string path = Server.MapPath("image\\");
                string path = Path.Combine(Server.MapPath("~/image/img_HS"), Path.GetFileName(FileUpload1.FileName));
                FileUpload1.SaveAs(path);
                //lblUpload.Text = path;
            }
            else
            {
                lblUpload.InnerText = "Ảnh sai định dạng !";
            }
            if (txtHoTen.Text != "" && txtDiachi.Text != "" && txtNgSinh.Text != "" && txtNoiSinh.Text != "" && txtNVT.Text != "")
            {
                if (rdoNam.Checked != false || rdoNu.Checked != false)
                {
                    Student stu = new Student();
                    stu.StudentID = txtMaHS.Text;
                    stu.StudentName = txtHoTen.Text;
                    stu.City = cboTP.SelectedValue.ToString();
                    stu.Status = "1";
                    stu.Images = "/image/img_HS/"+FileUpload1.FileName;
                    stu.SchoolEntryForm = cboHTVT.SelectedValue;
                    stu.Address = txtDiachi.Text;
                    stu.DateOfBirth = DateTime.Parse(txtNgSinh.Text);
                    stu.SchoolDay = DateTime.Parse(txtNVT.Text);
                    stu.Username = stu.Password = txtMaHS.Text;
                    if (rdoNu.Checked == true)
                    {
                        stu.Gender = "Nữ";
                    }
                    if (rdoNam.Checked == true)
                    {
                        stu.Gender = "Nam";
                    }
                    //stu.Gender = "Nữ";
                    db.Students.InsertOnSubmit(stu);
                    db.SubmitChanges();
                    LoadGrid();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Bạn thêm thành công');", true);
                    Refresh();
                }
            }
        }
        else
        {
            lblUpload.InnerText = "Xin chọn ảnh !";
        }

    }
    public void loadCity()
    {

    }
    //public void LoadTime()
    //{
    //    cboNgay.Items.Add("Ngày");
    //    cboThang.Items.Add("Tháng");
    //    cboNam.Items.Add("Năm");
    //    //cboNgay1.Items.Add("Ngày");
    //    //cboThang1.Items.Add("Tháng");
    //    //cboNam1.Items.Add("Năm");
    //    for (int i = 1; i <= 31; i++)
    //    {
    //        cboNgay.Items.Add(i.ToString()); //cboNgay1.Items.Add(i.ToString());
    //    }
    //    for (int j = 1; j <= 12; j++)
    //    {
    //        cboThang.Items.Add(j.ToString());//cboThang1.Items.Add(j.ToString());
    //    }
    //    for (int k = 1990; k <= DateTime.Now.Year; k++)
    //    {
    //        cboNam.Items.Add(k.ToString());//cboNam1.Items.Add(k.ToString());
    //    }
    //}
    //DateTime ChuyenDoiNgay()
    //{
    //    DateTime dt;
    //    int ngay = int.Parse(cboNgay.SelectedItem.Text.ToString());
    //    int thang = int.Parse(cboThang.SelectedItem.Text.ToString());
    //    int nam = int.Parse(cboNam.SelectedItem.Text.ToString());
    //    dt = new DateTime(nam, thang, ngay);
    //    return dt;
    //}
    void LoadGrid()
    {
        var data = from p in db.Students
                   select p;
        grvHocSinh.DataSource = data;
        grvHocSinh.DataBind();
    }
    void Refresh()
    {
        txtMaHS.Enabled = false;
        txtHoTen.Text = "";
        
        //txtQueQuan.Text="";
        //txtSDT.Text="";
        //txtSDTDD.Text = "";
        rdoNam.Checked = false;
        rdoNu.Checked = false;
        //cboNgay.SelectedIndex = 0;
        //cboThang.SelectedIndex = 0;
        //cboNam.SelectedIndex = 0;
        MaTuTang();
        //txtSDTDD.Enabled = true;
        txtHoTen.Enabled = true;
        txtMaHS.Enabled = true;
        //txtQueQuan.Enabled = true; txtSDT.Enabled = true;
        //cboNam.Enabled = true;
        //cboNgay.Enabled = true;
        //cboThang.Enabled = true;
        rdoNam.Enabled = true;
        rdoNu.Enabled = true;
        fuNhapExcel.Enabled = false;
    }
    protected void txtMaHS_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        bool kt=true;
            if (ckExcel.Checked == true)
            {
                lblThongBao.InnerText = "";
                if (fuNhapExcel.HasFile == true)
                {
                    if (CheckFileType(fuNhapExcel.FileName) == true)
                    {

                        string path = Server.MapPath("..\\upload") + "\\" + fuNhapExcel.FileName;
                        fuNhapExcel.SaveAs(path);
                        ImportFromExcel(path);
                    }
                    else
                    {
                        lblThongBao.InnerText = "File nhập không đúng định dạng!";
                    }
                }
                else { lblThongBao.InnerText = "Bạn phải nhập đường dẫn"; }
                
            }
            else
            {
                kt = kiemtraDuLieu();
                if (kt == false)
                { return; }
                kt=kiemtraGioiTinh();
                if (kt == false) return;
                //kt=kiemtrasodienthoaiCD();
                //if (kt == false) return;
                //kt = kiemtrasodienthoaiDD();
                //if (kt == false) return;

                Insert();
                fuNhapExcel.Enabled = false;
            }
        //string path = "E:\\Student.xlsx";
        //ImportFromExcel(path);
    }

    //đọc từ excel
    void ImportFromExcel(string filePath)
    {
       
        
            if (!System.IO.File.Exists(filePath))
            {
                return;
            }
 
            // Cắt đường dẫn tập tin để kiểm tra xem là xls hay xlsx
            string[] fileParts = filePath.Split('.');
 
            string connString = "";
            if (filePath.Length > 1 && fileParts[1] == "xls")// sử dụng cho Microsoft Excel 2003
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0";
            }
            else // sử dụng cho Microsoft Excel 2007
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0";
            }
 
            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connString);
            try
            {
                // Mở kết nối
                oledbConn.Open();
 
                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);
 
                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();
 
                oleda.SelectCommand = cmd;
 
                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();
 
                // Đổ đữ liệu từ tập excel vào DataSet
                 oleda.Fill(ds);
                DataTable dt=ds.Tables[0];
                for (int i = 3; i < dt.Rows.Count; i++)
                {
                    int c=(from p in db.Students where p.StudentID==dt.Rows[i][1].ToString() select p).Count();
                    if(c==0)
                    {
                    Student st = new Student();
                    st.StudentID = dt.Rows[i][1].ToString();
                   
                    st.StudentName = dt.Rows[i][2].ToString();
                    st.Gender = dt.Rows[i][4].ToString();
                    st.DateOfBirth = DateTime.Parse(dt.Rows[i][3].ToString());
                    st.Address = dt.Rows[i][5].ToString();
                    db.Students.InsertOnSubmit(st);
                    db.SubmitChanges();
                    //LoadGrid();
                    }
                    if(c!=0)
                    {
                        Student st=db.Students.SingleOrDefault(p=>p.StudentID==dt.Rows[i][1].ToString());
                        st.StudentName = dt.Rows[i][2].ToString();
                        st.Gender = dt.Rows[i][4].ToString();
                        st.DateOfBirth = DateTime.Parse(dt.Rows[i][3].ToString());
                        st.Address = dt.Rows[i][5].ToString();
                        db.SubmitChanges();
                        
                    }

                } 
                
                LoadGrid();
            }
            catch
            {
            }
            finally
            {
                 //Đóng chuỗi kết nối
                oledbConn.Close();
            }
        }
    protected void ckExcel_CheckedChanged(object sender, EventArgs e)
    {
        if (ckExcel.Checked == true)
        {
            txtHoTen.Enabled = false;
            //txtQueQuan.Enabled = false;
            //txtSDT.Enabled = false;
            //txtSDTDD.Enabled = false;
            //cboNam.Enabled = false;
            //cboNgay.Enabled = false;
            //cboNam.Enabled = false;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            fuNhapExcel.Enabled = true;
        }
        else
        {
            Refresh();
            
        }
    }
    protected void grvHocSinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("style", "background-color: #FFFFFF; color: black;");
                e.Row.Attributes.Add("onmouseover", "style.backgroundColor='#FF6600'");
                e.Row.Attributes.Add("onmouseout", "style.backgroundColor='#FFFFFF'");
            }
        }
        catch { }
    }
    protected void grvHocSinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnXoa.Enabled = true;
        btnSua.Enabled = true;
        btnThem.Enabled = false;
        GridViewRow row = grvHocSinh.SelectedRow;
        Label lbma = (Label)row.FindControl("lblMa");
        var c = (from p in db.Students where p.StudentID == lbma.Text select p).First();
        txtHoTen.Text = c.StudentName.Trim();
        txtMaHS.Text = c.StudentID.Trim();
        //txtQueQuan.Text = c.Address.Trim();
        //txtSDT.Text = c.PhoneFixe.Trim();
        //txtSDTDD.Text = c.MobilePhone.Trim();
        string chuoi = c.DateOfBirth.ToString();
        string[] mang = chuoi.Split(' ');
        string[] s = mang[0].Split('/');
        //if (s[0].Substring(0, 1) == "0")
        //{
        //    cboNgay.Text = s[0].Substring(1);
        //}
        //else
        //{
        //    cboNgay.Text = s[0];
        //}
        //if (s[1].Substring(0, 1) == "0")
        //{
        //    cboThang.Text = s[1].Substring(1);
        //}
        //else
        //{
        //    cboThang.Text = s[1];
        //}
        //cboNam.Text = s[2];
        if (c.Gender.Trim() == "Nam")
        {
            rdoNam.Checked = true;
        }
        if (c.Gender.Trim() == "Nữ")
        {
            rdoNu.Checked = true;
        }
        
        
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        bool kt = true;
        kt = kiemtraDuLieu();
        if (kt == false)
        { return; }
        kt = kiemtraGioiTinh();
        if (kt == false) return;
        //kt = kiemtrasodienthoaiCD();
        //if (kt == false) return;
        //kt = kiemtrasodienthoaiDD();
        //if (kt == false) return;
        Student st = db.Students.SingleOrDefault(p => p.StudentID == txtMaHS.Text);
        st.StudentName = txtHoTen.Text;
        if (rdoNam.Checked == true)
        {
            st.Gender = "Nam";

        }
        if (rdoNu.Checked == true)
        { st.Gender = "Nữ"; }
        st.DateOfBirth = DateTime.Parse(txtNgSinh.Text);
        //st.Address = txtQueQuan.Text;
        db.SubmitChanges();
        LoadGrid();
        Refresh();
        btnThem.Enabled = true;
    }
    void Xoa()
    {
        Student st = db.Students.SingleOrDefault(p=>p.StudentID==txtMaHS.Text);
        db.Students.DeleteOnSubmit(st);
        db.SubmitChanges();
        LoadGrid();
        Refresh();
    }
    protected void grvHocSinh_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Label lblMa = (Label)grvHocSinh.Rows[e.RowIndex].FindControl("lblMa");
        //Student st = db.Students.SingleOrDefault(c => c.StudentID == lblMa.Text);
        //db.Students.DeleteOnSubmit(st);
        //db.SubmitChanges();
        //LoadGrid();
        //txtHoTen.Focus();
    }
    protected void grvHocSinh_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        TextBox txtTen = (TextBox)grvHocSinh.Rows[e.RowIndex].FindControl("txtHoTen1");
        TextBox txtNS = (TextBox)grvHocSinh.Rows[e.RowIndex].FindControl("txtNgaySinh1");
        DropDownList  ddlGioi = (DropDownList)grvHocSinh.Rows[e.RowIndex].FindControl("ddlGioi1");
        TextBox txtDC = (TextBox)grvHocSinh.Rows[e.RowIndex].FindControl("txtDiaChi1");
        TextBox txtCD = (TextBox)grvHocSinh.Rows[e.RowIndex].FindControl("txtCD");
        TextBox txtDD = (TextBox)grvHocSinh.Rows[e.RowIndex].FindControl("txtDD");
        Label lblma = (Label)grvHocSinh.Rows[e.RowIndex].FindControl("lblMa");
        //ddlGioi.DataSource = c;
        //ddlGioi.DataTextField = "Gender";
        //ddlGioi.DataValueField = "Gender";
        //ddlGioi.DataBind();
        
        Student st = db.Students.SingleOrDefault(p=>p.StudentID==lblma.Text);
        st.StudentName = txtTen.Text;
        st.Gender = ddlGioi.SelectedItem.ToString();
        st.DateOfBirth =DateTime.Parse(txtNS.Text);
        st.Address = txtDC.Text;
        db.SubmitChanges();
        grvHocSinh.EditIndex = -1;
        LoadGrid();



    }
    protected void grvHocSinh_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Label lblma = (Label)grvHocSinh.Rows[e.NewEditIndex].FindControl("lblMa");
        var  c = from p in db.Students where p.StudentID == lblma.Text select p.Gender;
        Student st = db.Students.SingleOrDefault(p=>p.StudentID==lblma.Text);

        txtHoTen.Text = st.StudentName.ToString();
        txtMaHS.Text = st.StudentID.ToString();
        //txtQueQuan.Text = st.Address.ToString();
        grvHocSinh.EditIndex = e.NewEditIndex;
        LoadGrid();
        
        DropDownList ddlGioi = (DropDownList)grvHocSinh.Rows[e.NewEditIndex].FindControl("ddlGioi1");
        
        //Response.Write(ddlGioi.Text);
        ddlGioi.Items.Add("Nam");
        ddlGioi.Items.Add("Nữ");
        if (c.First().ToString() == "Nam")
        {
         //   ddlGioi.Text = "Nam";
            ddlGioi.SelectedIndex = 0;
        }
        if (c.First().ToString() == "Nữ")
        {
            //ddlGioi.Text = "Nữ";
            ddlGioi.SelectedIndex = 1;
        }
        

    }

    public string DisplayDate(string d)
    {
        DateTime dDate = DateTime.Parse(d);
        return string.Format("{0:dd/MM/yyyy}", dDate);
    }
    protected void grvHocSinh_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("NhapTTHS.aspx");
        txtHoTen.Focus();
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Refresh();
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //if (e.Value)

        //    e.IsValid = false;

        //else

        //    e.IsValid = true;
    }

    //Mã tự động tăng
    void MaTuTang()
    {
        //lay 2 số cuối của năm hiện tại làm đầu mã
        string dau=DateTime.Now.Year.ToString();
        string cuoi=dau.Substring(2,2);
        int nam=int.Parse(cuoi);
        string madautien = cuoi + "001";
        var c = from p in db.Students select p.StudentID;
        
        if (c.Count() == 0)
        {
            txtMaHS.Text = madautien;
        }
        //if(c.Count()==1)
        //{

        //    txtMaHS.Text = (int.Parse(madautien) + 1).ToString();
            
        //}
        if(c.Count()>=1)
        {
            int max=0;
            string max1;
            foreach (var con in c)
            {
                max = int.Parse(con.Trim().ToString());
                
            }
            max1 = (max + 1).ToString();
            txtMaHS.Text = max1;
        }
    }

    protected void grvHocSinh_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        Xoa();
        btnThem.Enabled = true;
    }
    bool  kiemtraDuLieu()
    {
        bool kt = true;
        lblThongBao.InnerText = "";
        lblUpload.InnerText = "";
        lblChuThichDTDD.InnerText = "";
        if (txtHoTen.Text == "")//txtQueQuan.Text=="")
        {
            kt = false;
            lblThongBao.InnerText = "Các trường không được để trống";
        }
        
        return kt;
    }
    private bool CheckFileType(string FileName)
    {
        string ext = Path.GetExtension(FileName);
        if (ext.Equals(".png") || ext.Equals(".xls") || ext.Equals(".xlsx"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool kiemtraGioiTinh()
    {
        bool kt = true;
        lblThongBao.InnerText = "";
        
        if (rdoNam.Checked==false&&rdoNu.Checked==false)
        {
            kt = false;
            lblThongBao.InnerText = "Bạn phải chọn giới tính!";
        }

        return kt;
    }

    protected void grvHocSinh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvHocSinh.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }
}

