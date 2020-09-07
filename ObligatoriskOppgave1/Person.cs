namespace ObligatoriskOppgave1
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public Person()
        {
            Id = 1;
        }

        public string GetDescription()
        {
            string desc = null;
            if (FirstName != null) desc += $"{FirstName} ";
            if (LastName != null) desc += $"{LastName} ";
            desc += $"(Id={Id})";
            if (BirthYear != 0) desc += $" Født: {BirthYear}";
            if (DeathYear != 0) desc += $" Død: {DeathYear}";
            if (Father != null)
            {
                desc += Father.FirstName != null ? " Far: " : "";
                desc += $"{Father.FirstName} (Id={Father.Id})";
            }

            if (Mother != null)
            {
                desc += Mother.FirstName != null ? " Mor: " : "";
                desc += $"{Mother.FirstName} (Id={Mother.Id})";
            }

            return desc;
        }
    }
}