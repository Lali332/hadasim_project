using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Dtos
{
    public class PersonalDetailsDto
    {
        public int Id { get; set; }
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime DateBirth { get; set; }
        public string Phone { get; set; }
        public string Pelephon { get; set; }
        public string? FileUrl { get; set; }
        public string? FileType { get; set; }

        public int CoronaDetailsId { get; set; }
        public CoronaDetails CoronaDetails { get; set; }
    }
}
