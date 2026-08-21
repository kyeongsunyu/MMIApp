using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MMI
{
    public class CScanTimer
    {
        private static readonly Stopwatch
            sw = new Stopwatch(); //-- Application이 시작되고 나서부터의 흘러간 시간, static으로 선언되어 아무리 많은수의 타이머를 생성 하더라도 인스턴스는 1개만 생성된다.

        private long pvtime;

        public CScanTimer()
        {
            sw.Start(); //-- 첫번째 타이머가 생성될때 sw가 시작 된다.
        }

        public long Elapsed => sw.ElapsedMilliseconds - pvtime; //-- 타이머가 셋된 시간부터의 흘러간 시간(msec)

        private void Reset()
        {
            pvtime = sw.ElapsedMilliseconds;
        }

        public void SetTime()
        {
            Reset();
        }

        public bool TimeOver(long lTime)
        {
            return Elapsed >= lTime;
        }

        public bool TimeOverSec(long lTime)
        {
            return TimeOver(lTime * 1000);
        }

        public bool Delay(long lTime)
        {
            return TimeOver(lTime);
        }

        public bool DelaySec(long lTime)
        {
            return TimeOverSec(lTime);
        }

        public void TimerCondition(bool c)
        {
            if (!c) Reset();
        }
    }
}
