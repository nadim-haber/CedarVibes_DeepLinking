// ***********************************************************************
// Assembly         : Micro.Common.Log
// Author           : RAmmar
// Created          : 08-06-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="LogEngine.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Micro.Common.Log
{
    /// <summary>
    /// Class LogEngine.
    /// </summary>
    public class LogEngine : ILogEngine
    {
        /// <summary>
        /// The log
        /// </summary>
        private log4net.ILog log;
        /// <summary>
        /// The default enable
        /// </summary>
        private bool defaultEnable = true;

        /// <summary>
        /// Gets a value indicating whether this <see cref="LogEngine"/> is enable.
        /// </summary>
        /// <value><c>true</c> if enable; otherwise, <c>false</c>.</value>
        private bool Enable
        {
            get
            {
                bool enable = defaultEnable;
                if (ConfigurationManager.AppSettings.AllKeys.Contains("Log_Enable"))
                {
                    if (!bool.TryParse(ConfigurationManager.AppSettings["Log_Enable"], out enable))
                        enable = defaultEnable;
                }
                return enable;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEngine"/> class.
        /// </summary>
        public LogEngine()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Called when [begin].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnBegin(params object[] parameters)
        {
            if (Enable)
            {
                StackTrace stackTrace = new StackTrace();
                log.Info("--------------------------------------------------------");
                log.Info("Begin " + stackTrace.GetFrame(2).GetMethod().Name + Environment.NewLine);
                foreach (var item in parameters)
                {
                    log.Info(JsonConvert.SerializeObject(item) + Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// Called when [end].
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnEnd(params object[] parameters)
        {
            if (Enable)
            {
                log.Info("End" + Environment.NewLine);
                foreach (var item in parameters)
                {
                    log.Info(JsonConvert.SerializeObject(item) + Environment.NewLine);
                }
                log.Info("--------------------------------------------------------");
            }
        }

        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="parameters">The parameters.</param>
        public virtual void OnException(Exception ex, params object[] parameters)
        {
            if (Enable)
            {
                StackTrace stackTrace = new StackTrace();
                log.Error("--------------------------------------------------------");
                log.Error("Exception ");

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        log.Error(JsonConvert.SerializeObject(item) + Environment.NewLine);
                    }
                }

                string errorTrace = string.Empty;

                log.Error(ex.Message + Environment.NewLine);

                if (ex.StackTrace != null)
                    errorTrace = ex.StackTrace.ToString();
                if (ex.InnerException != null)
                    errorTrace = ex.InnerException.InnerException != null ? ex.InnerException.InnerException.Message : ex.InnerException.Message;

                log.Error(errorTrace + Environment.NewLine);
                log.Error("--------------------------------------------------------");
            }
        }

        /// <summary>
        /// Writes the specified log type.
        /// </summary>
        /// <param name="logType">Type of the log.</param>
        /// <param name="message">The message.</param>
        public virtual void Write(LogType logType, string message)
        {
            if (Enable)
            {
                switch (logType)
                {
                    case LogType.Info:
                        log.Info(message);
                        break;
                    case LogType.Warning:
                        log.Warn(message);
                        break;
                    case LogType.Error:
                        log.Error(message);
                        break;
                }
            }
        }
    }
}
