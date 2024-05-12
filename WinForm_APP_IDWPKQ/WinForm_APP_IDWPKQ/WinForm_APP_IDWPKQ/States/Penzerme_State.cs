using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_APP_IDWPKQ;

namespace WinForm_APP_IDWPKQ
{
    public class Penzerme_State : State, IOperatorHandler<bool, Penzerme_Action>
    {
        public int[,] board;
        private int[] centralCoins;



        public Penzerme_State()
        {
            board = new int[4, 4];
            centralCoins = new int[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = 0;
                }
            }
            board[1, 1] = 1;
            board[1, 2] = 1;
            board[2, 1] = 1;
            board[2, 2] = 1;

            // Középső érméket beállítjuk
            centralCoins[1] = 1;
            centralCoins[2] = 1;
            centralCoins[3] = 1;
            centralCoins[0] = 1;
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
                return board[0, 0] == 1 && board[0, 3] == 1 && board[3, 0] == 1 && board[3, 3] == 1;
            }
        }

        public bool ApplyOperator(bool isCoinInCentralPosition, Penzerme_Action action)
        {
            if (!IsOperator(isCoinInCentralPosition, action))
                return false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 1)
                    {
                        for (int step = 1; step <= 3; step++)
                        {
                            switch (action)
                            {
                                case Penzerme_Action.LEFT:
                                    if (j >= step && board[i, j - step] == 0 && IsNeighbor(i, j))
                                    {
                                        board[i, j] = 0;
                                        board[i, j - step] = 1;
                                        return true;
                                    }
                                    break;
                                case Penzerme_Action.RIGHT:
                                    if (j + step < 4 && board[i, j + step] == 0 && IsNeighbor(i, j))
                                    {
                                        board[i, j] = 0;
                                        board[i, j + step] = 1;
                                        return true;
                                    }
                                    break;
                                case Penzerme_Action.UP:
                                    if (i >= step && board[i - step, j] == 0 && IsNeighbor(i, j))
                                    {
                                        board[i, j] = 0;
                                        board[i - step, j] = 1;
                                        return true;
                                    }
                                    break;
                                case Penzerme_Action.DOWN:
                                    if (i + step < 4 && board[i + step, j] == 0 && IsNeighbor(i, j))
                                    {
                                        board[i, j] = 0;
                                        board[i + step, j] = 1;
                                        return true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return false;
        }




        public bool IsNeighbor(int row, int col)
        {
            int[] dx = { -1, 0, 1, 0 }; // Exclude diagonals
            int[] dy = { 0, 1, 0, -1 }; // Exclude diagonals

            for (int i = 0; i < 4; i++) // Iterate through all 4 directions
            {
                int newRow = row + dx[i];
                int newCol = col + dy[i];
                if (newRow >= 0 && newRow < 4 && newCol >= 0 && newCol < 4 &&
                    ((newRow != 1 || newCol != 1) && board[newRow, newCol] == 1)) // Exclude center tile and check for coin
                {
                    return true;
                }
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

        public override int GetHashCode()
        {
            return this.board.GetHashCode() + this.centralCoins.GetHashCode();
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
