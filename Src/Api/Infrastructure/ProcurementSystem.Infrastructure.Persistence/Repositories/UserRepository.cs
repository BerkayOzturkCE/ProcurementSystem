using ProcurementSystem.Api.Application.Interfaces.Repositories;
using ProcurementSystem.Api.Domain.Models;
using ProcurementSystem.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ProcurementSystemContext dbContext) : base(dbContext)
    {
    }
}
