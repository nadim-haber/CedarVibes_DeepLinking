// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-07-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-07-2018
// ***********************************************************************
// <copyright file="ILogEngine.cs" company="">
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
    /// Interface ILogEngine
    /// </summary>
    public interface ILogEngine
    {
        /// <summary>
        /// Called when [begin].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void OnBegin(params object[] parameters);
        /// <summary>
        /// Called when [end].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void OnEnd(params object[] parameters);
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="parameters">The parameters.</param>
        void OnException(Exception ex, params object[] parameters);
        /// <summary>
        /// Writes the specified log type.
        /// </summary>
        /// <param name="logType">Type of the log.</param>
        /// <param name="message">The message.</param>
        void Write(LogType logType, string message);
    }
}
