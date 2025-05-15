namespace Sports_DB.model
{
    internal class Program
    {
        private static Storagemanager storagemanager;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial" +
                " Catalog=\"sports managment \";Integrated Security=True;Connect " +
                "Timeout=30;Encrypt=False;Trust Server Certificate=False;Application " +
                "Intent=ReadWrite;Multi Subnet Failover=False";
            Storagemanager hello = new Storagemanager(connectionString);
            
        }
    }
}
