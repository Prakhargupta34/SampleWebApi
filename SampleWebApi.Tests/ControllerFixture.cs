using System;
using Xunit;
using SampleWebApi.Controllers;

namespace SampleWebApi.Tests
{
    public class ControllerFixture
    {
        [Fact]
        public void Can_say_hii()
        {
            var sayHiiController = new SayHiiController();
            Assert.Equal("Hii", sayHiiController.Get());
        }
        [Fact]
        public void Can_say_hii_when_pass_with_name_parameter()
        {
            var sayHiiController = new SayHiiController();
            Assert.Equal("Hii, prakhar", sayHiiController.Get("prakhar"));
        }
        [Fact]
        public void Can_say_hello()
        {
            var sayHelloController = new SayHelloController();
            Assert.Equal("Hello", sayHelloController.Get());
        }
        [Fact]
        public void Can_say_hello_when_pass_with_name_parameter()
        {
            var sayHelloController = new SayHelloController();
            Assert.Equal("Hello, prakhar", sayHelloController.Get("prakhar"));
        }
    }
}
