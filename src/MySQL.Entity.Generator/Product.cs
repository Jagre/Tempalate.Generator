//-----------------------------------------------------------------------
// <copyright file=" Product.cs" company="xxxx Enterprises">
// * Copyright (C) 2021 haha
// * version : 4.0.30319.42000
// * FileName: Product.cs
// * history : Created at 03/22/2021 23:31:09 
// * 
// </copyright>
//-----------------------------------------------------------------------

using System;
 
namespace Test.Entities
{
    /// <summary>
    /// Product Entity Model
    /// </summary>    
    public partial class Product
    {
        
        /// <summary>
        /// Product Id
        /// </summary>
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Creator
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// Create time
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
