using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErorDataResults<T> : SuccessDataResult<T>
    {
        public ErorDataResults(T data, string message) : base(data, false, message)
        {

        }
        public ErorDataResults(T data) : base(data,false)
        {

        }
        public ErorDataResults(string message) : base(default, false, message)
        {

        }
        public ErorDataResults() : base(default, false)
        {

        }
    }
}
