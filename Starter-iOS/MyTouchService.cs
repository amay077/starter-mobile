using System;
using StarterCorePcl;

namespace Starter
{
    public class MyTouchService : IMyService
    {
        public int Calc(int x, int y)
        {
            return x + y;
        }
    }
}

