namespace tarea1._4.Views;

public partial class PageFotos : ContentPage
{
	public PageFotos()
	{
		InitializeComponent();
        cargarList();
    }


    public async void cargarList()
    {
        var fotoList = await App.SQLiteBD.GetFotoAsync();
        if (fotoList != null)
        {
            lstFotos.ItemsSource = fotoList;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var listafotos = await App.SQLiteBD.GetFotoAsync();
        lstFotos.ItemsSource = listafotos;
    }

    private async void lstFotos_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Models.Fotos item = (Models.Fotos)e.Item;

        var page = new Verfotos();
        page.BindingContext = item;
        await Navigation.PushAsync(page);

    }
}