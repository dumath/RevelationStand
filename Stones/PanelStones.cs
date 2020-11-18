using System;
using System.Collections.Generic;
using System.ComponentModel;
using Stones;


namespace Stones
{
    public class PanelStones
    {
        #region Feilds
        /* Цифра в названии поля, должна соответствовать ( по часам) в XAML */

        //Небесный круг
        private SkyRing _elevenSky;
        private SkyRing _oneSky;
        private SkyRing _twoSky;
        private SkyRing _fourSky;
        private SkyRing _fiveSky;
        private SkyRing _sevenSky;
        private SkyRing _eigthSky;
        private SkyRing _tenSky;

        //Земной круг
        private GroundRing _elevenGround;
        private GroundRing _oneGround;
        private GroundRing _fiveGround;
        private GroundRing _sevenGround;
        #endregion

        #region Proprtyes
        //TODO: Переделать. Создано рефакторингом.
        internal SkyRing ElevenSky { get => _elevenSky; set => _elevenSky = value; }
        internal SkyRing OneSky { get => _oneSky; set => _oneSky = value; }
        internal SkyRing TwoSky { get => _twoSky; set => _twoSky = value; }
        internal SkyRing FourSky { get => _fourSky; set => _fourSky = value; }
        internal SkyRing FiveSky { get => _fiveSky; set => _fiveSky = value; }
        internal SkyRing SevenSky { get => _sevenSky; set => _sevenSky = value; }
        internal SkyRing EigthSky { get => _eigthSky; set => _eigthSky = value; }
        internal SkyRing TenSky { get => _tenSky; set => _tenSky = value; }

        internal GroundRing ElevenGround { get => _elevenGround; set => _elevenGround = value; }
        internal GroundRing OneGround { get => _oneGround; set => _oneGround = value; }
        internal GroundRing FiveGround { get => _fiveGround; set => _fiveGround = value; }
        internal GroundRing SevenGround { get => _sevenGround; set => _sevenGround = value; }
        #endregion

    }
}
