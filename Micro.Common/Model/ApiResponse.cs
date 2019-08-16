// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-08-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-08-2018
// ***********************************************************************
// <copyright file="ApiResponse.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Common.Model
{
    /// <summary>
    /// Class ApiResponse.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public object Data { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }
}
