using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            EFRepository<Product> productRepository = new EFRepository<Product>();

            LoggingRepositoryDecorator<Product> updateDeleteLoggingDecorator = new LoggingRepositoryDecorator<Product>(productRepository);

            SendRequestRepositoryDecorator<Product> updateDeleteRequestDecorator = new SendRequestRepositoryDecorator<Product>(updateDeleteLoggingDecorator);

            DataWareHouseRepositoryDecorator<Product> updateDataWareHouseDecorator = new DataWareHouseRepositoryDecorator<Product>(updateDeleteRequestDecorator);

            SecurityRepositoryDecorator<Product> securityDecorator = new SecurityRepositoryDecorator<Product>(updateDataWareHouseDecorator);

            Product p = new Product() { ProductId = 1, ProductName = "Ürünüm 1" };

            #region Select işlemi
            Console.WriteLine("--------------------------------------------");

            securityDecorator.Get(3);

            Console.WriteLine("---------------------------------------------\n");
            #endregion

            #region Add işlemi
            Console.WriteLine("--------------------------------------------");

            securityDecorator.Add(p);

            Console.WriteLine("---------------------------------------------\n");
            #endregion

            #region Update ve Delete İşlemi
            Console.WriteLine("---------------------------------------------");

            securityDecorator.Delete(p);

            Console.WriteLine("---------------------------------------------\n");

            Console.WriteLine("---------------------------------------------");

            securityDecorator.Update(p);

            Console.WriteLine("---------------------------------------------\n");
            #endregion

            Console.ReadLine();
        }
    }

    // İstekler gelmeden önceki ilk Orjinal Hali
    public interface IRepository<T>
    {
        T Get(int id);
        void Add(T value);
        void Update(T value);
        void Delete(T value);
    }
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private Context<T> context;
        public EFRepository()
        {
            context = new Context<T>();

        }
        public T Get(int id)
        {
            return context.Get(id);
        }
        public void Add(T value)
        {
            context.Add(value);
        }
        public void Update(T value)
        {
            context.Update(value);
        }
        public void Delete(T value)
        {
            context.Delete(value);
        }
    }
    public class Context<T>
    {
        //bu sınıfın bir orm contexti olduğunu düşünün
        public void Add(T entity)
        {
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanına eklendi.");
        }

        public void Update(T entity)
        {
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanında güncellendi");
        }

        public void Delete(T entity)
        {
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanından silindi.");
        }
        public T Get(int id)
        {
            //Reflection ile o an gelen tipin Instance'ını alıyoruz
            Console.WriteLine("-'" + typeof(T).FullName + "' adlı entity veritabanından çekildi.");
            T entity = (T)Activator.CreateInstance(typeof(T));
            return entity;
        }
    }


    // İstekler Geldikden sonraki Decorator Hali
    // İlerde türeyecek olan tüm Decorator sınıfların için kullanacağımız interface Idecorator olarak düşünebiliriz
    public class DecoratorRepository<T> : IRepository<T>
    {
        private IRepository<T> repository;
        public DecoratorRepository(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public virtual T Get(int id)
        {
            return repository.Get(id);
        }
        public virtual void Add(T value)
        {
            repository.Add(value);
        }
        public virtual void Update(T value)
        {
            repository.Update(value);
        }
        public virtual void Delete(T value)
        {
            repository.Delete(value);
        }
    }
    public class SecurityRepositoryDecorator<T> : DecoratorRepository<T>
    {
        public SecurityRepositoryDecorator(IRepository<T> repository)
            : base(repository)
        {
        }
        public override T Get(int id)
        {
            Console.WriteLine("-" + typeof(T).FullName + " adlı entity için security kontrolü yapıldı"); //Decorator işlemi yapıyoruz
            return base.Get(id); // Base sınıfın select'ini çağırıyoruz
            // isteseydik buradada başka bir işlem yapabilirdik
        }
    }
    public class LoggingRepositoryDecorator<T> : DecoratorRepository<T>
    {
        public LoggingRepositoryDecorator(IRepository<T> repository)
            : base(repository)
        {
        }
        public override void Add(T value)
        {
            base.Add(value);
            Console.WriteLine("- " + typeof(T).FullName + " adlı entity için ADD Log'ı atıldı..");
        }
        public override void Update(T value)
        {
            base.Update(value);
            Console.WriteLine("- " + typeof(T).FullName + " adlı entity için UPDATE Log'ı atıldı..");
        }
        public override void Delete(T value)
        {
            base.Delete(value);
            Console.WriteLine("- " + typeof(T).FullName + " adlı entity için DELETE Log'ı atıldı..");
        }
    }
    public class SendRequestRepositoryDecorator<T> : DecoratorRepository<T>
    {
        public SendRequestRepositoryDecorator(IRepository<T> repository)
            : base(repository)
        {
        }
        public override void Delete(T value)
        {
            base.Delete(value);
            Console.WriteLine("- " + typeof(T).FullName + " Adlı entity için delete yapıldıkdan sonra CRM veritabanındaki silme için web servisine istek atıldı ");
        }
        public override void Update(T value)
        {
            base.Update(value);
            Console.WriteLine("- " + typeof(T).FullName + " Adlı entity için delete yapıldıkdan sonra CRM veritabanındaki silme için web servisine istek atıldı ");
        }
    }
    public class DataWareHouseRepositoryDecorator<T> : DecoratorRepository<T>
    {
        public DataWareHouseRepositoryDecorator(IRepository<T> repository)
            : base(repository)
        {
        }
        public override void Update(T value)
        {
            base.Update(value);
            Console.WriteLine("- " + typeof(T).FullName + " Adlı entity için UPDATE yapıldıkdan sonra DataWareHouseRepositoryDecorator güncelleme yapıldı.. ");
        }
    }

    // Program içinde kullanılan sınıflar
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }    
}