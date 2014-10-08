using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock
{
    class AlarmClock
    {
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;

        public AlarmClock() : this(0,0)
        {
            //Ät lite nudlar...
        }
        public AlarmClock(int hour, int minute) : this(hour,minute,0,0)
        {
            // ...med köttbullar, det är gott.
        }
        public AlarmClock(int hour, int minute, int alarmhour, int alarmminute)
        {
            //Tilldela värden som togs emot
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmhour;
            AlarmMinute = alarmminute;
        }
        public int AlarmHour
        {
            get { return _alarmHour; }
            set 
            {
                if (CheckHour(value) == false)
                {
                    throw new ArgumentException();
                }                    
               _alarmHour = value; 
            }
        }

        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set{
                if (CheckMinute(value) == false)
                {
                    throw new ArgumentException();
                }
                _alarmMinute = value;
            }
        }
        public int Hour
        {
            get { return _hour;}
            set
            {
                if (CheckHour(value) == false)
                {
                    throw new ArgumentException();
                }
                _hour = value;
            }
        }
        public int Minute
        {
            get { return _minute;}
            set
            {
                if (CheckMinute(value) == false)
                {
                    throw new ArgumentException();
                }
                _minute = value;
            }
        }

        private bool CheckHour(int hour)
        {
            //Kontrollerar intervallen på timmen...
            if (hour < 0 || hour > 23)
            {
                return false;
            }
            return true;
        }
        private bool CheckMinute(int minute)
        {
            //Kontrollerar intervallen på minuten...
            if (minute < 0 || minute > 59)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            //deklarera variabel till strängen
            string timeToText;  
         
            //Lagra sträng beroende av olika formfaktorer (ensiffriga minuter ska ha en nolla framför sig)...
            timeToText = string.Format("          {0,2}:{1}{2}   ({3}:{4}{5})",_hour,(_minute < 10? "0":""),_minute, _alarmHour,(_alarmMinute < 10? "0":""), _alarmMinute);
            
            return timeToText;
        }

        public bool TickTock()
        {
            //undersök minuten...
            if (_minute + 1 > 59)
            {
                Minute = 0;
                if (_hour + 1 > 23)
                {
                    Hour = 0;
                }
                else
                {
                    Hour++;
                }
            }
            else
            {
                Minute++;
            }
            if (_hour == _alarmHour && _minute == _alarmMinute)
            {
                return true;
            }
            return false;
        }
    }
}
