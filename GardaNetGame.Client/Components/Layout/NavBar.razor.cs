
namespace GardaNetGame.Client.Components.Layout
{
    public partial class NavBar
    {
        private string currentUrl = string.Empty;

		private int cartItemCount = 0;
		protected override async Task OnInitializedAsync()
		{
			currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
		}

        protected void NavigateToCheckout()
        {
            NavigationManager.NavigateTo("/checkout");
        }
    }
}


