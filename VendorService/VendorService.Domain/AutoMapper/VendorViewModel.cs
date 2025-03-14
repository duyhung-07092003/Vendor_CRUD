using System.ComponentModel.DataAnnotations;
using VendorService.Domain.Models;

namespace VendorService.Domain.AutoMapper
{
    public class VendorViewModel
    {
        public decimal? SetOfBooksId { get; set; }

        [Key]
        [Required(ErrorMessage = "ID nhà cung cấp không được để trống.")]
        public decimal VendorId { get; set; }

        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống.")]
        [StringLength(200, ErrorMessage = "Tên nhà cung cấp không được vượt quá 200 ký tự.")]
        public string? VendorName { get; set; }

        [Required(ErrorMessage = "Mã nhà cung cấp không được để trống.")]
        public decimal? Segment1 { get; set; }

        [Required(ErrorMessage = "Trạng thái kích hoạt không được để trống.")]
        public string? EnabledFlag { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu có hiệu lực không được để trống.")]
        public DateTime? StartDateActive { get; set; }

        public DateTime? EndDateActive { get; set; }

        [Required(ErrorMessage = "Loại nhà cung cấp không được để trống.")]
        public string? VendorTypeLookupCode { get; set; }

        public decimal? EmployeeId { get; set; }

        [StringLength(200, ErrorMessage = "Tên thay thế của nhà cung cấp không được vượt quá 200 ký tự.")]
        public string? VendorNameAlt { get; set; }

        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Mã số thuế phải là số từ 10 đến 15 ký tự.")]
        public string? VatRegistrationNum { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống.")]
        public string? Status { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute1 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute2 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute3 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute4 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute5 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute6 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute7 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute8 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute9 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute10 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute11 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute12 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute13 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute14 { get; set; }

        [StringLength(200, ErrorMessage = "Trường dự phòng không được vượt quá 200 ký tự.")]
        public string? Attribute15 { get; set; }

        [Required(ErrorMessage = "ID người cập nhật không được để trống.")]
        public decimal? LastUpdatedBy { get; set; }

        [Required(ErrorMessage = "Ngày cập nhật không được để trống.")]
        public DateTime LastUpdateDate { get; set; }

        [Required(ErrorMessage = "ID người tạo không được để trống.")]
        public decimal CreatedBy { get; set; }

        [Required(ErrorMessage = "Ngày tạo không được để trống.")]
        public DateTime CreationDate { get; set; }

        public virtual ICollection<VendorSiteViewModel> TblVendorSites { get; set; } = new List<VendorSiteViewModel>();
    }
}
