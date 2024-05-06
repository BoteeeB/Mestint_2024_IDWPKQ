using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    public abstract class State : IDeepCloneable<State>
    {
        public abstract bool IsState { get; }
        public abstract bool IsGoalState { get; }

        public abstract State DeepClone();
        public abstract bool Equals(object obj);
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
