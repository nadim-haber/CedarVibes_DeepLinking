// ***********************************************************************
// Assembly         : Micro.Common
// Author           : SaHaidar
// Created          : 08-17-2018
//
// Last Modified By : SaHaidar
// Last Modified On : 08-17-2018
// ***********************************************************************
// <copyright file="MediaObject.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Common.Model
{
    /// <summary>
    /// Class MediaObject.
    /// </summary>
    [DataContract]
    public class MediaObject
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        /// <value>The thumbnail.</value>
        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public string Thumbnail { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [DataMember(Order = 3)]
        [JsonProperty(Order = 3)]
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the type value.
        /// </summary>
        /// <value>The type value.</value>
        [DataMember(Order = 4)]
        [JsonProperty(Order = 4)]
        public int TypeValue { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        [DataMember(Order = 5)]
        [JsonProperty(Order = 5)]
        public long Duration { get; set; }
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        [DataMember(Order = 6)]
        [JsonProperty(Order = 6)]
        public string Guid { get; set; }
    }
}
