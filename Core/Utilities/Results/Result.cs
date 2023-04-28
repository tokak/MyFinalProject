using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)//parametreli this tek paremetreli ctor successe gönderir.
        {
            Message = message;
           //Success = success; allta kodu eşitliyoruz
        }
        //Mesaj Boş olursa
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
