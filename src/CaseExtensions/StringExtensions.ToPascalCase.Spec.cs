using System;

using FluentAssertions;

using Xunit;

namespace CaseExtensions.Spec;

public class StringExtensionsToPascalCase
{
    [Theory]
    [InlineData(null)]
    public void ReturnArgumentNullException(string source)
    {
        Action act = () => source.ToPascalCase();
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("api/users/32/someActionToDo?param=%a%")]
    [InlineData("Api/Users/32/SomeActionToDo?Param=%A%")]
    [InlineData("api/users/32/some-action-to-do?param=%a%")]
    [InlineData("api/users/32/Some-Action-To-Do?Param=%a%")]
    [InlineData("api/users/32/some_action_to_do?param=%a%")]
    [InlineData("api/users/32/Some_Action_to_do?param=%a%")]
    public void ReturnPascalCaseUrl(string source)
    {
        var expectedResult = "Api/Users/32/SomeActionToDo?Param=%A%";
        source.ToPascalCase().Should().Be(expectedResult);
    }
}