using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPHelloWorld
{
    class MyListItem
    {
        string title;
        string content;

        //Constructor
        public MyListItem(string title, string content)
        {
            this.title = title;
            this.content = content;
        }


        //GET AND SET
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

    }
}
