using System;
using System.Collections.Generic;

namespace PeopleDB.UI
{
    public static class MenuCommand
    {
        public const int List = 1;
        public const int Search = 2;
        public const int AddUpdate = 3;
        public const int Delete = 4;
        public const int ClearAll = 5;
        public const int ResetDB = 6;
        public const int Quit = 7;
    }

    public class Menu
    { 
        private readonly List<MenuOption> options = new List<MenuOption>()
        {
            new MenuOption { Option = MenuCommand.List, Label = "List All People" },
            new MenuOption { Option = MenuCommand.Search, Label = "Search For A Person" },
            new MenuOption { Option = MenuCommand.AddUpdate, Label = "Add/Update A Person" },
            new MenuOption { Option = MenuCommand.Delete, Label = "Delete A Person" },
            new MenuOption { Option = MenuCommand.ClearAll, Label = "Clear Database" },
            new MenuOption { Option = MenuCommand.ResetDB, Label = "Initialize Database" },
            new MenuOption { Option = MenuCommand.Quit, Label = "Quit" }
        };
        
        public int Show()
        {
            Console.Clear();
            UIHelper.OutputTitle();
            Console.WriteLine("");
            options.ForEach(o => Console.WriteLine(o.Format));

            Console.WriteLine("");
            Console.Write("Select option (1-{0}): ", options.Count);

            int option;
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                option = key.KeyChar - '0';
            }
            while ((option < 1) || (option > 9));
            
            return option;
        }  
    }
}
