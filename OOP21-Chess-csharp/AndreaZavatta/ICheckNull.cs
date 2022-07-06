using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_Chess_csharp.AndreaZavatta
{
    public interface ICheckNull
    {
        public TResult IfNotNull<TInput, TResult>(TInput obj, Func<TInput, TResult> eval) where TResult : class where TInput : class
        {
            if (obj == null) return null;
            return eval(obj);
        }
    }
}
