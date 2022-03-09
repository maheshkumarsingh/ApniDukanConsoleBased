using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniDukan
{
    public class UserMaster
    {
        public int UserId { get; set; }

        public string UserFName { get; set; }

        public string UserLName { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public double UserConatct { get; set; }

        public DateTime UserJoinedDate { get; set; }

        public override string ToString()
        {
            return String.Format("{0,-10} {1,-15} {2,-15} {3,-30} {4,-20} {5,-20}", UserId,
                                        UserFName, UserLName, UserEmail, UserConatct,UserJoinedDate.ToShortDateString()); 
        }
    }
}
