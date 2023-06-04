using Microservice.TaskManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.TaskManagement.Application.Common.DTO.Responses
{
    public class ResponseDto<T> : IResponseDto<T>
    {
        private T _result;

        public T Result
        {
            get { return _result; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(T));

                _result = value;
            }
        }
        public ResponseDto()
        {

        }
        public ResponseDto(T result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(T));

            _result = result;
        }
    }
}
