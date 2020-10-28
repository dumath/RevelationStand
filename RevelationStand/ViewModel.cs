using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevelationStand
{
    class ViewModel
    {
        private Druid _druid;

        public ViewModel()
        {
            _druid = new Druid();
        }

        public Druid Druid
        {
            get => this._druid;
        }
    }
}
