﻿using Likegram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.DataAccess.Entityframework
{
    public class EFEntityRepostioryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<bool> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                EntityEntry entityEntry = context.Entry(entity);
                bool result = entityEntry.State == EntityState.Added;
                await context.SaveChangesAsync();
                return result;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                EntityEntry entityEntry = context.Entry(entity);
                bool result = entityEntry.State == EntityState.Deleted;
                await context.SaveChangesAsync();
                return result;
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            using(var context = new TContext())
            {
                EntityEntry<TEntity> entityEntry = context.Entry(entity);
                bool result = entityEntry.State == EntityState.Modified;
                await context.SaveChangesAsync();
                return result;
            }
        }
    }
}