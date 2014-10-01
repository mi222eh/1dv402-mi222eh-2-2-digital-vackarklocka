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
                if (CheckHour(value) == false)
                {
                    throw new ArgumentException();
                }
            }
        }

        private bool CheckHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                return false;
            }
            return true;
        }
        private bool CheckMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                return false;
            }
            return true;
        }

        public bool TickTock()
        {
            throw new NotImplementedException();
        }
    }
}
