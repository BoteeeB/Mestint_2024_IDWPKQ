using System;
using System.Collections.Generic;
using WinForm_APP_IDWPKQ;

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
            HashSet<Node> visited = new HashSet<Node>();
            stack.Push(StartNode);

            while (stack.Count > 0)
            {
                Node actual = stack.Pop();
                visited.Add(actual);
                int depth = actual.Depth;

                if (depth >= limit && limit > 0)
                    continue;

                if (actual.IsTerminal)
                    return actual;

                foreach (Penzerme_Action action in Enum.GetValues(typeof(Penzerme_Action)))
                {
                    Node newNode = new Node(actual);
                    if (newNode.State.ApplyOperator(true, action))
                    {
                        if (!visited.Contains(newNode))
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
