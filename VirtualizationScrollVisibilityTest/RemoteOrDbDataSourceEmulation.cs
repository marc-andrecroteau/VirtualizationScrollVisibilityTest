using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VirtualizationScrollVisibilityTest
{
    /// <summary>
    ///     Emulate a remote data repository (list of item + sort & filter values)
    /// </summary>
    public class RemoteOrDbDataSourceEmulation : ObservableCollection<ObjectTestViewModel>
    {
        public RemoteOrDbDataSourceEmulation(int itemsCount, bool isHeightTest)
        {
            for (var i = 0; i < itemsCount; i++)
                Add(new ObjectTestViewModel(isHeightTest));
        }
    }
}