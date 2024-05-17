using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    public class Backtrack : SolverBase
    {
        static Random rnd = new Random();

        int limit;
        bool isMemorisable;

        public Backtrack(int limit, bool isMemorisable)
        {
            this.limit = limit;
            this.isMemorisable = isMemorisable;
        }
        public Backtrack() : this(0, false) { }
        public Backtrack(int limit) : this(limit, false) { }
        public Backtrack(bool isMemorisable) : this(0, isMemorisable) { }

        public override Node Search()
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(StartNode);

            while (stack.Count > 0)
            {
                Node actual = stack.Pop();
                int depth = actual.Depth;

                if (limit > 0 && depth >= limit)
                    continue;

                Node parent = null;
                if (isMemorisable)
                    parent = actual.Parent;
                while (parent != null)
                {
                    if (actual.Equals(parent))
                        break;
                    parent = parent.Parent;
                }

                if (actual.IsTerminal)
                    return actual;

                bool[] bools = rnd.NextDouble() < 0.5 ? new bool[] { false, true } : new bool[] { true, false };
                foreach (bool isCoinCentral in bools)
                {
                    foreach (Penzerme_Action action in Enum.GetValues(typeof(Penzerme_Action)))
                    {
                        Node newNode = new Node(actual);
                        if (newNode.State.ApplyOperator(isCoinCentral, action))
                        {
                            stack.Push(newNode);
                        }
                    }
                }
            }

            return null;
        }

    }
}
