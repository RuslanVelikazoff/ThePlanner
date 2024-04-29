[System.Serializable]
public class GameData 
{
    //Profile
    public string firstName;
    public string lastName;
    public string emailAddress;
    public int age;
    public bool[] gender = new bool[3];
    
    //Settings
    public bool[] calendarType = new bool[2];
    public bool pushNotifications;
    public bool sounds;

    public GameData()
    {
        gender[0] = false;
        gender[1] = false;
        gender[2] = false;
    }
}
