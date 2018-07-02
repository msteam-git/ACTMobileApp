using System;
namespace Polcirkelleden
{
    public class QRData
    {
        public Type GetPage(string data)
        {
            switch(data)
            {
                case "1":
                    return typeof(ObjectOne);
            }

            return null;
        }
    }
}
