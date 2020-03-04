using System;
using ClassLibrary1;
using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestPrivateMethod()
        {
            Class1 obj = new Class1();
            MSTest.PrivateObject privateObj = new MSTest.PrivateObject(obj);

            int retVal = (int)privateObj.Invoke("Parse", "1234");

            Assert.Equal(1234, retVal);
        }
    }
}
