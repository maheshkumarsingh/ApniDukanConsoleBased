using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Cart
    {
        public int CartID { get; set; }

        public string UserMailID { get; set; }

        public Product ProductObj { get; set; }  
        public DateTime CartCreatedDate { get; set; }

        public override string ToString()
        {
            string data = String.Format("\n\n{0,-10} {1,-30} {2,-30}","Cart ID","User EmailID","Cart Created Date");
            data += String.Format("\n{0,-10} {1,-30} {2,-30}\n\n", CartID,UserMailID,CartCreatedDate.ToShortDateString());
            data+= ProductObj.ToString();
            return data;
        }

        //public string PrintStream()
        //{
        //    string data = String.Format("{0,-10} {1,-10} {2,")
        //}
    }
}
