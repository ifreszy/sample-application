using AutoMapper;
using DTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_application.Mappings
{
    
    public static class Mapper
    {
        private static MapperConfiguration ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                #region Entity To DTO
                cfg.CreateMap<UserModel, UserDTO>()
                    .ForSourceMember(x => x.Password, y => y.DoNotValidate());
                #endregion

                #region DTO To Entity
                cfg.CreateMap<UserDTO, UserModel>();
                #endregion
            });

            return config;
        }

        public static IMapper CreateMapper() => ConfigureMapper().CreateMapper();
    }
}
