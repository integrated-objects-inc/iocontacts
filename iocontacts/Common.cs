using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.AppDomain;
using System.Collections.Specialized;
using System.Configuration;

namespace iocontacts
{
    internal static class Common
    {
        private static io.Systems.IOSystem _system;

        internal enum DataConnection
        {
            io_auth = 100,
            io_contacts = 101,
            io_tasks = 102,
            io_systemlog = 103
        }

        internal static io.Systems.IOSystem IOSystem
        {
            get 
            {
                if (_system == null)
                    _system = new io.Systems.IOSystem();

                return _system;
            }
        }

        internal static string SMTPServer()
        {
            try
            {
                NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                return section["SMTPServer"];
            }
            catch
            {
                return "";
            }
        }

        internal static string EmailUser()
        {
            try
            {
                NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                return section["EmailUser"];
            }
            catch
            {
                return "";
            }
        }

        internal static string EmailPassword()
        {
            try
            {
                NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                return section["EmailPassword"];
            }
            catch
            {
                return "";
            }
        }

        internal static string EmailFrom()
        {
            try
            {
                NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                return section["EmailFrom"];
            }
            catch
            {
                return "";
            }
        }

        internal static string SiteRoot()
        {
            try
            {
                NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
                return section["SiteRoot"];
            }
            catch
            {
                return "";
            }
        }
    }
}



