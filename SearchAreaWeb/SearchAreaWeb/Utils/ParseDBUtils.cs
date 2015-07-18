using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace SearchAreaWeb.Utils
{
    public static class ParseDBUtils
    {
        public static void Initialize()
        {
            ParseClient.Initialize("SAlhWqn4ERwfsVT7MHjky4PLiURrI7tY1K3xF6Sa", 
                                   "hmS5OMLDGUfeLDwOF7EWoNgMcamuYhgABkq7N4Qy");
        }

        public async static void Test()
        {
            var testObject = new ParseObject("TestObject");
            testObject["foo"] = "bar";
            await testObject.SaveAsync();
        }
    }
}