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
using System.IO;
using System.Data.OleDb;

public partial class GiaoDien_NhapHSTheoLopExcel : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblThongBao.InnerText = "";
            LoadCBNamHoc();
            if (cboNamHoc.Text != "")
            {
                LoadCBLop();
            }
            else { lblThongBao.InnerText = "Hiện tại chưa có thông tin năm học mới"; }
        }
    }
    void LoadCBNamHoc()
    {
        var c = from i in
                    (from p in db.ClassDepartments
                     where p.SchoolYear.BeginDate.Value.Date <= DateTime.Now.Date
                     && p.SchoolYear.EndDate >= DateTime.Now.Date
                     select new { p.SchoolYear.SchoolYearName, p.SchoolYearID })
                group i by new { i.SchoolYearID, i.SchoolYearName } into grp
                select new { grp.Key.SchoolYearID,grp.Key.SchoolYearName};
        if (c.Count() != 0)
        {
            cboNamHoc.DataTextField = "SchoolYearName";
            cboNamHoc.DataValueField = "SchoolYearID";
            cboNamHoc.DataSource = c;
            cboNamHoc.DataBind();
        }

    }
    void LoadCBLop()
    {
        var c = from p in db.ClassDepartments
                where p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                select new { p.ClassID, p.Class.ClassName };
        if (c.Count() != 0)
        {
            cboTenLop.DataTextField = "ClassName";
            cboTenLop.DataValueField = "ClassID";
            cboTenLop.DataSource = c;
            cboTenLop.DataBind();
        }

    }
    bool kiemtratrongexcel()
    {
        bool kt = true;
        lblThongBao.InnerText = "";
        if (cboNamHoc.Text == "" || cboTenLop.Text =="")
        {
            kt = false;
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
            DataTable dt = ds.Tables[0];
            for (int i = 3; i < dt.Rows.Count; i++)
            {
                int c = (from p in db.Students where p.StudentID == dt.Rows[i][1].ToString() select p).Count();
                if (c == 0)
                {
                    Student st = new Student();
                    st.StudentID = dt.Rows[i][1].ToString();

                    st.StudentName = dt.Rows[i][2].ToString();
                    st.Gender = dt.Rows[i][4].ToString();
                    st.DateOfBirth = DateTime.Parse(dt.Rows[i][3].ToString());
                    st.Address = dt.Rows[i][5].ToString();
                    //st.PhoneFixe = dt.Rows[i][6].ToString();
                    //st.MobilePhone = dt.Rows[i][7].ToString();
                    db.Students.InsertOnSubmit(st);
                    db.SubmitChanges();
                    int c1 = (from p in db.ClassStudents
                              where p.StudentID == dt.Rows[i][1].ToString()
                              && p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                              && p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString())
                              select p).Count();
                    //if (kiemtra(dt.Rows[i][1].ToString()) == true)
                    //{
                    if (c1 == 0)
                    {
                        ClassStudent clst = new ClassStudent();
                        clst.SchoolYearID = int.Parse(cboNamHoc.SelectedItem.Value.ToString());
                        clst.ClassID = int.Parse(cboTenLop.SelectedItem.Value.ToString());
                        clst.StudentID = dt.Rows[i][1].ToString();
                        db.ClassStudents.InsertOnSubmit(clst);
                        db.SubmitChanges();
                    }
                    //LoadGrid();
                }
                if (c != 0)
                {
                    Student st = db.Students.SingleOrDefault(p => p.StudentID == dt.Rows[i][1].ToString());
                    st.StudentName = dt.Rows[i][2].ToString();
                    st.Gender = dt.Rows[i][4].ToString();
                    st.DateOfBirth = DateTime.Parse(dt.Rows[i][3].ToString());
                    st.Address = dt.Rows[i][5].ToString();
                    //st.PhoneFixe = dt.Rows[i][6].ToString();
                    //st.MobilePhone = dt.Rows[i][7].ToString();
                    db.SubmitChanges();
                    int c1 = (from p in db.ClassStudents
                              where p.StudentID == dt.Rows[i][1].ToString()
                              && p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                              && p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString())
                              select p).Count();
                    //if (kiemtra(dt.Rows[i][1].ToString()) == true)
                    //{
                    if (c1 == 0)
                    {
                        ClassStudent clst = new ClassStudent();
                        clst.SchoolYearID = int.Parse(cboNamHoc.SelectedItem.Value.ToString());
                        clst.ClassID = int.Parse(cboTenLop.SelectedItem.Value.ToString());
                        clst.StudentID = dt.Rows[i][1].ToString();
                        db.ClassStudents.InsertOnSubmit(clst);
                        db.SubmitChanges();
                    }

                }
                
                
                    //else if (c1 != 0)
                    //{
                    //    ClassStudent cl = db.ClassStudents.SingleOrDefault(p => p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString()) &&
                    //        p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString()) &&
                    //        p.StudentID == dt.Rows[i][1].ToString());

                    //}
                //}
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
    void LoadGrid()
    {
        var c = from p in db.ClassStudents
                where p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                && p.ClassID == int.Parse(cboTenLop.SelectedItem.Value.ToString())
                select new { p.StudentID, p.Student.StudentName,p.Student.Address, p.Student.Gender, p.Student.DateOfBirth };
        if (c.Count() != 0)
        {
            grvHocSinh.DataSource = c;
            grvHocSinh.DataBind();
        }
    }
    bool kiemtra(string mahs)
    {
        bool kt = true;
        var c = from p in db.ClassStudents
                where p.ClassID != int.Parse(cboTenLop.SelectedItem.Value.ToString())
                && p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                &&p.StudentID==mahs
                select new { p.SchoolYearID,p.ClassID,p.StudentID};
        if (c.Count() != 0)
        {
            kt = false;

        }
        return kt;

    }
    protected void btnNhapExcel_Click(object sender, EventArgs e)
    {
        if (fuDSHS.HasFile == true)
        {
            if (CheckFileType(fuDSHS.FileName) == true)
            {

                string path = Server.MapPath("..\\upload") + "\\" + fuDSHS.FileName;
                fuDSHS.SaveAs(path);
                ImportFromExcel(path);
            }
            else
            {
                lblThongBao.InnerText = "File nhập không đúng định dạng!";
            }
        }
        else { lblThongBao.InnerText = "Bạn phải nhập đường dẫn"; }
                
    }
}
