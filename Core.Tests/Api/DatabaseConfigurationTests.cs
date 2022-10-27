using Core.Api;
using Core.Api.Exceptions;
using NUnit.Framework;

namespace Core.Tests.Api;

public class DatabaseConfigurationTests
{
    [Test]
    public void failsOnGettingInvalidParameter()
    {
        var e = Assert.Throws<OptionNotFoundException>(() => DatabaseConfiguration.Configure().Get("test"));
        Assert.That(e?.Message.Contains("test") ?? false, $"Actual : {e?.Message}");
    }
}
