using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dices
{
    public class InvalidEdgeException : Exception
    {
        public int Edge
        {
            get;
            private set;
        }

        public InvalidEdgeException(int edge)
        {
            Edge = edge;
        }

        public string ToString()
        {
            return "Invalid Edge: " + Edge.ToString();
        }
    }
}
