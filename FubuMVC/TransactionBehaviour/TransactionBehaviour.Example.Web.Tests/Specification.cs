using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TransactionBehaviour.Example.Web.Tests
{
    [TestFixture]
    public abstract class Specification
    {
        [SetUp]
        public void BaseSetUp()
        {
            SetupParameters();
            SetupDependencies();
            InitializeClassUnderTest();
            MoveClassUnderTestIntoContext();
            Because();
        }

        [TearDown]
        public void BaseTearDown()
        {
            TidyUp();
        }

        protected virtual void SetupParameters() { }
        protected virtual void SetupDependencies() { }
        protected virtual void InitializeClassUnderTest() { }
        protected virtual void MoveClassUnderTestIntoContext() { }
        protected virtual void Because() { }
        protected virtual void TidyUp() { }
    }
}
