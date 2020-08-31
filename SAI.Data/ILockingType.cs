using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
	public interface ILockingType
	{
		List<lockingTypeCompositeType> getAll();
		lockingTypeCompositeType GetLockingTypeById(int iIdLockingType);
		errorCompositeType InsertLockingType(String sDescription);
		errorCompositeType DeleteLockingType(int iIdLockingType);
		errorCompositeType UpdateLockingType(int iIdLockingType, String sDescription);
		int getCountLockingTypeByDescription(String sDescription);
		int getCountLockingTypeByDescription(String sDescription, int idLockingType);
		int getCountLockingTypeDuplicate(int iIdLockingType, String sDescription);
	}

	public class lockingTypeCompositeType
	{
		public int iIdLockingType { get; set; }
		public String sDescription { get; set; }
		public bool bStatus { get; set; }
	}
}