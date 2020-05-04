using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameProj.Models;
using GameProj.Repo;
using GameProj.View;

namespace GameProj
{
    public partial class MainWindow : Window
    {
        private readonly DevRepo _devRepo = new DevRepo();
        private readonly GameRepo _gameRepo = new GameRepo();
        private readonly ManRepo _manRepo = new ManRepo();
        private readonly ArtRepo _artRepo = new ArtRepo();

        public MainWindow() => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            var debView = new ViewAll();
        }

        private void Update()
        {
            var debView = new ViewAll();
            MainDataGrid.ItemsSource = debView.Items;
            GameDataGrid.ItemsSource = debView.GameItems;
            ManColumn.ItemsSource = debView.GameItemsManager;
            ManagerDataGrid.ItemsSource = debView.ManagerItems;
            ArtDataGrid.ItemsSource = debView.ArtistItems;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new GameDataBase())
                {
                    switch (TabControl.SelectedIndex)
                    {
                        case 0:
                            db.DEVELOPERs.Remove(db.DEVELOPERs.Find(((DEVELOPER) MainDataGrid.SelectedItem).DVLP_ID));
                            break;
                        case 1:
                            db.GAMES.Remove(db.GAMES.Find(((GAME) GameDataGrid.SelectedItem).ID_GAMES));
                            break;
                        case 2:
                            db.MANAGERs.Remove(db.MANAGERs.Find(((MANAGER) ManagerDataGrid.SelectedItem).MANAGER_ID));
                            break;
                        case 3:
                            db.ARTISTs.Remove(db.ARTISTs.Find(((ARTIST) ArtDataGrid.SelectedItem).ARTST_ID));
                            break;
                    }

                    db.SaveChanges();
                }

                Update();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Конфликт инструкции DELETE с ограничением REFERENCE", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception) { }
        }

        private void MainDataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    _devRepo.DevUpdate(e.Row.Item as DEVELOPER);
                    break;
                case 1:
                    _gameRepo.GameUpdate(e.Row.Item as GAME);
                    break;
                case 2:
                    _manRepo.ManUpdate(e.Row.Item as MANAGER);
                    break;
                case 3:
                    _artRepo.ArtUpdate(e.Row.Item as ARTIST);
                    break;
            }
        }


        private void MainDataGrid_OnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                switch (TabControl.SelectedIndex)
                {
                    case 0:
                        var dev = e.Row.Item as DEVELOPER;
                        if (dev.DVLP_ID == 0)
                            _devRepo.Add(dev);
                        break;
                    case 1:
                        var game = e.Row.Item as GAME;
                        if (game.ID_GAMES == 0)
                            _gameRepo.Add(game);
                        break;
                    case 2:
                        var man = e.Row.Item as MANAGER;
                        if (man.MANAGER_ID == 0)
                            _manRepo.Add(man);
                        break;
                    case 3:
                        var art = e.Row.Item as ARTIST;
                        if (art.ARTST_ID == 0)
                            _artRepo.Add(art);
                        break;
                }
                Update();
            }
            catch { }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) => Close();

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var add = new AddWindow(3);
            add.Show();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var add = new AddWindow(2);
            add.Show();
        }

        private void MenuItem_OnClick2(object sender, RoutedEventArgs e)
        {
            var add = new AddWindow(1);
            add.Show();
        }
    }
}
