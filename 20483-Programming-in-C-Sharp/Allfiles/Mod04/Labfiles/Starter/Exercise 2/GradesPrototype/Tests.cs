
using System;
using GradesPrototype42.Data;
using NUnit.Framework;

namespace GradesPrototype42
{
    [TestFixture]
    public class GradesTests
    {
        [SetUp]
        public void SetUp()
        {
            Init();
        }

        [Test]
        public void TestValidGrade()
        {
            var grade = new Grade();
            Assert.That(() => grade.Assessment = "A", Throws.Nothing);
        }

        [Test]
        public void TestBadDate()
        {
            var grade = new Grade();
            Assert.That(() => grade.AssessmentDate = (DateTime.Today.AddDays(1)).ToShortDateString(), Throws.ArgumentException);
        }

        [Test]
        public void TestDatenotRecognized()
        {
            var grade = new Grade();
            Assert.That(() => grade.AssessmentDate = "NotADate", Throws.ArgumentException);
        }

        [Test]
        public void TestBadAssessment()
        {
            var grade = new Grade();
            Assert.That(() => grade.Assessment = "Z", Throws.ArgumentException);
        }

        [Test]
        public void TesBadSubject()
        {
            var grade = new Grade();
            Assert.That(() => grade.SubjectName= "Z", Throws.ArgumentException);
        }

        private void Init()
        {
            DataSource.CreateData();
        }

    }
}