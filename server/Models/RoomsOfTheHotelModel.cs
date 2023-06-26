using server.Data;

namespace server.Models
{
    public class RoomsOfTheHotelModel
    {
        public int room_type_id { get; set; }

        public string name { get; set; }

        public double room_area { get; set; }

        public int number_bed { get; set; }

        public Boolean smoking_allowed { get; set; }

        public List<Rooms> Rooms { get; set; }

        public List<AmenitiesModel> Amenities { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public string? thumbnail { get; set; }
    }
}