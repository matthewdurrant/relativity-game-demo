using RelativityDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Oasis1
{
    public static class TimeDilationCalculator
    {
        private const double c = 1;

        /// <summary>
        /// The time interval measured by a stationary observer.
        /// E.g. if 3 years passes for someone in a spaceship travelling at 0.25c,
        /// how much time passes on Earth?
        /// </summary>
        public static TimeSpan GetCoordinateTime(TimeSpan properTime, double relativeVelocityC)
        {
            long pt = properTime.Ticks;
            double factor = CalculateFactorFromVelocity(relativeVelocityC, c);
            double ct = pt / factor;
            return TimeSpan.FromTicks(Convert.ToInt64(ct));
        }

        /// <summary>
        /// The time interval measured by a moving observer.
        /// E.g. if 3 years passes on Earth, how many years pass for
        /// someone on a spaceship travelling at 0.25c?
        /// </summary>
        public static TimeSpan GetProperTime(TimeSpan coordinateTime, float relativeVelocityC)
        {
            long ct = coordinateTime.Ticks;
            double factor = CalculateFactorFromVelocity(relativeVelocityC, c);
            double pt = ct * factor;
            return TimeSpan.FromTicks(Convert.ToInt64(pt));
        }

        /// <summary>
        /// The velocity, as a fraction of c, that the moving observer is moving at.
        /// E.g. how fast do I need to go so that 4 years on earth is 3 years for me?
        /// </summary>
        public static double GetRelativeVelocity(TimeSpan properTime, TimeSpan coordinateTime)
        {
            double factor = CalculateFactorFromTime(properTime, coordinateTime);
            double factorSq = Math.Pow(factor, 2); //0.93749999999999967
            double βSq = 1 - factorSq; //0.062500000000000333
            double β = Math.Sqrt(βSq);
            double velocity = β * c;
            return velocity;
        }

        public static double CalculateFactorFromVelocity(double relativeVelocityC, double _c)
        {
            double β = relativeVelocityC / _c; //0.25.
            double βSq = Math.Pow(β, 2); //0.0625
            double factorSq = 1 - βSq; //0.9375

            if (factorSq > 0)
            {
                double factor = Math.Sqrt(factorSq); //0.96824583655185426
                return factor;
            }
            else
            {
                Complex complexSqrt = Complex.Sqrt(factorSq);
                return 0 - complexSqrt.Imaginary; //????
                //Uh-oh, we are going faster than light.
                //throw new Exception("You cannot travel faster than light.");
            }
        }

        public static double CalculateFactorFromTime(TimeSpan properTime, TimeSpan coordinateTime)
        {
            double pt = properTime.Ticks;
            double ct = coordinateTime.Ticks;
            double factor = pt / ct; //0.968245836551854
            return factor;
        }

        /// <summary>
        /// A lot could go into this. But ideally, help a pilot work out a decent speed that's neither too fast nor too slow.
        /// A journey  time between 1 month and 1 year.
        /// </summary>
        public static (double minV, double maxV) GetRecommendedMinMaxVelocity(float distanceLy)
        {
            TimeSpan minTimeSpan = TimeSpan.FromDays(30);
            TimeSpan maxTimeSpan = TimeSpan.FromDays(365);

            TimeSpan coordinateJourneyTime = TimeSpan.FromDays(distanceLy * 365);

            double minV = GetRelativeVelocity(maxTimeSpan, coordinateJourneyTime);
            double maxV = GetRelativeVelocity(minTimeSpan, coordinateJourneyTime);
            return (minV, maxV);
        }
    }
}
