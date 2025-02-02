﻿using Kanban.Core.Entities.Common;
using Kanban.DataAccess.Abstracts.Base;
using Kanban.DataAccess.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.DataAccess.Repositories.Implementations.Base
{
    public abstract class EFBaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly KanbanContext _db;
        private readonly DbSet<TEntity> _dbTable;

        public EFBaseRepository(KanbanContext db)
        {
            _db = db;
            _dbTable = db.Set<TEntity>();
        }

        public async virtual Task<List<TEntity>> GetAllAsync()
        {
            return await _dbTable.ToListAsync();
        }

        public async virtual Task<TEntity> GetAsync(object id)
        {
            return await _dbTable.FindAsync(id);
        }

        public async virtual Task CreateAsync(TEntity data)
        {
            await _dbTable.AddAsync(data);
        }

        public async virtual Task UpdateAsync(TEntity data)
        {
            _dbTable.Attach(data);
            _db.Entry(data).State = EntityState.Modified;
        }

        public async virtual Task DeleteAsync(TEntity data)
        {
            _dbTable.Remove(data);
        }
    }
}
