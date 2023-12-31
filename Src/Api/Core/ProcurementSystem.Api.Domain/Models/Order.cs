using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Api.Domain.Models
{
    public class Order:BaseEntity
    {
       public string Entry {  get; set; }
        public ICollection<OrderContent> Content { get; set; }


       

    }
}
