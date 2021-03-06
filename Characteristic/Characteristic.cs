﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Characteristic
{

    #region Strange
    public class Strange : INotifyPropertyChanged
    {
        /* Каждая единица силы(основное значение) добавляет + 1 к модификатору, за каждые 10 единиц силы увеличивается бонус
         к базовой силе атаки на 4% */

        #region Fields
        private float _value; //Основное значение силы
        private Bonus _bonus; //Бонус к характеристике(приходит от гринда).
        private BonusBase _bonusBase; // Бонус к базовой силе атаки
        private MinBase _minBase; //TODO: Перенести в класс Druid
        private MaxBase _maxBase; //TODO: Перенести в класс Druid
        private Modifier _modifier; //Модификатор. Прибавляется к минимальной и максимальной базовой, до увеличения Бонусом к силе атаки. Сдвигает интервал Мин - Макс.
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализация объекта. Значение приходит из класса Друид
        /// </summary>
        /// <param name="value">Показатель силы</param>
        public Strange(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
            this._bonusBase = new BonusBase(_value + _bonus.Value);
            this._minBase = new MinBase(0.0f); //TODO: Strange: После добавляения эквипа, переопределить алгоритм расчета
            this._maxBase = new MaxBase(0.0f); //TODO: Strange: После добавляения эквипа, переопределить алгоритм расчета
            this._modifier = new Modifier(this._value + this._bonus.Value);
        }
        #endregion

        #region Propertyes
        // Свойство основной характеристики силы
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        //Свойство Бонуса к основной характеристике
        public Bonus Bonus
        {
            get => this._bonus;
        }

        // Процент увеличения базовой СА мин и макс. Бонус к базовой.
        public BonusBase BonusBase
        {
            get => this._bonusBase;
        }

        // Каждая 1 ед. силы дает 1 очко в модификатор
        public Modifier Modifier
        {
            get => this._modifier;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Добавляем 1 единицу к основновному значению силы и проверяем выражением изменения в проценте к базовой.
        /// </summary>
        public void Add()
        {
            this._value++;
            OnPropertyChanged(nameof(Value));
            this._modifier.Value++;
            this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
        }

        /// <summary>
        /// Убираем 1 очко от основного значения силы и проверяем выражением изменения в проценте к базовой. Не может быть 0 или -1
        /// </summary>
        public void Sub()
        {
            if (this._value != 1.0f)
            {
                this._value--;
                OnPropertyChanged(nameof(Value));
                this._modifier.Value--;
                this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
            }

        }

        ///<summary>
        ///Вносим изменения в интерфейсе
        ///</summary>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
    #endregion

    #region Intellegency
    public class Intellegency : INotifyPropertyChanged
    {
        #region Fields
        private float _value;
        private Bonus _bonus; //Бонус к характеристике(приходит от гринда)
        private BonusBase _bonusBase; // Бонус к базовой силе заклинаний
        private MinBase _minBase;
        private MaxBase _maxBase;
        private Modifier _modifier; //Модификатор
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public Intellegency(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
            this._bonusBase = new BonusBase(_value + _bonus.Value);
            this._minBase = new MinBase(0.0f); //TODO: Intellegency: После добавляения эквипа, переопределить алгоритм расчета
            this._maxBase = new MaxBase(0.0f); //TODO: Intellegency: После добавляения эквипа, переопределить алгоритм расчета
            this._modifier = new Modifier(this._value + this._bonus.Value);
        }
        #endregion

        #region Propertyes
        public virtual float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public Bonus Bonus
        {
            get => this._bonus;
        }

        public BonusBase BonusBase
        {
            get => this._bonusBase;
        }

        public MinBase MinBase
        {
            get => this._minBase;
        }

        public MaxBase MaxBase
        {
            get => this._maxBase;
        }

        public Modifier Modifier
        {
            get => this._modifier;
        }
        #endregion

        #region Methods
        public void Add()
        {
            this._value++;
            OnPropertyChanged(nameof(Value));
            this._modifier.Value++;
            this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
        }


        public void Sub()
        {
            if (this._value != 1.0f)
            {
                this._value--;
                OnPropertyChanged(nameof(Value));
                this._modifier.Value--;
                this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
    #endregion

    #region Endurancy
    public class Endurancy : INotifyPropertyChanged
    {
        /*Каждая единица Выносливости дает 29 единиц ХП, 8 единиц зашиты(модификатор), за 10 единиц Выносливости - 4% к бонусу базовой защиты*/
        public const float HP_PER_ONE_VALUE = 29.0f; // 1 ед Value == HP_PER_VALUE
        public const float DEFENCE_PER_ONE_VALUE = 8.0f; // 1ед Value == DEFENCE_PER_VALUE
        private Set _set; //!!!!БЫТЬ ПРЕДЕЛЬНО ВНИМАТЕЛЬНЫМ С ДАННЫМ ДЕЛЕГАТОМ. НА НЕМ ВИСЯТ МЕТОДЫ ДРУГИХ КЛАССОВ. В ПАРАМЕТРАХ : ВЫН , СД. ПОЗИЦИЮ СОБЛЮДАТЬ.
        #region Fields
        private float _value; //Основная характеристика
        private Bonus _bonus; // Бонус к основной характеристике(дополнительная характеристика)
        private BonusBase _bonusBase; // Бонус за 10 ед VALUE(p.s. 4%)
        public event PropertyChangedEventHandler PropertyChanged; //Отслеживаем изменения и передаем на интерфейс
        #endregion

        #region Constructors
        //Конструктор объекта Выносливость.
        public Endurancy(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
            this._bonusBase = new BonusBase(this._value + this._bonus.Value);
        }
        #endregion

        #region Propertyes
        //Основное свойство значения выносливости
        public virtual float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        //Свойство дополнительной характеристики
        public Bonus Bonus
        {
            get => this._bonus;
        }

        //Свойство бонуса к базовой защите
        public BonusBase BonusBase
        {
            get => this._bonusBase;
        }

        //Свойство делегата, для передачи метода из класса HP, при изменении значения
        public Set Set
        {
            get => this._set;
            set => this._set = value;
        }
        #endregion

        #region Methods
        //Метод добавления 1 единицы характеристики
        public void Add()
        {
            this._value++;
            OnPropertyChanged(nameof(Value));
            this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
            Set(1.0f, 0.0f, BonusBase);
        }

        //Метод убавления 1 единицы характеристики
        public void Sub()
        {
            if (this._value != 1.0f)
            {
                this._value--;
                OnPropertyChanged(nameof(Value));
                this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
                Set(-1.0f, 0.0f, BonusBase);
            }

        }

        //Вызов события , при изменении значения
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
    #endregion

    #region SpellPower
    public class SpellPower : INotifyPropertyChanged
    {
        /* Каждая единица силы духа прибавляет 25 ед к хп, 10 единиц к мп, 1.6f к лечению, 8ед к resist(модификатор?-зайти в игру потестить стат).
           Каждые 10 единиц СД увеличивают реген хп на 1ед(!не понадобится), и дает 4% к бонусу базового resist */
        public const float HP_PER_ONE_VALUE = 25.0f; //1 _value == 25.0f hp
        public const float RESISTANCE_PER_ONE_VALUE = 8.0f; // 1 _value == 8.0f resist
        public const float MP_PER_VALUE = 10.0f; // 1 _value == 10.0f mp
        private Set _set; //!!!!БЫТЬ ПРЕДЕЛЬНО ВНИМАТЕЛЬНЫМ С ДАННЫМ ДЕЛЕГАТОМ. НА НЕМ ВИСЯТ МЕТОДЫ ДРУГИХ КЛАССОВ. В ПАРАМЕТРАХ : ВЫН , СД. ПОЗИЦИЮ СОБЛЮДАТЬ.
        #region Fields
        private float _value; // Основное значение характеристики
        private Bonus _bonus; // Бонус к основному значению от гринда
        private BonusBase _bonusBase; //TODO: Реализовать свойство + механику
        public event PropertyChangedEventHandler PropertyChanged; // Событие интерфейса
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="value"> Значение приходящее от класса Друид</param>
        public SpellPower(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
            this._bonusBase = new BonusBase(this._value);
        }
        #endregion

        #region Propertyes
        //Свойство основного значения
        public virtual float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        //Свойство бонуса к основному значению
        public Bonus Bonus { get => this._bonus; }

        //Свойство бонуса к базовсой СЗ
        public BonusBase BonusBase  { get => this._bonusBase; }
       

        //Свойство делегата. Класс HP и MP зависят от основного значения SP
        public Set Set
        {
            get => this._set;
            set => this._set = value;
        }
        #endregion

        #region Methods
        //Добавляем одну единицу к SP
        public void Add()
        {
            this._value++;
            this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
            OnPropertyChanged(nameof(Value));
            Set(0.0f, 1.0f, _bonusBase);
        }

        //Убавляем одну единицу из SP
        public void Sub()
        {
            if (this._value != 1.0f)
            {
                this._value--;
                this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
                OnPropertyChanged(nameof(Value));
                Set(0.0f, -1.0f, _bonusBase);
            }
        }

        //Вызываем событие UI , при изменении значении SP
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion 
    }
    #endregion

    #region Agility
    public class Agility : INotifyPropertyChanged
    {
        private float _value;
        private Bonus _bonus;
        public event PropertyChangedEventHandler PropertyChanged;
        public event ValueChanging ValueChanged;

        public Agility(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
        }

        public virtual float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public Bonus Bonus
        {
            get => this._bonus;
        }

        public void Add()
        {
            this._value++;
            OnPropertyChanged(nameof(Value));
            if (ValueChanged != null)
                ValueChanged(1.0f);
        }

        public void Sub()
        {
            if(this._value != 1.0f)
            {
                this._value--;
                OnPropertyChanged(nameof(Value));
                if (ValueChanged != null)
                    ValueChanged(-1.0f);
            }
            
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    #endregion

    #region Common classes

    //ВНИМАНИЕ:Класс бонуса к характеристике. Этот класс имеет сходство с бонусом к Силе атаки/ Силе заклинаний. 
    public class Bonus : INotifyPropertyChanged
    {
        private float _value;
        public event PropertyChangedEventHandler PropertyChanged;

        public Bonus()
        {
            this._value = 0;
        }

        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                this.OnPropertyChanged(nameof(Value));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }

    public class BonusBase : INotifyPropertyChanged
    {
        #region Fields
        //Каждые 10 единиц силы дают 4% бонуса
        private int _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public BonusBase(float characteristic)
        {
            this._value = (int)Math.Round(characteristic) / 10 * 4;
        }
        #endregion

        #region Propertyes
        public int Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }

    public class MinBase : INotifyPropertyChanged
    {
        #region Fields
        private float _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public MinBase(float minBase)
        {
            this._value = minBase;
        }
        #endregion

        #region Propertyes
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    } 

    public class MaxBase : INotifyPropertyChanged
    {
        
        #region Fields
        private float _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public MaxBase(float maxBase)
        {
            this._value = maxBase;
        }
        #endregion

        #region Propertyes
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    } 

    public class Modifier : INotifyPropertyChanged
    {
        #region Fields
        private float _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public Modifier(float modifier)
        {
            this._value = modifier;
        }
        #endregion

        #region Propertyes
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                this.OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }
        #endregion

    } 

    #endregion

    #region Other classes
    public class Speed
    {
        private float _value;

        public Speed()
        {
            this._value = 300.0f;
        }

        public float Value
        {
            get => this._value;
        }
    }

    public class HP : INotifyPropertyChanged
    {

        //В структуру не переделывать (!возможно понадобится наследование из за баф).
        #region Fields
        private float _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public HP(float healthPoint, float endurancy, float spellPower)
        {

            this._value = healthPoint + (endurancy * Endurancy.HP_PER_ONE_VALUE) + (spellPower * SpellPower.HP_PER_ONE_VALUE);
        }

        #endregion

        #region Propretyes
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value; //?? добавить или изменить TODO: Переделать(!Возможно. На гетсеттер работает инкримент.)
                OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods

        public void Set(float endurancy, float spellPower, BonusBase bonusBase)
        {
            this._value += (endurancy * Endurancy.HP_PER_ONE_VALUE) + (spellPower * SpellPower.HP_PER_ONE_VALUE);
            OnPropertyChanged(nameof(Value));
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }

    public class MP : INotifyPropertyChanged
    {
        //В структуру не переделывать (!возможно понадобится наследование из за баф).
        #region Fields
        private float _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public MP(float manaPoint, float spellPower)
        {
            this._value = manaPoint + (spellPower * SpellPower.MP_PER_VALUE);
        }
        #endregion

        #region Propretyes
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Метод вызывается при изменении значения силы духа
        /// </summary>
        /// <param name="spellPower">Входящая прибавка к силе духа</param>
        /// <param name="stub">Заглушка(аналог метода адаптера)</param>
        public void Set(float stub, float spellPower, BonusBase bonusBase)
        {
            this._value += spellPower * SpellPower.MP_PER_VALUE;
            OnPropertyChanged(nameof(Value));
        }
        #endregion
    }

    public class Defence : INotifyPropertyChanged
    {
        /*Класс защиты */
        #region Fields
        private float _value; //Общая защита
        private float _base; //TODO: Переделать в отдельный класс//Базовая защита
        private Modifier _modifier; //Модификатор защиты
        private float _persentDefence; //TODO:Процент уменьшение физ урона: Определить методы , свойства, разметку (!зависит от общей защиты) 
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public Defence(float baseDefence, Endurancy endurancy)
        {
            this._modifier = new Modifier(Endurancy.DEFENCE_PER_ONE_VALUE * endurancy.Value);
            this._base = baseDefence;
            this._value = _base * Calculate.CalculatePersentBonus(endurancy.BonusBase) + this._modifier.Value;
        }
        #endregion

        #region Propertyes
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public Modifier Modifier
        {
            get => this._modifier;
        }

        public float Base
        {
            get => this._base;
            set
            {
                this._base = value;
                OnPropertyChanged(nameof(Base));
            }
        }
        #endregion

        #region Methods
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Set(float endurancy, float spellPower, BonusBase bonusBase)
        {
            if(endurancy != 0.0f)
            {
                this._modifier.Value += endurancy * Endurancy.DEFENCE_PER_ONE_VALUE;
                this._value = this._base * Calculate.CalculatePersentBonus(bonusBase) + this._modifier.Value;
                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(Base));
            }
            
        }
        #endregion
    }

    public class Resist : INotifyPropertyChanged
    {
        #region Fields
        private float _value;
        private float _base;
        private Modifier _modifier;
        private float _persentResist; //TODO:Процент уменьшение маг урона: Определить методы , свойства, разметку (!зависит от общего сопротивления) 
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public Resist(float baseResist, SpellPower spellPower)
        {
            this._base = baseResist;
            this._modifier = new Modifier(spellPower.Value * SpellPower.RESISTANCE_PER_ONE_VALUE);
            this._value = this._base * Calculate.CalculatePersentBonus(spellPower.BonusBase) + this._modifier.Value;
        }
        #endregion

        #region Propertyes
        //Свойство Общего сопротивления
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                this.OnPropertyChanged(nameof(Value));
            }
        }

        //Свойство базового сопротивления
        public float Base
        {
            get => this._base;
            set
            {
                this._base = value;
                this.OnPropertyChanged(nameof(Base));
            }
        }

        //Свойство Модификатора сопротивления
        public Modifier Modifier { get => this._modifier; }
        #endregion

        #region Methods
        public void Set(float endurancy, float spellPower, BonusBase bonusBase)
        {
            if(spellPower != 0)
            {
                this._modifier.Value += spellPower * SpellPower.RESISTANCE_PER_ONE_VALUE;
                this._value = this._base * Calculate.CalculatePersentBonus(bonusBase) + this._modifier.Value;
                this.OnPropertyChanged(nameof(Value));
                this.OnPropertyChanged(nameof(Modifier));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }

    public class CriticalChance : INotifyPropertyChanged
    {
        //Класс - Вероятность нанесения критического удара
        #region Fields
        private float _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public CriticalChance(Agility value)
        {
            this._value = value.Value * 2.0f;
        }
        #endregion

        #region Propertyes
        public float Value
        {
            get => _value;
            set
            {
                this._value = value;
                this.OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods
        public void Change(float value)
        {
            this._value += value*2.0f;
            OnPropertyChanged(nameof(Value));
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }


    public class Veha : INotifyPropertyChanged
    {
        //Данная ветвь реализуется последней(нет инфы по механике: модификатор/базовая/общая)
        private bool _imperial;
        private bool _oro;
        private bool _akari;
        private bool _kuromi;
        private bool _ren;
        private bool _atum;
        public event PropertyChangedEventHandler PropertyChanged;


        #region Propertyes
        public bool Imperial
        {
            get => _imperial;
            set
            {
                this._imperial = value;
                this.OnPropertyChanged(nameof(Imperial));
            }
        }

        public bool Oro
        {
            get => _oro;
            set
            {
                this._oro = value;
                this.OnPropertyChanged(nameof(Oro));
            }
        }

        public bool Akari
        {
            get => _akari;
            set
            {
                this._akari = value;
                this.OnPropertyChanged(nameof(Akari));
            }
        }

        public bool Kuromi
        {
            get => _kuromi;
            set
            {
                this._kuromi = value;
                this.OnPropertyChanged(nameof(Kuromi));
            }
        }

        public bool Ren
        {
            get => _ren;
            set
            {
                this._ren = value;
                this.OnPropertyChanged(nameof(Ren));
            }
        }

        public bool Atum
        {
            get => _atum;
            set
            {
                this._atum = value;
                this.OnPropertyChanged(nameof(Atum));
            }
        }
        #endregion

        #region Methods
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }


    public delegate void Set(float endurancy, float spellPower, BonusBase bonusBase);
    public delegate void ValueChanging(float value);

    //Класc-контейнер методов расчета/расширений
    public static class Calculate
    {
        static Calculate() { }
        


        //Метод инкремента базовой сз/са
        public static float CalculatePersentBonus(BonusBase bonusBase)
        {
            return (float)bonusBase.Value / 100 + 1;
        }
    }
    #endregion


}
