using System;
using System.Collections.Generic;
using System.Linq;
using BOCAR.SACI.Data;

namespace BOCAR.SACI.Business
{
	public class AreaManager
	{
		public AreaManager()
		{

		}

		public errorCompositeType AddArea(String description, int iNumber, int iResponsable)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new Area();
				et.InsertArea(description, iNumber, iResponsable);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public errorCompositeType DeleteArea(int iIdArea)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new Area();
				et.DeleteArea(iIdArea);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public List<areaCompositeType> getAllArea()
		{
			var lst = new List<areaCompositeType>();
			var et = new Area();
			return et.getAll();
		}

		public areaCompositeType getAreaById(int iIdArea)
		{
			var act = new areaCompositeType();
			var et = new Area();
			return et.GetAreaById(iIdArea);
		}

		public errorCompositeType UpdateArea(int iIdArea, String sDescription, int iNumber, int iResponsable)
		{
			var lstError = new errorCompositeType();
			try
			{
				var et = new Area();
				et.UpdateArea(iIdArea, sDescription, iNumber, iResponsable);
				lstError.bError = true;
				lstError.sError = "";
				return lstError;
			}
			catch (Exception ex)
			{
				lstError.bError = false;
				lstError.sError = ex.Message;
				return lstError;
			}
		}

		public bool ExisteArea(int iId, string sDescripcion)
		{
			var chocorroles = new Area();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.sDescription.Equals(sDescripcion) && !s.iIdArea.Equals(iId) select s).Count();
			return qbo >= 1;
		}

		public bool ExisteArea(int iId, int iArea)
		{
			var chocorroles = new Area();
			var swap = chocorroles.getAll();
			var qbo = (from s in swap where s.iNumber.Equals(iArea) && !s.iIdArea.Equals(iId) select s).Count();
			return qbo >= 1;
		}

		public bool ExistArea(String sDescription)
		{
			var a = new Area();
			return a.getCountArea(sDescription) > 0;
		}

		public bool ExistArea(int iNumber)
		{
			var a = new Area();
			return a.getCountArea(iNumber) > 0;
		}

		public bool ExistArea(String sDescription, int iNumber, int iIdArea)
		{
			var a = new Area();
			return a.getCountArea(iNumber, sDescription, iIdArea) > 0;
		}

		public bool ExistAreaDuplicate(String sDescription, int iNumber, int iIdArea)
		{
			var a = new Area();
			return a.getCountAreaDuplicate(iIdArea, sDescription, iNumber) > 0;
		}
	}
}