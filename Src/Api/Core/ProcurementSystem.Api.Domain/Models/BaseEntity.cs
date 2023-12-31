using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Api.Domain.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}
    public Guid UpdatedById {  get; set;}
    public Guid CreatedById { get; set;}
    public bool IsPassive { get; set; }
    public virtual User CreatedBy { get; set; }
    public virtual User UpdatedBy { get; set; }
}
