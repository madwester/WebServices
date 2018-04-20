using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data; //lets us inlcude data table and data rows and all that kind of stuff
using BusinessLogic;

namespace WebServices
{
    /// <summary>
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebService : System.Web.Services.WebService
    {

        //making an userlogin attribute so I dont have to make it in every method
        UserLogic ul = new UserLogic();

        //if returning lists, converting them to datatables first
        [WebMethod]
        public DataTable listUsers() {
                //ToDataTable = static method we use to convert any list of anything into a datatable
                return AppUtil.ToDataTable(ul.GetListOfUsers());
        }

        //list users
        [WebMethod]
        public DataTable listUsersByLogin(string username, string password) {
            return AppUtil.ToDataTable(ul.GetListOfUsersByUserNameAndPassword(username, password));
        }

        //update password
        [WebMethod]
        public int updatePassword(string newPassword, int userID, int adminLevel) {
            return ul.UpdatePassword(newPassword, userID, adminLevel);
        }

        //delete user
        [WebMethod]
        public int deleteUser(int userID, int adminLevel) {
            return ul.DeleteUser(userID, adminLevel);
        }

        //add new user
        [WebMethod]
        public int addNewUser(string username, string password, int userLevel, string email, int adminLevel)
        {
            return ul.AddNewUser(username, password, userLevel, email, adminLevel);
        } 
    }
}
