using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.Data;

namespace iocontacts.Modules.Profiles
{
    public static class ActivateUsers
    {
        public static Return<DataContracts.ActivateUserData> Submit(DataContracts.ActivateUserData activateUserData)
        {
            if (activateUserData.IsValid())   
                return new Return<DataContracts.ActivateUserData>(io.Constants.SUCCESS, "", "", activateUserData);
            else
                return new Return<DataContracts.ActivateUserData>(io.Constants.FAILURE, "", "", activateUserData);
        }
    }
}
