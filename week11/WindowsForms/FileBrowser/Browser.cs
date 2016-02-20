using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{
	public partial class Browser : Form
	{
		public Browser()
		{
			InitializeComponent();

			var strDrives = Environment.GetLogicalDrives();

			AddFolder(new DirectoryInfo(@"C:\"), folderExplorer.Nodes, 0);

			foreach (var drive in strDrives)
			{
			}
		}

		private void AddFolder(DirectoryInfo folder, TreeNodeCollection nodeCollection, int level)
		{
			if(!CanRead(folder.FullName))
				return;

			var newNode = nodeCollection.Add(folder.Name);

			if (level == 0)
			{
				foreach (var directoryInfo in folder.GetDirectories())
				{
					AddFolder(directoryInfo, newNode.Nodes, level + 1);
				}
			}
		}

		public static bool CanRead(string path)
		{
			try
			{
				var readAllow = false;
				var readDeny = false;
				var accessControlList = Directory.GetAccessControl(path);
				if(accessControlList == null)
					return false;
				var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
				if(accessRules == null)
					return false;

				foreach(FileSystemAccessRule rule in accessRules)
				{
					if((FileSystemRights.Read & rule.FileSystemRights) != FileSystemRights.Read)
						continue;

					if(rule.AccessControlType == AccessControlType.Allow)
						readAllow = true;
					else if(rule.AccessControlType == AccessControlType.Deny)
						readDeny = true;
				}

				return readAllow && !readDeny;
			}
			catch(Exception)
			{
				return false;
			}
		}
	}
}
