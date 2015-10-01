using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iocontacts
{
    static internal class Constants
    {
        static internal string CONST_SESSIONEXPIRED = "Session Expired.";
        static internal string CONST_NOTLOGGEDIN = "Not logged in.";

        internal const int SystemInstallKey = iosystem.Installation.SystemInstallKey;
        internal const int SystemKey = 1;
        internal const int AppKey = (int)iosystem.UseContext.AppKey.Webapp;
        internal const int AppKeyAsService = (int)iosystem.UseContext.AppKey.Service;
    }
}
