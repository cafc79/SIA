using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DeltaCore.DBConnect;

namespace DS.SAI.Data
{
	public class PartListExchange : IPartListExchange
	{
		private SqlParameter[] param;

		private ClassDB objDB = new ClassDB();
		#region PartListExchange Methods

		#region Insert
		public errorCompositeType InsertPartListExchange(int iIdPartList, int iIdAffectation, int iIdExchange)
		{
			var lstError = new errorCompositeType();
			try
			{
				bool bStatus = true;
				param = new SqlParameter[3];
				param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = iIdPartList};
				param[1] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = iIdAffectation};
				param[2] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = iIdExchange};
				objDB.ExecStoredIUD("sp_insertPartListExchange", param);
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
		public errorCompositeType DeletePartListExchange(int iIdExchange, int iIdPartList)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[2];
				param[0] = new SqlParameter("@fiid_exchange", SqlDbType.Int) { Value = iIdExchange };
				param[1] = new SqlParameter("@fiid_part_list", SqlDbType.Int) { Value = iIdPartList };
				objDB.ExecStoredIUD("sp_deletePartListExchange", param);
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

		public errorCompositeType UpdatePartListExchange(int iIdListPartExchange, int iIdPartList, int iIdAffectation, int iIdExchange)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fiid_Exchange_part_list", SqlDbType.Int) { Value = iIdListPartExchange };
				param[1] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = iIdPartList};
				param[2] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = iIdExchange};
				param[3] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) { Value = iIdAffectation };
				objDB.ExecStore("sp_updatePartListExchange", param);
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

		//Ya no se utiliza este método
		public errorCompositeType UpdatePartListExchangeCost(PartListExchangeCompositeType plect)
		{
			var lstError = new errorCompositeType();
			try
			{
				param = new SqlParameter[4];
				param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = plect.iIdPartList};
				param[1] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = plect.iIdAffectation};
				param[2] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = plect.iIdExchange};
				objDB.ExecStore("sp_updatePartListExchangeCost", param);
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

		public List<PartListExchangeCompositeType> getAll(int iIdListPartExchange)
		{
			var lst = new List<PartListExchangeCompositeType>();
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) { Value = iIdListPartExchange };
				DataTable dt = objDB.ExecStore("sp_SelectPartListExchangeById", param);
				lst.AddRange(from DataRow dr in dt.Rows
				             select new PartListExchangeCompositeType
				                    	{
				                    		iIdPartListExchange = int.Parse(dr.ItemArray[0].ToString()), iIdPartList = int.Parse(dr.ItemArray[1].ToString()), iIdAffectation = int.Parse(dr.ItemArray[2].ToString()), iIdExchange = int.Parse(dr.ItemArray[3].ToString()), sPartListDS = dr.ItemArray[4].ToString(), sPartListDescription = dr.ItemArray[5].ToString(), sPartListClient = dr.ItemArray[6].ToString(), sAffectationDescription = dr.ItemArray[7].ToString(), sFolio = dr.ItemArray[8].ToString(), sPreFolio = dr.ItemArray[9].ToString()
				                    	});
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public DataTable GetPartListC(int iIdListPartExchange)
		{
			try
			{
				param = new SqlParameter[1];
				param[0] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) { Value = iIdListPartExchange };
				return objDB.ExecStore("sp_SelectDiscPartListExchangeById", param);
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

        public DataTable sqlDSPartListExchange(Dictionary<string, object> pDictionary)
        {
            var cnx = new SqlConexion(ConfigurationManager.ConnectionStrings["SAIConnectionString"].ConnectionString);

            try
            {
                return cnx.ExecStp("sp_SelectPartListExchangeById", pDictionary);
            }
            catch
            {
                throw new Exception();
            }
        }

		public PartListExchangeCompositeType getPartListExchange(int iIdListPartExchange)
		{
			param = new SqlParameter[1];
			param[0] = new SqlParameter("@fiid_Exchange_part_list", SqlDbType.Int) {Value = iIdListPartExchange};
			DataTable dt = objDB.ExecStore("sp_SelectPartListExchangeByIdExPl", param);
			var et = new PartListExchangeCompositeType
			                                   	{
			                                   		iIdPartListExchange = (int) dt.Rows[0].ItemArray[0],
			                                   		iIdPartList = (int) dt.Rows[0].ItemArray[1],
			                                   		iIdAffectation = (int) dt.Rows[0].ItemArray[2],
			                                   		iIdExchange = (int) dt.Rows[0].ItemArray[3],
			                                   		sPartListDS = dt.Rows[0].ItemArray[4].ToString(),
			                                   		sPartListDescription = dt.Rows[0].ItemArray[5].ToString(),
			                                   		sPartListClient = dt.Rows[0].ItemArray[6].ToString(),
			                                   		sAffectationDescription = dt.Rows[0].ItemArray[7].ToString(),
			                                   		sFolio = dt.Rows[0].ItemArray[8].ToString(),
			                                   		sPreFolio = dt.Rows[0].ItemArray[9].ToString()
			                                   	};
			return et;
		}

		//public PartListExchangeCompositeType GetPartListExchangeById(int iIdPartListExchange)
		//{
		//    PartListExchangeCompositeType et = new PartListExchangeCompositeType();

		//    //try
		//    //{
		//    param = new SqlParameter[1];
		//    param[0] = new SqlParameter("@fiid_Exchange_part_list", SqlDbType.Int);
		//    param[0].Value = iIdPartListExchange;

		//    
		//    DataTable dt = objDB.ExecStore("sp_SelectPartListExchangeById", param);
		//    


		//    et.iIdPartListExchange = int.Parse(dt.Rows[0].ItemArray[0].ToString());
		//    et.iIdPartList = int.Parse(dt.Rows[0].ItemArray[1].ToString());
		//    et.iIdAffectation = int.Parse(dt.Rows[0].ItemArray[2].ToString());
		//    et.iIdExchange = int.Parse(dt.Rows[0].ItemArray[3].ToString());
		//    et.sPartListDS = dt.Rows[0].ItemArray[4].ToString();
		//    et.sPartListDescription = dt.Rows[0].ItemArray[5].ToString();
		//    et.sPartListClient = dt.Rows[0].ItemArray[6].ToString();
		//    et.sAffectationDescription = dt.Rows[0].ItemArray[7].ToString();
		//    et.sFolio = dt.Rows[0].ItemArray[8].ToString();
		//    et.sPreFolio = dt.Rows[0].ItemArray[9].ToString();

		//    return et;
		//    //}
		//    //catch (Exception ex)
		//    //{
		//    //    throw ex.Message();
		//    //}
		//}

		public int getSUMPartListExchange(PartListExchangeCompositeType plect)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = plect.iIdPartList};
			param[1] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = plect.iIdExchange};
			return (int)objDB.ExecStore("sp_SelectSumPartListExchangeCost", param).Rows[0].ItemArray[0];
		}

		public int getIdExchangePartListByAll(PartListExchangeCompositeType plect)
		{
			param = new SqlParameter[4];
			param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = plect.iIdPartList};
			param[1] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = plect.iIdAffectation};
			param[2] = new SqlParameter("@fiid_exchange", SqlDbType.Int) {Value = plect.iIdExchange};
			return (int)objDB.ExecStore("sp_getIdExchangePartListByAll", param).Rows[0].ItemArray[0];
		}

		public int getSUMPartListExchangeComponents(PartListExchangeCompositeType plect)
		{
			param = new SqlParameter[2];
			param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = plect.iIdPartList};
			param[1] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = plect.iIdExchange};
			return (int)objDB.ExecStore("sp_SelectSumPartListExchangeCost", param).Rows[0].ItemArray[0];
		}

		public int getCountPartListExchangeDuplicate(int iIdPartList, int iIdAffectation, int iIdExchange)
		{
			param = new SqlParameter[3];
			param[0] = new SqlParameter("@fiid_part_list", SqlDbType.Int) {Value = iIdPartList};
			param[1] = new SqlParameter("@fiid_Exchange", SqlDbType.Int) {Value = iIdExchange};
			param[2] = new SqlParameter("@fiid_affectation_type", SqlDbType.Int) {Value = iIdAffectation};
			return (int) objDB.ExecStore("sp_countPartListExchangeDuplicate", param).Rows[0].ItemArray[0];
		}
		#endregion

		#endregion
	}
}