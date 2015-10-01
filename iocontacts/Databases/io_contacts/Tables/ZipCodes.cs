using System;
using System.Linq;
using System.Data;
using io.Data;
using io;

namespace iocontacts.Databases.io_contacts.Tables
{
    [System.ComponentModel.DesignerCategory("")]
    public class ZipCodes : View
    {
        public enum Fields
            {
                 City = 0,
                 CityAlias = 1,
                 County = 2,
                 State = 3,
                 Zipcode = 4,
                 ZipCodeKey = 5
            }

            public const Int16 CITY_MAXLENGTH = 50;
            public const Int16 CITYALIAS_MAXLENGTH = 50;
            public const Int16 COUNTY_MAXLENGTH = 255;
            public const Int16 STATE_MAXLENGTH = 2;
            public const Int16 ZIPCODE_MAXLENGTH = 5;

            private ZipCode DefaultValues(ZipCode row)
            {
                return row;
            }

            public static io.Data.Return<ZipCodes.ZipCode> GetObjectWithKey(int key)
            { 
                using(ZipCodes objects = new ZipCodes(key))
                {
                    if (objects.QueryResult.Success && objects.Count != 0)
                        return new io.Data.Return<ZipCodes.ZipCode>(io.Constants.SUCCESS,"","", objects[0]);
                    else
                        return new io.Data.Return<ZipCodes.ZipCode>(io.Constants.FAILURE, "", "", null);
                }
            }

            private void Init()
            {
                _view = @"tZipCodes";
                _source = @"tZipCodes";
                _id = @"ZipCodeKey";
                _ioSystem = iocontacts.Common.IOSystem;
                _connectionIndex = Convert.ToInt32(Databases.io_contacts.Database.ActiveConnection());
                base.Query();
            }

            public ZipCodes(int zipCodeKey, params Fields[] selectFields)
            {
                _where = "ZipCodeKey = " + zipCodeKey;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ZipCodes(string where, params Fields[] selectFields)
            {
                _where = where;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ZipCodes(string where, string orderBy, params Fields[] selectFields)
            {
                _where = where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ZipCodes(int top, string @where, string orderBy, params Fields[] selectFields)
            {
                _top = top;
                _where = @where;
                _orderBy = orderBy;
                _selectFields = selectFields.ToArray();
                Init();
            }

            public ZipCode this[int index]
            {
                get { return (ZipCode)this.Rows[index]; }
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ZipCode(builder, this);
            }

            protected override Type GetRowType()
            {
                return typeof(ZipCode);
            }

            public ZipCode NewZipCode()
            {
                ZipCode row = (ZipCode)this.NewRow();
                row = DefaultValues(row);
                this.Rows.Add(row);
                return row;
            }

            public class ZipCode : io.Data.ViewRow
            {

                internal ZipCode(DataRowBuilder rb, IView view)
                    : base(rb, view)
                {
                }

                public string City
                {
                    get { return this.DBString(Fields.City.ToString()); }
                    set { this.SetDBString(Fields.City.ToString(), value, CITY_MAXLENGTH); }
                }

                public string CityAlias
                {
                    get { return this.DBString(Fields.CityAlias.ToString()); }
                    set { this.SetDBString(Fields.CityAlias.ToString(), value, CITYALIAS_MAXLENGTH); }
                }

                public string County
                {
                    get { return this.DBString(Fields.County.ToString()); }
                    set { this.SetDBString(Fields.County.ToString(), value, COUNTY_MAXLENGTH); }
                }

                public string State
                {
                    get { return this.DBString(Fields.State.ToString()); }
                    set { this.SetDBString(Fields.State.ToString(), value, STATE_MAXLENGTH); }
                }

                public string Zipcode
                {
                    get { return this.DBString(Fields.Zipcode.ToString()); }
                    set { this.SetDBString(Fields.Zipcode.ToString(), value, ZIPCODE_MAXLENGTH); }
                }

                public int ZipCodeKey
                {
                    get { return this.DBInteger(Fields.ZipCodeKey.ToString()); }
                }
            }
        }
    }
