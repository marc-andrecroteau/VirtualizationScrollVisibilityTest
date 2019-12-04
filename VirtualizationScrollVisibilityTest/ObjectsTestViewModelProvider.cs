using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AlphaChiTech.Virtualization;

namespace VirtualizationScrollVisibilityTest
{
    public class ObjectsTestViewModelProvider : IPagedSourceProviderAsync<ObjectTestViewModel>
    {
                #region Fields

        private readonly ObservableCollection<ObjectTestViewModel> _ObjectTestViewModels;

        #endregion

        #region Constructor

        public ObjectsTestViewModelProvider(RemoteOrDbDataSourceEmulation remoteOrDbDataSourceEmulation)
        {
            _ObjectTestViewModels = remoteOrDbDataSourceEmulation;
        }

        #endregion

        #region Methods

        #region Sync

        int IPagedSourceProvider<ObjectTestViewModel>.IndexOf(ObjectTestViewModel item)
        {
            return _ObjectTestViewModels.IndexOf(item);
        }

        public bool Contains(ObjectTestViewModel item)
        {
            return _ObjectTestViewModels.Contains(item);
        }

        public PagedSourceItemsPacket<ObjectTestViewModel> GetItemsAt(int pageoffset, int count, bool usePlaceholder)
        {
            //Task.Delay(50 + (int) Math.Round(_rand.NextDouble() * 100)).Wait(); // Just to slow it down !
            return new PagedSourceItemsPacket<ObjectTestViewModel>
            {
                LoadedAt = DateTime.Now,
                Items = (from items in _ObjectTestViewModels select items).Skip(pageoffset).Take(count)
            };
        }

        public int Count => _ObjectTestViewModels.Count;

        #endregion

        #region Async

        public Task<int> GetCountAsync()
        {
            return Task.Run(() =>
            {
                return _ObjectTestViewModels.Count;
            });
        }

        public Task<PagedSourceItemsPacket<ObjectTestViewModel>> GetItemsAtAsync(int pageoffset, int count,
            bool usePlaceholder)
        {
            Console.WriteLine("Get");
            return Task.Run(() =>
            {
                return new PagedSourceItemsPacket<ObjectTestViewModel>
                {
                    LoadedAt = DateTime.Now,
                    Items = (from items in _ObjectTestViewModels select items).Skip(pageoffset)
                        .Take(count)
                };
            });
        }

        public ObjectTestViewModel GetPlaceHolder(int index, int page, int offset)
        {
            return new ObjectTestViewModel(false);
        }

        /// <summary>
        ///     This returns the index of a specific item. This method is optional – you can just return -1 if you
        ///     don’t need to use IndexOf. It’s not strictly required if don’t need to be able to seeking to a
        ///     specific item, but if you are selecting items implementing this method is recommended.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> IndexOfAsync(ObjectTestViewModel item)
        {
            return Task.Run(() => _ObjectTestViewModels.IndexOf(item));
        }

        /// <summary>
        ///     This is a callback that runs when a Reset is called on a provider. Implementing this is also optional.
        ///     If you don’t need to do anything in particular when resets occur, you can leave this method body empty.
        /// </summary>
        /// <param name="count"></param>
        public void OnReset(int count)
        {
            // Do nothing for now
        }

        #endregion

        #endregion
    }
}