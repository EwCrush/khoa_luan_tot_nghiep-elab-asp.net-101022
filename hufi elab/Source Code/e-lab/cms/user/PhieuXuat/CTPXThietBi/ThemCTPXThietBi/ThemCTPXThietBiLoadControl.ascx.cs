using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.CTPXThietBi.ThemCTPXThietBi
{
    public partial class ThemCTPXThietBiLoadControl : System.Web.UI.UserControl
    {
        string mapxk = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mapxk"] != null)
                mapxk = Request.QueryString["mapxk"];
            if (!IsPostBack)
            {
                layDSTB();
                layDSPL();
            }
        }

        private void layDSTB()
        {
            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_tb();
            ddl_thietbi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_thietbi.Items.Add(new ListItem(dt.Rows[i]["TenThietBi"].ToString(), dt.Rows[i]["MaTB"].ToString()));
            }
        }

        private void layDSPL()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhongLab.ds_phonglab();
            ddl_phonglab.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_phonglab.Items.Add(new ListItem(dt.Rows[i]["TenPL"].ToString(), dt.Rows[i]["MaPL"].ToString()));
            }
        }

        protected Boolean daTonTai()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.ds_tb_check(ddl_thietbi.SelectedValue, mapxk, ddl_phonglab.SelectedValue);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        protected string getmapxk()
        {
            return mapxk;
        }

        protected Boolean isEnough()
        {
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_thietbikhoa_matb(Session["MaDonVi"].ToString(), ddl_thietbi.SelectedValue.ToString(), ddl_phonglab.SelectedValue.ToString());
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
                    e_lab.PhieuXuatKhoa.them_ctpx_tb(mapxk, ddl_thietbi.SelectedValue, ddl_phonglab.SelectedValue, SoLuong.Text);
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