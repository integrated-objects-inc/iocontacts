using System;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class Entities : View
    {
        public enum Fields
            {
                 AddressLine1 = 0,
                 AddressLine2 = 1,
                 AddressZipKey = 2,
                 DateCreated = 3,
                 EntityKey = 4,
                 EntityName = 5,
                 MailingAddressLine1 = 6,
                 MailingAddressLine2 = 7,
                 MailingZipKey = 8,
                 WebsiteUrl = 9
            }

            public const Int16 ADDRESSLINE1_MAXLENGTH = 100;
            public const Int16 ADDRESSLINE2_MAXLENGTH = 100;
            public const Int16 ENTITYNAME_MAXLENGTH = 100;
            public const Int16 MAILINGADDRESSLINE1_MAXLENGTH = 100;
            public const Int16 MAILINGADDRESSLINE2_MAXLENGTH = 100;
            public const Int16 WEBSITEURL_MAXLENGTH = 255;

            private Entity DefaultValues(Entity row)
            {
                return row;
            }

            public static io.Data.Return<Entities.Entity> GetObjectWithKey(int key)
            { 
                using(Entities objects = new Entities(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<Entities.Entity>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<Entities.Entity>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntities";
                _source = @"tEntities";
                _id = @"EntityKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());
                base.Query();
            }

            public Entities(int entityKey, params Fields[] selectFields)
            {
                _where = "EntityKey = " + entityKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Entities(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Entities(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Entities(int top, string @where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = @where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public Entity this[int index]
            {
                get { return (Entity)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Entity(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(Entity);
            }

            public Entity NewEntity()
            {
                Entity row = (Entity)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class Entity : io.Data.ViewRow
            {

                internal Entity(DataRowBuilder rb, IView view)
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

                public int AddressZipKey
                {
                    get { return this.DBInteger(Fields.AddressZipKey.ToString()); }
                    set { this.SetDBInteger(Fields.AddressZipKey.ToString(), value); }
                }

                public string DateCreated
                {
                    get { return this.DBDate(Fields.DateCreated.ToString()); }
                }

                public int EntityKey
                {
                    get { return this.DBInteger(Fields.EntityKey.ToString()); }
                }

                public string EntityName
                {
                    get { return this.DBString(Fields.EntityName.ToString()); }
                    set { this.SetDBString(Fields.EntityName.ToString(), value, ENTITYNAME_MAXLENGTH); }
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

                public int MailingZipKey
                {
                    get { return this.DBInteger(Fields.MailingZipKey.ToString()); }
                    set { this.SetDBInteger(Fields.MailingZipKey.ToString(), value); }
                }

                public string WebsiteUrl
                {
                    get { return this.DBString(Fields.WebsiteUrl.ToString()); }
                    set { this.SetDBString(Fields.WebsiteUrl.ToString(), value, WEBSITEURL_MAXLENGTH); }
                }
            }
        }
    }
