#!/bin/bash

SCRIPT_DIR=$(dirname "$0")
cd "$SCRIPT_DIR"

if [ -d "MinimalApi" ]; then
    echo "INFO: MinimalApi already exists."
else
    echo "Creating MinimalApi from web template"
    dotnet new web -o MinimalApi
fi

if [ -d "MinimalApi.Tests" ]; then
    echo "INFO: MinimalApi.Tests alreade exists."
else
    echo "Creating XUnit test project for MinimalApi"
    dotnet new xunit -o MinimalApi.Tests
fi

if [ -d "MinimalApi" ] && [ -d "MinimalApi.Tests" ]; then
    grep -q 'MinimalApi.csproj' MinimalApi.Tests/MinimalApi.Tests.csproj
    if [ "$?" == "0" ]; then
        echo "INFO: Test project already references MinimalApi"
    else
        echo "Add: Test project references MinimalApi"
        dotnet add MinimalApi.Tests reference MinimalApi
    fi
fi

if [ -f "MinimalApi.sln" ]; then
    echo "INFO: Solution already exists."
else
    echo "Creating solution MinimalApi"
    dotnet new sln -n MinimalApi
fi

if [ -f "MinimalApi.sln" ] && [ -d "MinimalApi" ] && [ -d "MinimalApi.Tests" ]; then
    grep -q '"MinimalApi"' MinimalApi.sln
    if [ "$?" == "0" ]; then
        echo "INFO: MinimalApi already in solution."
    else
        dotnet sln MinimalApi.sln add MinimalApi
    fi
    grep -q '"MinimalApi.Tests"' MinimalApi.sln
    if [ "$?" == "0" ]; then
        echo "INFO: MinimalApi.Tests already in solution."
    else
        dotnet sln MinimalApi.sln add MinimalApi.Tests
    fi
fi

# adding nugets
grep -q 'Include="Microsoft.AspNetCore.Mvc.Testing"' MinimalApi.Tests/MinimalApi.Tests.csproj
if [ "$?" == "0" ]; then
    echo "INFO: Microsoft.AspNetCore.Mvc.Testing dependency already set."
else
    echo "Adding nuget for Mvc.Testing to Tests Project"
    dotnet add MinimalApi.Tests package Microsoft.AspNetCore.Mvc.Testing
fi
