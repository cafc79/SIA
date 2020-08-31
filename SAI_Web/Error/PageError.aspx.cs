using System;

public partial class Error_PageError : System.Web.UI.Page
{
	private string soundPath;
	protected void Page_Load(object sender, EventArgs e)
	{
		// Display Error
		var friendlyError = new FriendlyError();
		Page.Title = friendlyError.GetErrorMessage();
		lblMessage.Text = friendlyError.GetErrorMessage();
		lblFile.Text = String.Format("{0} &mdash; {1}", friendlyError.GetFileName(), friendlyError.GetErrorCoordinates());
		ltlSource.Text = friendlyError.GetSourceCode(-4, 3);

		// Display picture
		imgPicture.ImageUrl = Page.ResolveUrl(friendlyError.GetRandomPicture());

		// Play sound
		//soundPath = Page.ResolveUrl(friendlyError.GetRandomSound());

		// Display motivational message
		lblMotivation.Text = "Existe una incosistencia en la información por lo cual tu petición no puede ser procesada. El estatus de los valores de uno o mas catalogos no coinciden con la información";
	}
}