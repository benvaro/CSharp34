using System;

namespace Event_02
{
    delegate void UI();  // делегат, що посилаэтсья на методи, які нічого не приймають і не повертають
    class MyEvent
    {
        public event UI UserEvent;  // оголосили подію типу делегата UI

        //Raise event!!!
        public void OnUserEvent()
        {
            if (UserEvent != null)
                UserEvent();

            //UserEvent?.Invoke();
        }
    }

    class UserInfo
    {
        string name;
        string lastName;
        int age;

        public UserInfo(string name, string lastName, int age)
        {
            this.name = name;
            this.lastName = lastName;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public void UserInfoHandler()
        {
            Console.WriteLine("Event was raised!!");
            Console.WriteLine($"{Name} {LastName}, {Age} y.o.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            UserInfo u1 = new UserInfo("Bill", "Gates", 40);
            UserInfo u2 = new UserInfo("Ann", "Simpson", 20);

            evt.UserEvent += u1.UserInfoHandler;
            evt.UserEvent += u2.UserInfoHandler;
            evt.UserEvent += () => Console.WriteLine("Something was happened!!!");

            evt.OnUserEvent();
        }
    }
}
