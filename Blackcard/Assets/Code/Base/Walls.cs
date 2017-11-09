using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Base
{
    [Serializable]
    public class Walls
    {
        public bool leftBlocked;
        public bool topBlocked;
        public bool rightBlocked;
        public bool bottomBlocked;

        public void Turn(bool left)
        {
            bool a = leftBlocked;
            if (left)
            {
                leftBlocked = topBlocked;
                topBlocked = rightBlocked;
                rightBlocked = bottomBlocked;
                bottomBlocked = a;
            }
            else
            {
                leftBlocked = bottomBlocked;
                bottomBlocked = rightBlocked;
                rightBlocked = topBlocked;
                topBlocked = a;
            }
        }
    }
}
