using System;
using System.Collections.Generic;
using Characteristic;
using Stones;


namespace RevelationStand
{
    //TODO: Нужно реализовать для каждой характеристика один тип. !Возможно
    interface Propertyes
    {

    }


    class Druid
    {
        // 0лвл уровень HP - 360 MP 250
        // Изначально Druid LVL == 1;
        public int Lvl = 1; // TODO: Определить структуру(как отдельный тип)
                            // За каждый лвл дается 72хп и 50мп

        private const float FIRST_LVL_HP = 360.0f;
        private const float FIRST_LVL_MP = 250.0f;
        private const float HP_PER_LVL = 72.0f;
        private const float MP_PER_LVL = 50.0f;
        #region Fields
        
        private Strange _strange;
        private Intellegency _intellegency;
        private Endurancy _endurancy;
        private SpellPower _spellPower;
        private Agility _agility;



        private Speed _speed; //TODO: Забиндить, при описании баф/дебаф. Биндится только на инициализации.
        private HP _hp;
        private MP _mp;
        private Defence _defence;
        private Resist _resist;
        private CriticalChance _criticalChance;




        private Veha _veha;
        private PanelStones _panelStones; //TODO: Разобраться со статой тарелки, куда ставятся камни. У каждого класса они - РАЗНЫЕ.
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
            this._defence = new Defence(100.0f, this._endurancy); //TODO: Тестовая загрушка (100.0f)
            this._resist = new Resist(100.0f, this._spellPower); //TODO: Тестовая загулшка (100.0f)
            this._endurancy.Set += _defence.Set;
            this._spellPower.Set += _resist.Set;
            this._criticalChance = new CriticalChance(this._agility);
            this._agility.ValueChanged += new ValueChanging(_criticalChance.Change);
            this._veha = new Veha();
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

        public Defence Defence
        {
            get => this._defence;
        }

        public Resist Resist
        {
            get => this._resist;
        }

        public Veha Veha
        {
            get => this._veha;
        }

        public CriticalChance CriticalChance
        {
            get => this._criticalChance;
        }
        #endregion
    }
}
