using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Book
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
    }

}
