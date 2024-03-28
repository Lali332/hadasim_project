using HMO.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMO.Core.Repositories
{
    public interface ICoronaDetailsRep
    {
        public List<CoronaDetails> GetCoronaDetails();
        public CoronaDetails GetCoronaDetailsById(int id);
        public void AddCoronaDetails(CoronaDetails coronaDetails);
        public void UpDateCoronaDetails(int id ,CoronaDetails coronaDetails);
        public void DeleteCoronaDetails(int id );
    }
}
