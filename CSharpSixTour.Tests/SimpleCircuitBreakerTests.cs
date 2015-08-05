using System;
using CSharpSixTour.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace CSharpSixTour.Tests
{
    [TestClass]
    public class SimpleCircuitBreakerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullTarget_ThrowsArgumentNull()
        {
            // Arrange
            SimpleCircuitBreaker<TestClass> cb = new SimpleCircuitBreaker<TestClass>(null, new SimpleCircuitBreakerConfig());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Ctor_NullConfig_ThrowsArgumentNull()
        {
            // Arrange
            SimpleCircuitBreaker<TestClass> cb = new SimpleCircuitBreaker<TestClass>(new TestClass(), null);
        }

        [TestMethod]
        public void Ctor_Nothing_IsOpenByDefault()
        {
            // Arrange
            SimpleCircuitBreaker<TestClass> cb = new SimpleCircuitBreaker<TestClass>(new TestClass(), new SimpleCircuitBreakerConfig());

            // Assert
            cb.State.ShouldBe(CircuitBreakerState.Open);
        }

        [TestMethod]
        public void Call_DoNothing_DoesNothing()
        {
            // Arrange
            SimpleCircuitBreaker<TestClass> cb = new SimpleCircuitBreaker<TestClass>(new TestClass(),
                new SimpleCircuitBreakerConfig {Threshold = 0});

            // Act
            cb.Call(tc => tc.DoNothing());

            // Assert
            cb.State.ShouldBe(CircuitBreakerState.Open);
            cb.LastException.ShouldBe(null);
        }

        [TestMethod]
        public void Call_ThrowException_ClosesCircuit()
        {
            // Arrange
            SimpleCircuitBreaker<TestClass> cb = new SimpleCircuitBreaker<TestClass>(new TestClass(),
                new SimpleCircuitBreakerConfig {Threshold = 0});
            Exception exception = null;

            // Act
            try
            {
                cb.Call(tc => { tc.ThrowException(); });
            }
            catch (Exception e)
            {
                exception = e;
            }

            // Assert
            cb.State.ShouldBe(CircuitBreakerState.Closed);
            exception.ShouldNotBe(null);
            exception.Message.ShouldBe("fake exception");
        }

        [TestMethod]
        public void Call_WithExceptionFilter_IgnoresException()
        {
            // Arrange
            SimpleCircuitBreaker<TestClass> cb = new SimpleCircuitBreaker<TestClass>(new TestClass(),
                new SimpleCircuitBreakerConfig {Threshold = 0}, exception => false);

            // Act
            try
            {
                cb.Call(tc => tc.ThrowException());
            }
            catch (Exception)
            {
                
            }

            // Assert
            cb.State.ShouldBe(CircuitBreakerState.Open);
            cb.LastException.ShouldBe(null);
        }
    }

    public class TestClass
    {
        public void DoNothing()
        {
            
        }

        public void ThrowException()
        {
            throw new Exception("fake exception");
        }
    }
}
