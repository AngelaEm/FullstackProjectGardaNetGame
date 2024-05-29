

namespace GardaNetGame.Client.Components
{
    //public class Klarna
    //{
    //    public void KlarnaAPI()
    //    {
            
    //        var klarnaConfig = new Klarna.Rest.Core.Configuration(
    //            username: "PK254382_cf8896f6edf1",
    //            password: "A2vOPOtBsjQYp2oN",
    //            apiEndpoint: Klarna.Rest.Core.Commuication.ApiUrl.NorthAmerica.Test // Ändra till rätt API slutpunkt beroende på din region
    //        );
    //        // Skapa konfigurationsinstans
    //    }
    //}
    //public class KlarnaService
    //{
    //    private Klarna.Rest.Core.Configuration _klarnaConfig;

    //    public KlarnaService(IConfiguration configuration)
    //    {
    //        klarnaConfig = new Klarna.Rest.Core.Configuration(
    //            username: configuration["Klarna:Username"],
    //            password: configuration["Klarna:Password"],
    //            apiEndpoint: GetApiEndpoint(configuration["Klarna:Environment"])
    //        );
    //    }

    //    private ApiUrl GetApiEndpoint(string environment)
    //    {
    //        return environment.ToLower() switch
    //        {
    //            "production" => Klarna.Rest.Core.Commuication.ApiUrl.NorthAmerica.Production,
    //            "test" => Klarna.Rest.Core.Commuication.ApiUrl.NorthAmerica.Test,
    //         => throw new ArgumentException("Invalid Klarna environment setting")
    //        };
    //    }

    //    public CheckoutClient CreateCheckoutClient()
    //    {
    //        return new CheckoutClient(_klarnaConfig);
    //    }

    //    // Metoder för att hantera order, etc.
    //}
}
