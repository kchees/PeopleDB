using System;

namespace PeopleDB.UI
{
    public class MenuOption
    {
        public int Option { get; set; }
        public string Label { get; set; }  
        
        public string Format
        {
            get
            {
                return string.Format("{0}....{1}", Option, Label);
            }
        }
    }
}
