using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    //key classe zou je niet moeten hebben maar de user vragen deze te onthouden dan wel ergens veilig op te slaan
    public class Key
    {
        String keyStr = "4F2C326181B87C45CD2484EE8927A3294D1C7EA8D47464436E0B7665B5371442";
        String IVStr = "DED762AD4E79C30E98A7836870555D65";

        public string getKey()
        {
            return keyStr;
        }

        public string getIV()
        {
            return IVStr;
        }
    }



}
