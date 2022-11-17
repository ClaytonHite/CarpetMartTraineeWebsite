using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccessLayer
{
    public interface IDataAccess
    {
        object UpdateDataViaStoredProcedure(string storedProcName, Dictionary<string, object> parameters);
        object DeleteDataViaStoredProcedure(string storedProcName, Dictionary<string, object> parameters);
        DataTable PopulateDataTableViaStoredProcedure(string storedProcName, Dictionary<string, object> parameters);
    }
}
