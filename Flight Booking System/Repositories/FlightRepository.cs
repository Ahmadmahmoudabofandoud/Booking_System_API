﻿using Flight_Booking_System.Context;
using Flight_Booking_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flight_Booking_System.Repositories
{

    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(BookingContext _context) : base(_context)
        {

        }

        //*************************************************************

        // used in system inBookingalize
        public List<Flight> GetAllWithAllIncludes()
        {
          return  Context.Flights
                .Include(f => f.SourceAirport)
                .Include(f => f.DestinationAirport)
                .Include(f => f.Plane)
                .Include(f => f.Passengers)
                .Include(f => f.Tickets)
                .ToList();
        }

        public Flight? GetOneWithAllIncludes(int id) 
        {
            return Context.Flights.Where(f => f.Id == id)
                  .Include(f => f.SourceAirport)
                  .Include(f => f.DestinationAirport)
                  .Include(f => f.Plane)
                  .Include(f => f.Passengers)
                  .Include(f => f.Tickets)
                  .FirstOrDefault();
        }

        public Flight? GetWithPlane_Passengers(int? id)
        {
            return Context.Flights
                 .Where(f => f.Id == id).Include(f => f.Plane).Include(f => f.Passengers).FirstOrDefault();
        }

        public Flight? GetWitPassengers_Tickets(int? id)  
        {
            return Context.Flights
                            .Where(f => f.Id == id).Include(f => f.Tickets)
                            .Include(f => f.Passengers).FirstOrDefault();
        }
        
        public Flight? GetWithTickets_Passengers(int? id)
        {
            return Context.Flights.Where(f => f.Id == id)
                .Include(f => f.Tickets)
                .Include(f => f.Passengers)
                .FirstOrDefault();
        }

        public Flight? GetWithTickets(int? id)
        {
            return Context.Flights.Where(f => f.Id == id)
                .Include(f => f.Tickets)
                .FirstOrDefault();
        }
    }
}
