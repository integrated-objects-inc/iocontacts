using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class EntityLocations : View
    {
        public enum Fields
            {
                 AddressLine1 = 0,
                 AddressLine2 = 1,
                 DateCreated = 2,
                 EntityKey = 3,
                 EntityLocationKey = 4,
                 EntityLocationKey_Parent = 5,
                 LocationName = 6,
                 MailingAddressLine1 = 7,
                 MailingAddressLine2 = 8,
                 MailingZipCodeKey = 9,
                 OrganizationalUnit = 10,
                 ZipCodeKey = 11
            }

            public const Int16 ADDRESSLINE1_MAXLENGTH = 50;
            public const Int16 ADDRESSLINE2_MAXLENGTH = 50;
            public const Int16 LOCATIONNAME_MAXLENGTH = 50;
            public const Int16 MAILINGADDRESSLINE1_MAXLENGTH = 50;
            public const Int16 MAILINGADDRESSLINE2_MAXLENGTH = 50;
            public const Int16 ORGANIZATIONALUNIT_MAXLENGTH = 50;

            private EntityLocation DefaultValues(EntityLocation row)
            {
                return row;
            }

            public static io.Data.Return<EntityLocations.EntityLocation> GetObjectWithKey(int key)
            { 
                using(EntityLocations objects = new EntityLocations(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<EntityLocations.EntityLocation>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<EntityLocations.EntityLocation>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntityLocations";
                _source = @"tEntityLocations";
                _id = @"EntityLocationKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public EntityLocations(int entityLocationKey, params Fields[] selectFields)
            {
                _where = "EntityLocationKey = " + entityLocationKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocations(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocations(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocations(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityLocation this[int index]
            {
                get { return (EntityLocation)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EntityLocation(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(EntityLocation);
            }

            public EntityLocation NewEntityLocation()
            {
                EntityLocation row = (EntityLocation)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class EntityLocation : io.Data.ViewRow
            {

                internal EntityLocation(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public string AddressLine1
                {
                    get { return this.DBString(Fields.AddressLine1.ToString()); }
                    set { this.SetDBString(Fields.AddressLine1.ToString(), value, ADDRESSLINE1_MAXLENGTH); }
                }

                public string AddressLine2
                {
                    get { return this.DBString(Fields.AddressLine2.ToString()); }
                    set { this.SetDBString(Fields.AddressLine2.ToString(), value, ADDRESSLINE2_MAXLENGTH); }
                }

                public string DateCreated
                {
                    get { return this.DBDate(Fields.DateCreated.ToString()); }
                }

                public int EntityKey
                {
                    get { return this.DBInteger(Fields.EntityKey.ToString()); }
                    set { this.SetDBInteger(Fields.EntityKey.ToString(), value); }
                }

                public int EntityLocationKey
                {
                    get { return this.DBInteger(Fields.EntityLocationKey.ToString()); }
                }

                public int EntityLocationKey_Parent
                {
                    get { return this.DBInteger(Fields.EntityLocationKey_Parent.ToString()); }
                    set { this.SetDBInteger(Fields.EntityLocationKey_Parent.ToString(), value); }
                }

                public string LocationName
                {
                    get { return this.DBString(Fields.LocationName.ToString()); }
                    set { this.SetDBString(Fields.LocationName.ToString(), value, LOCATIONNAME_MAXLENGTH); }
                }

                public string MailingAddressLine1
                {
                    get { return this.DBString(Fields.MailingAddressLine1.ToString()); }
                    set { this.SetDBString(Fields.MailingAddressLine1.ToString(), value, MAILINGADDRESSLINE1_MAXLENGTH); }
                }

                public string MailingAddressLine2
                {
                    get { return this.DBString(Fields.MailingAddressLine2.ToString()); }
                    set { this.SetDBString(Fields.MailingAddressLine2.ToString(), value, MAILINGADDRESSLINE2_MAXLENGTH); }
                }

                public int MailingZipCodeKey
                {
                    get { return this.DBInteger(Fields.MailingZipCodeKey.ToString()); }
                    set { this.SetDBInteger(Fields.MailingZipCodeKey.ToString(), value); }
                }

                public string OrganizationalUnit
                {
                    get { return this.DBString(Fields.OrganizationalUnit.ToString()); }
                    set { this.SetDBString(Fields.OrganizationalUnit.ToString(), value, ORGANIZATIONALUNIT_MAXLENGTH); }
                }

                public int ZipCodeKey
                {
                    get { return this.DBInteger(Fields.ZipCodeKey.ToString()); }
                    set { this.SetDBInteger(Fields.ZipCodeKey.ToString(), value); }
                }
            }
        }
    }
