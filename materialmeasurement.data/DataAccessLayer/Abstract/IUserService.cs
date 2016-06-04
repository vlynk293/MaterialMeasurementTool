using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMeasurement.Data.DataAccessLayer.Abstract
{
    public interface IUserService
    {
        User SignIn(string username, string password);
        
        bool Add(User newInstance);

        bool Edit(User newInstance);

        bool Delete(string username);

        IEnumerable<User> GetAll();

        void SaveChanges(MaterialMeasurementEntities db);
    }
}
