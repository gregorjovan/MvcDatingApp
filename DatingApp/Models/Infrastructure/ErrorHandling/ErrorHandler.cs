using System;
using System.Collections.Specialized;

namespace DatingApp.Models.Infrastructure.ErrorHandling
{
    public abstract class ErrorHandler
    {
        #region Data members

        protected NameValueCollection errors;
        public NameValueCollection Errors { get { return errors; } set { errors = value; } }

        private bool systemError;
        /// <summary>
        /// Error is in system. Report some user friendly error message.
        /// </summary>
        protected bool SystemError { get { return systemError; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Error Handler constructor
        /// </summary>
        protected ErrorHandler()
        {
            this.errors = new NameValueCollection();
        }

        #endregion

        #region System Error

        protected void RaiseSystemError(string message)
        {

        }

        #endregion
    }
}