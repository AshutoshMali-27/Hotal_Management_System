using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Hotal_Management_System.ViewModel
{
    public class ClsRoomDetailVIewModel
    {
        public int RoomID { get; set; }

        
        public string RoomNo { get; set; }
        
        public string RoomImage { get; set; }
       
        public double RoomPrice { get; set; }
        
        public string BookingStatus { get; set; }
       
        public string RoomType { get; set; }
       
        public int RoomCapecity { get; set; }
       
        public string RoomDescription { get; set; }

    }
}