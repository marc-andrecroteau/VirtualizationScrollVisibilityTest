using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using AlphaChiTech.Virtualization;

namespace VirtualizationScrollVisibilityTest
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {

        #region Fields

        private VirtualizingObservableCollection<ObjectTestViewModel> _ObjectTestHeightVirtualizingObservableCollection;
        private VirtualizingObservableCollection<ObjectTestViewModel> _ObjectTestVirtualizingObservableCollection;

        #endregion

        #region Properties

        private ICollectionView _ObjectTestCollectionView;
        public ICollectionView ObjectTestCollectionView

        {
            get
            {
                if (_ObjectTestCollectionView == null)
                    CreateObjectTestCollectionView();

                return _ObjectTestCollectionView;
            }
        }

        private ICollectionView _ObjectTestHeightCollectionView;
        public ICollectionView ObjectTestHeightCollectionView

        {
            get
            {
                if (_ObjectTestHeightCollectionView == null)
                    CreateObjectTestHeightCollectionView();

                return _ObjectTestHeightCollectionView;
            }
        }

        public object IsLargeWidth => false;

        #endregion

        public MainWindowViewModel()
        {
        }

        #region Methods

        private void CreateObjectTestCollectionView()
        {
            var dataSource = new RemoteOrDbDataSourceEmulation(100, false);
            var modelProvider = new ObjectsTestViewModelProvider(dataSource);
            _ObjectTestVirtualizingObservableCollection = new VirtualizingObservableCollection<ObjectTestViewModel>(
                new PaginationManager<ObjectTestViewModel>(modelProvider, pageSize: 10));

            _ObjectTestCollectionView = CollectionViewSource.GetDefaultView(_ObjectTestVirtualizingObservableCollection);
        }

        private void CreateObjectTestHeightCollectionView()
        {
            var dataSource = new RemoteOrDbDataSourceEmulation(100, true);
            var modelProvider = new ObjectsTestViewModelProvider(dataSource);
            _ObjectTestHeightVirtualizingObservableCollection = new VirtualizingObservableCollection<ObjectTestViewModel>(
                new PaginationManager<ObjectTestViewModel>(modelProvider, pageSize: 10));

            _ObjectTestHeightCollectionView = CollectionViewSource.GetDefaultView(_ObjectTestHeightVirtualizingObservableCollection);
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}