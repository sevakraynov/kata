using Kata.Tasks.Int32ToIpAddress;
using Xunit;

namespace Kata.Test.Int32ToIpAddressTests
{
    /// <summary>
    /// Тесты для задачи <see cref="Int32ToIpAddress"/>
    /// </summary>
    public class Int32ToIpAddressTest
    {
        [Fact]
        public void ConvertTest()
        {
            Assert.Equal("0.0.0.32", new Int32ToIpAddress(32).ConvertInt32ToIp());
            Assert.Equal("128.114.17.104", new Int32ToIpAddress(2154959208).ConvertInt32ToIp());
            Assert.Equal("0.0.0.0", new Int32ToIpAddress(0).ConvertInt32ToIp());
            Assert.Equal("128.32.10.1", new Int32ToIpAddress(2149583361).ConvertInt32ToIp());
        }
    }
}
