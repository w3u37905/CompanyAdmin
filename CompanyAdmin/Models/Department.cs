﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyAdmin.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MaxEmployees { get; set; }

    }
}