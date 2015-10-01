using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;

namespace iocontacts.Modules.Profiles.DataContracts
{
    [Serializable()]
    [DataContract()]
    public class ProfileData
    {
        private int _entityContactKey = 0;
        private string _entityLocationName = "";
        private string _firstName = "";
        private string _lastName = "";
        private string _title = "";
        private string _email = "";

        public ProfileData()
        { }

        public ProfileData Bind(Databases.io_contacts.Views.DataContracts.Profiles.GetUserProfile.UserProfile userProfile)
        {
            _entityContactKey = userProfile.EntityContactKey;
            _entityLocationName = userProfile.EntityLocationName;
            _firstName = userProfile.FirstName;
            _lastName = userProfile.LastName;
            _title = userProfile.Title;
            _email = userProfile.Email;
            return this;
        }

        [DataMember()]
        public int EntityContactKey
        {
            get { return _entityContactKey; }
            set { _entityContactKey = value; }
        }

        [DataMember()]
        public string EntityLocationName
        {
            get { return _entityLocationName; }
            set { _entityLocationName = value; }
        }

        [DataMember()]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [DataMember()]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DataMember()]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [DataMember()]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
