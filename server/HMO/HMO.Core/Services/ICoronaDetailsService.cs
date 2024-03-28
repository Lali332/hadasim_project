using HMO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HMO.Core.Services
{
    public interface ICoronaDetailsService
    {
        public List<CoronaDetails> GetCoronaDetails();
        public CoronaDetails GetCoronaDetailsById(int id);
        public void AddCoronaDetails(CoronaDetails coronaDetails);
        public void UpDateCoronaDetails(int id, CoronaDetails coronaDetails);
        public void DeleteCoronaDetails(int id);
    }
}
