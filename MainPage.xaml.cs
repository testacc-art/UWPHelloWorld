using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPHelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        ArrayList inputs = new ArrayList();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock txt = this.FindName("TextBlock1") as TextBlock;
            txt.Text = "Hello World";
        }

        //Adding input into ArrayList, then calling the Populate_Listview method.
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox inputText = this.FindName("Input1") as TextBox;
            TextBox contentText = this.FindName("InputContent") as TextBox;
            string title = inputText.Text;
            string content = contentText.Text;

            MyListItem listItem = new MyListItem(title, content);

            inputs.Add(listItem);

            Populate_ListView();
        }

        private void Populate_ListView()
        {
            ListView list = this.FindName("ListView1") as ListView;

            list.Items.Clear();

            foreach(MyListItem listItem in inputs)
            {
                list.Items.Add(listItem.Title);
            }

            //printing a count above the list:

            int count = list.Items.Count();
            TextBlock countText = this.FindName("CountText") as TextBlock;
            countText.Text = count.ToString();
        }

        //When the event of "ListView_SelectedIndexChanged" is called, write title and content of current list-item to the app.

        private void ListView_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView list = this.FindName("ListView1") as ListView;
            TextBlock titleOutput = this.FindName("TitleOutput") as TextBlock;
            TextBlock contentOutput = this.FindName("ContentOutput") as TextBlock;

            int index = list.SelectedIndex;

            //Try catch due to index out of bounds when updating.
            try
            {
                MyListItem item = (MyListItem)inputs[index];
                string title = item.Title;
                string content = item.Content;

                titleOutput.Text = title;
                contentOutput.Text = content;
            }
            catch
            {
                Debug.WriteLine("Failed to write");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ListView list = this.FindName("ListView1") as ListView;

            // Clear the outputfields:
            TextBlock titleOutput = this.FindName("TitleOutput") as TextBlock;
            TextBlock contentOutput = this.FindName("ContentOutput") as TextBlock;

            titleOutput.Text = "";
            contentOutput.Text = "";

            // Get index of currently selected in the ListView

            int index = list.SelectedIndex;

            inputs.RemoveAt(index);

            //Populate with the array that now have one less item.

            Populate_ListView();
        }
    }
}
