using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VSAssetManagement.Models
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
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<PurchaseReferenceBatchDetails> PurchaseReferenceBatchDetails { get; set; }
        public virtual DbSet<PurchaseReferenceBatchMaster> PurchaseReferenceBatchMaster { get; set; }
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
                entity.ToTable("ASSET");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchId)
                    .HasColumnName("BATCH_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

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

                entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.Property(e => e.Size).HasColumnName("SIZE");

                entity.Property(e => e.StoreId).HasColumnName("STORE_ID");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_PROJECT");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_STORE");
            });

            modelBuilder.Entity<AssetHistory>(entity =>
            {
                entity.ToTable("ASSET_HISTORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("ASSET_ID");

                entity.Property(e => e.AssetStatus)
                    .HasColumnName("ASSET_STATUS")
                    .HasMaxLength(30)
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

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetHistory)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_HISTORY_ASSET_HISTORY");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.AssetHistory)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_HISTORY_TAG");
            });

            modelBuilder.Entity<AssetOperations>(entity =>
            {
                entity.ToTable("ASSET_OPERATIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("ASSET_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

                entity.Property(e => e.TagId).HasColumnName("TAG_ID");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetOperations)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_OPERATIONS_ASSET");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.AssetOperations)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASSET_OPERATIONS_TAG");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("PROJECT");

                entity.Property(e => e.Id).HasColumnName("ID");

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

                entity.Property(e => e.CreateDateTime)
                    .HasColumnName("CREATE_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.GstinNo)
                    .HasColumnName("GSTIN_NO")
                    .HasMaxLength(30)
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
                    .HasMaxLength(30)
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
            });

            modelBuilder.Entity<PurchaseReferenceBatchDetails>(entity =>
            {
                entity.ToTable("PURCHASE_REFERENCE_BATCH_DETAILS");

                entity.Property(e => e.Id).HasColumnName("ID");

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
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasColumnName("LAST_UPDATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDateTime)
                    .HasColumnName("LAST_UPDATED_DATE_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseBatchMasterId).HasColumnName("PURCHASE_BATCH_MASTER_ID");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");

                entity.HasOne(d => d.PurchaseBatchMaster)
                    .WithMany(p => p.PurchaseReferenceBatchDetails)
                    .HasForeignKey(d => d.PurchaseBatchMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASE_REFERENCE_BATCH_DETAILS_MASTER");
            });

            modelBuilder.Entity<PurchaseReferenceBatchMaster>(entity =>
            {
                entity.ToTable("PURCHASE_REFERENCE_BATCH_MASTER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnName("CREATED_DATE_TIME")
                    .HasColumnType("datetime");

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

                entity.Property(e => e.ReceivedBy)
                    .HasColumnName("RECEIVED_BY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate)
                    .HasColumnName("RECEIVED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("STORE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MainStoreId).HasColumnName("MAIN_STORE_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordStatus).HasColumnName("RECORD_STATUS");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("TAG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(30)
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
