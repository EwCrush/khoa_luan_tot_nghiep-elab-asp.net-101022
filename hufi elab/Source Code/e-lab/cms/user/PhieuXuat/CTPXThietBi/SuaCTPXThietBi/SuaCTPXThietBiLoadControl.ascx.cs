using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.CTPXThietBi.SuaCTPXThietBi
{
    public partial class SuaCTPXThietBiLoadControl : System.Web.UI.UserControl
    {
        string mapxk = "";
        string matb = "";
        string mapl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapxk"] != null)
                mapxk = Request.QueryString["mapxk"];
            if (Request.QueryString["mapl"] != null)
                mapl = Request.QueryString["mapl"];
            if (Request.QueryString["matb"] != null)
                matb = Request.QueryString["matb"];
        }



        protected string getmapxk()
        {
            return mapxk;
        }

        protected string getmapl()
        {
            return mapl;
        }

        protected string getmatb()
        {
            return matb;
        }

        protected Boolean isEnough()
        {
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_thietbikhoa_matb(Session["MaDonVi"].ToString(), matb, mapl);
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
                e_lab.PhieuXuatKhoa.sua_ctpx_tb(SoLuong.Text, mapxk, matb, mapl);
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