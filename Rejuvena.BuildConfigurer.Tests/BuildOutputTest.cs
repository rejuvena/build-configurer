using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Rejuvena.BuildConfigurer.Tests
{
    public class BuildOutputTest
    {
        [Test]
        public void OutputTest()
        {
            Console.WriteLine(new BuildFile().WriteFile());

            Console.WriteLine(new BuildFile
            {
                Author = "Test",
                DisplayName = "Test Name",
                Version = new Version(0, 1, 2, 3),
                DllReferences = new List<string> { "Reference1", "Reference2" }
            }.WriteFile());
        }
    }
}