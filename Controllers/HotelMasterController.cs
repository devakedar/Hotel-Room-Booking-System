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
    public class HotelMasterController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(HotelMasterController));

        ihotelmaster udb;
        public HotelMasterController(ihotelmaster _udb)
        {
            udb = _udb;
        }

        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int? Id)
        {
            _log4net.Info("HotelMasterController Http GET");
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var data = udb.GetDetail(Id);
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
        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetDetails()
        {
            _log4net.Info("HotelMasterController Http GET ALL");
            try
            {
                var bookin = udb.GetDetails();
                if (bookin == null)
                {
                    return NotFound();
                }

                return Ok(bookin);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}