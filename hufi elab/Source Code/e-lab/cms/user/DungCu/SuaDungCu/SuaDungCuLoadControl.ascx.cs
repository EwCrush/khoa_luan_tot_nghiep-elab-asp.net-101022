using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_lab.cms.user.DungCu.SuaDungCu
{
    public partial class SuaDungCuLoadControl : System.Web.UI.UserControl
    {
        string madc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["madc"] != null)
                madc = Request.QueryString["madc"];
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_dungcukhoa_madc(Session["MaDonVi"].ToString(), madc);
            SoLuongTon.Text = dt.Rows[0]["SoLuongTon"].ToString();
        }

        protected string getmadv()
        {
            DataTable dt = new DataTable();
            dt = e_lab.DonVi.get_tendv(Session["MaDonVi"].ToString());
            return dt.Rows[0]["TenDV"].ToString();
        }

        protected string getmadc()
        {
            return madc;
        }

        protected int getsoluong()
        {
            int kq;
            string soluong = "";
            DataTable dt = new DataTable();
            dt = e_lab.VatTuKhoa.ds_dungcukhoa_madc(Session["MaDonVi"].ToString(), madc);
            soluong = dt.Rows[0]["SoLuongTon"].ToString();
            int.TryParse(soluong, out kq);
            return kq;
        }


        protected void btncapnhat_Click(object sender, EventArgs e)
        {
            int soluongton;
            int.TryParse(SoLuongTon.Text, out soluongton);

            if (soluongton > getsoluong())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed')", true);
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                e_lab.VatTuKhoa.sua_dc(madc, Session["MaDonVi"].ToString(), SoLuongTon.Text);
                e_lab.HoaChat.update_soluong();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data has been saved')", true);
                SoLuongTon.Text = "";
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            SoLuongTon.Text = "";
        }
    }
}