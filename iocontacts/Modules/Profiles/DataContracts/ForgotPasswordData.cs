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
    public class ForgotPasswordData : IUIControllerData
    {
        public bool _IsValid { get; private set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Email == null)
                Email = new UIData<string>(Types.String);


            Validate();
        }

        public void Validate() 
        {
            try
            {
                Email.TrueType = Types.String;

                Email.Validate(Validation.StringFormat.Email, "Required", 255);

                _IsValid = io.Constants.YES;

                if (!Email.IsValid)
                    _IsValid = io.Constants.NO;
            }
            catch
            {

            }
        }

        public bool IsValid()
        {
            return _IsValid;
        }

        public ForgotPasswordData()
        { }

        [DataMember()]
        public UIData<string> Email { get; set; }
    }
}