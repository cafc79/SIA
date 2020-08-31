using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DS.SAI.Data
{
	/// <summary>
	/// Clase definida para los accesos a la base de datos y consultas de informacion. 
	/// </summary>
	public class ClassDB : IDisposable
	{
		#region Private Properties
		private SqlConnection objCon;
		#endregion

		#region Constructors
		public ClassDB()
		{
			objCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["SAIConnectionString"].ToString() };
		}
		#endregion

		#region Public Functions
		//Funcion General : Inserta , Actualiza o Borra Registros indicando la Consulta

		/// <summary>
		/// Ejecuta un string que no devuelve datos
		/// </summary>
		/// <param name="strQuery">La cadena que se quiere ejecutar</param>
		public void InsertUpdateDelete(string strQuery)
		{
			var QueryCmd = new SqlCommand(strQuery, objCon);
			if (strQuery == "")
				throw new Exception("Debes indicar la consulta a ejecutar");
			try
			{
				if ((objCon != null) && objCon.State != ConnectionState.Open)
					objCon.Open();
				QueryCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				// Cerrar Conexion y Liberar Objetos
				if (objCon != null && objCon.State == ConnectionState.Open)
					objCon.Close();
				QueryCmd.Dispose();
			}
		}

		/// <summary>
		/// Ejecuta una consulta y devuelve un DataTable
		/// </summary>
		/// <param name="strQuery">La cadena a ejecutar</param>
		/// <returns>Un DataTable</returns>
		public DataTable Consult(string strQuery)
		{
			try
			{
				if ((objCon != null) && objCon.State != ConnectionState.Open)
					objCon.Open();
				var ad = new SqlDataAdapter(strQuery, objCon);
				var ds = new DataTable();
				ad.Fill(ds);
				return ds;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				// Cerrar Conexion y Liberar Objetos
				if (objCon != null && objCon.State == ConnectionState.Open)
					objCon.Close();
			}
		}

		/// <summary>
		/// Ejecuta un store procedure, no regresa datos
		/// </summary>
		/// <param name="sNameStore">el nombre del store a ejecutar</param>
		/// <param name="Param">los parametros del store</param>
		public void ExecStoredIUD(string sNameStore, SqlParameter[] Param)
		{
			var sqlCmd = new SqlCommand();
			try
			{
				if ((objCon != null) && objCon.State != ConnectionState.Open)
					objCon.Open();
				sqlCmd.CommandText = sNameStore;
				sqlCmd.Connection = objCon;
				sqlCmd.CommandType = CommandType.StoredProcedure;
				if (Param != null)
					sqlCmd.Parameters.AddRange(Param);
				sqlCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				// Cerrar Conexion y Liberar Objetos
				if (objCon != null && objCon.State == ConnectionState.Open)
					objCon.Close();
				sqlCmd.Dispose();
			}
		}

		/// <summary>
		/// Ejecuta un Stored indicado junto con sus parametros. Regresa Datos
		/// </summary>
		/// <param name="sNameStore">el nombre del store a ejecutar</param>
		/// <param name="Param">los parametros del store</param>
		/// <returns></returns>
		public DataTable ExecStore(string sNameStore, SqlParameter[] Param)
		{
			var sqlCmdS = new SqlCommand();
			var sqlAdpS = new SqlDataAdapter(sqlCmdS);
			try
			{
				if ((objCon != null) && objCon.State != ConnectionState.Open)
					objCon.Open();
				sqlCmdS.CommandText = sNameStore;
				sqlCmdS.Connection = objCon;
				sqlCmdS.CommandType = CommandType.StoredProcedure;
				if (Param != null)
					sqlCmdS.Parameters.AddRange(Param);
				var sqlTblS = new DataTable();
				sqlAdpS.Fill(sqlTblS);

				return sqlTblS;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				// Cerrar Conexion y Liberar Objetos
				if (objCon != null && objCon.State == ConnectionState.Open)
					objCon.Close();
				sqlCmdS.Dispose();
				sqlAdpS.Dispose();
			}
		}

		//Obtiene Numero de Registros De una consulta proporcionada

		/// <summary>
		/// Obtiene el numero de datos de una consulta proporcionada
		/// </summary>
		/// <param name="strQuery">El store a ejecuitar</param>
		/// <returns>la cantidad de datos contenidos</returns>
		public int getDataNumber(string strQuery)
		{
			try
			{
				if (objCon != null && objCon.State != ConnectionState.Open)
					objCon.Open();
				var cmdCuenta = new SqlCommand(strQuery, objCon);
				return (int)cmdCuenta.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				// Cerrar Conexion y Liberar Objetos
				if (objCon != null && objCon.State == ConnectionState.Open)
					objCon.Close();
			}
		}
		#endregion

		public void Dispose()
		{
			Dispose();
			GC.SuppressFinalize(this);
		}
	}
}