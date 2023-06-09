namespace ImagesMAUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (!MediaPicker.Default.IsCaptureSupported) return;

		var result = await MediaPicker.Default.CapturePhotoAsync();
		if (result != null)
		{
			var filePath = Path.Combine(FileSystem.CacheDirectory, result.FileName);
			label.Text = filePath;
			label.TextColor = Colors.Black;
			using var stream = await result.OpenReadAsync();
			await stream.CopyToAsync(File.OpenWrite(filePath));
			image.Source = ImageSource.FromFile(filePath);
		}
		else
		{
			label.Text = "Photo failed";
			label.TextColor = Colors.Black;
		}
    }
}

