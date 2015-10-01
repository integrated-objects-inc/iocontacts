using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iocontacts.Databases.io_contacts
{
    internal static class Database
    {
        internal static string Name
        {
            get { return "io_contacts"; }
        }

        internal static int ActiveConnection()
        {
            return Convert.ToInt32(Common.DataConnection.io_contacts);
        }

        internal static io.Data.Return<bool> RunNonQuery(string sql)
        {
            return RunNonQuery(sql, true);
        }

        internal static io.Data.Return<bool> RunNonQuery(string sql, bool noTimeout)
        {
            using (io.Database.Command cmd = new io.Database.Command(ActiveConnection(), sql, Common.IOSystem, noTimeout))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        internal static io.Data.Return<object> RunScalar(string sql)
        {
            return RunScalar(sql, true);
        }

        internal static io.Data.Return<object> RunScalar(string sql, bool noTimeout)
        {
            using (io.Database.Command cmd = new io.Database.Command(ActiveConnection(), sql, Common.IOSystem, true))
            {
                return cmd.ExecuteScalar();
            }
        }
    }
}
