using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using io.Data;
using ioauth.Modules.Authentication;

namespace iocontacts.Modules.Profiles.UIControllers
{
    [ServiceContract(Namespace = "")]
    public interface IUserProfile
    {
        [OperationContract()]
        [WebInvoke()]
        UIControllerData.Result<Modules.Profiles.DataContracts.UpdatePasswordData> ChangePassword(string token, Modules.Profiles.DataContracts.UpdatePasswordData passwordData);

        [OperationContract()]
        [WebInvoke()]
        UIControllerData.Result<bool> PasswordExpired(string token);

        [OperationContract()]
        [WebInvoke()]
        UIControllerData.Result<Modules.Profiles.DataContracts.ForgotPasswordData> ForgotPassword(Modules.Profiles.DataContracts.ForgotPasswordData forgotPasswordData);

        [OperationContract()]
        [WebInvoke()]
        UIControllerData.Result<Modules.Profiles.DataContracts.ResetPasswordData> ResetPassword(Modules.Profiles.DataContracts.ResetPasswordData resetPasswordData);

        [OperationContract()]
        [WebInvoke()]
        UIControllerData.Result<Modules.Profiles.DataContracts.ProfileData> GetProfile(string token);
   }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserProfile : IUserProfile
    {
        public UIControllerData.Result<Modules.Profiles.DataContracts.UpdatePasswordData> ChangePassword(string token, Modules.Profiles.DataContracts.UpdatePasswordData passwordData)
        {
            var userSession = Authenticate.UserSession(token);

            if (userSession.Success)
                return Modules.Profiles.EntityContact.ChangePassword(userSession.Object, passwordData).ToUIControllerResult();
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized; // 401
                return new io.Data.Return<Modules.Profiles.DataContracts.UpdatePasswordData>(io.Constants.SUCCESS, userSession.Message, "", null).ToUIControllerResult();
            }
        }

        public UIControllerData.Result<Modules.Profiles.DataContracts.ResetPasswordData> ResetPassword(Modules.Profiles.DataContracts.ResetPasswordData resetPasswordData)
        {
            return Modules.Profiles.EntityContact.ResetPassword(resetPasswordData).ToUIControllerResult();
        }

        public UIControllerData.Result<bool> PasswordExpired(string token)
        {
            var userSession = Authenticate.UserSession(token);

            if (userSession.Success)
                return Modules.Profiles.EntityContact.PasswordExpired(userSession.Object).ToUIControllerResult();
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized; // 401
                return new io.Data.Return<bool>(io.Constants.SUCCESS, userSession.Message, "", false).ToUIControllerResult();
            }
        }

        public UIControllerData.Result<Modules.Profiles.DataContracts.ForgotPasswordData> ForgotPassword(Modules.Profiles.DataContracts.ForgotPasswordData forgotPasswordData)
        {
            return Modules.Profiles.EntityContact.ForgotPassword(forgotPasswordData).ToUIControllerResult();
        }

        public UIControllerData.Result<Modules.Profiles.DataContracts.ProfileData> GetProfile(string token)
        {
            var userSession = Authenticate.UserSession(token);

            if (userSession.Success)
                return Modules.Profiles.EntityContact.GetProfile(userSession.Object).ToUIControllerResult();
            else
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized; // 401
                return new io.Data.Return<Modules.Profiles.DataContracts.ProfileData>(io.Constants.SUCCESS, userSession.Message, "", null).ToUIControllerResult();
            }
        }
   }
}