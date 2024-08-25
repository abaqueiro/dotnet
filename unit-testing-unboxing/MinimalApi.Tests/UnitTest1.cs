namespace MinimalApi.Tests;

using Microsoft.AspNetCore.Mvc.Testing;

public class UnitTest1 {
    private readonly WebApplicationFactory<Program> _wapFactory;

    public UnitTest1(){
        _wapFactory = new WebApplicationFactory<Program>();
    }

    [Fact]
    public async Task TestRootEndpoint(){
        var hcl = _wapFactory.CreateClient();

        // Act
        var response = await hcl.GetStringAsync("/");
        // Assert
        Assert.Equal("Hello World!", response);
    } 
}