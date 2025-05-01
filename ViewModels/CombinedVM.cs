using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondHana.ViewModels
{
    public partial class CombinedVM : ObservableObject
    {
        public SettingVM UserSetting => SettingVM.Instance;

        // อาจจะมี ViewModel อื่น ๆ รวมอยู่ด้วย
        //public OtherVM OtherViewModel { get; set; }

        //public CombinedVM()
        //{
        //    OtherViewModel = new OtherVM();
        //}
    }
}
