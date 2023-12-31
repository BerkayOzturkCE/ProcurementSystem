using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Api.Domain.Models
{
    public class OrderContent:BaseEntity
    {
        public string Description { get; set; }
        public string Links { get; set; }
        public int Piece { get; set; }
        public double UnitPrice { get; set; }
        public Guid OrderId { get; set; } 
        public virtual Order Order { get; set; }
    }
}
