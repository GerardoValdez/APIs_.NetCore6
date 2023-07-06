using System.Net;

namespace ApiAuto.Result
{
    public class ResultadoBase
    {
        public bool Ok { get; set; } = true;
        public string MensajeError { get; set; } = "";

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        public void setearMensajeError(string mensaje, HttpStatusCode statusCode)
        {
            Ok = false;
            MensajeError = mensaje;
            StatusCode = statusCode;
        }
    

    }
}
