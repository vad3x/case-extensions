using FluentAssertions;

namespace CaseExtensions.UnitTests;

public class StringExtensionsUnitTests
{
    #region ToCamelCase

    [Theory]
    [InlineData(null!)]
    public void ToCamelCase_WithNullSourceString_ShouldReturnArgumentNullException(string? source)
    {
        Action act = () => source.ToCamelCase();
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("api/users/32/someActionToDo?param=%a%")]
    [InlineData("Api/Users/32/SomeActionToDo?Param=%A%")]
    [InlineData("api/users/32/some-action-to-do?param=%a%")]
    [InlineData("api/users/32/Some-Action-To-Do?Param=%a%")]
    [InlineData("api/users/32/some_action_to_do?param=%a%")]
    [InlineData("api/users/32/Some_Action_to_do?param=%a%")]
    public void ToCamelCase_WithUrlString_ShouldReturnCamelCaseUrl(string source)
    {
        const string expectedResult = "api/users/32/someActionToDo?param=%a%";
        source.ToCamelCase().Should().Be(expectedResult);
    }

    #endregion

    #region ToKebabCase

    [Theory]
    [InlineData(null!)]
    public void ToKebabCase_WithNullSourceString_ShouldReturnArgumentNullException(string? source)
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
    public void ToKebabCase_WithUrlString_ShouldReturnKebabCaseUrl(string source)
    {
        const string expectedResult = "api/users/32/some-action-to-do?param=%a%";
        source.ToKebabCase().Should().Be(expectedResult);
    }

    #endregion

    #region ToPascalCase

    [Theory]
    [InlineData(null!)]
    public void ToPascalCase_WithNullSourceString_ShouldReturnArgumentNullException(string? source)
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
    public void ToPascalCase_WithUrlString_ShouldReturnPascalCaseUrl(string source)
    {
        const string expectedResult = "Api/Users/32/SomeActionToDo?Param=%A%";
        source.ToPascalCase().Should().Be(expectedResult);
    }

    #endregion

    #region ToSnakeCase

    [Theory]
    [InlineData(null!)]
    public void ToSnakeCase_WithNullSourceString_ShouldReturnArgumentNullException(string? source)
    {
        Action act = () => source.ToSnakeCase();
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("api/users/32/someActionToDo?param=%a%")]
    [InlineData("Api/Users/32/SomeActionToDo?Param=%A%")]
    [InlineData("api/users/32/some-action-to-do?param=%a%")]
    [InlineData("api/users/32/Some-Action-To-Do?Param=%a%")]
    [InlineData("api/users/32/some_action_to_do?param=%a%")]
    [InlineData("api/users/32/Some_Action_to_do?param=%a%")]
    public void ToSnakeCase_WithUrlString_ShouldReturnSnakeCaseUrl(string source)
    {
        const string expectedResult = "api/users/32/some_action_to_do?param=%a%";
        source.ToSnakeCase().Should().Be(expectedResult);
    }

    #endregion

    #region ToTrainCase

    [Theory]
    [InlineData(null!)]
    public void ToTrainCase_WithNullSourceString_ShouldReturnArgumentNullException(string? source)
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
    public void ToTrainCase_WithUrlString_ShouldReturnTrainCaseUrl(string source)
    {
        const string expectedResult = "Api/Users/32/Some-Action-To-Do?Param=%A%";
        source.ToTrainCase().Should().Be(expectedResult);
    }

    #endregion
}