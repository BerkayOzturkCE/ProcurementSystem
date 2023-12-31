using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProcurementSystem.Api.Domain.Models;
using ProcurementSystem.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Infrastructure.Persistence.Context
{
    internal class SeedData
    {
        private static List<User> GetUsers()
        {
            var guids = Enumerable.Range(0, 1000).Select(i => Guid.NewGuid()).ToArray();
            int counter = 0;

            var result = new Faker<User>("tr").RuleFor(i => i.Id, i => guids[counter++])
                .RuleFor(i => i.CreatedDate, j => j.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.UpdatedDate, j => j.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.FirstName, j => j. Person.FirstName)
                .RuleFor(i => i.LastName, j => j.Person.LastName)
                .RuleFor(i => i.EmailAdress, (j, i) => j.Internet.Email(i.FirstName, i.LastName))
                .RuleFor(i => i.UserName, (j, i) => j.Internet.UserName(i.FirstName, i.LastName))
                .RuleFor(i => i.Password, j =>  PasswordEncryptor.Encrpt(j.Internet.Password()))
                .RuleFor(i => i.EmailConfirmed, j => j.PickRandom(true, false))
                .RuleFor(i => i.IsPassive, j => j.PickRandom(true, false))
                .RuleFor(i => i.CreatedById, (j,i) =>Guid.Parse("448d0bb2-ca4f-4221-bbce-b7b39cb36679"))
                .RuleFor(i => i.UpdatedById, (j, i) => Guid.Parse("448d0bb2-ca4f-4221-bbce-b7b39cb36679"))

                .Generate(500);
    
            return result;
        }

        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration["ProcurementSystemDBConnectionString"]);
            var context=new ProcurementSystemContext(dbContextBuilder.Options);
            var users = GetUsers();
            var userIds=users.Select(i => i.Id);
            await context.Users.AddRangeAsync(users);

            var guids= Enumerable.Range(0, 150).Select(i=> Guid.NewGuid()).ToArray();
            int counter = 0;

            var Orders = new Faker<Order>("tr")
                .RuleFor(i => i.Id, i => guids[counter++])
                .RuleFor(i => i.CreatedDate, i => i.Date.Between( DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.UpdatedDate, i => i.Date.Between( DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(i => i.Entry, i => i.Commerce.Product())
                .RuleFor(i => i.IsPassive, i => i.PickRandom(true, false))
                .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
                .RuleFor(i => i.UpdatedById, i => i.PickRandom(userIds))
                .Generate(150);
            await context.Orders.AddRangeAsync(Orders);

            var OrderIds = Orders.Select(i => i.Id);
            var Urls = Enumerable.Range(0, 150).Select(i => new Faker().Internet.Url());

            var OrderContent = new Faker<OrderContent>("tr")
               .RuleFor(i => i.Id, i => Guid.NewGuid())
               .RuleFor(i => i.CreatedDate, i => i.Date.Between( DateTime.Now.AddDays(-100), DateTime.Now))
               .RuleFor(i => i.UpdatedDate, i => i.Date.Between( DateTime.Now.AddDays(-100), DateTime.Now))
               .RuleFor(i => i.Description, i => i.Lorem.Paragraphs(2))
               .RuleFor(i => i.IsPassive, i => i.PickRandom(true, false))
               .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
               .RuleFor(i => i.UpdatedById, i => i.PickRandom(userIds))
               .RuleFor(i => i.OrderId, i => i.PickRandom(OrderIds))
               .RuleFor(i => i.Links, i => i.PickRandom(Urls))

               .Generate(150);
            await context.OrderContents.AddRangeAsync(OrderContent);

            await context.SaveChangesAsync();

        }
    }
}
