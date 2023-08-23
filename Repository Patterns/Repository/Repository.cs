﻿using Microsoft.EntityFrameworkCore;
using Repository_Patterns.Repository;
using Repository_Patterns;

namespace RepositoryPattern.Repository
{

    public class Repository<T> : IRepository<T> where T: class

    {
        private DatabaseContext _dbContext;

        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().AddAsync(entity);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteAsync(T model)
        {
            try
            {
                _dbContext.Set<T>().Remove(model);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }

        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public T GetProductById(int Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }


        public Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                return Task.FromResult(false);
            }

        }
    }
}