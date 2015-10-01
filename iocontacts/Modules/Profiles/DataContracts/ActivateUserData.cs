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
    public class ActivateUserData : IUIControllerData
    {

        private UIData<string> _password = new UIData<string>(Types.String);
        private UIData<string> _uID = new UIData<string>(Types.String);
        private UIData<string> _email = new UIData<string>(Types.String);
        private UIData<string> _passwordConfirm = new UIData<string>(Types.String);

        public void Validate() 
        {
            try
            {
                _password.Validate(Validation.StringFormat.Plain, "Password Required", 20, true);
                _uID.Validate(Validation.StringFormat.Plain, "Id missing", 36, true);
                _email.Validate(Validation.StringFormat.Email, "Email required", 255, true);
                _passwordConfirm.Validate(Validation.StringFormat.Plain, "Password Confirm Required", 20, true);

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

                if (!_password.IsValid)
                    return io.Constants.NO;

                if (!_uID.IsValid)
                    return io.Constants.NO;

                if (!_email.IsValid)
                    return io.Constants.NO;

                if (!_passwordConfirm.IsValid)
                    return io.Constants.NO;

                return io.Constants.YES;
            }
            catch
            {
                // TODO: Log serialization failed.
                return io.Constants.NO;
            }
        }

        public ActivateUserData()
        { }

        [DataMember()]
        public UIData<string> Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember()]
        public UIData<string> UID
        {
            get { return _uID; }
            set { _uID = value; }
        }

        [DataMember()]
        public UIData<string> Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember()]
        public UIData<string> PasswordConfirm
        {
            get { return _passwordConfirm; }
            set { _passwordConfirm = value; }
        }
    }
}
