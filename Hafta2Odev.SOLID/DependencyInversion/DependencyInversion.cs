using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hafta2Odev.SOLID.Utilities;

namespace Hafta2Odev.SOLID.DependencyInversion
{
    public class DependencyInversion : IPrinciple
    {
        public string Principle()
        {
            return "Dependency Inversion : Sınıflar arası bağımlılıklar olabildiğince az olmalıdır özellikle üst seviye sınıflar alt seviye sınıflara bağımlı olmamalıdır.";
        }

        internal class FileLogger
        {
            public void Handle(string error)
            {
                File.WriteAllText(@"C:\Error.txt", error);
            }
        }

        internal class Customer
        {
            FileLogger logger = new FileLogger();

            public void Add(Database db)
            {
                try
                {
                    db.Add();
                }
                catch (Exception error)
                {
                    logger.Handle(error.ToString());
                }
            }
        }

        class BetterCustomer
        {
            private ILogger logger;
            public BetterCustomer(ILogger logger)
            {
                this.logger = logger;
            }

            public void Add(Database db)
            {
                try
                {
                    db.Add();
                }
                catch (Exception error)
                {
                    logger.Handle(error.ToString());
                }
            }
        }
        class EmailLogger : ILogger
        {
            public void Handle(string error)
            {
                File.WriteAllText(@"C:\Error.txt", error);
            }
        }

        interface ILogger
        {
            void Handle(string error);
        }
        void UseDependencyInjectionForLogger()
        {
            var customer = new BetterCustomer(new EmailLogger());
            customer.Add(new Database());
        }
    }
}
