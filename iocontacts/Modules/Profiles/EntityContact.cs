using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ioauth.Modules.Authentication;
using iocontacts.Databases.io_contacts.Views.Middleware;

namespace iocontacts.Modules.Profiles
{
    public static class EntityContact
    {
        internal enum ErrorCodes
        {
            GetProfileFailed = 2000,
            QueryContactFailed = 2001
        }

        private const string _className = "iocontacts.Modules.Profiles";

        internal static io.Data.Return<DataContracts.UpdatePasswordData> ChangePassword(UserSession userSession, DataContracts.UpdatePasswordData passwordData)
        {
            if (!passwordData.IsValid())
                return new io.Data.Return<DataContracts.UpdatePasswordData>(io.Constants.FAILURE, "Invalid Password", "", passwordData);

            if (passwordData.NewPassword.Value != passwordData.RepeatPassword.Value)
                return new io.Data.Return<DataContracts.UpdatePasswordData>(io.Constants.FAILURE, "New Password must match", "", passwordData);

            var updatePassword = iocontacts.Modules.Administration.EntityContact.SetPassword(userSession.UserSessionKey, userSession.EntityContactKey, passwordData.NewPassword.Value, passwordData.OldPassword.Value, true);

            if (updatePassword.Failed)
                return new io.Data.Return<DataContracts.UpdatePasswordData>(io.Constants.FAILURE, updatePassword.Message, "", passwordData);

            return new io.Data.Return<DataContracts.UpdatePasswordData>(io.Constants.SUCCESS, updatePassword.Message, "", passwordData);
        }

        internal static io.Data.Return<DataContracts.ResetPasswordData> ResetPassword(DataContracts.ResetPasswordData passwordData)
        {
            const string functionName = _className + ".ResetPassword()";

            if (!passwordData.IsValid())
                return new io.Data.Return<DataContracts.ResetPasswordData>(io.Constants.FAILURE, "Check required fields", "", passwordData);

            Guid validGUID;
            if (!Guid.TryParse(passwordData.UID.Value.ToString(), out validGUID))
                return new io.Data.Return<DataContracts.ResetPasswordData>(io.Constants.FAILURE, "Check required fields", "", passwordData);

            if (passwordData.NewPassword.Value != passwordData.RepeatPassword.Value)
                return new io.Data.Return<DataContracts.ResetPasswordData>(io.Constants.FAILURE, "New Password must match", "", passwordData);

            var where = "(UID = '" + validGUID.ToString() + "')";
            int entityContactKey = 20;

            using (var rows = new Databases.io_contacts.Tables.EntityContacts(where, ""))
            {
                if (rows.QueryResult.Failed)
                    return new io.Data.Return<DataContracts.ResetPasswordData>(io.Constants.FAILURE, "Unable to change password, contact Administrator.", rows.QueryResult.Message, passwordData).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, 0, (int)ErrorCodes.QueryContactFailed, functionName);

                if (rows.Count == 0)
                    return new io.Data.Return<DataContracts.ResetPasswordData>(io.Constants.FAILURE, "Unable to change password, contact Administrator.", rows.QueryResult.Message, passwordData).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, 0, (int)ErrorCodes.QueryContactFailed, functionName);

                entityContactKey = rows[0].EntityContactKey;
            }
            
            var updatePassword = iocontacts.Modules.Administration.EntityContact.SetPassword(0, entityContactKey, passwordData.NewPassword.Value, passwordData.RepeatPassword.Value, false);

            if (updatePassword.Failed)
                return new io.Data.Return<DataContracts.ResetPasswordData>(io.Constants.FAILURE, updatePassword.Message, "", passwordData);

            return new io.Data.Return<DataContracts.ResetPasswordData>(io.Constants.SUCCESS, updatePassword.Message, "", passwordData);
        }

        internal static io.Data.Return<DataContracts.ForgotPasswordData> ForgotPassword(DataContracts.ForgotPasswordData forgotPasswordData)
        {
            const string functionName = _className + ".ForgotPassword()";

            if (!forgotPasswordData.IsValid())
                return new io.Data.Return<DataContracts.ForgotPasswordData>(io.Constants.FAILURE, "Invalid Email", "", forgotPasswordData);

            string where = "Email = '" + forgotPasswordData.Email.Value + "'";

            using (var rows = new iocontacts.Databases.io_contacts.Tables.EntityContacts(where, string.Empty))
            {
                if (rows.QueryResult.Failed)
                    return new io.Data.Return<DataContracts.ForgotPasswordData>(io.Constants.SUCCESS, "", "", forgotPasswordData);

                if (rows.Count == 0)
                    return new io.Data.Return<DataContracts.ForgotPasswordData>(io.Constants.SUCCESS, "", "", forgotPasswordData);

                string guid = rows[0].UID;

                rows[0].UID = Guid.NewGuid().ToString();

                if (rows[0].UpdateRow().Success)
                    guid = rows[0].UID;

                string rootSite = Common.SiteRoot();

                Email.SendEmail(0, rows[0].Email, "Forgot Password", "Click " + rootSite + "/changepassword.aspx?t=" + guid + " to change password.");
                    
                return new io.Data.Return<DataContracts.ForgotPasswordData>(io.Constants.SUCCESS, "", "", forgotPasswordData);
            }
        }

        internal static io.Data.Return<bool> PasswordExpired(UserSession userSession)
        {
            bool result = false;

            using (UserProfileExpiredPasswords rows = new UserProfileExpiredPasswords(userSession.EntityContactKey))
            {
                if (rows.QueryResult.Success && rows.Count != 0)
                    result = true;
            }

            return new io.Data.Return<bool>(io.Constants.SUCCESS, result ? "Password Expired" : "Password not Expired", "", result);
        }

        internal static io.Data.Return<iocontacts.Modules.Profiles.DataContracts.ProfileData> GetProfile(ioauth.Modules.Authentication.UserSession userSession)
        {
            var functionName = _className + ".GetProfile()";
            var result = new iocontacts.Modules.Profiles.DataContracts.ProfileData();

            using (var rows = new iocontacts.Databases.io_contacts.Views.DataContracts.Profiles.GetUserProfile(userSession.EntityContactKey))
            {
                if (rows.QueryResult.Failed)
                    return new io.Data.Return<iocontacts.Modules.Profiles.DataContracts.ProfileData>(io.Constants.FAILURE, "Unable to query database.", rows.QueryResult.Message, result).LogResult(Constants.SystemInstallKey, Constants.SystemKey, Constants.AppKey, userSession.UserSessionKey, (int)ErrorCodes.GetProfileFailed, functionName);

                if (rows.Count != 0)
                    result.Bind(rows[0]);

                return new io.Data.Return<iocontacts.Modules.Profiles.DataContracts.ProfileData>(io.Constants.SUCCESS, "", "", result);
            }
        }
    }
}
