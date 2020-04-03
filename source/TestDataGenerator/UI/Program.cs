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

        static async Task Main(string[] args)
        {
            Initialize();
            await CheckClassBuilderAsync();
        }

        static void Initialize()
        {
            serviceBuilder = new ServiceBuilder();
        }

        static async Task CheckClassBuilderAsync()
        {
            IDataCreationInputBoundary builder = serviceBuilder.GetService<IDataCreationInputBoundary>();
            await builder.CreateClassesAsync();
        }
    }
}