using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Views.DataContracts.Profiles
{
    [System.ComponentModel.DesignerCategory("")]
    public class GetUserProfile : View
    {
        public enum Fields
            {
                 Email = 0,
                 EntityContactKey = 1,
                 EntityLocationName = 2,
                 FirstName = 3,
                 LastName = 4,
                 Title = 5
            }

            public const Int16 EMAIL_MAXLENGTH = 50;
            public const Int16 ENTITYLOCATIONNAME_MAXLENGTH = 204;
            public const Int16 FIRSTNAME_MAXLENGTH = 30;
            public const Int16 LASTNAME_MAXLENGTH = 30;
            public const Int16 TITLE_MAXLENGTH = 50;

            private UserProfile DefaultValues(UserProfile row)
            {
                return row;
            }

            private int _entityContactKey = 0;

            private void Init()
            {
                var sql = new StringBuilder(@"SELECT dbo.tEntityContacts.EntityContactKey, dbo.tEntities.EntityName + ' - ' + dbo.tEntityLocations.LocationName + ISNULL(' ' + dbo.tEntityLocations.OrganizationalUnit, '') AS EntityLocationName, dbo.tEntityContacts.Title, dbo.tEntityContacts.FirstName, dbo.tEntityContacts.LastName, dbo.tEntityContacts.Email FROM dbo.tEntityContacts INNER JOIN dbo.tEntityLocations ON dbo.tEntityContacts.EntityLocationKey = dbo.tEntityLocations.EntityLocationKey INNER JOIN dbo.tEntities ON dbo.tEntityLocations.EntityKey = dbo.tEntities.EntityKey WHERE (dbo.tEntityContacts.EntityContactKey = @ENTITYCONTACTKEY)");

                base.AddParameterValue("@ENTITYCONTACTKEY", _entityContactKey.ToString());

                _view = sql.ToString();
                _source = "";
                _id = "EntityContactKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());
                base.Query();
            }

            public GetUserProfile(int entityContactKey)
            {
                _entityContactKey = entityContactKey;
                Init(); 
            }

            public UserProfile this[int index]
            {
                get { return (UserProfile)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new UserProfile(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(UserProfile);
            }

            public UserProfile NewUserProfile()
            {
                UserProfile row = (UserProfile)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class UserProfile : io.Data.ViewRow
            {

                internal UserProfile(DataRowBuilder rb, IView view) : base(rb, view)
                {
                }

                public string Email
                {
                    get { return this.DBString(Fields.Email.ToString()); }
                }

                public int EntityContactKey
                {
                    get { return this.DBInteger(Fields.EntityContactKey.ToString()); }
                }

                public string EntityLocationName
                {
                    get { return this.DBString(Fields.EntityLocationName.ToString()); }
                }

                public string FirstName
                {
                    get { return this.DBString(Fields.FirstName.ToString()); }
                }

                public string LastName
                {
                    get { return this.DBString(Fields.LastName.ToString()); }
                }

                public string Title
                {
                    get { return this.DBString(Fields.Title.ToString()); }
                }
            }
        }
    }
