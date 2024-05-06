using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    internal class Penzerme_State : State, IOperatorHandler<bool, Penzerme_Action>
    {
        private int[,] board;
        private int[] centralCoins;

        public Penzerme_State()
        {
            board = new int[4,4];
            centralCoins = new int[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                board[i, 1] = 1;
                centralCoins[i] = 1;
            }
        }

        public override bool IsState
        {
            get
            {
                for (int i = 0; i < 4; i++)
                {
                    if (board[i, 1] != 1 && board[i, 2] != 1 && board[i, 3] != 1)
                        return false;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (board[1, i] != 1 && board[2, i] != 1 && board[3, i] != 1)
                        return false;
                }
                return true;
            }
        }

        public override bool IsGoalState
        {
            get
            {
                for (int i = 0; i < 4; i++)
                {
                    if (board[i, 0] != 1 && board[0, i] != 1 && board[i, 3] != 1 && board[3, i] != 1)
                        return false;
                }
                return true;
            }
        }

        public bool ApplyOperator(bool isCoinInCentralPosition, Penzerme_Action action)
        {
            // Akció alkalmazása a játékállapotra
            if (!IsOperator(isCoinInCentralPosition, action))
                return false;

            int coinRow = -1;
            int coinCol = -1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 1)
                    {
                        coinRow = i;
                        coinCol = j;
                        break;
                    }
                }
                if (coinRow != -1)
                    break;
            }

            switch (action)
            {
                case Penzerme_Action.LEFT:
                    if (coinCol > 0 && board[coinRow, coinCol - 1] == 0)
                    {
                        board[coinRow, coinCol] = 0;
                        board[coinRow, coinCol - 1] = 1;
                        return true;
                    }
                    break;
                case Penzerme_Action.RIGHT:
                    if (coinCol < 3 && board[coinRow, coinCol + 1] == 0)
                    {
                        board[coinRow, coinCol] = 0;
                        board[coinRow, coinCol + 1] = 1;
                        return true;
                    }
                    break;
                case Penzerme_Action.UP:
                    if (coinRow > 0 && board[coinRow - 1, coinCol] == 0)
                    {
                        board[coinRow, coinCol] = 0;
                        board[coinRow - 1, coinCol] = 1;
                        return true;
                    }
                    break;
                case Penzerme_Action.DOWN:
                    if (coinRow < 3 && board[coinRow + 1, coinCol] == 0)
                    {
                        board[coinRow, coinCol] = 0;
                        board[coinRow + 1, coinCol] = 1;
                        return true;
                    }
                    break;
            }
            return false;
        }

        public override State DeepClone()
        {
            Penzerme_State clone = new Penzerme_State();
            clone.board = (int[,])board.Clone();
            clone.centralCoins = (int[])centralCoins.Clone();
            return clone;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetHashCode() != obj.GetHashCode())
                return false;

            Penzerme_State other = (Penzerme_State)obj;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (this.board[i, j] != other.board[i, j])
                        return false;
                }
            }
            return true;
        }

        public bool IsOperator(bool isCoinInCentralPosition, Penzerme_Action action)
        {
            // Akció lehetséges voltának ellenőrzése
            if (isCoinInCentralPosition)
            {
                switch (action)
                {
                    case Penzerme_Action.LEFT:
                        return centralCoins[1] == 1;
                    case Penzerme_Action.RIGHT:
                        return centralCoins[2] == 1;
                    case Penzerme_Action.UP:
                        return centralCoins[3] == 1;
                    case Penzerme_Action.DOWN:
                        return centralCoins[0] == 1;
                }
            }
            return false;
        }
    }
}
