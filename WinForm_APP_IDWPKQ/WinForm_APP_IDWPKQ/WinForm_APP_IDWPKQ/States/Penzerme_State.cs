using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    internal class Penzerme_State : State, IOperatorHandler<bool, Penzerme_Action>
    {
        public override bool IsState => throw new NotImplementedException();

        public override bool IsGoalState => throw new NotImplementedException();

        public bool ApplyOperator(bool t1, Penzerme_Action t2)
        {
            throw new NotImplementedException();
        }

        public override State DeepClone()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public bool IsOperator(bool t1, Penzerme_Action t2)
        {
            throw new NotImplementedException();
        }
    }
}
