using AutoMapper;
using D14_EFCore_DBFirst.Models;
using EFCore_DBFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_DBFirst.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //định nghĩa map theo 2 chiều .ReverseMap()
            CreateMap<HangHoa, HangHoaViewModel>()
                .ForMember(dest => dest.TenLoai, opt => opt.MapFrom(src => src.MaLoaiNavigation.TenLoai));
            //chỉ thuộc tính khác nhau ở 2 bên thì mới định nghĩa

            CreateMap<HangHoa, HangHoaKhuyenMai>()
                .ForMember(d => d.GiaBan, opt => opt.MapFrom(s => s.DonGia * (1 - s.GiamGia)));

            CreateMap<HangHoa, CartItem>()
                .ForMember(dest => dest.TenLoai, opt => opt.MapFrom(src => src.MaLoaiNavigation.TenLoai));
        }
    }
}
