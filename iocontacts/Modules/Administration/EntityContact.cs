using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iocontacts.Modules.Administration
{
    public static class EntityContact
    {
        internal enum ErrorCodes
        {
            QueryContactFailed = 3000,
            PasswordChangedSuccess = 3001,
            UpdatePasswordChangedFailed = 3002,
            QueryContactNoResult = 3003
        }

        private const string _className = "iocontacts.Modules.Administration";

        public static io.Data.Return<bool> SetPassword(int userSessionKey, int entityContactKey, string newPassword)
        {
            return SetPassword(userSessionKey, entityContactKey, newPassword, string.Empty, false);
        }

        public static io.Data.Return<bool> SetPassword(int userSessionKey, int entityContactKey, string newPassword, string oldPassword, bool compareOldPassword)
        {
            const string functionName = _className + ".SetPassword()";

            var validPasswordResult = ValidPassword(newPassword);

            if (validPasswordResult.Failed)
                return new io.Data.Return<bool>(io.Constants.FAILURE, validPasswordResult.Message, "", io.Constants.NO);

            using (Databases.io_contacts.Tables.EntityContacts rows = new Databases.io_contacts.Tables.EntityContacts(entityContactKey))
            {
                if (rows.QueryResult.Failed)
                    return new io.Data.Return<bool>(io.Constants.FAILURE, "Unable to change password, contact Administrator.", rows.QueryResult.Message, false).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, userSessionKey, (int)ErrorCodes.QueryContactFailed, functionName);

                if (rows.Count == 0)
                    return new io.Data.Return<bool>(io.Constants.FAILURE, "Unable to change password, contact Administrator.", rows.QueryResult.Message, false).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, userSessionKey, (int)ErrorCodes.QueryContactNoResult, functionName);

                if (compareOldPassword)
                {
                    if (rows[0].Password != GenerateHash(oldPassword, rows[0].EntityContactKey.ToString()))
                        return new io.Data.Return<bool>(io.Constants.FAILURE, "Invalid Password", "", false);
                }

                rows[0].Password = GenerateHash(newPassword, rows[0].EntityContactKey.ToString());
                rows[0].PasswordExpired = false;

                var updateResult = rows[0].UpdateRow();

                if (updateResult.Failed)
                    return new io.Data.Return<bool>(io.Constants.FAILURE, "Error changing password contact the administrator.", "", false).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, userSessionKey, (int)ErrorCodes.UpdatePasswordChangedFailed, functionName);

                return new io.Data.Return<bool>(io.Constants.SUCCESS, "Password changed successfully.", "", true).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, userSessionKey, (int)ErrorCodes.PasswordChangedSuccess, functionName);
            }
        }
        
        private static io.Data.Return<string> ValidPassword(string password)
        {
            try
            {
                bool badChars = false;
                string result = "";

                badChars = password.Contains("--"); 

                for (int i = 0; i < password.Length; i++)
                {
                    if ((int)password[i] < 33 || (int)password[i] > 127)
                    {
                        badChars = true;
                        break;
                    }

                    if (password[i] == ';')
                        badChars = true;
                }

                if (badChars)
                    result = "Invalid characters in password.";

                if (password.Length < 6 || password.Length > 20)
                {
                    if (result.Length > 0)
                        result += " ";
                    result += "Password must be 6-20 characters.";
                }


                if (result.Length > 0)
                    return new io.Data.Return<string>(io.Constants.FAILURE, result, result);
                else
                    return new io.Data.Return<string>(io.Constants.SUCCESS, result, result);
            }
            catch (Exception ex)
            {
                return new io.Data.Return<string>(io.Constants.FAILURE, "Invalid password specified.", "Invalid password specified.");
            }
        }

        private static string GenerateHash(string value, string salt)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(salt + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
