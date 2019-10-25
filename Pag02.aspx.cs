using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pag02 : System.Web.UI.Page
{
    MiBaseEntities objBase = new MiBaseEntities();
    private int Tot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (cboCat.SelectedIndex == 0)
            {
                //cargarGrid();
            }
            cargarGrid();
            cargarCombo();
            cargarGridResumen();
        }        
    }

    public void cargarGridResumen()
    {
        var aux = (from u in objBase.tbm_universidades
                   join c in objBase.tbm_categorias on u.Cod_Cat equals c.Cod_Cat
                   group u by new { c.Txt_Nom, u.Cod_Cat}
            into g
                   select new { Categorias = g.Key.Txt_Nom, Total = g.Count(item => item.Cod_Cat == g.Key.Cod_Cat) });

        if (aux != null) {
            GridResumen.DataSource = aux.ToList();           
            GridResumen.DataBind();            
        }
    }

    public void cargarGridResumenFiltrado(int cat)
    {
        var aux = (from u in objBase.tbm_universidades
                   join c in objBase.tbm_categorias on u.Cod_Cat equals c.Cod_Cat
                   where u.Cod_Cat == cat
                   group u by new { c.Txt_Nom, u.Cod_Cat }
            into g
                   select new { Categorias = g.Key.Txt_Nom, Total = g.Count(item => item.Cod_Cat == g.Key.Cod_Cat) });

        if (aux != null)
        {
            GridResumen.DataSource = aux.ToList();            
            GridResumen.DataBind();

        }
    }

    protected void btn_bus_Click(object sender, EventArgs e)
    {
        if (cboCat.SelectedIndex == 0)
        {
            cargarGrid();
            cargarGridResumen();
        }
        else
        {
            int cat = cboCat.SelectedIndex;
            cargarGridXCaT();
            cargarGridResumenFiltrado(cat);
        }
        
    }

    private void cargarGrid()
    {        
        try
        {
            var j = from u in objBase.tbm_universidades 
                    join c in objBase.tbm_categorias on u.Cod_Cat equals c.Cod_Cat
                    select new
                    {
                       u.co_uni,
                       u.tx_nom,
                       u.CantEst,
                       u.Bili,
                       tbm_Categorias = c.Txt_Nom
                    };
            grid1.DataSource = j.ToList();
            grid1.DataBind();
        }
        catch (Exception ex)
        {
            string ac = ex.Message;
        }

    }

    private void cargarGridXCaT()
    {
        short ca = Convert.ToInt16(cboCat.SelectedIndex);
        try
        {
            var j = from u in objBase.tbm_universidades
                    join c in objBase.tbm_categorias on u.Cod_Cat equals c.Cod_Cat
                    where u.Cod_Cat == ca
                    select new
                    {
                        u.co_uni,
                        u.tx_nom,
                        u.CantEst,
                        u.Bili,
                        tbm_Categorias = c.Txt_Nom
                    };
            grid1.DataSource = j.ToList();
            grid1.DataBind();
        }
        catch (Exception ex)
        {
            string ac = ex.Message;
        }

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

    protected void GridResumen_RowDataBound(object sender, GridViewRowEventArgs e)
    {        
        if (e.Row.RowType == DataControlRowType.DataRow) {
            Tot += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = Tot.ToString();
        }
    }
}