// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-22-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-22-2018
// ***********************************************************************
// <copyright file="PagedList.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Common.Model
{
    /// <summary>
    /// Class PagedList.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    [DataContract]
    public class PagedList<T> : IEnumerable<T> where T : class
    {
        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        [DataMember]
        public int PageIndex { get; set; }
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        [DataMember]
        public int PageSize { get; set; }
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        [DataMember]
        public int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        [DataMember]
        public int TotalPages
        {
            get
            {
                return (TotalCount / PageSize) + (TotalCount % PageSize > 0 ? 1 : 0);
            }
            set { }
        }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember]
        public IEnumerable<T> Items { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has previous page.
        /// </summary>
        /// <value><c>true</c> if this instance has previous page; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool HasPreviousPage
        {
            get
            {
                return PageIndex - 1 > 0;
            }
            set { }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance has next page.
        /// </summary>
        /// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages;
            }
            set { }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}" /> class.
        /// </summary>
        /// <param name="Items">The items.</param>
        /// <param name="PageNumber">The page number.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="TotalCount">The total count.</param>
        public PagedList(IEnumerable<T> Items, int PageNumber, int PageSize, int TotalCount)
        {
            this.PageIndex = PageNumber;
            this.PageSize = PageSize;
            this.TotalCount = TotalCount;
            this.Items = Items;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }
    }
}
