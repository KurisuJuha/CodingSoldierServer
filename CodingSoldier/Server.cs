using CodingGameBase;

namespace CodingSoldierServer
{
    public class Server
    {
        private static Action Update;
        private static CodingGameServer cgserver;

        public static List<Soldier> Soldiers = new List<Soldier>();
        public static List<Soldier> Enemies = new List<Soldier>();

        public static void StartServer(Action update)
        {
            Update += update;

            cgserver = new CodingGameServer();
            cgserver.Tick = () =>
            {
                GetShareData();
                Update();
                SetShareData();
            };
            cgserver.StartServer();
        }

        private static void GetShareData()
        {
            Soldiers.Clear();
            Enemies.Clear();

            int SoldierCount = BitConverter.ToInt32(cgserver.sharedata["SoldierCount"].data);

            for (int i = 0; i < SoldierCount; i++)
            {
                Soldiers.Add(new Soldier(cgserver.sharedata["Soldier" + i].data));
            }

            int EnemiesCount = BitConverter.ToInt32(cgserver.sharedata["EnemiesCount"].data);

            for (int i = 0; i < EnemiesCount; i++)
            {
                Enemies.Add(new Soldier(cgserver.sharedata["Enemy" + i].data));
            }
        }

        private static void SetShareData()
        {
            cgserver.sharedata.Clear();

            cgserver.sharedata.Add("SoldierCount", new CodingGameData()
            {
                data = BitConverter.GetBytes(Soldiers.Count)
            });

            for (int i = 0; i < Soldiers.Count; i++)
            {
                cgserver.sharedata.Add("Soldier" + i, new CodingGameData()
                {
                    data = Soldiers[i].GetBytes()
                });
            }

            cgserver.sharedata.Add("EnemiesCount", new CodingGameData()
            {
                data = BitConverter.GetBytes(Enemies.Count)
            });

            for (int i = 0; i < Enemies.Count; i++)
            {
                cgserver.sharedata.Add("Enemy" + i, new CodingGameData()
                {
                    data = Enemies[i].GetBytes()
                });
            }
        }
    }
}