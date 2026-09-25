using HotelBooking.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<HotelContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/rooms", (HotelContext db) => db.rooms.ToList());
app.MapGet("/bookings", (HotelContext db) => db.bookings.ToList());

app.MapPost("/rooms", (Room room, HotelContext db) =>
{
    db.rooms.Add(room);
    db.SaveChanges();
    return room;
});

app.MapGet("/rooms/{id:int}", (int id, HotelContext db) =>
{
    var result = db.rooms.Find(id);
    if(result == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);
});
app.MapPut("/rooms/{id:int}", (int id, Room room, HotelContext db) =>
{
    var result = db.rooms.Find(id);
    if(result == null)
    {
        return Results.NotFound();
    }
    result.Number = room.Number;
    result.Type = room.Type;
    result.Capacity = room.Capacity;
    result.Price = room.Price;

    db.SaveChanges();
    return Results.Ok(result);
});

app.MapDelete("/rooms/{id:int}", (int id, HotelContext db) =>
{
    var result = db.rooms.Find(id);
    if(result == null)
    {
        return Results.NotFound(new {message = $"Room {id} was not found"});
    }
    db.Remove(result);
    db.SaveChanges();
    return Results.Ok(result);
});

app.MapPost("/bookings", (Booking booking, HotelContext db) =>
{
    db.bookings.Add(booking);
    db.SaveChanges();
    return booking;
});

app.MapGet("/bookings/{id:int}", (int id, HotelContext db) =>
{
    var result = db.bookings.Find(id);
    if(result == null)
    {
        return Results.NotFound(new { message = $"Booking {id} was not found" });
    }
    return Results.Ok(result);
});

app.MapPut("/bookings/{id:int}", (int id, Booking booking, HotelContext db) =>
{
    var result = db.bookings.Find(id);
    if(result == null)
    {
        return Results.NotFound();
    }
    result.GuestName = booking.GuestName;
    result.CheckIn = booking.CheckIn;
    result.CheckOut = booking.CheckOut;
    result.PaymentMethod = booking.PaymentMethod;
    result.RoomId = booking.RoomId;

    db.SaveChanges();
    return Results.Ok(result);
});

app.MapDelete("/bookings/{id:int}", (int id, HotelContext db) =>
{
    var result = db.bookings.Find(id);
    if( result == null)
    {
        return Results.NotFound();
    }
    db.bookings.Remove(result);
    db.SaveChanges();
    return Results.Ok(result);
});
app.Run();