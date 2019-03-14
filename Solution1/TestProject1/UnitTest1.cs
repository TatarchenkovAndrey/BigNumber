using System;
using NUnit.Framework;

namespace TestProject1
{
    public class UnitTest1
    {
                [TestCase("123456",
            TestName = "ValidShortConstructionAndSerializationTest")]
        [TestCase("123456123456123456123456123456123456123456",
            TestName = "ValidLongConstructionAndSerializationTest")]
        public void ValidConstructionAndSerializationTest(string number)
        {
            Assert.AreEqual(number, new BigNumber(number).ToString());
        }

        [TestCase("1", "2",
            ExpectedResult = "3",
            TestName = "EqualLengthWithoutOverflowShortAdditionTest")]
        [TestCase("100", "200",
            ExpectedResult = "300",
            TestName = "EqualLengthWithoutOverflowAdditionTest")]
        [TestCase("700", "800",
            ExpectedResult = "1500",
            TestName = "EqualLengthWithOverflowAdditionTest")]
        [TestCase("123000", "456",
            ExpectedResult = "123456",
            TestName = "DifferentLengthWithoutOverflowAdditionTest")]
        [TestCase("456", "123000",
            ExpectedResult = "123456",
            TestName = "DifferentLengthWithoutOverflowAdditionTest2")]
        [TestCase("999999", "1",
            ExpectedResult = "1000000",
            TestName = "DifferentLengthWithOverflowAdditionTest")]
        [TestCase("1", "999999",
            ExpectedResult = "1000000",
            TestName = "DifferentLengthWithOverflowAdditionTest2")]
        [TestCase("1111111111111111111111111111111111111111", "2222222222222222222222222222222222222222", 
            ExpectedResult = "3333333333333333333333333333333333333333",
            TestName = "AdditionLongerThenUInt64WorksTest")]
        [TestCase("918", "726",
            ExpectedResult = "1644",
            TestName = "ResetOverflowTest")]
        public string AddTest(string number1, string number2)
        {
            var bNumber1 = new BigNumber(number1);
            var bNumber2 = new BigNumber(number2);
            var sum = bNumber1 + bNumber2;
            return sum.ToString();
        }

        [TestCase("998", "12",
            TestName = "ImmutableAdditionTest")]
        public void ImmutableAdditionTest(string number1, string number2)
        {
            var bNumber1 = new BigNumber(number1);
            var bNumber2 = new BigNumber(number2);
            var bNumber3 = bNumber1 + bNumber2;
            Assert.AreEqual(number1, bNumber1.ToString());
            Assert.AreEqual(number2, bNumber2.ToString());
        }

        [TestCase(TestName = "ImmutableToStringTest")]
        public void ImmutableToStringTest()
        {
            var number = "12345678910";
            var bNumber = new BigNumber(number);
            var s = bNumber.ToString();
            Assert.AreEqual(number, bNumber.ToString());
        }
    }
}