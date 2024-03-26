using System;
using System.IO;
using Xunit;
using CreditImmobilier;

namespace CreditImmobilierTests
{
    public class ConsoleWrapperTests
    {
        [Fact]
        public void WriteLine_WritesExpectedMessageToConsole()
        {
            var consoleWrapper = new ConsoleWrapper();
            var expectedMessage = "Test message";
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter); 

                
                consoleWrapper.WriteLine(expectedMessage);

                
                var output = stringWriter.ToString().Trim();
                Assert.Equal(expectedMessage, output);
            }
        }
    }
}
