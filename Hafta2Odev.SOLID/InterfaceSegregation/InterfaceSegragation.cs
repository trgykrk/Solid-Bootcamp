using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hafta2Odev.SOLID.Utilities;

namespace Hafta2Odev.SOLID.InterfaceSegregation
{
    public class InterfaceSegragation :IPrinciple
    {
        public string Principle()
        {
            return "Interface Segregation  : Sorumlulukların hepsini tek bir arayüze toplamak yerine daha özelleştirilmiş birden fazla arayüz oluşturmayı tercih etmemizi söyleyen prensiptir. ";
        }

        interface ICustomer
        {
            void Add();
        }
        // BAD:
        interface ICustomerImproved
        {
            void Add();
            void Read(); //  BAD
        }


        // GOOD:
        interface ICustomerV1 : ICustomer
        {
            void Read();
        }

        class CustomerWithRead : ICustomer, ICustomerV1
        {
            public void Add()
            {
                var customer = new Customer();
                customer.Add(new Database());
            }

            public void Read()
            {
                // GOOD: Yeni işlevler eklenebilir
            }
        }

        void ManipulateCustomers()
        {
            var database = new Database();
            var customer = new Customer();
            customer.Add(database);
            var readCustomer = new CustomerWithRead();
            readCustomer.Read();
        }
    }
}
