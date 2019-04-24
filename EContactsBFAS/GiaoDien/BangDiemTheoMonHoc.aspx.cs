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
using System.Text;
using System.Collections.Generic;

public partial class GiaoDien_BangDiemTheoMonHoc : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    LinQ lq = new LinQ();
    BangDiem bdiem = new BangDiem();
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
                
                //cls.LoadCbLop(cboLop,cboNam.SelectedItem.Value.ToString());
                //cls.LoadComBoxKy(cboKy);
                loadCBKyTheoGiaoVien(c.First());
                LoadCBLopTheoGiaoVien(c.First());
                LoadCBMon(c.First());
                LoadComBoxHS();
                //LoadCBMon();
                //LoadGridTheoTen();
            }
            else
            {
                lblThongBao.InnerText = "Bạn chưa được phân công dạy";
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
                select new { gr.Key.SemesterID, gr.Key.SemesterName };
        if (c.Count() != 0)
        {
            cboKy.DataTextField = "SemesterName";
            cboKy.DataValueField = "SemesterID";
            cboKy.DataSource = c;
            cboKy.DataBind();
        }
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
            cboMaHS.DataTextField = "StudentName";
            cboMaHS.DataValueField = "StudentID";
            cboMaHS.DataSource = c;
            cboMaHS.DataBind();
        }
    }
    //void LoadCBMon()
    //{
    //    var c = from p in db.ClassDepartments
    //            where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
    //            p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
    //            select p.DepartmentID;
    //    if (c.Count() != 0)
    //    {
    //        var c1 = from p1 in db.DepartmentSubjects
    //                 where p1.DepartmentID == c.First()
    //                 select new { p1.SubjectID, p1.Subject.SubjectName };
    //        if (c1.Count() != 0)
    //        {
    //            cboMon.DataTextField = "SubjectName";
    //            cboMon.DataValueField = "SubjectID";
    //            cboMon.DataSource = c1;
    //            cboMon.DataBind();
    //        }
    //    }
    //}
    void LoadCBMon(string maGV)
    {

        //var c = from p in db.ClassDepartments
        //        where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
        //        p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
        //        select p.DepartmentID;
        var c1 = from p1 in db.TeacherSubjects
                 where p1.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString())
                 && p1.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                 && p1.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString())
                 && p1.TeacherID == maGV
                 select new { p1.SubjectID, p1.Subject.SubjectName };
        if (c1.Count() != 0)
        {
            cboMon.DataTextField = "SubjectName";
            cboMon.DataValueField = "SubjectID";
            cboMon.DataSource = c1;
            cboMon.DataBind();
        }
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
    DataTable dt;
    void LoadGridTheoTen()
    {
        dt = new DataTable();
        dt.Columns.Add("MaHS", typeof(string));
        dt.Columns.Add("TenHS", typeof(string));
        dt.Columns.Add("DM", typeof(string));
        dt.Columns.Add("D15p", typeof(string));
        dt.Columns.Add("D45p", typeof(string));
        dt.Columns.Add("DHK", typeof(string));

        dt.Columns.Add("DTB", typeof(string));
        dt.Columns.Add("DTL", typeof(string));
        //dt.Columns.Add("DTBL", typeof(string));
        DataRow row = dt.NewRow();
        
        lq.LoadDiemTheoMon(int.Parse(cboNam.SelectedItem.Value.ToString()), int.Parse(cboKy.SelectedItem.Value.ToString()), int.Parse(cboLop.SelectedItem.Value.ToString()), int.Parse(cboMon.SelectedItem.Value.ToString()), cboMaHS.SelectedItem.Value.ToString(), cboMaHS.SelectedItem.Text, row);
        dt.Rows.Add(row);
        grvThanhvien.DataSource = dt;
        grvThanhvien.DataBind();
    }
    void LoadGridTheoMon()
    {
        dt = new DataTable();
        dt.Columns.Add("MaHS", typeof(string));
        dt.Columns.Add("TenHS", typeof(string));
        dt.Columns.Add("DM", typeof(string));
        dt.Columns.Add("D15p", typeof(string));
        dt.Columns.Add("D45p", typeof(string));
        dt.Columns.Add("DHK", typeof(string));
        
        dt.Columns.Add("DTB", typeof(string));
        dt.Columns.Add("DTL", typeof(string));
       // dt.Columns.Add("DTBL", typeof(string));

        var c = from i in
                    (from p in db.Scores
                     where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString()) &&
                     p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                     p.SubjectID == int.Parse(cboMon.SelectedItem.Value.ToString()) &&
                     p.SemesterID == int.Parse(cboKy.SelectedItem.Value.ToString())
                     select new { p.StudentID, p.Student.StudentName })
                group i by new { i.StudentID, i.StudentName } into gr
                select new {gr.Key.StudentID,gr.Key.StudentName };
        

        foreach (var con in c)
        {
            DataRow row = dt.NewRow();
            ////row[0] = con.StudentID;
            ////row[1] = con.StudentName;
            lq.LoadDiemTheoMon(int.Parse(cboNam.SelectedItem.Value.ToString()), int.Parse(cboKy.SelectedItem.Value.ToString()), int.Parse(cboLop.SelectedItem.Value.ToString()), int.Parse(cboMon.SelectedItem.Value.ToString()), con.StudentID, con.StudentName, row);
            dt.Rows.Add(row);
            
        }
        grvThanhvien.DataSource = dt;
        grvThanhvien.DataBind();
        
    }
    protected void optHS_CheckedChanged(object sender, EventArgs e)
    {
        
        
    }

    void XuatDLRaExcel(GridView grv)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = string.Empty;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        StringWriter sw = new StringWriter();
        HtmlTextWriter html = new HtmlTextWriter(sw);
        grv.AllowPaging = false;
        grv.DataBind();
        grv.RenderControl(html);
        string style = @"";
        Response.Write(style);
        Response.Output.Write(sw.ToString());

        Response.Flush();
        Response.End();
    }
    void ExportToExcel(string fileName, GridView grv)
    {
        Response.ContentType = "application/csv";
        Response.Charset = "";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        //DataTable dtb = getTable();
        //Response.Write(grv.to);
        try
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Năm học:" + "\t" + cboNam.SelectedItem.Text);
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("Học kỳ:" + "\t" + cboKy.SelectedItem.Text);
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("Lớp học:" + "\t" + cboLop.SelectedItem.Text);
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("Môn học:" + "\t" + cboMon.SelectedItem.Text);
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("STT" + "\t" + "Mã HS" + "\t" + "Tên HS" + "\t" + "M1" + "\t" + "M2" + "\t" + "M3" + "\t" + "M4" + "\t" + " 15'1" + "\t" + " 15'2" + "\t" + " 15'3" + "\t" + " 15'4" + "\t" + "45'1" + "\t" + "45'2" + "\t" + "HK" + "\t" + "Điểm TB");
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            //Duyệt từng bản ghi 
            //int soDem = 0;
            
            foreach (GridViewRow row in grv.Rows)
            { List<string> sodiem;
                sb = new StringBuilder();
                Label lblSTT = (Label)row.FindControl("lblSTT");
                if (lblSTT.Text != "")
                {
                    sb.Append(lblSTT.Text);
                    sb.Append("\t");
                }
                else if (lblSTT.Text == "" || lblSTT.Text == null)
                {
                    sb.Append(""); sb.Append("\t");
                }
                Label lblMaHS = (Label)row.FindControl("lblMaHS");
                if (lblMaHS.Text != "")
                {
                    sb.Append(lblMaHS.Text);
                    sb.Append("\t");
                }
                if (lblMaHS.Text == "" || lblMaHS.Text == null)
                {
                    sb.Append(""); sb.Append("\t");
                }
                Label lblTenHS = (Label)row.FindControl("lblTenHS");
                if (lblTenHS.Text != "")
                {
                    sb.Append(lblTenHS.Text);
                    sb.Append("\t");
                }
                if (lblTenHS.Text == "" || lblTenHS.Text == null)
                {
                    sb.Append(""); sb.Append("\t");
                }
                Label lblDM = (Label)row.FindControl("lblDM");
                if (lblDM.Text != "")
                {
                    sodiem=new List<string>();
                    tachdiem(lblDM.Text, sodiem);
                    for (int i = 0; i < sodiem.Count; i++)
                    {
                        sb.Append(sodiem[i]);
                        sb.Append("\t");
                    }
                    for (int j = 0; j < 4 - sodiem.Count; j++)
                    {
                        sb.Append("");
                        sb.Append("\t");
                    }
                }
                if (lblDM.Text == "" || lblDM.Text == null)
                {
                    for (int i1 = 0; i1 < 4; i1++)
                    {
                        sb.Append("");
                        sb.Append("\t");
                    }
                }
                Label lblD15p = (Label)row.FindControl("lblD15p");
                if (lblD15p.Text != "")
                {
                    sodiem = new List<string>();
                    tachdiem(lblD15p.Text, sodiem);
                    for (int i = 0; i < sodiem.Count; i++)
                    {
                        sb.Append(sodiem[i]);
                        sb.Append("\t");
                    }
                    for (int j = 0; j < 4 - sodiem.Count; j++)
                    {
                        sb.Append("");
                        sb.Append("\t");
                    }
                   
                }
                if (lblD15p.Text == "" || lblD15p.Text == null)
                {
                    for (int i1 = 0; i1 < 4; i1++)
                    {
                        sb.Append("");
                        sb.Append("\t");
                    }
                }
                Label lblD45p = (Label)row.FindControl("lblD45p");
                if (lblD45p.Text != "")
                {
                    sodiem = new List<string>();
                    tachdiem(lblD45p.Text, sodiem);
                    if ((2 - sodiem.Count) == 0)
                    {
                        for (int i = 0; i < sodiem.Count; i++)
                        {
                            sb.Append(sodiem[i]);
                            sb.Append("\t");
                        }
                    }
                    if ((2 - sodiem.Count) == 1)
                    {
                        sb.Append(sodiem[0]);
                        sb.Append("\t");
                        sb.Append("");
                        sb.Append("\t");
                    }
                    
                    
                }
                if (lblD45p.Text == "" || lblD45p.Text == null)
                {
                    for (int i1 = 0; i1 < 2;i1++)
                    {
                        sb.Append("");
                        sb.Append("\t");
                    }
                }
                Label lblDHK = (Label)row.FindControl("lblDHK");
                if (lblDHK.Text != "")
                {
                    sb.Append(lblDHK.Text);
                    sb.Append("\t");
                }
                if (lblDHK.Text == "" || lblDHK.Text == null)
                {
                    sb.Append(""); sb.Append("\t");
                }
                Label lblDTB = (Label)row.FindControl("lblDTB");
                if (lblDTB.Text != "")
                {
                    sb.Append(lblDTB.Text);
                    
                }
                if (lblDTB.Text == "" || lblDTB.Text == null)
                {
                    sb.Append("");
                }
                
                Response.Write(sb.ToString() + "\n");
                Response.Flush();

            }
           

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        grv.Dispose();
        Response.End();

    }
    void tachdiem(string diem,List<string> sodiem)
    {
        //List<string> sodiem = new List<string>();   
        if (diem.Contains(';') == true)
        {
            string[] diemtach = diem.Split(';');
            for (int i = 0; i < diemtach.Length; i++)
            {
                sodiem.Add(diemtach[i]);
            }
        }
        if (diem.Contains(';') == false)
        {
            sodiem.Add(diem);
        }
    }
    protected void optLop_CheckedChanged(object sender, EventArgs e)
    {
        //optHS.Enabled =false;
        //if (optLop.Checked == true)
        //{
            
            
        //    optHS.Enabled = true;
        //}
        
    }
    protected void btnHS_Click(object sender, EventArgs e)
    {
        LoadGridTheoTen();
    }
    protected void btnMon_Click(object sender, EventArgs e)
    {
        LoadGridTheoMon();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //Xác nhận điều khiển HtmlForm tại thời gian chạy ASP.NET
    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel("MonHoc.xls", grvThanhvien);
        //XuatDLRaExcel(grvThanhvien);
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

    }
    protected void cboMon_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cboKy_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TenDN = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == TenDN
                select p.TeacherID;
        LoadCBLopTheoGiaoVien(c.First());
        LoadCBMon(c.First());
        LoadComBoxHS();
    }
    protected void grvThanhvien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //grvThanhvien.PageIndex = e.NewSelectedIndex;
        //this.LoadGridTheoMon();
    }
    protected void grvThanhvien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvThanhvien.PageIndex = e.NewPageIndex;
        this.LoadGridTheoMon();
    }
}
