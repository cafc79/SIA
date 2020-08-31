using System;
using Telerik.Web.UI;
using DS.SAI.Business;

public partial class UsrCtrls_RolDetail : System.Web.UI.UserControl
{
	private MenuRolManager _rolManager = new MenuRolManager();

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public void SetPerfil(int iRol)
	{
		treeRol.Nodes.Clear();
		rolID.Value = iRol.ToString();
		var perfil = _rolManager.GetRolById(iRol);
		lblRol.Text = perfil.sDescription;
		SetAccess(iRol);
	}

	private void SetAccess(int iRol)
	{
		var menuRol = _rolManager.getAllMenuRol(iRol);
		foreach (var menu in menuRol)
		{
			var nodo = new RadTreeNode(menu.sDescription, menu.iIdMenu.ToString());
			var etapas = _rolManager.GetMenuPagina(menu.iIdMenu, iRol);
			foreach (var hojas in etapas)
			{
				nodo.Nodes.Add(new RadTreeNode(hojas.sDescription + " - " + hojas.sPermisos, hojas.sURL));
			}
			treeRol.Nodes.Add(nodo);
		}
	}

	protected void treeRol_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
	{
		var valor = treeRol.SelectedValue;
		int rol = int.Parse(rolID.Value);
		try
		{
			if (treeRol.SelectedNode.Level == 0)
			{
				int menu1 = int.Parse(valor);
				_rolManager.DeleteRol(rol, menu1, string.Empty);
			}
			else
			{
				int menu2 = int.Parse(treeRol.SelectedNode.ParentNode.Value);
				_rolManager.DeleteRol(rol, menu2, valor);
			}
			SetPerfil(rol);
		}
		catch (Exception) { }
	}
}