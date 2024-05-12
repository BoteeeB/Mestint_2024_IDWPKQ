﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_APP_IDWPKQ;

namespace WinForm_APP_IDWPKQ
{
    public class Node
    {
        Penzerme_State state;
        int depth;
        Node parent;

        public Node()
        {
            this.state = new Penzerme_State();
            this.depth = 0;
            this.parent = null;
        }

        public Node(Node parent)
        {
            this.state = (Penzerme_State)parent.state.DeepClone();
            this.depth = parent.depth + 1;
            this.parent = parent;
        }

        public int Depth { get { return this.depth; } }
        public Node Parent { get { return this.parent; } }
        public Penzerme_State State { get { return this.state; } }
        public bool IsTerminal { get { return this.state.IsGoalState; } }

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
