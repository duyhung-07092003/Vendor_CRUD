using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendorService.Domain.Models;

public partial class TblVendorSite
{
    public decimal OrgId { get; set; }

    public decimal VendorId { get; set; }

    [Key]
    public string VendorSiteId { get; set; } = null!;

    public string VendorSiteCode { get; set; } = null!;

    public string? VendorSiteCodeAlt { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? AddressLine4 { get; set; }

    public string? AddressLinesAlt { get; set; }

    public decimal? City { get; set; }

    public decimal? District { get; set; }

    public decimal? Ward { get; set; }

    public decimal? BankAccountNum { get; set; }

    public string? BankAccountType { get; set; }

    public string? BankBranchType { get; set; }

    public string? BankAccountName { get; set; }

    public decimal? AcctsPayCcid { get; set; }

    public decimal? PrepayCcid { get; set; }

    public string? Attribute1 { get; set; }

    public string? Attribute2 { get; set; }

    public string? Attribute3 { get; set; }

    public string? Attribute4 { get; set; }

    public string? Attribute5 { get; set; }

    public string? Attribute6 { get; set; }

    public string? Attribute7 { get; set; }

    public string? Attribute8 { get; set; }

    public string? Attribute9 { get; set; }

    public string? Attribute10 { get; set; }

    public string? Attribute11 { get; set; }

    public string? Attribute12 { get; set; }

    public string? Attribute13 { get; set; }

    public string? Attribute14 { get; set; }

    public string? Attribute15 { get; set; }

    public decimal? LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public decimal CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual TblVendor Vendor { get; set; } = null!;
}
