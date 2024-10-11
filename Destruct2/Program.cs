namespace Destruct2
{


    class aPlay
    {
     
        public string Name { get; set; }
        public string AvtorName { get; set; } 
        public string Genre { get; set; }   
        public int Year { get; set; }
        public bool disposed = false;
        public aPlay(string name, string avtorName, string genre, int year)
        {
            Name = name;
            AvtorName = avtorName;
            Genre = genre;
            Year = year;
            disposed = true;
        }
        public void Print()
        {
            Console.WriteLine("Name: " +  Name);
            Console.WriteLine("AvtorName: " +  AvtorName);
            Console.WriteLine("Genre: " +  Genre);
            Console.WriteLine("Year: " + Year);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~aPlay()
        {
            Dispose(false);
            Console.WriteLine("End of the play");

        }

    


        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Name = null;
                    AvtorName = null;
                    Genre = null;
                    Year = 0;

                }
            }
        }


    }


    enum Type
    {
        Shoes, Clothes, Provide, Ferm, Unknown
    }

    class Shop
    {
        public string Name { get; set; }
        public string Adres { get; set; }

        public Type Type { get; set; }

        public bool disposed = false;

        public Shop(string name, string adres, Type type)
        {
            Name = name;
            Adres = adres;
            Type = type;
            disposed = true;
        }
        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Adres: " + Adres);
            Console.WriteLine("Type: " + Type);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Shop()
        {
            Dispose(false);
            Console.WriteLine("The shop is closed");

        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Name = null;
                    Adres = null;
                    Type = Type.Unknown;

                }
            }
        }



    }



    internal class Program
    {
        static void Main(string[] args)
        {
            //N1
            aPlay obj = new aPlay("Miracle", "JohnEvans", "Drama", 1890);
            obj.Print();
            //N2
            Shop obj2 = new Shop("Light", "Street n2", Type.Provide);
            obj2.Print();


            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
