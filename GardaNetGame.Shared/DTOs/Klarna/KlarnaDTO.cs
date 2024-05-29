namespace GardaNetGame.Shared.DTOs.Klarna
{
    public class KlarnaDTO
    {
        public string purchase_country { get; set; }
        public string purchase_currency { get; set; }
        public string locale { get; set; }
        public int order_amount { get; set; }
        
        public int order_tax_amount { get; set; }
        
        public List<OrderKlarnaDTO> order_lines { get; set; } = new List<OrderKlarnaDTO>();
		public Dictionary<string, string> merchant_urls { get; set; }
    }
}
