using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VendorService.Domain.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblVendor> TblVendors { get; set; }

    public virtual DbSet<TblVendorSite> TblVendorSites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=adminuser;Password=matkhau123;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl21)))");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ADMINUSER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TblVendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("SYS_C008352");

            entity.ToTable("TBL_VENDORS");

            entity.Property(e => e.VendorId)
                .HasColumnType("NUMBER")
                .HasColumnName("VENDOR_ID");
            entity.Property(e => e.Attribute1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE1");
            entity.Property(e => e.Attribute10)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE10");
            entity.Property(e => e.Attribute11)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE11");
            entity.Property(e => e.Attribute12)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE12");
            entity.Property(e => e.Attribute13)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE13");
            entity.Property(e => e.Attribute14)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE14");
            entity.Property(e => e.Attribute15)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE15");
            entity.Property(e => e.Attribute2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE2");
            entity.Property(e => e.Attribute3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE3");
            entity.Property(e => e.Attribute4)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE4");
            entity.Property(e => e.Attribute5)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE5");
            entity.Property(e => e.Attribute6)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE6");
            entity.Property(e => e.Attribute7)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE7");
            entity.Property(e => e.Attribute8)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE8");
            entity.Property(e => e.Attribute9)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE9");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("NUMBER")
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("NUMBER")
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.EnabledFlag)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ENABLED_FLAG");
            entity.Property(e => e.EndDateActive)
                .HasColumnType("DATE")
                .HasColumnName("END_DATE_ACTIVE");
            entity.Property(e => e.LastUpdateDate)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("LAST_UPDATE_DATE");
            entity.Property(e => e.LastUpdatedBy)
                .HasColumnType("NUMBER")
                .HasColumnName("LAST_UPDATED_BY");
            entity.Property(e => e.Segment1)
                .HasColumnType("NUMBER")
                .HasColumnName("SEGMENT1");
            entity.Property(e => e.SetOfBooksId)
                .HasColumnType("NUMBER")
                .HasColumnName("SET_OF_BOOKS_ID");
            entity.Property(e => e.StartDateActive)
                .HasColumnType("DATE")
                .HasColumnName("START_DATE_ACTIVE");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.VatRegistrationNum)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("VAT_REGISTRATION_NUM");
            entity.Property(e => e.VendorName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("VENDOR_NAME");
            entity.Property(e => e.VendorNameAlt)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("VENDOR_NAME_ALT");
            entity.Property(e => e.VendorTypeLookupCode)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("VENDOR_TYPE_LOOKUP_CODE");
        });

        modelBuilder.Entity<TblVendorSite>(entity =>
        {
            entity.HasKey(e => e.VendorSiteId);

            entity.ToTable("TBL_VENDOR_SITES");

            entity.Property(e => e.VendorSiteId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VENDOR_SITE_ID");
            entity.Property(e => e.AcctsPayCcid)
                .HasColumnType("NUMBER")
                .HasColumnName("ACCTS_PAY_CCID");
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE1");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE2");
            entity.Property(e => e.AddressLine3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE3");
            entity.Property(e => e.AddressLine4)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE4");
            entity.Property(e => e.AddressLinesAlt)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINES_ALT");
            entity.Property(e => e.Attribute1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE1");
            entity.Property(e => e.Attribute10)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE10");
            entity.Property(e => e.Attribute11)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE11");
            entity.Property(e => e.Attribute12)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE12");
            entity.Property(e => e.Attribute13)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE13");
            entity.Property(e => e.Attribute14)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE14");
            entity.Property(e => e.Attribute15)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE15");
            entity.Property(e => e.Attribute2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE2");
            entity.Property(e => e.Attribute3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE3");
            entity.Property(e => e.Attribute4)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE4");
            entity.Property(e => e.Attribute5)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE5");
            entity.Property(e => e.Attribute6)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE6");
            entity.Property(e => e.Attribute7)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE7");
            entity.Property(e => e.Attribute8)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE8");
            entity.Property(e => e.Attribute9)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE9");
            entity.Property(e => e.BankAccountName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("BANK_ACCOUNT_NAME");
            entity.Property(e => e.BankAccountNum)
                .HasColumnType("NUMBER")
                .HasColumnName("BANK_ACCOUNT_NUM");
            entity.Property(e => e.BankAccountType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BANK_ACCOUNT_TYPE");
            entity.Property(e => e.BankBranchType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BANK_BRANCH_TYPE");
            entity.Property(e => e.City)
                .HasColumnType("NUMBER")
                .HasColumnName("CITY");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("NUMBER")
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.District)
                .HasColumnType("NUMBER")
                .HasColumnName("DISTRICT");
            entity.Property(e => e.LastUpdateDate)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("LAST_UPDATE_DATE");
            entity.Property(e => e.LastUpdatedBy)
                .HasColumnType("NUMBER")
                .HasColumnName("LAST_UPDATED_BY");
            entity.Property(e => e.OrgId)
                .HasColumnType("NUMBER")
                .HasColumnName("ORG_ID");
            entity.Property(e => e.PrepayCcid)
                .HasColumnType("NUMBER")
                .HasColumnName("PREPAY_CCID");
            entity.Property(e => e.VendorId)
                .HasColumnType("NUMBER")
                .HasColumnName("VENDOR_ID");
            entity.Property(e => e.VendorSiteCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VENDOR_SITE_CODE");
            entity.Property(e => e.VendorSiteCodeAlt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VENDOR_SITE_CODE_ALT");
            entity.Property(e => e.Ward)
                .HasColumnType("NUMBER")
                .HasColumnName("WARD");

            entity.HasOne(d => d.Vendor).WithMany(p => p.TblVendorSites)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_VENDOR_SITES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
