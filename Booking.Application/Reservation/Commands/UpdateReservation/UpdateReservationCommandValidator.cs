using Booking.Application.Reservations.Commands.UpdateReservations;
using FluentValidation;
using System.Globalization;

namespace Booking.Application.Reservations.Commands.UpdateTodoItem
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        [System.Obsolete]
        public UpdateReservationCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                          .Cascade(CascadeMode.StopOnFirstFailure)
                          .NotEmpty().WithMessage("Customer Name Is Required")
                          .MaximumLength(100).WithMessage(x => string.Format(CultureInfo.CurrentCulture, "Customer Name Length Must be leth Than Or Equal 100", 50));
            RuleFor(x => x.TripId)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("Trip Id Is Required");
        }
    }
}
