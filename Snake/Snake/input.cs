using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Snake
{
    class input
    {

        public static Hashtable keys = new Hashtable();
        public static void ChangeState(Keys key, bool state)
        {
            keys[key] = state;
        }

        public static bool KeyPress(Keys key)
        {
           
            if (keys[key] == null) return false;
            return (bool)keys[key];
        }
    }
}
