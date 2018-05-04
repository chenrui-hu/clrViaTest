using System;
using System.Text;
using BanKai.Basic.Common;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConditionIsAlwaysTrueOrFalse
    // ReSharper disable ExpressionIsAlwaysNull

    public class Inheritance
    {
        [Fact]
        public void should_access_public_memeber_in_derived_class()
        {
            var demoClass = new InheritMemberAccessDemoClass();

            // please change the variable value to fix the test.
            const string expected = "Public Property Value";

            Assert.Equal(expected, demoClass.PublicProperty);
        }

        [Fact]
        public void should_access_protected_member_in_derived_class()
        {
            // sub class can access protected member in super class
            var demoClass = new InheritMemberAccessDemoClass();

            string actualValue = demoClass.ManipulateProtectedMember();

            // please change the variable value to fix the test.            
            const string expected = "The value is Protected Property Value";

            Assert.Equal(expected, actualValue);
        }

        [Fact]
        public void should_access_member_of_most_derived_class()
        {
            // virtual method use override to override, difference with abstract method?
            // in super class declare method can be override use virtual
            // in sub class declare method with override
            var demoClass = new PolymorphismDemoClass();
            var castToBaseClass = (PolymorphismDemoClassBase) demoClass;

            string actualValue = castToBaseClass.VirtualMethod();

            // please change the variable value to fix the test.
            const string expected = "DerivedClass";

            Assert.Equal(expected, actualValue);
        }

        [Fact]
        public void should_return_casted_result_if_it_is_castable()
        {
            // force convert (cast) doesn't change the type of object, only treat object as it's converted type
            // PolymorphismDemoClass and -Base are in the same inheritance chain
            var demoClass = new PolymorphismDemoClass();
            // var baseDemo = new PolymorphismDemoClassBase();
            // Assert.Equal(demoClass, baseDemo); not equal

            // as returns null instead of raising exception when casing is impossible
            var castToBaseClass = demoClass as PolymorphismDemoClassBase;

            bool isNull = castToBaseClass == null;

            // please change the variable value to fix the test.
            const bool expected = false;

            Assert.Equal(expected, isNull);
            // Assert.Equal(demoClass.GetType(), (new PolymorphismDemoClass()).GetType());
            // Assert.Equal(castToBaseClass, baseDemo);
            // Assert.Equal(demoClass, baseDemo); not equal
            // Assert.Equal(demoClass, castToBaseClass); equal
            // Assert.Equal(baseDemo, castToBaseClass); not equal
        }

        [Fact]
        public void should_return_null_if_it_is_not_castable()
        {
            // normaly (super_class)class is castable, as keyword
            var demoClass = new PolymorphismDemoClass();
            object castToObject = demoClass;

            // StringBuilder and object are not in a inheritance chain ?, so caseResult is null
            var castResult = castToObject as StringBuilder;
            bool isNull = castResult == null;

            // please change the variable value to fix the test.
            const bool expected = true;

            Assert.Equal(expected, isNull);
        }

        [Fact]
        public void should_throw_exception_if_it_is_not_castable()
        {
            // not castable, throw InvalideCastException
            var demoClass = new PolymorphismDemoClass();
            object castToObject = demoClass;

            // please change the variable value to fix the test.
            Type expectedExceptionType = typeof(InvalidCastException);

            Assert.NotEqual(typeof(SystemException), expectedExceptionType);
            Assert.NotEqual(typeof(Exception), expectedExceptionType);

            Assert.Throws(expectedExceptionType, () => (StringBuilder) castToObject);
        }

        [Fact]
        public void should_reference_to_same_object_after_casting()
        {
            // after casting, have same reference and it's PolymorphismClass type
            // because casting doesn't change type/reference
            var demoClass = new PolymorphismDemoClass();
            var castToBaseClass = (PolymorphismDemoClassBase)demoClass;

            bool referenceEqual = ReferenceEquals(demoClass, castToBaseClass);

            // please change the variable value to fix the test.
            const bool expected = true;

            Assert.Equal(expected, referenceEqual);
        }

        [Fact]
        public void should_throw_exception_when_downcasting_fail()
        {
            var demoClassBase = new PolymorphismDemoClassBase();

            // please change the variable value to fix the test.
            // downcasting fails here, (int)object is not gonna fail
            Type expectedExceptionType = typeof(InvalidCastException);

            Assert.NotEqual(typeof(SystemException), expectedExceptionType);
            Assert.NotEqual(typeof(Exception), expectedExceptionType);

            Assert.Throws(expectedExceptionType, () => (PolymorphismDemoClass)demoClassBase);
        }

        [Fact]
        public void should_be_able_to_hide_non_virtual_method_in_derived_class()
        {
            // ? in HideMemberDemoClassBase, public new string
            var demoClass = new HideMemberDemoClass();
            var castedToBaseClass = (HideMemberDemoClassBase) demoClass;

            string methodReturnValue = demoClass.MethodToHide();
            string baseClassMethodReturnValue = castedToBaseClass.MethodToHide();

            // please change the following 2 variable values to fix the test.
            const string expectedMethodReturnValue = "HideMemberDemoClass::MethodToHide()";
            const string expectedBaseClassMethodReturnValue = "HideMemberDemoClassBase::MethodToHide()";

            Assert.Equal(expectedMethodReturnValue, methodReturnValue);
            Assert.Equal(expectedBaseClassMethodReturnValue, baseClassMethodReturnValue);
            // Assert.Equal(castedToBaseClass.GetType(), (new HideMemberDemoClassBase()).GetType()); not equal
        }

        [Fact]
        public void should_be_able_to_get_base_class_members_using_base_keyword()
        {
            // use base to represent abstract class BaseKeywordDemoClass
            var demoClass = new BaseKeywordDemoClass();

            string name = demoClass.Name;

            // please change the variable value to fix the test.
            const string expected = "BaseClass's derived class.";

            Assert.Equal(expected, name);
        }

        [Fact]
        public void should_call_default_constructors_of_base_class()
        {
            // call default constructor in case class
            var demoClass = new InheritanceConstructorCallDemoClass();

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "InheritanceConstructorCallDemoClassBase::Ctor()" + "\r\n" +
            "InheritanceConstructorCallDemoClass::Ctor()" + "\r\n";

            Assert.Equal(expected, message);
        }

        [Fact]
        public void should_call_default_constructor_of_base_class_when_call_derived_ctor_with_args()
        {
            // new object with type of sub class, parameter is int 
            //still call base constructor
            var demoClass = new InheritanceConstructorCallDemoClass(1);

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "InheritanceConstructorCallDemoClassBase::Ctor()" + "\r\n" +
            "InheritanceConstructorCallDemoClass::Ctor(int)" + "\r\n";

            Assert.Equal(expected, message);
        }

        [Fact]
        public void should_be_able_to_specify_which_base_ctor_to_call()
        {
            // should call method with string parameter in sub class, but in that method
            // first call abstract class with parsed int
            var demoClass = new InheritanceConstructorCallDemoClass("1");

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "InheritanceConstructorCallDemoClassBase::Ctor(int)" + "\r\n" +
            "InheritanceConstructorCallDemoClass::Ctor(string)" + "\r\n";

            Assert.Equal(expected, message);
        }

        [Fact]
        public void should_be_able_to_specify_which_ctor_of_current_class_to_call()
        {
            // call sub class with 2 args, in that method first call sub class with int arg
            // then excute the constructor with 2 args
            // why still call base constructor? here doesn't use base keyword
            var demoClass = new InheritanceConstructorCallDemoClass(1, "1");

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "InheritanceConstructorCallDemoClassBase::Ctor()" + "\r\n" +
                "InheritanceConstructorCallDemoClass::Ctor(int)" + "\r\n"
                + "InheritanceConstructorCallDemoClass::Ctor(int, string)" + "\r\n";

            Assert.Equal(expected, message);
        }

        [Fact]
        public void should_be_able_to_choose_most_specific_type_when_overloading()
        {
            // find the most specific type according to the type of given parameter
            var demoClass = new MethodOverloadDemoClass();

            string returnValueForBaseClassOverloading = 
                demoClass.Foo(new MethodOverloadBaseClass());
            string returnValueForDerivedClassOverloading =
                demoClass.Foo(new MethodOverloadDerivedClass());
            string returnValueForCastingOverloading =
                demoClass.Foo((MethodOverloadBaseClass) (new MethodOverloadDerivedClass()));

            const string expectedBaseClassOverloadingValue = "Foo(MethodOverloadBaseClass)";
            const string expectedDerivedClassOverloadingValue = "Foo(MethodOverloadDerivedClass)";
            const string expectedCastOverloadingValue = "Foo(MethodOverloadBaseClass)";

            Assert.Equal(expectedBaseClassOverloadingValue, returnValueForBaseClassOverloading);
            Assert.Equal(expectedDerivedClassOverloadingValue, returnValueForDerivedClassOverloading);
            Assert.Equal(expectedCastOverloadingValue, returnValueForCastingOverloading);
        }
    }

    // ReSharper restore ExpressionIsAlwaysNull
    // ReSharper restore ConditionIsAlwaysTrueOrFalse
}