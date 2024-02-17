using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotal_Management_System.ViewModel
{
    public class ClsRoom
    {
      public int RoomID { get; set; }

        [Display(Name ="Room No.")]
          public string RoomNo { get; set; }
        [Display(Name = "Room Image")]
        public  string RoomImage { get; set; }
        [Display(Name = "Room Price")]
        public double    RoomPrice { get; set; }
        [Display(Name = "Booking Status")]
        public int   BookingStatusId { get; set; }
        [Display(Name = "Room Type")]
        public int RoomTypeID { get; set; }
        [Display(Name = "Room Capacity")]
        public int RoomCapecity { get; set; }
        [Display(Name = "Room Description")]
        public string RoomDescription { get; set; }
        
        public HttpPostedFileBase Image { get; set; }

        public List<SelectListItem> ListofBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}