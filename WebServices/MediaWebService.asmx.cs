using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using BusinessLogic;

namespace WebServices
{
    /// <summary>
    /// Summary description for MediaWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MediaWebService : System.Web.Services.WebService
    {
        //making an medialogic attribute to make it faster
        MediaLogic ml = new MediaLogic();

        //list all media in database
        [WebMethod]
        public DataTable listMedia() {
            return AppUtil.ToDataTable(ml.ListMedia());
        }

        //list media by publish year
        [WebMethod]
        public DataTable listMediaByPublishYear(int year) { 
            return AppUtil.ToDataTable(ml.ListMediaByPublishYear(year)) ;
        }

        //list media by language
        [WebMethod]
        public DataTable listMediaByLanguage(String language) {
            return AppUtil.ToDataTable(ml.ListMediaByLanguage(language));
        }

        //list all reservations
        [WebMethod]
        public DataTable listReservations(int CurrentUserID) {
            return AppUtil.ToDataTable(ml.ListReservations(CurrentUserID));
        }

        //list borrowed media
        [WebMethod]
        public DataTable listBorrows(int CurrentUserID) {
            return AppUtil.ToDataTable(ml.ListBorrows(CurrentUserID));                 
        }

        //list all borrowed media
        [WebMethod]
        public DataTable listAllBorrows() {
            return AppUtil.ToDataTable(ml.ListAllBorrows());
        }

        //list genres
        [WebMethod]
        public DataTable listGenres() {
            return AppUtil.ToDataTable(ml.ListGenres());
        }

        //list languages
        [WebMethod]
        public DataTable listLanguages() { 
            return AppUtil.ToDataTable(ml.ListLanguages());
        }

        //list directors
        [WebMethod]
        public DataTable listDirectors() {
            return AppUtil.ToDataTable(ml.ListDirectors());
        }

        //list media by genre
        [WebMethod]
        public DataTable listMediaByGenre(String genre) {
            return AppUtil.ToDataTable(ml.ListMediaByGenre(genre));
        }

        //list media by director
        [WebMethod]
        public DataTable listMediaByDirector(String director) {
            return AppUtil.ToDataTable(ml.ListMediaByDirector(director));
        }

        //list media by budget
        [WebMethod]
        public DataTable listMediaByBudget(decimal budget) {
            return AppUtil.ToDataTable(ml.ListMediaByBudget(budget));
        }

        //delete media
        [WebMethod]
        public int deleteMedia(int mediaID, int adminLevel) {
            return ml.DeleteMedia(mediaID, adminLevel);
        }

        //update media
        [WebMethod]
        public int updateMedia(String Title, int Genre, int Director, int Language, int PublishYear, int Budget, int MediaID, int adminLevel) {
            return ml.UpdateMedia(Title, Genre, Director, Language, PublishYear, Budget, MediaID, adminLevel);
        }

        //add genre
        [WebMethod]
        public int addGenre(String genreName, int adminLevel){
            return ml.AddGenre(genreName, adminLevel);
        }

        //add language
        [WebMethod]
        public int addLanguage(String languageName, int adminLevel) {
            return ml.AddLanguage(languageName, adminLevel);
        }

        //add director
        [WebMethod]
        public int addDirector(String directorName, int adminLevel) {
            return ml.AddDirector(directorName, adminLevel);
        }

        //add reservatin
        [WebMethod]
        public int addReservation(int UID, int MediaID, String ReservedDate) {
            return ml.AddReservation(UID, MediaID, ReservedDate);
        }

        //delete reservations
        [WebMethod]
        public int deleteReservation(int UID, int MediaID)
        {
            return ml.DeleteReservation(UID, MediaID);
        }

        //check media 
        [WebMethod]
        public int? checkMedia(int MediaID) {
            return ml.CheckMedia(MediaID);
        }

        //add new media
        [WebMethod]
        public int addMedia(String Title, int Genre, int Director, int Language, int PublishYear, int Budget, int adminLevel) {
            return ml.AddMedia(Title, Genre, Director, Language, PublishYear, Budget, adminLevel);
        }

        //borrow media
        [WebMethod]
        public int borrowMedia(int UID, int MediaID, String BorrowDate, String ReturnDate, int LateFee) {
            return ml.BorrowMedia(UID, MediaID, BorrowDate, ReturnDate, LateFee);
        }

        //check media (if available or not)
        [WebMethod]
        public bool checkAvailableMedia(int MediaID) {
            return ml.CheckAvailableMedia(MediaID);
        }

        //return media
        [WebMethod]
        public int returnMedia(Decimal LateFee, int UID, int MediaID) {
            return ml.ReturnMedia(LateFee, UID, MediaID);
        }
    }
}
