namespace MinimalApi.Tests;

using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Text.RegularExpressions;

public class UnitTest2 {
    private readonly WebApplicationFactory<Program> _wapFactory;

    public UnitTest2(){
        _wapFactory = new WebApplicationFactory<Program>();
    }

    [Fact]
    public async Task CreatePerson(){
        var hcl = _wapFactory.CreateClient();
        
        var obj = new { FirstName="Poncho", LastName="Baqueiro", MiddleName="Bernal", Email="abaqueiro@gmail.com" };
        JsonContent content = JsonContent.Create(obj);

        var response = await hcl.PostAsync("/people", content );
        Assert.Equal("\"Poncho Baqueiro Bernal\"", await response.Content.ReadAsStringAsync() );
    }

    // [Fact]
    // public async Task TestEndpointVersion(){
    //     string pattern = @"^(\d+)\.(\d+)\.(\d+)$";
    //     Regex re = new Regex(pattern);

    //     var hcl = _wapFactory.CreateClient();
    //     var response = await hcl.GetStringAsync("/api/version");
    //     Assert.Matches(re, response);
    // }
}