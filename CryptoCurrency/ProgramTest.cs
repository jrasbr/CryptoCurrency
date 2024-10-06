using Xunit;


public class ProgramTest
{
    [Fact]
    public void TestConvert()
    {
        Converter converter = new Converter();
        converter.SetPricePerUnit("Bitcoin", 10000);
        converter.SetPricePerUnit("Ethereum", 300);
        converter.SetPricePerUnit("Litecoin", 50);

        double amount = 100;
        double convertedAmount = converter.Convert("Bitcoin", "Ethereum", amount);

        Assert.Equal(3, convertedAmount);
    }

    [Fact]
    public void TestSetPricePerUnit()
    {
        Converter converter = new Converter();
        converter.SetPricePerUnit("Bitcoin", 10000);
        converter.SetPricePerUnit("Ethereum", 300);
        converter.SetPricePerUnit("Litecoin", 50);

    }

    [Fact]
    public void TestSetPricePerUnitNegative()
    {
        Converter converter = new Converter();
        Assert.Throws<System.ArgumentException>(() => converter.SetPricePerUnit("Bitcoin", -10000));
    }

    [Fact]
    public void TestConvertNegativeAmount()
    {
        Converter converter = new Converter();
        converter.SetPricePerUnit("Bitcoin", 10000);
        converter.SetPricePerUnit("Ethereum", 300);
        converter.SetPricePerUnit("Litecoin", 50);

        Assert.Throws<System.ArgumentException>(() => converter.Convert("Bitcoin", "Ethereum", -100));
    }

    [Fact]
    public void TestConvertKeyDoesNotExist()
    {
        Converter converter = new Converter();
        converter.SetPricePerUnit("Bitcoin", 10000);
        converter.SetPricePerUnit("Ethereum", 300);
        converter.SetPricePerUnit("Litecoin", 50);

        Assert.Throws<System.ArgumentException>(() => converter.Convert("Bitcoin", "Dogecoin", 100));
    }

}