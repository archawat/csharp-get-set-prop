using System;
using System.ComponentModel;
using Xunit;

namespace getprop
{
    public class UnitTest1
    {
        [Fact]
        public void TestSet()
        {
            var obj = new ClassA();

            obj.GetType().GetProperty("StringProperty").SetValue(obj, "Set to String Property");
            
            Assert.Equal("Set to String Property", obj.StringProperty);
        }

        [Fact]
        public void TestSetNullablePropDecimal()
        {
            var obj = new ClassA();
            var prop = obj.GetType().GetProperty("NullableDecimalProperty");
            var tc = TypeDescriptor.GetConverter(prop.PropertyType);
            var converted = tc.ConvertFrom("1000.0009");
            obj.GetType().GetProperty("NullableDecimalProperty").SetValue(obj, converted);
            Assert.Equal(1000.0009M, obj.NullableDecimalProperty);
            
        }

        [Fact]
        public void TestSetNullableToNull()
        {
            var obj = new ClassA();
            obj.NullableDecimalProperty = 1000M;
            Assert.Equal(1000M, obj.NullableDecimalProperty);
            

            var prop = obj.GetType().GetProperty("NullableDecimalProperty");
            var tc = TypeDescriptor.GetConverter(prop.PropertyType);
            var converted = tc.ConvertFrom("");
            obj.GetType().GetProperty("NullableDecimalProperty").SetValue(obj, converted);            
            
            Assert.Null(obj.NullableDecimalProperty);
        }
    }
}
