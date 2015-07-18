using System;

namespace SearchAreaWeb.Utils
{
    public static class Verify
    {
        public static void IsNotNull(object o, string name) 
        {
            if(o == null) 
            {
                throw new ArgumentNullException();
            }
        }

        public static void IsNotNullOrEmpty(string s, string name)
        {
            if (s == null)
            {
                throw new ArgumentNullException("ERROR Argument null: " + name);
            }

            if (s == String.Empty)
            {
                throw new ArgumentException("ERROR String can't be empty: " + name);
            }
        }
    }
}