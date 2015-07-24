using System;
using System.Data;
using System.Data.SqlClient;
using Siteyonetim.Framework.Data;
using System.Data.SqlTypes;


namespace Siteyonetim.Framework.Data
{
    public static class DataHelper
    {
        public static DateTime SqlDateTimeMinValue = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        public static object CheckNull(int obj)
        {
            if (NullValue.IsNull(obj))
                return null;
            return obj;
        }



        #region ReadMethods
        public static Uri ReadUri(DataRow dr, string columnName)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return new Uri((string)dr[columnName]);
            return null;
        }

        public static string ReadString(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return (string)dr[ColumnOrder];
            else
                return null;
        }

        public static string ReadString(DataRow dr, string columnName)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return dr[columnName].ToString();
            return null;
        }

        public static char ReadChar(DataRow dr, string columnName)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToChar(dr[columnName]);
            return '\0';
        }

        public static string ReadGlobalString(IDataReader dr, string columnName)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return dr[columnName].ToString().Replace(",", ".");
                else
                    return null;
            }
            catch//(IndexOutOfRangeException)
            {
                return null;
            }
        }

        public static int? ReadIntNullable(DataRow dr, string ColumnName)
        {
            if (dr[ColumnName] != DBNull.Value)
                return (int)dr[ColumnName];
            else return null;
        }

        public static short? ReadShortNullable(DataRow dr, string ColumnName)
        {
            if (dr[ColumnName] != DBNull.Value)
                return (short)dr[ColumnName];
            else return null;
        }

        public static string ReadStr(IDataReader dr, int columnOrder)
        {
            if (dr[columnOrder] != DBNull.Value)
                return dr[columnOrder].ToString();
            else
                return null;
        }

        public static string ReadStrCommaToDot(IDataReader dr, int columnOrder)
        {
            if (dr[columnOrder] != DBNull.Value)
                return dr[columnOrder].ToString().Replace(",", ".");
            else
                return null;
        }

        public static string ReadGlobalString(DataRow dr, int order)
        {
            if (dr[order] != DBNull.Value)
                return dr[order].ToString().Replace(",", ".");
            return null;
        }

        public static string ReadString(IDataReader dr, string columnName)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return (string)dr[columnName];
                else
                    return null;
            }
            catch//(IndexOutOfRangeException)
            {
                return null;
            }
        }        

        public static decimal ReadDecimal(DataRow dr, string columnName)
        {
            return ReadDecimal(dr, columnName, 0);
        }

        public static decimal ReadDecimal(DataRow dr, string columnName, decimal defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToDecimal(dr[columnName]);
            return defaultValue;
        }

        public static decimal ReadDecimal(IDataReader dr, string columnName)
        {
            return ReadDecimal(dr, columnName, 0);
        }

        public static decimal ReadDecimal(IDataReader dr, string columnName, decimal defaultValue)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToDecimal(dr[columnName]);
                else
                    return defaultValue;
            }
            catch//(IndexOutOfRangeException)
            {
                return defaultValue;
            }
        }

        public static Decimal? ReadDecimalNullable(IDataReader dr, int ColumnOrder)
        {

            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToDecimal(dr[ColumnOrder]);
            else
                return null;

        }

        public static decimal ReadDecimal(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToDecimal(dr[ColumnOrder]);
            else
                return 0;
        }

        public static bool ReadBool(DataRow dr, string columnName)
        {
            return ReadBool(dr, columnName, false);
        }

        public static bool ReadBool(DataRow dr, string columnName, bool defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (bool)dr[columnName];
            return defaultValue;
        }

        public static bool? ReadNullBool(DataRow dr, string columnName)
        {
            return ReadNullBool(dr, columnName, null);
        }

        public static bool? ReadNullBool(DataRow dr, string columnName, bool? defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (bool)dr[columnName];
            return defaultValue;
        }

        public static bool ReadBool(IDataReader dr, string columnName)
        {
            return ReadBool(dr, columnName, false);
        }

        public static bool ReadBool(IDataReader dr, string columnName, bool defaultValue)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return (bool)dr[columnName];
                else
                    return defaultValue;
            }
            catch//(IndexOutOfRangeException)
            {
                return defaultValue;
            }
        }

        public static bool ReadBool(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return (bool)dr[ColumnOrder];
            else
                return false;
        }

        public static byte ReadByte(DataRow dr, string columnName)
        {
            return ReadByte(dr, columnName, Byte.MinValue);
        }

        public static byte ReadByte(DataRow dr, string columnName, byte defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (byte)dr[columnName];
            return defaultValue;
        }

        public static byte[] ReadByteArray(DataRow dr, string columnName)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (byte[])dr[columnName];
            return null;
        }

        public static byte[] ReadByteArray(IDataReader dr, string columnName)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return (byte[])dr[columnName];
                else
                    return null;
            }
            catch//(IndexOutOfRangeException)
            {
                return null;
            }
        }

        public static byte[] ReadByteArray(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return (byte[])dr[ColumnOrder];
            else
                return null;
        }

        public static int ReadInt(IDataReader dr, string columnName)
        {
            return ReadInt32(dr, columnName, Int32.MinValue);
        }
        public static int ReadInt(DataRow dr, string columnName)
        {
            return ReadInt32(dr, columnName, Int32.MinValue);
        }
        public static int ReadInt(DataRow dr, int columnOrder)
        {
            return ReadInt32(dr, columnOrder, Int32.MinValue);
        }
        public static int ReadInt32(DataRow dr, string columnName)
        {
            return ReadInt32(dr, columnName, Int32.MinValue);
        }
        public static Int64 ReadInt64(DataRow dr, string columnName)
        {
            return ReadInt64(dr, columnName, Int64.MinValue);
        }

        #region guid
        public static Guid ReadGuid(DataRow dr, string columnName)
        {
            return ReadGuid(dr, columnName, Guid.Empty);
        }

        public static Guid? ReadGuidNullable(IDataReader dr, string columnName)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return (Guid)dr[columnName];
                else
                    return null;
            }
            catch//(IndexOutOfRangeException)
            {
                return null;
            }
        }

        public static Guid? ReadGuidNullable(DataRow dr, string columnName)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (Guid)dr[columnName];
            return null;
        }

        public static Guid? ReadGuidNullable(DataRow dr, int columnOrder)
        {
            if (dr[columnOrder] != DBNull.Value)
                return (Guid)dr[columnOrder];
            return null;
        }

        public static Guid ReadGuid(DataRow dr, string columnName, Guid defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (Guid)dr[columnName];
            return defaultValue;
        }

        public static Guid ReadGuid(DataRow dr, int columnOrder)
        {
            if (dr[columnOrder] != DBNull.Value)
                return (Guid)dr[columnOrder];
            else
                return Guid.Empty;
        }
        #endregion

        public static int ReadInt32(DataRow dr, int ColumnOrder, int defaultValue)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToInt32(dr[ColumnOrder]);
            else
                return defaultValue;
        }
        public static int ReadInt32(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToInt32(dr[ColumnOrder]);
            else
                return 0;
        }
        public static int ReadInt32(DataRow dr, string columnName, int defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToInt32(dr[columnName]);
            return defaultValue;
        }
        public static Int64 ReadInt64(DataRow dr, string columnName, Int64 defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToInt64(dr[columnName]);
            return defaultValue;
        }

        public static int ReadInt32(IDataReader dr, string columnName, int defaultValue)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToInt32(dr[columnName]);
                else
                    return defaultValue;
            }
            catch//(IndexOutOfRangeException)
            {
                return defaultValue;
            }
        }
        public static Int64 ReadInt64DataReader(IDataReader dr, string columnName, Int64 defaultValue)
        {
            try
            {
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToInt64(dr[columnName]);
                else
                    return defaultValue;
            }
            catch//(IndexOutOfRangeException)
            {
                return defaultValue;
            }
        }

        public static TimeSpan ReadTime(DataRow dr, string columnName)
        {
            return ReadTime(dr, columnName, TimeSpan.MinValue);
        }

        public static DateTime ReadDateTime(DataRow dr, string columnName)
        {
            return ReadDate(dr, columnName, DateTime.MinValue);
        }

        public static DateTime ReadDateTime(IDataReader dr, string columnName)
        {
            return ReadDate(dr, columnName, DateTime.MinValue);
        }
        public static DateTime ReadDate(DataRow dr, string columnName)
        {
            return ReadDate(dr, columnName, DateTime.MinValue);
        }
        public static DateTime ReadDate(IDataReader dr, string columnName, DateTime defaultValue)
        {
            if (dr[columnName] != DBNull.Value)
                return (DateTime)dr[columnName];
            else
                return defaultValue;
        }
        public static DateTime ReadDate(IDataReader dr, int columnOrder, DateTime defaultValue)
        {
            if (dr[columnOrder] != DBNull.Value)
                return (DateTime)dr[columnOrder];
            else
                return defaultValue;
        }

        public static DateTime? ReadDateTimeNullable(DataRow dr, string columnName)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (DateTime)dr[columnName];
            return null;
        }

        public static DateTime? ReadDateNullable(IDataReader dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return (DateTime)dr[ColumnOrder];
            else
                return null;
        }

        public static DateTime ReadDateTime(IDataReader dr, string columnName, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return (DateTime)dr[ColumnOrder];
            else
                throw new Exception(columnName + "kolunu bulunamadı");
        }
        public static TimeSpan ReadTime(DataRow dr, string columnName, TimeSpan defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (TimeSpan)dr[columnName];
            return defaultValue;
        }

        public static DateTime ReadDate(DataRow dr, string columnName, DateTime defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (DateTime)dr[columnName];
            return defaultValue;
        }
        public static DateTime ReadDate(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return (DateTime)dr[ColumnOrder];
            else
                return DateTime.MinValue;
        }

        #endregion

        public static SqlParameter MakeIntParam(string name, SqlDbType sqlType, int size, object value)
        {
            return MakeParam(name, sqlType, size, ParameterDirection.Input, value);
        }

        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        public static SqlDateTime MakeDateParam(DateTime d)
        {
            if (d == DateTime.MinValue || (DateTime)SqlDateTime.MinValue >= d) return SqlDateTime.Null;
            else return d;
        }

        public static object MakeByteArrayParam(byte[] d)
        {
            if (d == null || d.Length < 1)
                return DBNull.Value;
            else
                return d;
        }

        public static object MakeBoolParam(bool? d)
        {
            if (d == null)
                return DBNull.Value;
            else
                return d;
        }

        public static object MakeGuidParam(Guid? d)
        {
            if (d == null || d == Guid.Empty)
                return DBNull.Value;
            else
                return d;
        }

        public static object MakeStringParam(string d, int length = 0)
        {
            if (string.IsNullOrWhiteSpace(d))
                return DBNull.Value;
            else
            {
                if (length > 0 && d.Length > length)
                    return d.Substring(0, length);
                else
                    return d;
            }
        }

        public static object MakeDecimalParam(decimal d)
        {
            return d;
        }

        public static object MakeIntParam(int d)
        {
            return d;
        }

        public static object HandleDBNullValue(Object obj, Object defaultValue = null)
        {
            if (defaultValue == null)
                defaultValue = DBNull.Value;
            if (obj == null)
                return defaultValue;
            else
                return obj;
        }

        public static object MakeInt32Param(Int32 d, Int32 minValue = Int32.MinValue)
        {
            if (d < minValue)
                return DBNull.Value;
            return d;
        }

        #region long
        /// <summary>
        /// Int64
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static long ReadLong(DataRow dr, string columnName)
        {
            return ReadLong(dr, columnName, long.MinValue);
        }

        /// <summary>
        /// Int64
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ReadLong(DataRow dr, string columnName, long defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToInt64(dr[columnName]);
            return defaultValue;
        }

        /// <summary>
        /// Int64
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="ColumnOrder"></param>
        /// <returns></returns>
        public static long ReadLong(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToInt64(dr[ColumnOrder]);
            else
                return 0;
        }

        /// <summary>
        /// Int64
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static long? ReadLongNullable(DataRow dr, string columnName)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return (long)dr[columnName];
            return null;
        }

        /// <summary>
        /// Int64
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="ColumnOrder"></param>
        /// <returns></returns>
        public static long? ReadLongNullable(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return (long)dr[ColumnOrder];
            else return null;
        }

        public static long? ReadLongNullable(IDataReader dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToInt64(dr[ColumnOrder]);
            else return null;
        }
        #endregion

        #region short
        /// <summary>
        /// Int16
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static short ReadShort(DataRow dr, string columnName)
        {
            return ReadShort(dr, columnName, short.MinValue);
        }

        /// <summary>
        /// Int16
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="ColumnOrder"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ReadShort(DataRow dr, int ColumnOrder, short defaultValue)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToInt16(dr[ColumnOrder]);
            else
                return defaultValue;
        }

        public static short ReadShort(DataRow dr, int ColumnOrder)
        {
            if (dr[ColumnOrder] != DBNull.Value)
                return Convert.ToInt16(dr[ColumnOrder]);
            return 0;
        }

        /// <summary>
        /// Int16
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ReadShort(DataRow dr, string columnName, short defaultValue)
        {
            if (dr.Table.Columns.Contains(columnName))
                if (dr[columnName] != DBNull.Value)
                    return Convert.ToInt16(dr[columnName]);
            return defaultValue;
        }
        #endregion
    }
}
