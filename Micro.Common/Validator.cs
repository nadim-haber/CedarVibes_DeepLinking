// ***********************************************************************
// Assembly         : Micro.Common
// Author           : RAmmar
// Created          : 08-06-2018
//
// Last Modified By : RAmmar
// Last Modified On : 08-06-2018
// ***********************************************************************
// <copyright file="Validator.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Micro.Common
{
    /// <summary>
    /// Class Validator.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Determines whether [is model valid] [the specified model].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <param name="error">The error.</param>
        /// <returns><c>true</c> if [is model valid] [the specified model]; otherwise, <c>false</c>.</returns>
        public bool IsModelValid<T>(T model, out string error) where T : class
        {
            bool isValid = false;
            error = string.Empty;

            var results = new List<ValidationResult>();
            isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, new ValidationContext(model), results, true);

            if (!isValid)
                error = string.Join(" ", results.Select(x => x.ErrorMessage).ToArray());

            return isValid;
        }
    }
}
