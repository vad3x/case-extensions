﻿using System;
﻿using CaseExtensions;
﻿using Xunit;

namespace CaseExtensions.Tests
{
    public class StringExtensions_ToTrainCaseShould
    {
        [Theory]
        [InlineData(null)]
        public void ReturnArgumentNullException(string source)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var result = source.ToTrainCase();
            });
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
            var result = source.ToTrainCase();
            Assert.Equal("Api/Users/32/Some-Action-To-Do?Param=%A%", result);
        }
    }
}
