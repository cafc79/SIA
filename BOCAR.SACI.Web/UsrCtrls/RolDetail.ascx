<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RolDetail.ascx.cs" Inherits="UsrCtrls_RolDetail" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<script type="text/javascript">
    //<!--
    function OnClientNodeDropped(args) {

        var node = args.get_htmlElement();
        alert(node.get_text());
    }
    
    //-->
        </script>


<style type="text/css">
    h2 { font-size: 21px; padding-bottom: 10px; color: #4D4D4D; border-bottom: solid 1px #4D4D4D; margin-right: 18px; margin-top: 20px; }
</style>
<div class="niobe">
<br/>
<h2>
    Perfil de Usuario:
    <asp:Label runat="server" ID="lblRol"></asp:Label>
    <asp:HiddenField ID="rolID" runat="server" />
 </h2>
<h3>Niveles de Acceso al Sistema</h3>
<telerik:RadTreeView ID="treeRol" Runat="server" Skin="Sitefinity" 
        SingleExpandPath="True" EnableDragAndDrop="True" 
        onnodedrop="treeRol_NodeDrop" >

    </telerik:RadTreeView>
</div>