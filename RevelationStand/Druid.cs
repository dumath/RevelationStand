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
        // 0лвл уровень HP - 360 MP 250
        // TODO: Описать харакеристику LVL(Возможна стркутура, небольшой объект бафов нет, наследование не нужно, перегружать операторы не нужно)!!!
        // За каждый лвл дается 72хп и 50мп

        public const float HP_PER_LVL = 72.0f;
        public const float MP_PER_LVL = 50.0f;
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
            this._hp = new HP(360.0f + Druid.HP_PER_LVL, this._endurancy.Value, this._spellPower.Value);
            this._endurancy.Set = _hp.Set;
            this._spellPower.Set = _hp.Set;
            this._mp = new MP(250.0f + Druid.MP_PER_LVL, this._spellPower.Value);
            this._spellPower.Set += _mp.Set;
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
