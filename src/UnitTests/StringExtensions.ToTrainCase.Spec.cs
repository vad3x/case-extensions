using System;
using FluentAssertions;
using Xunit;

namespace CaseExtensions.Spec
{
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
        [InlineData("API/USERS/32/SOME_ACTION_TO_DO?PARAM=%A%")]
        public void ReturnTrainCaseUrl(string source)
        {
            const string expectedResult = "Api/Users/32/Some-Action-To-Do?Param=%A%";
            source.ToTrainCase().Should().Be(expectedResult);
        }
    }
}
