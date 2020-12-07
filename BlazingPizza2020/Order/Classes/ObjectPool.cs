using System;
using System.Collections.Generic;

namespace BlazingPizza2020.Order.Classes
{
    class ObjectPool<T> where T : new()
    {
        private static List<T> PizzasDisponible = new List<T>();
        private List<T> PizzasEnUso = new List<T>();

        public int Couter = 0;
        private int MAXTotalObjects;

        private static ObjectPool<T> Instance = null;

        public static ObjectPool<T> GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ObjectPool<T>();
            }
            else
            {
                Console.WriteLine("This is singleton!");
            }
            return Instance;
        }

        public T UtilizartPizza()
        {
            if (PizzasDisponible.Count != 0 && PizzasDisponible.Count < 10)
            {
                T item = PizzasDisponible[0];
                PizzasEnUso.Add(item);
                PizzasDisponible.RemoveAt(0);
                this.Couter --;
                return item;
            }
            else
            {
                T obj = new T();
                PizzasEnUso.Add(obj);
                return obj;
            }
        }

        public void RetornarPizza(T item)
        {
            if (this.Couter <= MAXTotalObjects)
            {
                PizzasDisponible.Add(item);
                this.Couter ++;
                PizzasEnUso.Remove(item);
            }
            else
            {
                Console.WriteLine("To much object in pool!");
            }
        }

        public void SetMaxPoolSize(int settingPoolSize)
        {
            this.MAXTotalObjects = settingPoolSize;
        }
    }
}
