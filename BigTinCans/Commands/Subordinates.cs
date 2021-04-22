using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BigTinCans.Models;

namespace BigTinCans.Commands
{
    public class Subordinates
    {
        public List<Role> Roles { get; set; }
        public List<User> Users { get; set; }
        public int UserId { get; set; }

        List<int> AllChildrenRoleIds;

        public Subordinates(int userId, List<Role> roles, List<User> users)
        {
            UserId = userId;
            Roles = roles;
            Users = users;
        }

        public List<User> getSubordinates()
        {
            var results = new List<User>();
            try
            {
                if (Users.Exists(u => u.Id == UserId))
                {
                    User currentUser = Users.Find(u => u.Id == UserId);
                    int roleId = currentUser.Role;

                    if (Roles.Exists(r => r.Id == roleId))
                    {
                        AllChildrenRoleIds = new List<int>();
                        getAllChildren(roleId);
                        results = getUsers();
                    }
                    else
                    {
                        throw new Exception("Invalid Role Number");
                    }
                }
                else
                {
                    throw new Exception("Invalid User Number");
                }
            }
            catch
            {
            }
            return results;
        }

        void getAllChildren(int roleId)
        {
            var parentsRoleIds = Roles.Where(r => r.Parent == roleId).Select(r => new { r.Id });
            foreach (var parent in parentsRoleIds)
            {
                AllChildrenRoleIds.Add(parent.Id);
                getAllChildren(parent.Id);
            }
        }

        List<User> getUsers()
        {
            List<User> pUsers = new List<User>();
            foreach (int roleId in AllChildrenRoleIds)
            {
                pUsers.AddRange(Users.FindAll(u => u.Role == roleId));
            }

            return pUsers;
        }
    }

    
}
