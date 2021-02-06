using System;
using System.Collections.Generic;

namespace DocuSign.CodeExamples.Data
{
    public partial class User
    {
        public User()
        {
            Document = new HashSet<Document>();
            EmployeePrevileges = new HashSet<EmployeePrevileges>();
            Mail = new HashSet<Mail>();
            NotesNavigation = new HashSet<Notes>();
            PropertyCreatedByNavigation = new HashSet<Property>();
            PropertyUser = new HashSet<Property>();
            Template = new HashSet<Template>();
            TransactionaccountdetailsCreatedByNavigation = new HashSet<Transactionaccountdetails>();
            TransactionaccountdetailsUser = new HashSet<Transactionaccountdetails>();
        }

        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string OfficeNumber { get; set; }
        public string FaxNumber { get; set; }
        public string MailingAddress { get; set; }
        public string Status { get; set; }
        public string ProfilePath { get; set; }
        public string ProfileImage { get; set; }
        public byte IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public short IsTokenExpiered { get; set; }
        public string Token { get; set; }
        public string Notes { get; set; }
        public int IsLogin { get; set; }
        public DateTime LastLogin { get; set; }
        public short? ChangepasswordFlag { get; set; }
        public int? LoginFailureCount { get; set; }
        public DateTime? NextOtpdate { get; set; }
        public DateTime? OtpexpiryTime { get; set; }
        public string Otpvalue { get; set; }
        public int TwoFactorConfig { get; set; }
        public int Updatepasswordcount { get; set; }
        public string Ipaddress { get; set; }
        public string SystemIp { get; set; }
        public short IsAdminApproved { get; set; }
        public int? SynergyId { get; set; }

        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<EmployeePrevileges> EmployeePrevileges { get; set; }
        public virtual ICollection<Mail> Mail { get; set; }
        public virtual ICollection<Notes> NotesNavigation { get; set; }
        public virtual ICollection<Property> PropertyCreatedByNavigation { get; set; }
        public virtual ICollection<Property> PropertyUser { get; set; }
        public virtual ICollection<Template> Template { get; set; }
        public virtual ICollection<Transactionaccountdetails> TransactionaccountdetailsCreatedByNavigation { get; set; }
        public virtual ICollection<Transactionaccountdetails> TransactionaccountdetailsUser { get; set; }
    }
}
