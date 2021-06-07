using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class Service
    {
        /// <summary>
        /// For String Array
        /// </summary>
        /// <returns>List of strings</returns>
        public async Task<IEnumerable<string>> GetStringArray()
        {
            IEnumerable<string> someStrings = new[] { "abc", "cat", "bad", "hat" };

            await Task.Delay(100);

            return someStrings;
        }

        /// <summary>
        /// For get users data
        /// </summary>
        /// <returns>List of the users data</returns>
        public async Task<IEnumerable<User>> GetUsersData()
        {
            User[] users = new User[] {
                new User{ Id = 1, Name = "Abhishek", Email = "abhishek.patel@gmail.com", Address = "Rajkot"},
                new User{ Id = 2, Name = "Parth", Email = "parth.patel@gmail.com", Address = "Ahmedabad"},
                new User{ Id = 3, Name = "Darshit", Email = "darshit.patel@gmail.com", Address = null},
            };

            await Task.Delay(100);

            return users;
        }

        /// <summary>
        /// for generate table of given number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>array of int</returns>
        public int[] GetTable(int number)
        {
            int[] table = new int[10];
            for (int i = 0; i <= 9; i++)
            {
                table[i] = (i + 1) * number;
            }
            return table;
        }

        /// <summary>
        /// For Get Name
        /// </summary>
        /// <returns>name</returns>
        public string GetName()
        {
            return "parth nonghanvadra";
        }

        /// <summary>
        /// For Get Submission date
        /// </summary>
        /// <returns>submission date</returns>
        public DateTime GetSubmissionDate()
        {
            return new DateTime(2021, 04, 23);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
