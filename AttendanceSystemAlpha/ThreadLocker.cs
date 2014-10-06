using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceSystemAlpha
{
    public static class ThreadLocker
    {
        public static readonly object CallingBriefcaseLocker = new object();
    }
}
