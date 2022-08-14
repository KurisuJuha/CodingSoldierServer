using CodingSoldierServer;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Server.StartServer(program.Update);

            program.Start();
            while (true) { }
        }

        public void Start()
        {
            Console.WriteLine("start");
        }

        public void Update()
        {
            Console.WriteLine(Server.Soldiers[0].ToString() + "," + Server.Enemies[0].ToString());
        }
    }
}