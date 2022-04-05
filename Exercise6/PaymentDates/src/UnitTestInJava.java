import org.junit.Assert;
import org.junit.Test;

import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.Date;

public class UnitTestInJava {
    @Test
    public void CalculateFuturePaymentDate_ValidInput_DateReturned30DaysInFuture(){
        PaymentDates pd = new PaymentDates();
        Date sampleDate = new Date("7/6/2011");
        LocalDateTime localDateTime = sampleDate.toInstant().atZone(ZoneId.systemDefault()).toLocalDateTime();
        localDateTime = localDateTime.plusDays(30);

        Date resultDateWhichShouldBe30DaysLater = pd.CalculateFuturePaymentDate(sampleDate);
        sampleDate = Date.from(localDateTime.atZone(ZoneId.systemDefault()).toInstant());

        Assert.assertEquals(sampleDate, resultDateWhichShouldBe30DaysLater);
    }

    @Test
    public void CalculateFuturePaymentDate_InputCausesSundayDate_DateReturnedIsMonday(){
        PaymentDates pd = new PaymentDates();
        Date sampleDate = new Date("7/8/2011");

        Date resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);

        Assert.assertEquals(1, resultDateWhichShouldBeMonday.getDay());
    }
}
