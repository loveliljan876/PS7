using PS6.Areas.Data.Models;
using PS6.Pages.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Areas.Data
{
    public interface ILeapYearInterface
    {

        Task Save(HttpContext httpContext, YearResponse yearResponse);
        Task<List<YearValidationResult>> GetResults(int pageIndex);
    }
}
