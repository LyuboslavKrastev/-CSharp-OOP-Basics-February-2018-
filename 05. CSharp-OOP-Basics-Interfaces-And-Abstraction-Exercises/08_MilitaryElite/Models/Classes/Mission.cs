
using System;

public class Mission : IMission
{
    public Mission(string codeName, string missionState)
    {
        this.CodeName = codeName;
        ParseMissionState(missionState);
    }

    private void ParseMissionState(string missionState)
    {
        bool isValidState = Enum.TryParse(typeof(MissionState), missionState, out object outState);

        if (!isValidState)
        {
            throw new ArgumentException("Invalid mission state!");
        }
        this.State = (MissionState)outState;
    }

    public string CodeName { get; private set; }

    public MissionState State { get; private set; }

    public void Complete()
    {
        this.State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
    }
}

