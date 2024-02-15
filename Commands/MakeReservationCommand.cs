using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    internal class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        public readonly Hotel _hotel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;

            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {

            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, 
                    _makeReservationViewModel.RoomNumber),
                    _makeReservationViewModel.Username,
                    _makeReservationViewModel.StartDate, 
                    _makeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeResevation(reservation);
                MessageBox.Show($"Successfully reserved room N# {reservation.RoomID.ToString()}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show($"The room N# {reservation.RoomID.ToString()} is already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
