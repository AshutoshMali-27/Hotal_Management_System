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
            string message = String.Empty;
            string ImageUniqueName = String.Empty;
            string ActualImageName = String.Empty;
            if (objClsRoom.RoomID == 0)
            {
                 ImageUniqueName = Guid.NewGuid().ToString();
                 ActualImageName = ImageUniqueName + Path.GetExtension(objClsRoom.Image.FileName);
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
                    RoomImage = ActualImageName


                };

                objhotelDBEntities.Rooms.Add(objRoom);
                message = "Added.";
            }
            else
            {
                if(objClsRoom.Image != null)
                {
                     ImageUniqueName = Guid.NewGuid().ToString();
                     ActualImageName = ImageUniqueName + Path.GetExtension(objClsRoom.Image.FileName);
                    objClsRoom.Image.SaveAs(filename: Server.MapPath("~/RoomImages/" + ActualImageName));
                    objClsRoom.RoomImage = ActualImageName;
                }
                Room objRoom = objhotelDBEntities.Rooms.Single(model => model.RoomID == objClsRoom.RoomID);
                objRoom.RoomNo = objClsRoom.RoomNo;
                objRoom.RoomDescription = objClsRoom.RoomDescription;
                objRoom.RoomPrice = Convert.ToDecimal(objClsRoom.RoomPrice);
                objRoom.BookingStatusId = objClsRoom.BookingStatusId;
                objRoom.isActive = true;
                objRoom.RoomCapecity = objClsRoom.RoomCapecity;
                objRoom.RoomTypeID = objClsRoom.RoomTypeID;
             
                message = "Updates";
            }

      
            objhotelDBEntities.SaveChanges();

            return Json(data:new { message ="Room Successfully"+message, success=true}, JsonRequestBehavior.AllowGet);

        }

        
        public PartialViewResult GetAllRooms()
        {
            IEnumerable<ClsRoomDetailVIewModel> listofRoomDetailViewModels =
                (from objRooms in objhotelDBEntities.Rooms
                 join objbooking in objhotelDBEntities.BStatus on objRooms.BookingStatusId equals objbooking.BookingStatusID
                 join objRoomType in objhotelDBEntities.RoomTypes on objRooms.RoomTypeID equals objRoomType.RoomTypeID where objRooms.isActive==true
                 select new ClsRoomDetailVIewModel()
                 {
                     RoomNo = objRooms.RoomNo.ToString(),
                     RoomDescription=objRooms.RoomDescription.ToString(),
                     RoomCapecity=(Int32)objRooms.RoomCapecity,
                     RoomPrice= (double)objRooms.RoomPrice,
                     BookingStatus=objbooking.BookingStatus.ToString(),
                     RoomType=objRoomType.RoomTypeName.ToString(),
                     RoomImage=objRooms.RoomImage.ToString(),
                     RoomID=objRooms.RoomID



                 }).ToList() ;

            return PartialView("_PartialRoomDetail", listofRoomDetailViewModels);

        }


        [HttpGet]
        public JsonResult EditRoomDetail(int RoomID)
        {
            var Result = objhotelDBEntities.Rooms.Single(model => model.RoomID == RoomID);
            return Json(Result, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult DeleteRoomDetails(int RoomID)
        {
            Room objRoom= objhotelDBEntities.Rooms.Single(model => model.RoomID == RoomID);
            objRoom.isActive = false;
            objhotelDBEntities.SaveChanges();
            return Json(data: new { message = "Record Successfully Deleted.",success=true },JsonRequestBehavior.AllowGet);
        }
    }
}