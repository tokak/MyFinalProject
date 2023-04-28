using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç 
    public interface IResult
    {
        //get : Sadece okunabilir demek set:Yazmak için kullanırız.
        bool Success { get; }
        string Message { get; }
    }
}
