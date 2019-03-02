using System.Net.Http.Headers;

namespace SOLID.ISP
{
    public interface IWideInterface
    {
        void A();
        void B();
        void C();
        void D();
    }

    public interface INarrowInterface
    {
        void A();
        void B();
    }

    class Adapter : INarrowInterface
    {
        private readonly IWideInterface _wide;

        public Adapter(IWideInterface wide)
        {
            _wide = wide;
        }

        public void A()
        {
            _wide.A();
        }

        public void B()
        {
            _wide.B();
        }
    }   

    //needs to use only A and B
    class Client
    {
        private readonly INarrowInterface _narrow;

        public Client(INarrowInterface narrow)
        {
            _narrow = narrow;
        }
    }

    public interface INewPersister
    {
        void SaveToCloud(string connectionString, string content);
    }

    public class Persister : INewPersister
    {
        public void SaveToFile(string file, string content)
        {

        }

        public void SaveToDb(string connectionString, string content)
        {

        }

        void INewPersister.SaveToCloud(string connectionString, string content)
        {            
        }
    }

    class PersisterClient
    {
        void Save()
        {
            Persister p = new Persister();
            //doesn't compile
            //p.SaveToCloud("", "")

            INewPersister np = new Persister();
            np.SaveToCloud("", ""); // compiles
        }
    }
}