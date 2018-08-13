using System;
using System.Windows.Forms;
using Launcher.Models;
using System.Collections.Generic;
using Launcher.Utilities;
using System.IO;

namespace Launcher
{
    public partial class Patcher : Form
    {
        private readonly LauncherConfig _config;

        public static Dictionary<string, string> PatchDirectories {
            get {
                return new Dictionary<string, string>
                {
                    { "text", "text.pak" }
                };
            }
        }

        public Patcher(LauncherConfig config)
        {
            this._config = config;
            var patchFiles = false;

            foreach (var path in Patcher.PatchDirectories.Keys)
            {
                if (Directory.GetFiles(Path.Combine(this._config.InstallDir, path)).Length > 0)
                {
                    patchFiles = true;
                    break;
                }
            }

            if (!patchFiles)
            {
                this.Close();
                return;
            }

            InitializeComponent();
            PatchFiles();
        }

        private void PatchFiles()
        {
            foreach(var directory in PatchDirectories.Keys)
            {
                var filesToPack = new List<PakFile>();
                var directoryString = Path.Combine(this._config.InstallDir, directory);

                var filePaths = Directory.GetFiles(directoryString);
                foreach(var filePath in filePaths)
                {
                    filesToPack.Add(new PakFile
                    {
                        FileName = filePath,
                        Content = File.ReadAllText(filePath)
                    });
                }

                PakTools.RebuildPak(Path.Combine(this._config.InstallDir, PatchDirectories[directory]),
                    filesToPack,
                    true);

                var directoryInfo = new DirectoryInfo(directoryString);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
