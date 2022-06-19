using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hafta2Odev.SOLID.Utilities;

namespace Hafta2Odev.SOLID.OpenClosed
{
    public class OpenClosed : IPrinciple
    {
        public string Principle()
        {
            return "Open Closed : Gelişime  açık değişime  kapalı olmalıdır. Bir sınıf ya da fonksiyon var olan özellikleri korumalı yani davranışını değiştirmiyor olmalı ve yeni özellikler kazanabilmelidir.";
        }
    }

    //BAD :  Prensibi ihlal eder 
    internal class Customer
    {
        public int Type;

        public virtual void Add(Database db)
        {
            if (Type == 0)
            {
                db.Add();
            }
            else
            {
                db.AddExistingCustomer();
            }
        }
    }

    // GOOD 
    internal class CustomerBetter
    {
        public virtual void Add(Database db)
        {
            db.Add();
        }
    }

    internal class ExistingCustomer : CustomerBetter
    {
        public override void Add(Database db)
        {
            db.AddExistingCustomer();
        }
    }

    internal class AnotherCustomer : CustomerBetter
    {
        public override void Add(Database db)
        {
            db.AnotherExtension();
        }
    }
}
