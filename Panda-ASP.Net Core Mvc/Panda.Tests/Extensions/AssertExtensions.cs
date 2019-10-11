using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Panda.Tests.Extensions
{
    public static class AssertExtensions
    {
        public static void  EqualsWithMessage( object first, object second, string message)
        {
            Assert.True(first == second, message);
        }
    }
}
