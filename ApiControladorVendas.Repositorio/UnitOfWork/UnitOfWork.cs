﻿using ApiControladorVendas.Repositorio.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ApiControladorVendas.Repositorio.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;
        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Persistir()
        {
            try
            {
                foreach(object item in from x in _contexto.ChangeTracker.Entries()
                                                 where x.State == EntityState.Added 
                                                       ||x.State == EntityState.Modified
                                                 select x.Entity)
                {
                    ValidationContext validationContext = new ValidationContext(item);
                    Validator.ValidateObject(item, validationContext);
                }
                _contexto.SaveChanges();
            }
            catch (DbUpdateException exp)
            {

                RejectChanges();
                throw new Exception(exp.Message);
            }
            catch (ValidationException ex)
            {
                RejectChanges();
                throw new Exception(ex.Message);

            }
        }

        public void RejectChanges()
        {
            try
            {
                foreach (EntityEntry item in (from x in _contexto.ChangeTracker.Entries()
                                              where x.State != EntityState.Unchanged
                                              select x).ToList())
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            item.CurrentValues.SetValues(item.OriginalValues);
                            item.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            item.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                            item.State = EntityState.Unchanged;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }
            
        }

    }
}

