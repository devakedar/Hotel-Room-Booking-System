using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoom.Models;

namespace HotelRoom.Repository
{
    public interface iroommaster
    {
        List<RoomBooking> GetDetails();
        RoomBooking GetDetail(int? Id);
        int AddDetail(RoomBooking data);
        int DeleteDetail(int Id);
        int UpdateDetail(int id,string BookedDateFr,string BookedDateTo);
    }
}
