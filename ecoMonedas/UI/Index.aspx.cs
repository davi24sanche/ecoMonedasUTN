using ecoMonedas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecoMonedas.UI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = UsuarioLN.listaCategorias().ToList();
            dataGridView1.DataBind();
        }
    }
}