public class Converter {
    //Main method
    public static void Main(string[] args)
    {
        //Eksempel på brug af Converter klassen
        //Opret en instans af Converter klassen
        Converter converter = new Converter();

        //Angiv priser for forskellige kryptovalutaer
        converter.SetPricePerUnit("Bitcoin", 10000);
        converter.SetPricePerUnit("Ethereum", 300);
        converter.SetPricePerUnit("Litecoin", 50);

        //Konverter fra Bitcoin til Ethereum
        double amount = 100;
        double convertedAmount = converter.Convert("Bitcoin", "Ethereum", amount);

        Console.WriteLine(amount + " Bitcoin is " + convertedAmount + " Ethereum");
    }

    Dictionary<string, double> prices = new Dictionary<string, double>();
    /// <summary>
    /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
    /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
    /// bliver den gamle værdi overskrevet af den nye værdi
    /// </summary>
    /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
    /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
    public void SetPricePerUnit(String currencyName, double price) {

        //Hvis prisen er negativ, returneres uden at gøre noget
        if (price <= 0)
            throw new ArgumentException("Price must be a non-negative value");

        //Fjern nøglen. Hvis den ikke findes, smides der ingen exception.
        prices.Remove(currencyName);

        //Tilføj nøglen og værdien
        prices.Add(currencyName, price);
    }

    /// <summary>
    /// Konverterer fra en kryptovaluta til en anden. 
    /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
    /// 
    /// </summary>
    /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
    /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
    /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
    /// <returns>Værdien af beløbet i toCurrencyName</returns>
    public double Convert(String fromCurrencyName, String toCurrencyName, double amount) {
       
        //Hvis en af valutaerne ikke findes, kastes en ArgumentException
        if (!prices.ContainsKey(fromCurrencyName) || !prices.ContainsKey(toCurrencyName))
            throw new ArgumentException("Key did not exist");

        //Hvis amount er negativ, kastes en ArgumentException
        if (amount <= 0)
            throw new ArgumentException("Amount was negative or 0");

        //Hent priserne for de to valutaer i dictionary
        double fromPrice = prices[fromCurrencyName];
        double toPrice = prices[toCurrencyName];

        return amount * toPrice / fromPrice;
    }
}