using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    public class Node
    {
        Penzerme_State state;
        int depth;
        Node parent;

        public Node()
        {
            this.State = new Penzerme_State();
            this.Depth = 0;
            this.Parent = null;
        }

        public Node(Node parent)
        {
            this.State = (Penzerme_State)parent.State.DeepClone();
            this.Depth = parent.Depth + 1;
            this.Parent = parent;
        }

        public bool IsTerminal { get { return this.State.IsGoalState; } }

        public int Depth { get => depth; set => depth = value; }
        public Node Parent { get => parent; set => parent = value; }
        internal Penzerme_State State { get => state; set => state = value; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;

            Node other = obj as Node;
            return this.state.Equals(other.state);
        }

        public override int GetHashCode()
        {
            return this.state.GetHashCode();
        }

        public override string ToString()
        {
            return this.state.ToString();
        }

        public List<Node> GetAllChildren()
        {
            List<Node> children = new List<Node>();
            foreach (bool bool1 in new bool[] { true, false })
            {
                foreach (Penzerme_Action action in Enum.GetValues(typeof(Penzerme_Action)))
                {
                    Node newNode = new Node(this);
                    if (newNode.state.ApplyOperator(bool1, action))
                        children.Add(newNode);
                }
            }
            return children;
        }
    }
}
