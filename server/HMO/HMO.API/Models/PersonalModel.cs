namespace HMO.API.Models
{
    public class PersonalModel
    {
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Phone { get; set; }
        public string Pelephon { get; set; }
        public IFormFile? ImageFile { get; set; }

        public int CoronaDetailsId { get; set; }
    }
}
