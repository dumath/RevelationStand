using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Characteristic
{

    #region Strange
    public class Strange : INotifyPropertyChanged
    {
        #region Fields
        private float _value; //Основное значение силы
        private Bonus _bonus; //Бонус к характеристике(приходит от гринда)
        private BonusBaseAtt _bonusBaseAtt; // Бонус к базовой силе атаки
        private MinBase _minBase;
        private MaxBase _maxBase;
        private Modifier _modifier;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public Strange(float value)
        {
            this._value = value;
            this._bonus = new Bonus();
            this._bonusBaseAtt = new BonusBaseAtt(_value + _bonus.Value);
            this._minBase = new MinBase(0.0f); //TODO: После добавляения эквипа, переопределить алгоритм расчета
            this._maxBase = new MaxBase(0.0f); //TODO: После добавляения эквипа, переопределить алгоритм расчета
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
        public BonusBaseAtt BonusBaseAtt
        {
            get => this._bonusBaseAtt;
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
        public void Add()
        {
            this._value++;
            OnPropertyChanged(nameof(Value));
            this._modifier.Value++;
            this._bonusBaseAtt.Value = (int)Math.Round(this._value +_bonus.Value) / 10 * 4;
        }

        public void Sub()
        {
            if(this._value != 1.0f)
            {
                this._value--;
                OnPropertyChanged(nameof(Value));
                this._modifier.Value--;
                this._bonusBaseAtt.Value = (int)Math.Round(this._value + _bonus.Value) / 10 * 4;
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
        private float _value;
        private Bonus _bonus;
        public event PropertyChangedEventHandler PropertyChanged;

        public Intellegency(float value)
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

    #region Endurancy
    public class Endurancy : INotifyPropertyChanged
    {
        private float _value;
        private Bonus _bonus;
        public event PropertyChangedEventHandler PropertyChanged;

        public Endurancy(float value)
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

    #region SpellPower
    public class SpellPower : INotifyPropertyChanged
    {
        private float _value;
        private Bonus _bonus;
        public event PropertyChangedEventHandler PropertyChanged;

        public SpellPower(float value)
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

    public class BonusBaseAtt : INotifyPropertyChanged
    {
        #region Fields
        //Каждые 10 единиц силы дают 4% бонуса
        private int _value;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public BonusBaseAtt(float strange)
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

}
