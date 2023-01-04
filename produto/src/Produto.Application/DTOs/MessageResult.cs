using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto.Application.DTOs
{
    public class MessageResult
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public MessageResult(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
