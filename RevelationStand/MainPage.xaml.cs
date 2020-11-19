using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace RevelationStand
{
    
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region XAML ADDITIONAL FIELDS
        private ViewModel view;
        #endregion

        #region Constructor of Main Page
        public MainPage()
        {
            try
            {
                this.InitializeComponent();
                view = new ViewModel(ViewModel.CharacterClass.Druid);
                DataContext = view;
                lvl.Text =$"Уровень: {view.Druid.Lvl.ToString()}";

            }
            catch(Exception ex)
            {
                MessageDialog message = new MessageDialog(ex.Message);
                message.ShowAsync();
            }
             
        }
        #endregion

        #region EventHandler
        private void add_click(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;

                if (sender != null)
                {
                    switch (button.Name)
                    {
                        case "addStrange":
                            this.view.Druid.Strange.Add();
                            break;
                        case "addIntellegency":
                            this.view.Druid.Intellegency.Add();
                            break;
                        case "addEndurancy":
                            this.view.Druid.Endurancy.Add();
                            break;
                        case "addSpellPower":
                            this.view.Druid.SpellPower.Add();
                            break;
                        case "addAgility":
                            this.view.Druid.Agility.Add();
                            break;
                        default: throw new ArgumentException("Wrong Name");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageDialog message = new MessageDialog(ex.Message);
                message.ShowAsync();
            }

            
        }

        private void sub_click(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;

                if (sender != null)
                {
                    switch (button.Name)
                    {
                        case "subStrange":
                            this.view.Druid.Strange.Sub();
                            break;
                        case "subIntellegency":
                            this.view.Druid.Intellegency.Sub();
                            break;
                        case "subEndurancy":
                            this.view.Druid.Endurancy.Sub();
                            break;
                        case "subSpellPower":
                            this.view.Druid.SpellPower.Sub();
                            break;
                        case "subAgility":
                            this.view.Druid.Agility.Sub();
                            break;
                        default: throw new ArgumentException("Wrong Name");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageDialog message = new MessageDialog(ex.Message);
                message.ShowAsync();
            }
            
        }

        private void Selected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (navButtons != null)
                {
                    switch (navButtons.SelectedIndex) //TODO: Переделать в простое : Временная заглушка
                    {
                        case 0:
                            characteristicGrid.Visibility = Visibility.Visible;
                            armorGrid.Visibility = Visibility.Collapsed;
                            vehaGrid.Visibility = Visibility.Collapsed;
                            stoneGrid.Visibility = Visibility.Collapsed;
                            skillGrid.Visibility = Visibility.Collapsed;
                            break;
                        case 1:
                            characteristicGrid.Visibility = Visibility.Collapsed;
                            armorGrid.Visibility = Visibility.Visible;
                            vehaGrid.Visibility = Visibility.Collapsed;
                            stoneGrid.Visibility = Visibility.Collapsed;
                            skillGrid.Visibility = Visibility.Collapsed;
                            break;
                        case 2:
                            characteristicGrid.Visibility = Visibility.Collapsed;
                            armorGrid.Visibility = Visibility.Collapsed;
                            vehaGrid.Visibility = Visibility.Visible;
                            stoneGrid.Visibility = Visibility.Collapsed;
                            skillGrid.Visibility = Visibility.Collapsed;
                            break;
                        case 3:
                            characteristicGrid.Visibility = Visibility.Collapsed;
                            armorGrid.Visibility = Visibility.Collapsed;
                            vehaGrid.Visibility = Visibility.Collapsed;
                            stoneGrid.Visibility = Visibility.Visible;
                            skillGrid.Visibility = Visibility.Collapsed;
                            break;
                        case 4:
                            characteristicGrid.Visibility = Visibility.Collapsed;
                            armorGrid.Visibility = Visibility.Collapsed;
                            vehaGrid.Visibility = Visibility.Collapsed;
                            stoneGrid.Visibility = Visibility.Collapsed;
                            skillGrid.Visibility = Visibility.Visible;
                            break;
                        default: throw new InvalidOperationException("Not selected : Method Selected : ListView ");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageDialog message = new MessageDialog(ex.Message + " :Method Selected()");
                message.ShowAsync();
            }

        }
        #endregion
    }
}
