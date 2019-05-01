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
using System.Web.UI.Design;
using System.Collections.Generic;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for clsThaoTac
/// </summary>
public class clsThaoTac
{

    EContactDataContext db = new EContactDataContext();
    public clsThaoTac()
    {

    }
     public void MaTuTang(string ma)
    {
        
        //string[] a = DateTime.Now.ToShortDateString().Split('/');
        //string dau = a[2].Substring(2, 2) + a[0] + a[1];
        //string madautien = dau + "001";
        //var c = from p in db.Scores select p.ScoreID;
        //string chuoi = "";
        //foreach (var con in c)
        //{

        //    if (con.ToString().Substring(0, 6) == dau)
        //    {
        //        list.Add(con.ToString());
        //    }
        //}
        //if (list.Count == 0)
        //{
        //    ma = madautien;
        //}
        //else
        //    if (list.Count > 0)
        //    {

        //        ma = (int.Parse(list[list.Count - 1]) + 1).ToString();

        //    }

    }
    public void LoadComboxNam(AjaxControlToolkit.ComboBox cboNH)
    {
        //var c = from p in db.SchoolYears select p;
        var c = from i in
                    (from p in db.ClassStudents select new {p.SchoolYearID, p.SchoolYear.SchoolYearName })
                group i by new { i.SchoolYearID, i.SchoolYearName } into g
                select new { g.Key.SchoolYearID, g.Key.SchoolYearName };
        cboNH.DataTextField = "SchoolYearName";
        cboNH.DataValueField = "SchoolYearID";
        cboNH.DataSource = c;
        cboNH.DataBind();

    }
    public void LoadComboxNam1(AjaxControlToolkit.ComboBox cboNH)
    {
        //var c = from p in db.SchoolYears select p;
        var c = from i in
                    (from p in db.TeacherSubjects select new { p.SchoolYearID, p.SchoolYear.SchoolYearName })
                group i by new { i.SchoolYearID, i.SchoolYearName } into g
                select new { g.Key.SchoolYearID, g.Key.SchoolYearName };
        if (c.Count() != 0)
        {
            cboNH.DataTextField = "SchoolYearName";
            cboNH.DataValueField = "SchoolYearID";
            cboNH.DataSource = c;
            cboNH.DataBind();
        }

    }
    public void LoadcboNam(AjaxControlToolkit.ComboBox cboNam)
    {
        var c = from i in
                    (from p in db.ClassDepartments select new { p.SchoolYearID, p.SchoolYear.SchoolYearName })
                group i by new { i.SchoolYearID, i.SchoolYearName } into g
                select new { g.Key.SchoolYearID, g.Key.SchoolYearName };
        cboNam.DataTextField = "SchoolYearName";
        cboNam.DataValueField = "SchoolYearID";
        cboNam.DataSource = c;
        cboNam.DataBind();
    }
    public void LoadComBoxKy(AjaxControlToolkit.ComboBox cboKy)
    {
        var c = from p in db.Semesters select p;
        cboKy.DataTextField = "SemesterName";
        cboKy.DataValueField = "SemesterID";
        cboKy.DataSource = c;
        cboKy.DataBind();
    }
    public void LoadCbLop(AjaxControlToolkit.ComboBox cboLop,string manam)
    {
        var c = from i in
                    (from p in db.ClassStudents where p.SchoolYearID==int.Parse(manam) select new { p.ClassID, p.Class.ClassName })
                group i by new { i.ClassID, i.ClassName } into g
                select new { g.Key.ClassID,g.Key.ClassName};
        cboLop.DataTextField = "ClassName";
        cboLop.DataValueField = "ClassID";
        cboLop.DataSource = c;
        cboLop.DataBind();
    }
    public void LoadCbMon(AjaxControlToolkit.ComboBox cboMon)
    {
        var c = from p in db.Subjects select p;
        cboMon.DataTextField = "SubjectName";
        cboMon.DataValueField = "SubjectID";
        cboMon.DataSource = c;
        cboMon.DataBind();
    }public void LoadCbCity(AjaxControlToolkit.ComboBox cboCity)
    {
        var c = from p in db.Cities select p;
        cboCity.DataTextField = "NameCity";
        cboCity.DataValueField = "id_city";
        cboCity.DataSource = c;
        cboCity.DataBind();
    }
    public void LoadCbQuan(AjaxControlToolkit.ComboBox cboQuan)
    {
        var c = from p in db.Districts select p;
        cboQuan.DataTextField = "NameDistrict";
        cboQuan.DataValueField = "id_district";
        cboQuan.DataSource = c;
        cboQuan.DataBind();
    }
    public void LoadCbLoaiDiem(AjaxControlToolkit.ComboBox cboLoaiDiem)
    {
        var c = from p in db.TypeScores select p;
        cboLoaiDiem.DataTextField = "TypeScoreName";
        cboLoaiDiem.DataValueField = "TypescoreID";
        cboLoaiDiem.DataSource = c;
        cboLoaiDiem.DataBind();
    }
    public void LoadCbKhoi(AjaxControlToolkit.ComboBox cboKhoi)
    {
        var c = from p in db.GradeSchools select p;
        cboKhoi.DataTextField = "GradeSchoolName";
        cboKhoi.DataValueField = "GradeSchoolID";
        cboKhoi.DataSource = c;
        cboKhoi.DataBind();
    }
    public void LoadCBBan(AjaxControlToolkit.ComboBox cboBan)
    {
        var c = from p in db.Departments select p;
        cboBan.DataTextField = "DepartmentName";
        cboBan.DataValueField = "DepartmentID";
        cboBan.DataSource = c;
        cboBan.DataBind();
    }
   public  void LoadComBoxHS(AjaxControlToolkit.ComboBox cboTenHS,string manam,string malop)
    {

        var c = from p in db.ClassStudents
                where p.ClassID == int.Parse(malop) &&
                p.SchoolYearID == int.Parse(manam)
                select new { p.StudentID, p.Student.StudentName };

        cboTenHS.DataTextField = "StudentName";
        cboTenHS.DataValueField = "StudentID";
        cboTenHS.DataSource = c;
        cboTenHS.DataBind();
    }
   public void LoadCBNamTheoGV(string magv, AjaxControlToolkit.ComboBox cboNam)
   {
      
           var c = from i in
                       (from p in db.ClassDepartments
                        where p.TeacherID == magv
                        && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date > DateTime.Now.Date
                        select new { p.SchoolYearID, p.SchoolYear.SchoolYearName })
                   group i by new { i.SchoolYearID, i.SchoolYearName } into gr
                   select new { gr.Key.SchoolYearID, gr.Key.SchoolYearName };
           if (c.Count() != 0)
           {
               cboNam.DataTextField = "SchoolYearName";
               cboNam.DataValueField = "SchoolYearID";
               cboNam.DataSource = c;
               cboNam.DataBind();
           }
   }
 public void LoadCBNamTheoGV1(string magv,AjaxControlToolkit.ComboBox cboNam)
   {

       var ad = from p in db.Users_UserGroups
                where p.UserGroupID == 1 &&p.TeacherID==magv
                    && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date > DateTime.Now.Date
                select p;
       if (ad.Count() == 0)
       {
           var c = from i in
                       (from p in db.ClassDepartments
                        where p.TeacherID == magv
                        && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date > DateTime.Now.Date
                        select new { p.SchoolYearID, p.SchoolYear.SchoolYearName })
                   group i by new { i.SchoolYearID, i.SchoolYearName } into gr
                   select new { gr.Key.SchoolYearID, gr.Key.SchoolYearName };
           if (c.Count() != 0)
           {
               cboNam.DataTextField = "SchoolYearName";
               cboNam.DataValueField = "SchoolYearID";
               cboNam.DataSource = c;
               cboNam.DataBind();
           }
       }
       if (ad.Count() != 0)
       {
           var c1 = from i in
                       (from p in db.ClassDepartments select new { p.SchoolYearID, p.SchoolYear.SchoolYearName })
                   group i by new { i.SchoolYearID, i.SchoolYearName } into grp
                   select new { grp.Key.SchoolYearID, grp.Key.SchoolYearName };
           if (c1.Count() != 0)
           {
               cboNam.DataTextField = "SchoolYearName";
               cboNam.DataValueField = "SchoolYearID";
               cboNam.DataSource = c1;
               cboNam.DataBind();
           }
       }
       
   }
 public void LoadCBLopTheoGV(string magv,AjaxControlToolkit.ComboBox cboLop,AjaxControlToolkit.ComboBox cboNam)
   {
      
           var c = from i in
                       (from p in db.ClassDepartments
                        where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                            && p.TeacherID == magv
                            && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date > DateTime.Now.Date
                        select new { p.ClassID, p.Class.ClassName })
                   group i by new { i.ClassName, i.ClassID } into grp
                   select new { grp.Key.ClassID, grp.Key.ClassName };

           cboLop.DataTextField = "ClassName";
           cboLop.DataValueField = "ClassID";
           cboLop.DataSource = c;
           cboLop.DataBind();
       
       


   }
 public void LoadCBLopTheoGV1(string magv, AjaxControlToolkit.ComboBox cboLop, AjaxControlToolkit.ComboBox cboNam)
 {
     var ad = from p in db.Users_UserGroups
              where p.UserGroupID == 1 && p.TeacherID == magv
                  && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date > DateTime.Now.Date
              select p;
     if (ad.Count() == 0)
     {
         var c = from i in
                     (from p in db.ClassDepartments
                      where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                          && p.TeacherID == magv
                          && p.SchoolYear.BeginDate.Value.Date < DateTime.Now.Date && p.SchoolYear.EndDate.Value.Date > DateTime.Now.Date
                      select new { p.ClassID, p.Class.ClassName })
                 group i by new { i.ClassName, i.ClassID } into grp
                 select new { grp.Key.ClassID, grp.Key.ClassName };

         cboLop.DataTextField = "ClassName";
         cboLop.DataValueField = "ClassID";
         cboLop.DataSource = c;
         cboLop.DataBind();

     }
     if (ad.Count() != 0)
     {
         var c = from i in
                     (from p in db.ClassDepartments
                      where p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                          
                      select new { p.ClassID, p.Class.ClassName })
                 group i by new { i.ClassName, i.ClassID } into grp
                 select new { grp.Key.ClassID, grp.Key.ClassName };
         cboLop.DataTextField = "ClassName";
         cboLop.DataValueField = "ClassID";
         cboLop.DataSource = c;
         cboLop.DataBind();
     }


 }
   public bool CheckEmail(string Email)
   {
       bool check = true;

       Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
       if (regex.IsMatch(Email) == false)
       {
           check = false;
       }
       return check;
   }
   private bool IsNumber(string val)
   {
       if (val != "")
           return Regex.IsMatch(val, @"^[0-9]\d*\.?[0]*$");
       else return true;
   }
   public bool CheckPhone(string Phone)
   {
       bool check = true;
       
       Regex regex = new Regex(@"^[0-9]\d*\.?[0]*$");
       //Regex regex = new Regex();
       if (regex.IsMatch(Phone) == false)
       {
           check = false;
       }
       return check;
   }
}