using HMO.Core.Entities;
using HMO.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Data.Repositories
{
    public class PersonalDetailsRep : IPersonalDetailsRep
    {
        private readonly DataContext _context;
        public PersonalDetailsRep(DataContext context)
        {
            _context = context;
        }
        public List<PersonalDetails> GetPersonalDetails()
        {
            return _context.PersonalDetails.Include(c=>c.CoronaDetails).ToList();
        }
        public PersonalDetails GetPersonalDetailsById(int id)
        {
            return _context.PersonalDetails.First(i => i.Id == id);
        }

        public void AddPersonalDetails(PersonalDetails PersonalDetails)
        {
            _context.PersonalDetails.Add(PersonalDetails);
            _context.SaveChanges();
        }

        public void DeletePersonalDetails(int id)
        {
            var details = GetPersonalDetailsById(id);
            _context.PersonalDetails.Remove(details);
            _context.SaveChanges();
        }

        public void UpDatePersonalDetails(int id, PersonalDetails personalDetails)
        {
            var details = GetPersonalDetailsById(id);
            if (details != null)
            {
                details.Address = personalDetails.Address;
                details.Pelephon = personalDetails.Pelephon;
                details.Phone = personalDetails.Phone;
                details.DateBirth = personalDetails.DateBirth;
                details.Tz = personalDetails.Tz;
                details.FirstName = personalDetails.FirstName;
                details.LastName = personalDetails.LastName;
                details.City = personalDetails.City;
                details.FileData=personalDetails.FileData;
                details.FileType=personalDetails.FileType;
                _context.SaveChanges();
            }
        }
    }
}
