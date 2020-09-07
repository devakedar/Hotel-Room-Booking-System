using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoom.Models;

namespace HotelRoom.Repository
{
    public interface ihotelmaster
    {
        List<HotelMaster> GetDetails();
        HotelMaster GetDetail(int? inId);
    }
}
