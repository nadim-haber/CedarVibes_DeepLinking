// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-08-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-08-2018
// ***********************************************************************
// <copyright file="ResponseExtension.cs" company="">
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
    /// Class ResponseExtension.
    /// </summary>
    public static class ResponseExtension
    {
        /// <summary>
        /// APIs the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <returns>ApiResponse.</returns>
        public static ApiResponse ApiResponse<T>(this Response<T> response)
        {
            return new ApiResponse()
            {
                Status = response.Status,
                Data = response.Data,
                Message = response.Message
            };
        }
    }
}
