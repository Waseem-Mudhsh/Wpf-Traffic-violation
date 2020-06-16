namespace Wpf_Traffic_violation.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Class For every class need INotifyPropertyChanged And INotifyDataError 
    ///   للتحقق من كل قيمة   roles فيها  CollectErrors() اعمل فقط تعريف للدالة  validation  ملاحظة \ علشان اعمل 
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged, IDataErrorInfo
    {
        //public string Update = "Update";
        //public string Delete = "Delete";
        //public string Insert = "Insert";


        public bool IsEditing { get; set; }
        public bool IsAdding { get; set; }
        #region PropertyChanged

        public void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        public event PropertyChangedEventHandler PropertyChanged;


        #endregion
        #region DataErrorInfo Implementation
        public Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();
        public bool HasErrors => Errors.Any();
        public string Error => string.Empty;
        public string this[string propertyName]
        {
            get
            {
                CollectErrors();
                return Errors.ContainsKey(propertyName) ? Errors[propertyName] : string.Empty;
            }
        }

        public abstract void CollectErrors();

        #endregion
    }
}




