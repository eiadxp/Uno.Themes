﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uno.Themes.Samples.Entities;
using Uno.Themes.Samples.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Uno.Themes.Samples.Content.Controls
{
	[SamplePage(SampleCategory.Controls, "Modal Standard Bottom Sheet", SourceSdk.UnoMaterial, Description = "This represents a draggable, modal bottom sheet. Sheet Content and FullScreenHeader are customizable", DocumentationLink = "https://material.io/components/sheets-bottom#modal-bottom-sheet", DataType = typeof(ModalBottomSheetViewModel))]
	public sealed partial class ModalStandardBottomSheetSamplePage : Page
	{
		public ModalStandardBottomSheetSamplePage()
		{
			this.InitializeComponent();
		}
	}
}
