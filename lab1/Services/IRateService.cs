using NbrbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Services
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> GetRates(DateTime date);
    }
}
