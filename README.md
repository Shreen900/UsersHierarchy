# BigTinCans
Users Hierarchy
---------------

The Users Hierarchy application reads the groups of roles and users, and retrieves 
a set of subordinates for a given user Id.
The roles and users are expected to be in a text file on "D" drive defaulted as "input.txt", 
with an option to change the input file path at the beginning of the program.
The output is displayed on the console in a readable format.
There is an option to try more rounds by selecting "y" to "One more round?" question at the 
end of each process and then entering a new user Id. 


REQUIREMENTS
------------

This program requires a text input file on D drive, containing two groups: roles and users, 
separated by semi-colon.
Acceptable format would be as follows:
roles = [
	{
		"Id": 1,
		"Name": "System Administrator",
		"Parent": 0
	},
	{
		"Id": 2,
		"Name": "Location Manager",
		"Parent": 1
	}
];
users = [
	{
		"Id": 1,
		"Name": "Adam Admin",
		"Role": 1
	},
	{
		"Id": 4,
		"Name": "Mary Manager",
		"Role": 2
	}
];


CONFIGURATION
-------------

Permissions to read the input file in the specified path.

