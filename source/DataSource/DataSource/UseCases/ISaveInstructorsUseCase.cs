using System.Collections.Generic;
using EllAid.Entities.Data;

namespace EllAid.DataSource.UseCases
{
    interface ISaveInstructorsUseCase
    {
        void Save(List<Instructor> instructors);
    }
}