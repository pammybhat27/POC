﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using POC.Models;

namespace POC.Dto {
    public class CustomerDto {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

       // [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }


    }
}