using HotelRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRoom.Repository
{
    public class hotelmaster : ihotelmaster
    {
        HotelDBContext db;
        public hotelmaster(HotelDBContext _db)
        {
            db = _db;
        }
        public List<HotelMaster> GetDetails()
        {
            if(db != null)
            {
                return db.HotelMaster.ToList();
            }
            return null;
        }

        public HotelMaster GetDetail(int? inId)
        {
            if (db != null)
            {
                return (db.HotelMaster.Where(x => x.RoomId == inId)).FirstOrDefault();
            }
            return null;
        }
    }
}
