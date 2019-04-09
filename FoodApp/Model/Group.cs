using System;
using System.Text;

namespace FoodApp.Model
{
    public class Group
    {
        
        public string Id { get; set; }

        public string GroupCode { get; set; }

        public Group()
        {
            Id = Guid.NewGuid().ToString();
            GroupCode = RandomString();
        }

        private string RandomString()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 4; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
