using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//new imports
using System.Data;
using System.ComponentModel;


namespace WebServices
{
    public static class AppUtil
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable dt = new DataTable();
            dt.TableName = "wsTable"; //web service table

            //perpare table structure
            //for each property class T has, add as column to datatable
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor pd = props[i]; //one of the properties of class T
                dt.Columns.Add(pd.Name, pd.PropertyType);//new column of property name 
                                                   //and the type of this column is the same
                                                    //as the property
                                            //e.g UserID, int
            }

            //creating generic array of objects of size (number of properties)
            object[] RowOfDataAsObjects = new object[props.Count];
                //represents a whole row of data gotten from our data parameter to 
                //add to our datatable
            
            //cycle through all our data in our data list (e.g each userModel in list<UserModel>)
            foreach (T item in data)
            {
                //cycle through all of the values in each of the items properties (e.g UserID in userModel)
                for (int i = 0; i < RowOfDataAsObjects.Length; i++)
                {
                    //copy row values into objects array
                    RowOfDataAsObjects[i] = props[i].GetValue(item);
                }
                //add objects array as new row into datatable
                dt.Rows.Add(RowOfDataAsObjects);
            }
            return dt;
        }
    }
}