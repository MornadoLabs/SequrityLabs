using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Web.Services
{
    public interface IRandomSequenceGenerator
    {
        List<long> GetNextSequencePart();
    }
}
