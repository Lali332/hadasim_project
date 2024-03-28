namespace HMO.API.Models
{
    public class CoronaModel
    {
        public DateTime? FirstVaccination { get; set; }
        public DateTime? SecondVaccination { get; set; }
        public DateTime? ThirdVaccination { get; set; }
        public DateTime? FourhVaccination { get; set; }
        public string? ProducerFirst { get; set; }
        public string? ProducerSecond { get; set; }
        public string? ProducerThird { get; set; }
        public string? ProducerFourth { get; set; }
        public DateTime? DataSick { get; set; }
        public DateTime? DataRecover { get; set; }
    }
}
