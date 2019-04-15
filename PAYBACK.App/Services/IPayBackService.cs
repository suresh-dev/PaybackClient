using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYBACK.App.Services
{
    public interface IPayBackService
    {
        string GetAccountBalance();

        string Authenticate();
    }
}
