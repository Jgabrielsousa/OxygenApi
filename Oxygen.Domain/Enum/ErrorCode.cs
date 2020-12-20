using System;
using System.Collections.Generic;
using System.Text;

namespace Oxygen.Domain.Enum
{
    public enum ErrorCode
    {
        NotFound = 0,
        BadRequest = 1,
        Business = 2,
        Unauthorized = 3,
        InternalError = 4,
        Conflict = 5,
        ServiceUnavailable = 6,
        UnprocessableEntity = 7
    }
}
