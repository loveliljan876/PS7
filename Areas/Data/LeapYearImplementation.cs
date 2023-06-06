using Microsoft.EntityFrameworkCore;
using PS6.Areas.Data.Models;
using PS6.Areas.YearDb;
using PS6.Pages.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Areas.Data
{
    public class LeapYearImplementation : ILeapYearInterface
    {
        private readonly YearDbContext context;

        public LeapYearImplementation(PS6.Areas.YearDb.YearDbContext context)
        {
            this.context = context;
        }

        public async Task<List<YearValidationResult>> GetResults(int pageIndex)
        {
            var results = await PaginatedList<YearValidationResult>.CreateAsync(
            context.YearValidationResult.AsNoTracking(), pageIndex, 20);


            return results;
        }

        public async Task Save(HttpContext httpContext, YearResponse response)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = httpContext.User.Identity.Name;

            var yearValidationResult = new YearValidationResult
            {
                Year = response.Year,
                Result = response.ToString(),
                TimeAdded = DateTime.Now,
                UserId = userId,
                UserLogin = userName
            };

            context.YearValidationResult.Add(yearValidationResult);
            await context.SaveChangesAsync();
        }

        public Task Save(YearForm yearForm)
        {
            throw new NotImplementedException();
        }
    }
}
