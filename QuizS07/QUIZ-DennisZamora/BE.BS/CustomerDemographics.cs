using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using BE.DAL.DO.Objects;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class CustomerDemographics : ICRUD<data.CustomerDemographics>
    {
        private dal.CustomerDemographics _dal;

        public CustomerDemographics(NDbContext dbContext)
        {
            _dal = new dal.CustomerDemographics(dbContext);
        }

        public void Delete(data.CustomerDemographics t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.CustomerDemographics> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.CustomerDemographics>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.CustomerDemographics GetOneById(string id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.CustomerDemographics> GetOneByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.CustomerDemographics t)
        {
            _dal.Insert(t);
        }

        public void Update(data.CustomerDemographics t)
        {
            _dal.Update(t);
        }
    }
}
