using NUnit.Framework;

namespace NUnitAssignment9
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test Pass with using Custom Constraint
        /// </summary>
        [Test]
        public void TestCustomConstrain_For_Chack_Capitalize_String()
        {
            // Act
            string value = "Parth Nonghanvadra";

            // Assert
            Assert.That(value, Is.IsCapitalize("Parth Nonghanvadra"));
        }

        /// <summary>
        /// Test Fails with using Custom Constraint
        /// </summary>
        [Test]
        public void TestCustomConstrain_For_Chack_Capitalize_String_Fails()
        {
            // Act
            string value = "Parth nonghanvadra";

            // Assert
            Assert.That(value, Is.IsCapitalize("Parth nonghanvadra"));
        }

        /// <summary>
        /// Test Pass with using Custom Constraint
        /// </summary>
        [Test]
        public void TestCustomConstrain_For_Chack_AllmostEqual_Number()
        {
            // Act
            int value = 98;

            // Assert
            Assert.That(value, Is.IsAlmostEqualTo(100, 5));
        }

        /// <summary>
        /// Test Fails with using Custom Constraint
        /// </summary>
        [Test]
        public void TestCustomConstrain_For_Chack_AllmostEqual_Number_Fails()
        {
            // Act
            int value = 50;

            // Assert
            Assert.That(value, Is.IsAlmostEqualTo(100, 8));
        }

        /// <summary>
        /// Test Pass with using Custom Constraint
        /// </summary>
        [Test]
        public void TestCustomConstrain_For_IsPartOf_IntArray()
        {
            // Act
            int[] array = { 5, 10, 15, 20 };
            int value = 10;

            // Assert
            Assert.That(value, Is.IsPartOf(array));
        }

        /// <summary>
        /// Test Fails with using Custom Constraint
        /// </summary>
        [Test]
        public void TestCustomConstrain_For_IsPartOf_IntArray_Fails()
        {
            // Act
            int[] array = { 2, 4, 6, 8 };
            int value = 10;

            // Assert
            Assert.That(value, Is.IsPartOf(array));
        }
    }
}