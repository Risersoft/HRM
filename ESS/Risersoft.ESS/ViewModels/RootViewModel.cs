using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Risersoft.ESS.ViewModels
{
    //public class RootViewModel : INotifyPropertyChanged
    //{
    //    public RootViewModel()
    //    {
    //    }
    //    public string Title { get; set; }
    //    public string Icon { get; set; }

    //    #region INotifyPropertyChanged implementation
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected bool SetProperty<T>(
    //       ref T backingStore, T value,
    //       [CallerMemberName]string propertyName = "",
    //       Action onChanged = null)
    //    {
    //        if (EqualityComparer<T>.Default.Equals(backingStore, value))
    //            return false;

    //        backingStore = value;

    //        if (onChanged != null)
    //            onChanged();

    //        OnPropertyChanged(propertyName);
    //        return true;
    //    }
    //    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    //    {
    //        var changed = PropertyChanged;
    //        if (changed == null)
    //            return;
    //        changed(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //    #endregion

    //}
}
