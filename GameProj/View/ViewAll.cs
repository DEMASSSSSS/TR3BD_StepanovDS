using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GameProj.Models;

namespace GameProj.View
{
    class ViewAll : DependencyObject
    {

        public ViewAll()
        {
            Items = CollectionViewSource.GetDefaultView(_dev.GetAll());
            ItemsTeams = CollectionViewSource.GetDefaultView(_devTeams.GetAll().Select(n=>new{n.TEAM_DVLP_ID,n.NAME}));
            GameItems = CollectionViewSource.GetDefaultView(_game.GetAll());
            GameItemsManager = CollectionViewSource.GetDefaultView(_man.GetAll().Select(n=>new{n.MANAGER_ID,n.FIO_MNG}));
            ManagerItems = CollectionViewSource.GetDefaultView(_man.GetAll());
            ArtistItems = CollectionViewSource.GetDefaultView(_artist.GetAll());
            ArtistTeamItems = CollectionViewSource.GetDefaultView(_artistTeam.GetAll().Select(n => new{n.TEAM_ARTST_ID,n.NAME}));
        }


        #region Developer
        private readonly BaseRepo<DEVELOPER> _dev = new BaseRepo<DEVELOPER>();
        private readonly BaseRepo<TEAM_DVLP> _devTeams = new BaseRepo<TEAM_DVLP>();

        public ICollectionView Items
        {
            get => (ICollectionView)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(ViewAll), new PropertyMetadata(null));

        public ICollectionView ItemsTeams
        {
            get => (ICollectionView)GetValue(ItemsTeamsProperty);
            set => SetValue(ItemsTeamsProperty, value);
        }

  
        public static readonly DependencyProperty ItemsTeamsProperty =
            DependencyProperty.Register("ItemsTeams", typeof(ICollectionView), typeof(ViewAll), new PropertyMetadata(null));

        #endregion

        #region Game

        private readonly BaseRepo<GAME> _game = new BaseRepo<GAME>();
        private readonly BaseRepo<MANAGER> _man = new BaseRepo<MANAGER>();

        public ICollectionView GameItems
        {
            get => (ICollectionView)GetValue(GameItemsProperty);
            set => SetValue(GameItemsProperty, value);
        }

        public static readonly DependencyProperty GameItemsProperty =
            DependencyProperty.Register("GameItems", typeof(ICollectionView), typeof(ViewAll), new PropertyMetadata(null));

        public ICollectionView GameItemsManager
        {
            get => (ICollectionView)GetValue(ItemsGameManagerProperty);
            set => SetValue(ItemsGameManagerProperty, value);
        }


        public static readonly DependencyProperty ItemsGameManagerProperty =
            DependencyProperty.Register("GameManager", typeof(ICollectionView), typeof(ViewAll), new PropertyMetadata(null));

        #endregion

        #region Manager

        public ICollectionView ManagerItems
        {
            get => (ICollectionView)GetValue(ManagerItemsProperty);
            set => SetValue(ManagerItemsProperty, value);
        }

        public static readonly DependencyProperty ManagerItemsProperty =
            DependencyProperty.Register("ManagerItems", typeof(ICollectionView), typeof(ViewAll), new PropertyMetadata(null));

        #endregion

        #region Artist
        private readonly BaseRepo<ARTIST> _artist = new BaseRepo<ARTIST>();
        private readonly BaseRepo<TEAM_ARTST> _artistTeam = new BaseRepo<TEAM_ARTST>();

        public ICollectionView ArtistItems
        {
            get => (ICollectionView)GetValue(ArtistItemsProperty);
            set => SetValue(ArtistItemsProperty, value);
        }

        public static readonly DependencyProperty ArtistItemsProperty =
            DependencyProperty.Register("ArtistItems", typeof(ICollectionView), typeof(ViewAll), new PropertyMetadata(null));

        public ICollectionView ArtistTeamItems
        {
            get => (ICollectionView)GetValue(ArtistTeamItemsProperty);
            set => SetValue(ArtistTeamItemsProperty, value);
        }

        public static readonly DependencyProperty ArtistTeamItemsProperty =
            DependencyProperty.Register("ArtistTeamItems", typeof(ICollectionView), typeof(ViewAll), new PropertyMetadata(null));

        #endregion
    }
}
