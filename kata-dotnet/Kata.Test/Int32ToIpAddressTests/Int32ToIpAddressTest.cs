using FluentAssertions;
using Kata.Tasks.Int32ToIpAddress;
using NUnit.Framework;

namespace Kata.Test.Int32ToIpAddressTests;

/// <summary>
/// Тесты для задачи <see cref="Int32ToIpAddress"/>
/// </summary>
public class Int32ToIpAddressTest
{
    [Test]
    [TestCase((uint)32, "0.0.0.32")]
    [TestCase(2154959208, "128.114.17.104")]
    [TestCase((uint)0, "0.0.0.0")]
    [TestCase(2149583361, "128.32.10.1")]
    public void ConvertTest(uint number, string ip)
    {
        var intToIp = new Int32ToIpAddress(number);
        intToIp.ConvertInt32ToIp().Should().Be(ip);
    }
}
