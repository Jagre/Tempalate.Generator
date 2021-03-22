//-----------------------------------------------------------------------
// <copyright file=" ProductStatus.cs" company="xxxx Enterprises">
// * Copyright (C) 2021 haha
// * version : 4.0.30319.42000
// * FileName: ProductStatus.cs
// * history : Created at 03/22/2021 23:31:09 
// * 
// </copyright>
//-----------------------------------------------------------------------

using System;
 
namespace Test.Entities
{
    /// <summary>
    /// ProductStatus Entity Model
    /// </summary>    
    public partial class ProductStatus
    {
        
        /// <summary>
        /// 产品ID
        /// </summary>
        [Dapper.Contrib.Extensions.Key]
        [Dapper.Contrib.Extensions.ExplicitKey]
        public int Id { get; set; }
        
        /// <summary>
        /// 产品状态
        /// </summary>
        public int Status { get; set; }
    }
}
