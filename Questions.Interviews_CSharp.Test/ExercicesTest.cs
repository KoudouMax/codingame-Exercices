namespace Questions.Interviews_CSharp.Test
{
    public class ExercicesTest
    {
        [
            Theory,
            InlineData(471, 480)
        ]
        public void ComputeJoinPoint_should_return_expected(int value1, int value2)
        {
            var expected = 52;
            var actual = Exercises.ComputeJoinPoint(value1, value2);
            Assert.Equal(expected, actual);
        }

        [
            Theory,
            InlineData(new int[]{1, 1, 3, 2, 3, 2 })
        ]
        public void FilterDuplicate_should_return_expected(int[] values)
        {
            int[] expected = {1, 3, 2};
            int[] actual = Exercises.FilterDuplicate(values);

            Assert.Equal(expected, actual);
        }

        [
            Theory,
            InlineData(new int[] { 1, 7, 3, 4, 2, 6, 9 }, 6)
        ]
        public void BinarySearch_should_return_expected(int[] values, int number)
        {
            bool actual = Exercises.BinarySearch(values, number);
            Assert.True(actual);
        }

        [
            Theory,
            InlineData(0, new int[] { 1, 7, 3, 4, 2, 6, 9 }, new int[] { 3, 3, 4, 6, 6, 9, 5 })
        ]
        public void FindNetworkEndpoint_should_return_expected(int k, int[] values1, int[] values2)
        {
            var expected = 45;
            var actual = Exercises.FindNetworkEndpoint(k, values1, values2);
            Assert.Equal(expected, actual);
        }

        [
            Theory,
            InlineData("Kayak"),
            InlineData("aa"),
            InlineData("aDa"),
            InlineData("anona"),
            InlineData("pop"),
            InlineData("reifier"),
            InlineData("semâmes"),
            InlineData("solos"),
            InlineData("sugus"),
        ]
        public void StringPalindrome_should_return_expected(string value)
        {
            var actual = Exercises.StringPalindrome(value);
            Assert.True(actual);
        }

        [
            Theory,
            InlineData(new int[] { 1, 7, 3, 4, 2, 6, 9 })
        ]
        public void ClosesToZero_should_return_expected(int[] values)
        {
            int expected = 1;
            var actual = Exercises.ClosesToZero(values);
            Assert.Equal(expected, actual);
        }
    }
}
