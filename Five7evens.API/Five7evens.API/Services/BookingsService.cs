using Five7evens.API.Data;
using Five7evens.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Five7evens.API.Services;

public class BookingsService
{
    private readonly AppDbContext _context;

    public BookingsService(AppDbContext context)
    {
        _context = context;
    }

    public List<Booking> GetAllBookings()
    {
        return _context.Bookings.OrderByDescending(b => b.CreatedAt).ToList();
    }

    public Booking? GetBookingById(int id)
    {
        return _context.Bookings.FirstOrDefault(b => b.Id == id);
    }

    public Booking AddBooking(Booking booking)
    {
        booking.CreatedAt = DateTime.UtcNow;
        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return booking;
    }

    public Booking? UpdateBooking(Booking booking)
    {
        var existing = _context.Bookings.FirstOrDefault(b => b.Id == booking.Id);
        if (existing == null) return null;

        existing.Name = booking.Name;
        existing.Email = booking.Email;
        existing.Destination = booking.Destination;
        existing.Date = booking.Date;
        existing.Guests = booking.Guests;

        _context.SaveChanges();
        return existing;
    }

    public bool DeleteBooking(int id)
    {
        var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null) return false;

        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return true;
    }
}
