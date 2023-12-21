using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);
        void Update( Car car);
        void Delete(int Id);   
        
        List<Car> GetAll();
        Car GetById(int Id);

    }
}
