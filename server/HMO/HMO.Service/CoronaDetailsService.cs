using HMO.Core.Entities;
using HMO.Core.Repositories;
using HMO.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Service
{
    public class CoronaDetailsService : ICoronaDetailsService
    {
        private readonly ICoronaDetailsRep _coronaDetailsRep;
        public CoronaDetailsService(ICoronaDetailsRep coronaDetailsRep)
        {
            _coronaDetailsRep = coronaDetailsRep;
        }
        public List<CoronaDetails> GetCoronaDetails()
        {
            return _coronaDetailsRep.GetCoronaDetails();
        }
        public CoronaDetails GetCoronaDetailsById(int id)
        {
            return _coronaDetailsRep.GetCoronaDetailsById(id);
        }
        public void AddCoronaDetails(CoronaDetails coronaDetails)
        {
            _coronaDetailsRep.AddCoronaDetails(coronaDetails);
        }
        public void UpDateCoronaDetails(int id, CoronaDetails coronaDetails)
        {
            _coronaDetailsRep.UpDateCoronaDetails(id, coronaDetails);
        }
        public void DeleteCoronaDetails(int id)
        {
            _coronaDetailsRep.DeleteCoronaDetails(id);
        }
    }
}
