namespace SmartTalentTechnicalTest
{
    // Entity: User
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // e.g., "Agent", "Traveler"
    }

    // Entity: Hotel
    public class Hotel
    {
        public int HotelID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public decimal Commission { get; set; } // Percentage
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }

    // Entity: Room
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string RoomType { get; set; } = string.Empty; // e.g., Single, Double, Suite
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public bool IsActive { get; set; } = true;
        public string Location { get; set; } = string.Empty; // e.g., Floor or description

        public Hotel Hotel { get; set; } = null!;
    }

    // Entity: Reservation
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int RoomID { get; set; }
        public int UserID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }

        public Room Room { get; set; } = null!;
        public User User { get; set; } = null!;
        public ICollection<Guest> Guests { get; set; } = new List<Guest>();
    }

    // Entity: Guest
    public class Guest
    {
        public int GuestID { get; set; }
        public int ReservationID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;

        public Reservation Reservation { get; set; } = null!;
    }

    //Entity: EmailNotification
    public class EmailNotification
    {
        public int NotificationID { get; set; }
        public int ReservationID { get; set; }
        public DateTime SentDate { get; set; }
        public string Status { get; set; } = string.Empty; // e.g., Sent, Failed

        public Reservation Reservation { get; set; } = null!;
    }

}
