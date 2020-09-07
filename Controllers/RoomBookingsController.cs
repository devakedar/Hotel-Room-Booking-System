using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelRoom.Repository;
using HotelRoom.Models;

namespace HotelRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RoomBookingsController));

        iroommaster rdb;
        public RoomBookingsController(iroommaster _rdb)

        {
            rdb = _rdb;
        }
        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetDetails()
        {
            _log4net.Info("RoomBookingsController Http GET ALL");
            try
            {
                var reservations = rdb.GetDetails();
                if (reservations == null)
                {
                    return NotFound();
                }

                return Ok(reservations);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var data = rdb.GetDetail(Id);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddDetail")]
        public IActionResult AddDetail(RoomBooking model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = rdb.AddDetail(model);
                    if (Id > 0)
                    {
                        return Ok(Id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteDetail")]
        public IActionResult DeleteDetail(int Id)
        {


            if (Id == null)
            {
                return BadRequest(Id);
            }

            try
            {
                var result = rdb.DeleteDetail(Id);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(Id);
            }
        }
        [HttpPut]
        [Route("UpdateDetail")]

        public IActionResult UpdateDetail(int id, string BookedDateFr = "", string BookedDateTo = "")
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = rdb.UpdateDetail(id, BookedDateFr, BookedDateTo);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


    }
}