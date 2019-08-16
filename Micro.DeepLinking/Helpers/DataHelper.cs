using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;
using Micro.Common.Model;

namespace Micro.DeepLinking.Helpers
{
    public class DataHelper
    {
        #region Declarations

        #endregion

        #region General Properties

        public List<string> EventsLanguages
        {
            get
            {
                if (HttpContext.Current.Session["WhatNow_Events_Languages"] == null)
                {
                    List<string> _languages = ConfigurationManager.AppSettings["EventLanguages"].Split(',').ToList();

                    HttpContext.Current.Session["WhatNow_Events_Languages"] = _languages;
                }
                return (List<string>)(HttpContext.Current.Session["WhatNow_Events_Languages"]);
            }
        }

        #endregion
        public string ImageContentURL()
        {
            return ConfigurationManager.AppSettings["ImageContentURL"].FirstOrDefault().ToString();
        }

        #region User Properties

        public BaseRequest BaseRequest
        {
            get
            {
                if (HttpContext.Current.Session["WhatNow_BaseRequest"] != null)
                    return (BaseRequest)(HttpContext.Current.Session["WhatNow_CMS_BaseRequest"]);
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["WhatNow_BaseRequest"] = value;
            }
        }

        


        

        

        
        

        

       


        

        
        public string DefaultLanguage
        {
            get
            {
                if (HttpContext.Current.Session["WhatNow_CMS_DefaultLanguage"] != null)
                    return (string)(HttpContext.Current.Session["WhatNow_CMS_DefaultLanguage"]);
                else
                    return "en";
            }
            set
            {
                HttpContext.Current.Session["WhatNow_CMS_DefaultLanguage"] = value;
            }
        }


        #endregion

        #region Functions

        

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public DataTable RemoveAllColumnsExcept(DataTable dt, string[] columnNames)
        {
            for (int i = dt.Columns.Count - 1; i >= 0; i--)
            {
                DataColumn _column = dt.Columns[i];
                string value = System.Array.Find<string>(columnNames, (string elm) => elm.ToLower().Equals(_column.ColumnName.ToLower()));
                if (string.IsNullOrEmpty(value))
                {
                    int index = dt.Columns.IndexOf(_column.ColumnName);
                    dt.Columns.RemoveAt(index);
                    dt.AcceptChanges();
                }
            }

            return dt;
        }



        #endregion

    }
}