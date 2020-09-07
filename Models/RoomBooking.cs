using System;
using System.Collections.Generic;

namespace HotelRoom.Models
{
    public partial class RoomBooking
    {
        public int BookingId { get; set; }
        public int? RoomId { get; set; }
        public string BookedDateFr { get; set; }
        public string BookedDateTo { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string AdvancePayed { get; set; }
        public string TotalAmountPayed { get; set; }
    }
}
