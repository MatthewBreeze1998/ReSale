using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cloud_System_dev_ops.Models
{
    public class ReSaleModel
    {

        [Key]
        public int ReSaleId { get; set; }

        public int ProductId { get; set; }

        public Double CurrentPrice { get; set; }

        public DateTime CreationTime { get ; set; }

    }
}
