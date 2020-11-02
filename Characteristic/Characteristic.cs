using System;
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
        private MinBase _minBase;
        private MaxBase _maxBase;
        private Modifier _modifier; //Модификатор. Прибавляется к минимальной и максимальной базовой, до увеличения Бонусом к силе атаки. Сдвигает интервал Мин - Макс.
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
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
        /// <summary>
        /// Свойство основной характеристики силы
        /// </summary>
        public float Value
        {
            get => this._value;
            set
            {
                this._value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        /// <summary>
        /// Бонус к характеристике
        /// </summary>
        public Bonus Bonus
        {
            get => this._bonus;
        }

        /// <summary>
        /// Процент увеличения базовой СА мин и макс. Бонус к базовой.
        /// </summary>
        public BonusBase BonusBase
        {
            get => this._bonusBase;
        }

        /// <summary>
        /// Каждая 1 ед. силы дает 1 очко в модификатор
        /// </summary>
        public Modifier Modifier
        {
            get => this._modifier;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Добавляем 1 единицу к основновному значению силы
        /// </summary>
        public void Add()
        {
            this._value++;
            OnPropertyChanged(nameof(Value));
            this._modifier.Value++;
            this._bonusBase.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
        }

        /// <summary>
        /// Убираем 1 очко от основного значения силы. Не может быть 0 или -1
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

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        private Set _set;
        #region Fields
        private float _value; //Основная зарактеристика
        private Bonus _bonus; // Бонус к основной характеристике
        private BonusBase _bonusBase; // Бонус за 10 ед VALUE(p.s. 4%)
        public event PropertyChangedEventHandler PropertyChanged; //Отслеживаем изменения и передаем на интерфейс
        #endregion

        #region Constructors
        //Конструктор объекта Выносливость. Активный. Пассивный отсутствует.
        public Endurancy(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
            this._bonusBase = new BonusBase(this._value + this._bonus.Value);
        }
        #endregion

        #region Propertyes
        //Основное свойсто значения выносливости
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
            this._set(1.0f, 0.0f);
        }

        //Метод убавления 1 единицы характеристики
        public void Sub()
        {
            if (this._value != 1.0f)
            {
                this._value--;
                OnPropertyChanged(nameof(Value));
                Set(-1.0f, 0.0f);
            }

        }

        //Вызов события , при изменении значения
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    #endregion

    #region SpellPower
    public class SpellPower : INotifyPropertyChanged
    {
        public const float HP_PER_ONE_VALUE = 25.0f;
        public const float RESISTANCE_PER_ONE_VALUE = 8.0f;
        public const float MP_PER_VALUE = 10.0f;
        private Set _set;
        #region Fields
        private float _value;
        private Bonus _bonus;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public SpellPower(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
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

        public Set Set
        {
            get => this._set;
            set => this._set = value;
        }
        #endregion

        #region Methods
        public void Add()
        {

            this._value++;
            OnPropertyChanged(nameof(Value));
            Set(0.0f, 1.0f);



        }

        public void Sub()
        {
            if (this._value != 1)
            {
                this._value--;
                OnPropertyChanged(nameof(Value));
                Set(0.0f, -1.0f);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        }

        public void Sub()
        {
            this._value--;
            OnPropertyChanged(nameof(Value));
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        public BonusBase(float strange)
        {
            this._value = (int)Math.Round(strange) / 10 * 4;
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
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
                OnPropertyChanged(nameof(Value));
            }
        }
        #endregion

        #region Methods
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        public void Set(float endurancy = 0.0f, float spellPower = 0.0f)
        {
            this._value += (endurancy * Endurancy.HP_PER_ONE_VALUE) + (spellPower * SpellPower.HP_PER_ONE_VALUE);
            OnPropertyChanged(nameof(Value));
        }


        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Метод вызывается при изменении значения силы духа
        /// </summary>
        /// <param name="spellPower">Входящая прибавка к силе духа</param>
        /// <param name="stub">Заглушка(аналог метода адаптера)</param>
        public void Set(float stub = 0, float spellPower = 0)
        {
            this._value += spellPower * SpellPower.MP_PER_VALUE;
            OnPropertyChanged(nameof(Value));
        }
        #endregion
    }
    #endregion

    public delegate void Set(float valueOne, float valueTwo);
}
