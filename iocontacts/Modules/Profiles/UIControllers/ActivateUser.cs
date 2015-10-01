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
    public interface IActivateUser
    {
        [OperationContract()]
        [WebInvoke()]
        UIControllerData.Result<Modules.Profiles.DataContracts.ActivateUserData> Submit(Modules.Profiles.DataContracts.ActivateUserData activateUserData);
   }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ActivateUser : IActivateUser
    {
        public UIControllerData.Result<Modules.Profiles.DataContracts.ActivateUserData> Submit(Modules.Profiles.DataContracts.ActivateUserData activateUserData)
        {
            return Modules.Profiles.ActivateUsers.Submit(activateUserData).ToUIControllerResult();
        }
   }
}