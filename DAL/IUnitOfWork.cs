using INTEX2.DAL;
using INTEX2.Models;

namespace INTEX2.DAL
{
    /// <summary>
    /// Defines the members for the Unit Of Work class. 
    /// </summary>
    public interface IUnitOfWork
    {
        // All Generic Repos for the project.
        /// <summary>
        /// Generic Repo for Bowlers.
        /// </summary>

        /// <summary>
        /// Saves the changes made to the Repos in this Unit Of Work to the Db.
        /// </summary>
        void Save();
    }
}