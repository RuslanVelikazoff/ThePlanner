using System;
using System.Collections.Generic;



[System.Serializable]
public class GameData 
{
    public enum Priority
    {
        Null,
        High,
        Mid,
        Low
    }

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
    
    //Tasks
    public List<string> nameOfTask = new List<string>();
    public List<string> descriptionOfTheTask = new List<string>();
    public List<DateTime> startDate;
    public List<string> startDateString = new List<string>();
    public List<DateTime> endDate;
    public List<string> endDateString = new List<string>();
    public List<Priority> priority = new List<Priority>();
    public List<bool> taskCompleted = new List<bool>();

    public GameData()
    {
        gender[0] = false;
        gender[1] = false;
        gender[2] = false;

        startDate = new List<DateTime>();
        endDate = new List<DateTime>();
    }
}
