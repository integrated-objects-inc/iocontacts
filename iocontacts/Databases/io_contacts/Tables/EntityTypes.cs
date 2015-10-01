using System;
using System.Text;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class EntityTypes : View
    {
        public enum Fields
            {
                 EntityTypeKey = 0,
                 EntityTypeName = 1
            }

            public const Int16 ENTITYTYPENAME_MAXLENGTH = 50;

            private EntityType DefaultValues(EntityType row)
            {
                return row;
            }

            public static io.Data.Return<EntityTypes.EntityType> GetObjectWithKey(int key)
            { 
                using(EntityTypes objects = new EntityTypes(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<EntityTypes.EntityType>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<EntityTypes.EntityType>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tEntityTypes";
                _source = @"tEntityTypes";
                _id = @"EntityTypeKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());

                base.Query();
            }

            public EntityTypes(int entityTypeKey, params Fields[] selectFields)
            {
                _where = "EntityTypeKey = " + entityTypeKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityTypes(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityTypes(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityTypes(int top, string where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public EntityType this[int index]
            {
                get { return (EntityType)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new EntityType(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(EntityType);
            }

            public EntityType NewEntityType()
            {
                EntityType row = (EntityType)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class EntityType : io.Data.ViewRow
            {

                internal EntityType(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public int EntityTypeKey
                {
                    get { return this.DBInteger(Fields.EntityTypeKey.ToString()); }
                }

                public string EntityTypeName
                {
                    get { return this.DBString(Fields.EntityTypeName.ToString()); }
                    set { this.SetDBString(Fields.EntityTypeName.ToString(), value, ENTITYTYPENAME_MAXLENGTH); }
                }
            }
        }
    }
