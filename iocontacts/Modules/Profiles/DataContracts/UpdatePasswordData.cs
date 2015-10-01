using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using io.Data;

namespace iocontacts.Modules.Profiles.DataContracts
{
    [Serializable()]
    [DataContract()]
    public class UpdatePasswordData : IUIControllerData
    {

        private UIData<string> _oldPassword = new UIData<string>(Types.String);
        private UIData<string> _newPassword = new UIData<string>(Types.String);
        private UIData<string> _repeatPassword = new UIData<string>(Types.String);

        public void Validate() 
        {
            try
            {
                _oldPassword.TrueType = Types.String;
                _newPassword.TrueType = Types.String;
                _repeatPassword.TrueType = Types.String;

                _oldPassword.Validate(Validation.StringFormat.Plain, "Required", 20);
                _newPassword.Validate(Validation.StringFormat.Plain, "Required", 20);
                _repeatPassword.Validate(Validation.StringFormat.Plain, "Required", 20);
            }
            catch
            {
            
            }
        }

        public bool IsValid()
        {
            try
            {
                Validate();

                if (!_oldPassword.IsValid)
                    return io.Constants.NO;

                if (!_newPassword.IsValid)
                    return io.Constants.NO;

                if (!_repeatPassword.IsValid)
                    return io.Constants.NO;

                return io.Constants.YES;
            }
            catch
            {
                return io.Constants.NO;
            }
        }

        public UpdatePasswordData()
        { }

        [DataMember()]
        public UIData<string> OldPassword
        {
            get { return _oldPassword; }
            set { _oldPassword = value; }
        }

        [DataMember()]
        public UIData<string> NewPassword
        {
            get { return _newPassword; }
            set { _newPassword = value; }
        }

        [DataMember()]
        public UIData<string> RepeatPassword
        {
            get { return _repeatPassword; }
            set { _repeatPassword = value; }
        }
    }
}
