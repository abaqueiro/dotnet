namespace MinimalApi.Tests;

using Microsoft.AspNetCore.Mvc.Testing;

public class UnitTest {
    [Fact]
    public async Task TestRootEndpoint() {
        await using var app = new WebApplicationFactory<Program>();
        using var client = app.CreateClient();

        // Act
        var response = await client.GetStringAsync("/");
        // Assert
        Assert.Equal("Hello World!", response);
    }
}