using System;

namespace Prova.Tests.ForTestable
{
    public class TestableContext
    {
        public Testable Testable { get; set; }

        public Testable OtherTestable { get; set; }

        public dynamic Instance { get; set; }

        public dynamic SecondInstance { get; set; }

        public dynamic ExpectedDependency { get; set; }

        public Exception Exception { get; set; }
    }
}
