using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Ent_Json_Update : Ent_Json
    {
        public class RootObject
        {
            public DateTime? updateDate { get; set; } = null;
            public string updateBy { get; set; }
            public Json.Header header { get; set; }
            public List<AccountList> accountList { get; set; }
            public List<ActionsHistoryList> actionsHistoryList { get; set; }
            public List<AccountDetailsList> accountDetailsList { get; set; }
            public List<AdditionalCmSpendInfoList> additionalCmSpendInfoList { get; set; }            
            public List<AgencyInfoList> agecyInfoList { get; set; }
            public List<AgencyAssignmentList> AgencyAssignmentList { get; set; }
            public List<Json.AttorneyDetails> attorneyDetails { get; set; }
            public List<BankListList> bankListList { get; set; }
            public List<BankruptcyDetailsList> bankruptcyDetailsList { get; set; }
            public List<CapInfoList> capInfoList { get; set; }
            public List<CaseList> caseList { get; set; }
            public List<CmxTradeDemographicsList> cmxTradeDemographicsList { get; set; }
            public List<CollectionInfoList> collectionInfoList { get; set; }
            public List<CollectionScoreList> collectionScoreList { get; set; }
            public List<ContactInfoList> contactInfoList { get; set; }
            public List<CreditRiskInfoList> creditRiskInfoList { get; set; }
            public List<CustomerFinancialList> customerFinancialList { get; set; }
            public List<CustomerAdditionalDetailsList> customerAdditionalDetailsList { get; set; }
            public List<CustomerDetailsList> customerDetailsList { get; set; }
            public List<DemographicsList> demographicsList { get; set; }
            public List<DisputeDetailsList> disputeDetailsList { get; set; }
            public List<DeceasedDetailsList> deceasedDetailsList { get; set; }
            public List<EmployerList> employerList { get; set; }
            public List<FinancialRiskList> financialRiskList { get; set; }
            public List<FinancialSummaryList> financialSummaryList { get; set; }
            public List<FinancialTransactionDetailsList> financialTransactionDetailsList { get; set; }
            public List<Json.HistoryNotesList> historyNotesList { get; set; }
            public List<JudgementList> judgementList { get; set; }
            public List<LegalList> legalList { get; set; }
            public List<PaymentInfoList> paymentInfoList { get; set; }
            public List<ProductDetailsList> productDetailsList { get; set; }    
            public List<RiskScoreList> riskScoreList { get; set; }
            public List<RegulatoryChangeList> regulatoryChangeList { get; set; }
            public List<Json.RelatedPersonListList> relatedPersonList { get; set; }
            public List<SettlementList> settlementList { get; set; }
            public List<StrategyInfoList> strategyInfoList { get; set; }
            public List<SugarBarFieldDetailsList> sugarBarFieldDetailsList { get; set; }
            public List<TreatmentList> treatmentList { get; set; }
            public List<VisionList> visionList { get; set; }
        }
    }
    public class relatedPersonListList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<RelatedPersonDetailsList>relatedPersonDetailsList { get; set; }

    }
    public class OasisAccounts
    {
        public string additionalProperties { get; set; }
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
    public class OasisOffer
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null; 
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string legacyCode { get; set; }
        public string offer { get; set; }
        public string accept { get; set; }
        public int? applicationGeoScramNumber { get; set; } = null;
        public string eligibility { get; set; }
        public string rmsStatus { get; set; }
        public string agencyCode { get; set; }
        public DateTime? currentDate { get; set; } = null;
        public OasisAccounts oasisAccounts { get; set; }
        public string reserveReactivationSolicitationFlag { get; set; }
        public DateTime? reserveReactivationSolicitationFlagDate { get; set; } = null;
        public string primarySolicitationFlag { get; set; }
        public DateTime? primarySolicitationFlagDate { get; set; } = null;
        public string secondarySolicitationFlag { get; set; }
        public DateTime? secondarySolicitationFlagDate { get; set; } = null;
        public string tertiarySolicitationFlag { get; set; }
        public DateTime? tertiarySolicitationFlagDate { get; set; } = null;
    }

    public class VisionList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string class2 { get; set; }
        public string class5 { get; set; }
        public string rpc { get; set; }
        public string rpcTypeCode { get; set; }
        public string agencyId { get; set; }

        //public string visionD { get; set; }
    }

    public class Care
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string offerFlag { get; set; }
        public string acceptFlag { get; set; }
        public double? minimumDueAmount { get; set; } = null;
        public DateTime? minimumDueDate { get; set; } = null;
        public DateTime? letterDate { get; set; } = null;
        public string careCompletion { get; set; }
        
    }

    public class Cdmp
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public double? paymentAmount { get; set; } = null;
    }
    public class TreatmentList
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public DateTime? nextPaymentDate { get; set; } = null;
        public Care care { get; set; }
        public Cdmp cdmp { get; set; }
        public double? actualSettlementAmount { get; set; } = null;
        public string treatmentEligibility { get; set; }
        public DateTime? treatmentOffer { get; set; } = null;
        public DateTime? treatmentAccept { get; set; } = null;
        public DateTime? treatmentCompletion { get; set; } = null;
        public DateTime? treatmentExpiration { get; set; } = null;
        public string treatmentProgram { get; set; }
        public double? agreedSettlementAmount { get; set; } = null;
        public int? applicationGeoScramNumber { get; set; } = null;
        public string agencyId { get; set; }



    }
    public class SugarBarFields
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public double? totalSpend { get; set; } = null;
        public int? totalVisit { get; set; } = null;
        public double? highestCharge { get; set; } = null;
        public DateTime? highestChargeDate { get; set; } = null;
        public string suppCode { get; set; }
        public double? sumSpendOnChargeDate { get; set; } = null;
        public int? noOfVisitsOnChargeDate { get; set; } = null;
        public DateTime? chargeDate { get; set; } = null;
        public string minimumPeriod { get; set; }
        public string legacyFieldCode { get; set; }
    }

    public class SugarBarMerchantFields
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string seName { get; set; }
        public string seZipCode { get; set; }
        public string legacyFieldCode { get; set; }
    }
    public class SugarBarFieldDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<SugarBarFields> sugarBarFields { get; set; }
        public List<SugarBarMerchantFields> sugarBarMerchantFields { get; set; }



    }


    public class StrategyInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string strategyIndicator1 { get; set; }
        public string strategyIndicator2 { get; set; }
        public string strategyIndicator3 { get; set; }
        public string strategyIndicator4 { get; set; }
        public int? noOfCcsgChargeCardsCustomerHas { get; set; } = null;
        public int? noOfCcsgLendingCardsCustomerHas { get; set; } = null;
        public string segmentId1 { get; set; }
        public string segmentId2 { get; set; }
        public string segmentId3 { get; set; }
        public string segmentId4 { get; set; }
        public int? noOfOpenCardsCustomerHas { get; set; } = null;
        public string indicatorForLocBalance { get; set; }
        public string reAgeIndicator { get; set; }
        public string careEligibility { get; set; }
        public string writtenOffIndicator { get; set; }
        public string lendingInCharge { get; set; }
        public string speedToPayModel { get; set; }
    }
    public class SettlementList
    {
        public DateTime? updateDate { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public DateTime? settlementAgreementDate { get; set; } = null;
        public DateTime? settlementExpirationDate { get; set; } = null;
        public double? agreedSettlementAmount { get; set; } = null;
    }
    public class RiskScoreList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public double? debtToValueRatio { get; set; } = null;
        public double? customerLevelScoreForChargeAndLending { get; set; } = null;
        public double? lendingPayToCurrrentScore { get; set; } = null;
        public int? probScore { get; set; } = null;
    }
    public class RelatedPersonListList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<RelatedPersonDetailsList> relatedPersonDetailsList { get; set; }
    }
    public class RelatedPersonDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string seqNo { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime? birthDate { get; set; } = null;
        public List<Phone> phoneList { get; set; }
        public Address address { get; set; }
        public List<NationalId> nationalId { get; set; }
    }


    public class RegulatoryChangeList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public DateTime? finalDemandLetterDate { get; set; } = null;
        public double? totalInterest { get; set; } = null;
        public double? totalNonInterestCharges { get; set; } = null;
        public double? totalPayments { get; set; } = null;
        //public RelatedPersonList reatedPersonList { get; set; }




    }
    public class ProductDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string amexProductCode { get; set; }
        public string productType { get; set; }
        public string fullProductDescription { get; set; }
    }
    public class PaymentInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string paymentMode { get; set; }
        public int? ddaNumber { get; set; } = null;
        public int? routingNumber { get; set; } = null;
    }
    public class LegalList
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string customerId { get; set; }
        public string courtCode { get; set; }
        public DateTime? legalFileDate { get; set; } = null;
        public string attorneyOfRecord { get; set; }
        public DateTime? legalServiceDate { get; set; } = null;
    }

    public class LinkedAccountBalance
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public double? balance { get; set; } = null;
        public string legacyCode { get; set; }
    }
    public class JudgementExecutionAttemptsAndProgressByType
    {
        public string items { get; set; }
    }

    public class JudgementOperatingMetrics
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public int? judgementId { get; set; } = null;
        public DateTime? date { get; set; } = null;
        public int? noOfUniquePhoneNumbers { get; set; } = null;
        public int? noOfAttempts { get; set; } = null;
        public int? noOfOutboundContacts { get; set; } = null;
        public int? noOfOutboundRightPartyContacts { get; set; } = null;
        public int? noOfInboundContacts { get; set; } = null;
        public int? noOfInboundRightPartyContacts { get; set; } = null;
        public int? noOfPromises { get; set; } = null;
        public int? noOfPayments { get; set; } = null;
    }

    public class JudgementWorkStandards
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public int? judgementId { get; set; } = null;
        public DateTime? date { get; set; } = null;
        public string skipTrace { get; set; }
        public string managerReview { get; set; }
        public string foundPoe { get; set; }
        public string foundBank { get; set; }
        public string foundVehicle { get; set; }
        public string foundRealEstate { get; set; }
        public string foundOtherAssets { get; set; }
        public string activeBusiness { get; set; }
    }
    public class JudgementList
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<LinkedAccountBalance> linkedAccountBalance { get; set; }
        public DateTime? legalProceedingCourtDate { get; set; } = null;
        public string reasonForSuit { get; set; } = null;
        public DateTime? judgementDate { get; set; } = null;
        public DateTime? judgementExpirationDate { get; set; } = null;
        public string courtOfRecordName { get; set; }
        public double? judgementPrincipalBalance { get; set; } = null;
        public int? noOfAccountsInJudgement { get; set; } = null;
        public string postJudgementInterestAward { get; set; }
        public double? postJudgementInterestDate { get; set; } = null;
        public double? courtCost { get; set; } = null;
        public double? attorneyFees { get; set; } = null;
        public double? preJudgementInterest { get; set; } = null;
        public double? judgementBalance { get; set; } = null;
        public string courtOfRecordCounty { get; set; }
        public string courtOfRecordState { get; set; }
        public string attorneyOfRecordAgency { get; set; }
        public Phone attorneyOfRecordPhone { get; set; }
        public string accountsInJudgement { get; set; }
        public double? postJudgementInterestRate { get; set; } = null;
        public string primaryAccount { get; set; } = null;
        public double? balanceInLawSuit { get; set; } = null;
        public DateTime? satisfactionOfJudgementFulfilledDate { get; set; } = null;
        public DateTime? satisfactionOfJudgementRequestedDate { get; set; } = null;
        public List<string> judgementExecutionAttemptsAndProgressByType { get; set; }
        public JudgementOperatingMetrics judgementOperatingMetrics { get; set; }
        public JudgementWorkStandards judgementWorkStandards { get; set; }
    }
    public class HistoryNotesList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<HistoryNoteLineList> historyNoteLineList { get; set; }


    }
    public class HistoryNoteLineList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string activityCode { get; set; }
        public string activityTimeStamp { get; set; }
        public string resultCode { get; set; }
        public string notes { get; set; }
        public string contactCode { get; set; }
        public string liftDate { get; set; }
        public string addtionalInfo { get; set; }


    }
    public class FinancialTransactionDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<Transactions> transactions { get; set; }
        
    }
    public class Transactions
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string last5DigitsOfTransaction { get; set; }
        public double? transactionAmount { get; set; } = null;
        public string transactionTypeCode { get; set; }
        public DateTime? transactionDate { get; set; } = null;
        public string legacyFieldCode { get; set; }
        public string transactionCode { get; set; }
        public string transactionId { get; set; }
        public string currency { get; set; }
        public string transactionReferId { get; set; }
        public double? foreignTransactionAmount { get; set; } = null;
        public string foreignCurrencyCode { get; set; }
        public double? stampedFxRate { get; set; } = null;
        public string sorTransactionCode { get; set; }
        public double? currentForeignBalance { get; set; } = null;
        public double? currentLocalCurrencyBalance { get; set; } = null;
        public DateTime? acornPostDate { get; set; } = null;
        public string processingStatus { get; set; }
    }
    public class DebitSummaryInMonths
    {
        public double? Month01 { get; set; } = null;
        public double? Month02 { get; set; } = null;
        public double? Month03 { get; set; } = null;
        public double? Month04 { get; set; } = null;
        public double? Month05 { get; set; } = null;
        public double? Month06 { get; set; } = null;
        public double? Month07 { get; set; } = null;
        public double? Month08 { get; set; } = null;
        public double? Month09 { get; set; } = null;
        public double? Month10 { get; set; } = null;
        public double? Month11 { get; set; } = null;
        public double? Month12 { get; set; } = null;
    }
    public class AccountBalanceInMonths
    {
        public double? Month01 { get; set; } = null;
        public double? Month02 { get; set; } = null;
        public double? Month03 { get; set; } = null;
        public double? Month04 { get; set; } = null;
        public double? Month05 { get; set; } = null;
        public double? Month06 { get; set; } = null;
        public double? Month07 { get; set; } = null;
        public double? Month08 { get; set; } = null;
        public double? Month09 { get; set; } = null;
        public double? Month10 { get; set; } = null;
        public double? Month11 { get; set; } = null;
        public double? Month12 { get; set; } = null;
    }
    public class InterestAccessedByMonth
    {
        public double? Month01 { get; set; } = null;
        public double? Month02 { get; set; } = null;
        public double? Month03 { get; set; } = null;
        public double? Month04 { get; set; } = null;
        public double? Month05 { get; set; } = null;
        public double? Month06 { get; set; } = null;
        public double? Month07 { get; set; } = null;
        public double? Month08 { get; set; } = null;
        public double? Month09 { get; set; } = null;
        public double? Month10 { get; set; } = null;
        public double? Month11 { get; set; } = null;
        public double? Month12 { get; set; } = null;
    }
    public class SummaryCreditInMonths
    {
        public double? Month01 { get; set; } = null;
        public double? Month02 { get; set; } = null;
        public double? Month03 { get; set; } = null;
        public double? Month04 { get; set; } = null;
        public double? Month05 { get; set; } = null;
        public double? Month06 { get; set; } = null;
        public double? Month07 { get; set; } = null;
        public double? Month08 { get; set; } = null;
        public double? Month09 { get; set; } = null;
        public double? Month10 { get; set; } = null;
        public double? Month11 { get; set; } = null;
        public double? Month12 { get; set; } = null;
    }
    public class AccountAgingInMonths
    {
        public int? Month01 { get; set; } = null;
        public int? Month02 { get; set; } = null;
        public int? Month03 { get; set; } = null;
        public int? Month04 { get; set; } = null;
        public int? Month05 { get; set; } = null;
        public int? Month06 { get; set; } = null;
        public int? Month07 { get; set; } = null;
        public int? Month08 { get; set; } = null;
        public int? Month09 { get; set; } = null;
        public int? Month10 { get; set; } = null;
        public int? Month11 { get; set; } = null;
        public int? Month12 { get; set; } = null;
    }
    public class FinancialSummaryList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public DebitSummaryInMonths debitSummaryInMonths { get; set; }
        public AccountBalanceInMonths accountBalanceInMonths { get; set; }
        public InterestAccessedByMonth interestAccessedByMonth { get; set; }
        public SummaryCreditInMonths summaryCreditInMonths { get; set; }
        public double? previousBalance { get; set; } = null;
        public AccountAgingInMonths accountAgingInMonths { get; set; }


    }
    public class FinancialRiskList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string lendingAgeCode { get; set; }
        public double? chargeTotalBalance { get; set; } = null;
        public double? lendingTotalBalance { get; set; } = null;
        public double? customerExposureCcsg { get; set; } = null;
        public double? customerExposureOpen { get; set; } = null;
        public double? totalExposure { get; set; } = null;
        public DateTime? lastBalanceDate { get; set; } = null;
        public DateTime? cycleCutDate { get; set; } = null;
        public int? cycleCutDate2 { get; set; } = null;
        public DateTime? dueDate { get; set; } = null;
        public int? dueDate2 { get; set; } = null;
        public string bankType { get; set; }
        public int? ability { get; set; } = null;
        public string minDueIndicator { get; set; }
        public double? currentCombinedFeeAndInterest { get; set; } = null;
        public double? combinedFeesWithInterest30Days { get; set; } = null;
        public double? combinedFeesWithInterest60Days { get; set; } = null;
        public double? combinedFeesWithInterest90Days { get; set; } = null;
        public double? combinedFeesWithInterest120Days { get; set; } = null;
        public double? combinedFeesWithInterest150Days { get; set; } = null;
        public double? combinedFeesWithInterest180Days { get; set; } = null;
        public double? oldestAgeMinDueBucket { get; set; } = null;
        public double? totalCustomerLevelMinDueCcsg { get; set; } = null;
        public double? totalCustomerLevelMinDueOpen { get; set; } = null;
        public double? totalCustomerLevelMinDue { get; set; } = null;
        public double? totalCourtCostsReimbursedToPreviousAgency { get; set; } = null;
    }
    public class EmployerList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public Emails email { get; set; }
        public List<Phone> Phones { get; set; }
    }
    public class DisputeDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string disputeType { get; set; }
        public double? disputeAmount { get; set; } = null;
        public string disputeDate { get; set; }
        public string disputeOutcome { get; set; }
    }
    public class NationalId
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string nationalIdNumber { get; set; }
        public string nationalIDtype { get; set; }
    }
    public class Emails
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string typeCode { get; set; }
        public string categoryCode { get; set; }
        public string statusCode { get; set; }
        public string consent { get; set; }
        public string emailAddress { get; set; }
    }
    public class DemographicsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public List<Address> addresses { get; set; }
        public List<Emails> emails { get; set; }
        public List<Phone> phones { get; set; }
        public List<NationalId> nationalIds { get; set; }
        public DateTime? birthDate { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string returnMailIndicator { get; set; }
        //public string rightPartyContactTypeCode { get; set; }
    }
    public class DeceasedDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string attorneyName { get; set; }
        public string attorneyAddress { get; set; }
        public string executorAddress2 { get; set; }
        public string executorCity { get; set; }
        public string executorState { get; set; }
        public string executorZip { get; set; }
        public string executorPhone { get; set; }
    }
    public class CustomerFinancialList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string largeOrMiddleMarket { get; set; }
        public int? cycleCut { get; set; } = null;
        public string waiverOrGuaranteed { get; set; }
        public int? numberOfTimesPastDue60Days { get; set; } = null;
        public string liability { get; set; }
        public double? totalExposure { get; set; } = null;
        public DateTime? lastPaymentDate { get; set; } = null;
        public double? creditBalance { get; set; } = null;
        public double? minimumAmountDue { get; set; } = null;
        public double? unbilledAmountDue { get; set; } = null;
        public double? currentAmountDue { get; set; } = null;
        public double? amountDue30Days { get; set; } = null;
        public double? amountDue60Days { get; set; } = null;
        public double? amountDue90Days { get; set; } = null;
        public double? amountDue120Days { get; set; } = null;
        public double? amountDue150Days { get; set; } = null;
        public double? amountDue180Days { get; set; } = null;
        public double? totalAmountDueInUSD { get; set; } = null;
        public double? unbilledAmountDueInUSD { get; set; } = null;
        public double? currentAmountDueInUSD { get; set; } = null;
        public double? amountDue30DaysInUSD { get; set; } = null;
        public double? amountDue60DaysInUSD { get; set; } = null;
        public double? amountDue90DaysInUSD { get; set; } = null;
        public double? amountDue120DaysInUSD { get; set; } = null;
        public double? amountDue150DaysInUSD { get; set; } = null;
        public string creditInUSD { get; set; }
        public string legacyCode { get; set; }
    }
    public class CustomerDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string customerId { get; set; }
        public string accountMarketCode { get; set; }
        public string countryCode { get; set; }
        public double? homeMarketValue { get; set; } = null;
        public double? homeEquity { get; set; } = null;
        public double? monthlyMortgage { get; set; } = null;
        public string cardMemberTitle { get; set; }
        public string preferredLanguageIndicator { get; set; }
        public string amexPortfolioOrLendingOfficerCode { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string taxidfieldext { get; set; }
    }
    public class CustomerAdditionalDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string accountMarketCode { get; set; }
        public string countryCode { get; set; }
        public string cardMemberType { get; set; }
        public DateTime? deceasedDate { get; set; } = null;
        public double? monthlyIncome { get; set; } = null;
        public string rentOrOwn { get; set; }
    }
    public class CreditRiskInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public int? majorDerogs { get; set; } = null;
        public int? minorDerogs { get; set; } = null;
        public int? satTrades { get; set; } = null;
        public int? judgements { get; set; } = null;
        public double? monthlyMortgage { get; set; } = null;
        //public int? ficoScore { get; set; }
    }
    public class ContactInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string type { get; set; }
        public DateTime? lastContactDate { get; set; } = null;
    }
    public class CollectionScoreList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public int? collectibilityScore { get; set; } = null;
        public int? recoveryScore { get; set; } = null;
        public int? bankruptcyScore { get; set; } = null;
        public int? marketRecoveryScore { get; set; } = null;
        public string returnMetricScore { get; set; }
        public string ficoScore { get; set; }
    }
    public class CollectionInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public double? actualSettlementAmount { get; set; } = null;
    }
    public class CmxTradeDemographicsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public Address businessAddress { get; set; }
        public Address businessCorrespondenceAddress { get; set; }
        public string businessContactName { get; set; }
        public List<Address> homeAddressOnBusinessAccount { get; set; }

    }
    //public class AccountNumbers
    //{
    //    public string items { get; set; }
    //}
    public class CaseList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string id { get; set; }
        public string caseId { get; set; }
        public string parentCaseId { get; set; }
        public string type { get; set; }
        public List<string> accountNumbers {get;set;}
        public string customerId { get; set; }
        public string chargeOffReasonCode { get; set; }
        public string countryISOAlpha2Code { get; set; }
        public double? balance { get; set; } = null;
        public int? collectibilityScore { get; set; } = null;
        public DateTime? writeOffDate { get; set; } = null;
        public string marketCode { get; set; }
        public string caseStatus { get; set; }
        public string casePurpose { get; set; }
        public string caseSetupType { get; set; }
        public DateTime? caseSetupDate { get; set; } = null;
        public string businessLeader { get; set; }
        public DateTime? lastReviewedDate { get; set; } = null;
        public string lastReviewedBy { get; set; }
        public DateTime? liftDate { get; set; } = null;
        public DateTime? lastCaseStatusChangeDate { get; set; } = null;
    }
    public class CapInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string capMemo { get; set; }
    }
    public class BankruptcyDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string assetIndicator { get; set; }
        public DateTime? bankruptcyFilingDate { get; set; } = null;
        public string bankruptcyChapter { get; set; }
        public string bankruptcyChapterCode { get; set; }
        public string attorneyName { get; set; }
        public Address attorneyAddress { get; set; }
        public Address executorAddress { get; set; }
        public Phone executorPhone { set; get; }
        public string caseNumber { get; set; }
    }
    public class BankListList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<Bank> banks { get; set; }
    }
    public class Bank
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string customerId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string phone { get; set; }
        public string bankAccountNumber { get; set; }
        public DateTime? lastUpdatedDate { get; set; } = null;
        public string routingNumber { get; set; }
        public string abaNumber { get; set; }
        public DateTime? dateAccountOpened { get; set; } = null;
        public double? lastAmount { get; set; } = null;
        public DateTime? lastActivityDate { get; set; } = null;
        public string sourceFlag { get; set; }
        public string legacyFieldCode { get; set; }
    }
    public class AttorneyDetails
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string typeCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string firmName { get; set; }
        public string emailAddress1 { get; set; }
        public string emailAddress2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string businessPhone { get; set; }
        public string mobilePhone1 { get; set; }
        public string mobilePhone2 { get; set; }
        public string extensionAttributes { get; set; }
    }
    public class Phone
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public int? id { get; set; } = null;
        public string typeCode { get; set; }
        public string categoryCode { get; set; }
        public string statusCode { get; set; }
        public string number { get; set; }
        public string isdCode { get; set; }
        public string extension { get; set; }
        public DateTime? lastUpdateDate { get; set; } = null;
        public DateTime? lastContactDate { get; set; } = null;
    }
    public class Address
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string typeCode { get; set; }
        public string categoryCode { get; set; }
        public string statusCode { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }//
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public DateTime? addressConfirmationDate { get; set; } = null;
        public DateTime? lastUpdateDate { get; set; } = null;
    }
   
    public class AgencyAssignmentList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string caseId { get; set; }
        public string agencyId { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string accountStatusCode { get; set; }
        public string countryCode { get; set; }
        public string agencyAssignmentStatusCode { get; set; }
        public string fileTransmissionStatusCode { get; set; }
        public DateTime? accountInsertTimeStamp { get; set; } = null;
        public DateTime? agencyAssignmentDate { get; set; } = null;
        public DateTime? agencyRecallDate { get; set; } = null;
        public double? balanceAmount { get; set; } = null;
        public int? noOfDays { get; set; } = null;
        public string previousAgencyId { get; set; }
        public int? commissionRate { get; set; } = null;
        public string internalAmexRecovererCode { get; set; }//////////        
    }
    public class AgencyInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public int? id { get; set; } = null;
        public string agencyId { get; set; }
        public string agencyGroupId { get; set; }
        public string assignmentGroupNumber { get; set; }
        public string countrycode { get; set; }
        public string agencyDescription { get; set; }
        public string channelCode { get; set; }
        public string levelCode { get; set; }
        public string programCode { get; set; }
        public string legacyRecoverCode { get; set; }
        public Address agencyAddress { get; set; }
        public Phone agencyPhone { get; set; }
        public string agencyBranchName { get; set; }
        public string extensibleAttribute { get; set; }
    }
    public class AdditionalCmSpendInfoList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public List<AdditionalCmSpends> additionalCmSpends { get; set; }

    }
    public class AdditionalCmSpends
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string additionalCmAccountNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public double? totalAmountSpentIn6Months { get; set; } = null;
        public double? percentageOfBalance { get; set; } = null;
        public double? highSpend { get; set; } = null;
        public string legacyFieldCode { get; set; }
    }
    public class AccountDetailsList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string accountMarketCode { get; set; }
        public string customerId { get; set; }
        public string cancelCode { get; set; }
        public DateTime? crDate { get; set; } = null;
        public DateTime? cancellationDate { get; set; } = null;
        public DateTime? cardOpenDate { get; set; } = null;
        public string corporateId { get; set; }
        public string membershipRewards { get; set; }
        public DateTime? lastChargeActivity { get; set; } = null;
        public string companyName { get; set; }
        public string productCode { get; set; }
        public string taxidfieldext { get;set;}

        //public double? commissionRate { get; set; }
    }
    public class AccountList
    {
        public DateTime? updateDate { get; set; } = null;
        public string updatedBy { get; set; }
        public string accountNumber { get; set; }
        public string accountCategoryTypeCode { get; set; }
        public string countryIsoAlpha2Code { get; set; }
        public string productCode { get; set; }
        public string chargeOffReasonCode { get; set; }
        public double? placementBalance { get; set; } = null;
        public double? currentBalance { get; set; } = null;
        public double? writeOffAmount { get; set; } = null;
        public string accountStatus { get; set; }
        public DateTime? writeOffDate { get; set; } = null;
        public DateTime? originalPlacementDate { get; set; } = null; 
        public DateTime? accountReceiveDate { get; set; } = null;
        public string internalRecovererCode { get; set; }
        public string placementLevelCode { get; set; }
        public double? stampedRate1 { get; set; } = null;
        public double? stampedRate2 { get; set; } = null;
        public double? stampedRate3 { get; set; } = null;
        public double? stampedFxRate { get; set; } = null;
        public double? commissionRate { get; set; } = null;
        public DateTime? agencyAssignmentDate { get; set; } = null;
        public DateTime? lastStatusChangeDate { get; set; } = null;
        public DateTime? agencyRecallDate { get; set; } = null;
        public string currentAgencyId { get; set; }

    }

   
    public class Header
    {
        public DateTime? updateDate { get; set; } = null;
        public string senderID { get; set; }
        public string targetID { get; set; }
        public int? totalRecords { get; set; } = null;
        public string balancingId { get; set; }
        public int? balancingSeqNo { get; set; } = null;
    }
}
