﻿using System;
using System.Collections.Generic;

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
		public MaterialResources() => this.InitializeResources();
		//public MaterialResources(Uri colorPaletteSource) => this.ColorPaletteSource = colorPaletteSource;

		private Uri _ColorPaletteSource;
		public Uri ColorPaletteSource
		{
			get => _ColorPaletteSource;
			set
			{
				_ColorPaletteSource = value;
				SetColorPaletteSource();
			}
		}

		private void InitializeResources()
		{
			// Add all ResourceDictionaries for Variables here in alphabetical order
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/AnimationConstants.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/Colors.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/Converters.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Application/TextBoxVariables.xaml") });

			// Add all ResourceDictionaries for Controls here in alphabetical order
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/BottomNavigationBar.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/BottomNavigationBarItem.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Button.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Card.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Chip.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ChipGroup.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/CheckBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ComboBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/CommandBar.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/DatePicker.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Divider.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ExpandingBottomSheet.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/FloatingActionButton.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Flyout.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/HyperlinkButton.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/InfoBar.xaml") });
#if !WinUI
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/NavigationView.xaml") }); // NavigationView merges it's related dictionaries already
#endif
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/PasswordBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ProgressBar.xaml") });
#if !WinUI_Desktop
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ProgressRing.xaml") });
#endif
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/RadioButton.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Ripple.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/SnackBar.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/Slider.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/StandardBottomSheet.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/TextBox.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/TextBlock.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/TimePicker.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ToggleButton.xaml") });
			this.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///Uno.Material/Styles/Controls/ToggleSwitch.xaml") });
		}
		private void SetColorPaletteSource()
		{
			if (ColorPaletteSource == null)
			{
				foreach (var dictionary in GetColorResourceDictionaries())
				{
					while (dictionary.MergedDictionaries.Count > 1)
					{
						dictionary.MergedDictionaries.RemoveAt(dictionary.MergedDictionaries.Count - 1);
					}
				}
			}
			else
			{
				foreach (var dictionary in GetColorResourceDictionaries())
				{
					if (dictionary.MergedDictionaries.Count == 1)
					{
						dictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = ColorPaletteSource });
					}
					else
					{
						dictionary.MergedDictionaries[0] = new ResourceDictionary() { Source = ColorPaletteSource };
					}
				}
			}
		}

		private List<ResourceDictionary> colorResourceDictionaries;
		private List<ResourceDictionary> GetColorResourceDictionaries()
		{
			if (colorResourceDictionaries == null)
			{
				colorResourceDictionaries = new List<ResourceDictionary>();
				foreach (var dictionary in MergedDictionaries)
				{
					GetColorResourceDictionaries(dictionary);
				}
			}
			return colorResourceDictionaries;
		}
		private void GetColorResourceDictionaries(ResourceDictionary dictionary)
		{
			colorResourceDictionaries = colorResourceDictionaries ?? new List<ResourceDictionary>();
			if (dictionary.Source != null && dictionary.Source.AbsoluteUri.EndsWith("Colors.xaml"))
			{
				colorResourceDictionaries.Add(dictionary);
			}
			foreach (var item in dictionary.MergedDictionaries)
			{
				GetColorResourceDictionaries(item);
			}
		}
	}
}
