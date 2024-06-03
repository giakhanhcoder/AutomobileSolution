using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void DeleteCar(int carId) => CarDBContext.Instance.Remove(carId);

        public Car GetCarByID(int carId) => CarDBContext.Instance.getCarByID(carId);

        public IEnumerable<Car> GetCars() => CarDBContext.Instance.getCarList;

        public void InsertCar(Car car) => CarDBContext.Instance.addNew(car);

        public void UpdateCar(Car car) => CarDBContext.Instance.Update(car);
    
    }
}
