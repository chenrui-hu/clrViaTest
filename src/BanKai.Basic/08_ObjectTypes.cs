using System;
using System.Collections.Generic;
using BanKai.Basic.Common;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConvertToConstant.Local
    // ReSharper disable PossibleInvalidCastException
    public class ObjectTypes
    {
        [Fact]
        public void all_types_are_derived_from_object()
        {
            // all types are su classes of object
            // object->value type->string, object->value type->int
            // object->ref type->array
            var stringInstance = "a string";
            var annonymousInstance = new { };
            var valueTypeInstance = 2;

            // change the variable values for the following 3 lines to fix the test.
            const bool isStringInstanceObject = true;
            const bool isAnnonymousInstanceObject = true;
            const bool isValueTypeInstanceObject = true;

            Assert.Equal(
                isStringInstanceObject,
                stringInstance.GetType().IsSubclassOf(typeof(object)));
            Assert.Equal(
                isAnnonymousInstanceObject,
                annonymousInstance.GetType().IsSubclassOf(typeof(object)));
            Assert.Equal(
                isValueTypeInstanceObject,
                valueTypeInstance.GetType().IsSubclassOf(typeof(object)));
        }

        [Fact]
        public void should_cast_to_object_for_any_instance()
        {
            // cast object to more specific type
            var objectList = new List<object> {"String", 2, new RefTypeClass(2)};

            object itemAtPosition0 = objectList[0];
            object itemAtPosition1 = objectList[1];
            object itemAtPosition2 = objectList[2];

            // change the variable values for the following 3 lines to fix the test.
            Type expectedTypeForItemAtPosition0 = typeof(string);
            Type expectedTypeForItemAtPosition1 = typeof(int);
            Type expectedTypeForItemAtPosition2 = typeof(RefTypeClass);

            Assert.Equal(expectedTypeForItemAtPosition0, itemAtPosition0.GetType());
            Assert.Equal(expectedTypeForItemAtPosition1, itemAtPosition1.GetType());
            Assert.Equal(expectedTypeForItemAtPosition2, itemAtPosition2.GetType());
        }

        [Fact]
        public void should_derived_from_value_type_for_value_type()
        {
            // value type: numeric types, char, boolean, struct, enum
            int intObject = 1;
            DateTime dateTimeObject = DateTime.Now;
            // struct
            var customValueTypeObject = new ValueTypeDemoClass();

            // change the variable values for the following 3 lines to fix the test.
            const bool isIntObjectValueType = true;
            const bool isDateTimeObjectValueType = true;
            const bool isCustomValueTypeObjectValueType = true;

            Assert.Equal(
                isIntObjectValueType, 
                intObject.GetType().IsSubclassOf(typeof(ValueType)));
            Assert.Equal(
                isDateTimeObjectValueType,
                dateTimeObject.GetType().IsSubclassOf(typeof(ValueType)));
            Assert.Equal(
                isCustomValueTypeObjectValueType,
                customValueTypeObject.GetType().IsSubclassOf(typeof(ValueType)));
        }

        [Fact]
        public void should_be_sealed_for_value_type()
        {
            // sealed keyword to prevent it from being overridden by further subclasses
            // value type are sealed
            var customValueTypeObject = new ValueTypeDemoClass();

            // change the variable value to fix the test.
            const bool isValueTypeSealed = true;

            Assert.Equal(isValueTypeSealed, customValueTypeObject.GetType().IsSealed);
        }

        [Fact]
        public void should_perform_real_copy_operation_for_value_type()
        {
            var original = new ValueTypeDemoClass();

            ValueTypeDemoClass copy = original;
            bool isSameReference;

            // use unsafe keyword permit use pointer and perform c++-style pointer operations 
            unsafe
            {
                // & returns a pointer to the address of variable
                // * returns the variable at the address of a pointer
                // -> ponit-to-member operator, x->y is equivalent to(*x).y
                ValueTypeDemoClass* originalPtr = &original;
                ValueTypeDemoClass* copyPtr = &copy;

                // originalPtr -> original
                // copyPtr -> copy
                isSameReference = originalPtr == copyPtr;
            }

            // change the variable value to fix the test.
            const bool expectedIsSameReference = false;

            Assert.Equal(expectedIsSameReference, isSameReference);
        }

        [Fact]
        public void should_as_if_nothing_different_occurrs_when_doing_boxing_operation()
        {
            int intObject = 1;
            // upcasting
            var boxed = (object) intObject;

            // change the variable values for the following 3 lines to fix the test.
            Type expectedType = typeof(int);
            const bool isBoxedTypeSealed = true;
            const bool isValueType = true;

            Assert.Equal(expectedType, boxed.GetType());
            Assert.Equal(isBoxedTypeSealed, boxed.GetType().IsSealed);
            Assert.Equal(isValueType, boxed.GetType().IsValueType);
        }

        [Fact]
        public void should_make_explicity_cast_when_doing_unboxing_operation()
        {
            int intObject = 1;
            var boxed = (object) intObject;
            long longObject = 0;
            Exception errorWhenCasting = null;

            try
            {
                // long and int are not at a same iheritance chain
                longObject = (long) boxed;
            }
            catch (Exception error)
            {
                errorWhenCasting = error;
            }

            // change the variable values for the following 3 lines to fix the test.
            const bool isExceptionOccurred = true;
            Type expectedExceptionType = typeof(InvalidCastException);
            const long expectedLongObjectValue = 0;

            Assert.Equal(isExceptionOccurred, (errorWhenCasting != null));
            Assert.Equal(expectedExceptionType, errorWhenCasting.GetType());
            Assert.Equal(expectedLongObjectValue, longObject);
        }

        [Fact]
        public void should_get_most_derived_type_when_call_get_type_method()
        {
            var derivedClassObject = new InheritMemberAccessDemoClass();
            // cast into base type
            var castedToBaseClass = (InheritMemberAccessDemoBaseClass)derivedClassObject;

            Type type = castedToBaseClass.GetType();

            // change the variable value to fix the test.
            Type expectedType = typeof(InheritMemberAccessDemoClass);

            Assert.Equal(expectedType, type);
        }

        [Fact]
        public void should_print_object_type_if_no_override_is_available_for_to_string_method()
        {
            // ToString() output object type
            var objectWithoutToStringOverride = new RefTypeClass(2);

            // change the variable value to fix the test.
            const string expectedToStringResult = "BanKai.Basic.Common.RefTypeClass";

            string toStringResult = objectWithoutToStringOverride.ToString();

            Assert.Equal(expectedToStringResult, toStringResult);
        }
    }

    // ReSharper restore PossibleInvalidCastException
    // ReSharper restore ConvertToConstant.Local
}