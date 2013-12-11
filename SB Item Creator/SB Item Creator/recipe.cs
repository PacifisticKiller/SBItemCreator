using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB_Item_Creator
{
    class recipe
    {
        public static string rp1, rp2, rp3, rp9, rp10, rp11, rp12;
        public static string create,create2,create3;

        public static void updatevalus()
        {
            rp1 = "{"+Environment.NewLine;
            rp2 = "  \"input\" : ["+Environment.NewLine;
            rp9 = "  ],"+Environment.NewLine;
            rp10 = "  \"output\" : { \"item\" : \""+Value.itemfilename+"\", \"count\" : "+Value.im+" },"+Environment.NewLine;
            rp11 = "  \"groups\" : [ \""+Value.craftingstation+"\", \"weapons\", \"all\" ]"+Environment.NewLine;
            rp12 = "}";
        }
        public static void updateitem()
        {
            rp3 = "    { \"item\" : \"" + Value.item1 + "\", \"count\" : " + Value.ita1 + " }";
        }
        public static void creation()
        {
            create = rp1 + rp2;
            create2 = rp9 + rp10 + rp11 + rp12;
        }
    }
}
