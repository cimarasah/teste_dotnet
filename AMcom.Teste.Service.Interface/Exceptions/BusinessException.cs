using System;
using System.Collections.Generic;
using AMcom.Teste.Service.Interface.Extension;

namespace AMcom.Teste.Service.Interface.Exceptions
{
    public class BusinessException : Exception
    { 
        public ExceptionMessages Code { get; private set; }
         
        public BusinessException(ExceptionMessages message)
            : base(message.GetDescriptionEnum()) => this.Code = message;

        public BusinessException(ExceptionMessages key, string message)
            : base(message) => this.Code = key;
    }
}
