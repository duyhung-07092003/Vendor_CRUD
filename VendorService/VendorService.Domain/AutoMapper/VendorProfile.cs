using VendorService.Domain.AutoMapper;
using AutoMapper;
using VendorService.Domain.Models;

namespace VendorService.Domain.AutoMapper
{
    public class VendorProfile : Profile
    {
        public VendorProfile() 
        {
            CreateMap<TblVendor, VendorViewModel>().ReverseMap();
            CreateMap<TblVendorSite, VendorSiteViewModel>().ReverseMap();
        }
    }
}
