using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvorionTest.Models.Database
{
    public class TradeRecord
    {
        public int Id { get; set; }
        public int Station_Id { get; set; }
        public int TradeGood_Id { get; set; }
        public bool IsBuyable { get; set; }
        public int Price { get; set; }
        public int stock { get; set; }
        public int MaxStock { get; set; }
        public DateTime Timestamp { get; set; }
    }
}