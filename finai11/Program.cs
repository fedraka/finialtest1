using System;



public class Program
{
	public static void Main()
	{
		var person = new Person();
		person.personName = "test";


		var alarm = new AlarmClock();
		alarm.AlarmClockEvent += person.HandleAlarm;
		alarm.Alarm();
	}
}

public class alarmClockEventArgs : EventArgs
{
	public DateTime datetime { set; get; }
	public alarmClockEventArgs(DateTime datetime)
	{
		this.datetime = datetime;
	}
}

public delegate void AlarmClockHandeler(object source, alarmClockEventArgs e);

public class AlarmClock
{
	public event AlarmClockHandeler AlarmClockEvent;
	public void Alarm()
	{
		AlarmClockHandeler alarm = AlarmClockEvent;
		if (AlarmClockEvent != null)
		{
			alarm(this, new alarmClockEventArgs(DateTime.Now));
		}
	}
}

public class Person
{
	public string personName { get; set; }

	public void HandleAlarm(object sender, alarmClockEventArgs e)
	{
		Console.WriteLine("Alarm Go off!!!!");
	}
}