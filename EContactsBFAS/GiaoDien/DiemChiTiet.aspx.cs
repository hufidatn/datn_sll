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

public partial class GiaoDien_DiemChiTiet : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    LinQ lq = new LinQ();
    string manam;
    string malop;
    string mamon;
    string maky;
    //string ;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            manam = Request.QueryString["SchoolYearID"];
            malop = Request.QueryString["ClassID"];
            mamon = Request.QueryString["SubjectID"];
            //query3 = Request.QueryString["StudentID"];
            maky = Request.QueryString["SemesterID"];
            if (!IsPostBack)
            {
                lq.LoadMa1(manam, malop, maky, mamon,
                    txtKy, txtNamHoc, txtLop, txtMonHoc);

                LoadGrid();
            }
            HideControl();
        //var c=from p in db.Scores where
    }
    void HideControl()
    {
        txtMaHS.Enabled = false;
        txtMonHoc.Enabled = false;
        txtNamHoc.Enabled = false;
        txtLop.Enabled = false;
        txtKy.Enabled = false;
        txtTenHS.Enabled = false;
    }
    void LoadGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("MaHS",typeof(string));
        dt.Columns.Add("TenHS", typeof(string));
        dt.Columns.Add("DM1", typeof(string));
        
        dt.Columns.Add("D15p1", typeof(string));
        
        dt.Columns.Add("D45p1", typeof(string));
        
        dt.Columns.Add("DHK", typeof(string));
        dt.Columns.Add("DTB", typeof(string));
        dt.Columns.Add("DiemThiLai", typeof(string));
        
        
        var c=from i in (from p in db.Scores
              where p.SemesterID==int.Parse(maky)&&p.SubjectID==int.Parse(mamon)&&p.SchoolYearID==int.Parse(manam)&&p.ClassID==int.Parse(malop)
              select new { p.StudentID, p.Student.StudentName })
              group i by new { i.StudentID, i.StudentName } into gr
              select new { gr.Key.StudentID, gr.Key.StudentName };

        foreach (var con in c)
        {
            DataRow row = dt.NewRow();
            lq.LoadDiemTheoMon(int.Parse(manam), int.Parse(maky), int.Parse(malop), int.Parse(mamon), con.StudentID, con.StudentName, row);

          
            dt.Rows.Add(row);
        }
        grvDiemChiTiet.DataSource = dt;
        grvDiemChiTiet.DataBind();

    }

    protected void btnSua_Click(object sender, EventArgs e)
    {

        SuaDiemMieng(manam, maky, malop, mamon, txtMaHS.Text,1,txtDiemM1,txtDiemM2,txtDiemM3,txtDiemM4);
        SuaDiemMieng(manam, maky, malop, mamon, txtMaHS.Text,2,txtDiem15L1,txtDiem15L2,txtDiem15L3,txtDiem15L4);
        SuaDiem45P(manam, maky, malop, mamon, txtMaHS.Text,3,txtDiem45L1,txtDiem45L2);
        SuaDiemThiHK(manam, maky, malop, mamon, txtMaHS.Text,4,txtDiemThi);

        SuaDiemThiHK(manam, maky, malop, mamon, txtMaHS.Text,5,txtThiLai);
        LoadGrid();
        Moi();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("NhapDiem.aspx");
    }
    List<string> dsdiem;
    protected void grvDiemChiTiet_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            GridViewRow row = grvDiemChiTiet.SelectedRow;
            Label lblMaHS = (Label)row.FindControl("lblMaHS");
            Label lblTenHS = (Label)row.FindControl("lblTenHS");
            Label lblDM = (Label)row.FindControl("lblDM");
            
            Label lbl15p = (Label)row.FindControl("lblD15");
            
           
            Label lbl45p = (Label)row.FindControl("lblD45");
            Label lblHK = (Label)row.FindControl("lblDHK");
            Label lblTL = (Label)row.FindControl("lblTL");
            txtMaHS.Text = lblMaHS.Text;
            txtTenHS.Text = lblTenHS.Text;
            HienDiem(lblDM.Text, txtDiemM1, txtDiemM2, txtDiemM3, txtDiemM4);
            HienDiem(lbl15p.Text, txtDiem15L1, txtDiem15L2, txtDiem15L3, txtDiem15L4);
            if (lbl45p.Text != "")
            {
                if (lbl45p.Text.Contains(';') == true)
                {
                    TachDiem(lbl45p.Text);
                    txtDiem45L1.Text = dsdiem[0];
                    txtDiem45L2.Text = dsdiem[1];
                }
                else
                {
                    txtDiem45L1.Text = lbl45p.Text;
                    txtDiem45L2.Text = "";
                }

            }
            else {
                txtDiem45L2.Text = "";
                txtDiem45L1.Text = "";
            }
            if (lblHK.Text != "")
            {
                txtDiemThi.Text = lblHK.Text;
            }
            else { txtDiemThi.Text="";}
            if (lblTL.Text != "")
            {
                txtThiLai.Text = lblTL.Text;
            }
            else { txtThiLai.Text = ""; }
            
        
    }
    void HienDiem(string dm, TextBox t1, TextBox t2, TextBox t3, TextBox t4)
    {
        if (dm == "")
        {
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
        }
        if (dm != "")
        {
            if (dm.Contains(';') == true)
            {
                TachDiem(dm);
                if (dsdiem.Count == 2)
                {
                    t1.Text = dsdiem[0];
                    t2.Text = dsdiem[1];
                }
                if (dsdiem.Count == 3)
                {
                    t1.Text = dsdiem[0];
                    t2.Text = dsdiem[1];
                    t3.Text = dsdiem[2];
                }
                if (dsdiem.Count == 4)
                {
                    t1.Text = dsdiem[0];
                    t2.Text = dsdiem[1];
                    t3.Text = dsdiem[2];
                    t4.Text = dsdiem[3];
                }
            }
            if (dm.Contains(';') == false)
            {
                t1.Text = dm;
            }
        }
    }
    void TachDiem(string Diem)
    {
         dsdiem = new List<string>();
           string[] chuoi = Diem.Split(' ');
             string chuoimoi = "";
             for (int i = 0; i < chuoi.Length; i++)
             {
                 chuoimoi = chuoimoi + chuoi[i];
             }
             string[] diem = chuoimoi.Split(';');
             for (int i = 0; i < diem.Length; i++)
             {
                 dsdiem.Add(diem[i]);
             }
     

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
                list.Add(con);
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
    void Insert(string diem,int mald)
    {
        Score sr = new Score();
        sr.ScoreID = MaTuTang();
        sr.Score1 = float.Parse(diem);
        sr.SemesterID = int.Parse(maky);
        sr.StudentID = txtMaHS.Text;
        sr.ClassID = int.Parse(malop);
        sr.SchoolYearID = int.Parse(manam);
        sr.TypeScoreID = mald;
        sr.SubjectID = int.Parse(mamon);
        db.Scores.InsertOnSubmit(sr);
        db.SubmitChanges();
    }
    void delete(string mad)
    {
        Score sr = db.Scores.SingleOrDefault(p=>p.ScoreID==mad);
        db.Scores.DeleteOnSubmit(sr);
        db.SubmitChanges();
    }
    void Update(string ma,string diem)
    {
        Score sr = db.Scores.SingleOrDefault(p=>p.ScoreID==ma);
        sr.Score1 = float.Parse(diem);
        db.SubmitChanges();
    }
    void SuaDiemMieng(string mn,string mk,string ml,string mm,string mhs,int type,TextBox t1,TextBox t2,TextBox t3,TextBox t4 )
    {
        List<string> diem = new List<string>();
        var c = from p in db.Scores
                where p.SchoolYearID == int.Parse(mn) && p.SemesterID == int.Parse(mk) && p.ClassID == int.Parse(ml)
                && p.SubjectID == int.Parse(mm) && p.StudentID == mhs&& p.TypeScoreID==type
                select p.ScoreID;
        //Response.Write(c.Count().ToString());
        if (c.Count() == 0)
        {
            if (t1.Text != "")
            {
                Insert(t1.Text, type);
            }
            if (t2.Text != "")
            {
                Insert(t2.Text, type);
            }
            if (t3.Text != "")
            {
                Insert(t3.Text, type);
            }
            if (t4.Text != "")
            {
                Insert(t4.Text, type);
            }
        }
        
        if (c.Count() == 1)
        {
            if(t1.Text=="")
            {
                delete(c.First().ToString());
            }
            if (t1.Text != "")
            {
                Update(c.First().ToString(),t1.Text);
                
                
            }
            if (t2.Text != "")
                {

                    Insert(t2.Text,type);
                }
            
             if (t3.Text != "")
               {
                 Insert(t3.Text, type);
                  
              }
            if (t4.Text != "")
              {
                   Insert(t4.Text, type);
               }
                    
                    
                
        }
        if (c.Count() == 4)
        {

            foreach (var con in c)
            {
                diem.Add(con);
            }

            if (t1.Text != "")
            {
                Update(diem[0].ToString(), t1.Text);
            }
            if (t2.Text != "")
            {
                Update(diem[1].ToString(), t2.Text);
            }
            if (t3.Text != "")
            {
                Update(diem[2].ToString(), t3.Text);
            }
            if (t4.Text != "")
            {
                Update(diem[3].ToString(), t4.Text);
            }

            if (t1.Text == "")
            {
                delete(diem[0].ToString());
            }
            if (t2.Text == "")
            {
                delete(diem[1].ToString());
            }
            if (t3.Text == "")
            {
                delete(diem[2].ToString());
            }
            if (t4.Text == "")
            {
                delete(diem[3].ToString());
            }
        }
        if (c.Count() == 3)
        {

            foreach (var con in c)
            {
                diem.Add(con);
            }

            if (t1.Text != "")
            {
                Update(diem[0].ToString(), t1.Text);
            }
            if (t2.Text != "")
            {
                Update(diem[1].ToString(), t2.Text);
            }
            if (t3.Text != "")
            {
                Update(diem[2].ToString(), t3.Text);
            }
            if (t4.Text != "")
            {
                Insert(t4.Text, type);
            }
            if (t1.Text == "")
            {
                delete(diem[0].ToString());
            }
            if (t2.Text == "")
            {
                delete(diem[1].ToString());
            }
            if (t3.Text == "")
            {
                delete(diem[2].ToString());
            }


        }
        if (c.Count() == 2)
        {
            
            foreach (var con in c)
            {
                diem.Add(con);
            }
            
            if (t1.Text != "")
            {
                Update(diem[0].ToString(), t1.Text);


            }
            if (t2.Text != "")
            {
                Update(diem[1].ToString(), t2.Text);
            }
            if (t3.Text != "")
            {
                Insert(t3.Text, type);

            }
            if (t4.Text != "")
            { Insert(t4.Text, type); }
            if (t1.Text == "")
            {
                delete(diem[0].ToString());

            }
            if (t2.Text == "")
            {
                delete(diem[1].ToString());
            }
            
        }
        
        

        

        
    }
    
    void SuaDiem45P(string mn, string mk, string ml, string mm, string mhs,int type,TextBox t1,TextBox t2)
    {
        List<string > diem = new List<string>();
        var c = from p in db.Scores
                where p.SchoolYearID == int.Parse(mn) && p.SemesterID == int.Parse(mk) && p.ClassID == int.Parse(ml)
                && p.SubjectID == int.Parse(mm) && p.StudentID == mhs && p.TypeScoreID == type
                select p.ScoreID;
        if (c.Count() == 0)
        {
            if (t1.Text != "")
            {
                Insert(t1.Text, type);
            }
            if (t2.Text != "")
            {
                Insert(t2.Text, type);
            }

        }
        else
        {
        if (c.Count() == 1)
        {

            //Score sr = db.Scores.SingleOrDefault(p => p.ScoreID == c.First());
            //sr.Score1 = float.Parse(txtDiem45L1.Text);
            //db.SubmitChanges();
            if (t1.Text == "")
            {
                delete(c.First());
            }
            if (t1.Text != "")
            {
                Update(c.First(), t1.Text);


            }
            if (t2.Text != "")
            {

                Insert(t2.Text, type);
            }
        }
        if (c.Count() == 2)
        {

            foreach (var con in c)
            {
                diem.Add(con);
            }
            if (t1.Text == "")
            {
                delete(diem[0]);

            }
            if (t2.Text == "")
            {
                delete(diem[1]);
            }
            if (t1.Text != "")
            {
                Update(diem[0], t1.Text);


            }
            if (t2.Text != "")
            {
                Update(diem[1], t2.Text);
            }
            
        }
        }
        
    }
    void SuaDiemThiHK(string mn, string mk, string ml, string mm, string mhs,int type,TextBox t1)
    {
        //List<int> diem = new List<int>();
        var c = from p in db.Scores
                where p.SchoolYearID == int.Parse(mn) && p.SemesterID == int.Parse(mk) && p.ClassID == int.Parse(ml)
                && p.SubjectID == int.Parse(mm) && p.StudentID == mhs && p.TypeScoreID ==type
                select p.ScoreID;

        if (c.Count() == 1)
        {
            if (t1.Text == "")
            {
                delete(c.First());
            }
            if (t1.Text != "")
            {
                Update(c.First(), t1.Text);


            }

            //Score sr = db.Scores.SingleOrDefault(p => p.ScoreID == c.First());
            //sr.Score1 = float.Parse(txtDiemThi.Text);
            //db.SubmitChanges();
        }
        else
        {
            if (c.Count() == 0)
        {
            if (t1.Text != "")
            {
                Insert(t1.Text, type);
            }

        }
      
        }
    
   
    }
    void Moi()
    {
        txtTenHS.Text = "";
        txtMaHS.Text = "";
        txtDiem15L1.Text = "";
        txtDiem15L2.Text = "";
        txtDiem15L3.Text = "";
        txtDiem15L4.Text = "";
        txtDiem45L1.Text = "";
        txtDiem45L2.Text = "";
        txtDiemM1.Text = "";
        txtDiemM2.Text = "";
        txtDiemM3.Text = "";
        txtDiemM4.Text = "";
        txtDiemThi.Text = "";
        txtThiLai.Text = "";
    }
    protected void btnMoi_Click(object sender, EventArgs e)
    {
        Moi();
    }
}
