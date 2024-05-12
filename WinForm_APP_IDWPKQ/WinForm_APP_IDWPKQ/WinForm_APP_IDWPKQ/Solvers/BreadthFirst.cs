using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    internal class BreadthFirst : SolverBase
    {
        Queue<Node> openNodes;
        List<Node> closedNodes;
        private bool checkCircle;

        public BreadthFirst(bool checkCircle = true)
        {
            this.openNodes = new Queue<Node>();
            this.openNodes.Enqueue(base.StartNode);
            this.closedNodes = new List<Node>();
            this.checkCircle = checkCircle;
        }

        public override Node Search()
        {
            return checkCircle ?
                SearchWithCircleCheck() :
                SearchWithoutCircleCheck();
        }

        private Node SearchWithCircleCheck()
        {
            while (openNodes.Count != 0)
            {
                Node openNode = openNodes.Dequeue();
                List<Node> children = openNode.GetAllChildren();
                foreach (Node node in children)
                {
                    if (node.IsTerminal)
                        return node;

                    if (!closedNodes.Contains(node) && !openNodes.Contains(node))
                        openNodes.Enqueue(node);
                }
                closedNodes.Add(openNode);
            }

            return null;
        }
        private Node SearchWithoutCircleCheck()
        {
            while (openNodes.Count != 0)
            {
                Node openNode = openNodes.Dequeue();
                List<Node> children = openNode.GetAllChildren();
                foreach (Node node in children)
                {
                    if (node.IsTerminal)
                        return node;

                    openNodes.Enqueue(node);
                }
            }

            return null;
        }
    }
}
