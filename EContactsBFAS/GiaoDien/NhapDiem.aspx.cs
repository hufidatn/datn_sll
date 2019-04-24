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
using System.Collections.Generic;

public partial class GiaoDien_NhapDiem : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    clsNhapDiem nh = new clsNhapDiem();
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string TenDN = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == TenDN
                select p.TeacherID;
        if (!IsPostBack)
        {
            
            cls.LoadComboxNam1(cboNam);
            if (cboNam.Text != "")
            {
                loadCBKyTheoGiaoVien(c.First());
                LoadCBLopTheoGiaoVien(c.First());
                
                cls.LoadCbLoaiDiem(cboLoaiDiem);
                //Download source code tại Sharecode.vn
                LoadComBoxHS();
                LoadCBMon(c.First());
                LoadGrid();
                LoadMaHS();
            }
            else { lblThongBao.InnerText = "Bạn chưa được phân công dạy!";
            cboNam.Enabled = false;
            cboTenHS.Enabled = false;
            cboMonHoc.Enabled = false;
            cboLop.Enabled = false;
            }
        }
    }
    void loadCBKyTheoGiaoVien(string maGV)
    {
        var c = from i in
                    (from p in db.TeacherSubjects
                     where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                         && p.TeacherID == maGV
                     select new { p.SemesterID, p.Semester.SemesterName })
                group i by new { i.SemesterID, i.SemesterName } into gr
                select new { gr.Key.SemesterID,gr.Key.SemesterName};
        cboKy.DataTextField = "SemesterName";
        cboKy.DataValueField = "SemesterID";
        cboKy.DataSource = c;
        cboKy.DataBind();
    }
    void LoadCBLopTheoGiaoVien(string maGV)
    {
        var c = from i in
                    (from p in db.TeacherSubjects
                     where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                     && p.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString())
                     && p.TeacherID == maGV
                     select new { p.Class.ClassName, p.ClassID })
                group i by new { i.ClassID, i.ClassName } into grp
                select new { grp.Key.ClassID,grp.Key.ClassName};
        if (c.Count() != 0)
        {
            cboLop.DataTextField = "ClassName";
            cboLop.DataValueField = "ClassID";
            cboLop.DataSource = c;
            cboLop.DataBind();
        }
    }
    void LoadComBoxHS()
    {

        var c = from p in db.ClassStudents
                  where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                  p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                  select new { p.StudentID, p.Student.StudentName };
        if (c.Count() != 0)
        {
            cboTenHS.DataTextField = "StudentName";
            cboTenHS.DataValueField = "StudentID";
            cboTenHS.DataSource = c;
            cboTenHS.DataBind();
        }
    }
    void LoadCBMon( string maGV)
    {
        
        //var c = from p in db.ClassDepartments
        //        where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
        //        p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
        //        select p.DepartmentID;
        var c1 = from p1 in db.TeacherSubjects
                 where p1.ClassID==int.Parse(cboLop.SelectedItem.Value.ToString())
                 && p1.SchoolYearID==int.Parse(cboNam.SelectedItem.Value.ToString())
                 &&p1.SemesterID==int.Parse(cboKy.SelectedItem.Value.ToString())
                 &&p1.TeacherID==maGV
                 select new { p1.SubjectID,p1.Subject.SubjectName };
        cboMonHoc.DataTextField = "SubjectName";
        cboMonHoc.DataValueField = "SubjectID";
        cboMonHoc.DataSource = c1;
        cboMonHoc.DataBind();
    }
    void Them()
    {
        Score sc = new Score(); 
        sc.ScoreID =MaTuTang();
        sc.SchoolYearID = int.Parse(cboNam.SelectedItem.Value.ToString());
        sc.SemesterID =int.Parse(cboKy.SelectedItem.Value.ToString());
        sc.StudentID = cboTenHS.SelectedItem.Value.ToString();
        sc.SubjectID =int.Parse(cboMonHoc.SelectedItem.Value.ToString());
        sc.ClassID = int.Parse(cboLop.SelectedItem.Value.ToString());
        sc.TypeScoreID =int.Parse(cboLoaiDiem.SelectedItem.Value.ToString());
        sc.Score1 = float.Parse(txtDiem.Text);
        db.Scores.InsertOnSubmit(sc);
        db.SubmitChanges();
    }
    void LoadGrid()
    {
        //string TenDN = Session["UserName"].ToString();
        //var c = from p in db.Teachers
        //        where p.UserName == TenDN
        //        select p.TeacherID;
        //Score sr = new Score();
        var c = from i in
                    (from p in db.Scores where p.SchoolYearID==int.Parse(cboNam.SelectedItem.Value.ToString())
                     &&p.ClassID==int.Parse(cboLop.SelectedItem.Value.ToString())
                     &&p.SubjectID==int.Parse(cboMonHoc.SelectedItem.Value.ToString())
                     select new { p.SchoolYearID, p.SchoolYear.SchoolYearName, p.ClassID, p.Class.ClassName, p.SemesterID, p.Semester.SemesterName, p.SubjectID, p.Subject.SubjectName })
                    group i by new { i.SchoolYearID, i.SchoolYearName, i.ClassID, i.ClassName, i.SemesterID, i.SemesterName, i.SubjectID, i.SubjectName }
                    into gr
                    select new { gr.Key.ClassID, gr.Key.ClassName, gr.Key.SchoolYearID, gr.Key.SchoolYearName, gr.Key.SemesterID, gr.Key.SemesterName, gr.Key.SubjectID, gr.Key.SubjectName };
        grvNhapDiem.DataSource = c;
        grvNhapDiem.DataBind();
 
    }
    string MaTuTang()
    {
        string madiem = "";
        List<string> list = new List<string>();
        string[] a = DateTime.Now.ToShortDateString().Split('/');
        string dau = a[2].Substring(2, 2) + a[0] + a[1];
        string madautien = dau + "000001";
        var c = from p in db.Scores select p.ScoreID;
        //string chuoi = "";
        foreach (var con in c)
        {

            if (con.Trim().Substring(0, 6) == dau)
            {
                list.Add(con.Trim());
            }
        }
        if (list.Count == 0)
        {
            madiem = madautien;
        }
        else
            if (list.Count > 0)
            {

                madiem = (Int64.Parse(list[list.Count - 1]) + 1).ToString();

            }
        //madiem = madautien;
        return madiem;

    }
    void Refresh()
    {
        //txtMaDiem.Text = "";
        txtDiem.Text = "";
        //cls.MaTuTang(txtMaDiem.Text,list);
        MaTuTang();
       // txtMaDiem.Enabled = false;
    }
    bool kiemtratrong()
    {
        bool kt = true;
        lblThongBao.InnerText = "";
        if (cboNam.Text == "" || cboLop.Text == "" || cboKy.Text == "" || cboTenHS.Text == "" || cboMonHoc.Text == "")
        {
            kt = false;
        }
        return kt;
    }
    bool kiemtratrongexcel()
    {
        bool kt = true;
        lblThongBao.InnerText = "";
        if (cboNam.Text == "" || cboLop.Text == "" || cboKy.Text == ""|| cboMonHoc.Text == "")
        {
            kt = false;
        }
        return kt;
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        if (kiemtratrong() == true)
        {
            //ImportFromExcel();
            if (kiemtrasodiem(cboLoaiDiem.SelectedItem.Value.ToString()) == true)
            {
                Them();
                LoadGrid();
                Refresh();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Loại điểm này đã nhập đủ,Vui lòng nhập lại loại điểm khác!');", true);
                cboLoaiDiem.Focus();
            }
        }
        else lblThongBao.InnerText = "Các trương thông tin không được để trống";
       
    }
    protected void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        
    }
    protected void cboLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TenDN = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == TenDN
                select p.TeacherID;
        LoadCBMon(c.First());
        LoadComBoxHS();
        
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Refresh();
        LoadGrid();
    }
    void LoadMaHS()
    {
        var c = from p in db.Students
                where p.StudentID == cboTenHS.SelectedItem.Value.ToString()
                select p.StudentID;
        if (c.Count() != 0)
        {
            lblMaHS.Text = c.First().ToString();
        }
    }
    protected void cboTenHS_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadMaHS();
    }
    protected void grvNhapDiem_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string url = "";
      

    }
    bool kiemtrasodiem(string loaidiem)
    {
        bool kt = true;
        var c = from p in db.Scores
                where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString()) &&
                    p.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString()) &&
                    p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                    p.SubjectID == int.Parse(cboMonHoc.SelectedItem.Value.ToString()) &&
                    p.StudentID == cboTenHS.SelectedItem.Value.ToString() &&
                    p.TypeScoreID == int.Parse(loaidiem)
                select p.Score1;
        if (int.Parse(loaidiem) == 1||int.Parse(loaidiem)==2)
        {
            if (c.Count() == 4)
            {
                kt = false;
            }
        }
        if (int.Parse(loaidiem) == 3)
        {
            if (c.Count() == 2)
                kt = false;
        }
        if (int.Parse(loaidiem) == 4 || int.Parse(loaidiem) == 5)
        {
            if (c.Count() == 1)
                kt = false;
        }
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Điểm này đã nhập đủ!');", false);
        //    kt = false;
        //}
        return kt;
    }
    protected void grvNhapDiem_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grvNhapDiem_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
       
    }
    protected void grvNhapDiem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvNhapDiem.PageIndex = e.NewPageIndex;
        this.LoadGrid();
    }
    // nhập điểm từ excel
    int kiemtradiem(int hang, int cot, DataTable dt,int loaidiem)
    {
       // bool kt = true;
        var c = (from p in db.Scores
                where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString()) &&
                    p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                    p.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString()) &&
                    p.TypeScoreID == loaidiem &&
                    p.SubjectID == int.Parse(cboMonHoc.SelectedItem.Value.ToString()) &&
                    p.StudentID == dt.Rows[hang][1].ToString()
                select new { p.Score1, p.ScoreID }).Count();
        return c;
    }
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
                for (int i = 4; i < dt.Rows.Count; i++)
                {
                    UpdateExcel(1, dt, i, 3, 6);
                    UpdateExcel(2, dt, i, 7, 10);
                    UpdateExcel(3, dt, i, 11, 12);
                    UpdateExcel(4, dt, i, 13, 13);
                    
                    
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
    void UpdateExcel(int loaidiem, DataTable dt, int hang,int ddau,int dcuoi)
    {
        List<double> diem=new List<double>();
        List<double>diemexcel=new List<double>();
        List<string > madiem=new List<string>();
        var c=from p in db.Scores where p.SchoolYearID==int.Parse(cboNam.SelectedItem.Value.ToString())&&
              p.ClassID==int.Parse(cboLop.SelectedItem.Value.ToString())&&
              p.SemesterID==int.Parse(cboKy.SelectedItem.Value.ToString())&&
              p.TypeScoreID==loaidiem &&
              p.SubjectID==int.Parse(cboMonHoc.SelectedItem.Value.ToString())&&
              p.StudentID==dt.Rows[hang][1].ToString() 
              select new {p.Score1,p.ScoreID};
        for (int i1 = ddau; i1 <= dcuoi; i1++)
        {
          if (dt.Rows[hang][i1].ToString() != "")
          {
             diemexcel.Add(double.Parse(dt.Rows[hang][i1].ToString()));
          }
        }
        if(c.Count()==0)
        {
            if (diemexcel.Count > 0)
                {
                    for (int i1 = 0; i1 < diemexcel.Count; i1++)
                    {
                        insert(loaidiem, diemexcel[i1], hang, dt);
                    }
                }
        }
        if (c.Count() != 0)
        {
            //int madiem = c.First().ScoreID;
            foreach (var con in c)
            {
                diem.Add(con.Score1);
                madiem.Add(con.ScoreID);
            }
 
            if (diem.Count == 1)
            {
                //int madiem = c.First().ScoreID;
                if (diemexcel.Count > 1)
                {
                    update(diemexcel[0], madiem[0]);
                    for (int i1 = 1; i1 < diemexcel.Count; i1++)
                    {
                        insert(loaidiem, diemexcel[i1], hang, dt);
                    }
                }
                if (diemexcel.Count == 1)
                {
                    update(diemexcel[0], madiem[0]);
                }
                
            }
            if (diem.Count == 2)
            {
                if (diemexcel.Count > 2)
                {
                    
                        update(diemexcel[0],madiem[0]);
                        update(diemexcel[1], madiem[1]);
                    
                    for (int i1 = 2; i1 < diemexcel.Count; i1++)
                    {
                        insert(loaidiem, diemexcel[i1], hang, dt);
                    }
                }
                if (diemexcel.Count == 2)
                {

                    update(diemexcel[0], madiem[0]);
                    update(diemexcel[1], madiem[1]);
                }
                if (diemexcel.Count == 1)
                {
                    update(diemexcel[0], madiem[0]);
                    delete(madiem[1]);
                }
            }
            if (diem.Count == 3)
            {
                if (diemexcel.Count > 3)
                {
                    update(diemexcel[0], madiem[0]);
                    update(diemexcel[1], madiem[1]);
                    update(diemexcel[2], madiem[2]);
                    for (int i1 = 3; i1 < diemexcel.Count; i1++)
                    {
                        insert(loaidiem, diemexcel[i1], hang, dt);
                    }
                }
                if (diemexcel.Count == 3)
                {

                    update(diemexcel[0], madiem[0]);
                    update(diemexcel[1], madiem[1]);
                    update(diemexcel[2], madiem[2]);
                }
                if (diemexcel.Count == 2)
                {
                    update(diemexcel[0], madiem[0]);
                    update(diemexcel[1], madiem[1]);
                    delete(madiem[2]);
                }
                if (diemexcel.Count == 1)
                {
                    update(diemexcel[0], madiem[0]);
                    delete(madiem[1]);
                    delete(madiem[2]);
                }
            }
            if (diem.Count >= 4)
            {
                if (diemexcel.Count == 4)
                {
                    update(diemexcel[0], madiem[0]);
                    update(diemexcel[1], madiem[1]);
                    update(diemexcel[2], madiem[2]);
                    update(diemexcel[3], madiem[3]);

                }
                if (diemexcel.Count == 3)
                {
                    update(diemexcel[0], madiem[0]);
                    update(diemexcel[1], madiem[1]);
                    update(diemexcel[2], madiem[2]);
                    delete(madiem[3]);
                }
                if (diemexcel.Count == 2)
                {
                    update(diemexcel[0], madiem[0]);
                    update(diemexcel[1], madiem[1]);
                    delete(madiem[2]);
                    delete(madiem[3]);
                }
                if (diemexcel.Count == 2)
                {
                    update(diemexcel[0], madiem[0]);
                   delete(madiem[1]);
                    delete(madiem[2]);
                    delete(madiem[3]);
                }
            }
        }
     
        
    }
    void update(double diem,string madiem)
    {
        Score sc = db.Scores.SingleOrDefault(p => p.ScoreID.Trim() == madiem);
        sc.Score1 = diem;
        db.SubmitChanges();
    }
    void delete(string  madiem)
    {
        Score sc = db.Scores.SingleOrDefault(p => p.ScoreID == madiem);
        db.Scores.DeleteOnSubmit(sc);
        db.SubmitChanges();
    }
    void insert(int loaidiem, double diem, int hang, DataTable dt)
    {
        Score sc = new Score();
        sc.ScoreID = MaTuTang();
        sc.ClassID = int.Parse(cboLop.SelectedItem.Value.ToString());
        sc.SchoolYearID = int.Parse(cboNam.SelectedItem.Value.ToString());
        sc.SemesterID = int.Parse(cboKy.SelectedItem.Value.ToString());
        sc.SubjectID = int.Parse(cboMonHoc.SelectedItem.Value.ToString());
        sc.StudentID = dt.Rows[hang][1].ToString();
        sc.TypeScoreID = loaidiem;
        sc.Score1 = diem;
        db.Scores.InsertOnSubmit(sc);
        db.SubmitChanges();
    }
    void nhapexcel(int loaidiem,int cot,DataTable dt,int hang)
    {
       Score  sc = new Score();
        sc.ScoreID = MaTuTang();
        sc.ClassID = int.Parse(cboLop.SelectedItem.Value.ToString());
        sc.SchoolYearID = int.Parse(cboNam.SelectedItem.Value.ToString());
        sc.SemesterID = int.Parse(cboKy.SelectedItem.Value.ToString());
        sc.SubjectID = int.Parse(cboMonHoc.SelectedItem.Value.ToString());
        sc.StudentID = dt.Rows[hang][1].ToString();
        sc.TypeScoreID = loaidiem;
        sc.Score1 = float.Parse(dt.Rows[hang][cot].ToString());
        db.Scores.InsertOnSubmit(sc);
        db.SubmitChanges();

    }
        protected void cboNam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TenDN = Session["UserName"].ToString();
            var c = from p in db.Teachers
                    where p.UserName == TenDN
                    select p.TeacherID;
            loadCBKyTheoGiaoVien(c.First());
            LoadCBLopTheoGiaoVien(c.First());
                //cls.LoadCbLop(cboLop, cboNam.SelectedItem.Value.ToString());
                LoadCBMon(c.First());
                LoadComBoxHS();
                LoadMaHS();
            
        }
        protected void btnNhapEcel_Click(object sender, EventArgs e)
        {
            if (kiemtratrongexcel() == true)
            {
                if (fuNhapExcel.HasFile)
                {

                    string path = Server.MapPath("..\\upload") + "\\" + fuNhapExcel.FileName;
                    fuNhapExcel.SaveAs(path);
                    ImportFromExcel(path);
                    LoadGrid();
                    lblNhapExcel.InnerText = "";

                }
                else if (!fuNhapExcel.HasFile)
                {
                    lblNhapExcel.InnerText = "Bạn phải chọn đường dẫn!";
                }
            }
            else lblThongBao.InnerText = "Các trường thông tin không được để trống";
        }
        protected void cboKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TenDN = Session["UserName"].ToString();
            var c = from p in db.Teachers
                    where p.UserName == TenDN
                    select p.TeacherID;
            LoadCBLopTheoGiaoVien(c.First());
            LoadComBoxHS();
            LoadCBMon(c.First());
            LoadMaHS();
        }
}
