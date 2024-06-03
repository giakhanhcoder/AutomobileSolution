using AutomobileLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        private static List<Car> carList = new List<Car>
        {
            new Car{ CarId = 1, CarName = "CRV", Manufacturer = "Honda",
            Price = 30000, ReleaseYear = 2021},
            new Car{ CarId = 2, CarName = "Ford Focus", Manufacturer = "Ford",
            Price = 15000, ReleaseYear = 2020}
        };

        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }

        public List<Car> getCarList => carList;

        public Car getCarByID(int carID)
        // using LINQ to Object
        {
            Car car = carList.SingleOrDefault(pro => pro.CarId == carID);
            return car;
        }

        // Add new a car
        public void addNew(Car car)
        {
            Car pro = getCarByID(car.CarId);
            if (pro == null)
            {
                carList.Add(car);
            }
            else
            {
                throw new Exception("Car is already exists.");
            }
        }

        // Update a car
        public void Update(Car car)
        {
            Car c = getCarByID(car.CarId);
            if (c != null)
            {
                var index = carList.IndexOf(c);
                carList[index] = car;
            }
            else
            {
                throw new Exception("Car dos not already exists.");
            }
        }

        // Remove a car
        public void Remove(int carID)
        {
            Car p = getCarByID(carID);
            if (p != null)
            {
                carList.Remove(p);
            }
            else
            {
                throw new Exception("Car dos not already exists.");
            }
        }





    }
}
