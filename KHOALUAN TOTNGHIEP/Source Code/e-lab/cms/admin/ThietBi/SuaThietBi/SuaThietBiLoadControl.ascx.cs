using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.admin.ThietBi.SuaThietBi
{
    public partial class SuaThietBiLoadControl : System.Web.UI.UserControl
    {
        string matb = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["matb"] != null)
                matb = Request.QueryString["matb"];

            DataTable dt = new DataTable();
            dt = e_lab.ThietBi.ds_tb_matb(matb);

            TenTB.Text = dt.Rows[0]["TenThietBi"].ToString();
            SoLuongTon.Text = dt.Rows[0]["SoLuongTon"].ToString();
            NgayBaoDuong.Text = dt.Rows[0]["NgayBaoDuong"].ToString();
            DVT.Text = dt.Rows[0]["DVT"].ToString();
            
            if (!IsPostBack)
            {

                LayDS_nsx();
                LayDS_ncc();
            }
        }

        protected string getmatb() {
            return matb;
        }

        private void LayDS_ncc()
        {
            DataTable dt = new DataTable();
            dt = e_lab.NhaCungCap.ds_ncc();
            ddl_ncc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_ncc.Items.Add(new ListItem(dt.Rows[i]["TenNCC"].ToString(), dt.Rows[i]["MaNCC"].ToString()));
            }
        }

        private void LayDS_nsx()
        {
            DataTable dt = new DataTable();
            dt = e_lab.NhaSanXuat.ds_nsx();
            ddl_nsx.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_nsx.Items.Add(new ListItem(dt.Rows[i]["TenNSX"].ToString(), dt.Rows[i]["MaNSX"].ToString()));
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            NgayBaoDuong.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            int soluongton;
            int.TryParse(SoLuongTon.Text, out soluongton);
            e_lab.ThietBi.sua_tb(matb, TenTB.Text, ddl_nsx.SelectedValue, ddl_ncc.SelectedValue, soluongton, NgayBaoDuong.Text, DVT.Text);
            e_lab.ThietBi.update_soluong();
            e_lab.ThietBi.update_trangthai_btbd();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
            resetInput();
        }

        protected void btn_nhaplai_Click(object sender, EventArgs e)
        {
            resetInput();
        }

        private void resetInput()
        {
            TenTB.Text = SoLuongTon.Text = NgayBaoDuong.Text = "";
        }
    }
}