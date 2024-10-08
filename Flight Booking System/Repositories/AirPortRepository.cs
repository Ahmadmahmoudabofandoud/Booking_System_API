﻿using Flight_Booking_System.Context;
using Flight_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight_Booking_System.Repositories
{
    public class AirPortRepository : Repository<AirPort>, IAirPortRepository
    {
        public AirPortRepository(BookingContext _context) : base(_context)
        {

        }

        public AirPort? GetWithIncludes(int? id)
        {
            AirPort? airPortfromDB = Context.AirPorts.Where(a => a.Id == id)
                                        .Include(a => a.Country).Include(a => a.State)
                                        .FirstOrDefault();

            return airPortfromDB;
        }

        public AirPort? GetSourceWithFlights(int? id)
        {
            return Context.AirPorts.Where(a => a.Id == id)
                .Include(a => a.LeavingFlights).FirstOrDefault();
        }

        public AirPort? GetDsetinationWithFlights(int? id)
        {
            return Context.AirPorts.Where(a => a.Id == id)
                .Include(a => a.ArrivingFlights).FirstOrDefault();
        }
    }
}
