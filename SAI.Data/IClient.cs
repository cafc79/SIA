using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
    public interface IClient
    {
        List<clientCompositeType> getAll();
        clientCompositeType GetClientById(int iIdClient);
        errorCompositeType InsertClient(String sDescription);
        errorCompositeType DeleteClient(int iIdClient);
        errorCompositeType UpdateClient(int iIdClient, String sDescription);
        //int getCountClientByDescription(String sDescription);
        //int getCountClientByDescription(String sDescription, int iIdClient);
        int getCountClientDuplicate(int iIdClient, String sDescription);
    }

    public class clientCompositeType
    {
        public int iIdClient { get; set; }
        public String sDescription { get; set; }
        public bool bStatus { get; set; }
    }
}
