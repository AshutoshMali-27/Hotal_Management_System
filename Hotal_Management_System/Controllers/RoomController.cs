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
    public class RoomController : Controller
    {

        private HotalMSEntities objhotelDBEntities;
        public RoomController()
        {
            objhotelDBEntities = new HotalMSEntities();
        }

        
        public ActionResult Index()
        {
            ClsRoom objClsRoom = new ClsRoom();
            objClsRoom.ListofBookingStatus = (from obj in objhotelDBEntities.BStatus
                                              select new SelectListItem()
                                               {
                                                   Text = obj.BookingStatus,
                                                   Value = obj.BookingStatusID.ToString()
                                               }) .ToList();

            objClsRoom.ListOfRoomType = (from obj in objhotelDBEntities.RoomTypes
                                         select new SelectListItem()
                                         {
                                             Text = obj.RoomTypeName,
                                             Value = obj.RoomTypeID.ToString()
                                         }).ToList();
            return View(objClsRoom);
        }

        [HttpPost]
        public ActionResult Index(ClsRoom objClsRoom)
        {
            string ImageUniqueName = Guid.NewGuid().ToString();
            String ActualImageName = ImageUniqueName + Path.GetExtension(objClsRoom.Image.FileName);
            objClsRoom.Image.SaveAs(filename: Server.MapPath("~/RoomImages/" + ActualImageName));

            Room objRoom = new Room()
            {
                RoomNo = objClsRoom.RoomNo,
                RoomDescription = objClsRoom.RoomDescription,
                RoomPrice = Convert.ToDecimal(objClsRoom.RoomPrice),
                BookingStatusId = objClsRoom.BookingStatusId,
                isActive = true,
                RoomCapecity = objClsRoom.RoomCapecity,
                RoomTypeID = objClsRoom.RoomTypeID,
                RoomImage=ActualImageName


            };

            objhotelDBEntities.Rooms.Add(objRoom);
            objhotelDBEntities.SaveChanges();

            return Json(data:new { message ="Room Successfully Added .", success=true}, JsonRequestBehavior.AllowGet);

        }

        
        public PartialViewResult GetAllRooms()
        {
            IEnumerable<ClsRoomDetailVIewModel> listofRoomDetailViewModels =
                (from objRooms in objhotelDBEntities.Rooms
                 join objbooking in objhotelDBEntities.BStatus on objRooms.BookingStatusId equals objbooking.BookingStatusID
                 join objRoomType in objhotelDBEntities.RoomTypes on objRooms.RoomTypeID equals objRoomType.RoomTypeID
                 select new ClsRoomDetailVIewModel()
                 {
                     RoomNo = objRooms.RoomNo.ToString(),
                     RoomDescription=objRooms.RoomDescription.ToString(),
                    // RoomCapecity=objRooms.RoomCapecity,
                     //RoomPrice= Convert.ToDouble(objRooms.RoomPrice),
                     BookingStatus=objbooking.BookingStatus.ToString(),
                     RoomType=objRoomType.RoomTypeName.ToString(),
                     RoomImage=objRooms.RoomImage.ToString(),
                     RoomID=objRooms.RoomID



                 }).ToList() ;

            return PartialView("_PartialRoomDetail", listofRoomDetailViewModels);

        }
    }
}