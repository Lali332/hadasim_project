using HMO.Core.Entities;
using HMO.Core.Repositories;
using HMO.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Service
{
    public class PersonalDetailsService : IPersonalDetailsService
    {
        private readonly IPersonalDetailsRep _PersonalDetailsRep;
        public PersonalDetailsService(IPersonalDetailsRep PersonalDetailsRep)
        {
            _PersonalDetailsRep = PersonalDetailsRep;
        }
        public List<PersonalDetails> GetPersonalDetails()
        {
            return _PersonalDetailsRep.GetPersonalDetails();
        }
        public PersonalDetails GetPersonalDetailsById(int id)
        {
            return _PersonalDetailsRep.GetPersonalDetailsById(id);
        }
        public void AddPersonalDetails(PersonalDetails PersonalDetails)
        {
            _PersonalDetailsRep.AddPersonalDetails(PersonalDetails);
        }
        public void UpDatePersonalDetails(int id, PersonalDetails PersonalDetails)
        {
            _PersonalDetailsRep.UpDatePersonalDetails(id, PersonalDetails);
        }
        public void DeletePersonalDetails(int id)
        {
            _PersonalDetailsRep.DeletePersonalDetails(id);
        }
    }
}