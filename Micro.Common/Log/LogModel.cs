// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-07-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-07-2018
// ***********************************************************************
// <copyright file="LogModel.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Common.Log
{
    /// <summary>
    /// Class LogModel.
    /// </summary>
    /// <typeparam name="TIn">The type of the t in.</typeparam>
    /// <typeparam name="Tout">The type of the tout.</typeparam>
    public class LogModel<TIn, Tout>
    {
        private ILogEngine logEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogModel{TIn, Tout}"/> class.
        /// </summary>
        public LogModel()
        {
            CorrelationID = Guid.NewGuid();
            this.StartTime = new DateTime();
            this.EndTime = new DateTime();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogModel{TIn, Tout}"/> class.
        /// </summary>
        /// <param name="logEngine">The log engine.</param>
        public LogModel(ILogEngine logEngine)
        {
            this.logEngine = logEngine;
            CorrelationID = Guid.NewGuid();
            this.StartTime = new DateTime();
            this.EndTime = new DateTime();
        }

        /// <summary>
        /// Gets or sets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        public Guid CorrelationID { get; set; }
        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>The input.</value>
        public TIn Input { get; set; }
        /// <summary>
        /// Gets or sets the output.
        /// </summary>
        /// <value>The output.</value>
        public Tout Output { get; set; }
        /// <summary>
        /// The start time
        /// </summary>
        [JsonIgnore]
        private DateTime StartTime;
        /// <summary>
        /// The end time
        /// </summary>
        [JsonIgnore]
        private DateTime EndTime;

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public double Duration
        {
            get
            {
                return (EndTime - StartTime).TotalMilliseconds;
            }
        }

        /// <summary>
        /// Begins the log.
        /// </summary>
        public void BeginLog()
        {
            StartTime = DateTime.Now;
            if (this.logEngine != null)
                this.logEngine.OnBegin(this);
        }

        /// <summary>
        /// Ends the log.
        /// </summary>
        public void EndLog()
        {
            EndTime = DateTime.Now;
            if (this.logEngine != null)
                this.logEngine.OnEnd(this);
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="logType">Type of the log.</param>
        /// <param name="message">The message.</param>
        public void WriteLog(LogType logType, string message)
        {
            if (this.logEngine != null)
                this.logEngine.Write(logType, message);
        }

        /// <summary>
        /// Exceptions the log.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public void ExceptionLog(Exception ex)
        {
            if (this.logEngine != null)
                this.logEngine.OnException(ex, this);
        }
    }
}
