using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Ent_Guardar_Json
    {
        Json.CYBEREntities DB = new Json.CYBEREntities();
        public void Actions(Ent_Json_Action.RootObject Action)
        {
            Tab_Amex_Json Action_ = new Tab_Amex_Json();
            Action_.TBAXJNFECHA = new DateTime();
            Action_.TBAXJNUPDATEDATE = Action.updateDate;
            Action_.TBAXJNIDHEADER = HeaderAction(Action.header);
            Action_.TBAXJNTIPO = "ACTION";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Json.Add(Action_);
                DB.SaveChanges();
            }
            if (Action.actionsHistoryList != null)
            {
                for (int i = 0; i < Action.actionsHistoryList.Count; i++)
                {
                    ActionsHistory(Action.actionsHistoryList[i], Action_.TBAXJNID);
                }
            }
           
        }
        public void Recall(Ent_Json_Recall.RootObject Recall)
        {
            Tab_Amex_Json Recall_ = new Tab_Amex_Json();
            Recall_.TBAXJNFECHA = new DateTime();
            Recall_.TBAXJNUPDATEDATE = Recall.updateDate;
            Recall_.TBAXJNIDHEADER = HeaderRecall(Recall.header);
            Recall_.TBAXJNTIPO = "RECALL";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Json.Add(Recall_);
                DB.SaveChanges();
            }
            if (Recall.accountRecallInfoList != null)
            {
                for (int i = 0; i < Recall.accountRecallInfoList.Count; i++)
                {
                    AccountRecall(Recall.accountRecallInfoList[i], Recall_.TBAXJNID);
                }
            }
           

        }

        public void AccountRecall(Ent_Json_Recall.AccountRecallInfoList AccountRecallInfoList, int id)
        {
            Tab_Amex_AccountRecall Recall = new Tab_Amex_AccountRecall();
            Recall.TBAXATIDJSON = id;
            Recall.TBAXATUPDATEDATE = AccountRecallInfoList.updateDate;
            Recall.TBAXATUPDATEDBY = AccountRecallInfoList.updatedBy;
            Recall.TBAXATAGENCYID = AccountRecallInfoList.agencyId;
            Recall.TBAXATACCOUNTNUMBER = AccountRecallInfoList.accountNumber;
            Recall.TBAXATAGENCYASSIGNMENT = AccountRecallInfoList.agencyAssignmentStatusCode;
            Recall.TBAXATAGENCYRECALLDATE = AccountRecallInfoList.agencyRecallDate;
            Recall.TBAXATBALANCEAMOUNT = Convert.ToDecimal(AccountRecallInfoList.balanceAmount);
            Recall.TBAXATCASEID = AccountRecallInfoList.caseId;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_AccountRecall.Add(Recall);
                DB.SaveChanges();
            }

        }
        public int? HeaderAction(Ent_Json_Action.Header Header)
        {
            Tab_Amex_Header Header_ = new Tab_Amex_Header();
            Header_.TBAXHRUPDATEDATE = Header.updateDate;
            Header_.TBAXHRSENDERID = Header.senderID;
            Header_.TBAXHRTARGETID = Header.targetID;
            Header_.TBAXHRTOTALRECORDS = Header.totalRecords;
            Header_.TBAXHRBALANCINGID = Header.balancingId;
            Header_.TBAXHRBALANCINGSEQNO = Header.balancingSeqNo;
            Header_.TBAXHRTIPO = "ACTION";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Header.Add(Header_);
                DB.SaveChanges();
            }
            return Header_.TBAXHRID;
        }
        public int? HeaderRecall(Ent_Json_Recall.Header Header)
        {        
            Tab_Amex_Header Header_ = new Tab_Amex_Header();
            Header_.TBAXHRUPDATEDATE = Header.updateDate;
            Header_.TBAXHRSENDERID = Header.senderID;
            Header_.TBAXHRTARGETID = Header.targetID;
            Header_.TBAXHRTOTALRECORDS = Header.totalRecords;
            Header_.TBAXHRBALANCINGID = Header.balancingId;
            Header_.TBAXHRBALANCINGSEQNO = Header.balancingSeqNo;
            Header_.TBAXHRTIPO = "RECALL";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Header.Add(Header_);
                DB.SaveChanges();
            }
            return Header_.TBAXHRID;
    }

        public void Update(Ent_Json_Update.RootObject Update)
        {
            Tab_Amex_Json Update_ = new Tab_Amex_Json();
            Update_.TBAXJNFECHA = new DateTime();
            Update_.TBAXJNUPDATEDATE = Update.updateDate;
            Update_.TBAXJNIDHEADER = HeaderUpd(Update.header);
            Update_.TBAXJNTIPO = "UPDATEOB";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Json.Add(Update_);
                DB.SaveChanges();
            }
            
            if (Update.demographicsList != null)
            {
                for (int i = 0; i < Update.demographicsList.Count; i++)
                {
                    DemographicsUpd(Update.demographicsList[i], Update_.TBAXJNID);
                }
            }
            
            if (Update.riskScoreList != null)
            {
                for (int i = 0; i < Update.riskScoreList.Count; i++)
                {
                    RiskScoreUpd(Update.riskScoreList[i], Update_.TBAXJNID);
                }
            }
            if (Update.customerFinancialList != null)
            {
                for (int i = 0; i < Update.customerFinancialList.Count; i++)
                {
                    CustomerFinancialUpd(Update.customerFinancialList[i], Update_.TBAXJNID);
                }
            }
            if (Update.financialRiskList != null)
            {
                for (int i = 0; i < Update.financialRiskList.Count; i++)
                {
                    FinancialRiskUpd(Update.financialRiskList[i], Update_.TBAXJNID);
                }
            }
            if (Update.productDetailsList != null)
            {
                for (int i = 0; i < Update.productDetailsList.Count; i++)
                {
                    ProductDetailsUpd(Update.productDetailsList[i], Update_.TBAXJNID);
                }
            }
            if (Update.strategyInfoList != null)
            {
                for (int i = 0; i < Update.strategyInfoList.Count; i++)
                {
                    StrategyInfoUpd(Update.strategyInfoList[i], Update_.TBAXJNID);
                }
            }
            if (Update.accountList != null)
            {
                for (int i = 0; i < Update.accountList.Count; i++)
                {
                    AccountUpd(Update.accountList[i], Update_.TBAXJNID);
                }
            }
            if (Update.financialTransactionDetailsList != null)
            {
                for (int i = 0; i < Update.financialTransactionDetailsList.Count; i++)
                {
                    FinancialTransactionDetailsUpd(Update.financialTransactionDetailsList[i], Update_.TBAXJNID);
                }
            }
            if (Update.collectionScoreList != null)
            {
                for (int i = 0; i < Update.collectionScoreList.Count; i++)
                {
                    CollectionScoreUpd(Update.collectionScoreList[i], Update_.TBAXJNID);
                }
            }

        }

        private void ActionsHistory(Ent_Json_Action.ActionsHistoryList actionsHistoryList, int tBAXJNID)
        {
            Tab_Amex_ActionsHistory ActionsHistory_ = new Tab_Amex_ActionsHistory();
            ActionsHistory_.TBAXATUPDATEDATE = actionsHistoryList.updateDate;
            ActionsHistory_.TBAXATUPDATEDBY = actionsHistoryList.updatedBy;
            ActionsHistory_.TBAXATACCOUNTNUMBER = actionsHistoryList.accountNumber;
            ActionsHistory_.TBAXATACCOUNTCATEGORY = actionsHistoryList.accountCategoryTypeCode;
            ActionsHistory_.TBAXATACTIVITY = actionsHistoryList.timeOfActivity;
            ActionsHistory_.TBAXATTYPE = actionsHistoryList.type;
            ActionsHistory_.TBAXATCONTACT = actionsHistoryList.contactTypeCode;
            ActionsHistory_.TBAXATPARTY = actionsHistoryList.partyContactCode;
            ActionsHistory_.TBAXATPLACE = actionsHistoryList.placeContactCode;
            ActionsHistory_.TBAXATPROMISEAMOUNT = actionsHistoryList.promiseAmount;
            ActionsHistory_.TBAXATPROMISEDUEDATE = actionsHistoryList.promiseDueDate;
            ActionsHistory_.TBAXATPROMISEFREQUENCY = actionsHistoryList.promiseFrequencyCode;
            ActionsHistory_.TBAXATPROMISEPAYMENT = actionsHistoryList.promisePaymentMethod;
            ActionsHistory_.TBAXATTIMEOFACTIVITY = actionsHistoryList.timeOfActivity;
            ActionsHistory_.TBAXATNOTE = actionsHistoryList.note;
            ActionsHistory_.TBAXATHEADER = tBAXJNID;
            ActionsHistory_.TBAXATTIPO = "UPDATEOB";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_ActionsHistory.Add(ActionsHistory_);
                DB.SaveChanges();
            }
        }

        private void FinancialSummaryUpd(FinancialSummaryList FinancialSummary, int id)
        {
            Tab_Amex_FinancialSummary FinancialSummary_ = new Tab_Amex_FinancialSummary();
            FinancialSummary_.TBAXFYUPDATEDATE = FinancialSummary.updateDate;
            FinancialSummary_.TBAXFYUPDATEDBY = FinancialSummary.updatedBy;
            FinancialSummary_.TBAXFYACCOUNTNUMBER = FinancialSummary.accountNumber;
            FinancialSummary_.TBAXFYACCOUNTCATEGORYTYPECODE = FinancialSummary.accountCategoryTypeCode;
            FinancialSummary_.TBAXFYTIPO = "UPDATEOB";
            FinancialSummary_.TBAXFYIDHEADER = id;
            if (FinancialSummary.debitSummaryInMonths != null)
            {
                FinancialSummary_.TBAXFYIDDEBITSUMMARYINMONTHS = DebitSummaryInMonthsUpd(FinancialSummary.debitSummaryInMonths);
            }
            if (FinancialSummary.accountBalanceInMonths != null)
            {
                FinancialSummary_.TBAXFYIDACCOUNTBALANCEINMONTHS = AccountBalanceInMonthsUpd(FinancialSummary.accountBalanceInMonths);
            }
            if (FinancialSummary.interestAccessedByMonth != null)
            {
                FinancialSummary_.TBAXFYIDINTERESTACCESSEDBYMONTH = InterestAccessedByMonthUpd(FinancialSummary.interestAccessedByMonth);
            }
            if (FinancialSummary.summaryCreditInMonths != null)
            {
                FinancialSummary_.TBAXFYIDSUMMARYCREDITINMONTHS = SummaryCreditInMonthsUpd(FinancialSummary.summaryCreditInMonths);
            }
            FinancialSummary_.TBAXFYPREVIOUSBALANCE = Convert.ToDecimal(FinancialSummary.previousBalance);
            if (FinancialSummary.accountAgingInMonths != null)
            {
                FinancialSummary_.TBAXFYIDACCOUNTAGINGINMONTHS = AccountAgingInMonthsUpd(FinancialSummary.accountAgingInMonths);
            }

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_FinancialSummary.Add(FinancialSummary_);
                DB.SaveChanges();
            }
        }

        private int AccountAgingInMonthsUpd(AccountAgingInMonths AccountAgingInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "UPDATEOB";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(AccountAgingInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(AccountAgingInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(AccountAgingInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(AccountAgingInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(AccountAgingInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(AccountAgingInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(AccountAgingInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(AccountAgingInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(AccountAgingInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(AccountAgingInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(AccountAgingInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(AccountAgingInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }

        private int SummaryCreditInMonthsUpd(SummaryCreditInMonths SummaryCreditInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "UPDATEOB";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(SummaryCreditInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(SummaryCreditInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(SummaryCreditInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(SummaryCreditInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(SummaryCreditInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(SummaryCreditInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(SummaryCreditInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(SummaryCreditInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(SummaryCreditInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(SummaryCreditInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(SummaryCreditInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(SummaryCreditInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }

        private int InterestAccessedByMonthUpd(InterestAccessedByMonth InterestAccessedByMonth)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "UPDATEOB";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(InterestAccessedByMonth.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(InterestAccessedByMonth.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(InterestAccessedByMonth.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(InterestAccessedByMonth.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(InterestAccessedByMonth.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(InterestAccessedByMonth.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(InterestAccessedByMonth.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(InterestAccessedByMonth.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(InterestAccessedByMonth.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(InterestAccessedByMonth.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(InterestAccessedByMonth.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(InterestAccessedByMonth.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }

        private int AccountBalanceInMonthsUpd(AccountBalanceInMonths AccountBalanceInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "UPDATEOB";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(AccountBalanceInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(AccountBalanceInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(AccountBalanceInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(AccountBalanceInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(AccountBalanceInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(AccountBalanceInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(AccountBalanceInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(AccountBalanceInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(AccountBalanceInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(AccountBalanceInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(AccountBalanceInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(AccountBalanceInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }

        private int DebitSummaryInMonthsUpd(DebitSummaryInMonths DebitSummaryInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "UPDATEOB";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(DebitSummaryInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(DebitSummaryInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(DebitSummaryInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(DebitSummaryInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(DebitSummaryInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(DebitSummaryInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(DebitSummaryInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(DebitSummaryInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(DebitSummaryInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(DebitSummaryInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(DebitSummaryInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(DebitSummaryInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }

        public void DemographicsUpd(DemographicsList Demographics, int id)
        {
            Tab_Amex_Demographics Demographics_ = new Tab_Amex_Demographics();
            Demographics_.TBAXDSUPDATEDATE = Demographics.updateDate;
            Demographics_.TBAXDSUPDATEDBY = Demographics.updatedBy;
            Demographics_.TBAXDSTITLE = Demographics.title;
            Demographics_.TBAXDSFIRSTNAME = Demographics.firstName;
            Demographics_.TBAXDSMIDDLENAME = Demographics.middleName;
            Demographics_.TBAXDSLASTNAME = Demographics.lastName;
            Demographics_.TBAXDSBIRTHDATE = Demographics.birthDate;
            Demographics_.TBAXDSACCOUNTNUMBER = Demographics.accountNumber;
            Demographics_.TBAXDSACCOUNTCATEGORYTYPECODE = Demographics.accountCategoryTypeCode;
            Demographics_.TBAXDSRETURNMAILINDICATOR = Demographics.returnMailIndicator;
            Demographics_.TBAXDSTIPO = "UPDATEOB";
            Demographics_.TBAXDSIDHEADER = id;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Demographics.Add(Demographics_);
                DB.SaveChanges();
            }
            if (Demographics.addresses != null)
            {
                for (int i = 0; i < Demographics.addresses.Count; i++)
                {
                    if (Demographics.addresses[i] != null)
                    {
                        AddressUpd(Demographics.addresses[i], Demographics_.TBAXDSID);
                    }

                }
            }

            if (Demographics.emails != null)
            {
                for (int i = 0; i < Demographics.emails.Count; i++)
                {
                    if (Demographics.emails[i] != null)
                    {
                        EmailsUpd(Demographics.emails[i], Demographics_.TBAXDSID);
                    }
                }
            }
            if (Demographics.phones != null)
            {
                for (int i = 0; i < Demographics.phones.Count; i++)
                {
                    if (Demographics.phones[i] != null)
                    {
                        PhonesUpd(Demographics.phones[i], Demographics_.TBAXDSID);
                    }

                }
            }
            if (Demographics.nationalIds != null)
            {
                for (int i = 0; i < Demographics.nationalIds.Count; i++)
                {
                    if (Demographics.nationalIds[i] != null)
                    {
                        NationalIdsUpd(Demographics.nationalIds[i], Demographics_.TBAXDSID);
                    }

                }
            }
        }

        private void NationalIdsUpd(NationalId NationalIds, int Id)
        {
            Tab_Amex_NationalIds NationalIds_ = new Tab_Amex_NationalIds();
            NationalIds_.TBAXNSIDENT = Id;
            NationalIds_.TBAXNSUPDATEDATE = NationalIds.updateDate;
            NationalIds_.TBAXNSUPDATEDBY = NationalIds.updatedBy;
            NationalIds_.TBAXNSNATIONALIDNUMBER = NationalIds.nationalIdNumber;
            NationalIds_.TBAXNSNATIONALIDTYPE = NationalIds.nationalIDtype;
            NationalIds_.TBAXNSTIPO = "UPDATEOB";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_NationalIds.Add(NationalIds_);
                DB.SaveChanges();
            }
        }

        private void PhonesUpd(Phone Phones, int id)
        {
            Tab_Amex_Phones Phones_ = new Tab_Amex_Phones();
            Phones_.TBAXPSUPDATEDATE = Phones.updateDate;
            Phones_.TBAXPSUPDATEDBY = Phones.updatedBy;
            Phones_.TBAXPS_ID = Phones.id;
            Phones_.TBAXPSTYPECODE = Phones.typeCode;
            Phones_.TBAXPSCATEGORYCODE = Phones.categoryCode;
            Phones_.TBAXPSSTATUSCODE = Phones.statusCode;
            Phones_.TBAXPSNUMBER = Phones.number;
            Phones_.TBAXPSISDCODE = Phones.isdCode;
            Phones_.TBAXPSEXTENSION = Phones.extension;
            Phones_.TBAXPSLASTUPDATEDATE = Phones.lastUpdateDate;
            Phones_.TBAXPSLASTCONTACTDATE = Phones.lastContactDate;
            Phones_.TBAXPSTIPO = "UPDATEOB";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Phones.Add(Phones_);
                DB.SaveChanges();
            }           
        }

        private void EmailsUpd(Emails Emails, int Id)
        {
            Tab_Amex_Emails Emails_ = new Tab_Amex_Emails();
            Emails_.TBAXESUPDATEDATE = Emails.updateDate;
            Emails_.TBAXESIDENT = Id;
            Emails_.TBAXESUPDATEDBY = Emails.updatedBy;
            Emails_.TBAXES_ID = Emails.id;
            Emails_.TBAXESTYPECODE = Emails.typeCode;
            Emails_.TBAXESCATEGORYCODE = Emails.categoryCode;
            Emails_.TBAXESSTATUSCODE = Emails.statusCode;
            Emails_.TBAXESCONSENT = Emails.consent;
            Emails_.TBAXESEMAILADDRESS = Emails.emailAddress;
            Emails_.TBAXESETIPO = "UPDATEOB";

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Emails.Add(Emails_);
                DB.SaveChanges();
            }
        }

        private void AddressUpd(Address Address, int Id)
        {
            Tab_Amex_Address Address_ = new Tab_Amex_Address();
            Address_.TBAXASIDENT = Id;
            Address_.TBAXASUPDATEDATE = Address.updateDate;
            Address_.TBAXASUPDATEDBY = Address.updatedBy;
            Address_.TBAXASTYPECODE = Address.typeCode;
            Address_.TBAXASCATEGORYCODE = Address.categoryCode;
            Address_.TBAXASSTATUSCODE = Address.statusCode;
            Address_.TBAXASADDRESSLINE1 = Address.addressLine1;
            Address_.TBAXASADDRESSLINE2 = Address.addressLine2;
            Address_.TBAXASADDRESSLINE3 = Address.addressLine3;
            Address_.TBAXASCITY = Address.city;
            Address_.TBAXASSTATE = Address.state;
            Address_.TBAXASCOUNTRY = Address.country;
            Address_.TBAXASZIPCODE = Address.zipCode;
            Address_.TBAXASADDRESSCONFIRMATIONDATE = Address.addressConfirmationDate;
            Address_.TBAXASLASTUPDATEDATE = Address.lastUpdateDate;
            Address_.TBAXASTIPO = "UPDATEOB";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Address.Add(Address_);
                DB.SaveChanges();
            }
        }

        public void CollectionScoreUpd(CollectionScoreList CollectionScore, int id)
        {
            Tab_Amex_CollectionScore CollectionScore_ = new Tab_Amex_CollectionScore();
            CollectionScore_.TBAXCEUPDATEDATE = CollectionScore.updateDate;
            CollectionScore_.TBAXCEUPDATEDBY = CollectionScore.updatedBy;
            CollectionScore_.TBAXCE_ID = CollectionScore.id;
            CollectionScore_.TBAXCEACCOUNTNUMBER = CollectionScore.accountNumber;
            CollectionScore_.TBAXCEACCOUNTCATEGORYTYPECODE = CollectionScore.accountCategoryTypeCode;
            CollectionScore_.TBAXCECOLLECTIBILITYSCORE = CollectionScore.collectibilityScore;
            CollectionScore_.TBAXCERECOVERYSCORE = CollectionScore.recoveryScore;
            CollectionScore_.TBAXCEBANKRUPTCYSCORE = CollectionScore.bankruptcyScore;
            CollectionScore_.TBAXCEMARKETRECOVERYSCORE = CollectionScore.marketRecoveryScore;
            CollectionScore_.TBAXCERETURNMETRICSCORE = CollectionScore.returnMetricScore;
            CollectionScore_.TBAXCEFICOSCORE = Convert.ToInt32(CollectionScore.ficoScore);
            CollectionScore_.TBAXCETIPO = "UPDATEOB";
            CollectionScore_.TBAXCEIDHEADER = id;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CollectionScore.Add(CollectionScore_);
                DB.SaveChanges();
            }
            
        }
        private void FinancialTransactionDetailsUpd(FinancialTransactionDetailsList FinancialTransactionDetails,int id)
        {
            Tab_Amex_FinancialTransactionDetails FinancialTransactionDetails_ = new Tab_Amex_FinancialTransactionDetails();
            FinancialTransactionDetails_.TBAXFSUPDATEDATE = FinancialTransactionDetails.updateDate;
            FinancialTransactionDetails_.TBAXFSUPDATEDBY = FinancialTransactionDetails.updatedBy;
            FinancialTransactionDetails_.TBAXFSACCOUNTNUMBER = FinancialTransactionDetails.accountNumber;
            FinancialTransactionDetails_.TBAXFSACCOUNTCATEGORYTYPECODE = FinancialTransactionDetails.accountCategoryTypeCode;
            FinancialTransactionDetails_.TBAXFSTIPO = "UPDATEOB";
            FinancialTransactionDetails_.TBAXFSIDHEADER = id;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_FinancialTransactionDetails.Add(FinancialTransactionDetails_);
                DB.SaveChanges();
            }
            if (FinancialTransactionDetails.transactions != null)
            {
                for (int i = 0; i < FinancialTransactionDetails.transactions.Count; i++)
                {
                    Transactions(FinancialTransactionDetails.transactions[i], FinancialTransactionDetails_.TBAXFSID);
                }
            }

          
        }

        private void Transactions(Transactions Transactions, int id)
        {
            {
                Tab_Amex_Transactions Transactions_ = new Tab_Amex_Transactions();
                Transactions_.TBAXTSIDFINANCIAL = id;
                Transactions_.TBAXTSUPDATEDATE = Transactions.updateDate;
                Transactions_.TBAXTSUPDATEDBY = Transactions.updatedBy;
                Transactions_.TBAXTSACCOUNTNUMBER = Transactions.accountNumber;
                Transactions_.TBAXTSACCOUNTCATEGORYTYPECODE = Transactions.accountCategoryTypeCode;
                Transactions_.TBAXTSLAST5DIGITSOFTRANSACTION = Transactions.last5DigitsOfTransaction;
                Transactions_.TBAXTSTRANSACTIONAMOUNT = Convert.ToDecimal(Transactions.transactionAmount);
                Transactions_.TBAXTSTRANSACTIONTYPECODE = Transactions.transactionTypeCode;
                Transactions_.TBAXTSTRANSACTIONDATE = Transactions.transactionDate;
                Transactions_.TBAXTSLEGACYFIELDCODE = Transactions.legacyFieldCode;
                Transactions_.TBAXTSTRANSACTIONCODE = Transactions.transactionCode;
                Transactions_.TBAXTSTRANSACTIONID = Transactions.transactionId;
                Transactions_.TBAXTSCURRENCY = Transactions.currency;
                Transactions_.TBAXTSTRANSACTIONREFERID = Transactions.transactionReferId;
                Transactions_.TBAXTSFOREIGNTRANSACTIONAMOUNT = Convert.ToDecimal(Transactions.foreignTransactionAmount);
                Transactions_.TBAXTSFOREIGNCURRENCYCODE = Transactions.foreignCurrencyCode;
                Transactions_.TBAXTSSTAMPEDFXRATE = Convert.ToDecimal(Transactions.stampedFxRate);
                Transactions_.TBAXTSSORTRANSACTIONCODE = Transactions.sorTransactionCode;
                Transactions_.TBAXTSCURRENTFOREIGNBALANCE = Convert.ToDecimal(Transactions.currentForeignBalance);
                Transactions_.TBAXTSCURRENTLOCALCURRENCYBALANCE = Convert.ToDecimal(Transactions.currentLocalCurrencyBalance);
                Transactions_.TBAXTSACORNPOSTDATE = Transactions.acornPostDate;
                Transactions_.TBAXTSPROCESSINGSTATUS = Transactions.processingStatus;
                Transactions_.TBAXTSTIPO = "UPDATEOB";
                using (CYBEREntities DB = new CYBEREntities())
                {
                    DB.Tab_Amex_Transactions.Add(Transactions_);
                    DB.SaveChanges();
                }
            }
        }

        public void AccountUpd(AccountList Account, int id)
        {
            Tab_Amex_Account Account_ = new Tab_Amex_Account();
            Account_.TBAXATUPDATEDATE = Account.updateDate;
            Account_.TBAXATUPDATEDBY = Account.updatedBy;
            Account_.TBAXATACCOUNTNUMBER = Account.accountNumber;
            Account_.TBAXATACCOUNTCATEGORYTYPECODE = Account.accountCategoryTypeCode;
            Account_.TBAXATCOUNTRYISOALPHA2CODE = Account.countryIsoAlpha2Code;
            Account_.TBAXATPRODUCTCODE = Account.productCode;
            Account_.TBAXATCHARGEOFFREASONCODE = Account.chargeOffReasonCode;
            Account_.TBAXATPLACEMENTBALANCE = Convert.ToDecimal(Account.placementBalance);
            Account_.TBAXATCURRENTBALANCE = Convert.ToDecimal(Account.currentBalance);
            Account_.TBAXATWRITEOFFAMOUNT = Convert.ToDecimal(Account.writeOffAmount);
            Account_.TBAXATACCOUNTSTATUS = Account.accountStatus;
            Account_.TBAXATWRITEOFFDATE = Account.writeOffDate;
            Account_.TBAXATORIGINALPLACEMENTDATE = Account.originalPlacementDate;
            Account_.TBAXATACCOUNTRECEIVEDATE = Account.accountReceiveDate;
            Account_.TBAXATINTERNALRECOVERERCODE = Account.internalRecovererCode;
            Account_.TBAXATPLACEMENTLEVELCODE = Account.placementLevelCode;
            Account_.TBAXATSTAMPEDRATE1 = Convert.ToDecimal(Account.stampedRate1);
            Account_.TBAXATSTAMPEDRATE2 = Convert.ToDecimal(Account.stampedRate2);
            Account_.TBAXATSTAMPEDRATE3 = Convert.ToDecimal(Account.stampedRate3);
            Account_.TBAXATSTAMPEDFXRATE = Convert.ToDecimal(Account.stampedFxRate);
            Account_.TBAXATCOMMISSIONRATE = Convert.ToDecimal(Account.commissionRate);
            Account_.TBAXATAGENCYASSIGNMENTDATE = Account.agencyAssignmentDate;
            Account_.TBAXATLASTSTATUSCHANGEDATE = Account.lastStatusChangeDate;
            Account_.TBAXATAGENCYRECALLDATE = Account.agencyRecallDate;
            Account_.TBAXATCURRENTAGENCYID = Account.currentAgencyId;
            Account_.TBAXATTIPO = "UPDATEOB";
            Account_.TBAXATIDHEADER = id;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Account.Add(Account_);
                DB.SaveChanges();
            }
        }
        public void StrategyInfoUpd(StrategyInfoList StrategyInfo, int id)
        {
            Tab_Amex_StrategyInfo StrategyInfo_ = new Tab_Amex_StrategyInfo();
            StrategyInfo_.TBAXSOUPDATEDATE = StrategyInfo.updateDate;
            StrategyInfo_.TBAXSOUPDATEDBY = StrategyInfo.updatedBy;
            StrategyInfo_.TBAXSOACCOUNTNUMBER = StrategyInfo.accountNumber;
            StrategyInfo_.TBAXSOACCOUNTCATEGORYTYPECODE = StrategyInfo.accountCategoryTypeCode;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR1 = StrategyInfo.strategyIndicator1;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR2 = StrategyInfo.strategyIndicator2;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR3 = StrategyInfo.strategyIndicator3;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR4 = StrategyInfo.strategyIndicator4;
            StrategyInfo_.TBAXSONOOFCCSGCHARGECARDSCUSTOMERHAS = StrategyInfo.noOfCcsgChargeCardsCustomerHas;
            StrategyInfo_.TBAXSONOOFCCSGLENDINGCARDSCUSTOMERHAS = StrategyInfo.noOfCcsgLendingCardsCustomerHas;
            StrategyInfo_.TBAXSOSEGMENTID1 = StrategyInfo.segmentId1;
            StrategyInfo_.TBAXSOSEGMENTID2 = StrategyInfo.segmentId2;
            StrategyInfo_.TBAXSOSEGMENTID3 = StrategyInfo.segmentId3;
            StrategyInfo_.TBAXSOSEGMENTID4 = StrategyInfo.segmentId4;
            StrategyInfo_.TBAXSONOOFOPENCARDSCUSTOMERHAS = StrategyInfo.noOfOpenCardsCustomerHas;
            StrategyInfo_.TBAXSOINDICATORFORLOCBALANCE = StrategyInfo.indicatorForLocBalance;
            StrategyInfo_.TBAXSOREAGEINDICATOR = StrategyInfo.reAgeIndicator;
            StrategyInfo_.TBAXSOCAREELIGIBILITY = StrategyInfo.careEligibility;
            StrategyInfo_.TBAXSOWRITTENOFFINDICATOR = StrategyInfo.writtenOffIndicator;
            StrategyInfo_.TBAXSOLENDINGINCHARGE = StrategyInfo.lendingInCharge;
            StrategyInfo_.TBAXSOSPEEDTOPAYMODEL = StrategyInfo.speedToPayModel;
            StrategyInfo_.TBAXSOTIPO = "UPDATEOB";
            StrategyInfo_.TBAXSOIDHEADER = id;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_StrategyInfo.Add(StrategyInfo_);
                DB.SaveChanges();
            }
        }
        public void ProductDetailsUpd(ProductDetailsList ProductDetails, int id)
        {
            Tab_Amex_ProductDetails ProductDetails_ = new Tab_Amex_ProductDetails();
            ProductDetails_.TBAXPSUPDATEDATE = ProductDetails.updateDate;
            ProductDetails_.TBAXPSUPDATEDBY = ProductDetails.updatedBy;
            ProductDetails_.TBAXPSACCOUNTNUMBER = ProductDetails.accountNumber;
            ProductDetails_.TBAXPSACCOUNTCATEGORYTYPECODE = ProductDetails.accountCategoryTypeCode;
            ProductDetails_.TBAXPSAMEXPRODUCTCODE = ProductDetails.amexProductCode;
            ProductDetails_.TBAXPSPRODUCTTYPE = ProductDetails.productType;
            ProductDetails_.TBAXPSFULLPRODUCTDESCRIPTION = ProductDetails.fullProductDescription;
            ProductDetails_.TBAXPSTIPO = "UPDATEOB";
            ProductDetails_.TBAXPSIDHEADER = id;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_ProductDetails.Add(ProductDetails_);
                DB.SaveChanges();
            }
        }

        public void FinancialRiskUpd(FinancialRiskList FinancialRisk, int id)
        {
            Tab_Amex_FinancialRisk FinancialRisk_ = new Tab_Amex_FinancialRisk();
            FinancialRisk_.TBAXFKUPDATEDATE = FinancialRisk.updateDate;
            FinancialRisk_.TBAXFKUPDATEDBY = FinancialRisk.updatedBy;
            FinancialRisk_.TBAXFKACCOUNTNUMBER = FinancialRisk.accountNumber;
            FinancialRisk_.TBAXFKACCOUNTCATEGORYTYPECODE = FinancialRisk.accountCategoryTypeCode;
            FinancialRisk_.TBAXFKLENDINGAGECODE = FinancialRisk.lendingAgeCode;
            FinancialRisk_.TBAXFKCHARGETOTALBALANCE = Convert.ToDecimal(FinancialRisk.chargeTotalBalance);
            FinancialRisk_.TBAXFKLENDINGTOTALBALANCE = Convert.ToDecimal(FinancialRisk.lendingTotalBalance);
            FinancialRisk_.TBAXFKCUSTOMEREXPOSURECCSG = Convert.ToDecimal(FinancialRisk.customerExposureCcsg);
            FinancialRisk_.TBAXFKCUSTOMEREXPOSUREOPEN = Convert.ToDecimal(FinancialRisk.customerExposureOpen);
            FinancialRisk_.TBAXFKTOTALEXPOSURE = Convert.ToDecimal(FinancialRisk.totalExposure);
            FinancialRisk_.TBAXFKLASTBALANCEDATE = FinancialRisk.lastBalanceDate;
            FinancialRisk_.TBAXFKCYCLECUTDATE = FinancialRisk.cycleCutDate;
            FinancialRisk_.TBAXFKCYCLECUTDATE2 = FinancialRisk.cycleCutDate2;
            FinancialRisk_.TBAXFKDUEDATE = FinancialRisk.dueDate;
            FinancialRisk_.TBAXFKDUEDATE2 = FinancialRisk.dueDate2;
            FinancialRisk_.TBAXFKBANKTYPE = FinancialRisk.bankType;
            FinancialRisk_.TBAXFKABILITY = FinancialRisk.ability;
            FinancialRisk_.TBAXFKMINDUEINDICATOR = Convert.ToDecimal(FinancialRisk.minDueIndicator);
            FinancialRisk_.TBAXFKCURRENTCOMBINEDFEEANDINTEREST = Convert.ToDecimal(FinancialRisk.currentCombinedFeeAndInterest);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST30DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest30Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST60DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest60Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST90DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest90Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST120DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest120Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST150DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest150Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST180DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest180Days);
            FinancialRisk_.TBAXFKOLDESTAGEMINDUEBUCKET = Convert.ToDecimal(FinancialRisk.oldestAgeMinDueBucket);
            FinancialRisk_.TBAXFKTOTALCUSTOMERLEVELMINDUECCSG = Convert.ToDecimal(FinancialRisk.totalCustomerLevelMinDueCcsg);
            FinancialRisk_.TBAXFKTOTALCUSTOMERLEVELMINDUEOPEN = Convert.ToDecimal(FinancialRisk.totalCustomerLevelMinDueOpen);
            FinancialRisk_.TBAXFKTOTALCUSTOMERLEVELMINDUE = Convert.ToDecimal(FinancialRisk.totalCustomerLevelMinDue);
            FinancialRisk_.TBAXFKTOTALCOURTCOSTSREIMBURSEDTOPREVIOUSAGENCY = Convert.ToDecimal(FinancialRisk.totalCourtCostsReimbursedToPreviousAgency);
            FinancialRisk_.TBAXFKTIPO = "UPDATEOB";
            FinancialRisk_.TBAXFKIDHEADER = id;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_FinancialRisk.Add(FinancialRisk_);
                DB.SaveChanges();
            }
            
        }
        public void CustomerFinancialUpd(CustomerFinancialList CustomerFinancial,int id)
        {
            Tab_Amex_CustomerFinancial CustomerFinancial_ = new Tab_Amex_CustomerFinancial();
            CustomerFinancial_.TBAXCLUPDATEDATE = CustomerFinancial.updateDate;
            CustomerFinancial_.TBAXCLUPDATEDBY = CustomerFinancial.updatedBy;
            CustomerFinancial_.TBAXCL_ID = CustomerFinancial.id;
            CustomerFinancial_.TBAXCLACCOUNTNUMBER = CustomerFinancial.accountNumber;
            CustomerFinancial_.TBAXCLACCOUNTCATEGORYTYPECODE = CustomerFinancial.accountCategoryTypeCode;
            CustomerFinancial_.TBAXCLLARGEORMIDDLEMARKET = CustomerFinancial.largeOrMiddleMarket;
            CustomerFinancial_.TBAXCLCYCLECUT = CustomerFinancial.cycleCut;
            CustomerFinancial_.TBAXCLWAIVERORGUARANTEED = CustomerFinancial.waiverOrGuaranteed;
            CustomerFinancial_.TBAXCLNUMBEROFTIMESPASTDUE60DAYS = CustomerFinancial.numberOfTimesPastDue60Days;
            CustomerFinancial_.TBAXCLLIABILITY = CustomerFinancial.liability;
            CustomerFinancial_.TBAXCLTOTALEXPOSURE = Convert.ToDecimal(CustomerFinancial.totalExposure);
            CustomerFinancial_.TBAXCLLASTPAYMENTDATE = CustomerFinancial.lastPaymentDate;
            CustomerFinancial_.TBAXCLCREDITBALANCE = Convert.ToDecimal(CustomerFinancial.creditBalance);
            CustomerFinancial_.TBAXCLMINIMUMAMOUNTDUE = Convert.ToDecimal(CustomerFinancial.minimumAmountDue);
            CustomerFinancial_.TBAXCLUNBILLEDAMOUNTDUE = Convert.ToDecimal(CustomerFinancial.unbilledAmountDue);
            CustomerFinancial_.TBAXCLCURRENTAMOUNTDUE = Convert.ToDecimal(CustomerFinancial.currentAmountDue);
            CustomerFinancial_.TBAXCLAMOUNTDUE30DAYS = Convert.ToDecimal(CustomerFinancial.amountDue30Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE60DAYS = Convert.ToDecimal(CustomerFinancial.amountDue60Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE90DAYS = Convert.ToDecimal(CustomerFinancial.amountDue90Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE120DAYS = Convert.ToDecimal(CustomerFinancial.amountDue120Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE150DAYS = Convert.ToDecimal(CustomerFinancial.amountDue150Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE180DAYS = Convert.ToDecimal(CustomerFinancial.amountDue180Days);
            CustomerFinancial_.TBAXCLTOTALAMOUNTDUEINUSD = Convert.ToDecimal(CustomerFinancial.totalAmountDueInUSD);
            CustomerFinancial_.TBAXCLUNBILLEDAMOUNTDUEINUSD = Convert.ToDecimal(CustomerFinancial.unbilledAmountDueInUSD);
            CustomerFinancial_.TBAXCLCURRENTAMOUNTDUEINUSD = Convert.ToDecimal(CustomerFinancial.currentAmountDueInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE30DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue30DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE60DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue60DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE90DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue90DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE120DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue120DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE150DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue150DaysInUSD);
            CustomerFinancial_.TBAXCLCREDITINUSD = CustomerFinancial.creditInUSD;
            CustomerFinancial_.TBAXCLLEGACYCODE = CustomerFinancial.legacyCode;
            CustomerFinancial_.TBAXCLTIPO = "UPDATEOB";
            CustomerFinancial_.TBAXCLIDHEADER = id;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CustomerFinancial.Add(CustomerFinancial_);
                DB.SaveChanges();
            }
        }

        private void RiskScoreUpd(RiskScoreList RiskScore, int id)
        {
            Tab_Amex_RiskScore RiskScore_ = new Tab_Amex_RiskScore();
            RiskScore_.TBAXREUPDATEDATE = RiskScore.updateDate;
            RiskScore_.TBAXREUPDATEDBY = RiskScore.updatedBy;
            RiskScore_.TBAXREACCOUNTNUMBER = RiskScore.accountNumber;
            RiskScore_.TBAXREACCOUNTCATEGORYTYPECODE = RiskScore.accountCategoryTypeCode;
            RiskScore_.TBAXREDEBTTOVALUERATIO = Convert.ToDecimal(RiskScore.debtToValueRatio);
            RiskScore_.TBAXRECUSTOMERLEVELSCOREFORCHARGEANDLENDING = Convert.ToDecimal(RiskScore.customerLevelScoreForChargeAndLending);
            RiskScore_.TBAXRELENDINGPAYTOCURRRENTSCORE = Convert.ToInt32(RiskScore.lendingPayToCurrrentScore);
            RiskScore_.TBAXREPROBSCORE = RiskScore.probScore;
            RiskScore_.TBAXRETIPO = "UPDATEOB";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_RiskScore.Add(RiskScore_);
                DB.SaveChanges();
            }
        }

        public void Json(Ent_Json.RootObject Json)
        {
            Tab_Amex_Json Json_ = new Tab_Amex_Json();
            Json_.TBAXJNFECHA = DateTime.Now;
            Json_.TBAXJNUPDATEDATE = Json.updateDate;
            Json_.TBAXJNIDHEADER = Header(Json.header);
            Json_.TBAXJNTIPO = "PLACEMENT";

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Json.Add(Json_);
                DB.SaveChanges();
            }
            CaseInfoList(Json.caseInfoList, Json_.TBAXJNID);
        }

        public int HeaderUpd(Header Header)
        {
            Tab_Amex_Header Header_ = new Tab_Amex_Header();
            Header_.TBAXHRUPDATEDATE = Header.updateDate;
            Header_.TBAXHRSENDERID = Header.senderID;
            Header_.TBAXHRTARGETID = Header.targetID;
            Header_.TBAXHRTOTALRECORDS = Header.totalRecords;
            Header_.TBAXHRBALANCINGID = Header.balancingId;
            Header_.TBAXHRBALANCINGSEQNO = Header.balancingSeqNo;
            Header_.TBAXHRTIPO = "UPDATEOB";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Header.Add(Header_);
                DB.SaveChanges();
            }
            return Header_.TBAXHRID;
        }

        public int Header(Ent_Json.Header Header)
        {
            Tab_Amex_Header Header_ = new Tab_Amex_Header();
            Header_.TBAXHRUPDATEDATE = Header.updateDate;
            Header_.TBAXHRSENDERID = Header.senderID;
            Header_.TBAXHRTARGETID = Header.targetID;
            Header_.TBAXHRTOTALRECORDS = Header.totalRecords;
            Header_.TBAXHRBALANCINGID = Header.balancingId;
            Header_.TBAXHRBALANCINGSEQNO = Header.balancingSeqNo;
            Header_.TBAXHRTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Header.Add(Header_);
                DB.SaveChanges();
            }
            return Header_.TBAXHRID;
        }
        public void CaseInfoList(List<Ent_Json.CaseInfoList> CaseInfoList, int Id_Header)
        {
            for (int i = 0; i < CaseInfoList.Count; i++)
            {
                Tab_Amex_CaseInfoList CaseInfoList_ = new Tab_Amex_CaseInfoList();
                CaseInfoList_.TBAXCTUPDATEDATE = CaseInfoList[i].updateDate;
                CaseInfoList_.TBAXCT_ID = CaseInfoList[i].id;                 
                CaseInfoList_.TBAXCTIDHEADER = Id_Header;
                using (CYBEREntities DB = new CYBEREntities())
                {
                    DB.Tab_Amex_CaseInfoList.Add(CaseInfoList_);
                    DB.SaveChanges();
                }
                AccounInfoList(CaseInfoList[i].accountInfoList,CaseInfoList_.TBAXCTID);
            }
           
           

        }

        private void AccounInfoList(List<Ent_Json.AccountInfoList> accountInfoList, int Id_Case)
        {
            for (int i = 0; i < accountInfoList.Count; i++)
            {
                Tab_Amex_AccountInfoList accountInfoList_ = new Tab_Amex_AccountInfoList();
                accountInfoList_.TBAXATIDCASEINFOLIST = Id_Case;
                accountInfoList_.TBAXATUPDATEDATE = accountInfoList[i].updateDate;
                accountInfoList_.TBAXATUPDATEBY = accountInfoList[i].updatedBy;
                accountInfoList_.TBAXAT_ID = accountInfoList[i].id;
                accountInfoList_.TBAXATACCOUNTNUMBER = accountInfoList[i].accountNumber;
                if (accountInfoList[i].customerDetails!=null)               
                    accountInfoList_.TBAXATIDCUSTOMERDETAILS = CustomerDetails(accountInfoList[i].customerDetails);           
                if (accountInfoList[i].demographics!=null)
                    accountInfoList_.TBAXATIDDEMOGRAPHICS = Demographics(accountInfoList[i].demographics);
                if (accountInfoList[i].contactInfo!=null)
                    accountInfoList_.TBAXATIDCONTACTINFO = contactInfo(accountInfoList[i].contactInfo);
                if (accountInfoList[i].employer!=null)
                {
                    accountInfoList_.TBAXATIDEMPLOYER = Employer(accountInfoList[i].employer);
                }
                if (accountInfoList[i].relatedPerson!=null)
                {
                    accountInfoList_.TBAXATIDRELATEDPERSONLIST = RelatedPersonList(accountInfoList[i].relatedPerson);
                }
                if (accountInfoList[i].accountDetails!=null)
                {
                    accountInfoList_.TBAXATIDACCOUNTDETAILS = AccountDetails(accountInfoList[i].accountDetails);
                }
                if (accountInfoList[i].productDetails!=null)
                {
                    accountInfoList_.TBAXATIDPRODUCTDETAILS = ProductDetails(accountInfoList[i].productDetails);
                }
                if (accountInfoList[i].attorneyDetails!=null)
                {
                    accountInfoList_.TBAXATIDATTORNEYDETAILS = AttorneyDetails(accountInfoList[i].attorneyDetails);
                }
                if (accountInfoList[i].customerFinancial!=null)
                {
                    accountInfoList_.TBAXATIDCUSTOMERFINANCIAL = CustomerFinancial(accountInfoList[i].customerFinancial);
                }
                if (accountInfoList[i].financialRisk!=null)
                {
                    accountInfoList_.TBAXATIDFINANCIALRISK = FinancialRisk(accountInfoList[i].financialRisk);
                }
                if (accountInfoList[i].financialSummary!=null)
                {
                    accountInfoList_.TBAXATIDFINANCIALSUMMARY = FinancialSummary(accountInfoList[i].financialSummary);
                }
                if (accountInfoList[i].bankList!=null)
                {
                    accountInfoList_.TBAXATIDBANKLIST = BankList(accountInfoList[i].bankList);
                }
                if (accountInfoList[i].paymentInfo!=null)
                {
                    accountInfoList_.TBAXATIDPAYMENTINFO = PaymentInfo(accountInfoList[i].paymentInfo);
                }
                if (accountInfoList[i].additionalCmSpendInfo != null)
                {
                    accountInfoList_.TBAXATIDADDITIONALCMSPENDINFO = AdditionalCmSpendInfo(accountInfoList[i].additionalCmSpendInfo);
                }
                if (accountInfoList[i].bankruptcyDetails != null)
                {
                    accountInfoList_.TBAXATIDBANKRUPTCYDETAILS = BankruptcyDetails(accountInfoList[i].bankruptcyDetails);
                }
                if (accountInfoList[i].creditRiskInfo !=null)
                {
                    accountInfoList_.TBAXATIDCREDITRISKINFO = CreditRiskInfo(accountInfoList[i].creditRiskInfo);
                }
                if (accountInfoList[i].capInfo!=null)
                {
                    accountInfoList_.TBAXATIDCAPINFO = CapInfo(accountInfoList[i].capInfo);
                }
                if (accountInfoList[i].legal!=null)
                {
                    accountInfoList_.TBAXATIDLEGAL = Legal(accountInfoList[i].legal);
                }
                if (accountInfoList[i].judgement!=null)
                {
                    accountInfoList_.TBAXATIDJUDGEMENT = Judgement(accountInfoList[i].judgement);
                }
                if (accountInfoList[i].collectionInfo!=null)
                {
                    accountInfoList_.TBAXATIDCOLLECTIONINFO = CollectionInfo(accountInfoList[i].collectionInfo);
                }
                if (accountInfoList[i].financialTransactionDetails!=null)
                {
                    accountInfoList_.TBAXATIDFINANCIALTRANSACTIONDETAILS = FinancialTransactionDetails(accountInfoList[i].financialTransactionDetails);
                }
                if (accountInfoList[i].riskScore!=null)
                {
                    accountInfoList_.TBAXATIDRISKSCORE = RiskScore(accountInfoList[i].riskScore);
                }
                if (accountInfoList[i].regulatoryChange!=null)
                {
                    accountInfoList_.TBAXATIDREGULATORYCHANGE = RegulatoryChange(accountInfoList[i].regulatoryChange);
                }
                if (accountInfoList[i].treatment != null)
                {
                    accountInfoList_.TBAXATIDTREATMENT = Treatment(accountInfoList[i].treatment);
                }
                if (accountInfoList[i].settlement!=null)
                {
                    accountInfoList_.TBAXATIDSETTLEMENT = Settlement(accountInfoList[i].settlement);
                }
                if (accountInfoList[i].strategyInfo!=null)
                {
                    accountInfoList_.TBAXATIDSTRATEGYINFO = StrategyInfo(accountInfoList[i].strategyInfo);
                }
                if (accountInfoList[i].sugarBarFieldDetails != null)
                {
                    accountInfoList_.TBAXATIDSUGARBARFIELDDETAILS = SugarBarFieldDetails(accountInfoList[i].sugarBarFieldDetails);
                }
                if (accountInfoList[i].disputeDetails!= null)
                {
                    accountInfoList_.TBAXATIDDISPUTEDETAILS = DisputeDetails(accountInfoList[i].disputeDetails);
                }
                if (accountInfoList[i].account != null)
                {
                    accountInfoList_.TBAXATIDACCOUNT = Account(accountInfoList[i].account);
                }
                if (accountInfoList[i].collectionScore!=null)
                {
                    accountInfoList_.TBAXATIDCOLLECTIONSCORE = CollectionScore(accountInfoList[i].collectionScore);
                }

                if (accountInfoList[i].customerAdditionalDetails!=null)
                {
                    accountInfoList_.TBAXATIDCUSTOMERADDITIONALDETAILS = CustomerAdditionalDetails(accountInfoList[i].customerAdditionalDetails);
                }
                if (accountInfoList[i].historyNotes!=null)
                {
                    accountInfoList_.TBAXATIDHISTORYNOTES = HistoryNotes(accountInfoList[i].historyNotes);
                }
                if (accountInfoList[i].acornCase!=null)
                {
                    accountInfoList_.TBAXATIDACORNCASE = AcornCase(accountInfoList[i].acornCase);
                }
                if (accountInfoList[i].deceasedDetails!=null)
                {
                    accountInfoList_.TBAXATIDDECEASEDDETAILS = DeceasedDetails(accountInfoList[i].deceasedDetails);
                }
                if (accountInfoList[i].cmxTradeDemographics!=null)
                {
                    accountInfoList_.TBAXATIDCMXTRADEDEMOGRAPHICS = CmxTradeDemographics(accountInfoList[i].cmxTradeDemographics);
                }
                if (accountInfoList[i].agencyInfo!=null)
                {
                    accountInfoList_.TBAXATIDAGENCYINFO = AgencyInfo(accountInfoList[i].agencyInfo);
                }
                if (accountInfoList[i].agencyAssignment!=null)
                {
                    accountInfoList_.TBAXATIDAGENCYASSIGNMENT = AgencyAssignment(accountInfoList[i].agencyAssignment);
                }
                using (CYBEREntities DB = new CYBEREntities())
                {
                    DB.Tab_Amex_AccountInfoList.Add(accountInfoList_);
                    DB.SaveChanges();
                }
            }

        }
        public int AgencyInfo(Ent_Json.AgencyInfo AgencyInfo)
        {
            Tab_Amex_AgencyInfo AgencyInfo_ = new Tab_Amex_AgencyInfo();
            AgencyInfo_.TBAXAOUPDATEDATE = AgencyInfo.updateDate;
            AgencyInfo_.TBAXAO_ID = AgencyInfo.id;
            AgencyInfo_.TBAXAOAGENCYID = AgencyInfo.agencyId;
            AgencyInfo_.TBAXAOASSIGNMENTGROUPNUMBER = AgencyInfo.assignmentGroupNumber;
            AgencyInfo_.TBAXAOCOUNTRYCODE = AgencyInfo.countrycode;
            AgencyInfo_.TBAXAOAGENCYDESCRIPTION = AgencyInfo.agencyDescription;
            AgencyInfo_.TBAXAOCHANNELCODE = AgencyInfo.channelCode;
            AgencyInfo_.TBAXAOLEVELCODE = AgencyInfo.levelCode;
            AgencyInfo_.TBAXAOPROGRAMCODE = AgencyInfo.programCode;
            AgencyInfo_.TBAXAOLEGACYRECOVERCODE = AgencyInfo.legacyRecoverCode;
            if (AgencyInfo.agencyAddress!=null)
            {
                AgencyInfo_.TBAXAOIDAGENCYADDRESS = Address_(AgencyInfo.agencyAddress);
            }
            if (AgencyInfo.agencyPhone!=null)
            {
                AgencyInfo_.TBAXAOIDAGENCYPHONE = Phones(AgencyInfo.agencyPhone);
            }
            AgencyInfo_.TBAXAOAGENCYBRANCHNAME = AgencyInfo.agencyBranchName;
            AgencyInfo_.TBAXAOEXTENSIBLEATTRIBUTE = AgencyInfo.extensibleAttribute;
            return AgencyInfo_.TBAXAOID;
        }
        public int CmxTradeDemographics(Ent_Json.CmxTradeDemographics CmxTradeDemographics)
        {
            Tab_Amex_CmxTradeDemographics CmxTradeDemographics_ = new Tab_Amex_CmxTradeDemographics();
            CmxTradeDemographics_.TBAXCSUPDATEDATE = CmxTradeDemographics.updateDate;
            CmxTradeDemographics_.TBAXCSUPDATEDBY = CmxTradeDemographics.updatedBy;
            CmxTradeDemographics_.TBAXCSACCOUNTNUMBER = CmxTradeDemographics.accountNumber;
            if (CmxTradeDemographics.businessAddress!=null)
            {
                CmxTradeDemographics_.TBAXCSBUSINESSADDRESS = Address_(CmxTradeDemographics.businessAddress);
            }
            if (CmxTradeDemographics.businessCorrespondenceAddress!=null)
            {

                CmxTradeDemographics_.TBAXCSBUSINESSCORRESPONDENCEADDRESS = Address_(CmxTradeDemographics.businessCorrespondenceAddress);
            }
            
            CmxTradeDemographics_.TBAXCSBUSINESSCONTACTNAME = CmxTradeDemographics.businessContactName;
            if (CmxTradeDemographics.homeAddressOnBusinessAccount!= null)
            {
                for (int i = 0; i < CmxTradeDemographics.homeAddressOnBusinessAccount.Count; i++)
                {
                    Address(CmxTradeDemographics.homeAddressOnBusinessAccount[i], CmxTradeDemographics_.TBAXCSID);
                }
            }
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CmxTradeDemographics.Add(CmxTradeDemographics_);
                DB.SaveChanges();
            }
            return CmxTradeDemographics_.TBAXCSID;

        }
        public int AcornCase(Ent_Json.AcornCase AcornCase)
        {
            Tab_Amex_AcornCase AcornCase_ = new Tab_Amex_AcornCase();
            AcornCase_.TBAXAECASESETUPDATE = AcornCase.updateDate;
            AcornCase_.TBAXAEUPDATEDBY = AcornCase.updatedBy;
            AcornCase_.TBAXAE_ID = AcornCase.id;
            AcornCase_.TBAXAECASEID = AcornCase.caseId;
            AcornCase_.TBAXAEPARENTCASEID = AcornCase.parentCaseId;
            AcornCase_.TBAXAETYPE = AcornCase.type;
            if (AcornCase.accountNumbers!=null)
            {
                string Number = null;
                for (int i = 0; i < AcornCase.accountNumbers.Count; i++)
                {
                    if (i == 0)
                    {
                        Number = AcornCase.accountNumbers[i].ToString();
                    }
                    else
                    {
                        Number = Number + AcornCase.accountNumbers[i].ToString();
                    }
                }
                AcornCase_.TBAXAEACCOUNTNUMBERS = Number;
            }           
            AcornCase_.TBAXAECUSTOMERID = AcornCase.customerId;
            AcornCase_.TBAXAECHARGEOFFREASONCODE = AcornCase.chargeOffReasonCode;
            AcornCase_.TBAXAECOUNTRYISOALPHA2CODE = AcornCase.countryISOAlpha2Code;
            AcornCase_.TBAXAEBALANCE = Convert.ToDecimal(AcornCase.balance);
            AcornCase_.TBAXAECOLLECTIBILITYSCORE = AcornCase.collectibilityScore;
            AcornCase_.TBAXAEWRITEOFFDATE = AcornCase.writeOffDate;
            AcornCase_.TBAXAEMARKETCODE = AcornCase.marketCode;
            AcornCase_.TBAXAECASESTATUS = AcornCase.caseStatus;
            AcornCase_.TBAXAECASEPURPOSE = AcornCase.casePurpose;
            AcornCase_.TBAXAECASESETUPTYPE = AcornCase.caseSetupType;
            AcornCase_.TBAXAECASESETUPDATE = AcornCase.caseSetupDate;
            AcornCase_.TBAXAEBUSINESSLEADER = AcornCase.businessLeader;
            AcornCase_.TBAXAELASTREVIEWEDDATE = AcornCase.lastReviewedDate;
            AcornCase_.TBAXAELASTREVIEWEDBY = AcornCase.lastReviewedBy;
            AcornCase_.TBAXAELIFTDATE = AcornCase.liftDate;
            AcornCase_.TBAXAELASTCASESTATUSCHANGEDATE = AcornCase.lastCaseStatusChangeDate;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_AcornCase.Add(AcornCase_);
                DB.SaveChanges();
            }
            return AcornCase_.TBAXAEID;
        }
        private int HistoryNotes(Ent_Json.HistoryNotes HistoryNotes)
        {
            Tab_Amex_HistoryNotes HistoryNotes_ = new Tab_Amex_HistoryNotes();
            HistoryNotes_.TBAXHSUPDATEDATE = HistoryNotes.updateDate;
            HistoryNotes_.TBAXHSUPDATEDBY = HistoryNotes.updatedBy;
            HistoryNotes_.TBAXHSACCOUNTNUMBER = HistoryNotes.accountNumber;
            HistoryNotes_.TBAXHSACCOUNTCATEGORYTYPECODE = HistoryNotes.accountCategoryTypeCode;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_HistoryNotes.Add(HistoryNotes_);
                DB.SaveChanges();
            }
            if (HistoryNotes.historyNoteLineList != null)
            {
                for (int i = 0; i < HistoryNotes.historyNoteLineList.Count; i++)
                {
                    HistoryNoteLineList(HistoryNotes.historyNoteLineList[i], HistoryNotes_.TBAXHSID);
                }

            }
            return HistoryNotes_.TBAXHSID;
        }
        private void HistoryNoteLineList(Ent_Json.HistoryNoteLineList HistoryNoteLineList, int id)
        {
            Tab_Amex_HistoryNotesList HistoryNoteLineList_ = new Tab_Amex_HistoryNotesList();
            HistoryNoteLineList_.TBAXHTIDHISTORY = id;
            HistoryNoteLineList_.TBAXHTUPDATEDATE = HistoryNoteLineList.updateDate;
            HistoryNoteLineList_.TBAXHTUPDATEDBY = HistoryNoteLineList.updatedBy;
            HistoryNoteLineList_.TBAXHTACTIVITYCODE = HistoryNoteLineList.activityCode;
            HistoryNoteLineList_.TBAXHTACTIVITYTIMESTAMP = HistoryNoteLineList.activityTimeStamp;
            HistoryNoteLineList_.TBAXHTRESULTCODE = HistoryNoteLineList.resultCode;
            HistoryNoteLineList_.TBAXHTNOTES = HistoryNoteLineList.notes;
            HistoryNoteLineList_.TBAXHTCONTACTCODE = HistoryNoteLineList.contactCode;
            HistoryNoteLineList_.TBAXHTLIFTDATE = HistoryNoteLineList.liftDate;
            HistoryNoteLineList_.TBAXHTADDTIONALINFO = HistoryNoteLineList.addtionalInfo;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_HistoryNotesList.Add(HistoryNoteLineList_);
                DB.SaveChanges();
            }
        }
        private int SugarBarFieldDetails(Ent_Json.SugarBarFieldDetails SugarBarFieldDetails)
        {
            Tab_Amex_SugarBarFieldDetails SugarBarFieldDetails_ = new Tab_Amex_SugarBarFieldDetails();
            SugarBarFieldDetails_.TBAXSSUPDATEDATE = SugarBarFieldDetails.updateDate;
            SugarBarFieldDetails_.TBAXSSUPDATEDBY = SugarBarFieldDetails.updatedBy;
            SugarBarFieldDetails_.TBAXSS_ID = SugarBarFieldDetails.id;
            SugarBarFieldDetails_.TBAXSSACCOUNTNUMBER = SugarBarFieldDetails.accountNumber;
            SugarBarFieldDetails_.TBAXSSACCOUNTCATEGORYTYPECODE = Convert.ToInt32(SugarBarFieldDetails.accountCategoryTypeCode);

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_SugarBarFieldDetails.Add(SugarBarFieldDetails_);
                DB.SaveChanges();
            }
            if (SugarBarFieldDetails.sugarBarFields!=null)
            {
                for (int i = 0; i < SugarBarFieldDetails.sugarBarFields.Count; i++)
                {
                    SugarBarFields(SugarBarFieldDetails.sugarBarFields[i], SugarBarFieldDetails_.TBAXSSID);
                }
               
            }
            if (SugarBarFieldDetails.sugarBarMerchantFields != null)
            {
                for (int i = 0; i < SugarBarFieldDetails.sugarBarMerchantFields.Count; i++)
                {
                    SugarBarMerchantFields(SugarBarFieldDetails.sugarBarMerchantFields[i], SugarBarFieldDetails_.TBAXSSID);
                }
                
            }
            
            return SugarBarFieldDetails_.TBAXSSID;
        }
        private void SugarBarFields(Ent_Json.SugarBarFields SugarBarFields, int id)
        {
            Tab_Amex_SugarBarFields SugarBarFields_ = new Tab_Amex_SugarBarFields();
            SugarBarFields_.TBAXSSIDSUGAR = id;
            SugarBarFields_.TBAXSSUPDATEDATE = SugarBarFields.updateDate;
            SugarBarFields_.TBAXSS_ID = SugarBarFields.id;
            SugarBarFields_.TBAXSSACCOUNTNUMBER = SugarBarFields.accountNumber;
            SugarBarFields_.TBAXSSACCOUNTCATEGORYTYPECODE = SugarBarFields.accountCategoryTypeCode;
            SugarBarFields_.TBAXSSTOTALSPEND = Convert.ToDecimal(SugarBarFields.totalSpend);
            SugarBarFields_.TBAXSSTOTALVISIT = SugarBarFields.totalVisit;
            SugarBarFields_.TBAXSSHIGHESTCHARGE = Convert.ToDecimal(SugarBarFields.highestCharge);
            SugarBarFields_.TBAXSSSUPPCODE = SugarBarFields.suppCode;
            SugarBarFields_.TBAXSSSUMSPENDONCHARGEDATE = Convert.ToDecimal(SugarBarFields.sumSpendOnChargeDate);
            SugarBarFields_.TBAXSSNOOFVISITSONCHARGEDATE = SugarBarFields.noOfVisitsOnChargeDate;
            SugarBarFields_.TBAXSSCHARGEDATE = SugarBarFields.chargeDate;
            SugarBarFields_.TBAXSSMINIMUMPERIOD = SugarBarFields.minimumPeriod;
            SugarBarFields_.TBAXSSLEGACYFIELDCODE = SugarBarFields.legacyFieldCode;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_SugarBarFields.Add(SugarBarFields_);
                DB.SaveChanges();
            }
        }
        private void SugarBarMerchantFields(Ent_Json.SugarBarMerchantFields SugarBarMerchantFields, int id)
        {
            Tab_Amex_SugarBarMerchantFields SugarBarMerchantFields_ = new Tab_Amex_SugarBarMerchantFields();
            SugarBarMerchantFields_.TBAXSSIDSUGAR = id;
            SugarBarMerchantFields_.TBAXSSUPDATEDATE = SugarBarMerchantFields.updateDate;
            SugarBarMerchantFields_.TBAXSSUPDATEDBY = SugarBarMerchantFields.updatedBy;
            SugarBarMerchantFields_.TBAXSS_ID = SugarBarMerchantFields.id;
            SugarBarMerchantFields_.TBAXSSACCOUNTNUMBER = SugarBarMerchantFields.accountNumber;
            SugarBarMerchantFields_.TBAXSSACCOUNTCATEGORYTYPECODE = SugarBarMerchantFields.accountCategoryTypeCode;
            SugarBarMerchantFields_.TBAXSSSENAME = SugarBarMerchantFields.seName;
            SugarBarMerchantFields_.TBAXSSSEZIPCODE = SugarBarMerchantFields.seZipCode;
            SugarBarMerchantFields_.TBAXSSLEGACYFIELDCODE = SugarBarMerchantFields.legacyFieldCode;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_SugarBarMerchantFields.Add(SugarBarMerchantFields_);
                DB.SaveChanges();
            }
        }

        private int Treatment(Ent_Json.Treatment Treatment)
        {
            Tab_Amex_Treatment Treatment_ = new Tab_Amex_Treatment();
            Treatment_.TBAXTTUPDATEDATE = Treatment.updateDate;
            Treatment_.TBAXTT_ID = Treatment.id;
            Treatment_.TBAXTTACCOUNTNUMBER = Treatment.accountNumber;
            Treatment_.TBAXTTACCOUNTCATEGORYTYPECODE = Treatment.accountCategoryTypeCode;
            Treatment_.TBAXTTNEXTPAYMENTDATE = Treatment.nextPaymentDate;
            if (Treatment.care!=null)
            {
                Treatment_.TBAXTTIDCARE = Care(Treatment.care);
            }
            if (Treatment.cdmp != null)
            {
                Treatment_.TBAXTTIDCDMP = Cdmp(Treatment.cdmp);
            }
            Treatment_.TBAXTTACTUALSETTLEMENTAMOUNT = Treatment.actualSettlementAmount;
            Treatment_.TBAXTTTREATMENTELIGIBILITY = Treatment.treatmentEligibility;
            Treatment_.TBAXTTTREATMENTOFFER = Treatment.treatmentOffer;
            Treatment_.TBAXTTTREATMENTACCEPT = Treatment.treatmentAccept;
            Treatment_.TBAXTTTREATMENTCOMPLETION = Treatment.treatmentCompletion;
            Treatment_.TBAXTTTREATMENTEXPIRATION = Treatment.treatmentExpiration;
            Treatment_.TBAXTTTREATMENTPROGRAM = Treatment.treatmentProgram;
            Treatment_.TBAXTTAGREEDSETTLEMENTAMOUNT = Convert.ToDecimal(Treatment.agreedSettlementAmount);
            Treatment_.TBAXTTAPPLICATIONGEOSCRAMNUMBER = Treatment.applicationGeoScramNumber;
            Treatment_.TBAXTTAGENCYID = Treatment.agencyId;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Treatment.Add(Treatment_);
                DB.SaveChanges();
            }

            return Treatment_.TBAXTTID;
        }
        private int Cdmp(Ent_Json.Cdmp Cdmp)
        {
            Tab_Amex_Cdmp Cdmp_ = new Tab_Amex_Cdmp();
            Cdmp_.TBAXCPUPDATEDATE = Cdmp.updateDate;
            Cdmp_.TBAXCP_ID = Cdmp.id;
            Cdmp_.TBAXCPACCOUNTNUMBER = Cdmp.accountNumber;
            Cdmp_.TBAXCPACCOUNTCATEGORYTYPECODE = Cdmp.accountCategoryTypeCode;
            Cdmp_.TBAXCPPAYMENTAMOUNT = Convert.ToDecimal(Cdmp.paymentAmount);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Cdmp.Add(Cdmp_);
                DB.SaveChanges();
            }
            return Cdmp_.TBAXCPID;
        }
        private int Care(Ent_Json.Care Care)
        {
            Tab_Amex_Care Care_ = new Tab_Amex_Care();
            Care_.TBAXCEUPDATEDATE = Care.updateDate;
            Care_.TBAXCE_ID = Care.id;
            Care_.TBAXCEACCOUNTNUMBER = Care.accountNumber;
            Care_.TBAXCEACCOUNTCATEGORYTYPECODE = Care.accountCategoryTypeCode;
            Care_.TBAXCEOFFERFLAG = Care.offerFlag;
            Care_.TBAXCEACCEPTFLAG = Care.acceptFlag;
            Care_.TBAXCEMINIMUMDUEAMOUNT = Convert.ToDecimal(Care.minimumDueAmount);
            Care_.TBAXCEMINIMUMDUEDATE = Care.minimumDueDate;
            Care_.TBAXCELETTERDATE = Care.letterDate;
            Care_.TBAXCECARECOMPLETION = Care.careCompletion;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Care.Add(Care_);
                DB.SaveChanges();
            }
            return Care_.TBAXCEID;
        }

        private int FinancialTransactionDetails(Ent_Json.FinancialTransactionDetails FinancialTransactionDetails)
        {
            Tab_Amex_FinancialTransactionDetails FinancialTransactionDetails_ = new Tab_Amex_FinancialTransactionDetails();
            FinancialTransactionDetails_.TBAXFSUPDATEDATE = FinancialTransactionDetails.updateDate;
            FinancialTransactionDetails_.TBAXFSUPDATEDBY = FinancialTransactionDetails.updatedBy;
            FinancialTransactionDetails_.TBAXFSACCOUNTNUMBER = FinancialTransactionDetails.accountNumber;
            FinancialTransactionDetails_.TBAXFSACCOUNTCATEGORYTYPECODE = FinancialTransactionDetails.accountCategoryTypeCode;
            FinancialTransactionDetails_.TBAXFSTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_FinancialTransactionDetails.Add(FinancialTransactionDetails_);
                DB.SaveChanges();
            }
            if (FinancialTransactionDetails.transactions != null)
            {
                for (int i = 0; i < FinancialTransactionDetails.transactions.Count; i++)
                {
                    Transactions(FinancialTransactionDetails.transactions[i], FinancialTransactionDetails_.TBAXFSID);
                }
            }
            return FinancialTransactionDetails_.TBAXFSID;
        }
        public void Transactions(Ent_Json.Transactions Transactions,int id)
            {
            Tab_Amex_Transactions Transactions_ = new Tab_Amex_Transactions();
            Transactions_.TBAXTSIDFINANCIAL = id;
            Transactions_.TBAXTSUPDATEDATE = Transactions.updateDate;
            Transactions_.TBAXTSUPDATEDBY = Transactions.updatedBy;
            Transactions_.TBAXTSACCOUNTNUMBER = Transactions.accountNumber;
            Transactions_.TBAXTSACCOUNTCATEGORYTYPECODE = Transactions.accountCategoryTypeCode;
            Transactions_.TBAXTSLAST5DIGITSOFTRANSACTION = Transactions.last5DigitsOfTransaction;
            Transactions_.TBAXTSTRANSACTIONAMOUNT = Convert.ToDecimal(Transactions.transactionAmount);
            Transactions_.TBAXTSTRANSACTIONTYPECODE = Transactions.transactionTypeCode;
            Transactions_.TBAXTSTRANSACTIONDATE = Transactions.transactionDate;
            Transactions_.TBAXTSLEGACYFIELDCODE = Transactions.legacyFieldCode;
            Transactions_.TBAXTSTRANSACTIONCODE = Transactions.transactionCode;
            Transactions_.TBAXTSTRANSACTIONID = Transactions.transactionId;
            Transactions_.TBAXTSCURRENCY = Transactions.currency;
            Transactions_.TBAXTSTRANSACTIONREFERID = Transactions.transactionReferId;
            Transactions_.TBAXTSFOREIGNTRANSACTIONAMOUNT = Convert.ToDecimal(Transactions.foreignTransactionAmount);
            Transactions_.TBAXTSFOREIGNCURRENCYCODE = Transactions.foreignCurrencyCode;
            Transactions_.TBAXTSSTAMPEDFXRATE = Convert.ToDecimal(Transactions.stampedFxRate);
            Transactions_.TBAXTSSORTRANSACTIONCODE = Transactions.sorTransactionCode;
            Transactions_.TBAXTSCURRENTFOREIGNBALANCE = Convert.ToDecimal(Transactions.currentForeignBalance);
            Transactions_.TBAXTSCURRENTLOCALCURRENCYBALANCE = Convert.ToDecimal(Transactions.currentLocalCurrencyBalance);
            Transactions_.TBAXTSACORNPOSTDATE = Transactions.acornPostDate;
            Transactions_.TBAXTSPROCESSINGSTATUS = Transactions.processingStatus;
            Transactions_.TBAXTSTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Transactions.Add(Transactions_);
                DB.SaveChanges();
            }
        }

        private int Judgement(Ent_Json.Judgement Judgement)
        {
            Tab_Amex_Judgement Judgement_ = new Tab_Amex_Judgement();
            Judgement_.TBAXJTUPDATEDATE = Judgement.updateDate;
            Judgement_.TBAXJT_ID = Judgement.id;
            Judgement_.TBAXJTACCOUNTNUMBER = Judgement.accountNumber;
            Judgement_.TBAXJTACCOUNTCATEGORYTYPECODE = Judgement.accountCategoryTypeCode;            
            Judgement_.TBAXJTLEGALPROCEEDINGCOURTDATE = Judgement.legalProceedingCourtDate;
            Judgement_.TBAXJTREASONFORSUIT = Judgement.reasonForSuit;
            Judgement_.TBAXJTJUDGEMENTDATE = Judgement.judgementDate;
            Judgement_.TBAXJTJUDGEMENTEXPIRATIONDATE = Judgement.judgementExpirationDate;
            Judgement_.TBAXJTCOURTOFRECORDNAME = Judgement.courtOfRecordName;
            Judgement_.TBAXJTJUDGEMENTPRINCIPALBALANCE = Convert.ToDecimal(Judgement.judgementPrincipalBalance);
            Judgement_.TBAXJTNOOFACCOUNTSINJUDGEMENT = Judgement.noOfAccountsInJudgement;
            Judgement_.TBAXJTPOSTJUDGEMENTINTERESTAWARD = Judgement.postJudgementInterestAward;
            Judgement_.TBAXJTPOSTJUDGEMENTINTERESTDATE = Convert.ToDecimal(Judgement.postJudgementInterestDate);
            Judgement_.TBAXJTCOURTCOST = Convert.ToDecimal(Judgement.courtCost);
            Judgement_.TBAXJTATTORNEYFEES = Convert.ToDecimal(Judgement.attorneyFees);
            Judgement_.TBAXJTPREJUDGEMENTINTEREST = Convert.ToDecimal(Judgement.preJudgementInterest);
            Judgement_.TBAXJTJUDGEMENTBALANCE = Convert.ToDecimal(Judgement.judgementBalance);
            Judgement_.TBAXJTCOURTOFRECORDCOUNTY = Judgement.courtOfRecordCounty;
            Judgement_.TBAXJTCOURTOFRECORDSTATE = Judgement.courtOfRecordState;
            Judgement_.TBAXJTATTORNEYOFRECORDAGENCY = Judgement.attorneyOfRecordAgency;
            if (Judgement.attorneyOfRecordPhone!=null)
            {
                Judgement_.TBAXJTIDATTORNEYOFRECORDPHONE = Phones(Judgement.attorneyOfRecordPhone);
            }
            Judgement_.TBAXJTACCOUNTSINJUDGEMENT = Judgement.accountsInJudgement;
            Judgement_.TBAXJTPOSTJUDGEMENTINTERESTRATE = Convert.ToDecimal(Judgement.postJudgementInterestRate);
            Judgement_.TBAXJTPRIMARYACCOUNT = Judgement.primaryAccount;
            Judgement_.TBAXJTBALANCEINLAWSUIT = Convert.ToDecimal(Judgement.balanceInLawSuit);
            Judgement_.TBAXJTSATISFACTIONOFJUDGEMENTFULFILLEDDATE = Judgement.satisfactionOfJudgementFulfilledDate;
            Judgement_.TBAXJTSATISFACTIONOFJUDGEMENTREQUESTEDDATE = Judgement.satisfactionOfJudgementRequestedDate;
            if (Judgement.judgementExecutionAttemptsAndProgressByType!=null)
            {
                string V =null;
                for (int i = 0; i < Judgement.judgementExecutionAttemptsAndProgressByType.Count; i++)
                {
                    if (i == 0)
                    {
                        V =Judgement.judgementExecutionAttemptsAndProgressByType[i];
                    }
                    else
                    {
                        V = V + '/' + Judgement.judgementExecutionAttemptsAndProgressByType[i];
                    }
                   
                }
                Judgement_.TBAXJTJUDGEMENTEXECUTIONATTEMPTSANDPROGRESSBYTYPE = V;
            }
            if (Judgement.judgementOperatingMetrics!=null)
            {
                Judgement_.TBAXJTIDJUDGEMENTOPERATINGMETRICS = JudgementOperatingMetrics(Judgement.judgementOperatingMetrics);
            }
            if (Judgement.judgementWorkStandards != null)
            {
                Judgement_.TBAXJTIDJUDGEMENTWORKSTANDARDS = JudgementWorkStandards(Judgement.judgementWorkStandards);
            }
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Judgement.Add(Judgement_);
                DB.SaveChanges();
            }
            if (Judgement.linkedAccountBalance != null)
            {
                for (int i = 0; i < Judgement.linkedAccountBalance.Count; i++)
                {
                    LinkedAccountBalance(Judgement.linkedAccountBalance[i], Judgement_.TBAXJTID);
                }
            }
            return Judgement_.TBAXJTID;
        }
        private void LinkedAccountBalance(Ent_Json.LinkedAccountBalance LinkedAccountBalance ,int id)
        {
            Tab_Amex_LinkedAccountBalance LinkedAccountBalance_ = new Tab_Amex_LinkedAccountBalance();
            LinkedAccountBalance_.TBAXLEIDJUDGEMENT = id;
            LinkedAccountBalance_.TBAXLEUPDATEDATE = LinkedAccountBalance.updateDate;
            LinkedAccountBalance_.TBAXLEUPDATEDBY = LinkedAccountBalance.updatedBy;
            LinkedAccountBalance_.TBAXLEACCOUNTNUMBER = LinkedAccountBalance.accountNumber;
            LinkedAccountBalance_.TBAXLEACCOUNTCATEGORYTYPECODE = LinkedAccountBalance.accountCategoryTypeCode;
            LinkedAccountBalance_.TBAXLEBALANCE = Convert.ToDecimal(LinkedAccountBalance.balance);
            LinkedAccountBalance_.TBAXLELEGACYCODE = LinkedAccountBalance.legacyCode;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_LinkedAccountBalance.Add(LinkedAccountBalance_);
                DB.SaveChanges();
            }
        }
        private int JudgementWorkStandards(Ent_Json.JudgementWorkStandards JudgementWorkStandards)
        {
            Tab_Amex_JudgementWorkStandards JudgementWorkStandards_ = new Tab_Amex_JudgementWorkStandards();
            JudgementWorkStandards_.TBAXJSUPDATEDATE = JudgementWorkStandards.updateDate;
                JudgementWorkStandards_.TBAXJS_ID = JudgementWorkStandards.id;
            JudgementWorkStandards_.TBAXJSACCOUNTNUMBER = JudgementWorkStandards.accountNumber;
            JudgementWorkStandards_.TBAXJSACCOUNTCATEGORYTYPECODE = JudgementWorkStandards.accountCategoryTypeCode;
            JudgementWorkStandards_.TBAXJSJUDGEMENTID = JudgementWorkStandards.judgementId;
            JudgementWorkStandards_.TBAXJSDATE = JudgementWorkStandards.date;
            JudgementWorkStandards_.TBAXJSSKIPTRACE = JudgementWorkStandards.skipTrace;
            JudgementWorkStandards_.TBAXJSMANAGERREVIEW = JudgementWorkStandards.managerReview;
            JudgementWorkStandards_.TBAXJSFOUNDPOE = JudgementWorkStandards.foundPoe;
            JudgementWorkStandards_.TBAXJSFOUNDBANK = JudgementWorkStandards.foundBank;
            JudgementWorkStandards_.TBAXJSFOUNDVEHICLE = JudgementWorkStandards.foundVehicle;
            JudgementWorkStandards_.TBAXJSFOUNDREALESTATE = JudgementWorkStandards.foundRealEstate;
            JudgementWorkStandards_.TBAXJSFOUNDOTHERASSETS = JudgementWorkStandards.foundOtherAssets;
            JudgementWorkStandards.activeBusiness = JudgementWorkStandards.activeBusiness;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_JudgementWorkStandards.Add(JudgementWorkStandards_);
                DB.SaveChanges();
            }
            return JudgementWorkStandards_.TBAXJSID;
        }
        private int JudgementOperatingMetrics(Ent_Json.JudgementOperatingMetrics JudgementOperatingMetrics)
        {
            Tab_Amex_JudgementOperatingMetrics JudgementOperatingMetrics_ = new Tab_Amex_JudgementOperatingMetrics();
            JudgementOperatingMetrics_.TBAXJSUPDATEDATE = JudgementOperatingMetrics.updateDate;
                JudgementOperatingMetrics_.TBAXJS_ID = JudgementOperatingMetrics.id;
            JudgementOperatingMetrics_.TBAXJSACCOUNTNUMBER = JudgementOperatingMetrics.accountNumber;
            JudgementOperatingMetrics_.TBAXJSACCOUNTCATEGORYTYPECODE = JudgementOperatingMetrics.accountCategoryTypeCode;
            JudgementOperatingMetrics_.TBAXJSJUDGEMENTID = JudgementOperatingMetrics.judgementId;
            JudgementOperatingMetrics_.TBAXJSDATE = JudgementOperatingMetrics.date;
            JudgementOperatingMetrics_.TBAXJSNOOFUNIQUEPHONENUMBERS = JudgementOperatingMetrics.noOfUniquePhoneNumbers;
            JudgementOperatingMetrics_.TBAXJSNOOFATTEMPTS = JudgementOperatingMetrics.noOfAttempts;
            JudgementOperatingMetrics_.TBAXJSNOOFOUTBOUNDCONTACTS = JudgementOperatingMetrics.noOfOutboundContacts;
            JudgementOperatingMetrics_.TBAXJSNOOFOUTBOUNDRIGHTPARTYCONTACTS = JudgementOperatingMetrics.noOfOutboundRightPartyContacts;
            JudgementOperatingMetrics_.TBAXJSNOOFINBOUNDCONTACTS = JudgementOperatingMetrics.noOfInboundContacts;
            JudgementOperatingMetrics_.TBAXJSNOOFINBOUNDRIGHTPARTYCONTACTS = JudgementOperatingMetrics.noOfInboundRightPartyContacts;
            JudgementOperatingMetrics_.TBAXJSNOOFPROMISES = JudgementOperatingMetrics.noOfPromises;
            JudgementOperatingMetrics_.TBAXJSNOOFPAYMENTS = JudgementOperatingMetrics.noOfPayments;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_JudgementOperatingMetrics.Add(JudgementOperatingMetrics_);
                DB.SaveChanges();
            }
            return JudgementOperatingMetrics_.TBAXJSID;
        }
        private int BankruptcyDetails(Ent_Json.BankruptcyDetails BankruptcyDetails)
        {
            Tab_Amex_BankruptcyDetails BankruptcyDetails_ = new Tab_Amex_BankruptcyDetails();
            BankruptcyDetails_.TBAXBSUPDATEDATE = BankruptcyDetails.updateDate;
            BankruptcyDetails_.TBAXBSUPDATEDBY = BankruptcyDetails.updatedBy;
            BankruptcyDetails_.TBAXBSACCOUNTNUMBER = BankruptcyDetails.accountNumber;
            BankruptcyDetails_.TBAXBSACCOUNTCATEGORYTYPECODE = BankruptcyDetails.accountCategoryTypeCode;
            BankruptcyDetails_.TBAXBSASSETINDICATOR = BankruptcyDetails.assetIndicator;
            BankruptcyDetails_.TBAXBSBANKRUPTCYFILINGDATE = BankruptcyDetails.bankruptcyFilingDate;
            BankruptcyDetails_.TBAXBSBANKRUPTCYCHAPTER = BankruptcyDetails.bankruptcyChapter;
            BankruptcyDetails_.TBAXBSBANKRUPTCYCHAPTERCODE = BankruptcyDetails.bankruptcyChapterCode;
            BankruptcyDetails_.TBAXBSATTORNEYNAME = BankruptcyDetails.attorneyName;
            if (BankruptcyDetails.attorneyAddress!=null)
            {
                BankruptcyDetails_.TBAXBSATTORNEYADDRESS = Address_(BankruptcyDetails.attorneyAddress);
            }
            if (BankruptcyDetails.executorAddress!=null)
            {
                BankruptcyDetails_.TBAXBSEXECUTORADDRESS = Address_(BankruptcyDetails.executorAddress);
            }
            if (BankruptcyDetails.executorPhone!=null)
            {
                BankruptcyDetails_.TBAXBSEXECUTORPHONE = Phones(BankruptcyDetails.executorPhone);
            }           
            BankruptcyDetails_.TBAXBSCASENUMBER = BankruptcyDetails.caseNumber;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_BankruptcyDetails.Add(BankruptcyDetails_);
                DB.SaveChanges();
            }
            return BankruptcyDetails_.TBAXBSID;
        }

        private int AdditionalCmSpendInfo(Ent_Json.AdditionalCmSpendInfo AdditionalCmSpendInfo)
        {
            Tab_Amex_AdditionalCmSpendInfo AdditionalCmSpendInfo_ = new Tab_Amex_AdditionalCmSpendInfo();
            AdditionalCmSpendInfo_.TBAXAOUPDATEDATE = AdditionalCmSpendInfo_.TBAXAOUPDATEDATE;
            AdditionalCmSpendInfo_.TBAXAOUPDATEDBY = AdditionalCmSpendInfo_.TBAXAOUPDATEDBY;
            AdditionalCmSpendInfo_.TBAXAOACCOUNTNUMBER = AdditionalCmSpendInfo_.TBAXAOACCOUNTNUMBER;
            AdditionalCmSpendInfo_.TBAXAOACCOUNTCATEGORYTYPECODE = AdditionalCmSpendInfo_.TBAXAOACCOUNTCATEGORYTYPECODE;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_AdditionalCmSpendInfo.Add(AdditionalCmSpendInfo_);
                DB.SaveChanges();
            }
            if (AdditionalCmSpendInfo.additionalCmSpends != null)
            {
                for (int i = 0; i < AdditionalCmSpendInfo.additionalCmSpends.Count; i++)
                {
                    AdditionalCmSpends(AdditionalCmSpendInfo.additionalCmSpends[i], AdditionalCmSpendInfo_.TBAXAOID);
                }
            }
            return AdditionalCmSpendInfo_.TBAXAOID;
        }
        private void AdditionalCmSpends(Ent_Json.AdditionalCmSpends AdditionalCmSpends, int id)
        {
            Tab_Amex_AdditionalCmSpends AdditionalCmSpends_ = new Tab_Amex_AdditionalCmSpends();
            AdditionalCmSpends_.TBAXASIDSPENDINFO = id;
            AdditionalCmSpends_.TBAXASUPDATEDATE = AdditionalCmSpends.updateDate;
            AdditionalCmSpends_.TBAXASUPDATEDBY = AdditionalCmSpends.updatedBy;
            AdditionalCmSpends_.TBAXASACCOUNTNUMBER = AdditionalCmSpends.accountNumber;
            AdditionalCmSpends_.TBAXASACCOUNTCATEGORYTYPECODE = AdditionalCmSpends.accountCategoryTypeCode;
            AdditionalCmSpends_.TBAXASADDITIONALCMACCOUNTNUMBER = AdditionalCmSpends.additionalCmAccountNumber;
            AdditionalCmSpends_.TBAXASFIRSTNAME = AdditionalCmSpends.firstName;
            AdditionalCmSpends_.TBAXASLASTNAME = AdditionalCmSpends.lastName;
            AdditionalCmSpends_.TBAXASTOTALAMOUNTSPENTIN6MONTHS = Convert.ToDecimal(AdditionalCmSpends.totalAmountSpentIn6Months);
            AdditionalCmSpends_.TBAXASPERCENTAGEOFBALANCE = Convert.ToDecimal(AdditionalCmSpends.percentageOfBalance);
            AdditionalCmSpends_.TBAXASHIGHSPEND = Convert.ToDecimal(AdditionalCmSpends.highSpend);
            AdditionalCmSpends_.TBAXASLEGACYFIELDCODE = AdditionalCmSpends.legacyFieldCode;            
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_AdditionalCmSpends.Add(AdditionalCmSpends_);
                DB.SaveChanges();
            }
        }

        private int BankList(Ent_Json.BankList BankList)
        {
            Tab_Amex_BankList BankList_ = new Tab_Amex_BankList();
            BankList_.TBAXBTUPDATEDATE = BankList.updateDate;
            BankList_.TBAXBTUPDATEDBY = BankList.updatedBy;
            BankList_.TBAXBTACCOUNTNUMBER = BankList.accountNumber;
            BankList_.TBAXBTACCOUNTCATEGORYTYPECODE = BankList.accountCategoryTypeCode;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_BankList.Add(BankList_);
                DB.SaveChanges();
            }
            if (BankList.banks!=null)
            {
                for (int i = 0; i < BankList.banks.Count; i++)
                {
                    Banks(BankList.banks[i], BankList_.TBAXBTID);
                }
            }
            return BankList_.TBAXBTID;
        }

        private void Banks(Ent_Json.Bank Bank, int id)
        {
            Tab_Amex_Banks Banks_ = new Tab_Amex_Banks();
            Banks_.TBAXBSIDBANKLIST = id;
            Banks_.TBAXBSUPDATEDATE = Bank.updateDate;
            Banks_.TBAXBSUPDATEDBY = Bank.updatedBy;
            Banks_.TBAXBSCUSTOMERID = Bank.customerId;
            Banks_.TBAXBSNAME = Bank.name;
            Banks_.TBAXBSTYPE = Bank.type;
            Banks_.TBAXBSPHONE = Bank.phone;
            Banks_.TBAXBSBANKACCOUNTNUMBER = Bank.bankAccountNumber;
            Banks_.TBAXBSLASTUPDATEDDATE = Bank.lastUpdatedDate;
            Banks_.TBAXBSROUTINGNUMBER = Bank.routingNumber;
            Banks_.TBAXBSABANUMBER = Bank.abaNumber;
            Banks_.TBAXBSDATEACCOUNTOPENED = Bank.dateAccountOpened;
            Banks_.TBAXBSLASTAMOUNT = Bank.lastAmount.ToString();
            Banks_.TBAXBSLASTACTIVITYDATE = Bank.lastActivityDate;
            Banks_.TBAXBSSOURCEFLAG = Bank.sourceFlag;
            Banks_.TBAXBSLEGACYFIELDCODE = Bank.legacyFieldCode;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Banks.Add(Banks_);
                DB.SaveChanges();
            }

        }

        private int FinancialSummary(Ent_Json.FinancialSummary FinancialSummary)
        {
            Tab_Amex_FinancialSummary FinancialSummary_ = new Tab_Amex_FinancialSummary();
            FinancialSummary_.TBAXFYUPDATEDATE = FinancialSummary.updateDate;
            FinancialSummary_.TBAXFYUPDATEDBY = FinancialSummary.updatedBy;
            FinancialSummary_.TBAXFYACCOUNTNUMBER = FinancialSummary.accountNumber;
            FinancialSummary_.TBAXFYACCOUNTCATEGORYTYPECODE = FinancialSummary.accountCategoryTypeCode;
            FinancialSummary_.TBAXFYTIPO = "PLACEMENT";
            if (FinancialSummary.debitSummaryInMonths!=null)
            {
                FinancialSummary_.TBAXFYIDDEBITSUMMARYINMONTHS = DebitSummaryInMonths(FinancialSummary.debitSummaryInMonths);
            }
            if (FinancialSummary.accountBalanceInMonths!=null)
            {
                FinancialSummary_.TBAXFYIDACCOUNTBALANCEINMONTHS = AccountBalanceInMonths(FinancialSummary.accountBalanceInMonths);
            }
            if (FinancialSummary.interestAccessedByMonth !=null)
            {
                FinancialSummary_.TBAXFYIDINTERESTACCESSEDBYMONTH = InterestAccessedByMonth(FinancialSummary.interestAccessedByMonth);
            }
            if (FinancialSummary.summaryCreditInMonths!= null)
            {
                FinancialSummary_.TBAXFYIDSUMMARYCREDITINMONTHS = SummaryCreditInMonths(FinancialSummary.summaryCreditInMonths);
            }
            FinancialSummary_.TBAXFYPREVIOUSBALANCE = Convert.ToDecimal(FinancialSummary.previousBalance);
            if (FinancialSummary.accountAgingInMonths!=null)
            {
                FinancialSummary_.TBAXFYIDACCOUNTAGINGINMONTHS = AccountAgingInMonths(FinancialSummary.accountAgingInMonths);
            }

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_FinancialSummary.Add(FinancialSummary_);
                DB.SaveChanges();
            }
            return FinancialSummary_.TBAXFYID;
        }
        private int AccountAgingInMonths(Ent_Json.AccountAgingInMonths AccountAgingInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "PLACEMENT";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(AccountAgingInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(AccountAgingInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(AccountAgingInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(AccountAgingInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(AccountAgingInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(AccountAgingInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(AccountAgingInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(AccountAgingInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(AccountAgingInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(AccountAgingInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(AccountAgingInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(AccountAgingInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }
        private int SummaryCreditInMonths(Ent_Json.SummaryCreditInMonths SummaryCreditInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "PLACEMENT";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(SummaryCreditInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(SummaryCreditInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(SummaryCreditInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(SummaryCreditInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(SummaryCreditInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(SummaryCreditInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(SummaryCreditInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(SummaryCreditInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(SummaryCreditInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(SummaryCreditInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(SummaryCreditInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(SummaryCreditInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }
        private int InterestAccessedByMonth(Ent_Json.InterestAccessedByMonth InterestAccessedByMonth)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "PLACEMENT";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(InterestAccessedByMonth.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(InterestAccessedByMonth.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(InterestAccessedByMonth.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(InterestAccessedByMonth.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(InterestAccessedByMonth.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(InterestAccessedByMonth.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(InterestAccessedByMonth.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(InterestAccessedByMonth.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(InterestAccessedByMonth.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(InterestAccessedByMonth.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(InterestAccessedByMonth.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(InterestAccessedByMonth.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }
        private int AccountBalanceInMonths(Ent_Json.AccountBalanceInMonths AccountBalanceInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "PLACEMENT";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(AccountBalanceInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(AccountBalanceInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(AccountBalanceInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(AccountBalanceInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(AccountBalanceInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(AccountBalanceInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(AccountBalanceInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(AccountBalanceInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(AccountBalanceInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(AccountBalanceInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(AccountBalanceInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(AccountBalanceInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }

        private int DebitSummaryInMonths(Ent_Json.DebitSummaryInMonths DebitSummaryInMonths)
        {
            Tab_Amex_Months DebitSummaryInMonths_ = new Tab_Amex_Months();
            DebitSummaryInMonths_.TBAXMSTIPO = "PLACEMENT";
            DebitSummaryInMonths_.TBAXMSMONTH01 = Convert.ToDecimal(DebitSummaryInMonths.Month01);
            DebitSummaryInMonths_.TBAXMSMONTH02 = Convert.ToDecimal(DebitSummaryInMonths.Month02);
            DebitSummaryInMonths_.TBAXMSMONTH03 = Convert.ToDecimal(DebitSummaryInMonths.Month03);
            DebitSummaryInMonths_.TBAXMSMONTH04 = Convert.ToDecimal(DebitSummaryInMonths.Month04);
            DebitSummaryInMonths_.TBAXMSMONTH05 = Convert.ToDecimal(DebitSummaryInMonths.Month05);
            DebitSummaryInMonths_.TBAXMSMONTH06 = Convert.ToDecimal(DebitSummaryInMonths.Month06);
            DebitSummaryInMonths_.TBAXMSMONTH07 = Convert.ToDecimal(DebitSummaryInMonths.Month07);
            DebitSummaryInMonths_.TBAXMSMONTH08 = Convert.ToDecimal(DebitSummaryInMonths.Month08);
            DebitSummaryInMonths_.TBAXMSMONTH09 = Convert.ToDecimal(DebitSummaryInMonths.Month09);
            DebitSummaryInMonths_.TBAXMSMONTH10 = Convert.ToDecimal(DebitSummaryInMonths.Month10);
            DebitSummaryInMonths_.TBAXMSMONTH11 = Convert.ToDecimal(DebitSummaryInMonths.Month11);
            DebitSummaryInMonths_.TBAXMSMONTH12 = Convert.ToDecimal(DebitSummaryInMonths.Month12);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Months.Add(DebitSummaryInMonths_);
                DB.SaveChanges();
            }
            return DebitSummaryInMonths_.TBAXMSID;
        }

        public int CustomerDetails(Ent_Json.CustomerDetails CustomerDetails)
        {
            Tab_Amex_CustomerDetails CustomerDetails_ = new Tab_Amex_CustomerDetails();
            CustomerDetails_.TBAXCSUPDATEDATE = CustomerDetails.updateDate;
            CustomerDetails_.TBAXCSUPDATEDBY = CustomerDetails.updatedBy;
            CustomerDetails_.TBAXCSCUSTOMERID = CustomerDetails.customerId;
            CustomerDetails_.TBAXCSACCOUNTMARKETCODE = CustomerDetails.accountMarketCode;
            CustomerDetails_.TBAXCSCOUNTRYCODE = CustomerDetails.countryCode;
            CustomerDetails_.TBAXCSHOMEMARKETVALUE = Convert.ToDecimal(CustomerDetails.homeMarketValue);
            CustomerDetails_.TBAXCSHOMEEQUITY = Convert.ToDecimal(CustomerDetails.homeEquity);
            CustomerDetails_.TBAXCSMONTHLYMORTGAGE = Convert.ToDecimal(CustomerDetails.monthlyMortgage);
            CustomerDetails_.TBAXCSCARDMEMBERTITLE = CustomerDetails.cardMemberTitle;
            CustomerDetails_.TBAXCSPREFERREDLANGUAGEINDICATOR = CustomerDetails.preferredLanguageIndicator;
            CustomerDetails_.TBAXCSAMEXPORTFOLIOORLENDINGOFFICERCODE = CustomerDetails.amexPortfolioOrLendingOfficerCode;
            CustomerDetails_.TBAXCSACCOUNTNUMBER = CustomerDetails.accountNumber;
            CustomerDetails_.TBAXCSACCOUNTCATEGORYTYPECODE = CustomerDetails.accountCategoryTypeCode;
            CustomerDetails_.TBAXCSTAXIDFIELDEXT = CustomerDetails.taxidfieldext;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CustomerDetails.Add(CustomerDetails_);
                DB.SaveChanges();
            }
            return CustomerDetails_.TBAXCSID;
        }
        public int Demographics(Ent_Json.Demographics Demographics)
        {
            Tab_Amex_Demographics Demographics_ = new Tab_Amex_Demographics();
            Demographics_.TBAXDSUPDATEDATE = Demographics.updateDate;
            Demographics_.TBAXDSUPDATEDBY = Demographics.updatedBy;
            Demographics_.TBAXDSTITLE = Demographics.title;
            Demographics_.TBAXDSFIRSTNAME = Demographics.firstName;
            Demographics_.TBAXDSMIDDLENAME = Demographics.middleName;
            Demographics_.TBAXDSLASTNAME = Demographics.lastName;
           
            Demographics_.TBAXDSBIRTHDATE = Demographics.birthDate;
            Demographics_.TBAXDSACCOUNTNUMBER = Demographics.accountNumber;
            Demographics_.TBAXDSACCOUNTCATEGORYTYPECODE = Demographics.accountCategoryTypeCode;
            Demographics_.TBAXDSRETURNMAILINDICATOR = Demographics.returnMailIndicator;
            Demographics_.TBAXDSTIPO = "PLACEMENT";

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Demographics.Add(Demographics_);
                DB.SaveChanges();
            }
            if (Demographics.addresses !=null)
            {
                for (int i = 0; i < Demographics.addresses.Count; i++)
                {
                    if (Demographics.addresses[i] != null)
                    {
                        Address(Demographics.addresses[i], Demographics_.TBAXDSID);
                    }

                }
            }
            
            if (Demographics.emails!=null)
            {
                for (int i = 0; i < Demographics.emails.Count; i++)
                {
                    if (Demographics.emails[i] != null)
                    {
                        Emails(Demographics.emails[i], Demographics_.TBAXDSID);
                    }
                }
            }
            if (Demographics.phones!=null)
            {
                for (int i = 0; i < Demographics.phones.Count; i++)
                {
                    if (Demographics.phones[i] != null)
                    {
                        Phones(Demographics.phones[i], Demographics_.TBAXDSID);
                    }

                }
            }
            if (Demographics.nationalIds!=null)
            {
                for (int i = 0; i < Demographics.nationalIds.Count; i++)
                {
                    if (Demographics.nationalIds[i] != null)
                    {
                        NationalIds(Demographics.nationalIds[i], Demographics_.TBAXDSID);
                    }

                }
            }
          
            return Demographics_.TBAXDSID;
        }
        public int Address_(Ent_Json.Address Address)
        {
            Tab_Amex_Address Address_ = new Tab_Amex_Address();
            Address_.TBAXASUPDATEDATE = Address.updateDate;
            Address_.TBAXASUPDATEDBY = Address.updatedBy;
            Address_.TBAXASTYPECODE = Address.typeCode;
            Address_.TBAXASCATEGORYCODE = Address.categoryCode;
            Address_.TBAXASSTATUSCODE = Address.statusCode;
            Address_.TBAXASADDRESSLINE1 = Address.addressLine1;
            Address_.TBAXASADDRESSLINE2 = Address.addressLine2;
            Address_.TBAXASADDRESSLINE3 = Address.addressLine3;
            Address_.TBAXASCITY = Address.city;
            Address_.TBAXASSTATE = Address.state;
            Address_.TBAXASCOUNTRY = Address.country;
            Address_.TBAXASZIPCODE = Address.zipCode;
            Address_.TBAXASADDRESSCONFIRMATIONDATE = Address.addressConfirmationDate;
            Address_.TBAXASLASTUPDATEDATE = Address.lastUpdateDate;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Address.Add(Address_);
                DB.SaveChanges();
            }
            return Address_.TBAXASID;
        }
        public void Address(Ent_Json.Address Address, int Id)
        {
            Tab_Amex_Address Address_ = new Tab_Amex_Address();
            Address_.TBAXASIDENT = Id;
            Address_.TBAXASUPDATEDATE = Address.updateDate;
            Address_.TBAXASUPDATEDBY = Address.updatedBy;
            Address_.TBAXASTYPECODE = Address.typeCode;
            Address_.TBAXASCATEGORYCODE = Address.categoryCode;
            Address_.TBAXASSTATUSCODE = Address.statusCode;
            Address_.TBAXASADDRESSLINE1 = Address.addressLine1;
            Address_.TBAXASADDRESSLINE2 = Address.addressLine2;
            Address_.TBAXASADDRESSLINE3 = Address.addressLine3;
            Address_.TBAXASCITY = Address.city;
            Address_.TBAXASSTATE = Address.state;
            Address_.TBAXASCOUNTRY = Address.country;
            Address_.TBAXASZIPCODE = Address.zipCode;
            Address_.TBAXASADDRESSCONFIRMATIONDATE = Address.addressConfirmationDate;
            Address_.TBAXASLASTUPDATEDATE = Address.lastUpdateDate;
            Address_.TBAXASTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Address.Add(Address_);
                DB.SaveChanges();
            }
        }
        public int Emails_(Ent_Json.Emails Emails)
        {
            Tab_Amex_Emails Emails_ = new Tab_Amex_Emails();
            Emails_.TBAXESUPDATEDATE = Emails.updateDate;
            Emails_.TBAXESUPDATEDBY = Emails.updatedBy;
            Emails_.TBAXES_ID = Emails.id;
            Emails_.TBAXESTYPECODE = Emails.typeCode;
            Emails_.TBAXESCATEGORYCODE = Emails.categoryCode;
            Emails_.TBAXESSTATUSCODE = Emails.statusCode;
            Emails_.TBAXESCONSENT = Emails.consent;
            Emails_.TBAXESEMAILADDRESS = Emails.emailAddress;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Emails.Add(Emails_);
                DB.SaveChanges();
            }
            return Emails_.TBAXESID;
        }
        public void Emails(Ent_Json.Emails Emails, int Id)
        {
            Tab_Amex_Emails Emails_ = new Tab_Amex_Emails();
            Emails_.TBAXESUPDATEDATE = Emails.updateDate;
            Emails_.TBAXESIDENT = Id;
            Emails_.TBAXESUPDATEDBY = Emails.updatedBy;
            Emails_.TBAXES_ID = Emails.id;
            Emails_.TBAXESTYPECODE = Emails.typeCode;
            Emails_.TBAXESCATEGORYCODE = Emails.categoryCode;
            Emails_.TBAXESSTATUSCODE = Emails.statusCode;
            Emails_.TBAXESCONSENT = Emails.consent;
            Emails_.TBAXESEMAILADDRESS = Emails.emailAddress;
            Emails_.TBAXESETIPO = "PLACEMENT";

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Emails.Add(Emails_);
                DB.SaveChanges();
            }
        }
        public int Phones(Ent_Json.Phone Phones)
        {
            Tab_Amex_Phones Phones_ = new Tab_Amex_Phones();
            Phones_.TBAXPSUPDATEDATE = Phones.updateDate;
            Phones_.TBAXPSUPDATEDBY = Phones.updatedBy;
            Phones_.TBAXPS_ID = Phones.id;
            Phones_.TBAXPSTYPECODE = Phones.typeCode;
            Phones_.TBAXPSCATEGORYCODE = Phones.categoryCode;
            Phones_.TBAXPSSTATUSCODE = Phones.statusCode;
            Phones_.TBAXPSNUMBER = Phones.number;
            Phones_.TBAXPSISDCODE = Phones.isdCode;
            Phones_.TBAXPSEXTENSION = Phones.extension;
            Phones_.TBAXPSLASTUPDATEDATE = Phones.lastUpdateDate;
            Phones_.TBAXPSLASTCONTACTDATE = Phones.lastContactDate;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Phones.Add(Phones_);
                DB.SaveChanges();
            }
            return Phones_.TBAXPSID;
        }
        public void Phones(Ent_Json.Phone Phones, int Id)
        {
            Tab_Amex_Phones Phones_ = new Tab_Amex_Phones();
            Phones_.TBAXPSIDENT = Id;
            Phones_.TBAXPSUPDATEDATE = Phones.updateDate;
            Phones_.TBAXPSUPDATEDBY = Phones.updatedBy;
            Phones_.TBAXPS_ID = Phones.id;
            Phones_.TBAXPSTYPECODE = Phones.typeCode;
            Phones_.TBAXPSCATEGORYCODE = Phones.categoryCode;
            Phones_.TBAXPSSTATUSCODE = Phones.statusCode;
            Phones_.TBAXPSNUMBER = Phones.number;
            Phones_.TBAXPSISDCODE = Phones.isdCode;
            Phones_.TBAXPSEXTENSION = Phones.extension;
            Phones_.TBAXPSLASTUPDATEDATE = Phones.lastUpdateDate;
            Phones_.TBAXPSLASTCONTACTDATE = Phones.lastContactDate;
            Phones_.TBAXPSTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Phones.Add(Phones_);
                DB.SaveChanges();
            }
        }
        public void NationalIds(Ent_Json.NationalId NationalIds, int Id)
        {
            Tab_Amex_NationalIds NationalIds_ = new Tab_Amex_NationalIds();
            NationalIds_.TBAXNSIDENT = Id;
            NationalIds_.TBAXNSUPDATEDATE = NationalIds.updateDate;
            NationalIds_.TBAXNSUPDATEDBY = NationalIds.updatedBy;
            NationalIds_.TBAXNSNATIONALIDNUMBER = NationalIds.nationalIdNumber;
            NationalIds_.TBAXNSNATIONALIDTYPE = NationalIds.nationalIDtype;
            NationalIds_.TBAXNSTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_NationalIds.Add(NationalIds_);
                DB.SaveChanges();
            }
        }
        public int contactInfo(Ent_Json.ContactInfo ContactInfo)
        {
            Tab_Amex_ContactInfo ContactInfo_ = new Tab_Amex_ContactInfo();
            ContactInfo_.TBAXCOUPDATEDATE = ContactInfo.updateDate;
            ContactInfo_.TBAXCOUPDATEDBY = ContactInfo.updatedBy;
            ContactInfo_.TBAXCOACCOUNTNUMBER = ContactInfo.accountNumber;
            ContactInfo_.TBAXCOACCOUNTCATEGORYTYPECODE = ContactInfo.accountCategoryTypeCode;
            ContactInfo_.TBAXCOTYPE = ContactInfo.type;
            ContactInfo_.TBAXCOLASTCONTACTDATE = ContactInfo.lastContactDate;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_ContactInfo.Add(ContactInfo_);
                DB.SaveChanges();
            }
            return ContactInfo_.TBAXCOID;
        }

        public int Employer(Ent_Json.Employer Employer)
        {
            Tab_Amex_Employer Employer_ = new Tab_Amex_Employer();
            Employer_.TBAXERUPDATEDATE = Employer.updateDate;
            Employer_.TBAXERUPDATEDBY = Employer.updatedBy;
            Employer_.TBAXERACCOUNTNUMBER = Employer.accountNumber;
            Employer_.TBAXERNAME = Employer.name;
            //Employer_.TBAXERIDADDRESS = Address_(Employer.address, Employer_.TBAXERID);
            if (Employer.email!=null)
            {
                Employer_.TBAXERIDEMAIL = Emails_(Employer.email);
            }
            //Employer_.TBAXERIDPHONES = Employer.idphones;


            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Employer.Add(Employer_);
                DB.SaveChanges();
            }
            if (Employer.address!=null)
            {
                Address(Employer.address, Employer_.TBAXERID);
            }
            if (Employer.Phones != null)
            {
                for (int i = 0; i < Employer.Phones.Count; i++)
                {
                    if (Employer.Phones[i] != null)
                    {
                        Phones(Employer.Phones[i], Employer_.TBAXERID);
                    }

                }
            }         
            return Employer_.TBAXERID;
        }
        public int RelatedPersonList(Ent_Json.RelatedPerson RelatedPerson)
        {
            Tab_Amex_RelatedPerson RelatedPerson_ = new Tab_Amex_RelatedPerson();
            RelatedPerson_.TBAXRNUPDATEDATE = RelatedPerson.updateDate;
            RelatedPerson_.TBAXRNUPDATEDBY = RelatedPerson.updatedBy;
            RelatedPerson_.TBAXRNACCOUNTNUMBER = RelatedPerson.accountNumber;
            RelatedPerson_.TBAXRNACCOUNTCATEGORYTYPECODE = RelatedPerson.accountCategoryTypeCode;
            //RelatedPerson_.TBAXRNIDRELATEDPERSONLIST = RelatedPerson.idrelatedpersonlist;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_RelatedPerson.Add(RelatedPerson_);
                DB.SaveChanges();
            }

            for (int i = 0; i < RelatedPerson.relatedPersonDetailsList.Count; i++)
            {
                RelatedPersonDetailsList(RelatedPerson.relatedPersonDetailsList[i], RelatedPerson_.TBAXRNID);
            }
            return RelatedPerson_.TBAXRNID;
        }
        public void RelatedPersonDetailsList( Ent_Json.RelatedPersonDetailsList RelatedPersonDetailsList, int id)
        {
            Tab_Amex_RelatedPersonList RelatedPersonDetailsList_ = new Tab_Amex_RelatedPersonList();
            RelatedPersonDetailsList_.TBAXRTUPDATEDATE = RelatedPersonDetailsList.updateDate;
            RelatedPersonDetailsList_.TBAXRTUPDATEDBY = RelatedPersonDetailsList.updatedBy;
            RelatedPersonDetailsList_.TBAXRTSEQNO = RelatedPersonDetailsList.seqNo;
            RelatedPersonDetailsList_.TBAXRTFIRSTNAME = RelatedPersonDetailsList.firstName;
            RelatedPersonDetailsList_.TBAXRTLASTNAME = RelatedPersonDetailsList.lastName;
            RelatedPersonDetailsList_.TBAXRTBIRTHDATE = RelatedPersonDetailsList.birthDate;
            //RelatedPersonDetailsList_.TBAXERIDADDRESS = Address_(RelatedPersonDetailsList.address,id);
            //RelatedPersonDetailsList_.TBAXERIDPHONES = RelatedPersonDetailsList.idphones;
            //RelatedPersonDetailsList_.TBAXERIDNATIONALID = RelatedPersonDetailsList.idnationalid;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_RelatedPersonList.Add(RelatedPersonDetailsList_);
                DB.SaveChanges();
            }
            Address(RelatedPersonDetailsList.address, RelatedPersonDetailsList_.TBAXRTID);
            for (int i = 0; i < RelatedPersonDetailsList.phoneList.Count; i++)
            {
                Phones(RelatedPersonDetailsList.phoneList[i], RelatedPersonDetailsList_.TBAXRTID);
            }
            for (int i = 0; i < RelatedPersonDetailsList.nationalId.Count; i++)
            {
                NationalIds(RelatedPersonDetailsList.nationalId[i], RelatedPersonDetailsList_.TBAXRTID);
            }
        }
        public int AccountDetails(Ent_Json.AccountDetails AccountDetails)
        {
            Tab_Amex_AccountDetails AccountDetails_ = new Tab_Amex_AccountDetails();
            AccountDetails_.TBAXASUPDATEDATE = AccountDetails.updateDate;
            AccountDetails_.TBAXASUPDATEDBY = AccountDetails.updatedBy;
            AccountDetails_.TBAXASACCOUNTNUMBER = AccountDetails.accountNumber;
            AccountDetails_.TBAXASACCOUNTCATEGORYTYPECODE = AccountDetails.accountCategoryTypeCode;
            AccountDetails_.TBAXASACCOUNTMARKETCODE = AccountDetails.accountMarketCode;
            AccountDetails_.TBAXASCUSTOMERID = AccountDetails.customerId;
            AccountDetails_.TBAXASCANCELCODE = AccountDetails.cancelCode;
            AccountDetails_.TBAXASCRDATE = AccountDetails.crDate;
            AccountDetails_.TBAXASCANCELLATIONDATE = AccountDetails.cancellationDate;
            AccountDetails_.TBAXASCARDOPENDATE = AccountDetails.cardOpenDate;
            AccountDetails_.TBAXASCORPORATEID = AccountDetails.corporateId;
            AccountDetails_.TBAXASMEMBERSHIPREWARDS = AccountDetails.membershipRewards;
            AccountDetails_.TBAXASLASTCHARGEACTIVITY = AccountDetails.lastChargeActivity;
            AccountDetails_.TBAXASCOMPANYNAME = AccountDetails.companyName;
            AccountDetails_.TBAXASPRODUCTCODE = AccountDetails.productCode;
            AccountDetails_.TBAXASTAXIDFIELDEXT = AccountDetails.taxidfieldext;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_AccountDetails.Add(AccountDetails_);
                DB.SaveChanges();
            }

           
            return AccountDetails_.TBAXASID;
        }
        public int AttorneyDetails(Ent_Json.AttorneyDetails AttorneyDetails)
        {
            Tab_Amex_AttorneyDetails AttorneyDetails_ = new Tab_Amex_AttorneyDetails();
            AttorneyDetails_.TBAXASUPDATEDATE = AttorneyDetails.updateDate;
            AttorneyDetails_.TBAXAS_ID = AttorneyDetails.id;
            AttorneyDetails_.TBAXASACCOUNTNUMBER = AttorneyDetails.accountNumber;
            AttorneyDetails_.TBAXASACCOUNTCATEGORYTYPECODE = AttorneyDetails.accountCategoryTypeCode;
            AttorneyDetails_.TBAXASTYPECODE = AttorneyDetails.typeCode;
            AttorneyDetails_.TBAXASFIRSTNAME = AttorneyDetails.firstName;
            AttorneyDetails_.TBAXASLASTNAME = AttorneyDetails.lastName;
            AttorneyDetails_.TBAXASMIDDLENAME = AttorneyDetails.middleName;
            AttorneyDetails_.TBAXASFIRMNAME = AttorneyDetails.firmName;
            AttorneyDetails_.TBAXASEMAILADDRESS1 = AttorneyDetails.emailAddress1;
            AttorneyDetails_.TBAXASEMAILADDRESS2 = AttorneyDetails.emailAddress2;
            AttorneyDetails_.TBAXASCITY = AttorneyDetails.city;
            AttorneyDetails_.TBAXASSTATE = AttorneyDetails.state;
            AttorneyDetails_.TBAXASPOSTALCODE = AttorneyDetails.postalCode;
            AttorneyDetails_.TBAXASBUSINESSPHONE = AttorneyDetails.businessPhone;
            AttorneyDetails_.TBAXASMOBILEPHONE1 = AttorneyDetails.mobilePhone1;
            AttorneyDetails_.TBAXASMOBILEPHONE2 = AttorneyDetails.mobilePhone2;
            AttorneyDetails_.TBAXASEXTENSIONATTRIBUTES = AttorneyDetails.extensionAttributes;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_AttorneyDetails.Add(AttorneyDetails_);
                DB.SaveChanges();
            }

            return AttorneyDetails_.TBAXASID;
        }
        public int ProductDetails(Ent_Json.ProductDetails ProductDetails)
        {
            Tab_Amex_ProductDetails ProductDetails_ = new Tab_Amex_ProductDetails();
            ProductDetails_.TBAXPSUPDATEDATE = ProductDetails.updateDate;
            ProductDetails_.TBAXPSUPDATEDBY = ProductDetails.updatedBy;
            ProductDetails_.TBAXPSACCOUNTNUMBER = ProductDetails.accountNumber;
            ProductDetails_.TBAXPSACCOUNTCATEGORYTYPECODE = ProductDetails.accountCategoryTypeCode;
            ProductDetails_.TBAXPSAMEXPRODUCTCODE = ProductDetails.amexProductCode;
            ProductDetails_.TBAXPSPRODUCTTYPE = ProductDetails.productType;
            ProductDetails_.TBAXPSFULLPRODUCTDESCRIPTION = ProductDetails.fullProductDescription;
            ProductDetails_.TBAXPSTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_ProductDetails.Add(ProductDetails_);
                DB.SaveChanges();
            }
            return ProductDetails_.TBAXPSID;
        }

        public int CustomerFinancial(Ent_Json.CustomerFinancial CustomerFinancial)
        {
            Tab_Amex_CustomerFinancial CustomerFinancial_ = new Tab_Amex_CustomerFinancial();
            CustomerFinancial_.TBAXCLUPDATEDATE = CustomerFinancial.updateDate;
            CustomerFinancial_.TBAXCLUPDATEDBY = CustomerFinancial.updatedBy;
            CustomerFinancial_.TBAXCL_ID = CustomerFinancial.id;
            CustomerFinancial_.TBAXCLACCOUNTNUMBER = CustomerFinancial.accountNumber;
            CustomerFinancial_.TBAXCLACCOUNTCATEGORYTYPECODE = CustomerFinancial.accountCategoryTypeCode;
            CustomerFinancial_.TBAXCLLARGEORMIDDLEMARKET = CustomerFinancial.largeOrMiddleMarket;
            CustomerFinancial_.TBAXCLCYCLECUT = CustomerFinancial.cycleCut;
            CustomerFinancial_.TBAXCLWAIVERORGUARANTEED = CustomerFinancial.waiverOrGuaranteed;
            CustomerFinancial_.TBAXCLNUMBEROFTIMESPASTDUE60DAYS = CustomerFinancial.numberOfTimesPastDue60Days;
            CustomerFinancial_.TBAXCLLIABILITY = CustomerFinancial.liability;
            CustomerFinancial_.TBAXCLTOTALEXPOSURE = Convert.ToDecimal(CustomerFinancial.totalExposure);
            CustomerFinancial_.TBAXCLLASTPAYMENTDATE = CustomerFinancial.lastPaymentDate;
            CustomerFinancial_.TBAXCLCREDITBALANCE = Convert.ToDecimal(CustomerFinancial.creditBalance);
            CustomerFinancial_.TBAXCLMINIMUMAMOUNTDUE = Convert.ToDecimal(CustomerFinancial.minimumAmountDue);
            CustomerFinancial_.TBAXCLUNBILLEDAMOUNTDUE = Convert.ToDecimal(CustomerFinancial.unbilledAmountDue);
            CustomerFinancial_.TBAXCLCURRENTAMOUNTDUE = Convert.ToDecimal(CustomerFinancial.currentAmountDue);
            CustomerFinancial_.TBAXCLAMOUNTDUE30DAYS = Convert.ToDecimal(CustomerFinancial.amountDue30Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE60DAYS = Convert.ToDecimal(CustomerFinancial.amountDue60Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE90DAYS = Convert.ToDecimal(CustomerFinancial.amountDue90Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE120DAYS = Convert.ToDecimal(CustomerFinancial.amountDue120Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE150DAYS = Convert.ToDecimal(CustomerFinancial.amountDue150Days);
            CustomerFinancial_.TBAXCLAMOUNTDUE180DAYS = Convert.ToDecimal(CustomerFinancial.amountDue180Days);
            CustomerFinancial_.TBAXCLTOTALAMOUNTDUEINUSD = Convert.ToDecimal(CustomerFinancial.totalAmountDueInUSD);
            CustomerFinancial_.TBAXCLUNBILLEDAMOUNTDUEINUSD = Convert.ToDecimal(CustomerFinancial.unbilledAmountDueInUSD);
            CustomerFinancial_.TBAXCLCURRENTAMOUNTDUEINUSD = Convert.ToDecimal(CustomerFinancial.currentAmountDueInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE30DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue30DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE60DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue60DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE90DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue90DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE120DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue120DaysInUSD);
            CustomerFinancial_.TBAXCLAMOUNTDUE150DAYSINUSD = Convert.ToDecimal(CustomerFinancial.amountDue150DaysInUSD);
            CustomerFinancial_.TBAXCLCREDITINUSD = CustomerFinancial.creditInUSD;
            CustomerFinancial_.TBAXCLLEGACYCODE = CustomerFinancial.legacyCode;
            CustomerFinancial_.TBAXCLTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CustomerFinancial.Add(CustomerFinancial_);
                DB.SaveChanges();
            }
            return CustomerFinancial_.TBAXCLID;
        }

        public int FinancialRisk(Ent_Json.FinancialRisk FinancialRisk)
        {
            Tab_Amex_FinancialRisk FinancialRisk_ = new Tab_Amex_FinancialRisk();
            FinancialRisk_.TBAXFKUPDATEDATE = FinancialRisk.updateDate;
            FinancialRisk_.TBAXFKUPDATEDBY = FinancialRisk.updatedBy;
            FinancialRisk_.TBAXFKACCOUNTNUMBER = FinancialRisk.accountNumber;
            FinancialRisk_.TBAXFKACCOUNTCATEGORYTYPECODE = FinancialRisk.accountCategoryTypeCode;
            FinancialRisk_.TBAXFKLENDINGAGECODE = FinancialRisk.lendingAgeCode;
            FinancialRisk_.TBAXFKCHARGETOTALBALANCE = Convert.ToDecimal(FinancialRisk.chargeTotalBalance);
            FinancialRisk_.TBAXFKLENDINGTOTALBALANCE = Convert.ToDecimal(FinancialRisk.lendingTotalBalance);
            FinancialRisk_.TBAXFKCUSTOMEREXPOSURECCSG = Convert.ToDecimal(FinancialRisk.customerExposureCcsg);
            FinancialRisk_.TBAXFKCUSTOMEREXPOSUREOPEN = Convert.ToDecimal(FinancialRisk.customerExposureOpen);
            FinancialRisk_.TBAXFKTOTALEXPOSURE = Convert.ToDecimal(FinancialRisk.totalExposure);
            FinancialRisk_.TBAXFKLASTBALANCEDATE = FinancialRisk.lastBalanceDate;
            FinancialRisk_.TBAXFKCYCLECUTDATE = FinancialRisk.cycleCutDate;
            FinancialRisk_.TBAXFKCYCLECUTDATE2 = FinancialRisk.cycleCutDate2;
            FinancialRisk_.TBAXFKDUEDATE = FinancialRisk.dueDate;
            FinancialRisk_.TBAXFKDUEDATE2 = FinancialRisk.dueDate2;
            FinancialRisk_.TBAXFKBANKTYPE = FinancialRisk.bankType;
            FinancialRisk_.TBAXFKABILITY = FinancialRisk.ability;
            FinancialRisk_.TBAXFKMINDUEINDICATOR = Convert.ToDecimal(FinancialRisk.minDueIndicator);
            FinancialRisk_.TBAXFKCURRENTCOMBINEDFEEANDINTEREST = Convert.ToDecimal(FinancialRisk.currentCombinedFeeAndInterest);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST30DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest30Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST60DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest60Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST90DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest90Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST120DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest120Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST150DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest150Days);
            FinancialRisk_.TBAXFKCOMBINEDFEESWITHINTEREST180DAYS = Convert.ToDecimal(FinancialRisk.combinedFeesWithInterest180Days);
            FinancialRisk_.TBAXFKOLDESTAGEMINDUEBUCKET = Convert.ToDecimal(FinancialRisk.oldestAgeMinDueBucket);
            FinancialRisk_.TBAXFKTOTALCUSTOMERLEVELMINDUECCSG = Convert.ToDecimal(FinancialRisk.totalCustomerLevelMinDueCcsg);
            FinancialRisk_.TBAXFKTOTALCUSTOMERLEVELMINDUEOPEN = Convert.ToDecimal(FinancialRisk.totalCustomerLevelMinDueOpen);
            FinancialRisk_.TBAXFKTOTALCUSTOMERLEVELMINDUE = Convert.ToDecimal(FinancialRisk.totalCustomerLevelMinDue);
            FinancialRisk_.TBAXFKTOTALCOURTCOSTSREIMBURSEDTOPREVIOUSAGENCY = Convert.ToDecimal(FinancialRisk.totalCourtCostsReimbursedToPreviousAgency);
            FinancialRisk_.TBAXFKTIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_FinancialRisk.Add(FinancialRisk_);
                DB.SaveChanges();
            }
            return FinancialRisk_.TBAXFKID;
        }
        public int PaymentInfo(Ent_Json.PaymentInfo PaymentInfo)
        {
            Tab_Amex_PaymentInfo PaymentInfo_ = new Tab_Amex_PaymentInfo();
            PaymentInfo_.TBAXPOUPDATEDATE = PaymentInfo.updateDate;
            PaymentInfo_.TBAXPOUPDATEDBY = PaymentInfo.updatedBy;
            PaymentInfo_.TBAXPOACCOUNTNUMBER = PaymentInfo.accountNumber;
            PaymentInfo_.TBAXPOACCOUNTCATEGORYTYPECODE = PaymentInfo.accountCategoryTypeCode;
            PaymentInfo_.TBAXPOPAYMENTMODE = PaymentInfo.paymentMode;
            PaymentInfo_.TBAXPODDANUMBER = PaymentInfo.ddaNumber;
            PaymentInfo_.TBAXPOROUTINGNUMBER = PaymentInfo.routingNumber;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_PaymentInfo.Add(PaymentInfo_);
                DB.SaveChanges();
            }
            return PaymentInfo_.TBAXPOID;
        }
        public int CreditRiskInfo(Ent_Json.CreditRiskInfo CreditRiskInfo)
        {
            Tab_Amex_CreditRiskInfo CreditRiskInfo_ = new Tab_Amex_CreditRiskInfo();
            CreditRiskInfo_.TBAXCOUPDATEDATE = CreditRiskInfo.updateDate;
            CreditRiskInfo_.TBAXCOUPDATEDBY = CreditRiskInfo.updatedBy;
            CreditRiskInfo_.TBAXCOACCOUNTNUMBER = CreditRiskInfo.accountNumber;
            CreditRiskInfo_.TBAXCOACCOUNTCATEGORYTYPECODE = CreditRiskInfo.accountCategoryTypeCode;
            CreditRiskInfo_.TBAXCOMAJORDEROGS = CreditRiskInfo.majorDerogs;
            CreditRiskInfo_.TBAXCOMINORDEROGS = CreditRiskInfo.minorDerogs;
            CreditRiskInfo_.TBAXCOSATTRADES = CreditRiskInfo.satTrades;
            CreditRiskInfo_.TBAXCOJUDGEMENTS = CreditRiskInfo.judgements;
            CreditRiskInfo_.TBAXCOMONTHLYMORTGAGE = Convert.ToDecimal(CreditRiskInfo.monthlyMortgage);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CreditRiskInfo.Add(CreditRiskInfo_);
                DB.SaveChanges();
            }
            return CreditRiskInfo_.TBAXCOID;
        }

        public int CapInfo(Ent_Json.CapInfo CapInfo)
        {
            Tab_Amex_CapInfo CapInfo_ = new Tab_Amex_CapInfo();
            CapInfo_.TBAXCOUPDATEDATE = CapInfo.updateDate;
            CapInfo_.TBAXCOUPDATEDBY = CapInfo.updatedBy;
            CapInfo_.TBAXCOACCOUNTNUMBER = CapInfo.accountNumber;
            CapInfo_.TBAXCOACCOUNTCATEGORYTYPECODE = CapInfo.accountCategoryTypeCode;
            CapInfo_.TBAXCOCAPMEMO = CapInfo.capMemo;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CapInfo.Add(CapInfo_);
                DB.SaveChanges();
            }
            return CapInfo_.TBAXCOID;
        }
        public int Legal(Ent_Json.Legal Legal)
        {
            Tab_Amex_Legal Legal_ = new Tab_Amex_Legal();
            Legal_.TBAXLLUPDATEDATE = Legal.updateDate;
            Legal_.TBAXLL_ID = Legal.id;
            Legal_.TBAXLLACCOUNTNUMBER = Legal.accountNumber;
            Legal_.TBAXLLACCOUNTCATEGORYTYPECODE = Legal.accountCategoryTypeCode;
            Legal_.TBAXLLCUSTOMERID = Legal.customerId;
            Legal_.TBAXLLCOURTCODE = Legal.courtCode;
            Legal_.TBAXLLLEGALFILEDATE = Legal.legalFileDate;
            Legal_.TBAXLLATTORNEYOFRECORD = Legal.attorneyOfRecord;
            Legal_.TBAXLLLEGALSERVICEDATE = Legal.legalServiceDate;
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Legal.Add(Legal_);
                DB.SaveChanges();
            }
            return Legal_.TBAXLLID;
        }
        public int CollectionInfo(Ent_Json.CollectionInfo CollectionInfo)
        {
            Tab_Amex_CollectionInfo CollectionInfo_ = new Tab_Amex_CollectionInfo();
            CollectionInfo_.TBAXCOUPDATEDATE = CollectionInfo.updateDate;
            CollectionInfo_.TBAXCOUPDATEDBY = CollectionInfo.updatedBy;
            CollectionInfo_.TBAXCOACCOUNTNUMBER = CollectionInfo.accountNumber;
            CollectionInfo_.TBAXCOACCOUNTCATEGORYTYPECODE = CollectionInfo.accountCategoryTypeCode;
            CollectionInfo_.TBAXCOACTUALSETTLEMENTAMOUNT = Convert.ToDecimal(CollectionInfo.actualSettlementAmount);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CollectionInfo.Add(CollectionInfo_);
                DB.SaveChanges();
            }
            return CollectionInfo_.TBAXCOID;
        }
        public int RiskScore(Ent_Json.RiskScore RiskScore)
        {
            Tab_Amex_RiskScore RiskScore_ = new Tab_Amex_RiskScore();
            RiskScore_.TBAXREUPDATEDATE = RiskScore.updateDate;
            RiskScore_.TBAXREUPDATEDBY = RiskScore.updatedBy;
            RiskScore_.TBAXREACCOUNTNUMBER = RiskScore.accountNumber;
            RiskScore_.TBAXREACCOUNTCATEGORYTYPECODE = RiskScore.accountCategoryTypeCode;
            RiskScore_.TBAXREDEBTTOVALUERATIO = Convert.ToDecimal( RiskScore.debtToValueRatio);
            RiskScore_.TBAXRECUSTOMERLEVELSCOREFORCHARGEANDLENDING = Convert.ToDecimal(RiskScore.customerLevelScoreForChargeAndLending);
            RiskScore_.TBAXRELENDINGPAYTOCURRRENTSCORE = Convert.ToInt32(RiskScore.lendingPayToCurrrentScore);
            RiskScore_.TBAXREPROBSCORE = RiskScore.probScore;
            RiskScore_.TBAXRETIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_RiskScore.Add(RiskScore_);
                DB.SaveChanges();
            }
            return RiskScore_.TBAXREID;
        }
        public int RegulatoryChange(Ent_Json.RegulatoryChange RegulatoryChange)
        {
            Tab_Amex_RegulatoryChange RegulatoryChange_ = new Tab_Amex_RegulatoryChange();
            RegulatoryChange_.TBAXREUPDATEDATE = RegulatoryChange.updateDate;
            RegulatoryChange_.TBAXREUPDATEDBY = RegulatoryChange.updatedBy;
            RegulatoryChange_.TBAXREACCOUNTNUMBER = RegulatoryChange.accountNumber;
            RegulatoryChange_.TBAXREACCOUNTCATEGORYTYPECODE = RegulatoryChange.accountCategoryTypeCode;
            RegulatoryChange_.TBAXREFINALDEMANDLETTERDATE = RegulatoryChange.finalDemandLetterDate;
            RegulatoryChange_.TBAXRETOTALINTEREST = Convert.ToDecimal(RegulatoryChange.totalInterest);
            RegulatoryChange_.TBAXRETOTALNONINTERESTCHARGES = Convert.ToDecimal(RegulatoryChange.totalNonInterestCharges);
            RegulatoryChange_.TBAXRETOTALPAYMENTS = Convert.ToDecimal(RegulatoryChange.totalPayments);

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_RegulatoryChange.Add(RegulatoryChange_);
                DB.SaveChanges();
            }
            return RegulatoryChange_.TBAXREID;
        }
        public int Settlement(Ent_Json.Settlement Settlement)
        {
            Tab_Amex_Settlement Settlement_ = new Tab_Amex_Settlement();
            Settlement_.TBAXSTUPDATEDATE = Settlement.updateDate;
            Settlement_.TBAXSTACCOUNTNUMBER = Settlement.accountNumber;
            Settlement_.TBAXSTACCOUNTCATEGORYTYPECODE = Settlement.accountCategoryTypeCode;
            Settlement_.TBAXSTSETTLEMENTAGREEMENTDATE = Settlement.settlementAgreementDate;
            Settlement_.TBAXSTSETTLEMENTEXPIRATIONDATE = Settlement.settlementExpirationDate;
            Settlement_.TBAXSTAGREEDSETTLEMENTAMOUNT = Convert.ToDecimal(Settlement.agreedSettlementAmount);
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Settlement.Add(Settlement_);
                DB.SaveChanges();
            }
            return Settlement_.TBAXSTID;
        }
        public int StrategyInfo(Ent_Json.StrategyInfo StrategyInfo)
        {
            Tab_Amex_StrategyInfo StrategyInfo_ = new Tab_Amex_StrategyInfo();
            StrategyInfo_.TBAXSOUPDATEDATE = StrategyInfo.updateDate;
            StrategyInfo_.TBAXSOUPDATEDBY = StrategyInfo.updatedBy;
            StrategyInfo_.TBAXSOACCOUNTNUMBER = StrategyInfo.accountNumber;
            StrategyInfo_.TBAXSOACCOUNTCATEGORYTYPECODE = StrategyInfo.accountCategoryTypeCode;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR1 = StrategyInfo.strategyIndicator1;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR2 = StrategyInfo.strategyIndicator2;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR3 = StrategyInfo.strategyIndicator3;
            StrategyInfo_.TBAXSOSTRATEGYINDICATOR4 = StrategyInfo.strategyIndicator4;
            StrategyInfo_.TBAXSONOOFCCSGCHARGECARDSCUSTOMERHAS = StrategyInfo.noOfCcsgChargeCardsCustomerHas;
            StrategyInfo_.TBAXSONOOFCCSGLENDINGCARDSCUSTOMERHAS = StrategyInfo.noOfCcsgLendingCardsCustomerHas;
            StrategyInfo_.TBAXSOSEGMENTID1 = StrategyInfo.segmentId1;
            StrategyInfo_.TBAXSOSEGMENTID2 = StrategyInfo.segmentId2;
            StrategyInfo_.TBAXSOSEGMENTID3 = StrategyInfo.segmentId3;
            StrategyInfo_.TBAXSOSEGMENTID4 = StrategyInfo.segmentId4;
            StrategyInfo_.TBAXSONOOFOPENCARDSCUSTOMERHAS = StrategyInfo.noOfOpenCardsCustomerHas;
            StrategyInfo_.TBAXSOINDICATORFORLOCBALANCE = StrategyInfo.indicatorForLocBalance;
            StrategyInfo_.TBAXSOREAGEINDICATOR = StrategyInfo.reAgeIndicator;
            StrategyInfo_.TBAXSOCAREELIGIBILITY = StrategyInfo.careEligibility;
            StrategyInfo_.TBAXSOWRITTENOFFINDICATOR = StrategyInfo.writtenOffIndicator;
            StrategyInfo_.TBAXSOLENDINGINCHARGE = StrategyInfo.lendingInCharge;
            StrategyInfo_.TBAXSOSPEEDTOPAYMODEL = StrategyInfo.speedToPayModel;
            StrategyInfo_.TBAXSOTIPO = "PLACEMENT";

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_StrategyInfo.Add(StrategyInfo_);
                DB.SaveChanges();
            }
            return StrategyInfo_.TBAXSOID;
        }
        public int DisputeDetails(Ent_Json.DisputeDetails DisputeDetails)
        {
            Tab_Amex_DisputeDetails DisputeDetails_ = new Tab_Amex_DisputeDetails();
            DisputeDetails_.TBAXDSUPDATEDATE = DisputeDetails.updateDate;
            DisputeDetails_.TBAXDSUPDATEDBY = DisputeDetails.updatedBy;
            DisputeDetails_.TBAXDSACCOUNTNUMBER = DisputeDetails.accountNumber;
            DisputeDetails_.TBAXDSACCOUNTCATEGORYTYPECODE = DisputeDetails.accountCategoryTypeCode;
            DisputeDetails_.TBAXDSDISPUTETYPE = DisputeDetails.disputeType;
            DisputeDetails_.TBAXDSDISPUTEAMOUNT = Convert.ToDecimal(DisputeDetails.disputeAmount);
            DisputeDetails_.TBAXDSDISPUTEDATE = DisputeDetails.disputeDate;
            DisputeDetails_.TBAXDSDISPUTEOUTCOME = DisputeDetails.disputeOutcome;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_DisputeDetails.Add(DisputeDetails_);
                DB.SaveChanges();
            }
            return DisputeDetails_.TBAXDSID;
        }
        public int Account(Ent_Json.Account Account)
        {
            Tab_Amex_Account Account_ = new Tab_Amex_Account();
            Account_.TBAXATUPDATEDATE = Account.updateDate;
            Account_.TBAXATUPDATEDBY = Account.updatedBy;
            Account_.TBAXATACCOUNTNUMBER = Account.accountNumber;
            Account_.TBAXATACCOUNTCATEGORYTYPECODE = Account.accountCategoryTypeCode;
            Account_.TBAXATCOUNTRYISOALPHA2CODE = Account.countryIsoAlpha2Code;
            Account_.TBAXATPRODUCTCODE = Account.productCode;
            Account_.TBAXATCHARGEOFFREASONCODE = Account.chargeOffReasonCode;
            Account_.TBAXATPLACEMENTBALANCE = Convert.ToDecimal(Account.placementBalance);
            Account_.TBAXATCURRENTBALANCE = Convert.ToDecimal(Account.currentBalance);
            Account_.TBAXATWRITEOFFAMOUNT = Convert.ToDecimal(Account.writeOffAmount);
            Account_.TBAXATACCOUNTSTATUS = Account.accountStatus;
            Account_.TBAXATWRITEOFFDATE = Account.writeOffDate;
            Account_.TBAXATORIGINALPLACEMENTDATE = Account.originalPlacementDate;
            Account_.TBAXATACCOUNTRECEIVEDATE = Account.accountReceiveDate;
            Account_.TBAXATINTERNALRECOVERERCODE = Account.internalRecovererCode;
            Account_.TBAXATPLACEMENTLEVELCODE = Account.placementLevelCode;
            Account_.TBAXATSTAMPEDRATE1 = Convert.ToDecimal(Account.stampedRate1);
            Account_.TBAXATSTAMPEDRATE2 = Convert.ToDecimal(Account.stampedRate2);
            Account_.TBAXATSTAMPEDRATE3 = Convert.ToDecimal(Account.stampedRate3);
            Account_.TBAXATSTAMPEDFXRATE = Convert.ToDecimal(Account.stampedFxRate);
            Account_.TBAXATCOMMISSIONRATE = Convert.ToDecimal(Account.commissionRate);
            Account_.TBAXATAGENCYASSIGNMENTDATE = Account.agencyAssignmentDate;
            Account_.TBAXATLASTSTATUSCHANGEDATE = Account.lastStatusChangeDate;
            Account_.TBAXATAGENCYRECALLDATE = Account.agencyRecallDate;
            Account_.TBAXATCURRENTAGENCYID = Account.currentAgencyId;
            Account_.TBAXATTIPO = "PLACEMENT";

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_Account.Add(Account_);
                DB.SaveChanges();
            }
            return Account_.TBAXATID;
        }
        public int CollectionScore(Ent_Json.CollectionScore CollectionScore)
        {
            Tab_Amex_CollectionScore CollectionScore_ = new Tab_Amex_CollectionScore();
            CollectionScore_.TBAXCEUPDATEDATE = CollectionScore.updateDate;
            CollectionScore_.TBAXCEUPDATEDBY = CollectionScore.updatedBy;
            CollectionScore_.TBAXCE_ID = CollectionScore.id;
            CollectionScore_.TBAXCEACCOUNTNUMBER = CollectionScore.accountNumber;
            CollectionScore_.TBAXCEACCOUNTCATEGORYTYPECODE = CollectionScore.accountCategoryTypeCode;
            CollectionScore_.TBAXCECOLLECTIBILITYSCORE = CollectionScore.collectibilityScore;
            CollectionScore_.TBAXCERECOVERYSCORE = CollectionScore.recoveryScore;
            CollectionScore_.TBAXCEBANKRUPTCYSCORE = CollectionScore.bankruptcyScore;
            CollectionScore_.TBAXCEMARKETRECOVERYSCORE = CollectionScore.marketRecoveryScore;
            CollectionScore_.TBAXCERETURNMETRICSCORE = CollectionScore.returnMetricScore;
            CollectionScore_.TBAXCEFICOSCORE = Convert.ToInt32(CollectionScore.ficoScore);
            CollectionScore_.TBAXCETIPO = "PLACEMENT";
            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CollectionScore.Add(CollectionScore_);
                DB.SaveChanges();
            }
            return CollectionScore_.TBAXCEID;
        }
        public int CustomerAdditionalDetails(Ent_Json.CustomerAdditionalDetails CustomerAdditionalDetails)
        {
            Tab_Amex_CustomerAdditionalDetails CustomerAdditionalDetails_ = new Tab_Amex_CustomerAdditionalDetails();
            CustomerAdditionalDetails_.TBAXCSUPDATEDATE = CustomerAdditionalDetails.updateDate;
            CustomerAdditionalDetails_.TBAXCSUPDATEDBY = CustomerAdditionalDetails.updatedBy;
            CustomerAdditionalDetails_.TBAXCS_ID = CustomerAdditionalDetails.id;
            CustomerAdditionalDetails_.TBAXCSACCOUNTNUMBER = CustomerAdditionalDetails.accountNumber;
            CustomerAdditionalDetails_.TBAXCSACCOUNTCATEGORYTYPECODE = CustomerAdditionalDetails.accountCategoryTypeCode;
            CustomerAdditionalDetails_.TBAXCSACCOUNTMARKETCODE = CustomerAdditionalDetails.accountMarketCode;
            CustomerAdditionalDetails_.TBAXCSCOUNTRYCODE = CustomerAdditionalDetails.countryCode;
            CustomerAdditionalDetails_.TBAXCSCARDMEMBERTYPE = CustomerAdditionalDetails.cardMemberType;
            CustomerAdditionalDetails_.TBAXCSDECEASEDDATE = CustomerAdditionalDetails.deceasedDate;
            CustomerAdditionalDetails_.TBAXCSMONTHLYINCOME = Convert.ToDecimal(CustomerAdditionalDetails.monthlyIncome);
            CustomerAdditionalDetails_.TBAXCSRENTOROWN = CustomerAdditionalDetails.rentOrOwn;

            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_CustomerAdditionalDetails.Add(CustomerAdditionalDetails_);
                DB.SaveChanges();
            }
            return CustomerAdditionalDetails_.TBAXCSID;
        }
        public int DeceasedDetails(Ent_Json.DeceasedDetails DeceasedDetails)
        {
            Tab_Amex_DeceasedDetails DeceasedDetails_ = new Tab_Amex_DeceasedDetails();
            DeceasedDetails_.TBAXDSUPDATEDATE = DeceasedDetails.updateDate;
            DeceasedDetails_.TBAXDSUPDATEDBY = DeceasedDetails.updatedBy;
            DeceasedDetails_.TBAXDS_ID = DeceasedDetails.id;
            DeceasedDetails_.TBAXDSACCOUNTNUMBER = DeceasedDetails.accountNumber;
            DeceasedDetails_.TBAXDSACCOUNTCATEGORYTYPECODE = DeceasedDetails.accountCategoryTypeCode;
            DeceasedDetails_.TBAXDSATTORNEYNAME = DeceasedDetails.attorneyName;
            DeceasedDetails_.TBAXDSATTRONEYADDRESS = DeceasedDetails.attroneyAddress;
            DeceasedDetails_.TBAXDSEXECUTORADDRESS2 = DeceasedDetails.executorAddress2;
            DeceasedDetails_.TBAXDSEXECUTORCITY = DeceasedDetails.executorCity;
            DeceasedDetails_.TBAXDSEXECUTORSTATE = DeceasedDetails.executorState;
            DeceasedDetails_.TBAXDSEXECUTORZIP = DeceasedDetails.executorZip;
            DeceasedDetails_.TBAXDSEXECUTORPHONE = DeceasedDetails.executorPhone;


            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_DeceasedDetails.Add(DeceasedDetails_);
                DB.SaveChanges();
            }
            return DeceasedDetails_.TBAXDSID;
        }
        public int AgencyAssignment(Ent_Json.AgencyAssignment AgencyAssignment)
        {
            Tab_Amex_AgencyAssignment AgencyAssignment_ = new Tab_Amex_AgencyAssignment();
            AgencyAssignment_.TBAXATUPDATEDATE = AgencyAssignment.updateDate;
            AgencyAssignment_.TBAXATUPDATEDBY = AgencyAssignment.updatedBy;
            AgencyAssignment_.TBAXATCASEID = Convert.ToInt32( AgencyAssignment.caseId);
            AgencyAssignment_.TBAXATAGENCYID = AgencyAssignment.agencyId;
            AgencyAssignment_.TBAXATACCOUNTNUMBER = AgencyAssignment.accountNumber;
            AgencyAssignment_.TBAXATACCOUNTCATEGORYTYPECODE = AgencyAssignment.accountCategoryTypeCode;
            AgencyAssignment_.TBAXATACCOUNTSTATUSCODE = AgencyAssignment.accountStatusCode;
            AgencyAssignment_.TBAXATCOUNTRYCODE = AgencyAssignment.countryCode;
            AgencyAssignment_.TBAXATAGENCYASSIGNMENTSTATUSCODE = AgencyAssignment.agencyAssignmentStatusCode;
            AgencyAssignment_.TBAXATFILETRANSMISSIONSTATUSCODE = AgencyAssignment.fileTransmissionStatusCode;
            AgencyAssignment_.TBAXATACCOUNTINSERTTIMESTAMP = AgencyAssignment.accountInsertTimeStamp;
            AgencyAssignment_.TBAXATAGENCYASSIGNMENTDATE = AgencyAssignment.agencyAssignmentDate;
            AgencyAssignment_.TBAXATAGENCYRECALLDATE = AgencyAssignment.agencyRecallDate;
            AgencyAssignment_.TBAXATBALANCEAMOUNT = Convert.ToDecimal( AgencyAssignment.balanceAmount);
            AgencyAssignment_.TBAXATNOOFDAYS = AgencyAssignment.noOfDays;
            AgencyAssignment_.TBAXATPREVIOUSAGENCYID = AgencyAssignment.previousAgencyId;
            AgencyAssignment_.TBAXATCOMMISSIONRATE = Convert.ToDecimal(AgencyAssignment.commissionRate);
            AgencyAssignment_.TBAXATINTERNALAMEXRECOVERERCODE = AgencyAssignment.internalAmexRecovererCode;
            


            using (CYBEREntities DB = new CYBEREntities())
            {
                DB.Tab_Amex_AgencyAssignment.Add(AgencyAssignment_);
                DB.SaveChanges();
            }
            return AgencyAssignment_.TBAXATID;
        }

       
    }
}
