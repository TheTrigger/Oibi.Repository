﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oibi.Repository.Interfaces;
using System;
using System.Linq;

namespace Oibi.Repository.Abstracts
{
    public abstract class RepositoryEntityBase<T, PK> : RepositoryBase<T>
        where T : class, IEntity<PK>, new()
        where PK : struct
    {
        protected RepositoryEntityBase(DbContext repositoryContext, IMapper mapper) : base(repositoryContext, mapper)
        {
        }

        #region RETRIEVE

        /// <summary>
        /// Retrieve <see cref="T"/> by <see cref="PK"/>
        /// </summary>
        /// <param name="id">Primary Key</param>
        public T Retrieve(PK id) => Set.Single(s => s.Id.Equals(id));

        #endregion RETRIEVE

        #region UPDATE

        public T Update(PK id, T entity) => Update(entity.Id = id);

        public T Update(PK id, object data) => Update(id, _mapper.Map<T>(data));

        public MAP Update<MAP>(PK id, T data) => _mapper.Map<MAP>(Update(id, data));

        /// <summary>
        /// Update from Dto entity by id and map to <see cref="MAP"/>
        /// </summary>
        /// <typeparam name="MAP">Destination type</typeparam>
        /// <param name="id">Primary Key</param>
        /// <param name="data">Dto data</param>
        public MAP Update<MAP>(PK id, object data) => _mapper.Map<MAP>(Update(id, data));

        #endregion UPDATE

        #region DELETE

        public T Delete(PK id) => Set.Remove(new T { Id = id }).Entity;

        #endregion DELETE
    }
}