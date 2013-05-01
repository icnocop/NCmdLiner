// File: ParseArrayTests.cs
// Project Name: NCmdLiner.Tests
// Project Home: https://github.com/trondr
// License: New BSD License (BSD) http://www.opensource.org/licenses/BSD-3-Clause
// Credits: See the credits folder in this project
// Copyright � <github.com/trondr> 2013 
// All rights reserved.

using NCmdLiner.Exceptions;
using NUnit.Framework;
using Rhino.Mocks;

namespace NCmdLiner.Tests
{
    [TestFixture, Category(TestCategory.UnitTests)]
    public class ParseArrayTests
    {
        private static MockRepository _mockRepository;

        [SetUp]
        public static void SetUp()
        {
            _mockRepository = new MockRepository();
        }

        [TearDown]
        public static void TearDown()
        {
            _mockRepository.BackToRecordAll();
            _mockRepository = null;
        }

        #region Semicolon tests

        [Test]
        public void ParseArraySimpleSemicolonSeparationSuccess()
        {
            const string arrayString = "12;13;14;15";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15"};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseArraySimpleSemicolonSeparationEndingWithSemiColonSuccess()
        {
            const string arrayString = "12;13;14;15;";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15", ""};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseArrayQuotedSemicolonSeparationEndingWithSemiColonSuccess()
        {
            const string arrayString = "'12';'13';'14';'15';";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15", ""};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseArrayParantesis1SimpleSemicolonSeparationSuccess()
        {
            const string arrayString = "{12;13;14;15}";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15"};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseArrayParantesis2SimpleSemicolonSeparationSuccess()
        {
            const string arrayString = "[12;13;14;15]";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15"};
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Plus tests

        [Test]
        public void ParseArraySimplePlusSeparationSuccess()
        {
            const string arrayString = "12+13+14+15";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15"};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseArrayParantesis1SimplePlusSeparationSuccess()
        {
            const string arrayString = "{12+13+14+15}";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15"};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseArrayParantesis2SimplePlusSeparationSuccess()
        {
            const string arrayString = "[12+13+14+15]";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12", "13", "14", "15"};
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Non supported tests

        [Test]
        public void ParseArrayNonSupportedDelimiterReturnOneItemArray()
        {
            const string arrayString = "12-13-14-15";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"12-13-14-15"};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ParseArrayEmptyArrayStringReturnZeroItemArray()
        {
            const string arrayString = "";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new string[] {};
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Corrupt tests

        [Test]
        [ExpectedException(typeof (InvalidArrayParseException))]
        public void ParseArraySemicolonSeparationCorruptThrowInvalidArrayParseExeption()
        {
            const string arrayString = "'123';'21';'142;'5'";
            IArrayParser target = new ArrayParser();
            var actual = target.Parse(arrayString);
            var expected = new[] {"123", "21", "142", "5"};
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}