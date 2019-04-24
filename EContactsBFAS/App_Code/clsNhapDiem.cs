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
/// Summary description for clsNhapDiem
/// </summary>
public class clsNhapDiem
{
	public clsNhapDiem()
	{
		
	}
    public void tachdiem(string chuoidiem)
    {
        //List<string> diem = new List<string>();
        
        if(chuoidiem.Contains(';')==true)
        {
            string[] diem;
            diem = chuoidiem.Split(';');
        }
    }
}
