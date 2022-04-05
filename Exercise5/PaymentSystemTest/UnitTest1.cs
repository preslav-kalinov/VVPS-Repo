using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VVPS_Exercise4;

namespace PaymentSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateFuturePaymentDate_Valid_DateRet30DaysInFuture()
        {
            var pd = new PaymentDates();
            DateTime sampleData = DateTime.Parse("7/6/2011");

            DateTime resultDateShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleData);

            Assert.AreEqual(sampleData.AddDays(30), resultDateShouldBe30DaysLater);
        }

        [TestMethod]
        public void CalculateFuturePaymentDate_InputCausesSundayDate_DateRetMonday()
        {
            var pd = new PaymentDates();
            DateTime sampleData = DateTime.Parse("7/8/2011");

            DateTime resultDateShouldBeMonday = pd.CalculateFuturePaymentDate(sampleData);

            Assert.AreEqual(DayOfWeek.Monday, resultDateShouldBeMonday);
        }
    }
}
