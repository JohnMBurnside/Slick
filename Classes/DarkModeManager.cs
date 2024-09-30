using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
public class DarkModeManager
{
	public bool isDarkMode = false;
	[DllImport("user32.dll")]
	private static extern int SendMessage(int hWnd, int msg, int wParam, int lParam);
	private const int WM_SETTINGCHANGE = 0x001A;
	private const int HWND_BROADCAST = 0xFFFF;
    public DarkModeManager()
	{
		isDarkMode = IsDarkMode();
	}
	public void Toggle()
	{
		using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true))
		{
			var vari = Convert.ToInt32(key.GetValue("AppsUseLightTheme"));
			Debug.WriteLine(vari);
			if (key != null)
			{
				if(!isDarkMode)
				{
					key.SetValue("AppsUseLightTheme", 0, RegistryValueKind.DWord);
					key.SetValue("SystemUsesLightTheme", 0, RegistryValueKind.DWord);
					key.SetValue("ColorPrevalence", 0, RegistryValueKind.DWord);
				}
				else if (isDarkMode)
				{
					key.SetValue("AppsUseLightTheme", 1, RegistryValueKind.DWord);
					key.SetValue("SystemUsesLightTheme", 1, RegistryValueKind.DWord);
					key.SetValue("ColorPrevalence", 1, RegistryValueKind.DWord);
				}
				else
				{
					Debug.WriteLine("Error, no theme values changed");
					return;
				}	
				isDarkMode = !isDarkMode;
			}
		}
		// Notify the system that the setting has changed
		SendMessage(HWND_BROADCAST, WM_SETTINGCHANGE, 0, 0);
		Console.WriteLine("Switched to Dark Mode.");
	}
	public bool IsDarkMode()
	{
        using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true))
		{
			// More implementation needs to be added for edge cases
			int keyInt= Convert.ToInt32(key.GetValue("AppsUseLightTheme"));
			if (keyInt < 1)
			{
				Debug.WriteLine("Dark Mode On");
				return true;
			}
			else
			{
                Debug.WriteLine("Dark Mode Off");
                return false;
			}
		}
	}
}