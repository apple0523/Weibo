using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace Weibo.Data
{
   public class DbTranslate
    {
        public static List<TEntity> Translate<TEntity>(IDataReader reader) where TEntity : class, new() 
        {
            List<TEntity> list = new List<TEntity>();
            Type entityType = typeof(TEntity);
            
            Dictionary<string, PropertyInfo> dic = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo info in entityType.GetProperties())
            {
                dic.Add(info.Name, info);
            }

            string columnName = string.Empty;
            while (reader.Read())
            {
                TEntity t = new TEntity();
                foreach (KeyValuePair<string, PropertyInfo> attribute in dic)
                {
                    columnName = attribute.Key;
                    int filedIndex = 0;
                    while (filedIndex < reader.FieldCount)
                    {

                        if (reader.GetName(filedIndex) == columnName)
                        {
                            attribute.Value.SetValue(t, DataTypeConverter.ChangeType( attribute.Value.PropertyType,reader[filedIndex]), null);
                            break;

                        }
                        filedIndex++;


                    }
                }
                list.Add(t);

            }
            return list;

        }

        public static List<TEntity> Translate<TEntity>(DataTable dataTable) where TEntity : class, new()
        {
            List<TEntity> list = new List<TEntity>();
            Type entityType = typeof(TEntity);
            
            Dictionary<string, PropertyInfo> dic = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo info in entityType.GetProperties())
            {
                dic.Add(info.Name, info);
            }

            string columnName = string.Empty;
            foreach (DataRow dr in dataTable.Rows)
            {
                TEntity t = new TEntity();
                foreach (KeyValuePair<string, PropertyInfo> attribute in dic)
                {
                    columnName = attribute.Key;
                    int filedIndex = 0;
                    while (filedIndex < dataTable.Columns.Count)
                    {

                        if (dataTable.Columns[filedIndex].ColumnName == columnName)
                        {
                            attribute.Value.SetValue(t, DataTypeConverter.ChangeType(attribute.Value.PropertyType,dr[filedIndex]), null);
                            break;

                        }
                        filedIndex++;


                    }
                }
                list.Add(t);

            }
            return list;

        }

        
    }

   public class DataTypeConverter
   {
       public static object ChangeType(Type type, object value)
       {
           if (value is DBNull)
               return null;
           if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value != null)
                {
                    NullableConverter nullableConverter = new NullableConverter(type);
                    type = nullableConverter.UnderlyingType;
                }
                else
                {
                    return null;
                }
            }

           return Convert.ChangeType(value, type);
       }
   }
}
