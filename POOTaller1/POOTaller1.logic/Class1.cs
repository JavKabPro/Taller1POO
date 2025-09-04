namespace POOTaller1.logic;

public class Time            //Attributes
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

public Time()               //Constructor Method
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }                                               //These are overloaded constructors for the Time class.
                                                    //The idea is to allow you to create a Time object with
                                                    //different numbers of parameters without repeating code.
                                                    //Constructor method (Overload)
                                                    //It is defined by the number of parameters and the type of parameters.

    public Time(int hour) : this(hour, 0, 0, 0) { } //If only hour is provided, put minute, second, and millisecond to 0.
    public Time(int hour, int minute) : this(hour, minute, 0, 0) { } //If hour and minute are only provided, put second and millisecond to 0.
    public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { } //If hour, minute, and second are only provided, put millisecond to 0.
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }
    public int Hour     //Public properties must begin with a capital letter. 
    {
        get => _hour;   //I want properties to be linked to attributes.
        set             //... and I want that the privates attributes have relation with
        {               //publics properties...
            _hour = ValidHour(value);
            }
    }
    public int Minute   
    {
        get => _minute; //Replaced with arrow notation
        set
        {
            _minute =ValidMinute(value);
        }
    }
    public int Second
    {
        get => _second;
        set
        {
            _second = ValidSecond(value);
        }
    }
    public int Millisecond
    {
        get => _millisecond;
        set
        {
            _millisecond = ValidMillisecond(value);
        }
    }                               //End of properties
                                    //
    public long ToMilliseconds()    //Convert time to milliseconds,it is a conversion method.
    {
        return (long)Hour * 3600000 + Minute * 60000 + Second * 1000 + Millisecond; //Transforms the Time object to another unit(milliseconds).
    }

    public long ToSeconds()
    {
        return ToMilliseconds() / 1000;                 //Conversion from milliseconds to seconds.
    }

    public long ToMinutes()
    {
        return ToMilliseconds() / 60000;                //Conversion from milliseconds to minutes.
    }
    public Time Add(Time other)                         //
    {
        long totalMilliseconds = ToMilliseconds() + other.ToMilliseconds(); //Converts both Time objects to absolute milliseconds.
        int newHour = (int)((totalMilliseconds / 3600000) % 24);            //Calculating the new hour from the total milliseconds
        int newMinute = (int)((totalMilliseconds / 60000) % 60);            //The minutes are calculated on this line.
        int newSecond = (int)((totalMilliseconds / 1000) % 60);             //In this part the seconds are obtained.
        int newMillisecond = (int)(totalMilliseconds % 1000);               //Finally, we calculate the remaining milliseconds.

        return new Time(newHour, newMinute, newSecond, newMillisecond);     //New object Tme.
    }
    public bool IsOtherDay(Time other)
    {
        return ToMilliseconds() + other.ToMilliseconds() >= 86400000;       //If the sum of two times is carried over to the next day.
    }

    public override string ToString()
    {
        if (Hour == 0 && Minute == 0 && Second == 0 && Millisecond == 0)    //If the time is 00:00:00.000, return this string.
        {                                                                   //Because 12:00:00.000 AM is not correct way, according to the teacher
            return "00:00:00.000 AM";
        }
        int displayHour = Hour % 12;                                        //Convert hour from 24hours format to 12hours format.
        if (displayHour == 0) displayHour = 12;                             //If hour is 0, set it to 12.
        string period = Hour < 12 ? "AM" : "PM";                            //Determine if it is AM or PM.
        return $"{displayHour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
    }
    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour: {hour} is not valid.");
        }
        return hour;
    }
    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute: {minute} is not valid.");
        }
        return minute;
    }
    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second: {second} is not valid.");
        }
        return second;
    }
    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The millisecond: {millisecond} is not valid.");
        }
        return millisecond;
    }
}