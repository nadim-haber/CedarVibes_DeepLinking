// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-17-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-17-2018
// ***********************************************************************
// <copyright file="Channel.cs" company="">
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
    /// Class Channel.
    /// </summary>
    [Flags]
    public enum Channel
    {
        /// <summary>
        /// The mob
        /// </summary>
        MOB,
        /// <summary>
        /// The web
        /// </summary>
        WEB,
        /// <summary>
        /// The CMS
        /// </summary>
        CMS
    }
}
