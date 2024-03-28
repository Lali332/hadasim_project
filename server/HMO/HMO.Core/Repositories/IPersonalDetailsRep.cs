using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Core.Repositories
{
    public interface IPersonalDetailsRep
    {
        public List<PersonalDetails> GetPersonalDetails();
        public PersonalDetails GetPersonalDetailsById(int id);
        public void AddPersonalDetails(PersonalDetails PersonalDetails);
        public void UpDatePersonalDetails(int id, PersonalDetails PersonalDetails);
        public void DeletePersonalDetails(int id);
    }
}
