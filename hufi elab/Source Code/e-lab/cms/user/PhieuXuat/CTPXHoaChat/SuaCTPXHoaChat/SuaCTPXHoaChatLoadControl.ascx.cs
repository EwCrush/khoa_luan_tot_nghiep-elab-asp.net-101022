using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.CTPXHoaChat.SuaCTPXHoaChat
{
    public partial class SuaCTPXHoaChatLoadControl : System.Web.UI.UserControl
    {
        string mapxk = "";
        string mahc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapxk"] != null)
                mapxk = Request.QueryString["mapxk"];
            if (Request.QueryString["mahc"] != null)
                mahc = Request.QueryString["mahc"];
        }



        protected string getmapxk()
        {
            return mapxk;
        }

        protected string getmahc()
        {
            return mahc;
        }

        protected Boolean isEnough()
        {
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_hoachatkhoa_mahc(Session["MaDonVi"].ToString(), mahc);
            int soluongco;
            int.TryParse(dt.Rows[0]["SoLuongTon"].ToString(), out soluongco);
            int soluongcan;
            int.TryParse(SoLuong.Text.ToString(), out soluongcan);
            if (soluongcan > soluongco)
                return false;
            else
                return true;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            if (isEnough() == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Not enough')", true);
            }
            else
            {
                e_lab.PhieuXuatKhoa.sua_ctpx_hc(SoLuong.Text, mapxk, mahc);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                SoLuong.Text = "";
            }
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}