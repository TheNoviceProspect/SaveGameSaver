

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SaveGameSaver
{
    public partial class MainAppForm : Form
    {
        const int maxBackups = 10;
        private static bool firstRun = true;
        internal static string sourcePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..\\locallow\\James Bendon\\Dinkum");
        internal static List<String> FoundBackups = new List<string>();
        internal static string destinationSubDirectory = String.Empty;
        internal static string restoreSource = String.Empty;

        /// <summary>
        /// Checks if the specified source path exists as a directory.
        /// </summary>
        /// <returns>True when directory found, false otherwise</returns>
        internal static bool CheckSourcePath()
        {
            return Directory.Exists(sourcePath);
        }

        internal static string GetDestinationPath(string configFile = "destination_path")
        {
            // Stores the path to the destination folder
            string destPath = "";

            // Creates the full path to the configuration file
            string configFilePath = configFile + ".conf";

            // Check if the configuration file exists
            if (File.Exists(configFilePath))
            {
                // Read the destination path from the configuration file
                destPath = File.ReadAllText(configFilePath);
                // Set flag indicating this isn't the first run
                firstRun = false; // Assuming 'firstRun' is a variable tracking initial execution
            }

            // If destination path is empty or null (meaning not set in config or first run)
            if (string.IsNullOrEmpty(destPath))
            {
                // Create a folder browser dialog to let user select a destination
                FolderBrowserDialog fbd = new FolderBrowserDialog();

                // Show the dialog and check if user clicked OK
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected path from the dialog
                    destPath = fbd.SelectedPath;

                    // Write the selected path to the configuration file for future use
                    File.WriteAllText(configFilePath, destPath);
                }
                else // User canceled the folder selection dialog
                {
                    // Show an error message with options
                    DialogResult result = ThrowError("You did not select a destination. I cannot continue!", "Warning", MessageBoxButtons.OK);

                    // Check user's response to the error message
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        // User acknowledges the error, close the application
                        System.Environment.Exit(1);
                    }
                }
            }

            // Combine the destination path with "DinkumBackups" subfolder
            return Path.Combine(destPath, "DinkumBackups");
        }


        /// <summary>
        /// Checks if the destination directory exists and prompts the user for confirmation 
        /// before creating it if necessary.
        /// </summary>
        /// <param name="dir">The path to the destination directory.</param>
        internal static void CheckAndCreateDestination(string dir)
        {
            // Check if the directory already exists
            if (Directory.Exists(dir))
            {
                // Warn the user about overwriting existing backup
                DialogResult result = ThrowError("It looks like you've already done a backup today. Continuing WILL overwrite the existing backup! CONTINUE????", "Warning", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    // User cancels, close the application
                    System.Environment.Exit(1);
                }
            }
            else
            {
                // Create the directory if it doesn't exist
                Directory.CreateDirectory(dir);
            }

            // TODO: Add comment explaining what happens with the destination path
        }

        /// <summary>
        /// Cleans up existing backups by deleting excess ones based on the `maxBackups` setting.
        /// </summary>
        /// <param name="dir">The path to the backup directory.</param>
        internal static void CleanupBackups(string dir)
        {
            // Get a list of existing backup directories, sorted by last write time descending
            DirectoryInfo[] backupDirectories = new DirectoryInfo(dir).GetDirectories().OrderByDescending(d => d.LastWriteTime).ToArray();

            // Check if there are too many backups
            if (backupDirectories.Length > maxBackups)
            {
                // Delete excess backups, keeping only the most recent ones
                backupDirectories.Skip(maxBackups).ToList().ForEach(d => d.Delete(true));
            }

            // Add found backups to the list
            foreach (var directory in backupDirectories)
            {
                FoundBackups.Add(directory.ToString());
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourceDirName);

            if (!sourceDir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // Prepend destination directory path once
            string destPath = Path.Combine(destDirName, sourceDir.Name);

            // Create the destination directory if it doesn't exist
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            // Enumerate files and copy them
            foreach (FileInfo file in sourceDir.EnumerateFiles())
            {
                file.CopyTo(Path.Combine(destPath, file.Name), false);
            }

            // Stack to track directories to be copied
            Stack<DirectoryInfo> dirsToCopy = new Stack<DirectoryInfo>(sourceDir.EnumerateDirectories());

            while (dirsToCopy.Count > 0)
            {
                DirectoryInfo currentDir = dirsToCopy.Pop();

                string subDirDestPath = Path.Combine(destPath, currentDir.Name);
                Directory.CreateDirectory(subDirDestPath);

                // Enumerate files and copy them
                foreach (FileInfo file in currentDir.EnumerateFiles())
                {
                    file.CopyTo(Path.Combine(subDirDestPath, file.Name), false);
                }

                // Add subdirectories for further processing (if requested)
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in currentDir.EnumerateDirectories())
                    {
                        dirsToCopy.Push(subdir);
                    }
                }
            }
        }

        /// <summary>
        /// Displays a message box with an error icon and captures the user's response.
        /// </summary>
        /// <param name="caption">The title text displayed in the title bar of the message box.</param>
        /// <param name="msg">The message text displayed in the message box.</param>
        /// <param name="buttons">The set of buttons displayed in the message box. (Default: OK)</param>
        /// <param name="icon">The icon displayed in the message box. (Default: Error)</param>
        /// <returns>The DialogResult indicating the button clicked by the user.</returns>
        internal static DialogResult ThrowError(string caption, string msg, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            // Display message box and capture user response
            return MessageBox.Show(caption, msg, buttons, icon);
        }

        /// <summary>
        /// Mainform Contructor
        /// </summary>
        public MainAppForm()
        {
            InitializeComponent();

            if (!CheckSourcePath())
            {
                DialogResult result = ThrowError("I could not find the local Dinkum Save folder. Please report this error to Sebastian_TheNovice", "ERROR", MessageBoxButtons.OK);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    toolStripStatusLabel1.Text = $"ERROR: Could not find the local Dinkum Save folder. Tried looking here : [{sourcePath}]";
                    System.Environment.Exit(1);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "READY: Dinkum Save found";
                button1.Enabled = true;
            }

            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string destinationDirectory = GetDestinationPath("backup-location");
            if (!String.IsNullOrEmpty(destinationDirectory))
            {
                toolStripStatusLabel2.Text = $"Backup Destination: [{destinationDirectory}]";
                button1.Text += $"\n{currentDate}";
            }
            destinationSubDirectory = Path.Combine(destinationDirectory, currentDate);

            if (!firstRun)
            {
                CleanupBackups(destinationDirectory);
                foreach (var dir in FoundBackups)
                {
                    listBox1.Items.Add(dir);
                }
                if (FoundBackups.Count != 0) listBox1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAndCreateDestination(destinationSubDirectory);
            try
            {
                DirectoryCopy(sourcePath, destinationSubDirectory, true);
            }
            catch (Exception ex)
            {
                DialogResult result = ThrowError("ERROR", $"Something BAD happened [ERROR: {ex.Message}]. Please report this error to Sebastian_TheNovice", MessageBoxButtons.OK);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // Closes the parent form.
                    System.Environment.Exit(1);
                }
            }
            System.Environment.Exit(0);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //button2.Enabled = true;
            restoreSource = listBox1.SelectedItem.ToString();
            string tempText = "Restore Save";
            button2.Text = tempText + $"\nfrom {restoreSource}";
        }
    }
}
