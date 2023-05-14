using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.CTPXDungCu.SuaCTPXDungCu
{
    public partial class SuaCTPXDungCuLoadControl : System.Web.UI.UserControl
    {
        string mapxk = "";
        string madc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapxk"] != null)
                mapxk = Request.QueryString["mapxk"];
            if (Request.QueryString["madc"] != null)
                madc = Request.QueryString["madc"];
        }


        protected string getmapxk()
        {
            return mapxk;
        }

        protected string getmadc()
        {
            return madc;
        }

        //protected Boolean daTonTai()
        //{
        //    DataTable dt = new DataTable();
        //    dt = e_lab.PhieuXuat.ds_dc_check(ddl_dungcu.SelectedValue, mapxk);
        //    if (dt.Rows.Count > 0)
        //        return false;
        //    else
        //        return true;
        //}

        protected Boolean isEnough() {
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_dungcukhoa_madc(Session["MaDonVi"].ToString(), madc);
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
                e_lab.PhieuXuatKhoa.sua_ctpx_dc(SoLuong.Text, mapxk, madc);
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