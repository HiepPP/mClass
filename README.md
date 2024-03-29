# mClass
using System;
using System.Collections.Generic;
using System.Linq;
using SSC.ComicOnline.Models;

namespace SSC.ComicOnline.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
    {
        public TEntity FindById(Guid id)
        {
            try
            {
                using (var db = new SscContext())
                {
                    var result = db.Set<TEntity>().FirstOrDefault(x => x.Id == id);
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Insert(List<TEntity> list)
        {
            using (var db = new SscContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Set<TEntity>().AddRange(list);
                        db.SaveChanges();
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool Update(TEntity item)
        {
            try
            {
                using (var db = new SscContext())
                {
                    TEntity entity = db.Set<TEntity>().FirstOrDefault(x => x.Id == item.Id);
                    if (entity != null)
                    {
                        db.Entry(entity).CurrentValues.SetValues(item);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(List<TEntity> dtoList)
        {
            using (var db = new SscContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    TEntity entity = null;
                    try
                    {

                        var dbSet = db.Set<TEntity>();
                        dtoList.ForEach(x =>
                        {
                            entity = dbSet.Find(x.Id);
                            if (entity != null)
                            {
                                db.Entry(entity).CurrentValues.SetValues(x);
                            }
                        });

                        db.SaveChanges();
                        trans.Commit();//Data Saved Successfully. Transaction Commited
                        return true;

                    }
                    catch (Exception)
                    {
                        trans.Rollback();//Error Occured during data saved. Transaction Rolled Back
                        return false;
                    }
                }
            }
        }

        public bool DisableById(Guid id)
        {
            try
            {
                using (var db = new SscContext())
                {
                    TEntity entity = db.Set<TEntity>().FirstOrDefault(x => x.Id == id);
                    if (entity != null)
                    {
                        entity.IsActive = false;
                        db.Entry(entity).CurrentValues.SetValues(entity);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActiveById(Guid id)
        {
            try
            {
                using (var db = new SscContext())
                {
                    TEntity entity = db.Set<TEntity>().FirstOrDefault(x => x.Id == id);
                    if (entity != null)
                    {
                        entity.IsActive = true;
                        db.Entry(entity).CurrentValues.SetValues(entity);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(TEntity item)
        {
            try
            {
                using (var db = new SscContext())
                {
                    db.Set<TEntity>().Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(Guid id)
        {
            try
            {
                using (var db = new SscContext())
                {
                    TEntity entity = db.Set<TEntity>().FirstOrDefault(x => x.Id == id);
                    if (entity != null)
                    {
                        entity.IsDeleted = true;
                        db.Entry(entity).CurrentValues.SetValues(entity);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int TotalItem()
        {
            try
            {
                using (var db = new SscContext())
                {
                    return db.Set<TEntity>().Where(i => i.IsDeleted == false).ToList().Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using (var db = new SscContext())
                {
                    return db.Set<TEntity>().Where(i => i.IsDeleted == false).ToList();
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<TEntity>();
            }
        }

        public IEnumerable<TEntity> GetAllActive()
        {
            try
            {
                using (var db = new SscContext())
                {
                    return db.Set<TEntity>().Where(i => i.IsDeleted == false && i.IsActive == true).ToList();
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<TEntity>();
            }
        }

        public int TotalItemActive()
        {
            try
            {
                using (var db = new SscContext())
                {
                    return db.Set<TEntity>().Where(i => i.IsDeleted == false && i.IsActive == true).ToList().Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IEnumerable<TEntity> GetAll(int pageindex, int takerecord)
        {
            try
            {
                using (var db = new SscContext())
                {
                    return db.Set<TEntity>().Where(i => i.IsDeleted == false).Skip((pageindex - 1) * takerecord).Take(takerecord).ToList();
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<TEntity>();
            }
        }

        public IEnumerable<TEntity> GetAllActive(int pageindex, int takerecord)
        {
            try
            {
                using (var db = new SscContext())
                {
                    return db.Set<TEntity>().Where(i => i.IsDeleted == false && i.IsActive == true).Skip((pageindex - 1) * takerecord).Take(takerecord).ToList();
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<TEntity>();
            }
        }
    }
}
