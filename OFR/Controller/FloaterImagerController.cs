using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFR.Controller
{
    public class FloaterImagerController
    {

        public string GenerateImageSourceUri(string imageName)
        {
            return "pack://application:,,,/Include/" + imageName;
        }
    }
}
