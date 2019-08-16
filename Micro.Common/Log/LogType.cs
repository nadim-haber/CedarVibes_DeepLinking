// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-07-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-07-2018
// ***********************************************************************
// <copyright file="LogType.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Common.Log
{
    /// <summary>
    /// Enum LogType
    /// </summary>
    [Flags]
    public enum LogType
    {
        /// <summary>
        /// The information
        /// </summary>
        Info,
        /// <summary>
        /// The warning
        /// </summary>
        Warning,
        /// <summary>
        /// The error
        /// </summary>
        Error
    }
}
