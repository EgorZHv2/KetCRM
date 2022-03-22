using System;
using System.Collections.Generic;

namespace KetCRM.Domain.Entities
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Flat { get; set; }
        public Guid? PersonId { get; set; }
        public bool? ActualAddress { get; set; }

        public virtual Person? Person { get; set; }
    }
}
