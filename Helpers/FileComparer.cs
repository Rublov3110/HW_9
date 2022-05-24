using System;
using System.Collections;
using System.IO;

namespace HW_9.Helpers
{
    public class FileComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var xFile = x as string;
            var yFile = y as string;

            if (xFile == null || yFile == null)
            {
                return 0;
            }

            var xFileInfo = new FileInfo(xFile);
            var yFileInfo = new FileInfo(yFile);

            return DateTime.Compare(xFileInfo.CreationTime, yFileInfo.CreationTime);
        }
    }
}