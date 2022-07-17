using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace Thales.DataAccessLayer
{
    /// <summary>
    /// This Class allow to make request API-REST through RestSharp package  
    /// </summary>
    public class RequestByAPI
    {
        /// <summary>
        /// Constructor of Class
        /// </summary>
        public RequestByAPI() {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url"> URL or endpoint for consume API Rest </param>
        /// <param name="sendMethod">Method HTTP (GET, PUT, POST, DELETE) for send data or query</param>
        /// <param name="Sendbody">Data body to share or consulting</param>
        /// <returns></returns>
        public RestResponse RunPetition(string Url,Method sendMethod, object Sendbody)
        {
            try
            {
                System.Console.WriteLine("Entro en enviar peticion IRESTRESPONSE ");
                RestClient client = new RestClient(Url);
                RestRequest request = new RestRequest(Url,sendMethod);
                string jsonString = JsonConvert.SerializeObject(Sendbody);
                request.AddParameter("ContenType", ContentType.Json, ParameterType.RequestBody);
                request.AddJsonBody(Sendbody);
                request.RequestFormat = DataFormat.Json;
                System.Console.WriteLine("EJECUTO PETICION ");
                RestResponse response = client.Execute(request);
                return response;
            }
            catch (System.Exception x)
            {
                System.Console.WriteLine("ocurrio un error rest : " + x.Message);
                System.Console.ReadKey();
                return null;
            }
        }
    }
}
