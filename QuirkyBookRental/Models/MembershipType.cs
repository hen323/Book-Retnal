﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Models
{
    public class MembershipType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("For One Month")]
        public Byte ChargeRateOneMonth { get; set; }

        [Required]
        [DisplayName("For Six Month")]
        public Byte ChargeRateSixMonth { get; set; }

        [Required]
        [DisplayName("Sign Up Fee")]
        [DataType(DataType.Currency)]
        public short SignUpFee { get; set; }
    }
}