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
    /// <summary>The main page of the application.</summary>
    public sealed partial class MainPage : Page
    {
        // THE ARRAY THAT STORES YOUR INPUTS
        /// <summary>The inputs
        /// from the user</summary>
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
        /// <summary>Add button for the inputs</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox inputText = this.FindName("Input1") as TextBox;
            TextBox contentText = this.FindName("InputContent") as TextBox;
            string title = inputText.Text;
            string content = contentText.Text;

            if(title.Equals("") || content.Equals(""))
            {
                Debug.WriteLine("Empty strings");
            }
            else
            {

                MyListItem listItem = new MyListItem(title, content);

                inputs.Add(listItem);

                //Clear inputs after adding item to array

                inputText.Text = "";
                contentText.Text = "";

                //Populate with the updated array
                Populate_ListView();
            }


        }

        /// <summary>Populates the ListView.</summary>
        private void Populate_ListView()
        {
            ListView list = this.FindName("ListView1") as ListView;

            //Clear it, so you can show the current state of the ArrayList.

            list.Items.Clear();

            //Foreach to add the title to the ListView

            foreach(MyListItem listItem in inputs)
            {
                list.Items.Add(listItem.Title);
            }

            //printing a count above the list:

            int count = list.Items.Count();
            TextBlock countText = this.FindName("CountText") as TextBlock;
            countText.Text = count.ToString();
        }


        /// <summary>Handles the SelectedIndexChanged event of the ListView control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void ListView_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            //When the event of "ListView_SelectedIndexChanged" is called, write title and content of current list-item to the app.

            ListView list = this.FindName("ListView1") as ListView;
            TextBlock titleOutput = this.FindName("TitleOutput") as TextBlock;
            TextBlock contentOutput = this.FindName("ContentOutput") as TextBlock;

            int index = list.SelectedIndex;

            //Try catch due to index out of bounds when updating.
            try
            {
                //Get the item at the selected index from the array, then set the text of the title field and content field.
                MyListItem item = (MyListItem)inputs[index];
                string title = item.Title;
                string content = item.Content;

                titleOutput.Text = title;
                contentOutput.Text = content;
            }
            catch
            {
                Debug.WriteLine("Exception");
            }
        }

        /// <summary>Handles the Click event of the Delete button.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
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

            try
            {
                inputs.RemoveAt(index);
            }
            catch
            {
                Debug.WriteLine("Out of range delete");
            }

            //Populate with the array that now have one less item.
            Populate_ListView();
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OtherPage));
        }
    }
}
