using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoom.Models;

namespace HotelRoom.Repository
{
    public class roommaster: iroommaster
    {
        HotelDBContext db;
        public roommaster(HotelDBContext _db)
        {
            db = _db;
        }

        public int AddDetail (RoomBooking data)
        {
            if (db != null)
            {
                db.RoomBooking.Add(data);
                db.SaveChanges();

                return data.BookingId;
            }

            return 0;
        }
        public int DeleteDetail(int Id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.RoomBooking.FirstOrDefault(x => x.BookingId == Id);

                if (post != null)
                {

                    db.RoomBooking.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }
        public List<RoomBooking> GetDetails()
        {
            if (db != null)
            {
                return db.RoomBooking.ToList();
            }
            return null;
        }

        public RoomBooking GetDetail(int? inId)
        {
            if (db != null)
            {
                return (db.RoomBooking.Where(x => x.BookingId == inId)).FirstOrDefault();
            }
            return null;
        }

       public int UpdateDetail(int id, string BookedDateFr, string BookedDateTo)
        {
            if (db != null)
            {
                RoomBooking val = db.RoomBooking.Where(x => x.BookingId == id).FirstOrDefault();
                RoomBooking valc = db.RoomBooking.Where(x => x.BookingId == id).FirstOrDefault();
                if (val != null)
                {
                    db.RoomBooking.Remove(val);
                    db.SaveChanges();
                    if ((BookedDateFr != "") && (BookedDateFr != null))
                        valc.BookedDateFr = BookedDateFr;
                    if((BookedDateTo != "") && (BookedDateTo != null))
                        valc.BookedDateTo = BookedDateTo;

                   
                    
                    db.RoomBooking.Add(valc);
                    db.SaveChanges();
                }
            }
            return 0;
        }


    }
}
