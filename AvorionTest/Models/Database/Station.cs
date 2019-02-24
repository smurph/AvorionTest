using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvorionTest.Models.Database
{
    public class Station
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}