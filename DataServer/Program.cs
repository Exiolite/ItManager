using Models.External;

namespace DataServer
{
    public class Program
    {
        public static DataContext DataContext { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter DataPassword");
            new ServerSocket(Console.ReadLine());
        }

        public static void Merge(DataContext dataContext)
        {
            //DataContext.Merge(dataContext);
        }
    }
}