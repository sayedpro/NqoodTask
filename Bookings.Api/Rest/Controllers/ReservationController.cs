using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booking.Api.Rest.Models;
using Booking.Application.Employee.Commands.CreateEmployee;
using Booking.Application.Reservations.Commands.DeleteTodoItem;
using Booking.Application.Reservations.Commands.UpdateReservations;
using Booking.Application.Reservations.Queries.GetReservationDetailsQuery;
using Booking.Application.Reservations.Queries.GetReservationsQuery;
using MediatR;

using Microsoft.AspNetCore.Mvc;
using Booking.Api.Rest.Mappers;

namespace Booking.Api.Rest.Controllers
{
    [ApiVersion("1.0")]
    [Route("Api/v{version:apiVersion}/")]
    public class ReservationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ReservationController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Create Trip Reservation
        /// </summary>
        /// <param name="command"><see cref="CreateReservationDto"/>.</param>
        /// <returns>Create Trip Reservation Response <see cref="int"/>.</returns>>
        [HttpPost("create/", Name = "CreateReservation")]
        public async Task<int> CreateReservation(CreateReservationDto command)
        {
            var request = _mapper.Map<CreateReservationCommand>(command);

            var response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// Update Trip Reservation
        /// </summary>
        /// <param name="command"><see cref="UpdateReservationDto"/>.</param>
        /// <returns>Update Trip Reservation Response <see cref="int"/>.</returns>>
        [HttpPut("update/", Name = "UpdateReservation")]
        public async Task<int> UpdateReservation(UpdateReservationDto command)
        {
            var request = _mapper.Map<UpdateReservationCommand>(command);

            var response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// Delete Trip Reservation
        /// </summary>
        /// <param name="reservationId"><see cref="int"/>.</param>
        /// <returns>Delete Trip Reservation Response <see cref="int"/>.</returns>>
        [HttpDelete("delete/{reservationId}", Name = "DeleteReservation")]
        public async Task<int> DeleteReservation(int reservationId)
        {
            var request = new DeleteReservationsCommand() { Id = reservationId };

            var response = await _mediator.Send(request);
            return response;
        }

        /// <summary>
        /// Get Trip Reservation Details
        /// </summary>
        /// <param name="reservationId"><see cref="int"/>.</param>
        /// <returns>Get Trip Reservation Response <see cref="int"/>.</returns>>
        [HttpGet("get/{reservationId}", Name = "GetReservationDetails")]
        public async Task<GetReservationResaponseDto> GetReservationDetails(int reservationId)
        {
            var request = new GetReservationsDetailsQuery() { ReservationsId = reservationId };

            var result = await _mediator.Send(request);
            var response = _mapper.Map<GetReservationResaponseDto>(result);

            return response;
        }

        /// <summary>
        /// Get All Reservations
        /// </summary>
        /// <param name="reservationId"><see cref="int"/>.</param>
        [HttpGet("list/", Name = "GetAllReservations")]
        public async Task<GetAllReservationResaponseDto> GetAllReservations(int pageSize = 10, int pageNumber = 1)
        {
            var query = new GetReservationsQuery() { PageNumber = pageNumber, PageSize = pageSize };

            var result = await _mediator.Send(query);

            var response = new GetAllReservationResaponseDto()
            {
                Result = ReservationMapper.ToReservationResponseDto(result.Items),
                Metadata = new MetaDataDto()
                {
                    TotalPages = result.TotalPages,
                    TotalCount = result.TotalCount
                }
            };
            return response;
        }

    }
}
