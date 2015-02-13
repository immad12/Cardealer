using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Vechile
    {
        double price { get; set; }
        String model { get; set; }
        String Color{ get; set; }

        enum CarState { Commision, Sold, Leased };

        
    }

    class Car : Vechile
    {
 
    }

    class Truck : Vechile
    {

    }
}
