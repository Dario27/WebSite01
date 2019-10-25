using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pag01 : System.Web.UI.Page
{
    MiBaseEntities objBase = new MiBaseEntities();
    public string x;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCombo();            
        }
    }

    protected void btn_Grabar_Click(object sender, EventArgs e)
    {
        string bili = "";

        if (rboSi.Checked)
        {
            bili = "S";
        }
        else if (RboNo.Checked)
        {
            bili = "N";

        }

        int Cod1 = Convert.ToInt32(NuevoCodigo());
        string nombre = txtNomUni.Text;
        short cant = Convert.ToInt16(txtCant.Text);        
        short cat = Convert.ToInt16(cboCat.SelectedIndex);

        using (var context = new MiBaseEntities())
        {
            var U = new tbm_universidades
            {
                co_uni = Convert.ToInt16(Cod1),
                tx_nom = nombre,
                CantEst = cant,
                Bili = bili,
                St_reg = "A",
                Cod_Cat = cat
            };

            context.tbm_universidades.Add(U);
            context.SaveChanges();
        }

        Response.Write("<script language=javascript> alert('Datos guardados con exito');</script>");
    }
    public int NuevoCodigo()
    {
        int cod = 0;
        var x = (from c in objBase.tbm_universidades
                 select c.co_uni).Max();
        cod = x + 1;
        return cod;
    }

    public void cargarCombo()
    {
        var aux = from a1 in objBase.tbm_categorias
                  select new { a1.Cod_Cat, a1.Txt_Nom };
        if (aux != null)
        {
            //cboCiu.DataSource = lstCiu;
            cboCat.DataSource = aux.ToList();
            cboCat.DataTextField = "Txt_Nom";
            cboCat.DataValueField = "Cod_Cat";
            cboCat.DataBind();
            cboCat.Items.Insert(0, "(Todas)");
        }
    }

    protected void cboCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        //x = cboCat.SelectedValue;
    }
}