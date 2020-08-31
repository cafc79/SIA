using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.SAI.Data
{
    public interface IEmployed
    {
        errorCompositeType InsertEmployed(int iNumber, String sName, String sMotherLastName, String sFatherLasteName, String sEMail, int iIdArea, int iIdPlant, int iBoss, int iSubstitute);
        errorCompositeType DeleteEmployed(int iIdEmployed);
        errorCompositeType UpdateEmployed(int iIdEmployed, int iNumber, String sName, String sMotherLastName, String sFatherLasteName, String sEMail, int iIdARea, int iIPlant, int iBoss, int iSubstitute);
        List<employedCompositeType> getAll();
        employedCompositeType GetEmployedById(int iIdEmployed);
        int getCountEmployedDuplicate(int iIdEmployed, String sEmail, int iNumber);
    }

    public class employedCompositeType
    {
        public int iIdEmployed { get; set; }
        public int iNumber { get; set; }
        public String sName { get; set; }
        public String sFLastName { get; set; }
        public String sMLastName { get; set; }
        public String sEMail { get; set; }
        public int iIdArea { get; set; }
        public String sDescriptionArea { get; set; }
        public int iIdPlant { get; set; }
        public String sDescriptionPlant { get; set; }
        public DateTime dDate { get; set; }
        public int iStatus { get; set; }
        public int iBoss { get; set; }
        public int iSubstitute { get; set; }
        public String sBoss { get; set; }
        public String sSubstitute { get; set; }
        public String sCompleteName { get; set; }
    }
}
