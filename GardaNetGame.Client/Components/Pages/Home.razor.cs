namespace GardaNetGame.Client.Components.Pages
{
    public partial class Home
    {
        private string currentUrl = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
        }

        private void NavigateToEvents()
        {
	        NavigationManager.NavigateTo("/event");
        }

        private void NavigateToGames()
        {
            NavigationManager.NavigateTo("/games");
        }

    }
}
