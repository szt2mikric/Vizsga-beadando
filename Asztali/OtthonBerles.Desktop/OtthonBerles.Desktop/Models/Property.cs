using System;

namespace OtthonBerles.Models
{
    public class Property
    {
        public Property(string id, string email, string city, string type, int roomNumber, int price, bool isFurnished, string possibilityOfMoving, string other, byte[] imageData)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
            City = city;
            Email = email;
            Type_ = type;
            RoomNumber = roomNumber;
            Price = price;
            IsFurnished = isFurnished;
            PossibilityOfMoving = possibilityOfMoving;
            Other = other;
            ImageData = imageData;
        }

        public Property(int id, string email, string city, string type, int roomNumber, int price, bool isFurnished, string possibilityOfMoving, string other, byte[] imageData)
        {
            Id = id;
            City = city;
            Email = email;
            Type_ = type;
            RoomNumber = roomNumber;
            Price = price;
            IsFurnished = isFurnished;
            PossibilityOfMoving = possibilityOfMoving;
            Other = other;
            ImageData = imageData;
        }

        private int id;
        private string city;
        private string email;
        private string type;
        private int roomNumber;
        private int price;
        private bool isFurnished;
        private string possibilityOfMoving;
        private string other;
        private byte[] imageData;

        public int Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Email { get => email; set => email = value; }
        public string Type_ { get => type; set => type = value; }
        public int RoomNumber { get => roomNumber; set => roomNumber = value; }
        public int Price { get => price; set => price = value; }
        public bool IsFurnished { get => isFurnished; set => isFurnished = value; }
        public string PossibilityOfMoving { get => possibilityOfMoving; set => possibilityOfMoving = value; }
        public string Other { get => other; set => other = value; }
        public byte[] ImageData { get => imageData; set => imageData = value; }

        public override string ToString()
        {
            return email + " : " + Id.ToString();
        }
    }
}
