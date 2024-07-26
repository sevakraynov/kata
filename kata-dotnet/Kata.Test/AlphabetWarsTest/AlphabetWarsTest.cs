using FluentAssertions;
using Kata.Tasks.AlphabetWars;
using NUnit.Framework;

namespace Kata.Test.AlphabetWarsTest;

/// <summary>
/// Тесты для задач <see cref="AlphabetWars"/>
/// </summary>
public class AlphabetWarsTest
{
    [Test]
    [TestCase("Right side wins!", "z")]
    [TestCase("Let's fight again!", "zdqmwpbs")]
    [TestCase("Right side wins!", "zzzzs")]
    [TestCase("Left side wins!", "wwwwwwz")]
    public void FightTest(string result, string str)
        => result.Should().Be(AlphabetWars.Fight(str));

    [Test]
    [TestCase("Right side wins!", "z")]
    [TestCase("Let's fight again!", "****")]
    [TestCase("Let's fight again!", "z*dq*mw*pb*s")]
    [TestCase("Let's fight again!", "zdqmwpbs")]
    [TestCase("Right side wins!", "zz*zzs")]
    [TestCase("Left side wins!", "*wwwwww*z*")]
    public void AirstrikeTest(string result, string str)
        => result.Should().Be(AlphabetWars.AirStrike(str));
}
