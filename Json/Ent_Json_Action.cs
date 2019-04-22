using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Ent_Json_Action
    {
        public class RootObject
        {
            public DateTime? updateDate { get; set; }
            public string updatedBy { get; set; }
            public Header header { get; set; }
            public List<ActionsHistoryList> actionsHistoryList { get; set; }
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
        public class ActionsHistoryList
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public string activityTypeCode { get; set; }
            public string type { get; set; }
            public string contactTypeCode { get; set; }
            public string partyContactCode { get; set; }
            public string placeContactCode { get; set; }
            public string promiseAmount { get; set; }
            public string promiseDueDate { get; set; }
            public string promiseFrequencyCode { get; set; }
            public string promisePaymentMethod { get; set; }
            public string timeOfActivity { get; set; }
            public string note { get; set; }

        }
    }
}
