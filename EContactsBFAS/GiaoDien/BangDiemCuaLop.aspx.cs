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
using iTextSharp.text;
using System.IO;
using System.Text;


public partial class GiaoDien_BangDiemCuaLop : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    LinQ lq = new LinQ();
    clsThaoTac cls = new clsThaoTac();
    BangDiem bd = new BangDiem();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        if (!IsPostBack)
        {
            //cls.LoadComboxNam(cboNam);
            cls.LoadCBNamTheoGV1(c.First(),cboNam);
            cls.LoadComBoxKy(cboKy);
            cls.LoadCBLopTheoGV1(c.First(),cboLop,cboNam);
            cboKy.Items.Add("Cả năm");
            //cls.LoadCbLop(cboLop, cboNam.SelectedItem.Value.ToString());
        }
    }

   
   
   
   //void LoadDiemCuaLop(string manam,string maky,string malop)
   // {
        
   //     dt = new DataTable();
   //     dt.Columns.Add("MaHS",typeof(string));
   //     dt.Columns.Add("TenHS", typeof(string));
   //     dt.Columns.Add("Toan",typeof(string));
      
   //     dt.Columns.Add("Van", typeof(string));
   //     dt.Columns.Add("Ly", typeof(string));
   //     dt.Columns.Add("Hoa", typeof(string));
   //     dt.Columns.Add("LichSu", typeof(string));
   //     dt.Columns.Add("DiaLy", typeof(string));
   //     dt.Columns.Add("Sinh", typeof(string));
   //     dt.Columns.Add("NgoaiNgu", typeof(string));
   //     dt.Columns.Add("GDCD", typeof(string));
   //     dt.Columns.Add("Tin", typeof(string));
        
   //     dt.Columns.Add("CongNghe", typeof(string));
   //     dt.Columns.Add("TheDuc", typeof(string));
   //     dt.Columns.Add("GDQP", typeof(string));
   //     dt.Columns.Add("DTB", typeof(string));
   //     //dt.Columns.Add("Toan", typeof(string));
   //     // select masinhvien trong nam học nay có kỳ học này và lớp học này
   //     var c0 = from i in
   //                 (from p in db.Scores
   //                  where p.SemesterID == int.Parse(maky) &&
   //                      p.SchoolYearID == int.Parse(manam) &&
   //                      p.ClassID == int.Parse(malop)
   //                  select new { p.StudentID, p.Student.StudentName })
   //             group i by new { i.StudentID, i.StudentName } into g
   //             select new { g.Key.StudentID, g.Key.StudentName };
        
   //     foreach (var con in c0)
   //     {
   //         DataTable dtmon = new DataTable();
   //         dtmon.Columns.Add("MaMon", typeof(string));
   //         dtmon.Columns.Add("TenMon", typeof(string));
   //         dtmon.Columns.Add("DM", typeof(string));
   //         dtmon.Columns.Add("D15p", typeof(string));
   //         dtmon.Columns.Add("D45p", typeof(string));
   //         dtmon.Columns.Add("DHK", typeof(string));
   //         dtmon.Columns.Add("DTB", typeof(string));
        
   //         DataRow row1 = dt.NewRow();
   //         row1[0] = con.StudentID;
   //         row1[1] = con.StudentName;
            
   //         var ban=(from p in db.ClassDepartments where p.ClassID==int.Parse(malop)&&p.SchoolYearID==int.Parse(manam)
   //                   select p.DepartmentID).First();
   //         var c1 = from i in
   //                     (from p in db.Scores
   //                      where p.SchoolYearID == int.Parse(manam) &&
   //                      p.ClassID == int.Parse(malop) &&
   //                      p.StudentID == con.StudentID &&
   //                      p.SemesterID == int.Parse(maky)
   //                      select new { p.SubjectID, p.Subject.SubjectName })
   //                 group i by new { i.SubjectID, i.SubjectName } into gr
   //                 select new { gr.Key.SubjectID, gr.Key.SubjectName };
   //         foreach (var con1 in c1)
   //         {
   //             DataRow row = dtmon.NewRow();
   //             lq.LoadDiemTheoHK(int.Parse(manam), int.Parse(maky), int.Parse(malop), con1.SubjectID, con1.SubjectName, con.StudentID, row);
   //             dtmon.Rows.Add(row);
   //         }
   //         double diem=0 ;
   //         int hso = 0;
   //         foreach (DataRow rcon in dtmon.Rows)
   //         {
   //             //string mon = rcon[1].ToString();
   //             ////float  p1;
   //             if (rcon[6].ToString() != "")
   //             {
   //                 if (rcon[1].ToString() == "Toán Học")
   //                 {

   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();
   //                     row1[2] = rcon[6].ToString();
   //                     string s = row1[2].ToString();
   //                     ////Response.Write(s);
   //                     diem = diem + float.Parse(s) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     // }

   //                 }
   //                 if (rcon[1].ToString() == "Ngữ Văn")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();
   //                     row1[3] = rcon[6].ToString();

   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }

   //                 if (rcon[1].ToString() == "Vật Lý")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[4] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Hóa Học")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[5] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Lịch Sử")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[6] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Địa Lý")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[7] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Sinh Học")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[8] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Ngoại Ngữ")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[9] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Giáo dục công dân")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[10] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Tin Học")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[11] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "Công Nghệ")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[12] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}
   //                 }


   //                 if (rcon[1].ToString() == "Thể Dục")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[13] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 if (rcon[1].ToString() == "GDQP")
   //                 {
   //                     //if (rcon[6].ToString() != "")
   //                     //{
   //                     var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

   //                     row1[14] = rcon[6].ToString();
   //                     diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
   //                     hso = hso + int.Parse(c.ToString());
   //                     //}

   //                 }
   //                 List<string> day = new List<string>();
   //                 for (int i = 2; i < 15; i++)
   //                 {
   //                     if (row1[i].ToString() != "")
   //                     {
   //                         day.Add(row1[i].ToString());
   //                     }
   //                 }
   //                 var somon = from p in db.DepartmentSubjects where p.DepartmentID == ban select p.SubjectID;
   //                 if (day.Count == somon.Count())
   //                 { row1[15] = lq.LamTronDiem((diem / hso).ToString()); }
   //                 if (day.Count < somon.Count())
   //                 {
   //                     row1[15] = "";
   //                 }


   //                // 
                    
   //             }
                
   //         }
           
   //         dt.Rows.Add(row1);
            
            
   //     }
        
   

   // }

    DataTable dt;
    public DataTable getTable( )
    {
        dt = new DataTable();
        if (cboKy.SelectedItem.Value.ToString() == "1")
        {

            bd.LoadDiemCuaLopTheoKy(cboNam.SelectedItem.Value.ToString(), "1", cboLop.SelectedItem.Value.ToString(), dt);
            //return dt;
        }
        if (cboKy.SelectedItem.Value.ToString() == "2")
        {
            bd.LoadDiemCuaLopTheoKy(cboNam.SelectedItem.Value.ToString(), "2", cboLop.SelectedItem.Value.ToString(), dt);
        }
        if (cboKy.Text == "Cả năm")
        {
            //lq.TongDiemCN(dt, cboNam.SelectedItem.Value.ToString(), cboLop.SelectedItem.Value.ToString());
            dt.Columns.Add("STT", typeof(string));
            dt.Columns.Add("MaHS", typeof(string));
            dt.Columns.Add("TenHS", typeof(string));
            dt.Columns.Add("Toan", typeof(string));

            dt.Columns.Add("Van", typeof(string));
            dt.Columns.Add("Ly", typeof(string));
            dt.Columns.Add("Hoa", typeof(string));
            dt.Columns.Add("LichSu", typeof(string));
            dt.Columns.Add("DiaLy", typeof(string));
            dt.Columns.Add("Sinh", typeof(string));
            dt.Columns.Add("NgoaiNgu", typeof(string));
            dt.Columns.Add("GDCD", typeof(string));
            dt.Columns.Add("Tin", typeof(string));

            dt.Columns.Add("CongNghe", typeof(string));
            dt.Columns.Add("TheDuc", typeof(string));
            dt.Columns.Add("GDQP", typeof(string));
            dt.Columns.Add("DTB", typeof(string));
            dt.Columns.Add("HL", typeof(string));
            dt.Columns.Add("HK", typeof(string));

            int stt = 0;
            var c = (from p in db.ClassDepartments
                     where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                         p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                     select p.DepartmentID).First();
            DataTable dt1 = new DataTable();

            bd.LoadDiemCuaLopTheoKy(cboNam.SelectedItem.Value.ToString(), "1", cboLop.SelectedItem.Value.ToString(), dt1);

            DataTable dt2 = new DataTable();

            bd.LoadDiemCuaLopTheoKy(cboNam.SelectedItem.Value.ToString(), "2", cboLop.SelectedItem.Value.ToString(), dt2);
            lq.TongDiemCN(dt, dt1, dt2, stt, c);
        
            
        }
        return dt;
    }
    protected void btnHienThi_Click(object sender, EventArgs e)
    {
        lblThongBao.InnerText = "";
        DataTable dtb = getTable();
            grvThanhvien.DataSource = dtb;
            grvThanhvien.DataBind();
        if(grvThanhvien.Rows.Count==0)
        {
            lblThongBao.InnerText = "Hiện tại chưa có điểm";
        }
    }
    string TongMotMonCN(string dk1,string dk2)
    {
        string dcn="";
        if ((dk1 == "" && dk2 != "")||(dk1==null&&dk2!=""))
        {
            dcn = dk2;
        }
        if ((dk1 != "" && dk2 == "")||( dk1!=""&&dk2==null))
        {
            dcn = dk1;
        }
        if (dk1 != "" && dk2 != "")
        {
            dcn=lq.LamTronDiem(((float.Parse(dk1)+float.Parse(dk2)*2)/3).ToString());
        }
        if ((dk1 == "" && dk2 == "")||(dk1==null&&dk2==null)||(dk1==""&&dk2==null)||(dk1==null&&dk2==""))
        {
            dcn = "";
        }
        return dcn;
    }
    //string TKCN()
    //{
 
    //}

    void XuatDLRaExcel(GridView grv)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.doc");
        Response.Charset = string.Empty;
        Response.ContentType = "application/vnd.ms-word";
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
    void ExporttuDataTable(string fileName,DataTable dt)
    {
        Response.ContentType = "application/csv";
    Response.Charset = "";
    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
    Response.ContentEncoding = Encoding.Unicode;
    Response.BinaryWrite(Encoding.Unicode.GetPreamble());
    DataTable dtb = getTable();
   // Response.Write(dtb.ToString());
    try
    {
        StringBuilder sb = new StringBuilder();
        
        sb.Append("Năm học:" + "\t"+cboNam.SelectedItem.Text);
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
        sb.Append("STT"+"\t"+"Mã HS" + "\t" + "Tên HS" + "\t" + "Toán" + "\t" + "Ngữ Văn" + "\t" + "Vật Lý" + "\t" + "Hóa học" + "\t" + "Lịch sử" + "\t" + "Địa lý"
        + "\t" + "Sinh học" + "\t" + "Ngoại ngữ" + "\t" + "GDCD" + "\t" + "Tin học" + "\t" + "Công nghệ" + "\t" + "Thể dục" + "\t" + "GDQP" + "\t" + "DTB" + "\t" + "Học lực" );
        Response.Write(sb.ToString() + "\n");
        Response.Flush();
        //Duyệt từng bản ghi 
        int soDem = 0;
        while (dtb.Rows.Count >= soDem + 1)
        {
            sb = new StringBuilder();

            for (int col = 0; col < dtb.Columns.Count-1; col++)
            {
                //if (dt.Rows[soDem][col] != null)
                    sb.Append(dtb.Rows[soDem][col].ToString().Replace(",", " "));
                sb.Append("\t");
            }
            if (dtb.Rows[soDem][dtb.Columns.Count - 1] != null)
                sb.Append(dtb.Rows[soDem][dtb.Columns.Count - 1].ToString().Replace(",", " "));

            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            soDem = soDem + 1;
        }

    }
    catch (Exception ex)
    {
        Response.Write(ex.Message);
    }
    dtb.Dispose();
    Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //Xác nhận điều khiển HtmlForm tại thời gian chạy ASP.NET
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //XuatDLRaExcel(grvThanhvien);
        ExporttuDataTable("NguNgoc.xls",dt);
    }
    protected void cboNam_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls.LoadCbLop(cboLop, cboNam.SelectedItem.Value.ToString());
    }
    protected void grvThanhvien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvThanhvien.PageIndex = e.NewPageIndex;
        this.getTable();
    }
}
