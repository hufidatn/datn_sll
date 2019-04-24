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
using System.Text;

public partial class GiaoDien_Tongdiem : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    BangDiem bd = new BangDiem();
    LinQ lq = new LinQ();
    protected void Page_Load(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        if (!IsPostBack)
        {
            cls.LoadCBNamTheoGV1(c.First(), cboNam);
            cls.LoadCBLopTheoGV1(c.First(), cboLop, cboNam);
            //cls.LoadComboxNam(cboNam);
            //cls.LoadCbLop(cboLop,cboNam.SelectedItem.Value.ToString());
        }

    }
    DataTable dt;
    DataTable dtcn;
    void LoadKQRL()
    {
        dt = new DataTable();
        dtcn = new DataTable();
        dt.Columns.Add("MaHS",typeof(string));
        dt.Columns.Add("TenHS",typeof(string));
        dt.Columns.Add("TBMHK1", typeof(string));
        dt.Columns.Add("TBMHK2", typeof(string));
        dt.Columns.Add("TBMCN", typeof(string));
        dt.Columns.Add("HLCN", typeof(string));
        dt.Columns.Add("HKCN", typeof(string));
        
        DataTable dt1 = new DataTable();
        bd.LoadDiemCuaLopTheoKy(cboNam.SelectedItem.Value.ToString(), "1", cboLop.SelectedItem.Value.ToString(), dt1);
        DataTable dt2 = new DataTable();
        bd.LoadDiemCuaLopTheoKy(cboNam.SelectedItem.Value.ToString(), "2", cboLop.SelectedItem.Value.ToString(), dt2);

        dtcn.Columns.Add("STT", typeof(string));
        dtcn.Columns.Add("MaHS", typeof(string));
        dtcn.Columns.Add("TenHS", typeof(string));
        dtcn.Columns.Add("Toan", typeof(string));

        dtcn.Columns.Add("Van", typeof(string));
        dtcn.Columns.Add("Ly", typeof(string));
        dtcn.Columns.Add("Hoa", typeof(string));
        dtcn.Columns.Add("LichSu", typeof(string));
        dtcn.Columns.Add("DiaLy", typeof(string));
        dtcn.Columns.Add("Sinh", typeof(string));
        dtcn.Columns.Add("NgoaiNgu", typeof(string));
        dtcn.Columns.Add("GDCD", typeof(string));
        dtcn.Columns.Add("Tin", typeof(string));

        dtcn.Columns.Add("CongNghe", typeof(string));
        dtcn.Columns.Add("TheDuc", typeof(string));
        dtcn.Columns.Add("GDQP", typeof(string));
        dtcn.Columns.Add("DTB", typeof(string));
        dtcn.Columns.Add("HL", typeof(string));
        dtcn.Columns.Add("HK", typeof(string));

        int stt = 0;
        var c = (from p in db.ClassDepartments
                 where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString()) &&
                     p.SchoolYearID == int.Parse(cboNam.SelectedItem.Value.ToString())
                 select p.DepartmentID).First();
        if(dt1.Rows.Count!=0&&dt2.Rows.Count!=0)
        {
        lq.TongDiemCN(dtcn,dt1,dt2,stt,c);
        foreach (DataRow r1 in dt1.Rows)
        {
            DataRow dr = dt.NewRow();
            
                foreach (DataRow r2 in dt2.Rows)
                {

                    if (r1[1].ToString() == r2[1].ToString())
                    {
                        foreach (DataRow rcn in dtcn.Rows)
                        {
                            if (r1[1].ToString() == rcn[1].ToString())
                            {

                                dr[0] = r1[1].ToString();
                                dr[1] = r1[2].ToString();
                                string s = r1[1].ToString();

                                dr[2] = r1[16].ToString();
                                dr[3] = r2[16].ToString();
                                if (r1[16].ToString() == "" || r2[16].ToString() == "")
                                { dr[4] = ""; }
                                else
                                    if (r1[16].ToString() != "" && r2[16].ToString() != "")
                                    {
                                        string diem =rcn[16].ToString();
                                        dr[4]=diem;
                                        //dr[4] = lq.LamTronDiem(diem);
                                        dr[5] = rcn[17].ToString(); dr[6] = r2[18].ToString();
                                    }
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
        //}
        //    else 
        //        if(dt2.Rows.Count==0)
        //        {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Kỳ 2 chưa có điểm');", true);
        //        }
        }
        if (dt1.Rows.Count != 0 && dt2.Rows.Count == 0)
        {
            foreach (DataRow r1 in dt1.Rows)
            {
                DataRow dr = dt.NewRow();
                dr[0] = r1[1].ToString();
                dr[1] = r1[2].ToString();
                //string s = r1[1].ToString();
                if (r1[16].ToString() != "")
                {
                    dr[2] = r1[16].ToString();
                    
                }
                if (r1[16].ToString() == "")
                {
                    dr[2] = "";
                }
                dr[3] = "";
                //if (r1[16].ToString() == "" || r2[16].ToString() == "")
                dr[4] = "";
                dr[5] = ""; dr[6] = "";
                dt.Rows.Add(dr);
                        
                        
                }          
        }
        if (dt1.Rows.Count == 0 && dt2.Rows.Count == 0)
        {
            var hs=from p in db.ClassStudents where p.ClassID==int.Parse(cboLop.SelectedItem.Value.ToString())
                  && p.SchoolYearID==int.Parse(cboNam.SelectedItem.Value.ToString())
                  select new{p.StudentID,p.Student.StudentName};
            foreach (var con in hs)
            {
                DataRow dr = dt.NewRow();
                dr[0] = con.StudentID;
                dr[1] = con.StudentName;
                dr[2] = "";
                dr[3] = "";
                dr[4] = "";
                dr[5] = "";
                dr[6] = "";
                dt.Rows.Add(dr);
            }
            
                        
         }
    }
    //DataTable dtcn;
    void TongdiemCN()
    {
 
    }
    protected void btnTinh_Click(object sender, EventArgs e)
    {
        lblThongBao.InnerText = "";
        LoadKQRL();
        grvTV.DataSource = dt;
        grvTV.DataBind();
        if (grvTV.Rows.Count == 0)
        {
            lblThongBao.InnerText = "Hiện tại chưa có kết quả rèn luyện của lớp này.";
        }
    }
    protected void cboNam_SelectedIndexChanged(object sender, EventArgs e)
    {
        string giaovien = Session["UserName"].ToString();
        var c = from p in db.Teachers
                where p.UserName == giaovien
                select p.TeacherID;
        cls.LoadCBLopTheoGV1(c.First(), cboLop, cboNam);
        //cls.LoadCbLop(cboLop,cboNam.SelectedItem.Value.ToString());
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
            sb.Append("Lớp học:" + "\t" + cboLop.SelectedItem.Text);
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("STT" + "\t" + "Mã HS" + "\t" + "Tên HS" + "\t" + "DTBHK1" + "\t" + "DTBHK2" + "\t" + "DTBCN" + "\t" + "HLCN" + "\t" + " HKCN");
            Response.Write(sb.ToString() + "\n");
            Response.Flush();

            foreach (GridViewRow row in grv.Rows)
            {

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
                Label lblHK1 = (Label)row.FindControl("lblTBMHK1");
                if (lblHK1.Text != "")
                {
                    sb.Append(lblHK1.Text);
                    sb.Append("\t");
                }
                if (lblHK1.Text == "" || lblHK1.Text == null)
                {
                    sb.Append("");
                    sb.Append("\t");
                }
                Label lblHK2 = (Label)row.FindControl("lblTBMHK2");
                if (lblHK2.Text != "")
                {
                    sb.Append(lblHK2.Text);
                    sb.Append("\t");
                }
                if (lblHK2.Text == "" || lblHK2.Text == null)
                {

                    sb.Append("");
                    sb.Append("\t");
                }
                Label lblTBCN = (Label)row.FindControl("lblTBMCN");
                if (lblTBCN.Text != "")
                {
                    sb.Append(lblTBCN.Text);
                    sb.Append("\t");

                }
                if (lblTBCN.Text == "" || lblTBCN.Text == null)
                {

                    sb.Append("");
                    sb.Append("\t");

                }
                Label lblHLCN = (Label)row.FindControl("lblHLCN");
                if (lblHLCN.Text != "")
                {
                    sb.Append(lblHLCN.Text);
                    sb.Append("\t");
                }
                if (lblHLCN.Text == "" || lblHLCN.Text == null)
                {
                    sb.Append(""); sb.Append("\t");
                }
                Label lblHKCN = (Label)row.FindControl("lblHKCN");
                if (lblHKCN.Text != "")
                {
                    sb.Append(lblHKCN.Text);

                }
                if (lblHKCN.Text == "" || lblHKCN.Text == null)
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
    
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel("KetQuaRenLuyen.xls", grvTV);
    }
}
