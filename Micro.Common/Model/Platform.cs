// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-17-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-20-2018
// ***********************************************************************
// <copyright file="Platform.cs" company="">
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
    /// Class Platform.
    /// </summary>
    [Flags]
    public enum Platform
    {
        /// <summary>
        /// The ios
        /// </summary>
        IOS,
        /// <summary>
        /// The android
        /// </summary>
        Android,
        /// <summary>
        /// The web
        /// </summary>
        Web
    }
}
