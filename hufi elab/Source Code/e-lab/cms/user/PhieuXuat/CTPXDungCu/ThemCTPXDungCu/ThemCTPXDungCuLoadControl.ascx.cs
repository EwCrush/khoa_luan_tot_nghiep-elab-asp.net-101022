using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.CTPXDungCu.ThemCTPXDungCu
{
    public partial class ThemCTPXDungCuLoadControl : System.Web.UI.UserControl
    {
        string mapxk = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapxk"] != null)
                mapxk = Request.QueryString["mapxk"];
            if (!IsPostBack)
                layDSHoaChat();
        }

        private void layDSHoaChat()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DungCu.ds_dc();
            ddl_dungcu.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_dungcu.Items.Add(new ListItem(dt.Rows[i]["TenDC"].ToString(), dt.Rows[i]["MaDC"].ToString()));
            }
        }

        protected string getmapxk()
        {
            return mapxk;
        }

        protected Boolean daTonTai()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.ds_dc_check(ddl_dungcu.SelectedValue, mapxk);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        protected Boolean isEnough()
        {
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_dungcukhoa_madc(Session["MaDonVi"].ToString(), ddl_dungcu.SelectedValue.ToString());
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
            if (daTonTai() == true)
            {
                if (isEnough() == true)
                {
                    e_lab.PhieuXuatKhoa.them_ctpx_dc(mapxk, ddl_dungcu.SelectedValue, SoLuong.Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                    SoLuong.Text = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Not enough')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data already exists')", true);
            }
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            SoLuong.Text = "";
        }
    }
}