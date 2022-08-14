using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingGameBase;

namespace CodingSoldierServer
{
    public class Soldier
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public bool go { get; set; }
        public float angle { get; private set; }

        public Soldier(byte[] data)
        {
            DataReader dataReader = new DataReader(data);
            x = dataReader.GetFloat();
            y = dataReader.GetFloat();
            go = dataReader.GetBool();
            angle = dataReader.GetFloat();
        }

        public byte[] GetBytes()
        {
            DataWriter dataWriter = new DataWriter();



            return dataWriter.GetData();
        }

        public override string ToString()
        {
            return "(" + x.ToString() + "," + y.ToString() + ")";
        }
    }
}
