using Core.Api;
using Core.Api.Exceptions;
using NUnit.Framework;

namespace Core.Tests.Api;

public class ConfigurationTests
{
    [Test]
    public void failsOnGettingInvalidParameter()
    {
        var e = Assert.Throws<NoParameterFoundException>(() => Configuration.Configure().GetUrl());
        Assert.That(e?.Message.Contains(DefaultConfigurationExtensions.URL) ?? false, $"Expected: {e?.Message}");
    }
}
