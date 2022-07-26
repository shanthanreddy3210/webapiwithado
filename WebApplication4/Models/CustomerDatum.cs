using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public partial class CustomerDatum
    {
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AlternateNumber { get; set; }
        public string? EmailId { get; set; }
        public string? Country { get; set; }
        public string? WhichState { get; set; }
        public string? District { get; set; }
        public string? Colony { get; set; }
        public string? HouseAddress { get; set; }
        public string? PostalCode { get; set; }

    }
}
