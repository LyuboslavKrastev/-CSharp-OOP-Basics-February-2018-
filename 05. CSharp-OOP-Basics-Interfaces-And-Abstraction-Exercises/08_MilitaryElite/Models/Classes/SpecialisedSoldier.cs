
using System;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        bool isValidCorps = Enum.TryParse(typeof(Corps), corps, out object validCorps);
        if (!isValidCorps)
        {
            throw new ArgumentException("Invalid corps!");
        }
        this.@Corps = (Corps)validCorps;
    }

    public Corps @Corps { get; private set; }
}
