using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GameProj.Models;
using GameProj.Repo;

namespace GameProj.View
{
    class ViewAdditional : DependencyObject
    {
     
        public ViewAdditional()
        {
            ItemsSortRate = CollectionViewSource.GetDefaultView(_dev.DevRate());
            ItemsLan = CollectionViewSource.GetDefaultView(_dev.GetAll().Select(d => d.LNG).Distinct());
            ItemsProjects = CollectionViewSource.GetDefaultView(_game.GetAllProject());
        }

        public ViewAdditional(string lan)
        {
            ItemsDevSalary = CollectionViewSource.GetDefaultView(_dev.SelectLan(lan).OrderByDescending(n=>n.SALARY_DVLP));
        }

        #region All

        private readonly DevRepo _dev = new DevRepo();
        public ICollectionView ItemsSortRate
        {
            get => (ICollectionView)GetValue(MyPropertyProperty);
            set => SetValue(MyPropertyProperty, value);
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("SortRate", typeof(ICollectionView), typeof(ViewAdditional), new PropertyMetadata(null));

        public ICollectionView ItemsDevSalary
        {
            get => (ICollectionView)GetValue(MyPropertyPropert);
            set => SetValue(MyPropertyPropert, value);
        }

        public static readonly DependencyProperty MyPropertyPropert =
            DependencyProperty.Register("SortSalary", typeof(ICollectionView), typeof(ViewAdditional), new PropertyMetadata(null));


        public ICollectionView ItemsLan
        {
            get => (ICollectionView)GetValue(ItemsLanProperty);
            set => SetValue(ItemsLanProperty, value);
        }

        public static readonly DependencyProperty ItemsLanProperty =
            DependencyProperty.Register("LanItems", typeof(ICollectionView), typeof(ViewAdditional), new PropertyMetadata(null));


        private readonly GameRepo _game = new GameRepo();

        public ICollectionView ItemsProjects
        {
            get => (ICollectionView)GetValue(ItemsProjectsProperty);
            set => SetValue(ItemsProjectsProperty, value);
        }

        public static readonly DependencyProperty ItemsProjectsProperty =
            DependencyProperty.Register("ProjItems", typeof(ICollectionView), typeof(ViewAdditional), new PropertyMetadata(null));

        #endregion

    }
}
