using MaterialMeasurement.Data.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Concrete
{
    public class UserService : IUserService
    {
        //MaterialMeasurementEntities db;
        public UserService()
        {
            //db = _db;
        }

        public User SignIn(string username, string password)
        {
            var db = new MaterialMeasurementEntities();

            var currentInstance = db.Users.FirstOrDefault(u => u.Username.Equals(username));
            if (currentInstance == null)
            {
                return null;
            }
            if (!currentInstance.Password.Equals(password))
            {
                return null;
            }
            return currentInstance;
        }

        public bool Add(User newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                db.Users.Add(newInstance);
                SaveChanges(db);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Edit(User newInstance)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.Users.FirstOrDefault(u => u.Username.Equals(newInstance.Username));
                if (currentInstance == null)
                {
                    return false;
                }
                currentInstance.Password = newInstance.Password;

                db.Entry(currentInstance).State = System.Data.Entity.EntityState.Modified;
                SaveChanges(db);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(string username)
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                var currentInstance = db.Users.FirstOrDefault(u => u.Username.Equals(username));
                if (currentInstance == null)
                {
                    return false;
                }
                db.Entry(currentInstance).State = System.Data.Entity.EntityState.Deleted;
                SaveChanges(db);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            var db = new MaterialMeasurementEntities();

            try
            {
                return db.Users.AsEnumerable();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void SaveChanges(MaterialMeasurementEntities db)
        {
            db.SaveChanges();
        }
    }
}
