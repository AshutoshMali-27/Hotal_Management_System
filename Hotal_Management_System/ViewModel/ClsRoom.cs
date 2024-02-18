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
        [Required(ErrorMessage ="Room Number is Required")]
          public string RoomNo { get; set; }
        [Display(Name = "Room Image")]
        public  string RoomImage { get; set; }
        [Display(Name = "Room Price")]
        [Required(ErrorMessage = "Room Price is Required")]
        public double    RoomPrice { get; set; }
        [Display(Name = "Booking Status")]
        [Required(ErrorMessage = "Booking Status is Required")]
        public int   BookingStatusId { get; set; }
        [Display(Name = "Room Type")]
        [Required(ErrorMessage = "Room Type is Required")]
        public int RoomTypeID { get; set; }
        [Display(Name = "Room Capacity")]
        [Required(ErrorMessage = "Room Capacity is Required")]
        public int RoomCapecity { get; set; }
        [Display(Name = "Room Description")]
        [Required(ErrorMessage = "Room Description is Required")]
        public string RoomDescription { get; set; }
        
        public HttpPostedFileBase Image { get; set; }

        public List<SelectListItem> ListofBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}