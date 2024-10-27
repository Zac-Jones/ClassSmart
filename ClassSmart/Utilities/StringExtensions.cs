namespace ClassSmart.Utilities
{
    /// <summary>  
    /// Extension methods for string operations.  
    /// </summary>  
    public static class StringExtensions
    {
        /// <summary>  
        /// Determines whether the specified string is a valid email address.  
        /// </summary>  
        /// <param name="email">The email string to validate.</param>  
        /// <returns><c>true</c> if the specified string is a valid email address; otherwise, <c>false</c>.</returns>  
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
