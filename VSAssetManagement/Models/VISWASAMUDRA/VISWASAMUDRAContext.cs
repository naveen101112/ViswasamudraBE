using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSManagement.Models.VISWASAMUDRA
{
    public partial class VISWASAMUDRAContext : DbContext
    {
        public VISWASAMUDRAContext()
        {
        }

        public VISWASAMUDRAContext(DbContextOptions<VISWASAMUDRAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetHistory> AssetHistory { get; set; }
        public virtual DbSet<AssetOperations> AssetOperations { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<LookupType> LookupType { get; set; }
        public virtual DbSet<LookupTypeValue> LookupTypeValue { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Reason> Reason { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json");
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("VISWASAMUDRA"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("ASSET");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssetCode)
                    .IsRequired()
                    .HasColumnName("ASSET_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssetName)
                    .IsRequired()
                    .HasColumnName("ASSET_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetSpecification).HasColumnName("ASSET_SPECIFICATION");

                entity.Property(e => e.AssetType).HasColumnName("ASSET_TYPE");

                entity.Property(e => e.BatchNo)
                    .IsRequired()
                    .HasColumnName("BATCH_NO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProjectCode).HasColumnName("PROJECT_CODE");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Store).HasColumnName("STORE");

                entity.Property(e => e.StructureSubType).HasColumnName("STRUCTURE_SUB_TYPE");

                entity.Property(e => e.StructureType).HasColumnName("STRUCTURE_TYPE");

                entity.Property(e => e.TagId).HasColumnName("TAG_ID");
            });

            modelBuilder.Entity<AssetHistory>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("ASSET_HISTORY");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssetId).HasColumnName("ASSET_ID");

                entity.Property(e => e.AssetStatus)
                    .HasColumnName("ASSET_STATUS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TagId)
                    .IsRequired()
                    .HasColumnName("TAG_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AssetOperations>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("ASSET_OPERATIONS");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssetId)
                    .IsRequired()
                    .HasColumnName("ASSET_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetStatus)
                    .IsRequired()
                    .HasColumnName("ASSET_STATUS")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUdatedBy)
                    .HasColumnName("LAST_UDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedTime)
                    .HasColumnName("LAST_UPDATED_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ReferenceOperationId)
                    .HasColumnName("REFERENCE_OPERATION_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TagId)
                    .IsRequired()
                    .HasColumnName("TAG_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_PURCHASE_REFERENCE_BATCH_DETAILS");

                entity.ToTable("BATCH");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssetSpecification).HasColumnName("ASSET_SPECIFICATION");

                entity.Property(e => e.AssetType).HasColumnName("ASSET_TYPE");

                entity.Property(e => e.BatchDescription)
                    .HasColumnName("BATCH_DESCRIPTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchNo)
                    .IsRequired()
                    .HasColumnName("BATCH_NO")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.BatchQuantity).HasColumnName("BATCH_QUANTITY");

                entity.Property(e => e.BatchStatus)
                    .IsRequired()
                    .HasColumnName("BATCH_STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("INVOICE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasColumnName("INVOICE_NO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.ReceivedBy)
                    .IsRequired()
                    .HasColumnName("RECEIVED_BY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate)
                    .HasColumnName("RECEIVED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StructureSubType).HasColumnName("STRUCTURE_SUB_TYPE");

                entity.Property(e => e.StructureType).HasColumnName("STRUCTURE_TYPE");

                entity.Property(e => e.Uom).HasColumnName("UOM");

                entity.Property(e => e.UsageUom).HasColumnName("USAGE_UOM");

                entity.Property(e => e.UseFrequency).HasColumnName("USE_FREQUENCY");
            });

            modelBuilder.Entity<LookupType>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("LOOKUP_TYPE");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<LookupTypeValue>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("LOOKUP_TYPE_VALUE");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.LookupTypeId).HasColumnName("LOOKUP_TYPE_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.LookupType)
                    .WithMany(p => p.LookupTypeValue)
                    .HasForeignKey(d => d.LookupTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOOKUP_TYPE_VALUE_LOOKUP_TYPE");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("PROJECT");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("ADDRESS_LINE_1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("ADDRESS_LINE_2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CityTown)
                    .HasColumnName("CITY_TOWN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasColumnName("CLIENT_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDateTime)
                    .HasColumnName("CREATE_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.GstinNo)
                    .HasColumnName("GSTIN_NO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasColumnName("PROJECT_CODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectEndDate)
                    .HasColumnName("PROJECT_END_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("PROJECT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectSiteHead)
                    .HasColumnName("PROJECT_SITE_HEAD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStartDate)
                    .HasColumnName("PROJECT_START_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectType)
                    .HasColumnName("PROJECT_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SiteHeadMobile)
                    .HasColumnName("SITE_HEAD_MOBILE")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_PURCHASE_REFERENCE_BATCH_MASTER");

                entity.ToTable("PURCHASE_ORDER");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseOrderDate)
                    .HasColumnName("PURCHASE_ORDER_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.PurchaseOrderNo)
                    .HasColumnName("PURCHASE_ORDER_NO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseProject).HasColumnName("PURCHASE_PROJECT");

                entity.Property(e => e.PurchaseStore).HasColumnName("PURCHASE_STORE");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Reason>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("REASON");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReasonCode)
                    .IsRequired()
                    .HasColumnName("REASON_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonName)
                    .HasColumnName("REASON_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonType)
                    .HasColumnName("REASON_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("STORE");

                entity.HasIndex(e => e.Name)
                    .HasName("NAME_UNIQ_STORE")
                    .IsUnique();

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Incharge)
                    .HasColumnName("INCHARGE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InchargeMobile)
                    .HasColumnName("INCHARGE_MOBILE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParentStore).HasColumnName("PARENT_STORE");

                entity.Property(e => e.Project).HasColumnName("PROJECT");

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("TAG");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus)
                    .HasColumnName("RECORD_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
