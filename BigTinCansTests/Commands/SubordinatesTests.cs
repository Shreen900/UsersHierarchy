using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigTinCans.Commands;
using BigTinCans.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BigTinCans.Commands.Tests
{
    [TestClass()]
    public class SubordinatesTests
    {
        [TestMethod()]
        public void getSubordinatesTest_EmptyRolesAndUsers()
        {
            //Arrange & Act
            Subordinates subordinates = new Subordinates(1, new List<Role>(), new List<User>());
            var results = subordinates.getSubordinates();
            //Assert
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod()]
        public void getSubordinatesTest_EmptyRoles()
        {
            //Arrange
            List<User> users = new List<User>
            {
                new User{Id=1,Name="Adam Admin",Role=1},
                new User{Id=2,Name="Emily Employee",Role=4},
                new User{Id=3,Name="Sam Supervisor",Role=3},
                new User{Id=4,Name="Mary Manager",Role=2},
                new User{Id=5,Name="Steve Trainer",Role=5}
            };

            //Act
            Subordinates subordinates = new Subordinates(1, new List<Role>(), users);
            var results = subordinates.getSubordinates();
            
            //Assert
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod()]
        public void getSubordinatesTest_EmptyUsers()
        {
            //Arrange
            List<Role> roles=new List<Role>
            {
                new Role{Id=1,Name="System Administrator",Parent=0},
                new Role{Id=2,Name="Location Manager",Parent=1},
                new Role{Id=3,Name="Supervisor",Parent=2},
                new Role{Id=4,Name="Employee",Parent=3},
                new Role{Id=5,Name="Trainer",Parent=3}
            };

            //Act
            Subordinates subordinates = new Subordinates(1, roles, new List<User>());
            var results = subordinates.getSubordinates();

            //Assert
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod()]
        public void getSubordinatesTest_UserId_0()
        {
            //Arrange
            List<Role> roles = new List<Role>
            {
                new Role{Id=1,Name="System Administrator",Parent=0},
                new Role{Id=2,Name="Location Manager",Parent=1},
                new Role{Id=3,Name="Supervisor",Parent=2},
                new Role{Id=4,Name="Employee",Parent=3},
                new Role{Id=5,Name="Trainer",Parent=3}
            };

            List<User> users = new List<User>
            {
                new User{Id=1,Name="Adam Admin",Role=1},
                new User{Id=2,Name="Emily Employee",Role=4},
                new User{Id=3,Name="Sam Supervisor",Role=3},
                new User{Id=4,Name="Mary Manager",Role=2},
                new User{Id=5,Name="Steve Trainer",Role=5}
            };

            //Act
            Subordinates subordinates = new Subordinates(0, roles, users);
            var results = subordinates.getSubordinates();
            
            //Assert
            Assert.AreEqual(results.Count, 0);
        }

        [TestMethod()]
        public void getSubordinatesTest_UserId_1()
        {
            //Arrange
            List<Role> roles = new List<Role>
            {
                new Role{Id=1,Name="System Administrator",Parent=0},
                new Role{Id=2,Name="Location Manager",Parent=1},
                new Role{Id=3,Name="Supervisor",Parent=2},
                new Role{Id=4,Name="Employee",Parent=3},
                new Role{Id=5,Name="Trainer",Parent=3}
            };

            List<User> users = new List<User>
            {
                new User{Id=1,Name="Adam Admin",Role=1},
                new User{Id=2,Name="Emily Employee",Role=4},
                new User{Id=3,Name="Sam Supervisor",Role=3},
                new User{Id=4,Name="Mary Manager",Role=2},
                new User{Id=5,Name="Steve Trainer",Role=5}
            };

            List<User> suborindatesUsers = new List<User>
            {
                new User{Id=4,Name="Mary Manager",Role=2},
                new User{Id=3,Name="Sam Supervisor",Role=3},
                new User{Id=2,Name="Emily Employee",Role=4},
                new User{Id=5,Name="Steve Trainer",Role=5}
            };

            //Act
            Subordinates subordinates = new Subordinates(1, roles, users);
            string actualUsers = JsonSerializer.Serialize(subordinates.getSubordinates());
            string expectedUsers = JsonSerializer.Serialize(suborindatesUsers);
            
            //Assert
            Assert.AreEqual(expectedUsers, actualUsers);
        }

        [TestMethod()]
        public void getSubordinatesTest_UserId_3()
        {
            //Arrange
            List<Role> roles = new List<Role>
            {
                new Role{Id=1,Name="System Administrator",Parent=0},
                new Role{Id=2,Name="Location Manager",Parent=1},
                new Role{Id=3,Name="Supervisor",Parent=2},
                new Role{Id=4,Name="Employee",Parent=3},
                new Role{Id=5,Name="Trainer",Parent=3}
            };

            List<User> users = new List<User>
            {
                new User{Id=1,Name="Adam Admin",Role=1},
                new User{Id=2,Name="Emily Employee",Role=4},
                new User{Id=3,Name="Sam Supervisor",Role=3},
                new User{Id=4,Name="Mary Manager",Role=2},
                new User{Id=5,Name="Steve Trainer",Role=5}
            };

            List<User> suborindatesUsers = new List<User>
            {
                new User{Id=2,Name="Emily Employee",Role=4},
                new User{Id=5,Name="Steve Trainer",Role=5}
            };

            //Act
            Subordinates subordinates = new Subordinates(3, roles, users);
            string actualUsers = JsonSerializer.Serialize(subordinates.getSubordinates());
            string expectedUsers = JsonSerializer.Serialize(suborindatesUsers);

            //Assert
            Assert.AreEqual(expectedUsers, actualUsers);
        }
    }
}