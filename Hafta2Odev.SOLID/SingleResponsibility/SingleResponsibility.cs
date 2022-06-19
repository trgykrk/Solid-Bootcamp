using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hafta2Odev.SOLID.Utilities;

namespace Hafta2Odev.SOLID.SingleResponsibility
{
    public class SingleResponsibility :IPrinciple
    {
        public string Principle()
        {
            return "Single Responsibility : Tek işi, tek sorumlulukta yapma sanatı olarak özetlenebilir.";
        }
    }
    // BAD
    internal class Customer
    {
        // Bu Add yöntemi çok fazla şey yapıyor,
        // loga nasıl yazı yazılacağını ve müşteri ekleyeceğini bilmemeli
        public void Add(Database db)
        {
            try
            {
                db.Add();
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Error.txt", ex.ToString());
            }
        }
    }


    // İyi Yol bu  şekilde, tek sorumluluk ilkesini ihlal etmiyor
    // Şimdi kaydediciyi soyutladık, bu yüzden sadece hatayı yazıyor.
    class CustomerBetter
    {
        private FileLogger logger = new FileLogger();
        public void Add(Database db)
        {
            try
            {
                db.Add();
            }
            catch (Exception ex)
            {
                logger.Handle(ex.ToString());
            }
        }
    }
    internal class FileLogger
    {
        public void Handle(string error)
        {
            File.WriteAllText(@"C:\Error.txt", error);
        }
    }

    // Daha İyi Yol, müşteri yalnızca nasıl ekleneceğini bilir
    class Wrapper
    {
        public void HandleAdd(FileLogger logger, Database db, Customer customer)
        {
            try
            {
                customer.Add(db);
            }
            catch (Exception error)
            {
                logger.Handle(error.ToString());
            }
        }
    }
}
