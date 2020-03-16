using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2020_2_20demo1.Models
{
    public class Sales
    {
        public long Id { get; set; }
        public DateTime DateSold { get; set; }
        public long StoreId { get; set; }        
        public long CustomerId { get; set; }
        public long ProductId { get; set; }


    }
}