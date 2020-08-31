using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

namespace BOCAR.SACI.Data
{
	public class Employed : IEmployed
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		private DataTable dt = new DataTable();
		private List<employedCompositeType> ls = new List<employedCompositeType>();

		#region Employed Methods

		#region Insert

		public errorCompositeType InsertEmployed(int iNumber, String sName, String sMotherLastName, String sFatherLasteName, String sEMail, int iIdArea, int iIdPlant, int iBoss, int iSubstitute)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[11];

				param[0] = new SqlParameter("@finumber_employed", SqlDbType.Int);
				param[0].Value = iNumber;
				param[1] = new SqlParameter("@fvname_employed", SqlDbType.VarChar);
				param[1].Value = sName;
				param[2] = new SqlParameter("@fvmother_last_name", SqlDbType.VarChar);
				param[2].Value = sMotherLastName;
				param[3] = new SqlParameter("@fvfather_last_name", SqlDbType.VarChar);
				param[3].Value = sFatherLasteName;
				param[4] = new SqlParameter("@fvemail_employed", SqlDbType.VarChar);
				param[4].Value = sEMail;
				param[5] = new SqlParameter("@fistatus_employed", SqlDbType.Int);
				param[5].Value = 1;
				param[6] = new SqlParameter("@fiid_area", SqlDbType.Int);
				param[6].Value = iIdArea;
				param[7] = new SqlParameter("@fiid_plant", SqlDbType.Int);
				param[7].Value = iIdPlant;
				param[8] = new SqlParameter("@fdregistry_date", SqlDbType.DateTime);
				param[8].Value = DateTime.Now;
				param[9] = new SqlParameter("@fiid_boss", SqlDbType.Int);
				param[9].Value = iBoss;
				param[10] = new SqlParameter("@fiid_substitute", SqlDbType.Int);
				param[10].Value = iSubstitute;

				
				objDB.ExecStoredIUD("sp_insertEmployed", param);
				
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}


		}

		#endregion

		#region Update

		public errorCompositeType DeleteEmployed(int iIdEmployed)
		{
			errorCompositeType lstError = new errorCompositeType();

			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_Employed", SqlDbType.Int);
				param[0].Value = iIdEmployed;

				
				objDB.ExecStoredIUD("sp_deleteEmployed", param);
				
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public errorCompositeType UpdateEmployed(int iIdEmployed, int iNumber, String sName, String sMotherLastName, String sFatherLasteName, String sEMail, int iIdARea, int iIdPlant, int iBoss, int iSubstitute)
		{
			errorCompositeType lstError = new errorCompositeType();
			int iEstatus = 1;
			try
			{
				param = new SqlParameter[11];
				param[0] = new SqlParameter("@fiid_employed", SqlDbType.Int);
				param[0].Value = iIdEmployed;
				param[1] = new SqlParameter("@finumber_employed", SqlDbType.Int);
				param[1].Value = iNumber;
				param[2] = new SqlParameter("@fvname_employed", SqlDbType.VarChar);
				param[2].Value = sName;
				param[3] = new SqlParameter("@fvmother_last_name", SqlDbType.VarChar);
				param[3].Value = sMotherLastName;
				param[4] = new SqlParameter("@fvfather_last_name", SqlDbType.VarChar);
				param[4].Value = sFatherLasteName;
				param[5] = new SqlParameter("@fvemail_employed", SqlDbType.VarChar);
				param[5].Value = sEMail;
				param[6] = new SqlParameter("@fiid_area", SqlDbType.Int);
				param[6].Value = iIdARea;
				param[7] = new SqlParameter("@fiid_plant", SqlDbType.Int);
				param[7].Value = iIdPlant;
				param[8] = new SqlParameter("@fistatus_employed", SqlDbType.Int);
				param[8].Value = iEstatus;
				param[9] = new SqlParameter("@fiid_boss", SqlDbType.Int);
				param[9].Value = iBoss;
				param[10] = new SqlParameter("@fiid_substitute", SqlDbType.Int);
				param[10].Value = iSubstitute;
				
				objDB.ExecStore("sp_updateEmployed", param);
				
				lstError.bError = true;
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		#endregion

		#region Select

		public List<employedCompositeType> getAll()
		{
			List<employedCompositeType> lst = new List<employedCompositeType>();

			
			DataTable dt = objDB.Consult("sp_selectEmployed");
			

			foreach (DataRow dr in dt.Rows)
			{
				employedCompositeType et = new employedCompositeType();
				et.iIdEmployed = int.Parse(dr.ItemArray[0].ToString());
				et.iNumber = int.Parse(dr.ItemArray[1].ToString());
				et.sName = dr.ItemArray[2].ToString();
				et.sMLastName = dr.ItemArray[3].ToString();
				et.sFLastName = dr.ItemArray[4].ToString();
				et.sEMail = dr.ItemArray[5].ToString();
				et.iStatus = int.Parse(dr.ItemArray[6].ToString());
				et.iIdArea = int.Parse(dr.ItemArray[7].ToString());
				et.iIdPlant = int.Parse(dr.ItemArray[9].ToString());
				et.dDate = DateTime.Parse(dr.ItemArray[11].ToString());
				et.iBoss = int.Parse(dr.ItemArray[12].ToString());
				et.iSubstitute = int.Parse(dr.ItemArray[13].ToString());
				et.sBoss = dr.ItemArray[14].ToString();
				et.sSubstitute = dr.ItemArray[15].ToString();
				et.sCompleteName = dr.ItemArray[16].ToString();
				et.sDescriptionArea = dr.ItemArray[8].ToString(); //Add
				lst.Add(et);
			}
			return lst;
		}

		//Add
		public List<employedCompositeType> getEmployedArea(String sArea)
		{
			List<employedCompositeType> lst = new List<employedCompositeType>();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@area", SqlDbType.VarChar);
			param[0].Value = sArea;


			
			DataTable dt = objDB.ExecStore("sp_selectEmployedByNameArea", param);
			

			foreach (DataRow dr in dt.Rows)
			{
				employedCompositeType et = new employedCompositeType();
				et.iIdEmployed = int.Parse(dr.ItemArray[0].ToString());
				et.iNumber = int.Parse(dr.ItemArray[1].ToString());
				et.sName = dr.ItemArray[2].ToString();
				et.sMLastName = dr.ItemArray[3].ToString();
				et.sFLastName = dr.ItemArray[4].ToString();
				et.sEMail = dr.ItemArray[5].ToString();
				et.iStatus = int.Parse(dr.ItemArray[6].ToString());
				et.iIdArea = int.Parse(dr.ItemArray[7].ToString());
				et.iIdPlant = int.Parse(dr.ItemArray[8].ToString());
				et.dDate = DateTime.Parse(dr.ItemArray[9].ToString());
				et.iBoss = int.Parse(dr.ItemArray[10].ToString());
				et.iSubstitute = int.Parse(dr.ItemArray[11].ToString());
				et.sCompleteName = dr.ItemArray[12].ToString();
				lst.Add(et);
			}
			return lst;
		}


		public employedCompositeType GetEmployedById(int iIdEmployed)
		{
			employedCompositeType et = new employedCompositeType();
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Employed", SqlDbType.Int);
			param[0].Value = iIdEmployed;

			
			DataTable dt = objDB.ExecStore("sp_getEmployedById", param);
			
			if (dt.Rows.Count > 0)
			{
				et.iIdEmployed = int.Parse(dt.Rows[0].ItemArray[0].ToString());
				et.iNumber = int.Parse(dt.Rows[0].ItemArray[1].ToString());
				et.sName = dt.Rows[0].ItemArray[2].ToString();
				et.sMLastName = dt.Rows[0].ItemArray[3].ToString();
				et.sFLastName = dt.Rows[0].ItemArray[4].ToString();
				et.sEMail = dt.Rows[0].ItemArray[5].ToString();
				et.iStatus = int.Parse(dt.Rows[0].ItemArray[6].ToString());
				et.iIdArea = int.Parse(dt.Rows[0].ItemArray[7].ToString());
				et.iIdPlant = int.Parse(dt.Rows[0].ItemArray[8].ToString());
				et.dDate = DateTime.Parse(dt.Rows[0].ItemArray[9].ToString());
				et.iBoss = int.Parse(dt.Rows[0].ItemArray[10].ToString());
				et.iSubstitute = int.Parse(dt.Rows[0].ItemArray[11].ToString());
				et.sBoss = dt.Rows[0].ItemArray[12].ToString();
				et.sSubstitute = dt.Rows[0].ItemArray[13].ToString();
				et.sCompleteName = dt.Rows[0].ItemArray[14].ToString();
			}
			else
				et = null;

			return et;
		}

		public int getCountEmployedDuplicate(int iIdEmployed, String sEmail, int iNumber)
		{
			param = new SqlParameter[3];
			param[0] = new SqlParameter("@fiid_employed", SqlDbType.Int);
			param[0].Value = iIdEmployed;
			param[1] = new SqlParameter("@finumber_employed", SqlDbType.Int);
			param[1].Value = iNumber;
			param[2] = new SqlParameter("@fvemail_employed", SqlDbType.VarChar);
			param[2].Value = sEmail;

			
			DataTable dt = objDB.ExecStore("sp_countEmployedDuplicate", param);
			
			return int.Parse(dt.Rows[0].ItemArray[0].ToString());
		}

		#endregion

		#endregion

	}
}