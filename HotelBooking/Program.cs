using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<HotelContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/rooms", async (HotelContext db) => await db.rooms.ToListAsync());
app.MapGet("/bookings", async (HotelContext db) => await db.bookings.ToListAsync());

app.MapGet("/rooms/{id:int}", async (int id, HotelContext db) =>
{
    var result = await db.rooms.FindAsync(id);
    if(result == null)
    {
        return Results.NotFound(new {message = $"Room {id} was not found"});
    }
    return Results.Ok(result);
});

app.MapPost("/rooms", async (Room room, HotelContext db) =>
{
    db.rooms.Add(room);
    await db.SaveChangesAsync();
    return room;
});

app.MapPut("/rooms/{id:int}", async (int id, Room room, HotelContext db) =>
{
   var result = await db.rooms.FindAsync(id);
    if(result == null)
    {
        return Results.NotFound(new { message = $"Room {id} was not found" });
    }
    result.Number = room.Number;
    result.Type = room.Type;
    result.Capacity = room.Capacity;
    result.Price = room.Price;
    await db.SaveChangesAsync();
    return Results.Ok(result);
});

app.MapDelete("/rooms/{id:int}", async (int id, HotelContext db) =>
{
    var result = await db.rooms.FindAsync(id);
    if(result == null)
    {
        return Results.NotFound(new {message = $"Room {id} was not found" });
    }
    db.rooms.Remove(result);
    await db.SaveChangesAsync();
    return Results.Ok(result);
});

app.MapGet("/bookings/{id:int}", async (int id, HotelContext db) =>
{
    var result = await db.bookings.FindAsync(id);
    if(result == null)
    {
        return Results.NotFound(new { message = $"Booking {id} was not found" });
    }
    return Results.Ok(result);
});

app.MapPost("/bookings", async (Booking booking, HotelContext db) =>
{
    db.bookings.Add(booking);
    await db.SaveChangesAsync();
    return booking;
});

app.MapPut("/bookings/{id:int}", async (int id, Booking booking, HotelContext db) =>
{
    var result = await db.bookings.FindAsync(id);
    if(result == null)
    {
        return Results.NotFound(new { message = $"Booking {id} was not found" });
    }
    result.GuestName = booking.GuestName;
    result.CheckIn = booking.CheckIn;
    result.CheckOut = booking.CheckOut;
    result.PaymentMethod = booking.PaymentMethod;
    result.RoomId = booking.RoomId;

    await db.SaveChangesAsync();
    return Results.Ok(result);
});

app.MapDelete("/bookings/{id:int}", async (int id, HotelContext db) =>
{
    var result = await db.bookings.FindAsync(id);
    if(result == null)
    {
        return Results.NotFound(new { message = $"Booking {id} was not found" });
    }
    db.bookings.Remove(result);
    await db.SaveChangesAsync();
    return Results.Ok(result);
});
app.Run();