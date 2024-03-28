using HMO.Core.Entities;
using HMO.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Data.Repositories
{
    public class CoronaDetailsRep : ICoronaDetailsRep
    {
        private readonly DataContext _context;
        public CoronaDetailsRep(DataContext context)
        {
            _context = context;
        }
        public List<CoronaDetails> GetCoronaDetails()
        {
            return _context.CoronaDetails.ToList();
        }
        public CoronaDetails GetCoronaDetailsById(int id)
        {
            return _context.CoronaDetails.First(i => i.Id == id);
        }

        public void AddCoronaDetails(CoronaDetails coronaDetails)
        {
           _context.CoronaDetails.Add(coronaDetails);
           _context.SaveChanges();
        }

        public void DeleteCoronaDetails(int id)
        {
            var details = GetCoronaDetailsById(id);
            _context.CoronaDetails.Remove(details);
            _context.SaveChanges();
        }

        public void UpDateCoronaDetails(int id, CoronaDetails coronaDetails)
        {
            var details = GetCoronaDetailsById(id);
            if(details != null)
            {
                details.ProducerFourth = coronaDetails.ProducerFourth;
                details.ProducerThird=coronaDetails.ProducerThird;
                details.ProducerFirst = coronaDetails.ProducerFirst;
                details.ProducerSecond=coronaDetails.ProducerSecond;
                details.SecondVaccination=coronaDetails.SecondVaccination;
                details.ThirdVaccination = coronaDetails.ThirdVaccination;
                details.FirstVaccination = coronaDetails.FirstVaccination;
                details.FourhVaccination = coronaDetails.FourhVaccination;
                details.DataRecover = coronaDetails.DataRecover;
                details.DataSick = coronaDetails.DataSick;
                _context.SaveChanges();
            }
        }
    }
}
