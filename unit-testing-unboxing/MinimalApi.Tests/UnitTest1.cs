namespace MinimalApi.Tests;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.RegularExpressions;

public class UnitTest1 {
    private readonly WebApplicationFactory<Program> _wapFactory;

    public UnitTest1(){
        _wapFactory = new WebApplicationFactory<Program>();
    }

    [Fact]
    public async Task TestEndpointRoot(){
        var hcl = _wapFactory.CreateClient();

        // Act
        var response = await hcl.GetStringAsync("/");
        // Assert
        Assert.Equal("Hello World!", response);
    }

    [Fact]
    public async Task TestEndpointVersion(){
        string pattern = @"^(\d+)\.(\d+)\.(\d+)$";
        Regex re = new Regex(pattern);

        var hcl = _wapFactory.CreateClient();
        var response = await hcl.GetStringAsync("/api/version");
        Assert.Matches(re, response);
    }
}