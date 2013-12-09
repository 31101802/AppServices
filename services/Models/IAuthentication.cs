using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quierobesarte.Models
{
    public interface IAuthentication
    {
        bool IsAdmin { get; set; }
    }
}
