using MFF.DTO.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFF.DTO.Entities
{
    public class Product : GuIdEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
