using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendorService.Domain.Models;

public partial class TblVendor
{
    public decimal? SetOfBooksId { get; set; }

    [Key]
    public decimal VendorId { get; set; }

    public string? VendorName { get; set; }

    public decimal? Segment1 { get; set; }

    public string? EnabledFlag { get; set; }

    public DateTime? StartDateActive { get; set; }

    public DateTime? EndDateActive { get; set; }

    public string? VendorTypeLookupCode { get; set; }

    public decimal? EmployeeId { get; set; }

    public string? VendorNameAlt { get; set; }

    public string? VatRegistrationNum { get; set; }

    public string? Status { get; set; }

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

    public virtual ICollection<TblVendorSite> TblVendorSites { get; set; } = new List<TblVendorSite>();
}
