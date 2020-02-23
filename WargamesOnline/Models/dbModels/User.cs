using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBEMGlory.Models.dbModels
{
    /// <summary>
    /// User class that defines each user and is the basis of each person's authentication
    /// </summary>
    public class User
    {
        /// <summary>
        /// This is the Id of the user 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chosen display name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User name of the user
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The hash of the password + salt
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// Randomly generated salt 
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// Email address of user
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
