using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Booking.UI.Models;
using System.Diagnostics;
using Booking.Application.Reservations.Queries.GetReservationsQuery;
using PagedList;
using PagedList.Core;

namespace Booking.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IMediator _mediator;
        private const int PageSize = 5;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetReservationsQuery() { PageNumber = 1, PageSize = PageSize };

            var result = await _mediator.Send(query);
            var reservationList = result.Items.Select(x => new ReservationViewModel()
            {
                CreationDate = x.CreationDate,
                CustomerName = x.CustomerName,
                Notes = x.Notes,
                ReservationDate = x.ReservationDate,
                ReservationId = x.ReservationId,
                ReservedBy = x.ReservedBy,
                TripName = x.TripName
            }).ToList();
            var model = new ReservationModel()
            {
                CurrentPageIndex = 1,
                PageCount = PageSize,
                Reservations = reservationList
            };

            return View(model);
        }

        // GET: Reservations
        [HttpPost]
        public async Task<IActionResult> Index(int? currentPageIndex)
        {
            int pageNumber = (currentPageIndex ?? 1);
            var query = new GetReservationsQuery() { PageNumber = pageNumber, PageSize = PageSize };

            var result = await _mediator.Send(query);
            var reservationList = result.Items.Select(x => new ReservationViewModel()
            {
                CreationDate = x.CreationDate,
                CustomerName = x.CustomerName,
                Notes = x.Notes,
                ReservationDate = x.ReservationDate,
                ReservationId = x.ReservationId,
                ReservedBy = x.ReservedBy,
                TripName = x.TripName
            }).ToList();
            var model = new ReservationModel()
            {
                CurrentPageIndex = pageNumber,
                PageCount = PageSize,
                Reservations = reservationList
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
