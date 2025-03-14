using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorService.Domain.AutoMapper;
using VendorService.Domain.Models;
using VendorService.Infrastructure.Repository;

namespace VendorService.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VendorSiteController : ControllerBase
    {
        private readonly VendorSiteRepository _vendorSiteRepository;

        public VendorSiteController(VendorSiteRepository vendorSiteRepository)
        {
            _vendorSiteRepository = vendorSiteRepository;
        }

        // Lấy danh sách tất cả địa chỉ nhà cung cấp.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorSiteViewModel>>> GetAllVendorSites()
        {
            var vendorSites = await _vendorSiteRepository.GetAllVendorSites();
            return Ok(vendorSites);
        }

        // Lấy thông tin địa chỉ nhà cung cấp theo ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorSiteViewModel>> GetVendorSitesById(string id)
        {
            if (string.IsNullOrEmpty(id)) 
                return BadRequest(new { message = "Mã địa chỉ nhà cung cấp không hợp lệ." });

            var vendorSites = await _vendorSiteRepository.GetVendorSitesById(id);
            if (vendorSites == null) 
                return NotFound(new { message = "Không tìm thấy địa chỉ nhà cung cấp." });

            return Ok(vendorSites);
        }

        // Tạo địa chỉ nhà cung cấp mới.
        [HttpPost]
        public async Task<ActionResult> CreateVendorSites([FromBody] VendorSiteViewModel vendorSites)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                await _vendorSiteRepository.CreateVendorSites(vendorSites);
                return CreatedAtAction(nameof(GetVendorSitesById), new { id = vendorSites.VendorSiteId }, new { message = "Thêm thành công", data = vendorSites });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }

        // Cập nhật thông tin địa chỉ nhà cung cấp.
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVendorSites(string id, [FromBody] VendorSiteViewModel vendorSites)
        {
            if (string.IsNullOrEmpty(id)) 
                return BadRequest(new { message = "Mã địa chỉ nhà cung cấp không hợp lệ." });
            if (id != vendorSites.VendorSiteId) 
                return BadRequest(new { message = "ID trong URL và dữ liệu không khớp." });
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var existingVendorSite = await _vendorSiteRepository.GetVendorSitesById(id);
            if (existingVendorSite == null) 
                return NotFound(new { message = "Không tìm thấy địa chỉ nhà cung cấp." });

            try
            {
                await _vendorSiteRepository.UpdateVendorSites(vendorSites);
                return Ok(new { message = "Cập nhật thành công", data = vendorSites });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }

        // Xóa địa chỉ nhà cung cấp.
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVendorSites(string id)
        {
            if (string.IsNullOrEmpty(id)) 
                return BadRequest(new { message = "Mã địa chỉ nhà cung cấp không hợp lệ." });

            var existingVendorSite = await _vendorSiteRepository.GetVendorSitesById(id);
            if (existingVendorSite == null) 
                return NotFound(new { message = "Không tìm thấy địa chỉ nhà cung cấp." });

            try
            {
                await _vendorSiteRepository.DeleteVendorSites(id);
                return Ok(new { message = "Xóa thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server", error = ex.Message });
            }
        }
    }
}