﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;



namespace BE.DAL.Repository
{
    public interface IRepositoryCustomerDemographics<T> where T : class
    {
        IQueryable<T> AsQueryble();
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
        T GetOne(Expression<Func<T, bool>> predicado);
        T GetOnebyID(string id);

        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        void Commit();
        void AddRange(IEnumerable<T> t);
        void UpdateRange(IEnumerable<T> t);
        void RemoveRange(IEnumerable<T> t);
    }
}
