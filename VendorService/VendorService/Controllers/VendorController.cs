using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorService.Domain.Models;
using VendorService.Domain.AutoMapper;
using VendorService.Infrastructure.Repository;

namespace VendorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly VendorRepository _vendorRepository;

        public VendorController(VendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }
        // Lấy danh sách tất cả nhà cung cấp.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorViewModel>>> GetAllVendor()
        {
            var vendors = await _vendorRepository.GetAllVendors();
            return Ok(vendors);
        }

        // Lấy thông tin chi tiết nhà cung cấp theo ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorViewModel>> GetVendorById(decimal id)
        {
            if (id <= 0) 
                return BadRequest(new { message = "Mã nhà cung cấp không hợp lệ." });

            var vendor = await _vendorRepository.GetVendorById(id);
            if (vendor == null) 
                return NotFound(new { message = "Không tìm thấy nhà cung cấp." });

            return Ok(vendor);
        }

        // Tạo nhà cung cấp mới.
        [HttpPost]
        public async Task<ActionResult> CreateVendor([FromBody] VendorViewModel vendor)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                await _vendorRepository.CreateVendor(vendor);
                return CreatedAtAction(nameof(GetVendorById), new { id = vendor.VendorId }, new { message = "Thêm thành công", data = vendor });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }

        // Cập nhật thông tin nhà cung cấp theo ID.
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVendor(decimal id, [FromBody] VendorViewModel vendor)
        {
            if (id <= 0) 
                return BadRequest(new { message = "Mã nhà cung cấp không hợp lệ." });
            if (id != vendor.VendorId) 
                return BadRequest(new { message = "ID trong URL và dữ liệu không khớp." });
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var existingVendor = await _vendorRepository.GetVendorById(id);
            if (existingVendor == null) 
                return NotFound(new { message = "Không tìm thấy nhà cung cấp." });

            try
            {
                await _vendorRepository.UpdateVendor(vendor);
                return Ok(new { message = "Cập nhật thành công", data = vendor });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }

        // Xóa nhà cung cấp theo ID.
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVendor(decimal id)
        {
            if (id <= 0) 
                return BadRequest(new { message = "Mã nhà cung cấp không hợp lệ." });

            var existingVendor = await _vendorRepository.GetVendorById(id);
            if (existingVendor == null) 
                return NotFound(new { message = "Không tìm thấy nhà cung cấp." });

            try
            {
                await _vendorRepository.DeleteVendor(id);
                return Ok(new { message = "Xóa thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }
    }
}