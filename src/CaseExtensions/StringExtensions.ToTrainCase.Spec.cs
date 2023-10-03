using System;

using FluentAssertions;

using Xunit;

namespace CaseExtensions.Spec;

public class StringExtensionsToTrainCase
{
    [Theory]
    [InlineData(null)]
    public void ReturnArgumentNullException(string source)
    {
        Action act = () => source.ToTrainCase();
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("api/users/32/someActionToDo?param=%a%")]
    [InlineData("Api/Users/32/SomeActionToDo?Param=%A%")]
    [InlineData("api/users/32/some-action-to-do?param=%a%")]
    [InlineData("api/users/32/Some-Action-To-Do?Param=%a%")]
    [InlineData("api/users/32/some_action_to_do?param=%a%")]
    [InlineData("api/users/32/Some_Action_to_do?param=%a%")]
    public void ReturnTrainCaseUrl(string source)
    {
        var expectedResult = "Api/Users/32/Some-Action-To-Do?Param=%A%";
        source.ToTrainCase().Should().Be(expectedResult);
    }
}