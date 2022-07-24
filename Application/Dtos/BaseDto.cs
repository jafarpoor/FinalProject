using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class BaseDto<T>
    {
        public BaseDto(T Data , List<string> Message , bool IsSuccess)
        {
            this.Data = Data;
            this.Message = Message;
            this.IsSuccess = IsSuccess;
        }
        public T Data { get; set; }
        public List<string> Message { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class BaseDto
    {
        public BaseDto(List<string> Message, bool IsSuccess)
        {
            this.Message = Message;
            this.IsSuccess = IsSuccess;
        }

        public List<string> Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
