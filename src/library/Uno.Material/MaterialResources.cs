using System;
using System.Linq;
using Uno.Disposables;

#if WinUI
using Microsoft.UI.Xaml;
#else
using Windows.UI.Xaml;
#endif

namespace Uno.Material
{
	/// <summary>
	/// Material resources including colors, layout values and styles
	/// </summary>
	public sealed class MaterialResources : ResourceDictionary
	{
		public MaterialResources() => InitializeResources();
		public MaterialResources(Uri colorPaletteSource) => ColorPaletteSource = colorPaletteSource;

		private Uri _ColorPaletteSource;
		public Uri ColorPaletteSource
		{
			get => _ColorPaletteSource;
			set
			{
				_ColorPaletteSource = value;
				InitializeResources();
			}
		}

		private void InitializeResources()
		{
			var mergedDictionary = new ResourceDictionary();
			// Add all ResourceDictionaries for Variables here in alphabetical order
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Application/AnimationConstants.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Application/Colors.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Application/Converters.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Application/TextBoxVariables.xaml");

			// Add all ResmergedDictionary, ourceDictionaries for Controls here in alphabetical order
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/BottomNavigationBar.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/BottomNavigationBarItem.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/Button.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/Card.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/Chip.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/ChipGroup.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/CheckBox.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/ComboBox.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/CommandBar.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/DatePicker.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/Divider.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/ExpandingBottomSheet.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/FloatingActionButton.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/Flyout.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/HyperlinkButton.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/InfoBar.xaml");
#if !WinUI				  
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/NavigationView.xaml"); // NavigationView merges it's related dictionaries already
#endif					 
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/PasswordBox.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/ProgressBar.xaml");
#if !WinUI				   
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/ProgressRing.xaml");
#endif					   
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/RadioButton.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/Ripple.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/SnackBar.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/Slider.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/StandardBottomSheet.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/TextBox.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/TextBlock.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/TimePicker.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/ToggleButton.xaml");
			AddDictionary(mergedDictionary, "ms-appx:///Uno.Material/Styles/Controls/ToggleSwitch.xaml");

			if (MergedDictionaries.Count == 0)
			{
				MergedDictionaries.Add(mergedDictionary);
			}
			else
			{
				MergedDictionaries[0] = mergedDictionary;
			}
		}

		void AddDictionary(ResourceDictionary mergedDictionary, string source)
		{
			if (mergedDictionary is null)
			{
				throw new ArgumentNullException(nameof(mergedDictionary));
			}

			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentException($"'{nameof(source)}' cannot be null or whitespace.", nameof(source));
			}

			var dictionary = new ResourceDictionary() { Source = new Uri(source) };
			if (ColorPaletteSource != null)
			{
				if (source == "ms-appx:///Uno.Material/Styles/Application/Colors.xaml")
				{
					dictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = ColorPaletteSource });
				}
				else
				{
					foreach (var item in dictionary.MergedDictionaries.Where(d => d.Source != null && d.Source.AbsoluteUri.EndsWith("/Application/Colors.xaml")))
					{
						item.MergedDictionaries.Add(new ResourceDictionary() { Source = ColorPaletteSource });
					}
				}
			}
			mergedDictionary.MergedDictionaries.Add(dictionary);
		}
	}
}
