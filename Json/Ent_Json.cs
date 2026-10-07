using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Ent_Json
    {
        public class RootObject
        {
            public DateTime? updateDate { get; set; } = null;
            public Header header { get; set; }
            public List<CaseInfoList> caseInfoList { get; set; }
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
        public class CaseInfoList
        {
            public DateTime? updateDate { get; set; } = null;
            public int? id { get; set; } = null;
            public string caseId { get; set; }
            //public CustomerInfo customerInfo { get; set; }
            public List<AccountInfoList> accountInfoList { get; set; }
            //public AgencyAssignment agencyAssignment { get; set; }
        }
        public class CustomerInfo
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public int? id { get; set; } = null;
            public string accountNumber { get; set; }
            public CustomerDetails customerDetails { get; set; }
            public Demographics demographics { get; set; }
            public ContactInfo contactInfo { get; set; }
            public Employer employer { get; set; }
        }
        public class AccountInfoList
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public int? id { get; set; } = null;
            public string accountNumber { get; set; }
            public CustomerDetails customerDetails { get; set; }
            public Demographics demographics { get; set; }
            public ContactInfo contactInfo { get; set; }
            public Employer employer { get; set; }
            public RelatedPersonList relatedPersonList { get; set; }
            public AccountDetails accountDetails { get; set; }
            public AttorneyDetails attorneyDetails { get; set; }
            public ProductDetails productDetails { get; set; }
            public CustomerFinancial customerFinancial { get; set; }
            public FinancialRisk financialRisk { get; set; }
            public FinancialSummary financialSummary { get; set; }
            public BankList bankList { get; set; }
            public PaymentInfo paymentInfo { get; set; }
            public AdditionalCmSpendInfo additionalCmSpendInfo { get; set; }
            public BankruptcyDetails bankruptcyDetails { get; set; }   
            public CreditRiskInfo creditRiskInfo { get; set; }
            public CapInfo capInfo { get; set; }
            public Legal legal { get; set; }
            public Judgement judgement { get; set; }
            public CollectionInfo collectionInfo { get; set; }
            public FinancialTransactionDetails financialTransactionDetails { get; set; }
            public RiskScore riskScore { get; set; }
            public RegulatoryChange regulatoryChange { get; set; }
            public List<Treatments> treatments { get; set; }
            public Settlement settlement { get; set; }
            public StrategyInfo strategyInfo { get; set; }
            public SugarBarFieldDetails sugarBarFieldDetails { get; set; }
            public DisputeDetails disputeDetails { get; set; }
            public Account account { get; set; }
            public CollectionScore collectionScore { get; set; }
            public CustomerAdditionalDetails customerAdditionalDetails { get; set; }
            public HistoryNotes historyNotes { get; set; }
            public AcornCase acornCase { get; set; }
            public DeceasedDetails deceasedDetails { get; set; }
            public CmxTradeDemographics cmxTradeDemographics { get; set; }            
            public AgencyInfo agencyInfo { get; set; }
            public AgencyAssignment agencyAssignment {get;set;}   
            public CollectionRiskScore collectionRiskScore { get; set; }
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
        public class AgencyAssignment
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
            public double? commissionRate { get; set; } = null;
            public string internalAmexRecovererCode { get; set; }
        }
        public class CustomerDetails
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
        public class Address
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string typeCode { get; set; }
            public string categoryCode { get; set; }
            public string statusCode { get; set; }
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string addressLine3 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string zipCode { get; set; }
            public DateTime? addressConfirmationDate { get; set; } = null;
            public DateTime? lastUpdateDate { get; set; } = null;

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
        public class Demographics
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
        }
        public class Employer
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string name { get; set; }
            public Address address { get; set; }
            public Emails email { get; set; }
            public List<Phone> Phones { get; set; }
        }
        public class AccountDetails
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
            public string taxidfieldext { get; set; }
            //public double? commissionRate { get; set; }
            //public DateTime? lastStatusChangeDate { get; set; }

        }
        public class ProductDetails
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public string amexProductCode { get; set; }
            public string productType { get; set; }
            public string fullProductDescription { get; set; }
        }
        public class CustomerFinancial
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
            public double? otherIncome { get; set; } = null;
            public double? totalPastdue { get; set; } = null;
            public string legacyCode { get; set; }
            public CreditInUSD creditInUSD { get; set; }
           
        }
        public class CreditInUSD
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
          
        
        public class FinancialRisk
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
        public class DebitSummaryInMonthsUSD
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
        public class AccountBalanceInMonthsUSD
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
        public class FinancialSummary
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }            
            public DebitSummaryInMonths debitSummaryInMonths { get; set; }
            public DebitSummaryInMonthsUSD debitSummaryInMonthsUSD { get; set; }
            public AccountBalanceInMonths accountBalanceInMonths { get; set; }
            public AccountBalanceInMonthsUSD accountBalanceInMonthsUSD { get; set; }
            public SummaryCreditInMonths summaryCreditInMonths { get; set; }
            public double? previousBalance { get; set; } = null;
            public AccountAgingInMonths accountAgingInMonths { get; set; }
            

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
        public class BankList
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public List<Bank> banks { get; set; }
        }
        public class CreditRiskInfo
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
            // public int? ficoScore { get; set; }            
        }
        public class RiskScore
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
        public class Treatments
        {
            public DateTime? updateDate { get; set; } = null;
            //public int? id { get; set; } = null;
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            //public DateTime? nextPaymentDate { get; set; } = null;
            //public Care care { get; set; }
            //public Cdmp cdmp { get; set; }
            public double? actualSettlementAmount { get; set; } = null;//AANAY CAMBIO A DECIMALES PARA QUE NO MARQUE ERROR PORQUE ESTABA COMO ENTERO (INT) 03/ENE/22
            public string treatmentEligibility { get; set; }
            public DateTime? treatmentOffer { get; set; } = null;
            public DateTime? treatmentAccept { get; set; } = null;
            public DateTime? treatmentCompletion { get; set; } = null;
            public DateTime? treatmentExpiration { get; set; } = null;
            public string treatmentProgram { get; set; }
            public double? agreedSettlementAmount { get; set; } = null;
            //public string applicationGeoScramNumber { get; set; }
            public string agencyId { get; set; }
            public string accountInsertTimeStamp { get; set; }
            public string isActive { get; set; }
        }
        public class StrategyInfo
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
        public class Account
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
        public class AgencyInfo
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
            //Este campo no existia, Existe en el EXCEL. Agregado el 24 de Septiembre del 2019. - Ricardo Cervantes
            public string legacyRecovererCode { get; set; }


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
        public class ContactInfo
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }            
            public string type { get; set; }
            public DateTime? lastContactDate { get; set; } = null;
        }
        public class RelatedPersonList
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public List<RelatedPersonDetailsList> relatedPersonDetailsList { get; set; }
        }
        public class PaymentInfo
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public string paymentMode { get; set; }
            public int? ddaNumber { get; set; } = null;
            public int? routingNumber { get; set; } = null;
        }
        public class AdditionalCmSpendInfo
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public List<AdditionalCmSpends> additionalCmSpends { get; set; }
        }
        public class BankruptcyDetails
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
        public class CapInfo
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public string capMemo { get; set; }
        }
        public class Legal
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
        public class Judgement
        {
            public DateTime? updateDate { get; set; } = null;
            public int? id { get; set; } = null;
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public List<LinkedAccountBalance> linkedAccountBalance { get; set; }
            public DateTime? legalProceedingCourtDate { get; set; } = null;
            public string reasonForSuit { get; set; }
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
            public string primaryAccount { get; set; }
            public double? balanceInLawSuit { get; set; } = null;
            public DateTime? satisfactionOfJudgementFulfilledDate { get; set; } = null;
            public DateTime? satisfactionOfJudgementRequestedDate { get; set; } = null;
            public List<string> judgementExecutionAttemptsAndProgressByType { get; set; }
            public JudgementOperatingMetrics judgementOperatingMetrics { get; set; }
            public JudgementWorkStandards judgementWorkStandards { get; set; }            
        }
        public class CollectionInfo
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public double? actualSettlementAmount { get; set; } = null;
        }
        public class FinancialTransactionDetails
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public List<Transactions> transactions { get; set; }

           
        }
        public class RegulatoryChange
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public DateTime? finalDemandLetterDate { get; set; } = null;
            public double? totalInterest { get; set; } = null;
            public double? totalNonInterestCharges { get; set; } = null;
            public double? totalPayments { get; set; } = null;
        }
        public class Settlement
        {
            public DateTime? updateDate { get; set; } = null;
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public DateTime? settlementAgreementDate { get; set; } = null;
            public DateTime? settlementExpirationDate { get; set; } = null;
            public double? agreedSettlementAmount { get; set; } = null;
        }
        public class SugarBarFieldDetails
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public int? id { get; set; } = null;
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public List<SugarBarFields> sugarBarFields { get; set; }
            public List<SugarBarMerchantFields> sugarBarMerchantFields { get; set; }


         
        }
        public class DisputeDetails
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
        public class CollectionScore
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
        public class CollectionRiskScore
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public double? debtToValueRatio { get; set; } = null;
            public double? customerLevelScoreForChargeAndLending { get; set; } = null;
            public double? lendingPayToCurrrentScore { get; set; } = null;
            public int? probScore { get; set; } = null;
            public int? id { get; set; } = null;
            public int? collectibilityScore { get; set; } = null;
            public int? recoveryScore { get; set; } = null;
            public int? bankruptcyScore { get; set; } = null;
            public int? marketRecoveryScore { get; set; } = null;
            public string returnMetricScore { get; set; }
            public string ficoScore { get; set; }
        }
        public class CustomerAdditionalDetails
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
        public class HistoryNotes
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public List<HistoryNoteLineList> historyNoteLineList { get; set; }

           
        }
        public class AcornCase
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string id { get; set; }
            public string caseId { get; set; }
            public string parentCaseId { get; set; }
            public string type { get; set; }
            public List<string> accountNumbers { get; set; }
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
        public class DeceasedDetails
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public int? id { get; set; } = null;
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public string attorneyName { get; set; }
            public string attorneyAddress  { get; set; }
            public string executorAddress2 { get; set; }
            public string executorCity { get; set; }
            public string executorState { get; set; }
            public string executorZip { get; set; }
            public string executorPhone { get; set; }
        }
        public class CmxTradeDemographics
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string accountNumber { get; set; }
            public Address businessAddress { get; set; }
            public Address businessCorrespondenceAddress { get; set; }
            public string businessContactName { get; set; }
            public List<Address> homeAddressOnBusinessAccount { get; set; }

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
            public string transactionCode{ get; set; }
            public string transactionId { get; set; }
            public string currency { get; set; }
            public string transactionReferId { get; set; }
            public double? foreignTransactionAmount { get; set; }
            public string foreignCurrencyCode { get; set; }
            public double? stampedFxRate { get; set; }
            public string sorTransactionCode { get; set; }
            public double? currentForeignBalance { get; set; } = null;
            public double? currentLocalCurrencyBalance { get; set; } = null;
            public DateTime? acornPostDate { get; set; } = null;
            public string processingStatus { get; set; }
        }
        public class OasisAccounts
        {
            public string additionalProperties { get; set; }
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
            public string oasisCompletion { get; set; }
        
        }
        public class Vision
        {
            public DateTime? updateDate { get; set; } = null;
            public string updateBy { get; set; }
            public int? id { get; set; } = null;
            public string accountNumber { get; set; }
            public string accountCategoryTypeCode { get; set; }
            public string class2 { get; set; }
            public string class5 { get; set; }
            public string rpc { get; set; }
            public string rpcTypeCode { get; set; }
            public string agencyId { get; set; }
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
        public class HistoryNoteLineList
        {
            public DateTime? updateDate { get; set; } = null;
            public string updatedBy { get; set; }
            public string activityCode { get; set; }
            public DateTime? activityTimeStamp { get; set; }
            public string resultCode { get; set; }
            public string notes { get; set; }
            public string contactCode { get; set; }
            public string liftDate { get; set; }
            public string addtionalInfo { get; set; }


        }
    }

    
}
