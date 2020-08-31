using System;
using System.Collections.Generic;

namespace DS.SAI.Data
{
    public interface IGroup
    {
        List<GroupCompositeType> getAll();
        GroupCompositeType GetGroupById(int iIdGroup);
        errorCompositeType InsertGroup(String sDescription);
        errorCompositeType DeleteGroup(int iIdGroup);
        errorCompositeType UpdateGroup(int iIdGroup, String sDescription);
        //int getCountGroupByDescription(String sDescription);
        //int getCountGroupByDescription(String sDescription, int idGroup);
        int getCountGroupDuplicate(int iIdGroup, String sDescription);
    }

    public class GroupCompositeType
    {
        public int iIdGroup { get; set; }
        public String sDescription { get; set; }
        public bool bStatus { get; set; }
    }
}
