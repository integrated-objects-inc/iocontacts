using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.Data;

namespace iocontacts.Modules.Profiles
{
    public class Contacts
    {
        public static io.Data.Return<List<KeyValuePair<int, string>>> GetContacts()
        {
            return new io.Data.Return<List<KeyValuePair<int, string>>>(io.Constants.SUCCESS, "", "", null);
        }
    }
}
