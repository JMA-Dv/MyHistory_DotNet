using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Domain.Responses.Specialists
{
    public record SpecialistResponse
        (
          Guid Id,
          string FirstName,
          string LastName
        );
}
