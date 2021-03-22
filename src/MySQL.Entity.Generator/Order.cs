//-----------------------------------------------------------------------
// <copyright file=" Order.cs" company="xxxx Enterprises">
// * Copyright (C) 2021 haha
// * version : 4.0.30319.42000
// * FileName: Order.cs
// * history : Created at 03/22/2021 23:31:09 
// * 
// </copyright>
//-----------------------------------------------------------------------

using System;
 
namespace Test.Entities
{
    /// <summary>
    /// Order Entity Model
    /// </summary>    
    public partial class Order
    {
        
        /// <summary>
        /// Order ID
        /// </summary>
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Order Number
        /// </summary>
        public string OrderNo { get; set; }
        
        /// <summary>
        /// Product ID
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// Sales Price
        /// </summary>
        public decimal SalesPrice { get; set; }
        
        /// <summary>
        /// Qty
        /// </summary>
        public int Qty { get; set; }
        
        /// <summary>
        /// Create By 
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// Create date
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
