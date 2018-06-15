using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class ListVMBroad
    {
        public List<ListVM> list { get; set; }
        public int pageNr { get; set; }
        public int listCount { get; set; }
        public int max_items { get; set; }
    }
}