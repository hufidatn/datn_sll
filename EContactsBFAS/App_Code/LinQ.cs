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
/// Summary description for LinQ
/// </summary>
public class LinQ
{
    EContactDataContext db = new EContactDataContext();
    //BangDiem bd = new BangDiem();
    public LinQ()
    {


    }
    public void LoadGridHK(string mahk, string manam, string malop, string mahs, GridView grv, DataTable dt, Label lb)
    {
        //dt = new DataTable();
        dt.Columns.Add("MaMon", typeof(string));
        dt.Columns.Add("TenMon", typeof(string));
        dt.Columns.Add("DM", typeof(string));
        dt.Columns.Add("D15p", typeof(string));
        dt.Columns.Add("D45p", typeof(string));
        dt.Columns.Add("DHK", typeof(string));
        dt.Columns.Add("DTB", typeof(string));
        var c = from i in
                    (from p in db.Scores
                     where p.SchoolYearID == int.Parse(manam) &&
                     p.ClassID == int.Parse(malop) &&
                     p.StudentID == mahs &&
                     p.SemesterID == int.Parse(mahk)
                     select new { p.SubjectID, p.Subject.SubjectName })
                group i by new { i.SubjectID, i.SubjectName } into gr
                select new { gr.Key.SubjectID, gr.Key.SubjectName };
        foreach (var con in c)
        {
            DataRow row = dt.NewRow();
            LoadDiemTheoHK(int.Parse(manam), int.Parse(mahk), int.Parse(malop), con.SubjectID, con.SubjectName, mahs, row);
            dt.Rows.Add(row);
        }
        if (dt.Rows.Count > 0)
        {
            grv.DataSource = dt;
            grv.DataBind();
        }
        else if (dt.Rows.Count == 0)
        {
            lb.Text = "Hiện tại chưa có điểm của học sinh này";
            //lb.
        }
    }
    DataTable dt;
    string TongMotMonCN(string dk1, string dk2)
    {
        string dcn = "";
        if ((dk1 == "" && dk2 != "") || (dk1 == null && dk2 != ""))
        {
            dcn = dk2;
        }
        if ((dk1 != "" && dk2 == "") || (dk1 != "" && dk2 == null))
        {
            dcn = dk1;
        }
        if (dk1 != "" && dk2 != "")
        {
            dcn = LamTronDiem(((float.Parse(dk1) + float.Parse(dk2) * 2) / 3).ToString());
        }
        if ((dk1 == "" && dk2 == "") || (dk1 == null && dk2 == null) || (dk1 == "" && dk2 == null) || (dk1 == null && dk2 == ""))
        {
            dcn = "";
        }
        return dcn;
    }
    public void TongDiemCN(DataTable dt0,DataTable dt1,DataTable dt2,int stt,int c)
    {
        
        if (dt1.Rows.Count != 0 && dt2.Rows.Count != 0)
            {
                foreach (DataRow r1 in dt1.Rows)
                {
                    DataRow r = dt0.NewRow();
                    stt = stt + 1;
                    r[0] = stt.ToString();
                    r[1] = r1[1].ToString();
                    r[2] = r1[2].ToString();
                    double dtkcn = 0;
                    int hs = 0;
                    foreach (DataRow r2 in dt2.Rows)
                    {
                        if (r1[1].ToString() == r2[1].ToString())
                        {
                            if (r2[18].ToString() == ""||r2[18].ToString()==null)
                            {
                                r[18] = "";
                            }
                            else if (r2[18].ToString() != "")
                            {
                                r[18] = r2[18].ToString();
                            }
                            r[3] = TongMotMonCN(r1[3].ToString(), r2[3].ToString());

                            if (r[3].ToString() != "")
                            {
                                var h2 = from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Toán Học" select p.Multiplier;
                                dtkcn = dtkcn + float.Parse(r[3].ToString()) * int.Parse(h2.First().ToString());
                                hs = hs + int.Parse(h2.First().ToString());
                            }
                            if (r[3].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[4] = TongMotMonCN(r1[4].ToString(), r2[4].ToString());

                            if (r[4].ToString() != "")
                            {
                                var h3 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Ngữ Văn" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[4].ToString()) * int.Parse(h3.ToString());
                                hs = hs + int.Parse(h3.ToString());
                            }
                            if (r[4].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[5] = TongMotMonCN(r1[5].ToString(), r2[5].ToString());

                            if (r[5].ToString() != "")
                            {
                                var h4 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Vật Lý" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[5].ToString()) * int.Parse(h4.ToString());
                                hs = hs + int.Parse(h4.ToString());
                            }
                            if (r[5].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[6] = TongMotMonCN(r1[6].ToString(), r2[6].ToString());

                            if (r[6].ToString() != "")
                            {
                                var h5 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Hóa Học" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[6].ToString()) * int.Parse(h5.ToString());
                                hs = hs + int.Parse(h5.ToString());
                            }
                            if (r[6].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[7] = TongMotMonCN(r1[7].ToString(), r2[7].ToString());

                            if (r[7].ToString() != "")
                            {
                                var h6 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Lịch Sử" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[7].ToString()) * int.Parse(h6.ToString());
                                hs = hs + int.Parse(h6.ToString());
                            }
                            if (r[7].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[8] = TongMotMonCN(r1[8].ToString(), r2[8].ToString());

                            if (r[8].ToString() != "")
                            {
                                var h7 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Địa Lý" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[8].ToString()) * int.Parse(h7.ToString());
                                hs = hs + int.Parse(h7.ToString());
                            }
                            if (r[8].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[9] = TongMotMonCN(r1[9].ToString(), r2[9].ToString());

                            if (r[9].ToString() != "")
                            {
                                var h8 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Sinh Học" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[9].ToString()) * int.Parse(h8.ToString());
                                hs = hs + int.Parse(h8.ToString());
                            }
                            if (r[9].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[10] = TongMotMonCN(r1[10].ToString(), r2[10].ToString());

                            if (r[10].ToString() != "")
                            {
                                var h9 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Ngoại Ngữ" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[10].ToString()) * int.Parse(h9.ToString());
                                hs = hs + int.Parse(h9.ToString());
                            }
                            if (r[10].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[11] = TongMotMonCN(r1[11].ToString(), r2[11].ToString());
                            //var h = from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Toán Học" select p.Multiplier;
                            if (r[11].ToString() != "")
                            {
                                var h10 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Giáo dục công dân" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[11].ToString()) * int.Parse(h10.ToString());
                                hs = hs + int.Parse(h10.ToString());
                            }
                            if (r[11].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[12] = TongMotMonCN(r1[12].ToString(), r2[12].ToString());
                            // var h = from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Toán Học" select p.Multiplier;
                            if (r[12].ToString() != "")
                            {
                                var h11 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Tin Học" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[12].ToString()) * int.Parse(h11.ToString());
                                hs = hs + int.Parse(h11.ToString());
                            }
                            if (r[12].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[13] = TongMotMonCN(r1[13].ToString(), r2[13].ToString());
                            //var h = from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Toán Học" select p.Multiplier;
                            if (r[13].ToString() != "")
                            {
                                var h12 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Công Nghệ" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[13].ToString()) * int.Parse(h12.ToString());
                                hs = hs + int.Parse(h12.ToString());
                            }
                            if (r[13].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[14] = TongMotMonCN(r1[14].ToString(), r2[14].ToString());

                            if (r[14].ToString() != "")
                            {
                                var h13 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "Thể Dục" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[14].ToString()) * int.Parse(h13.ToString());
                                hs = hs + int.Parse(h13.ToString());
                            }
                            if (r[14].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }
                            r[15] = TongMotMonCN(r1[15].ToString(), r2[15].ToString());

                            if (r[15].ToString() != "")
                            {
                                var h14 = (from p in db.DepartmentSubjects where p.DepartmentID == c && p.Subject.SubjectName == "GDQP" select p.Multiplier).First();
                                dtkcn = dtkcn + float.Parse(r[14].ToString()) * int.Parse(h14.ToString());
                                hs = hs + int.Parse(h14.ToString());
                            }
                            if (r[15].ToString() == "")
                            {
                                dtkcn = dtkcn + 0;
                                hs = hs + 0;
                            }

                        }
                        if (dtkcn == 0)
                        {
                            r[16] = "";
                        }
                        if (dtkcn != 0)
                        {

                            string s = LamTronDiem((dtkcn / hs).ToString());
                            if (s != "")
                            { r[16] = s; }
                        }
                        List<string> diemtb = new List<string>();
                        List<int> diemToanVan = new List<int>();
                        if (r[16].ToString() != "")
                        {
                            float dtbhky = float.Parse(r[16].ToString());
                            if (dtbhky >= 8.0 && dtbhky <= 10)
                            {
                                for (int i = 3; i <= 15; i++)
                                {
                                    if (r[i].ToString() != "" && r[i] != null)
                                    {
                                        if (float.Parse(r[3].ToString()) >= 8.0 || float.Parse(r[4].ToString()) >= 8.0)
                                        {
                                            diemToanVan.Add(1);
                                        }
                                        if (float.Parse(r[i].ToString()) > 0 && float.Parse(r[i].ToString()) < 6.5 && r[i].ToString() != "" && r[i] != null)
                                        {
                                            diemtb.Add(r[i].ToString());
                                        }
                                    }
                                }
                                if (diemtb.Count == 0 && diemToanVan.Count >= 1)
                                { r[17] = "Giỏi"; }
                                else if (diemtb.Count != 0 || diemToanVan.Count == 0) r[17] = "Khá";
                            }
                            if (dtbhky >= 6.5 && dtbhky <8)
                            {
                                for (int i = 3; i <= 15; i++)
                                {
                                    if (r[i].ToString() != "" && r[i] != null)
                                    {
                                        if (float.Parse(r[3].ToString()) >= 6.5 || float.Parse(r[4].ToString()) >= 6.5)
                                        {
                                            diemToanVan.Add(1);
                                        }
                                        if (float.Parse(r[i].ToString()) > 0 && float.Parse(r[i].ToString()) < 5.0 && r[i].ToString() != "" && r[i] != null)
                                        {
                                            diemtb.Add(r[i].ToString());
                                        }
                                    }
                                }
                                if (diemtb.Count == 0 && diemToanVan.Count >= 1)
                                { r[17] = "Khá"; }
                                else if (diemtb.Count != 0 || diemToanVan.Count == 0) r[17] = "TB";
                            }
                            if (dtbhky >= 5 && dtbhky <= 6.4)
                            {
                                for (int i = 3; i <= 15; i++)
                                {
                                    if (r[i].ToString() != "" && r[i] != null)
                                    {
                                        if (float.Parse(r[3].ToString()) >= 5.0 || float.Parse(r[4].ToString()) >= 5.0)
                                        {
                                            diemToanVan.Add(1);
                                        }
                                        if (float.Parse(r[i].ToString()) > 0 && float.Parse(r[i].ToString()) < 3.5 && r[i].ToString() != "" && r[i] != null)
                                        {
                                            diemtb.Add(r[i].ToString());
                                        }
                                    }
                                }
                                if (diemtb.Count == 0 && diemToanVan.Count >= 1)
                                { r[17] = "TB"; }
                                else if (diemtb.Count != 0 || diemToanVan.Count == 0) r[17] = "Yếu";
                            }
                            // row1[16]=lq.HocLuc(row1[15].ToString(),
                           
                        }

                        
                    }
                    dt0.Rows.Add(r);
                }
            }
            
        
    }
    public void LoadGridCN(DataTable dt1, DataTable dt2,Label lbThongbao,string malop,string manam,GridView grvHK3)
    {
        dt = new DataTable();
        dt.Columns.Add("MonHoc", typeof(string));
        dt.Columns.Add("DTBHK1", typeof(string));
        dt.Columns.Add("DTBHK2", typeof(string));
        dt.Columns.Add("DTBCN", typeof(string));
        dt.Columns.Add("MaMon", typeof(string));
        if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
        {
            foreach (DataRow r1 in dt1.Rows)
            {

                DataRow r = dt.NewRow();
                r[0] = r1[1].ToString();
                r[4] = r1[0].ToString();
                foreach (DataRow r2 in dt2.Rows)
                {
                    if (r1[0].ToString() == r2[0].ToString())
                    {
                        if (r2[6].ToString() != "" && r1[6].ToString() != "")
                        {
                            r[1] = r1[6].ToString();
                            string s = r1[6].ToString();
                            //Response.Write(s);
                            r[2] = r2[6].ToString();
                            string s1 = r2[6].ToString();
                            r[3] = LamTronDiem(((float.Parse(s) * 1 + float.Parse(s1) * 2) / 3).ToString());
                        }
                        if (r2[6].ToString() == "" && r1[6].ToString() != "")
                        {
                            r[2] = r1[6].ToString();
                            r[1] = "";
                            r[3] = r1[1].ToString();

                        }
                        if (r2[6].ToString() != "" && r1[6].ToString() == "")
                        {
                            r[1] = r2[6].ToString();
                            r[2] = "";
                            r[3] = r[1].ToString();

                        }
                        if (r2[6].ToString() == "" && r1[6].ToString() == "")
                        {
                            r[1] = "";
                            r[2] = "";
                            r[3] = "";

                        }
                        dt.Rows.Add(r);
                    }

                }
            }
        }
        else
        {
            if (dt1.Rows.Count > 0 && dt2.Rows.Count == 0)
            {

                foreach (DataRow dr1 in dt1.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dr1[1].ToString();
                    if (dr1[6].ToString() != "")
                    {

                        string s = dr[0].ToString();
                        //Response.Write(s);
                        dr[1] = dr1[6].ToString();
                        dr[2] = "";
                        dr[3] = "";
                        //string s = dr[0].ToString();
                        //dt.Rows.Add(dr);
                    }
                    if (dr1[6].ToString() == "")
                    {
                        //dr[0] = dr1[1].ToString();
                        dr[1] = "";
                        dr[2] = "";
                        dr[3] = "";

                    }
                    dt.Rows.Add(dr);

                }
            }
            if (dt1.Rows.Count == 0 && dt2.Rows.Count >= 1)
            {

                foreach (DataRow dr2 in dt2.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dr2[1].ToString();
                    if (dr2[6].ToString() != "")
                    {
                        //dr[0] = dr2[1].ToString();
                        dr[1] = dr2[6].ToString();
                        dr[2] = "";
                        dr[3] = "";
                    }
                    if (dr2[6].ToString() == "")
                    {

                        dr[1] = "";
                        dr[2] = "";
                        dr[3] = "";
                    }
                    dt.Rows.Add(dr);
                }
            }
        }
        if (lbThongbao.Text != "")
        {
            lbThongbao.Text = LamTronDiem(TinhTongDTBCN(dt,malop,manam));
        }
        grvHK3.DataSource = dt;
        grvHK3.DataBind();


    }
    string TinhTongDTBCN(DataTable dt,string malop,string manam)
    {

        var c = (from p in db.ClassDepartments
                 where p.ClassID == int.Parse(malop) &&
                     p.SchoolYearID == int.Parse(manam)
                 select p.DepartmentID).First();
        double diem = 0;
        int heso = 0;
        foreach (DataRow r in dt.Rows)
        {
            var hs = from p in db.DepartmentSubjects
                     where p.DepartmentID == int.Parse(c.ToString()) && p.SubjectID == int.Parse(r[4].ToString())
                     select p.Multiplier;
            if (r[3].ToString() != "")
            {
                diem = diem + (float.Parse(r[3].ToString()) * int.Parse(hs.First().ToString()));
                heso = heso + int.Parse(hs.First().ToString());
            }
        }
        return (diem / heso).ToString();

    }
    public void LoadMa1(string maN, string maL, string maK, string maM, TextBox ky, TextBox nam, TextBox lop, TextBox mon)
    {
        var c = (from p in db.Scores
                 where p.SchoolYearID == int.Parse(maN) && p.SemesterID == int.Parse(maK)
                 && p.SubjectID == int.Parse(maM) && p.ClassID == int.Parse(maL)
                 select new
                 {
                     p.Class.ClassName,
                     p.Subject.SubjectName,
                     p.Semester.SemesterName,
                     p.SchoolYear.SchoolYearName
                 }).First();
        nam.Text = c.SchoolYearName;
        lop.Text = c.ClassName;
        ky.Text = c.SemesterName;
        //tenhs.Text=c.StudentName;
        mon.Text = c.SubjectName;
    }
    //public void LoadMa(string maN,string maL,string maK,string maM, TextBox ky,TextBox nam,TextBox lop,TextBox mon)
    //{
    //    var c = (from p in db.Scores
    //            where p.SchoolYearID == int.Parse(maN) && p.SemesterID == int.Parse(maK)
    //            && p.SubjectID == int.Parse(maM) && p.ClassID == int.Parse(maL)
    //            select new { p.Class.ClassName,p.Subject.SubjectName,p.Semester.SemesterName,
    //            p.SchoolYear.SchoolYearName}).First();
    //    nam.Text=c.SchoolYearName;
    //    lop.Text=c.ClassName;
    //    ky.Text=c.SemesterName;
    //    //tenhs.Text=c.StudentName;
    //    mon.Text=c.SubjectName;


    //    var c1 = from p in db.Scores
    //             where p.SchoolYearID == int.Parse(maN) && p.SemesterID == int.Parse(maK) &&
    //             p.StudentID == maHS && p.SubjectID == int.Parse(maM) && p.ClassID == int.Parse(maL)&&p.TypeScoreID==1
    //             select p.Score1;
    //    List<double> diem=new List<double>();
    //    if (c1.Count() == 0)
    //    {
    //        dm1.Text = ""; dm3.Text = "";
    //        dm2.Text = ""; dm4.Text = "";
    //    }
    //    if (c1.Count() == 1)
    //    {
    //        dm1.Text = c1.First().ToString();
    //        dm2.Text = ""; dm3.Text = ""; dm4.Text = "";

    //    }
    //    if (c1.Count() == 2)
    //    {
    //        foreach (var con in c1)
    //        {
    //            diem.Add(con);
    //        }
    //        dm1.Text = diem[0].ToString();
    //        dm2.Text = diem[1].ToString();
    //        dm3.Text = "";
    //        dm4.Text = "";

    //    }
    //    if (c1.Count() == 3)
    //    {
    //        foreach (var con in c1)
    //        {
    //            diem.Add(con);
    //        }
    //        dm1.Text = diem[0].ToString();
    //        dm2.Text = diem[1].ToString();
    //        dm3.Text = diem[2].ToString();
    //        dm4.Text = "";
    //    }
    //    if (c1.Count() == 4)
    //    {
    //        foreach (var con in c1)
    //        {
    //            diem.Add(con);
    //        }
    //        dm1.Text = diem[0].ToString();
    //        dm2.Text = diem[1].ToString();
    //        dm3.Text = diem[2].ToString();
    //        dm4.Text = diem[3].ToString();
    //    }

    //    var c2 = from p in db.Scores
    //             where p.SchoolYearID == int.Parse(maN) && p.SemesterID == int.Parse(maK) &&
    //             p.StudentID == maHS && p.SubjectID == int.Parse(maM) && p.ClassID == int.Parse(maL)&&p.TypeScoreID==2
    //             select p.Score1;
    //    List<double> diem15 = new List<double>();
    //    if (c2.Count() == 0)
    //    {
    //        d151.Text = ""; d153.Text = "";
    //        d152.Text = ""; d154.Text = "";
    //    }
    //    if (c2.Count() == 1)
    //    {
    //        d151.Text = c2.First().ToString();
    //        d152.Text = ""; d153.Text = ""; d154.Text = "";

    //    }
    //    if (c2.Count() == 2)
    //    {
    //        foreach (var con in c2)
    //        {
    //            diem15.Add(con);
    //        }
    //        d151.Text = diem15[0].ToString();
    //        d152.Text = diem15[1].ToString();
    //        d153.Text = "";
    //        d154.Text = "";

    //    }
    //    if (c2.Count() == 3)
    //    {
    //        foreach (var con in c2)
    //        {
    //            diem15.Add(con);
    //        }
    //        d151.Text = diem15[0].ToString();
    //        d152.Text = diem15[1].ToString();
    //        d153.Text = diem15[2].ToString();
    //        d154.Text = "";
    //    }
    //    if (c2.Count() == 4)
    //    {
    //        foreach (var con in c2)
    //        {
    //            diem.Add(con);
    //        }
    //        d151.Text = diem15[0].ToString();
    //        d152.Text = diem15[1].ToString();
    //        d153.Text = diem15[2].ToString();
    //        d154.Text = diem15[3].ToString();
    //    }
    //    var c3 = from p in db.Scores
    //             where p.SchoolYearID == int.Parse(maN) && p.SemesterID == int.Parse(maK) &&
    //             p.StudentID == maHS && p.SubjectID == int.Parse(maM) && p.ClassID == int.Parse(maL)&&p.TypeScoreID==3
    //             select p.Score1;
    //    List<double> diem45 = new List<double>();
    //    if (c3.Count() == 0)
    //    {
    //        d451.Text = "";
    //        d452.Text = "";
    //    }
    //    if (c3.Count() == 1)
    //    {
    //        d451.Text = c3.First().ToString();
    //        d452.Text = "";
    //    }
    //    if (c3.Count() == 2)
    //    {
    //        foreach (var con in c3)
    //        {
    //            diem45.Add(con);
    //        }
    //        d451.Text = diem45[0].ToString();
    //        d452.Text = diem45[1].ToString();
    //    }

    //    var c4 = from p in db.Scores
    //             where p.SchoolYearID == int.Parse(maN) && p.SemesterID == int.Parse(maK) &&
    //             p.StudentID == maHS && p.SubjectID == int.Parse(maM) && p.ClassID == int.Parse(maL)&&p.TypeScoreID==4
    //             select p.Score1;
    //    if (c4.Count() == 0)
    //    {
    //        dthikt.Text = "";
    //    }
    //    if (c4.Count() == 1)
    //    {
    //        dthikt.Text = c4.First().ToString();
    //    }
    //    var c5 = from p in db.Scores
    //             where p.SchoolYearID == int.Parse(maN) && p.SemesterID == int.Parse(maK) &&
    //             p.StudentID == maHS && p.SubjectID == int.Parse(maM) && p.ClassID == int.Parse(maL)&&p.TypeScoreID==5
    //             select p.Score1;
    //    if (c5.Count() == 0)
    //    {
    //        dthilai.Text = "";
    //    }
    //    if (c5.Count() == 1)
    //    {
    //        dthilai.Text = c5.First().ToString();
    //    }


    //}
    //Loadgrid trang bảng điểm theo mon
    public void LoadDiemTheoMon(int nam, int ky, int lop, int mon, string mahs, string tenhs, DataRow row)
    {
        // dt = new DataTable();


        row[0] = mahs;
        row[1] = tenhs;

        double dtkm = 0;
        List<double> diemM = new List<double>();
        var c = from p in db.Scores
                where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 1
                select p.Score1;
        foreach (var con in c)
        {

            diemM.Add(con);
        }

        if (diemM == null)
        {
            row[2] = "";
            dtkm = 0;
        }
        if (diemM != null)
        {
            double dm = 0.0;
            string s = "";
            for (int i = 1; i <= diemM.Count; i++)
            {

                s = s + ";" + " " + diemM[i - 1].ToString();
                row[2] = s.Substring(2);
                dm = dm + diemM[i - 1];
                dtkm = dm / i;
            }

        }
        double dtk15 = 0;
        List<double> diem15 = new List<double>();
        var c1 = from p in db.Scores
                 where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 2
                 select p.Score1;
        foreach (var con1 in c1)
        {
            diem15.Add(con1);
        }
        if (diem15 == null)
        {
            row[3] = "";
            dtk15 = 0;
        }
        if (diem15 != null)
        {
            double d15 = 0;
            string s = "";
            for (int i = 1; i <= diem15.Count; i++)
            {

                s = s + ";" + " " + diem15[i - 1].ToString();
                row[3] = s.Substring(2);
                d15 = d15 + diem15[i - 1];
                dtk15 = d15 / i;
            }

        }
        List<double> diem45 = new List<double>();
        double dtk45 = 0;
        var c2 = from p in db.Scores
                 where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 3
                 select p.Score1;
        foreach (var con2 in c2)
        {
            diem45.Add(con2);
        }
        if (diem45 == null)
        {
            row[4] = "";
            dtk45 = 0;

        }
        if (diem45 != null)
        {
            double d45 = 0;
            string s = "";
            for (int i = 1; i <= diem45.Count; i++)
            {

                s = s + ";" + " " + diem45[i - 1].ToString();
                row[4] = s.Substring(2);
                d45 = d45 + diem45[i - 1];
                dtk45 = d45 / i;
            }

        }
        List<double> diemHK = new List<double>();
        double dtkHK = 0;
        var c3 = from p in db.Scores
                 where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 4
                 select p.Score1;
        if (c3.Count() == 0)
        {
            row[5] = "";
            dtkHK = 0;
        }
        if (c3.Count() != 0)
        {
            row[5] = c3.First().ToString();
            dtkHK = c3.First();
        }
        //foreach (var con3 in c3)
        //{
        //    diemHK.Add(con3);
        //}
        //if (diemHK == null)
        //{
        //    row[5] = "";
        //    dtkHK = 0;
        //}
        //if (diemHK != null)
        //{ 
        //        row[5] = diemHK[0].ToString();
        //        dtkHK = diemHK[0];

        //}
        ////List<double> diemTL = new List<double>();
        ////double dtkTL=0;

        //foreach (var con4 in c4)
        //{
        //    diemTL.Add(con4);
        //}
        //if (diemTL == null)
        //{
        //    row[5] = "";
        //    dtkTL = 0;
        //}
        //if (diemTL != null)
        //{

        //    row[5] = diemTL[0].ToString();
        //    dtkTL = diemTL[0];

        //}
        if (c3.Count() == 0)
        {
            row[6] = "";
        }
        if (c3.Count() != 0)
        {
            double diemTB = (dtkm + dtk15 + dtk45 * 2 + dtkHK * 3) / 7;
            row[6] = LamTronDiem(diemTB.ToString());
            //if (double.Parse(LamTronDiem(diemTB.ToString())) < 3.5)
            //{
            //    var c4 = from p in db.Scores
            //             where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 3
            //             select p.Score1;
            //    if (c4.Count() == 0)
            //    {
            //        row[6] = "";
            //        dtkTL = 0;
            //    }
            //    if (c4.Count() != 0)
            //    {
            //        row[6] = c3.First().ToString();
            //        dtkTL = c4.First();
            //    }
            //    if (c4.Count() != 0)
            //    {
            //        double diemTBL = (dtkm + dtk15 + dtk45 * 2 + dtkTL * 3) / 7;
            //        row[8] = LamTronDiem(diemTBL.ToString());
            //    }
            //    if (c4.Count() == 0)
            //    {
            //        row[8] = "";
            //    }
            //}

        }
        List<double> diemTL = new List<double>();
        double dtl = 0;
        var c4 = from p in db.Scores
                 where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 5
                 select p.Score1;
        if (c4.Count() == 0)
        {
            row[7] = "";
            dtl = 0;
        }
        if (c4.Count() != 0)
        {
            row[7] = c4.First().ToString();
            dtl = c4.First();
        }

        //dt.Rows.Add(row);
        //return dt;
    }
    public string LamTronDiem(string diem)
    {
        string kq = "";
        char[] kitu = diem.ToCharArray();
        if (kitu.Length <= 3)
        {

            kq = diem;
        }
        if (kitu.Length >= 4)
        {
            string con = diem.Substring(0, 4);
            int d = int.Parse(con.Substring(3));
            if (d >= 5 && d <= 9)
            {

                kq = (double.Parse(diem.Substring(0, 3)) + 0.1).ToString();
            }
            if (d < 5 && d >= 0)
            {
                kq = diem.Substring(0, 3);
            }

        }
        char[] kt = kq.ToCharArray();
        if (kt.Length == 1)
        { kq = kq + ".0"; }

        return kq;
    }

    //Load điểm cho nhiều môn
    public void LoadDiemTheoHK(int nam, int ky, int lop, int mon, string tenmon, string mahs, DataRow row)
    {
        // dt = new DataTable();


        row[0] = mon.ToString();
        row[1] = tenmon;

        double dtkm = 0;
        List<double> diemM = new List<double>();
        var c = from p in db.Scores
                where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 1
                select p.Score1;
        foreach (var con in c)
        {

            diemM.Add(con);
        }

        if (diemM == null)
        {
            row[2] = "";
            dtkm = 0;
        }
        if (diemM != null)
        {
            double dm = 0.0;
            string s = "";
            for (int i = 1; i <= diemM.Count; i++)
            {

                s = s + ";" + " " + diemM[i - 1].ToString();
                row[2] = s.Substring(2);
                dm = dm + diemM[i - 1];
                dtkm = dm / i;
            }

        }
        double dtk15 = 0;
        List<double> diem15 = new List<double>();
        var c1 = from p in db.Scores
                 where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 2
                 select p.Score1;
        foreach (var con1 in c1)
        {
            diem15.Add(con1);
        }
        if (diem15 == null)
        {
            row[3] = "";
            dtk15 = 0;
        }
        if (diem15 != null)
        {
            double d15 = 0;
            string s = "";
            for (int i = 1; i <= diem15.Count; i++)
            {

                s = s + ";" + " " + diem15[i - 1].ToString();
                row[3] = s.Substring(2);
                d15 = d15 + diem15[i - 1];
                dtk15 = d15 / i;
            }

        }
        List<double> diem45 = new List<double>();
        double dtk45 = 0;
        var c2 = from p in db.Scores
                 where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 3
                 select p.Score1;
        foreach (var con2 in c2)
        {
            diem45.Add(con2);
        }
        if (diem45 == null)
        {
            row[4] = "";
            dtk45 = 0;

        }
        if (diem45 != null)
        {
            double d45 = 0;
            string s = "";
            for (int i = 1; i <= diem45.Count; i++)
            {

                s = s + ";" + " " + diem45[i - 1].ToString();
                row[4] = s.Substring(2);
                d45 = d45 + diem45[i - 1];
                dtk45 = d45 / i;
            }

        }
        List<double> diemHK = new List<double>();
        double dtkHK = 0;
        var c3 = from p in db.Scores
                 where p.SchoolYearID == nam && p.ClassID == lop && p.SemesterID == ky && p.SubjectID == mon && p.StudentID == mahs && p.TypeScoreID == 4
                 select p.Score1;
        if (c3.Count() == 0)
        {
            row[5] = "";
            dtkHK = 0;
        }
        if (c3.Count() != 0)
        {
            row[5] = c3.First().ToString();
            dtkHK = c3.First();
        }

        if (c3.Count() == 0 || c.Count() == 0 || c1.Count() == 0 || c2.Count() == 0)
        {
            row[6] = "";
        }
        if (c3.Count() != 0 && c1.Count() != 0 && c.Count() != 0 && c2.Count() != 0)
        {
            double diemTB = (dtkm + dtk15 + dtk45 * 2 + dtkHK * 3) / 7;
            row[6] = LamTronDiem(diemTB.ToString());


        }


        //dt.Rows.Add(row);
        //return dt;
    }

    public string HocLuc(string diem, DataTable dt, string manam, string malop, string mahs, string maky)
    {
        string HL = "";
        List<string> diemtb = new List<string>();
        List<string> diemToanVan = new List<string>();
        var c = from p in db.Scores
                where p.SchoolYearID == int.Parse(manam) && p.ClassID == int.Parse(malop) && p.StudentID == mahs
                    && p.TypeScoreID == 4 && p.SemesterID == int.Parse(maky)
                select p.Score1;
        if (float.Parse(diem) >= 8.0 && float.Parse(diem) <= 10.0)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r[6].ToString() != "")
                {//var c1=from p in db.Subjects where p.SubjectID==int.Parse(r[0].ToString())select p.SubjectName;

                    if ((r[1].ToString() == "Toán Học" && float.Parse(r[6].ToString()) >= 8.0)||(r[1].ToString()=="Ngữ Văn"&&float.Parse(r[6].ToString())>=8.0))
                    {
                        diemToanVan.Add(r[6].ToString());
                    }
                    if (float.Parse(r[6].ToString()) < 6.5)
                    {
                        diemtb.Add(r[6].ToString());
                    }
                }
            }
            //foreach (var con in c)
            //{
            //    if (con < 5)
            //    { diemthi.Add(con.ToString()); }
            //}
            if (diemtb.Count== 0&& diemToanVan.Count>=1)
            {
                HL = "Giỏi";
            }
            else 
            {
                HL = "Khá";
            }
            
            }
        if (float.Parse(diem) >= 6.5 && float.Parse(diem) <= 7.9)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r[6].ToString() != "")
                {
                    if ((r[1].ToString() == "Toán Học" && float.Parse(r[6].ToString()) >= 6.5) || (r[1].ToString() == "Ngữ Văn" && float.Parse(r[6].ToString()) >= 6.5))
                    {
                        diemToanVan.Add(r[6].ToString());
                    }
                    if (float.Parse(r[6].ToString()) < 5.0)
                    {
                        diemtb.Add(r[6].ToString());
                    }
                }
            }
            //foreach (var con in c)
            //{
            //    if (con < 3.5)
            //    { diemthi.Add(con.ToString()); }
            //}
            if (diemtb.Count == 0&&diemToanVan.Count>=1)
            {
                HL = "Khá";
            }
            else
            {
                HL = "TB";
            }

        }
            if (float.Parse(diem) >= 5.0 && float.Parse(diem) <= 6.5)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r[6].ToString() != "")
                    {
                        if ((r[1].ToString() == "Toán Học" && float.Parse(r[6].ToString()) >= 5.0) || (r[1].ToString() == "Ngữ Văn" && float.Parse(r[6].ToString()) >= 5.0))
                        {
                            diemToanVan.Add(r[6].ToString());
                        }
                        if (float.Parse(r[6].ToString()) < 3.5)
                        {
                            diemtb.Add(r[6].ToString());
                        }
                    }
                }
                //foreach (var con in c)
                //{
                //    if (con < 3.5)
                //    { diemthi.Add(con.ToString()); }
                //}
                if (diemtb.Count == 0&&diemToanVan.Count>=1)
                {
                    HL = "TB";
                }
                else
                {
                    HL = "Yếu";
                }
            }
            if (float.Parse(diem) < 3.5)
            {
                HL = "Kém";
            }
            if (diem == "")
            {
                HL = "";
            }
            return HL;
        }
    ////////////////Học Lực Cả Năm

    public string HocLucCN(string diem, DataTable dt, string manam, string malop, string mahs, string ky1,string ky2)
    {
        string HL = "";
        List<string> diemtb = new List<string>();
        List<string> diemToanVan = new List<string>();
        var c = from p in db.Scores
                where p.SchoolYearID == int.Parse(manam) && p.ClassID == int.Parse(malop) && p.StudentID == mahs
                    && p.TypeScoreID == 4 && (p.SemesterID == int.Parse(ky1)||p.SemesterID==int.Parse(ky2))
                select p.Score1;
        if (float.Parse(diem) >= 8.0 && float.Parse(diem) <= 10.0)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r[3].ToString() != "")
                {
                    if ((r[0].ToString() == "Toán Học" && float.Parse(r[3].ToString()) >= 8.0) || (r[0].ToString() == "Ngữ Văn" && float.Parse(r[3].ToString()) >= 8.0))
                    {
                        diemToanVan.Add(r[3].ToString());
                    }
                    if (float.Parse(r[3].ToString()) < 6.5)
                    {
                        diemtb.Add(r[3].ToString());
                    }
                }
            }
            //foreach (var con in c)
            //{
            //    if (con < 5)
            //    { diemthi.Add(con.ToString()); }
            //}
            if (diemtb.Count == 0&&diemToanVan.Count>=1)
            {
                HL = "Giỏi";
            }
            else
            {
                HL = "Khá";
            }

        }
        if (float.Parse(diem) >= 6.5 && float.Parse(diem) <= 7.9)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r[3].ToString() != "")
                {
                    if ((r[0].ToString() == "Toán Học" && float.Parse(r[3].ToString()) >= 6.5) || (r[0].ToString() == "Ngữ Văn" && float.Parse(r[3].ToString()) >= 6.5))
                    {
                        diemToanVan.Add(r[3].ToString());
                    }   
                    if (float.Parse(r[3].ToString()) < 5.0)
                    {
                        diemtb.Add(r[3].ToString());
                    }
                }
            }
            //foreach (var con in c)
            //{
            //    if (con < 3.5)
            //    { diemthi.Add(con.ToString()); }
            //}
            if (diemtb.Count == 0&&diemToanVan.Count>=1)
            {
                HL = "Khá";
            }
            else
            {
                HL = "TB";
            }

        }
        if (float.Parse(diem) >= 5.0 && float.Parse(diem) <= 6.5)
        {
            foreach (DataRow r in dt.Rows)
            {
                if (r[3].ToString() != "")
                {
                    if ((r[0].ToString() == "Toán Học" && float.Parse(r[3].ToString()) >= 5.0) || (r[0].ToString() == "Ngữ Văn" && float.Parse(r[3].ToString()) >= 5.0))
                    {
                        diemToanVan.Add(r[3].ToString());
                    }
                    if (float.Parse(r[3].ToString()) < 3.5)
                    {
                        diemtb.Add(r[3].ToString());
                    }
                }
            }
            //foreach (var con in c)
            //{
            //    if (con < 3.5)
            //    { diemthi.Add(con.ToString()); }
            //}
            if (diemtb.Count == 0&&diemToanVan.Count>=1)
            {
                HL = "TB";
            }
            else
            {
                HL = "Yếu";
            }
        }
        if (float.Parse(diem) < 5.0&&float.Parse(diem)>=3.5)
        {
            HL = "Yếu";
        }
        if (float.Parse(diem) < 3.5)
        {
            HL = "Kém";
        }
        if (diem == "")
        {
            HL = "";
        }
        return HL;
    }
    }
