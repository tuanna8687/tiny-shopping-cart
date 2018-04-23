using System.Collections.Generic;

namespace TinyShoppingCart.Server.Presentation.Admin.ViewModels
{
    public class DataTableParamViewModel
    {
        public int Draw {get;set;}

        public List<ColumnParamViewModel> Columns {get;set;}
        public List<OrderParamViewModel> Order {get;set;}

        public int Start {get;set;}
        public int Length {get;set;}
        public SearchParamViewModel Search {get;set;}
    }
}