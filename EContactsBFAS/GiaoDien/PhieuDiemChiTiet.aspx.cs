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

public partial class GiaoDien_PhieuDiemChiTiet : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    LinQ lq = new LinQ();
    string manam;
    string malop;
    string mahs;
    string tenhs;
    string tenlop;
    string tennam;
    protected void Page_Load(object sender, EventArgs e)
    {
        manam = Request.QueryString["SchoolYearID"];
        malop = Request.QueryString["ClassID"];
        mahs = Request.QueryString["StudentID"];
        tenhs = Request.QueryString["StudentName"];
        tenlop = Request.QueryString["ClassName"];
        tennam = Request.QueryString["SchoolYearName"];
        if (!IsPostBack)
        {
            lblHoTen.Text = tenhs;
            lblLop.Text = tenlop;
            lblMa.Text = mahs;
            lblNamHoc.Text = tennam;
            DataTable dt1 = new DataTable();
            LoadGridHK("1", manam, malop, mahs, grvHK1, dt1, lblThongBao1);
            if (dt1.Rows.Count != 0)
            {

                lblDTBKy1.Text = lq.LamTronDiem(TinhTongDTB(dt1));
            }
            DataTable dt2 = new DataTable();
            LoadGridHK("2", manam, malop, mahs, grvHK2, dt2, lblThongBao2);
            if (dt2.Rows.Count != 0)
            {
                lblDTBKy2.Text = lq.LamTronDiem(TinhTongDTB(dt2));
            }
            int i = dt1.Rows.Count;
            if (dt1.Rows.Count == 0 && dt2.Rows.Count == 0)
            {
                lblThongBaoCN.Text = "Điểm trung bình cả năm chưa có!";
            }
            if (dt1.Rows.Count >= 1 || dt2.Rows.Count >= 1)
            {
                LoadGridCN(dt1, dt2);
            }
        }

    }
    DataTable dt;
    void LoadGridCN(DataTable dt1, DataTable dt2)
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
                            r[3] = lq.LamTronDiem(((float.Parse(s) * 1 + float.Parse(s1) * 2) / 3).ToString());
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
        if (lblDTBKy2.Text != "")
        {
            lblDTBCaNam.Text = lq.LamTronDiem(TinhTongDTBCN(dt));
        }
        grvHK3.DataSource = dt;
        grvHK3.DataBind();


    }
    void LoadGridHK(string mahk, string manam, string malop, string mahs, GridView grv, DataTable dt, Label lb)
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
            lq.LoadDiemTheoHK(int.Parse(manam), int.Parse(mahk), int.Parse(malop), con.SubjectID, con.SubjectName, mahs, row);
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
    string TinhTongDTB(DataTable dt)
    {
        string d = "";
        var c = (from p in db.ClassDepartments
                 where p.ClassID == int.Parse(malop) &&
                     p.SchoolYearID == int.Parse(manam)
                 select p.DepartmentID).First();
        var somon = from p in db.DepartmentSubjects where p.DepartmentID == int.Parse(c.ToString()) select p.SubjectID;
        double diem = 0;
        int heso = 0;
        if (somon.Count() == dt.Rows.Count)
        {
            foreach (DataRow r in dt.Rows)
            {
                var hs = from p1 in db.DepartmentSubjects
                         where p1.DepartmentID == int.Parse(c.ToString()) && p1.SubjectID == int.Parse(r[0].ToString())
                         select p1.Multiplier;
                if (r[6].ToString() != "")
                {
                    diem = diem + (float.Parse(r[6].ToString()) * int.Parse(hs.First().ToString()));
                    heso = heso + int.Parse(hs.First().ToString());
                }
                if (r[6].ToString() == "")
                {
                    diem = diem + 0;
                    heso = heso + 0;
                }

            }

            if (diem == 0)
            {
                d = "";
            }
            if (diem != 0)
            {
                d = (diem / heso).ToString();
            }
        }
        else d = "";
        return d;


    }
    string TinhTongDTBCN(DataTable dt)
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhieuDiemCuaTungHocSinh.aspx");
    }
}
