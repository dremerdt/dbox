using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dbox_global.Utils
{
    public static class DirectoryUtils
    {
        /// <summary>
        /// Move a directory to a target destination.
        /// </summary>
        /// <param name="source">A source directory</param>
        /// <param name="target">A target directory</param>
        public static void MoveDirectory(string source, string target)
        {
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                .GroupBy(Path.GetDirectoryName);
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }
            }
            Directory.Delete(source, true);
        }
    }
}
