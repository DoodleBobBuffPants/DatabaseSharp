namespace Core.Tests.Api;

public class DatabaseTests
{
    [Test]
    public void failsOnIncompleteConfiguration()
    {
        var e = Assert.Throws<NoDatabaseFoundException>(() => Configuration.Configure().Connect());
        Assert.That(e?.Message == $"No database found for the provided configuration:{Environment.NewLine}", $"Expected : {e?.Message}");
    }
}
