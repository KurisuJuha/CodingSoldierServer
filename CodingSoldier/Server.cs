using CodingGameBase;

namespace CodingSoldierServer
{
    public class Server
    {
        public static Action Update;
        public static CodingGameServer cgserver;

        public static void StartServer(Action update)
        {
            Update += update;

            cgserver = new CodingGameServer();
            cgserver.Tick = () =>
            {
                Update();
            };
            cgserver.StartServer();
        }
    }
}