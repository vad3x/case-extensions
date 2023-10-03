using FluentAssertions;

namespace CaseExtensions.UnitTests;

public class StringExtensionsToKebabCase
{
    [Theory]
    [InlineData(null)]
    public void ReturnArgumentNullException(string source)
    {
        Action act = () => source.ToKebabCase();
        act.Should().Throw<ArgumentNullException>();
    }

    public class StringExtensionsToKebabCase
    {
        [Theory]
        [InlineData(null)]
        public void ReturnArgumentNullException(string source)
        {
            Action act = () => source.ToKebabCase();
            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData("api/users/32/someActionToDo?param=%a%")]
        [InlineData("Api/Users/32/SomeActionToDo?Param=%A%")]
        [InlineData("api/users/32/some-action-to-do?param=%a%")]
        [InlineData("api/users/32/Some-Action-To-Do?Param=%a%")]
        [InlineData("api/users/32/some_action_to_do?param=%a%")]
        [InlineData("api/users/32/Some_Action_to_do?param=%a%")]
        public void ReturnKebabCaseUrl(string source)
        {
            var expectedResult = "api/users/32/some-action-to-do?param=%a%";
            source.ToKebabCase().Should().Be(expectedResult);
        }
    }