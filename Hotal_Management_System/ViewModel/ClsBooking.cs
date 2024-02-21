using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotal_Management_System.ViewModel
{
    public class ClsBooking
    {
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }
        [Display(Name = "Customer Phone")]
        public string CustomerPhoneNumber { get; set; }
        [Display(Name = "Booking From")]
        public DateTime BookingFrom { get; set; }
        [Display(Name = "Booking To")]
        public DateTime BookingTo { get; set; }
        [Display(Name = "Assign RoomID")]
        public int AssignRoomId { get; set; }
        [Display(Name = "Number of Member")]
        public int NoofMembers { get; set; }
        //public string TotalAmounts { get; set; }

        public IEnumerable<SelectListItem> LisofRooms { get; set; }
           
        //   public string BookingID { get; set; }
    }
}