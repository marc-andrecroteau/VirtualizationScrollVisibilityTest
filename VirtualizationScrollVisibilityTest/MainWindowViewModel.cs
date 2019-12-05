using System.ComponentModel;
using System.Windows.Data;

namespace VirtualizationScrollVisibilityTest
{
    public class MainWindowViewModel
    {

        #region Fields

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
            _ObjectTestCollectionView = CollectionViewSource.GetDefaultView(dataSource);
        }

        private void CreateObjectTestHeightCollectionView()
        {
            var dataSource = new RemoteOrDbDataSourceEmulation(100, true);
            _ObjectTestHeightCollectionView = CollectionViewSource.GetDefaultView(dataSource);
        }

        #endregion

    }
}