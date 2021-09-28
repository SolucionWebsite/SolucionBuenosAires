using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuenosAiresService.WCF;

namespace BuenosAiresWeb.GUI
{
    public partial class Seguimiento : System.Web.UI.Page
    {
        BuenosAiresService.WCF.Seguimiento seguimiento = new BuenosAiresService.WCF.Seguimiento();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BtnBuscar_Click(object sender, EventArgs e)
        {
            List<BuenosAiresService.WCF.Seguimiento> registros = seguimiento.SolicitarSeguimiento(Int32.Parse(TxtOrden.Text));
            GrdSeguimiento.DataSource = registros;
            GrdSeguimiento.DataBind();
            if (registros.Count != 0)
            {
                GrdSeguimiento.HeaderRow.Cells[0].Text = "ORDEN COMPRA";
                GrdSeguimiento.HeaderRow.Cells[1].Text = "ESTADO";
                GrdSeguimiento.HeaderRow.Cells[2].Text = "FECHA";
            }
        }
    }
}