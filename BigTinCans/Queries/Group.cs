using System;
using System.Collections.Generic;
using System.Text;
using BigTinCans.Models;
using System.IO;
using System.Text.Json;

namespace BigTinCans.Queries
{
    public class Group
    {
        private string[] inputGroups;
        public Group(string filePath)
        {
            inputGroups = File.ReadAllText(filePath).Split(";");
        }

        private List<Role> _roles;
        public List<Role> Roles 
        {
            get
            {
                _roles = new List<Role>();
                foreach (string sGroup in inputGroups)
                {
                    if (sGroup.Contains("roles"))
                    {
                        string jsonRoles = sGroup.Substring(sGroup.IndexOf("["), sGroup.IndexOf("]") - sGroup.IndexOf("[") + 1);
                        _roles= JsonSerializer.Deserialize<List<Role>>(jsonRoles);
                    }
                }
                return _roles;
            }
            private set { } 
        }

        private List<User> _users;
        public List<User> Users { 
                get
            {
                _users = new List<User>();
                foreach (string sGroup in inputGroups)
                {
                    if (sGroup.Contains("users"))
                    {
                        string jsonRoles = sGroup.Substring(sGroup.IndexOf("["), sGroup.IndexOf("]") - sGroup.IndexOf("[") + 1);
                        _users = JsonSerializer.Deserialize<List<User>>(jsonRoles);
                    }
                }
                return _users;
            } 
            private set { }
    }        

    }
}
