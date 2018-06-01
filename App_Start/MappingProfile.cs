﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using POC.Dto;
using POC.Models;

namespace POC.App_Start {
    public class MappingProfile : Profile {


        public MappingProfile()
        {
            Mapper.CreateMap<Customer,CustomerDto>();
            Mapper.CreateMap<CustomerDto,Customer>().ForMember(m=>m.Id,opt=>opt.Ignore());	;

}
     



    }

}