using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Characteristic;

namespace RevelationStand
{
    //TODO: Нужно реализовать для каждой характеристика один тип. !Возможно
    interface Propertyes
    {

    }


    class Druid
    {
        #region Fields
        private Strange _strange;
        private Intellegency _intellegency;
        private Endurancy _endurancy;
        private SpellPower _spellPower;
        private Agility _agility;
        private Speed _speed; //TODO: Забиндить, при описании баф/дебаф. Биндится только на инициализации.
        private HP _hp;
        private MP _mp;
        
        #endregion

        #region Constructors
        public Druid()
        {
            this._strange = new Strange(1.0f);
            this._intellegency = new Intellegency(2.0f);
            this._endurancy = new Endurancy(2.0f);
            this._spellPower = new SpellPower(2.0f);
            this._agility = new Agility(1.0f);
            this._speed = new Speed();
            this._hp = new HP(540.0f);
            this._mp = new MP(320.0f);
        }
        #endregion

        #region Propertyes of characteristics
        public Strange Strange
        {
            get => this._strange;
        }

        public Intellegency Intellegency
        {
            get => this._intellegency;
        }

        public Endurancy Endurancy
        {
            get => this._endurancy;
        }

        public SpellPower SpellPower
        {
            get => this._spellPower;
        }

        public Agility Agility
        {
            get => this._agility;
        }

        public Speed Speed
        {
            get => this._speed;
        }

        public HP HP
        {
            get => this._hp;
        }

        public MP MP
        {
            get => this._mp;
        }


        #endregion
    }
}
