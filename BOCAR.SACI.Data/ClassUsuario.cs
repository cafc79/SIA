namespace BOCAR.SACI.Data
{
	public class ClassUsuario
	{
		#region Propiedades
		//Usuario
		public string Usuario { get; set; }

		//idUsuario
		public int IdUsuario { get; set; }

		//idUsuario
		public int IdRol { get; set; }

		//Perfil del usuario
		public string Perfil { get; set; }

		//Autenticado
		public bool Autenticacion { get; set; }

		//Contraseña
		public string Contraseña { get; set; }

		//ID Empleado
		public int IdEmpleado { get; set; }

		//Numero de Empleado
		public string EmpNo { get; set; }

		public int IdArea { get; set; }

		public int IdPlant { get; set; }
		#endregion
	}
}