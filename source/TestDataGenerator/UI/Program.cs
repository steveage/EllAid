using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EllAid.Entities.Data;
using EllAid.TestDataGenerator.UseCases;

namespace EllAid.TestDataGenerator.UI
{
    class Program
    {
        static ServiceBuilder serviceBuilder;

        static void  Main(string[] args)
        {
            Initialize();
            CheckClassBuilder();
        }

        static void Initialize()
        {
            serviceBuilder = new ServiceBuilder();
        }

        static void CheckClassBuilder()
        {
            IDataCreationInputBoundary builder = serviceBuilder.GetService<IDataCreationInputBoundary>();
            List<SchoolClass> schoolClasses = builder.GetClasses();
            Console.WriteLine($"{schoolClasses.Count} classes were created: {schoolClasses}");
        }
    }
}