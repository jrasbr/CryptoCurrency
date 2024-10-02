using Xunit;


public class ProgramTest
{

    const string currencyBTC = "BTC";
    const double currencyBTCPrice = 416238.43;
    const string currencyETC = "ETC";
    const double currencyETCPrice = 16460.11;
    const string currencyXRP = "XRP";
    const double currencyXRPPrice = 3.91;



    [Theory]
    [InlineData(currencyBTC, currencyBTCPrice, currencyETC, currencyETCPrice, 1000, 39.544906989967266)]
    [InlineData(currencyETC, currencyETCPrice, currencyBTC, currencyBTCPrice, 1000, 25287.706461256941)]
    [InlineData(currencyBTC, currencyBTCPrice, currencyXRP, currencyXRPPrice, 1000, 0.0093936544974955825)]
    [InlineData(currencyXRP, currencyXRPPrice, currencyBTC, currencyBTCPrice, 1000, 106454841.43222506)]


    public void Convert_Result_Should_Equal_ExpectedPrice(string fromCurrency, double fromCurrencyRate, string toCurrency, double toCurrencyRate, double amount, double expectedPrice)
    {
        //Arrange
        Converter converter = new Converter();

        //Act
        converter.SetPricePerUnit(fromCurrency, fromCurrencyRate);
        converter.SetPricePerUnit(toCurrency, toCurrencyRate);

        double price = converter.Convert(fromCurrency, toCurrency, amount);

        //Assert
        Assert.Equal(price, expectedPrice, 0.01);
    }
}