using System.Diagnostics;
using Teretana.Models;

namespace Teretana.Database
{
    public class LogiranjeuSQLServer : ILog
    {
        public void Informacija()
        {
            Debug.WriteLine("Upisujem podatke u MSSQL");
        }
    }
}
