using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Ent_Json_Recall
    {
        public class RootObject
        {
            public DateTime? updateDate { get; set; }
            public string updatedBy { get; set; }
            public Header header { get; set; }
            public List<AccountRecallInfoList> accountRecallInfoList { get; set; }
        }
        public class Header
        {
            public DateTime? updateDate { get; set; }
            //public string updatedBy { get; set; }
            public string senderID { get; set; }
            public string targetID { get; set; }
            public int totalRecords { get; set; }
            public string balancingId { get; set; }
            public int balancingSeqNo { get; set; }
        }
        public class AccountRecallInfoList
        {
            public DateTime updateDate { get; set; }
            public string updatedBy { get; set; }
            public string agencyId { get; set; }
            public string accountNumber { get; set; }
            public string agencyAssignmentStatusCode { get; set; }
            public string agencyRecallDate { get; set; }
            public double balanceAmount { get; set; }
            public string caseId { get; set; }
          
        }
    }
}
