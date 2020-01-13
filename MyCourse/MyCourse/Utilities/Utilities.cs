using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Utilities
{
    public static class Utilities
    {
        public static bool RemoveImage(string root,string image)
        {
            string path = Path.Combine(root,"images",image);

            

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
