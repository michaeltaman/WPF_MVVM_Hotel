using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(NavigationStore navigationStore)
        {
            MakeReservationCommand = new NavigateCommand(navigationStore);

            _reservations = new ObservableCollection<ReservationViewModel>
            {
                new ReservationViewModel(new Reservation(new RoomID(1, 2), "Michael", DateTime.Now, DateTime.Now)),
                new ReservationViewModel(new Reservation(new RoomID(3, 3), "Joe", DateTime.Now, DateTime.Now)),
                new ReservationViewModel(new Reservation(new RoomID(2, 4), "Mary", DateTime.Now, DateTime.Now))
            };        
        }
    }
}
