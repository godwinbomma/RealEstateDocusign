using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class Exchange
    {
        public int ExchangeId { get; set; }
        public int UserTypeId { get; set; }
        public string ExchangeNumber { get; set; }
        public string ExchangeType { get; set; }
        public string Status { get; set; }
        public string OfficerName { get; set; }
        public string CompanyName { get; set; }
        public string OfficerPhone { get; set; }
        public string OfficerEmail { get; set; }
        public string PropertyTitle { get; set; }
        public string IdentificationMoneyTotal { get; set; }
        public DateTime? ExpectedClosingDate { get; set; }
        public string ReferralSource { get; set; }
        public short Bankrefferal { get; set; }
        public string AmountBeingReleasedtoClient { get; set; }
        public string MortgageBoot { get; set; }
        public string WithholdingAmount { get; set; }
        public string AlternativeWithholdingAmount { get; set; }
        public short AlternativeWithholding { get; set; }
        public string Note { get; set; }
        public string InterestPayabletoExchanger { get; set; }
        public short Is3PropertyRule { get; set; }
        public short Is200PerRule { get; set; }
        public byte Catransaction { get; set; }
        public byte ExemptFromWithholding { get; set; }
        public byte FailedExchange { get; set; }
        public byte WireFee { get; set; }
        public byte DirectTransfer { get; set; }
        public byte ExchangeFeeReceived { get; set; }
        public byte Identified { get; set; }
        public short IsPositiveCloseOut { get; set; }
        public double? CloseOutMoney { get; set; }
        public byte IsCloseOut { get; set; }
        public DateTime? ExchangeCloseDate { get; set; }
        public DateTime? ExchangeOpenDate { get; set; }
        public DateTime? Exchange45Date { get; set; }
        public DateTime? Exchange180Date { get; set; }
        public string Day45 { get; set; }
        public string Day180 { get; set; }
        public string SpecialInstruction { get; set; }
        public DateTime? ExchangeClosedOn { get; set; }
        public string FinalClosingStatementFilePath { get; set; }
        public string FinalClosingStatementFileName { get; set; }
        public int IintendToAquire { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public byte IsActive { get; set; }
        public short IsAdminApprovedCustomerIdentification { get; set; }
        public byte IsAdminApproveed { get; set; }
        public short IsIdentifiedAprroved { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public int CustomerId { get; set; }
        public int EscrowOfficerId { get; set; }
    }
}
