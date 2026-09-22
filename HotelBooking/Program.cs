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

app.MapGet("/rooms/{id:int}", (int id, HotelContext db) => db.rooms.Find(id));
app.MapPut("/rooms/{id:int}", (int id, Room room, HotelContext db) =>
{
    var result = db.rooms.Find(id);

    result.Number = room.Number;
    result.Type = room.Type;
    result.Capacity = room.Capacity;
    result.Price = room.Price;

    db.SaveChanges();
});
app.Run();