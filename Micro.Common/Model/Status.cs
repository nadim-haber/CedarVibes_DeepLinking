// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-06-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="Status.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Micro.Common.Model
{
    /// <summary>
    /// Enum Status
    /// </summary>
    [Flags]
    public enum Status : int
    {
        /// <summary>
        /// The error
        /// </summary>
        Error = -1,
        /// <summary>
        /// The failed
        /// </summary>
        Failed = 0,
        /// <summary>
        /// The success
        /// </summary>
        Success = 1,
    }
}
