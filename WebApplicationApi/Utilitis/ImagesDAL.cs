using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplicationApi.Utilitis
{
    public class ImagesDAL
    {
        public string SaveImage(string strm, string Id)
        {

            string convert = strm.Replace("data:image/jpeg;base64,", String.Empty);

            var base64string = convert;
            var base64array = Convert.FromBase64String(base64string);
            var uid = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "") + ".jpg";
            string route = "/wwwroot/images/user/" + Id.ToString();
            string routePrincipal = Environment.CurrentDirectory;

            Path.Combine($"{Environment.CurrentDirectory}/wwwroot/images/user/" + Id);  //"/wwwroot/images/user/" + idCustomer;

            if (!Directory.Exists(Path.Combine($"{routePrincipal + route}")))
            {
                Directory.CreateDirectory(Path.Combine($"{routePrincipal + route}"));
            }

            var filePath = Path.Combine($"{routePrincipal + route + "/" + uid}");

            System.IO.File.WriteAllBytes(filePath, base64array);
            return Convert.ToString(uid);
        }
    }
}
