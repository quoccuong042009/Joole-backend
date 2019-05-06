﻿using Joole_BackEnd.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Core.Domain.ManyToMany
{
    public class SubCatToTypeProp
    {
        public int ProductId { get; set; }
        public int TypePropertyId { get; set; }
        public Product Product { get; set; }
        public TypeProperty TypeProperty { get; set; }
    }
}