//using Microsoft.Extensions.Configuration;

namespace GardaNetGame.Shared.Entities;
using System.ComponentModel.DataAnnotations;

public class FaqForm
{


	[Required(ErrorMessage = "Ange ditt namn")]
	[StringLength(100, ErrorMessage = "Namnet får inte vara längre än 100 tecken")]
	public string UserName { get; set; }

	[Required(ErrorMessage = "E-postadress är obligatorisk")]
	[EmailAddress(ErrorMessage = "Ogiltig e-postadress")]
	public string UserEmail { get; set; }

	[Required(ErrorMessage = "Frågan kan inte vara tom")]
	[StringLength(500, ErrorMessage = "Frågan får inte vara längre än 500 tecken")]
	public string UserQuestion { get; set; }
}
