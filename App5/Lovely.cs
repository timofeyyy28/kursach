using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    internal class Lovely
    {
        private static int current = 0;
        public static List<int> Love { get; set; }
        public static async Task UpdateLoveAsync(int id)
        {
            Love = await User.GetFavouriteAsync(id);
        }
        public static int Current
        {
            get { return current;}
            set 
            {
                if (current < Love.Count - 1)
                {
                    current = value;
                }
                else
                {
                    current = 0;
                }
                
            }
        }
        

    }
}
