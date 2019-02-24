using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AvorionTest.Models.Database
{
    public class TradeGood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public decimal? Volume { get; set; }
        public bool? IsIllegal { get; set; }
        [DisplayName("Is Dangerous")]
        public bool? IsDangerous { get; set; }
    }
}