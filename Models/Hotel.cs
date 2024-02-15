using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; set; }

        public Hotel(string name)
        {
            _reservationBook = new ReservationBook();

            Name = name;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        public void MakeResevation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }

    }
}
