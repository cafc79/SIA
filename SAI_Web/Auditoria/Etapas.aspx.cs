using System;
using System.Data;

public partial class Auditoria_Etapas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable nodeTable = new DataTable();
        nodeTable.Columns.Add("ID");
        nodeTable.Columns.Add("ParentID");
        nodeTable.Columns.Add("TeamName");
 
        nodeTable.Rows.Add(new String[] { "1", null, "Corte" });
        nodeTable.Rows.Add(new String[] { "2", "1", "Doblado" });
        nodeTable.Rows.Add(new String[] { "3", "2", "Acabado" });
        nodeTable.Rows.Add(new String[] { "4", "2", "Pulido" });
        nodeTable.Rows.Add(new String[] { "5", "3", "Calidad" });
 
        DataTable itemsTable = new DataTable();
        itemsTable.Columns.Add("NodeID");
        itemsTable.Columns.Add("ID");
        itemsTable.Columns.Add("Text");
        itemsTable.Columns.Add("Certificates");
 
        itemsTable.Rows.Add(new String[] { "1", "1", "Inicio: Jul 1, 2011", "Materia prima incompleta retraso de 1 día" });
        itemsTable.Rows.Add(new String[] { "2", "2", "Inicio: Jul 3, 2011", "El lote recibido no completa el requerimiento" });
        itemsTable.Rows.Add(new String[] { "2", "3", "Inicio: Jul 4, 2011", "" });
        itemsTable.Rows.Add(new String[] { "3", "4", "Inicio: Jul 5, 2011", "Holgura Agotada" });
        itemsTable.Rows.Add(new String[] { "4", "5", "Inicio: Jul 5, 2011", "Rechazados por Defectos" });
        itemsTable.Rows.Add(new String[] { "5", "5", "Inicio: Jul 5, 2011", "Muestra al 2% Satisfactoria" });
 
        RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataFieldID = "ID";
        RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataFieldParentID = "ParentID";
        RadOrgChart1.GroupEnabledBinding.NodeBindingSettings.DataSource = nodeTable;
 
        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataFieldNodeID = "NodeID";
        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataFieldID = "ID";
        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataTextField = "Text";
        RadOrgChart1.GroupEnabledBinding.GroupItemBindingSettings.DataSource = itemsTable;
 
        RadOrgChart1.DataBind();
    }
}