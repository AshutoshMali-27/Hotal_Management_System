using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotal_Management_System.Models;
using Hotal_Management_System.ViewModel;

namespace Hotal_Management_System.Controllers
{
    public class BookingController : Controller
    {
        private HotalMSEntities objhotelDBEntities;

        public BookingController()
        {
            objhotelDBEntities = new HotalMSEntities();
        }

        public ActionResult Index()
        {
            ClsBooking objBookingViewMode = new ClsBooking();
            objBookingViewMode.LisofRooms = (from objRoom in objhotelDBEntities.Rooms
                                             where objRoom.BookingStatusId == 2
                                             select new SelectListItem()
                                             {
                                                 Text = objRoom.RoomNo,
                                                 Value = objRoom.RoomID.ToString()
                                             }
                                           ).ToList();
            return View(objBookingViewMode);
        }
    }
}