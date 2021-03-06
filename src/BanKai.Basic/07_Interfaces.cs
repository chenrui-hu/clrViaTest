﻿using BanKai.Basic.Common;
using BanKai.Basic.Extensions;
using Xunit;

namespace BanKai.Basic
{
    public class Interfaces
    {
        [Fact]
        public void should_implement_more_than_one_interface()
        {
            // IMovable and ITalkable are interfaces
            // IMovable has an abstract method MoveTo(x, y) and a property WhereAmI()
            // ITalkable has an abstract method Talk()
            // Duck can implement more than one interface
            var duck = new Duck();
            var castToMoveable = (IMoveable) duck;
            var castToTalkable = (ITalkable) duck;

            castToMoveable.MoveTo(2, 3);

            string duckPosition = duck.WhereAmI;
            string duckTalk = castToTalkable.Talk();

            // change the variable values for the following 2 lines to fix the test.
            const string expectedDuckPosition = "You are at (2, 3)";
            const string expectedTalk = "Ga, ga, ...";

            Assert.Equal(expectedDuckPosition, duckPosition);
            Assert.Equal(expectedTalk, duckTalk);
        }

        [Fact]
        public void should_use_explict_interface_impl_if_you_want_to_hide_something_for_certain_type()
        {
            // ReadOnlyStream implement ITextStream, explicity implement Write
            // lets the two methods coexist in one class. 
            // The only way to call an explicitly implemented member is to cast to its interface
            // as the next test
            var readOnlyStreamWithWriteExplicitlyImpl = new ReadOnlyStream();

            // see if reafOnlyStreamWithExplicitImpl has write method
            var hasWriteMethod = readOnlyStreamWithWriteExplicitlyImpl.HasInstanceMethod(
                "Write",
                new[] {typeof(string)});

            // change the variable value to fix the test.
            const bool expectedHasWriteMethod = false;

            Assert.Equal(expectedHasWriteMethod, hasWriteMethod);
        }

        [Fact]
        public void should_invoke_explicitly_implemented_method_by_original_interface()
        {
            // declare a sub class instance then cast it into base class, so the write method
            // belongs to base class
            var readOnlyStreamWithWriteExplicitlyImpl = new ReadOnlyStream();
            var castedToInterface = (ITextStream) readOnlyStreamWithWriteExplicitlyImpl;

            castedToInterface.Write("Hehe");
            var readResult = readOnlyStreamWithWriteExplicitlyImpl.Read();

            // change the variable value to fix the test.
            const string expectedReadResult = "Hehe";

            Assert.Equal(expectedReadResult, readResult);
        }
    }
}