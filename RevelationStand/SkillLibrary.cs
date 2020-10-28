using System;
using System.ComponentModel;

namespace RevelationStand
{

    abstract class Skill : IGetValues
    {
        protected double additionalMinimal;
        protected double additionalMaximal;
        protected double additionalPersent;
        protected double _resultMin;
        protected double _resultMax;

        public double GetMin { get => this._resultMin; }
        public double GetMax { get => this._resultMax; }

        public abstract void Use(double minimal = 0.0d, double maximal = 0.0d, double ragePower = 1.0d, double criticalPower = 1.0d);

    }

    interface IGetValues
    {
        double GetMin { get; }
        double GetMax { get; }
    }





    class SproutsOfLife : Skill // Ростки жизни
    {
        private const double MIN = 298.0d;
        private const double MAX = 365.0d;
        private const double PERSENT = 0.581d;

        public override void Use(double minimal = 0.0d, double maximal = 0.0d, double ragePower = 1.0d, double criticalPower = 1.0d)
        {
            double min = (minimal * additionalPersent + additionalMinimal) * criticalPower;
            double max = (maximal * additionalPersent + additionalMaximal) * criticalPower;
            this._resultMin = min;
            this._resultMax = max;
        }

        public SproutsOfLife(double min, double max)
        {
            this.additionalMinimal = MIN;
            this.additionalMaximal = MAX;
            this.additionalPersent = PERSENT;
            this._resultMin = min;
            this._resultMax = max;
        }

    }

    class ClimbingVines : Skill // Вьющиеся лозы
    {
        private const double MIN = 666.0d;
        private const double MAX = 775.0d;
        private const double PERSENT = 1.233d;

        public override void Use(double minimal = 0.0d, double maximal = 0.0d, double ragePower = 1.0d, double criticalPower = 1.0d)
        {
            double min = (minimal * additionalPersent + additionalMinimal) * criticalPower;
            double max = (maximal * additionalPersent + additionalMaximal) * criticalPower;
            this._resultMin = min;
            this._resultMax = max;
        }

        public ClimbingVines(double min, double max)
        {
            this.additionalMinimal = MIN;
            this.additionalMaximal = MAX;
            this.additionalPersent = PERSENT;
            this._resultMin = min;
            this._resultMax = max;
        }

    }

    class LeafFall : Skill  //Листопад
    {
        private const double MIN = 1742.0d;
        private const double MAX = 2129.0d;
        private const double PERSENT = 3.387d;

        public override void Use(double minimal = 0.0d, double maximal = 0.0d, double ragePower = 1.0d, double criticalPower = 1.0d)
        {
            double min = (minimal * additionalPersent + additionalMinimal) * criticalPower;
            double max = (maximal * additionalPersent + additionalMaximal) * criticalPower;
            this._resultMin = min;
            this._resultMax = max;
        }

        public LeafFall(double min, double max)
        {
            this.additionalMinimal = MIN;
            this.additionalMaximal = MAX;
            this.additionalPersent = PERSENT;
            this._resultMin = min;
            this._resultMax = max;
        }

    }

    class WildBloom : Skill //Буйное цветение
    {
        private const double MIN = 844.0d;
        private const double MAX = 1032.0d;
        private const double PERSENT = 1.643d;

        public override void Use(double minimal = 0.0d, double maximal = 0.0d, double ragePower = 1.0d, double criticalPower = 1.0d)
        {
            double min = (minimal * additionalPersent + additionalMinimal) * criticalPower;
            double max = (maximal * additionalPersent + additionalMaximal) * criticalPower;
            this._resultMin = min;
            this._resultMax = max;
        }

        public WildBloom(double min, double max)
        {
            this.additionalMinimal = MIN;
            this.additionalMaximal = MAX;
            this.additionalPersent = PERSENT;
            this._resultMin = min;
            this._resultMax = max;
        }

    }

    class SpringShower : Skill //Весенний ливень
    {
        private const double MIN = 1001.0d;
        private const double MAX = 1223.0d;
        private const double PERSENT = 1.839d;

        public override void Use(double minimal = 0.0d, double maximal = 0.0d, double ragePower = 1.0d, double criticalPower = 1.0d)
        {
            double min = (minimal * additionalPersent + additionalMinimal) * ragePower * criticalPower;
            double max = (maximal * additionalPersent + additionalMaximal) * ragePower * criticalPower;
            this._resultMin = min;
            this._resultMax = max;
        }

        public SpringShower(double min, double max)
        {
            this.additionalMinimal = MIN;
            this.additionalMaximal = MAX;
            this.additionalPersent = PERSENT;
            this._resultMin = min;
            this._resultMax = max;
        }

    }

    class StreamOfLife : Skill // Поток жизни
    {
        //This skill everytime max lvl.
        private const double MIN = 1264d;
        private const double MAX = 1545d;
        private const double PERSENT = 2.554d;

        public StreamOfLife(double min, double max)
        {
            this.additionalMinimal = MIN;
            this.additionalMaximal = MAX;
            this.additionalPersent = PERSENT;
            this._resultMin = min;
            this._resultMax = max;
        }


        public override void Use(double minimal = 0.0d, double maximal = 0.0d, double ragePower = 1.0d, double criticalPower = 1.0d)
        {
            double min = (minimal * additionalPersent + additionalMinimal) * ragePower * criticalPower;
            double max = (maximal * additionalPersent + additionalMaximal) * ragePower * criticalPower;
            this._resultMin = min;
            this._resultMax = max;
        }

    }

}
