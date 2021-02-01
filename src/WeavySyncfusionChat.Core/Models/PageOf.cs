using System;
using System.Collections.Generic;
using System.Text;

namespace WeavySyncfusionChat.Core.Models
{
    public class PageOf<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Top { get; set; }
        public int Skip { get; set; }
        public string Prev { get; set; }
        public string Next { get; set; }

    }
}
