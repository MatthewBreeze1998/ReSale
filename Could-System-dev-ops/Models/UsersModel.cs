﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Models
{
    public class UsersModel
    {
      
        public int UserId{ get; set; }

        public String FirstName { get; set; }
        public String lastName { get; set; }
        public String Email { get; set; }
        
        public bool isActive { get; set; }



    }
}