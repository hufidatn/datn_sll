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

public partial class GiaoDien_DanhSachHocSinh : System.Web.UI.Page
{
    EContactDataContext db = new EContactDataContext();
    clsThaoTac cls = new clsThaoTac();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cls.LoadComboxNam(cboNamHoc);
            cls.LoadCbLop(cboLop, cboNamHoc.SelectedItem.Value.ToString());
            LoadDSHS();
        }
    }
    protected void btnThem_Click(object sender, EventArgs e)
    {
        LoadDSHS();
    }
    void LoadDSHS()
    {
        var c = from p in db.ClassStudents
                where p.ClassID == int.Parse(cboLop.SelectedItem.Value.ToString())
                    && p.SchoolYearID == int.Parse(cboNamHoc.SelectedItem.Value.ToString())
                select new { p.StudentID, p.Student.StudentName, p.Student.Gender, p.Student.DateOfBirth, p.Student.Address };
        grvHocSinh.DataSource = c;
        grvHocSinh.DataBind();
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
            //Download source code tại Sharecode.vn
            sb.Append("Năm học:" + "\t" + cboNamHoc.SelectedItem.Text);
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("Lớp học:" + "\t" + cboLop.SelectedItem.Text);
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("Danh sách học sinh:" + "\t" );
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            sb = new StringBuilder();
            sb.Append("STT" + "\t" + "Mã HS" + "\t" + "Tên HS" + "\t" + "Ngày sinh" + "\t" + "Giới tính" + "\t" + "Quê quán" );
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            //Duyệt từng bản ghi 
            int soDem = 0;

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
                Label lblNgaySinh = (Label)row.FindControl("lblNgaySinh");
                if (lblNgaySinh.Text != "")
                {
                    sb.Append(lblNgaySinh.Text);
                    sb.Append("\t");
                }
                if (lblNgaySinh.Text == "" || lblNgaySinh.Text == null)
                {
                   
                        sb.Append("");
                        sb.Append("\t");
                   
                }
                Label lblGioi = (Label)row.FindControl("lblGioi");
                if (lblGioi.Text != "")
                {
                    sb.Append(lblGioi.Text);
                    sb.Append("\t");
                }
                if (lblGioi.Text == "" || lblGioi.Text == null)
                {
                        sb.Append("");
                        sb.Append("\t");
                   
                }
                Label lblDC = (Label)row.FindControl("lblDC");
                if (lblDC.Text != "")
                {
                    sb.Append(lblDC.Text);
                    sb.Append("\t");
                }
                if (lblDC.Text == "" || lblDC.Text == null)
                {
                   
                        sb.Append("");
                        sb.Append("\t");
                   
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
    protected void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls.LoadCbLop(cboLop, cboNamHoc.SelectedItem.Value.ToString());
    }
    protected void btnXuatEcel_Click(object sender, EventArgs e)
    {
        ExportToExcel("DanhSachHS_Lop"+cboLop.SelectedItem.Text+".xls", grvHocSinh);
    }
}
