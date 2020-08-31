using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
    public interface IDataType
    {
        List<DataTypeCompositeType> getAll();
        DataTypeCompositeType GetDataTypeById(int iIdDataType);
        errorCompositeType InsertDataType(String sDescription);
        errorCompositeType DeleteDataType(int iIdDataType);
        errorCompositeType UpdateDataType(int iIdDataType, String sDescription);
        //int getCountDataTypeByDescription(String sDescription);
        //int getCountDataTypeByDescription(String sDescription, int idDataType);
        int getCountDataTypeDuplicate(int iIdDataType, String sDescription);
    }

    public class DataTypeCompositeType
    {
        public int iIdDataType { get; set; }
        public String sDescription { get; set; }
        public bool bStatus { get; set; }
    }
}
