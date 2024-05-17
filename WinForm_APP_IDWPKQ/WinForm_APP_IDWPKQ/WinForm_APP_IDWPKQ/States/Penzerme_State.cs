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
        public char[,] baseboard = {
              { 'E', 'E', 'E', 'E' },
              { 'E', 'C', 'C', 'E' },
              { 'E', 'C', 'C', 'E' },
              { 'E', 'E', 'E', 'E' }
            };

        public char[,] goalboard = {
              { 'C', 'E', 'E', 'C' },
              { 'E', 'E', 'E', 'E' },
              { 'E', 'E', 'E', 'E' },
              { 'C', 'E', 'E', 'C' }
            };

        public char[,] Baseboard { get { return (char[,])baseboard.Clone(); } }
        public override bool IsState
        {
            get
            {
                int countE = (from char c in baseboard where c == 'E' select c).Count();
                int countC = (from char c in baseboard where c == 'C' select c).Count();

                return countE == 12 && countC == 4;
            }
        }

        public override bool IsGoalState
        {
            get
            {
                for (int i = 0; i < baseboard.GetLength(0); i++)
                {
                    for (int j = 0; j < baseboard.GetLength(1); j++)
                    {
                        if (baseboard[i, j] != goalboard[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool ApplyOperator(bool t1, Penzerme_Action action)
        {
            if (!IsOperator(t1, action)) return false;

            int dx = 0, dy = 0;
            switch (action)
            {
                case Penzerme_Action.UP1: dy = -1; break;
                case Penzerme_Action.UP2: dy = -2; break;
                case Penzerme_Action.UP3: dy = -3; break;
                case Penzerme_Action.DOWN1: dy = 1; break;
                case Penzerme_Action.DOWN2: dy = 2; break;
                case Penzerme_Action.DOWN3: dy = 3; break;
                case Penzerme_Action.LEFT1: dx = -1; break;
                case Penzerme_Action.LEFT2: dx = -2; break;
                case Penzerme_Action.LEFT3: dx = -3; break;
                case Penzerme_Action.RIGHT1: dx = 1; break;
                case Penzerme_Action.RIGHT2: dx = 2; break;
                case Penzerme_Action.RIGHT3: dx = 3; break;
            }

            for (int i = 0; i < baseboard.GetLength(0); i++)
            {
                for (int j = 0; j < baseboard.GetLength(1); j++)
                {
                    if (baseboard[i, j] == 'C')
                    {
                        int ni = i + dy, nj = j + dx;
                        if (IsInBounds(ni, nj) && baseboard[ni, nj] == 'E' && HasNeighbor(i, j))
                        {
                            baseboard[ni, nj] = 'C';
                            baseboard[i, j] = 'E';
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsOperator(bool t1, Penzerme_Action action)
        {
            int dx = 0, dy = 0;
            switch (action)
            {
                case Penzerme_Action.UP1: dy = -1; break;
                case Penzerme_Action.UP2: dy = -2; break;
                case Penzerme_Action.UP3: dy = -3; break;
                case Penzerme_Action.DOWN1: dy = 1; break;
                case Penzerme_Action.DOWN2: dy = 2; break;
                case Penzerme_Action.DOWN3: dy = 3; break;
                case Penzerme_Action.LEFT1: dx = -1; break;
                case Penzerme_Action.LEFT2: dx = -2; break;
                case Penzerme_Action.LEFT3: dx = -3; break;
                case Penzerme_Action.RIGHT1: dx = 1; break;
                case Penzerme_Action.RIGHT2: dx = 2; break;
                case Penzerme_Action.RIGHT3: dx = 3; break;
            }

            for (int i = 0; i < baseboard.GetLength(0); i++)
            {
                for (int j = 0; j < baseboard.GetLength(1); j++)
                {
                    if (baseboard[i, j] == 'C')
                    {
                        int ni = i + dy, nj = j + dx;
                        if (IsInBounds(ni, nj) && baseboard[ni, nj] == 'E' && HasNeighbor(i, j) && IsPathClear(i, j, ni, nj))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < 4 && y >= 0 && y < 4;
        }

        private bool HasNeighbor(int x, int y)
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i], ny = y + dy[i];
                if (IsInBounds(nx, ny) && baseboard[nx, ny] == 'C')
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPathClear(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2)
            {
                for (int y = Math.Min(y1, y2) + 1; y < Math.Max(y1, y2); y++)
                {
                    if (baseboard[x1, y] == 'C') return false;
                }
            }
            else if (y1 == y2)
            {
                for (int x = Math.Min(x1, x2) + 1; x < Math.Max(x1, x2); x++)
                {
                    if (baseboard[x, y1] == 'C') return false;
                }
            }
            return true;
        }

        public override State DeepClone()
        {
            Penzerme_State clone = new Penzerme_State();
            for (int i = 0; i < this.baseboard.GetLength(0); i++)
                for (int j = 0; j < this.baseboard.GetLength(1); j++)
                    clone.baseboard[i, j] = this.baseboard[i, j];
            return clone;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetHashCode() != obj.GetHashCode() || obj is not Penzerme_State)
                return false;

            Penzerme_State other = (Penzerme_State)obj;
            for (int i = 0; i < this.baseboard.GetLength(0); i++)
                for (int j = 0; j < this.baseboard.GetLength(1); j++)
                    if (this.baseboard[i, j] != other.baseboard[i, j])
                        return false;
            return true;
        }

        public override int GetHashCode()
        {
            return this.baseboard.GetHashCode();
        }
    }
}
