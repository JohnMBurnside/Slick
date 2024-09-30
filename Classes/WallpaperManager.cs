using System;
using System.Runtime.InteropServices;
public class WallpaperManager
{
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
	// Constants
	private const int SPI_SETDESKWALLPAPER = 20;
	private const int SPIF_UPDATEINIFILE = 0x01;
	private const int SPIF_SENDCHANGE = 0x02;
	public void DarkModeToggle(bool darkMode)
	{
		string lightBg = "C:\\PRJ\\Slick\\Assets\\Backgrounds\\OSX15Light.jpg";
		string darkBg = "C:\\PRJ\\Slick\\Assets\\Backgrounds\\OSX15Dark.jpg";
		if (darkMode)
			SetWallpaper(lightBg);
		if(!darkMode)		
			SetWallpaper(darkBg);
	}
	public void SetWallpaper(string imagePath)
	{
		SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
		Console.WriteLine("Wallpaper changed successfully!");
	}
	public void GetWallpaper() { }

}
