using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VS_EMPLOYEE
{
    public partial class VS_EMPLOYEEContext : DbContext
    {
        public VS_EMPLOYEEContext()
        {
        }

        public VS_EMPLOYEEContext(DbContextOptions<VS_EMPLOYEEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Deputation> Deputation { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<EmpTemp> EmpTemp { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public virtual DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual DbSet<EmployeeStatus> EmployeeStatus { get; set; }
        public virtual DbSet<EmployeestatusTemp> EmployeestatusTemp { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MigrationTemp> MigrationTemp { get; set; }
        public virtual DbSet<Salutation> Salutation { get; set; }
        public virtual DbSet<TblMigrationBand> TblMigrationBand { get; set; }
        public virtual DbSet<TblMigrationBank> TblMigrationBank { get; set; }
        public virtual DbSet<TblMigrationBranch> TblMigrationBranch { get; set; }
        public virtual DbSet<TblMigrationBranchaddress> TblMigrationBranchaddress { get; set; }
        public virtual DbSet<TblMigrationCategory> TblMigrationCategory { get; set; }
        public virtual DbSet<TblMigrationCity> TblMigrationCity { get; set; }
        public virtual DbSet<TblMigrationCompany> TblMigrationCompany { get; set; }
        public virtual DbSet<TblMigrationCountry> TblMigrationCountry { get; set; }
        public virtual DbSet<TblMigrationDepartment> TblMigrationDepartment { get; set; }
        public virtual DbSet<TblMigrationDeputation> TblMigrationDeputation { get; set; }
        public virtual DbSet<TblMigrationDesignation> TblMigrationDesignation { get; set; }
        public virtual DbSet<TblMigrationDivision> TblMigrationDivision { get; set; }
        public virtual DbSet<TblMigrationEmployee> TblMigrationEmployee { get; set; }
        public virtual DbSet<TblMigrationEmployeestatus> TblMigrationEmployeestatus { get; set; }
        public virtual DbSet<TblMigrationGrade> TblMigrationGrade { get; set; }
        public virtual DbSet<TblMigrationLocation> TblMigrationLocation { get; set; }
        public virtual DbSet<TblMigrationSalarygroup> TblMigrationSalarygroup { get; set; }
        public virtual DbSet<TblMigrationState> TblMigrationState { get; set; }
        public virtual DbSet<TblMigrationSubdepartment> TblMigrationSubdepartment { get; set; }
        public virtual DbSet<TblMigrationZone> TblMigrationZone { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<Zones> Zones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json");
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("VS_EMPLOYEE"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("BRANCH_PK");

                entity.ToTable("BRANCH");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneUid).HasColumnName("ZoneUID");

                entity.HasOne(d => d.ZoneU)
                    .WithMany(p => p.Branch)
                    .HasForeignKey(d => d.ZoneUid)
                    .HasConstraintName("BRANCH_ZONE_FK");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("COMPANY_PK");

                entity.ToTable("COMPANY");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("DEPARTMENT_PK");

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyUid).HasColumnName("CompanyUID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyU)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.CompanyUid)
                    .HasConstraintName("DEPARTMENT_COMPANY_FK");
            });

            modelBuilder.Entity<Deputation>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("DEPUTATION_PK");

                entity.ToTable("DEPUTATION");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentUid).HasColumnName("DepartmentUID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentU)
                    .WithMany(p => p.Deputation)
                    .HasForeignKey(d => d.DepartmentUid)
                    .HasConstraintName("DEPUTATION_DEPARTMENT_FK");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("DIVISION_PK");

                entity.ToTable("DIVISION");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyUid).HasColumnName("CompanyUID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyU)
                    .WithMany(p => p.Division)
                    .HasForeignKey(d => d.CompanyUid)
                    .HasConstraintName("DIVISION_COMPANY_FK");
            });

            modelBuilder.Entity<EmpTemp>(entity =>
            {
                entity.ToTable("EMP_TEMP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("EMPLOYEE_DETAILS_PK");

                entity.ToTable("EMPLOYEE_DETAILS");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UNIQUE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address1)
                    .HasColumnName("Address_1")
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("Address_2")
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailPersonal)
                    .HasColumnName("Email_Personal")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmailWork)
                    .HasColumnName("Email_Work")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmegAddress1)
                    .HasColumnName("Emeg_Address_1")
                    .IsUnicode(false);

                entity.Property(e => e.EmegAddress2)
                    .HasColumnName("Emeg_Address_2")
                    .IsUnicode(false);

                entity.Property(e => e.EmegCityName)
                    .HasColumnName("Emeg_CityName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmegContactName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmegEmailPersonal)
                    .HasColumnName("Emeg_Email_Personal")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmegHome)
                    .HasColumnName("Emeg_Home")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmegMobile)
                    .HasColumnName("Emeg_Mobile")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmegPinCode)
                    .HasColumnName("Emeg_Pin_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmegStateName)
                    .HasColumnName("Emeg_StateName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Handicap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Home)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaritalStatus)
                    .HasColumnName("Marital_Status")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Other)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PAddress1)
                    .HasColumnName("P_Address_1")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PAddress2)
                    .HasColumnName("P_Address_2")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PCityName)
                    .HasColumnName("P_CityName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PHome)
                    .HasColumnName("P_Home")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PMobile)
                    .HasColumnName("P_Mobile")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PPinCode)
                    .HasColumnName("P_Pin_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PStateName)
                    .HasColumnName("P_StateName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .HasColumnName("Pin_Code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Relation)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Smoker)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.WeddingAnniversary)
                    .HasColumnName("Wedding_Anniversary")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Unique)
                    .WithOne(p => p.EmployeeDetails)
                    .HasForeignKey<EmployeeDetails>(d => d.UniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYEE_DETAILS_EMPLOYEE_MASTER_FK");
            });

            modelBuilder.Entity<EmployeeMaster>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("EMPLOYEE_MASTER_PK");

                entity.ToTable("EMPLOYEE_MASTER");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdharName)
                    .HasColumnName("Adhar_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AdharNo)
                    .HasColumnName("Adhar_No")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasColumnName("Blood_Group")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Caste)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfJoining)
                    .HasColumnName("Date_of_Joining")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateofBirth)
                    .HasColumnName("Dateof_Birth")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("Employee_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FatherHusbandName)
                    .HasColumnName("Father_Husband_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("Middle_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceofBirth)
                    .HasColumnName("Placeof_Birth")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeRoles>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("EMPLOYEE_ROLES_PK");

                entity.ToTable("EMPLOYEE_ROLES");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("Branch_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("Company_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentCode)
                    .HasColumnName("Department_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DeputationCode)
                    .HasColumnName("Deputation_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DivisionCode)
                    .HasColumnName("Division_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeUid).HasColumnName("EmployeeUID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LocationCode)
                    .HasColumnName("Location_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrgChartReportingCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Salutation)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneCode)
                    .HasColumnName("Zone_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeU)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("BRANCH_ROLE_FK");

                entity.HasOne(d => d.EmployeeUNavigation)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("COMPANY_ROLE_FK");

                entity.HasOne(d => d.EmployeeU1)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("DEPARTMENT_ROLE_FK");

                entity.HasOne(d => d.EmployeeU2)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("DEPUTATION_ROLE_FK");

                entity.HasOne(d => d.EmployeeU3)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("DIVISION_ROLE_FK");

                entity.HasOne(d => d.EmployeeU4)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("ROLE_EMPLOYEE_MASTER_FK");

                entity.HasOne(d => d.EmployeeU5)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("LOCATIONS_ROLE_FK");

                entity.HasOne(d => d.EmployeeU6)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("SALUTATION_ROLE_FK");

                entity.HasOne(d => d.EmployeeU7)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeUid)
                    .HasConstraintName("ZONES_ROLE_FK");
            });

            modelBuilder.Entity<EmployeeStatus>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("EMPLOYEE_STATUS_PK");

                entity.ToTable("EMPLOYEE_STATUS");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UNIQUE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AttCardNumber)
                    .HasColumnName("AttCard_Number")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BandName)
                    .HasColumnName("Band_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmationDate)
                    .HasColumnName("Confirmation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CostCenterName)
                    .HasColumnName("CostCenter_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ctc)
                    .HasColumnName("CTC")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationName)
                    .HasColumnName("Designation_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatusCode)
                    .HasColumnName("EmployeeStatus_Code")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ExtConfirmationDate)
                    .HasColumnName("ExtConfirmation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FunctionalDesignation)
                    .HasColumnName("Functional_Designation")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.GradeName)
                    .HasColumnName("Grade_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Incentives)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InterviewerEmpCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoticePeriod)
                    .HasColumnName("Notice_Period")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OvertimeApplicable)
                    .HasColumnName("Overtime_Applicable")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PastExperience)
                    .HasColumnName("Past_Experience")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PayComponents)
                    .HasColumnName("Pay_Components")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PerformanceBonus)
                    .HasColumnName("Performance_Bonus")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProbationPeriod)
                    .HasColumnName("Probation_Period")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RelevantExperince)
                    .HasColumnName("Relevant_Experince")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryGroup)
                    .HasColumnName("Salary_Group")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryOnHold)
                    .HasColumnName("Salary_On_Hold")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryType)
                    .HasColumnName("Salary_Type")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SubDepartmentName)
                    .HasColumnName("SubDepartment_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TotalExperience)
                    .HasColumnName("Total_Experience")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Unique)
                    .WithOne(p => p.EmployeeStatus)
                    .HasForeignKey<EmployeeStatus>(d => d.UniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYEE_STATUS_EMPLOYEE_MASTER_FK");
            });

            modelBuilder.Entity<EmployeestatusTemp>(entity =>
            {
                entity.ToTable("EMPLOYEESTATUS_TEMP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("LOCATION_PK");

                entity.ToTable("LOCATIONS");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BranchUid).HasColumnName("BranchUID");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.BranchU)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.BranchUid)
                    .HasConstraintName("LOCATION_BRANCH_FK");
            });

            modelBuilder.Entity<MigrationTemp>(entity =>
            {
                entity.ToTable("MIGRATION_TEMP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Salutation>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("SALUTATION_PK");

                entity.ToTable("SALUTATION");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentUid).HasColumnName("DepartmentUID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentU)
                    .WithMany(p => p.Salutation)
                    .HasForeignKey(d => d.DepartmentUid)
                    .HasConstraintName("SALUTATION_DEPARTMENT_FK");
            });

            modelBuilder.Entity<TblMigrationBand>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_BAND");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BandCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BandName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationBank>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_BANK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationBranch>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_BRANCH");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationBranchaddress>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_BRANCHADDRESS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchAddressCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BranchAddressName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationCategory>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_CATEGORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationCity>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_CITY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationCompany>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_COMPANY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationCountry>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_COUNTRY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationDepartment>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_DEPARTMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationDeputation>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_DEPUTATION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeputationCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DeputationName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationDesignation>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_DESIGNATION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DesignationCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationDivision>(entity =>
            {
                entity.ToTable("TBL_MIGRATION_DIVISION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DivisionCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DivisionName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_EMPLOYEE");

                entity.Property(e => e.AadharName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AadharNumber)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Address1)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BankIfsccode)
                    .HasColumnName("BankIFSCCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasColumnName("Bank_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmationDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrAddress1)
                    .HasColumnName("Curr_Address_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrAddress2)
                    .HasColumnName("Curr_Address_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrCity)
                    .HasColumnName("Curr_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrEmailPersonal)
                    .HasColumnName("Curr_Email_Personal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrEmailWork)
                    .HasColumnName("Curr_Email_Work")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrHome)
                    .HasColumnName("Curr_Home")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrMobile)
                    .HasColumnName("Curr_Mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrOther)
                    .HasColumnName("Curr_Other")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrPinCode)
                    .HasColumnName("Curr_Pin_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrState)
                    .HasColumnName("Curr_State")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfJoining)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeputationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DivisionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergAddress1)
                    .HasColumnName("Emerg_Address_1")
                    .IsUnicode(false);

                entity.Property(e => e.EmergAddress2)
                    .HasColumnName("Emerg_Address_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergCity)
                    .HasColumnName("Emerg_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergEmailPersonal)
                    .HasColumnName("Emerg_Email_Personal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergEmailWork)
                    .HasColumnName("Emerg_Email_Work")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergHome)
                    .HasColumnName("Emerg_Home")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergMobile)
                    .HasColumnName("Emerg_Mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergOther)
                    .HasColumnName("Emerg_Other")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergPinCode)
                    .HasColumnName("Emerg_Pin_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergState)
                    .HasColumnName("Emerg_State")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatusId)
                    .HasColumnName("EmployeeStatus_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empsysid).HasColumnName("EMPSYSID");

                entity.Property(e => e.EsicApplicable)
                    .HasColumnName("ESIC_Applicable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsicGroup)
                    .HasColumnName("ESIC_Group")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EsicNumber)
                    .HasColumnName("ESIC_Number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionalDesignation)
                    .HasColumnName("Functional_Designation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionalDesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GradeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IfscCode)
                    .HasColumnName("IFSC_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsBranchEsicApplicable)
                    .HasColumnName("Is_Branch_ESIC_Applicable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isdaily).HasColumnName("ISDAILY");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastworkingDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoticePeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Panno)
                    .HasColumnName("PANNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PastExperience)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PfApplicable)
                    .HasColumnName("PF_Applicable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PfCeiling)
                    .HasColumnName("PF_Ceiling")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PfGroup)
                    .HasColumnName("PF_Group")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pfnumber)
                    .HasColumnName("PFNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentAddress1)
                    .HasColumnName("Prmnent_Address_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentAddress2)
                    .HasColumnName("Prmnent_Address_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentCity)
                    .HasColumnName("Prmnent_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentEmailPersonal)
                    .HasColumnName("Prmnent_Email_Personal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentEmailWork)
                    .HasColumnName("Prmnent_Email_Work")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentHome)
                    .HasColumnName("Prmnent_Home")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentMobile)
                    .HasColumnName("Prmnent_Mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentOther)
                    .HasColumnName("Prmnent_Other")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentPinCode)
                    .HasColumnName("Prmnent_Pin_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrmnentState)
                    .HasColumnName("Prmnent_State")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProbationPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PtApplicable)
                    .HasColumnName("PT_Applicable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ptgroup)
                    .HasColumnName("PTGroup")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RelevantExperince)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reporting1).HasColumnName("Reporting_1");

                entity.Property(e => e.Reporting2).HasColumnName("Reporting_2");

                entity.Property(e => e.Reporting3).HasColumnName("Reporting_3");

                entity.Property(e => e.ResignationDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryAccountNo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryBankBranch)
                    .HasColumnName("Salary_Bank_Branch")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubDepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubGradeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalExperience)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("UANNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vpfapplicable)
                    .HasColumnName("VPFApplicable")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vpfpercentage)
                    .HasColumnName("VPFPercentage")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMigrationEmployeestatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_EMPLOYEESTATUS");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeStatusCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatusName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_GRADE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GradeCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.GradeName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_LOCATION");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LocationCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMigrationSalarygroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_SALARYGROUP");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SalaryGroupCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryGroupName)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMigrationState>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_STATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMigrationSubdepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_SUBDEPARTMENT");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SubDepartmentCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SubDepartmentName)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMigrationZone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TBL_MIGRATION_ZONE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MigratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ZoneCode)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneName)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TEST");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasMaxLength(800)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("USER_LOGIN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoggedIn).HasColumnName("LOGGED_IN");

                entity.Property(e => e.OldPassword)
                    .HasColumnName("OLD_PASSWORD")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordReset).HasColumnName("PASSWORD_RESET");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WrongAttempt).HasColumnName("WRONG_ATTEMPT");
            });

            modelBuilder.Entity<Zones>(entity =>
            {
                entity.HasKey(e => e.UniqueId)
                    .HasName("ZONES_PK");

                entity.ToTable("ZONES");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("Unique_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DivisionCode)
                    .HasColumnName("divisionCode")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DivisionUid).HasColumnName("DivisionUID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("Is_Active")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.DivisionU)
                    .WithMany(p => p.Zones)
                    .HasForeignKey(d => d.DivisionUid)
                    .HasConstraintName("ZONES_DIVISION_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
