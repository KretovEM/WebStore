﻿using System.Collections.Generic;

namespace WebStore.DomainNew.Filters
{
    /// <summary>
    ///     Класс для фильтрации товаров
    /// </summary>
    public class ProductFilter
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public List<int> Ids { get; set; }
    }
}
