using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_APP_IDWPKQ
{
    internal interface IOperatorHandler<T>
    {
        bool IsOperator(T t);
        bool ApplyOperator(T t);
    }

    internal interface IOperatorHandler<T1, T2>
    {
        bool IsOperator(T1 t1, T2 t2);
        bool ApplyOperator(T1 t1, T2 t2);
    }

    internal interface IOperatorHandler<T1, T2, T3>
    {
        bool IsOperator(T1 t1, T2 t2, T3 t3);
        bool ApplyOperator(T1 t1, T2 t2, T3 t3);
    }
}
