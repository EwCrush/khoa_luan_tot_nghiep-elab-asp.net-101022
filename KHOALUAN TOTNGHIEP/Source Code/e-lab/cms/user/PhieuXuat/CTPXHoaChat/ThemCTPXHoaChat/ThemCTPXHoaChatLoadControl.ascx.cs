using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.PhieuXuat.CTPXHoaChat.ThemCTPXHoaChat
{
    public partial class ThemCTPXHoaChatLoadControl : System.Web.UI.UserControl
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
            dt = e_lab.HoaChat.ds_hc();
            ddl_hoachat.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_hoachat.Items.Add(new ListItem(dt.Rows[i]["TenHC"].ToString(), dt.Rows[i]["MaHC"].ToString()));
            }
        }

        protected Boolean isEnough()
        {
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_hoachatkhoa_mahc(Session["MaDonVi"].ToString(), ddl_hoachat.SelectedValue.ToString());
            int soluongco;
            int.TryParse(dt.Rows[0]["SoLuongTon"].ToString(), out soluongco);
            int soluongcan;
            int.TryParse(SoLuong.Text.ToString(), out soluongcan);
            if (soluongcan > soluongco)
                return false;
            else
                return true;
        }

        protected Boolean daTonTai()
        {
            DataTable dt = new DataTable();
            dt = e_lab.PhieuXuatKhoa.ds_hc_check(ddl_hoachat.SelectedValue, mapxk);
            if (dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        protected string getmapxk()
        {
            return mapxk;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            if (daTonTai() == true)
            {
                if (isEnough() == true)
                {
                    e_lab.PhieuXuatKhoa.them_ctpx_hc(mapxk, ddl_hoachat.SelectedValue, SoLuong.Text);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                    SoLuong.Text = "";
                }
                else {
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