using System;


namespace ObligatoriskOppgave1
{
    public class FamilyApp
    {
        private Person[] _family;
        public int Count;

        public string WelcomeMessage =
            "\n\n" +
            "    ┌─────────────────────────────────────────────────────────────────────────┐\n" +
            "    │  Secret files of the Montgomery family [max. 10 queries]                │\n" +
            "    │  You have *** 5 MINUTES *** before the secret services track you down.  │\n" +
            "    │  Hurry up, time is running out !!!                                      │\n" +
            "    └─────────────────────────────────────────────────────────────────────────┘\n\n";

        public FamilyApp(params Person[] persons)
        {
            _family = persons;
            Count = 10;
            CommandPrompt();
        }

        public string CommandPrompt()
        {
            return
                "[type <hjelp> for help]\n" +
                "Top secret base [access level x10][query " + Count + "/10]\n";
        }

        public string HandleCommand(string command)
        {
            int tryToConvert = 0;
            if (command != null && command.Length > 4 &&
                command.Substring(0, 4) == "vis " &&
                int.TryParse(command.Substring(4), out tryToConvert))
                return Vis(command);

            switch (command)
            {
                case "hjelp":
                    return Hjelp();
                case "liste":
                    return Liste();
                case "exit":
                    return "exit";
                default:
                    return $"\nWrong command \"{command}\"\n";
            }
        }

        private string Hjelp()
        {
            return
                "\n------------------------------\n" +
                "  List of supported comments\n" +
                "------------------------------\n" +
                "Type:\n\n" +
                "  hjelp    - to see this help\n" +
                "  liste    - to see all person in the Montgomery family\n" +
                "  vis <id> - to see specific person e.g. \"vis 25\"\n" +
                "  exit     - to close the program\n\n" +
                "The maximum number of queries is 10\n" +
                "!!! If you exceed 5 MINUTES, your secret spy mission will be burned. !!!\n";
        }

        private string Liste()
        {
            Console.ForegroundColor = Colors.Person;
            string liste = "\n";

            foreach (var person in _family)
            {
                liste += person.GetDescription() + "\n";
            }

            return liste;
        }

        private string Vis(string command)
        {
            Console.ForegroundColor = Colors.Person;
            int id = Int32.Parse(command.Substring(4));

            foreach (var person in _family)
            {
                if (person.Id == id)
                {
                    string children = null;
                    string desc = $"\n{person.GetDescription()}\n";
                    foreach (var child in _family)
                    {
                        if (child.Father != null && child.Father.Id == id)
                        {
                            children += $" {printChild(child)}\n";
                        }
                        else if (child.Mother != null && child.Mother.Id == id)
                        {
                            children += $" {printChild(child)}\n";
                        }
                    }

                    return children != null ? desc + " Barn:\n" + children : desc;
                }
            }

            return
                $"\nThe person with the Id <{id}> was not found\n";
        }

        private string printChild(Person child)
        {
            string desc = null;
            if (child.FirstName != null) desc += $"{child.FirstName} ";
            if (child.LastName != null) desc += $"{child.LastName} ";
            desc += $"(Id={child.Id})";
            if (child.BirthYear != 0) desc += $" Født: {child.BirthYear}";
            return desc;
        }
    }
}