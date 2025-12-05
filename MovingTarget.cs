using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL
{
    class MovingTarget
    {
        private double _speed = 0; //in m/s
        private double _position = 0;
        public MovingTarget(double speed)
        {
            _speed = speed;
        }

        public double GetPositionAtTime(double timeElapsed)
        {
            double _position = _speed * timeElapsed;
            return _position;
        }

     


    }
}
