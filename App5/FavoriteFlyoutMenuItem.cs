using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    public class FavoriteFlyoutMenuItem
    {
        public FavoriteFlyoutMenuItem()
        {
            TargetType = typeof(FavoriteFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}