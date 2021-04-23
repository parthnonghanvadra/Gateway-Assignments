using NUnit.Framework;
using FluentAssertions;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FluentAssertions.Extensions;

namespace Assignment8
{
    public class Tests
    {
        private Service _service;

        [SetUp]
        public void Setup()
        {
            _service = new Service();
        }

        /// <summary>
        ///  Testing Method with FluentAssertions
        /// </summary>
        /// <returns></returns>

        [Test]
        public async Task GetStringArray_Test()
        {
            // Act
            var result = await _service.GetStringArray();

            // Assert
            Assert.That(result, Has.All.With.Length.EqualTo(3).And.All.Contains("a"));
        }

        /// <summary>
        /// Testing Method with FluentAssertions
        /// </summary>
        /// <returns></returns>

        [Test]
        public async Task GetUsersData_Test()
        {
            // Act
            var result = await _service.GetUsersData();

            // Assert
            Assert.That(result, Has
             .Length.EqualTo(3)
             .And.Exactly(1).Property("Id").EqualTo(1)
             .And.Some.Property("Address").Null
             .And.All.Property("Name").Not.Null
             .And.All.Property("Email").Contains('@')
             .And.No.Property("Id").LessThanOrEqualTo(0));
        }

        /// <summary>
        /// Testing Method with FluentAssertions
        /// </summary>
        /// <returns></returns>
        [Test]
        public void GetTable_Test()
        {
            // Arrange
            int number = 5;

            // Act
            int[] data = _service.GetTable(number);

            // Assert
            data.Should().NotBeEmpty()
           .And.HaveCount(10)
           .And.AllBeOfType(typeof(int))
           .And.StartWith(number * 1)
           .And.EndWith(number * 10);
        }

        /// <summary>
        /// Testing Method with FluentAssertions 
        /// </summary>
        /// <returns></returns>
        [Test]
        public void GetName_Test()
        {
            // Act
            string value = _service.GetName();

            // Assert
            value.Should().NotBeNullOrWhiteSpace()
            .And.Contain("parth")
            .And.Contain("n", Exactly.Thrice())
            .And.Be("parth nonghanvadra")
            .And.NotBe("nonghanvadra parth")
            .And.BeOneOf(
                "parth nonghanvadra",
                "nonghanvadra parth"
            );
        }

        /// <summary>
        /// Testing Method with FluentAssertions
        /// </summary>
        [Test]
        public void Date_Test()
        {
            // Arrange
            DateTime deadline = new DateTime(2021, 04, 24);

            // Act
            DateTime? date = _service.GetSubmissionDate();

            // Assert
            date.Should().Be(23.April(2021))
            .And.BeBefore(deadline)
            .And.NotBeAfter(deadline)
            .And.HaveDay(23)
            .And.HaveMonth(04)
            .And.HaveYear(2021)
            .And.BeMoreThan(0.Days()).Before(deadline);
        }

    }
}