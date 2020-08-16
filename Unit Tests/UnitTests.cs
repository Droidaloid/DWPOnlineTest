using Xunit;
using System.Collections;
using System.Collections.Generic;


namespace DWPOnlineTest.UnitTests
{
    public class CoordinatesTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {42.546245, 1.601554, 624.116604932248};
            yield return new object[] {27.514162, 90.433601, 4772.98807052607};
            yield return new object[] {58.595272, 25.013607, 1098.95983487452};
            yield return new object[] {4.860416, -58.93018, 4640.09205574608};
            yield return new object[] {29.31166, 47.481766, 2864.34515226624};
            yield return new object[] {-20.348404, 57.552152, 6056.18209974236};
            yield return new object[] {39.399872, -8.224454, 922.380281856198};
            yield return new object[] {-49.280366, 69.348557, 8064.21741497357};
            yield return new object[] {15.552727, 48.516388,3638.07150299051};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

    public class HaversineCalculatorTest
    {
    
            [Theory]
            [ClassData(typeof(CoordinatesTestData))]
            public void distanceFromLondon_CorrectData_ReturnsDistance(double latitude, double longitude, decimal distanceFromLondon)
            {
                var distanceCalculator = new HaversineCalculator();

                decimal result = distanceCalculator.distanceFromLondon(latitude, longitude);


                
                Assert.Equal(distanceFromLondon, result);


            }
    }

    

}