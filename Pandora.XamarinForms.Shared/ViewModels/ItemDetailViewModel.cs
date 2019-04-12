using System;

using Pandora.XamarinForms.Shared.Models;

namespace Pandora.XamarinForms.Shared.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
