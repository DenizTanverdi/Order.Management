using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Management.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]  //Kod tarafinda lazim olduğundan JsonIgnore Kullandık.
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            //data döndürmediğimizde kullanabiliriz.
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            //
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            //Tek error yazdigimizda kullanbiliriz.
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

    }
}
