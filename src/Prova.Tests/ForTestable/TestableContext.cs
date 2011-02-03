using System;

namespace Prova.Tests.ForTestable
{
    public class TestableContext
    {
        private Testable _testable;
        private Testable _secondTestable;
        private dynamic _instance;
        private dynamic _secondInstance;
        private dynamic _expectedDependency;
        private Exception _exception;

        public Testable Testable
        {
            get { return _testable; }
            set { _testable = value; }
        }

        public Testable SecondTestable
        {
            get { return _secondTestable; }
            set { _secondTestable = value; }
        }

        public dynamic Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public dynamic SecondInstance
        {
            get { return _secondInstance; }
            set { _secondInstance = value; }
        }

        public dynamic ExpectedDependency
        {
            get { return _expectedDependency; }
            set { _expectedDependency = value; }
        }

        public Exception Exception
        {
            get { return _exception; }
            set { _exception = value; }
        }
    }
}