using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    public class DepthFirst : SolverBase
    {
        Stack<Node> openNodes;
        List<Node> closedNodes;
        private bool checkCircle;

        public DepthFirst(bool checkCircle = true)
        {
            this.openNodes = new Stack<Node>();
            this.openNodes.Push(base.StartNode);
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
                Node openNode = openNodes.Pop();
                List<Node> children = openNode.GetAllChildren();
                foreach (Node node in children)
                {
                    if (node.IsTerminal)
                        return node;

                    if (!closedNodes.Contains(node) && !openNodes.Contains(node))
                        openNodes.Push(node);
                }
                closedNodes.Add(openNode);
            }

            return null;
        }
        private Node SearchWithoutCircleCheck()
        {
            while (openNodes.Count != 0)
            {
                Node openNode = openNodes.Pop();
                List<Node> children = openNode.GetAllChildren();
                foreach (Node node in children)
                {
                    if (node.IsTerminal)
                        return node;

                    openNodes.Push(node);
                }
            }

            return null;
        }


    }

    
}
