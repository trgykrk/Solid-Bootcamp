using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hafta2Odev.SOLID.Utilities;

namespace Hafta2Odev.SOLID.Liskov
{
    public class Liskov : IPrinciple
    {
        public string Principle()
        {
            return "Liskov Substitution : Kodlarımızda herhangi bir değişiklik yapmaya gerek duymadan alt sınıfları, türedikleri(üst) sınıfların yerine kullanabilmeliyiz.";
        }

        // BAD : Liskov prensibini ihlal eden yöntem
        class Enquiry : Customer
        {
            public override int Discount(int sales)
            {
                return this.BaseDiscount - (sales * 5);
            }

            public override void Add(Database db)
            {
                throw new Exception("Not allowed");
            }
        }
        //BAD
        public class GoldCustomer : Customer
        {
            public override int Discount(int sales)
            {
                return BaseDiscount - sales - 100;
            }
        }

        public class SilverCustomer : Customer
        {
            public override int Discount(int sales)
            {
                return BaseDiscount - sales - 50;
            }
        }

        class ViolatingLiskovs
        {
            public void ParseCustomers()
            {
                var database = new Database();
                var customers = new List<Customer>
                {
                    new GoldCustomer(),
                    new SilverCustomer(),
                    new Enquiry() 
                };

                foreach (Customer c in customers)
                {
                    c.Add(database);
                }
            }
        }

        // Better method:
        interface IDiscount
        {
            int Discount(int sales);
        }

        interface IDatabase
        {
            void Add(Database db);
        }

        internal class BetterCustomer : IDiscount, IDatabase
        {
            public virtual int Discount(int sales)
            {
                return sales;
            }

            public void Add(Database db)
            {
                db.Add();
            }
        }

        internal class BetterGoldCustomer : BetterCustomer
        {
            public override int Discount(int sales)
            {
                return sales - 100;
            }
        }

        internal class BetterSilverCustomer : BetterCustomer
        {
            public override int Discount(int sales)
            {
                return sales - 50;
            }
        }

        // GOOD:  Liskov  prensibini ihlal etmeyen  yöntem
        class AdheringToLiskovs
        {
            public void ParseCustomers()
            {
                var database = new Database();
                var customers = new List<BetterCustomer>
                {
                    new BetterGoldCustomer(),
                    new BetterSilverCustomer(),
                };

                foreach (BetterCustomer c in customers)
                {
                    c.Add(database);
                }
            }
        }
    }
}
