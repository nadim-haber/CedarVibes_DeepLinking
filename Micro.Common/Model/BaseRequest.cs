// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-08-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-08-2018
// ***********************************************************************
// <copyright file="BaseRequest.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Common.Model
{
    /// <summary>
    /// Class BaseRequest.
    /// </summary>
    [DataContract]
    public class BaseRequest
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        [DataMember]
        public string Token { get; set; }
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        [DataMember]
        public string DeviceID { get; set; }
        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>The language code.</value>
        [DataMember]
        public List<string> LanguageCode { get; set; }
        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>The application version.</value>
        [DataMember]
        [Required]
        public string APP_Version { get; set; }
        /// <summary>
        /// Gets or sets the channel tag.
        /// </summary>
        /// <value>The channel tag.</value>
        [DataMember]
        [Required]
        public string ChannelTag { get; set; }
        /// <summary>
        /// Gets or sets the platform tag.
        /// </summary>
        /// <value>The platform tag.</value>
        [DataMember]
        [Required]
        public string PlatformTag { get; set; }
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        [DataMember]
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>The ip address.</value>
        [DataMember]
        [Required]
        public string IPAddress { get; set; }
        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>The user agent.</value>
        [DataMember]
        [Required]
        public string UserAgent { get; set; }
        /// <summary>
        /// Gets or sets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        [DataMember]
        [Required]
        public Guid CorrelationID { get; set; }

    }
}
