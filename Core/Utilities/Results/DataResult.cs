using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }
        public SuccessDataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }
        public SuccessDataResult(T data,bool success):base(success)
        {
            Data = data;
        }

    }
}
