using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IveonBootcamp.Asynchronous.Services
{
    public class ServiceResult
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }


        public static ServiceResult<T> Success(T data, int status)
        {
            return new ServiceResult<T>
            {
                Data = data,
                StatusCode = status
            };
        }

        public static ServiceResult<T> Fail(string title, string message)
        {
            return new ServiceResult<T>
            {
                Title = title,
                Description = message
            };
        }
    }
}
