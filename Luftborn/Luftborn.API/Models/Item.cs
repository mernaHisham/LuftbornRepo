using System;
using System.Collections.Generic;

namespace Luftborn.API.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
