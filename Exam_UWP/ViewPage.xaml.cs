using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exam_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewPage : Page
    {
        private ObservableCollection<StorageFile> _fileList;
        internal ObservableCollection<StorageFile> FileList { get => _fileList; set => _fileList = value; }
        public ViewPage()
        {
            this.InitializeComponent();
            this.FileList = new ObservableCollection<StorageFile>();
        }

        private async void viewPage_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            var files = await storageFolder.GetFilesAsync();
            foreach(var file in files)
            {
                FileList.Add(file);
            }
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = this.selectBox.SelectedIndex;
            content.Text = await Windows.Storage.FileIO.ReadTextAsync(FileList[selectedIndex]);
        }
    }
}
