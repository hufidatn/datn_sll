using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for BangDiem
/// </summary>
public class BangDiem
{
    EContactDataContext db = new EContactDataContext();
    LinQ lq = new LinQ();
	public BangDiem()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  public void LoadDiemCuaLopTheoKy(string manam, string maky, string malop,DataTable dt)
    {
        int stt = 0;

       // dt = new DataTable();
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
        
        //dt.Columns.Add("Toan", typeof(string));
        // select masinhvien trong nam học nay có kỳ học này và lớp học này
        var c0 = from i in
                     (from p in db.Scores
                      where p.SemesterID == int.Parse(maky) &&
                          p.SchoolYearID == int.Parse(manam) &&
                          p.ClassID == int.Parse(malop)
                      select new { p.StudentID, p.Student.StudentName })
                 group i by new { i.StudentID, i.StudentName } into g
                 select new { g.Key.StudentID, g.Key.StudentName };

        foreach (var con in c0)
        {
            DataTable dtmon = new DataTable();
            dtmon.Columns.Add("MaMon", typeof(string));
            dtmon.Columns.Add("TenMon", typeof(string));
            dtmon.Columns.Add("DM", typeof(string));
            dtmon.Columns.Add("D15p", typeof(string));
            dtmon.Columns.Add("D45p", typeof(string));
            dtmon.Columns.Add("DHK", typeof(string));
            dtmon.Columns.Add("DTB", typeof(string));

            DataRow row1 = dt.NewRow();
            stt = stt + 1;
            row1[0] = stt.ToString();
            row1[1] = con.StudentID;
            row1[2] = con.StudentName;
            var hk = from p in db.Conducts
                     where p.ClassID == int.Parse(malop) && p.SchoolYearID == int.Parse(manam)
                         && p.SemesterID == int.Parse(maky) && p.StudentID == con.StudentID
                     select p.Conduct1;
            if (hk.Count() != 0)
            {
                row1[18] = hk.First().ToString();
            }
            else if (hk.Count() == 0)
            {
                row1[18] = "";
            }
            var ban = (from p in db.ClassDepartments
                       where p.ClassID == int.Parse(malop) && p.SchoolYearID == int.Parse(manam)
                       select p.DepartmentID).First();
            var c1 = from i in
                         (from p in db.Scores
                          where p.SchoolYearID == int.Parse(manam) &&
                          p.ClassID == int.Parse(malop) &&
                          p.StudentID == con.StudentID &&
                          p.SemesterID == int.Parse(maky)
                          select new { p.SubjectID, p.Subject.SubjectName })
                     group i by new { i.SubjectID, i.SubjectName } into gr
                     select new { gr.Key.SubjectID, gr.Key.SubjectName };
            foreach (var con1 in c1)
            {
                DataRow row = dtmon.NewRow();
                lq.LoadDiemTheoHK(int.Parse(manam), int.Parse(maky), int.Parse(malop), con1.SubjectID, con1.SubjectName, con.StudentID, row);
                dtmon.Rows.Add(row);
            }
            double diem = 0;
            int hso = 0;
            foreach (DataRow rcon in dtmon.Rows)
            {
                //string mon = rcon[1].ToString();
                ////float  p1;
                if (rcon[6].ToString() != "")
                {
                    if (rcon[1].ToString() == "Toán Học")
                    {

                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();
                        row1[3] = rcon[6].ToString();
                        string s = row1[3].ToString();
                        ////Response.Write(s);
                        diem = diem + float.Parse(s) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        // }

                    }
                    if (rcon[1].ToString() == "Ngữ Văn")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();
                        row1[4] = rcon[6].ToString();

                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }

                    if (rcon[1].ToString() == "Vật Lý")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[5] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Hóa Học")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[6] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Lịch Sử")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[7] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Địa Lý")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[8] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Sinh Học")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[9] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Ngoại Ngữ")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[10] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Giáo dục công dân")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[11] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Tin Học")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[12] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "Công Nghệ")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[13] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}
                    }


                    if (rcon[1].ToString() == "Thể Dục")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[14] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    if (rcon[1].ToString() == "GDQP")
                    {
                        //if (rcon[6].ToString() != "")
                        //{
                        var c = (from p in db.DepartmentSubjects where p.SubjectID == int.Parse(rcon[0].ToString()) select p.Multiplier).First();

                        row1[15] = rcon[6].ToString();
                        diem = diem + float.Parse(rcon[6].ToString()) * int.Parse(c.ToString());
                        hso = hso + int.Parse(c.ToString());
                        //}

                    }
                    List<string> day = new List<string>();
                    for (int i = 3; i < 16; i++)
                    {
                        if (row1[i].ToString() != "")
                        {
                            day.Add(row1[i].ToString());
                        }
                    }
                    // chỗ này cần sửa điều kiện đểhiển thị điiemmr tổng kết
                    var somon = from p in db.DepartmentSubjects where p.DepartmentID == ban select p.SubjectID;
                    if (day.Count == somon.Count())
                    { row1[16] = lq.LamTronDiem((diem / hso).ToString()); }
                    if (day.Count < somon.Count())
                    {
                        row1[16] = "";
                    }


                    // 

                }

            }
            List<string> diemtb = new List<string>();
            List<int> diemToanVan = new List<int>();
            if (row1[16].ToString() != "")
            {
                float dtbhky=float.Parse(row1[16].ToString());
                if (dtbhky >= 8.0 && dtbhky <= 10)
                {
                    for (int i = 3; i <= 15; i++)
                    {
                        if (row1[i].ToString() != "" && row1[i] != null)
                        {
                            if (float.Parse(row1[3].ToString()) >= 8.0 || float.Parse(row1[4].ToString()) >= 8.0)
                            {
                                diemToanVan.Add(1);
                            }
                            if (float.Parse(row1[i].ToString()) > 0 && float.Parse(row1[i].ToString()) < 6.5 && row1[i].ToString() != "" && row1[i] != null)
                            {
                                diemtb.Add(row1[i].ToString());
                            }
                        }
                    }
                    if (diemtb.Count == 0&&diemToanVan.Count>=1)
                    { row1[17] = "Giỏi"; }
                    else if (diemtb.Count != 0||diemToanVan.Count==0) row1[17] = "Khá";
                }
                if (dtbhky >= 6.5 && dtbhky <8.0)
                {
                    for (int i = 3; i <= 15; i++)
                    {
                        if (row1[i].ToString() != "" && row1[i] != null)
                        {
                            if (float.Parse(row1[3].ToString()) >= 6.5 || float.Parse(row1[4].ToString()) >= 6.5)
                            {
                                diemToanVan.Add(1);
                            }
                            if (float.Parse(row1[i].ToString()) > 0 && float.Parse(row1[i].ToString()) < 5.0 && row1[i].ToString() != "" && row1[i] != null)
                            {
                                diemtb.Add(row1[i].ToString());
                            }
                        }
                    }
                    if (diemtb.Count == 0&&diemToanVan.Count>=1)
                    { row1[17] = "Khá"; }
                    else if (diemtb.Count != 0||diemToanVan.Count==0) row1[17] = "TB";
                }
                if (dtbhky >= 5 && dtbhky <6.5)
                {
                    for (int i = 3; i <= 15; i++)
                    {
                        if (row1[i].ToString() != "" && row1[i] != null)
                        {
                            if (float.Parse(row1[3].ToString()) >= 5.0 || float.Parse(row1[4].ToString()) >= 5.0)
                            {
                                diemToanVan.Add(1);
                            }
                            if (float.Parse(row1[i].ToString()) > 0 && float.Parse(row1[i].ToString()) < 3.5 && row1[i].ToString() != "" && row1[i] != null)
                            {
                                diemtb.Add(row1[i].ToString());
                            }
                        }
                    }
                    if (diemtb.Count == 0&&diemToanVan.Count>=1)
                    { row1[17] = "TB"; }
                    else if (diemtb.Count != 0||diemToanVan.Count==0) row1[17] = "Yếu";
                }
               // row1[16]=lq.HocLuc(row1[15].ToString(),
            }

            dt.Rows.Add(row1);


        }



    }
  //string  HocLucTungKy(string diem,string mahs,string manam,string malop,string maky)
  //{
  //      if()
  //}
}
