using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelationStand
{
    class ViewModel
    {
        public enum CharacterClass { Druid, Warrior, Defender, Reaper, Wizard, Assasin, Gunner }

        private Druid _druid;
        /*private Warrior warrior;
        private Defender defender;
        private Reaper reaper;
        private Wizard wizard;
        private Assasin assasin;
        private Gunner gunner;*/

        public ViewModel( CharacterClass characterClass)
        {
            switch(characterClass)
            {
                case CharacterClass.Druid:
                    _druid = new Druid();
                    break;
                default: break;
            }
            
        }

        //TODO: ADD class character / Command
        public Druid Druid
        {
            get => this._druid;
        }
    }
}
