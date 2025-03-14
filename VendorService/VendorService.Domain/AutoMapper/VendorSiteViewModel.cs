using System.ComponentModel.DataAnnotations;
using VendorService.Domain.Models;

namespace VendorService.Domain.AutoMapper
{
    public class VendorSiteViewModel
    {

        [Required(ErrorMessage = "Mã tổ chức là bắt buộc.")]
        [Range(1, long.MaxValue, ErrorMessage = "Mã tổ chức phải là số nguyên dương.")]
        public decimal OrgId { get; set; }

        [Required(ErrorMessage = "Mã nhà cung cấp không được để trống.")]
        [Range(1, long.MaxValue, ErrorMessage = "Mã nhà cung cấp phải là số nguyên dương.")]
        public decimal VendorId { get; set; }

        [Key]
        [Required(ErrorMessage = "Mã địa chỉ nhà cung cấp không được để trống.")]
        [MaxLength(50, ErrorMessage = "Mã địa chỉ nhà cung cấp tối đa 50 ký tự.")]
        public string VendorSiteId { get; set; } = null!;

        [Required(ErrorMessage = "Mã định danh địa chỉ không được để trống.")]
        [MaxLength(50, ErrorMessage = "Mã định danh địa chỉ không được vượt quá 50 ký tự.")]
        public string VendorSiteCode { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "Mã địa chỉ thay thế không được vượt quá 50 ký tự.")]
        public string? VendorSiteCodeAlt { get; set; }

        [MaxLength(200, ErrorMessage = "Dòng địa chỉ 1 không được vượt quá 200 ký tự.")]
        public string? AddressLine1 { get; set; }

        [MaxLength(200, ErrorMessage = "Dòng địa chỉ 2 không được vượt quá 200 ký tự.")]
        public string? AddressLine2 { get; set; }

        [MaxLength(200, ErrorMessage = "Dòng địa chỉ 3 không được vượt quá 200 ký tự.")]
        public string? AddressLine3 { get; set; }

        [MaxLength(200, ErrorMessage = "Dòng địa chỉ 4 không được vượt quá 200 ký tự.")]
        public string? AddressLine4 { get; set; }

        [MaxLength(500, ErrorMessage = "Địa chỉ thay thế không được vượt quá 500 ký tự.")]
        public string? AddressLinesAlt { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Mã thành phố phải là số nguyên dương.")]
        public decimal? City { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Mã quận/huyện phải là số nguyên dương.")]
        public decimal? District { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Mã phường/xã phải là số nguyên dương.")]
        public decimal? Ward { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Số tài khoản ngân hàng phải là số nguyên dương.")]
        public decimal? BankAccountNum { get; set; }

        [MaxLength(50, ErrorMessage = "Loại tài khoản ngân hàng không được vượt quá 50 ký tự.")]
        public string? BankAccountType { get; set; }

        [MaxLength(50, ErrorMessage = "Loại chi nhánh ngân hàng không được vượt quá 50 ký tự.")]
        public string? BankBranchType { get; set; }

        [MaxLength(100, ErrorMessage = "Tên tài khoản ngân hàng không được vượt quá 100 ký tự.")]
        public string? BankAccountName { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Mã tài khoản công nợ phải trả phải là số nguyên dương.")]
        public decimal? AcctsPayCcid { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Mã tài khoản trả trước phải là số nguyên dương.")]
        public decimal? PrepayCcid { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 1 không được vượt quá 200 ký tự.")]
        public string? Attribute1 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 2 không được vượt quá 200 ký tự.")]
        public string? Attribute2 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 3 không được vượt quá 200 ký tự.")]
        public string? Attribute3 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 4 không được vượt quá 200 ký tự.")]
        public string? Attribute4 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 5 không được vượt quá 200 ký tự.")]
        public string? Attribute5 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 6 không được vượt quá 200 ký tự.")]
        public string? Attribute6 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 7 không được vượt quá 200 ký tự.")]
        public string? Attribute7 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 8 không được vượt quá 200 ký tự.")]
        public string? Attribute8 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 9 không được vượt quá 200 ký tự.")]
        public string? Attribute9 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 10 không được vượt quá 200 ký tự.")]
        public string? Attribute10 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 11 không được vượt quá 200 ký tự.")]
        public string? Attribute11 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 12 không được vượt quá 200 ký tự.")]
        public string? Attribute12 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 13 không được vượt quá 200 ký tự.")]
        public string? Attribute13 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 14 không được vượt quá 200 ký tự.")]
        public string? Attribute14 { get; set; }

        [MaxLength(200, ErrorMessage = "Trường mở rộng 15 không được vượt quá 200 ký tự.")]
        public string? Attribute15 { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Người cập nhật cuối cùng phải là số nguyên dương.")]
        public decimal? LastUpdatedBy { get; set; }

        [Required(ErrorMessage = "Ngày cập nhật cuối cùng không được để trống.")]
        public DateTime LastUpdateDate { get; set; }

        [Required(ErrorMessage = "Người tạo không được để trống.")]
        [Range(1, long.MaxValue, ErrorMessage = "Người tạo phải là số nguyên dương.")]
        public decimal CreatedBy { get; set; }

        [Required(ErrorMessage = "Ngày tạo không được để trống.")]
        public DateTime CreationDate { get; set; }

        public virtual VendorViewModel Vendor { get; set; } = null!;
    }
}