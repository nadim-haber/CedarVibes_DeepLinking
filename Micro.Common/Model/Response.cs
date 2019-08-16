// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-06-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-07-2018
// ***********************************************************************
// <copyright file="Response.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Runtime.Serialization;

namespace Micro.Common.Model
{
    /// <summary>
   /// Class Response.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Response<T>
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [DataMember]
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [DataMember]
        public T Data { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [DataMember]
        public string Message { get; set; }
    }
}
