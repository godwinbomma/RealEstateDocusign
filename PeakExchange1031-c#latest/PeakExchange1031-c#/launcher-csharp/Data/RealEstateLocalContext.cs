using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DocuSign.CodeExamples.Data
{
    public partial class RealEstateLocalContext : DbContext
    {

        public RealEstateLocalContext(DbContextOptions<RealEstateLocalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChildCustomField> ChildCustomField { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ContactsCustomColumn> ContactsCustomColumn { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CustomColumn> CustomColumn { get; set; }
        public virtual DbSet<CustomFields> CustomFields { get; set; }
        public virtual DbSet<CustomFieldsTransations> CustomFieldsTransations { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<EmployeeAssign> EmployeeAssign { get; set; }
        public virtual DbSet<EmployeePrevileges> EmployeePrevileges { get; set; }
        public virtual DbSet<Exchange> Exchange { get; set; }
        public virtual DbSet<FieldTypeMaster> FieldTypeMaster { get; set; }
        public virtual DbSet<IdentificationProperty> IdentificationProperty { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<ManageBank> ManageBank { get; set; }
        public virtual DbSet<ManageBankTrasactions> ManageBankTrasactions { get; set; }
        public virtual DbSet<MasterExtension> MasterExtension { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<NotesRead> NotesRead { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<NotificationsReadId> NotificationsReadId { get; set; }
        public virtual DbSet<Previleges> Previleges { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyTransactions> PropertyTransactions { get; set; }
        public virtual DbSet<RolePrevileges> RolePrevileges { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SubExtensions> SubExtensions { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskAssign> TaskAssign { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<TemplateCustomField> TemplateCustomField { get; set; }
        public virtual DbSet<Transactionaccountdetails> Transactionaccountdetails { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=192.168.4.13;port=3306;user=admin1;password=Admin@123;database=RealEstateLocal");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildCustomField>(entity =>
            {
                entity.HasKey(e => e.ChildCfid)
                    .HasName("PRIMARY");

                entity.Property(e => e.ChildCfid).HasColumnName("ChildCFId");

                entity.Property(e => e.LabelValue)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactsCustomColumn>(entity =>
            {
                entity.HasKey(e => e.ColumnHeadersId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UserTypeId);

                entity.Property(e => e.ActualColumnName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Isdeleted)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.ContactsCustomColumn)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactsCustomColumn_Userstypes");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomColumn>(entity =>
            {
                entity.HasKey(e => e.ColumnHeadersId)
                    .HasName("PRIMARY");

                entity.Property(e => e.ColumnHeadersName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<CustomFields>(entity =>
            {
                entity.HasKey(e => e.CustomFieldId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.ExchangeId)
                    .HasName("ExchangeId");

                entity.HasIndex(e => e.IsExchange)
                    .HasName("IsExchange");

                entity.HasIndex(e => e.TypeId)
                    .HasName("TypeID");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");

                entity.Property(e => e.AlwaysVisible)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.CustomFieldName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HelpText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.IsExchange).HasColumnType("bit(1)");

                entity.Property(e => e.IsReplacement).HasColumnType("bit(1)");

                entity.Property(e => e.Required)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.ShowColumn)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.ToolTip)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<CustomFieldsTransations>(entity =>
            {
                entity.HasKey(e => e.CftransationsId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");

                entity.Property(e => e.CftransationsId).HasColumnName("CFTransationsId");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.Property(e => e.DocId).HasColumnName("DocID");

                entity.Property(e => e.DocumentDescription)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentPath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentType)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IsFinalClosingDoc).HasColumnType("bit(1)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("document_ibfk_1");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeAssign>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeID");

                entity.HasIndex(e => e.ExchangeId)
                    .HasName("ExchangeID");

                entity.HasIndex(e => e.SynergyId)
                    .HasName("SynergyID");

                entity.HasIndex(e => e.TaskId)
                    .HasName("TaskID");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.EscrowDocumentsAreAttached)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.EscrowDocumentsRequestedNotYetReceived)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.IsSynergy)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PleaseRequestEscrowDocuments)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Task)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeePrevileges>(entity =>
            {
                entity.HasKey(e => e.EmployeePrevilageId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.PrevilageId)
                    .HasName("PrevilageID");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.IsCreate)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsDelete)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsEdit)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsView)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.PrevilageId).HasColumnName("PrevilageID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Previlage)
                    .WithMany(p => p.EmployeePrevileges)
                    .HasForeignKey(d => d.PrevilageId)
                    .HasConstraintName("EmployeePrevileges_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeePrevileges)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("EmployeePrevileges_ibfk_2");
            });

            modelBuilder.Entity<Exchange>(entity =>
            {
                entity.HasIndex(e => e.CloseOutMoney)
                    .HasName("CloseOutMoney");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("UpdatedBy");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomerId");

                entity.HasIndex(e => e.EscrowOfficerId)
                    .HasName("EscrowOfficerId");

                entity.HasIndex(e => e.IsPositiveCloseOut)
                    .HasName("IsPositiveCloseOut");

                entity.HasIndex(e => e.UserTypeId)
                    .HasName("UserTypeId");

                entity.Property(e => e.ExchangeId).HasColumnName("ExchangeID");

                entity.Property(e => e.AlternativeWithholding)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.AlternativeWithholdingAmount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AmountBeingReleasedtoClient)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bankrefferal)
                    .HasColumnName("bankrefferal")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Catransaction).HasColumnName("CATransaction");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Day180)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Day45)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeNumber)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeType)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FinalClosingStatementFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FinalClosingStatementFilePath)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificationMoneyTotal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IintendToAquire).HasColumnName("IIntendToAquire");

                entity.Property(e => e.InterestPayabletoExchanger)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Is200PerRule)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Is3PropertyRule)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsAdminApprovedCustomerIdentification)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsIdentifiedAprroved)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsPositiveCloseOut).HasColumnType("bit(1)");

                entity.Property(e => e.MortgageBoot)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerPhone)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReferralSource)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.WithholdingAmount)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FieldTypeMaster>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<IdentificationProperty>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.ExchangeId)
                    .HasName("ExchangeID");

                entity.HasIndex(e => e.PropertyId)
                    .HasName("PropertyID");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.Is200PerRule)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Is3PropertyRule)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.PropertyAddress)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyStatus)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.Property(e => e.MailId).HasColumnName("MailID");

                entity.Property(e => e.AttachmentFilepath)
                    .HasColumnName("AttachmentFIlepath")
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.MailBody)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.MailSubject)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MailTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mailfrom)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Mail)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("mail_ibfk_1");
            });

            modelBuilder.Entity<ManageBank>(entity =>
            {
                entity.HasKey(e => e.BankId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.BankName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.Note)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManageBankTrasactions>(entity =>
            {
                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");
            });

            modelBuilder.Entity<MasterExtension>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.CreatedByNavigationUserId);

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.DateTime).HasColumnName("Date/Time");

                entity.Property(e => e.Note)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Tags)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigationUser)
                    .WithMany(p => p.NotesNavigation)
                    .HasForeignKey(d => d.CreatedByNavigationUserId);
            });

            modelBuilder.Entity<NotesRead>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.IsRead).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.ExchangeId)
                    .HasName("ExchangeId");

                entity.HasIndex(e => e.IsDocumentsUpload)
                    .HasName("IsDocumentsUpload");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IsDocumentsUpload).HasColumnType("bit(1)");

                entity.Property(e => e.MethodName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NotificationsReadId>(entity =>
            {
                entity.HasKey(e => e.NotificationsReadId1)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.NotificationsId)
                    .HasName("NotificationsId");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.NotificationsReadId1).HasColumnName("NotificationsReadId");

                entity.Property(e => e.IsAdmin)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsRead)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");
            });

            modelBuilder.Entity<Previleges>(entity =>
            {
                entity.HasKey(e => e.PrevilageId)
                    .HasName("PRIMARY");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrivilegeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.ExchangeId).HasColumnName("ExchangeID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.OwnershipInterest)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyAddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyName)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyStatus)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PropertyCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("property_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PropertyUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("property_ibfk_1");
            });

            modelBuilder.Entity<PropertyTransactions>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.Property(e => e.ExchangeId).HasColumnName("ExchangeID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.PropertyAddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            });

            modelBuilder.Entity<RolePrevileges>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");

                entity.Property(e => e.IsActive).HasColumnType("bit(1)");

                entity.Property(e => e.PrevilageId).HasColumnName("PrevilageID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubExtensions>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TaskAssign>(entity =>
            {
                entity.HasIndex(e => e.AssignToId)
                    .HasName("EmployeeId");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.ExchangeId)
                    .HasName("ExchangeId");

                entity.HasIndex(e => e.TaskId)
                    .HasName("TaskId");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.Note)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.Sharing)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateFileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TemplatePath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Template)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("Template_Cfk");
            });

            modelBuilder.Entity<TemplateCustomField>(entity =>
            {
                entity.HasKey(e => e.TcustomFieldId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Cfid)
                    .HasName("CFId");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.Property(e => e.TcustomFieldId).HasColumnName("TCustomFieldId");

                entity.Property(e => e.Cfid).HasColumnName("CFId");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.TcustomFieldName)
                    .HasColumnName("TCustomFieldName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transactionaccountdetails>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("ModifiedBy");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Description)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeId).HasColumnName("ExchangeID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.SenderOrReceiver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TransactionaccountdetailsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("transactionaccountdetails_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransactionaccountdetailsUser)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ChangepasswordFlag)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.IsAdminApproved)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsTokenExpiered)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LoginFailureCount).HasDefaultValueSql("'0'");

                entity.Property(e => e.MailingAddress)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.NextOtpdate).HasColumnName("NextOTPDate");

                entity.Property(e => e.Notes)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.OtpexpiryTime).HasColumnName("OTPExpiryTime");

                entity.Property(e => e.Otpvalue).HasColumnName("OTPValue");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImage)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePath)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SystemIp).HasColumnName("SystemIP");

                entity.Property(e => e.Token)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Updatepasswordcount).HasColumnName("updatepasswordcount");

                entity.Property(e => e.UserName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserNumber)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasIndex(e => e.CreatedBy)
                    .HasName("CreatedBy");

                entity.HasIndex(e => e.UpdatedBy)
                    .HasName("UpdatedBy");

                entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
