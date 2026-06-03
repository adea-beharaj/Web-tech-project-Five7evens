using Microsoft.AspNetCore.Mvc;
using Five7evens.API.Models;
using Five7evens.API.Services;

namespace Five7evens.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : ControllerBase
{
    private readonly BookingsService _bookingsService;

    public BookingsController(BookingsService bookingsService)
    {
        _bookingsService = bookingsService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAllBookings()
    {
        var bookings = _bookingsService.GetAllBookings();
        return Ok(bookings);
    }

    [HttpGet("GetById")]
    public IActionResult GetBookingById(int id)
    {
        var booking = _bookingsService.GetBookingById(id);
        if (booking == null)
            return NotFound($"Booking with id {id} not found.");
        return Ok(booking);
    }

    [HttpPost("AddNew")]
    public IActionResult CreateBooking([FromBody] Booking payload)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var added = _bookingsService.AddBooking(payload);
        return Ok(added);
    }

    [HttpPut("Update")]
    public IActionResult UpdateBooking([FromBody] Booking payload)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = _bookingsService.UpdateBooking(payload);
        if (updated == null)
            return NotFound($"Booking with id {payload.Id} not found.");
        return Ok(updated);
    }

    [HttpDelete("Delete")]
    public IActionResult DeleteBooking(int id)
    {
        var deleted = _bookingsService.DeleteBooking(id);
        if (!deleted)
            return NotFound($"Booking with id {id} not found.");
        return Ok("Booking deleted successfully.");
    }
}
