﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar.Somut;

namespace VeriErisimler.Soyut
{
    public interface IAuthorDal : IGenel<Author>
    {
        Author AuthorSign(Author a);
    }
}
