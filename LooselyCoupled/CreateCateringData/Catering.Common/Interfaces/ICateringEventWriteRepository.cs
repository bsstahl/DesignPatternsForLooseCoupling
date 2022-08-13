using Catering.Common.Entities;
using System.Collections.Generic;

namespace Catering.Common.Interfaces;

public interface ICateringEventWriteRepository
{
    void WriteCateringEvents(IEnumerable<CateringEvent> cateringEvents);
}
