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
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Status> Status { get; set; }
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
                entity.HasKey(e => e.Guid)
                    .HasName("PK_ASSET_1");

                entity.ToTable("ASSET");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BatchGuid).HasColumnName("BATCH_GUID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("COMPANY_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectGuid).HasColumnName("PROJECT_GUID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.StoreGuid).HasColumnName("STORE_GUID");

                entity.HasOne(d => d.BatchGu)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.BatchGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_BATCH");

                entity.HasOne(d => d.ProjectGu)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.ProjectGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_PROJECT");

                entity.HasOne(d => d.StoreGu)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.StoreGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_STORE");
            });

            modelBuilder.Entity<AssetHistory>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("ASSET_HISTORY");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssetGuid).HasColumnName("ASSET_GUID");

                entity.Property(e => e.AssetStatus)
                    .HasColumnName("ASSET_STATUS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeptCode)
                    .HasColumnName("DEPT_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.TagId).HasColumnName("TAG_ID");

                entity.Property(e => e.UserCode)
                    .HasColumnName("USER_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AssetGu)
                    .WithMany(p => p.AssetHistory)
                    .HasForeignKey(d => d.AssetGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_HISTORY_ASSET");
            });

            modelBuilder.Entity<AssetOperations>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("ASSET_OPERATIONS");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssetGuid).HasColumnName("ASSET_GUID");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeptCode)
                    .HasColumnName("DEPT_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Initiater)
                    .HasColumnName("INITIATER")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUdatedBy)
                    .IsRequired()
                    .HasColumnName("LAST_UDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedTime)
                    .HasColumnName("LAST_UPDATED_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OperationStatus)
                    .HasColumnName("OPERATION_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.TagGuid).HasColumnName("TAG_GUID");

                entity.HasOne(d => d.AssetGu)
                    .WithMany(p => p.AssetOperations)
                    .HasForeignKey(d => d.AssetGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_OPERATIONS_ASSET");

                entity.HasOne(d => d.TagGu)
                    .WithMany(p => p.AssetOperations)
                    .HasForeignKey(d => d.TagGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_OPERATIONS_TAG");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_PURCHASE_REFERENCE_BATCH_DETAILS");

                entity.ToTable("BATCH");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssetSize)
                    .HasColumnName("ASSET_SIZE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AssetType)
                    .HasColumnName("ASSET_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BatchName)
                    .HasColumnName("BATCH_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BatchNo)
                    .HasColumnName("BATCH_NO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PurchaseBatchMasterGuid).HasColumnName("PURCHASE_BATCH_MASTER_GUID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.HasOne(d => d.PurchaseBatchMasterGu)
                    .WithMany(p => p.Batch)
                    .HasForeignKey(d => d.PurchaseBatchMasterGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BATCH_PURCHASE_ORDER");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_PROJECT_1");

                entity.ToTable("PROJECT");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("ADDRESS_LINE_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("ADDRESS_LINE_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityTown)
                    .HasColumnName("CITY_TOWN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasColumnName("CLIENT_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDateTime)
                    .HasColumnName("CREATE_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeptCode)
                    .HasColumnName("DEPT_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("date");

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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectHead)
                    .HasColumnName("PROJECT_HEAD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectSiteHead)
                    .HasColumnName("PROJECT_SITE_HEAD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.SiteHeadMobile)
                    .HasColumnName("SITE_HEAD_MOBILE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode)
                    .HasColumnName("USER_CODE")
                    .HasMaxLength(10)
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

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeptCode)
                    .HasColumnName("DEPT_CODE")
                    .HasMaxLength(10)
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

                entity.Property(e => e.PurchaseOrderDate)
                    .HasColumnName("PURCHASE_ORDER_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.PurchaseOrderNo)
                    .HasColumnName("PURCHASE_ORDER_NO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedBy)
                    .HasColumnName("RECEIVED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate)
                    .HasColumnName("RECEIVED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.UserCode)
                    .HasColumnName("USER_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("STATUS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("STORE");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MainStoreId).HasColumnName("MAIN_STORE_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");
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

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("COMPANY_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeptCode)
                    .HasColumnName("DEPT_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdatedBy)
                    .IsRequired()
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode)
                    .HasColumnName("USER_CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
