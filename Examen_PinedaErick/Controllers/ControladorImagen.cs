using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Examen_PinedaErick.Entidades;
using Examen_PinedaErick.OCR;
using Examen_PinedaErick.DetectarObjetos;
namespace Examen_PinedaErick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorImagen : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Picture>> PostPictureText(string direccion)
        {
           
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-type", "application/octet-stream");
            api.Headers.Add("Ocp-Apim-Subscription-Key", "c4557d4a6a5f47e9803047319c7aadf7");
            var qs = "language=es&language=true&model-version=latest";
            var url = "https://eastus.api.cognitive.microsoft.com/vision/v3.2/ocr";


            var resp = api.UploadFile(url + "?" + qs, "POST", direccion);
            var json = System.Text.Encoding.UTF8.GetString(resp);
            var texto = Newtonsoft.Json.JsonConvert.DeserializeObject<respuesta>(json);


           
            var apiO = new System.Net.WebClient();
            apiO.Headers.Add("Content-type", "application/octet-stream");
            apiO.Headers.Add("Ocp-Apim-Subscription-Key", "c4557d4a6a5f47e9803047319c7aadf7");
            var qsO = "model-version=latest";
            var urlO = "https://eastus.api.cognitive.microsoft.com/vision/v3.2/detect";


            var respO = apiO.UploadFile(urlO + "?" + qsO, "POST", direccion);
            var jsonO = Encoding.UTF8.GetString(respO);
            var objetos = Newtonsoft.Json.JsonConvert.DeserializeObject<detectarRespuesta>(jsonO);

            return Ok(textoOcr(texto) + "\n" +  objetosOcr(objetos));
        }
        private static string textoOcr(respuesta resp)
        {
            var txt = "texto: \n";


            foreach (var region in resp.regions)
            {
                foreach (var line in region.lines)
                {
                    foreach (var word in line.words)
                    {
                        txt += word.text + " ";
                    }
                    txt += "\n";
                }
                txt += "\n";
            }
            return txt;
        }
        private static string objetosOcr(detectarRespuesta resp)
        {
            var txt = "Lista de objetos:\n";
            foreach (var @object in resp.objects)
            {
                txt += "Object: " + @object.Object + "\n";
                Parent aux = @object.parent;
                var space = "";
                while (aux != null)
                {
                    txt += space + "  Parent: " + aux.Object + "\n";
                    aux = aux.parent;
                    space += "  ";
                }
                space = "";
            }
            return txt;
            
        }
    }
}
