#region MITLincense

//MIT License
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,:
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion

using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
namespace DirectoryManger
{
    public static class DirectoryManagement
    {
        static DirectoryManagement()
        {
        }
#region DirectoryInfo
    
#endregion

#region DirectoryManagment
        public static Boolean CreateDirectory(String Path, String Name)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();
            if(Directory.Exists(strDirectory))
            {
#if(DEBUG)
                Console.WriteLine("Directory {0} exists",strDirectory);
#endif
                return false;
            } //End of checking if directory exists
            Directory.CreateDirectory(strDirectory);
            if(Directory.Exists(strDirectory))
            {
#if(DEBUG)
                Console.WriteLine("Directory {0} has been created",strDirectory);
#endif
                return true;
            }
            return false;
        }

        public static void DeleteDirectory(String Path, String Name)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            Directory.Delete(strDirectory);
        }
        private static Boolean RenameDirectory(String Path,String Name,String newName)
        {
            return false;
        }
        public static Boolean isDirectoryEmpty(String Path, String Name)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();
            
            return !Directory.EnumerateFileSystemEntries(
                strDirectory, 
                "*", 
                SearchOption.AllDirectories ).Any();
        }
        
#endregion

#region Windows_Permissions
        public static void EnableDirectoryInheritance(String Path,String Name)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSec = di.GetAccessControl();
            dirSec.SetAccessRuleProtection(false, false);
            di.SetAccessControl(dirSec);
        }
        public static void DisableDirectoryInheritance(String Path,String Name)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSec = di.GetAccessControl();
            dirSec.SetAccessRuleProtection(true, true);
            di.SetAccessControl(dirSec);
        }

        public static void SetFullPermission(String Path,String Name, String Username)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSecurity = di.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(Username,
                FileSystemRights.FullControl | FileSystemRights.Synchronize,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow
            ));
            di.SetAccessControl(dirSecurity);
        }
        public static void SetModifyPermission(String Path, String Name, String Username)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSecurity = di.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(Username,
                FileSystemRights.Modify | FileSystemRights.Synchronize,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow
            ));
            di.SetAccessControl(dirSecurity);
        }

        public static void SetWritePermission (String Path,String Name,String Username)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSecurity = di.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(Username,
                FileSystemRights.Write | FileSystemRights.Synchronize,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow
            ));
            di.SetAccessControl(dirSecurity);
        }

        public static void SetReadPermission(String Path,String Name, String Username)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSecurity = di.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(Username,
                FileSystemRights.Read | FileSystemRights.Synchronize,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow
            ));
            di.SetAccessControl(dirSecurity);
        }

        public static void SetReadExecurePermission(String Path,String Name, String Username)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSecurity = di.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(Username,
                FileSystemRights.ReadAndExecute | FileSystemRights.Synchronize,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow
            ));
            di.SetAccessControl(dirSecurity);
        }

        public static void SetListFolderContents(String Path,String Name,String Username)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();

            DirectoryInfo di = new DirectoryInfo(strDirectory);
            DirectorySecurity dirSecurity = di.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(Username,
                FileSystemRights.ListDirectory | FileSystemRights.Synchronize,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None, AccessControlType.Allow
            ));
            di.SetAccessControl(dirSecurity);
        }
        public static void RemovePermissions(String Path, String Name, String Username)
        {
            StringBuilder sbDirectory = new StringBuilder();
            sbDirectory.Append(Path.Trim());
            sbDirectory.Append(Name.Trim().ToUpper());
            String strDirectory = sbDirectory.ToString();
            DirectoryInfo dirinfo = new DirectoryInfo(strDirectory);
            DirectorySecurity dsec = dirinfo.GetAccessControl(AccessControlSections.All);
            AuthorizationRuleCollection rules = dsec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
            foreach (AccessRule rule in rules)
            {
                if (rule.IdentityReference.Value == Username)
                {
                    bool value;
                    dsec.PurgeAccessRules(rule.IdentityReference);
                    dsec.ModifyAccessRule(AccessControlModification.RemoveAll, rule, out value);
                    dirinfo.SetAccessControl(dsec);
                }
            }
        }
#endregion

    }
}