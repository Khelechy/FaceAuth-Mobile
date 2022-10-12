using FaceAuthMobile.Models.RequestModels;
using FaceAuthMobile.Models.ResponseModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaceAuthMobile.Managers
{
    public class ApiManager
    {
        public async Task<Tuple<string, AddPersonResponseModel>> AddPerson(AddPersonRequestModel requestModel)
        {
            string error = "";
            try
            {
                var client = new RestClient(AppConfig.BaseURL);
                var request = new RestRequest("api/faceauth/add-person", Method.POST);
                var requestBody = JsonConvert.SerializeObject(requestModel);
                request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
                var response = await client.ExecuteAsync<AddPersonResponseModel>(request);
                if((int)response.StatusCode == 200)
                {
                    return new Tuple<string, AddPersonResponseModel>(" ",  response.Data);
                }
                else
                {
                    error = response.Content;
                    return new Tuple<string, AddPersonResponseModel>(error, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Tuple<string, AddPersonResponseModel>(ex.Message, null);
            }
        }

        public async Task<Tuple<string, AddPersonResponseModel>> IdentifyPerson(object requestModel)
        {
            string error = "";
            try
            {
                var client = new RestClient(AppConfig.BaseURL);
                var request = new RestRequest("api/faceauth/recognize-person", Method.GET);
                var requestBody = JsonConvert.SerializeObject(requestModel);
                request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
                var response = await client.ExecuteAsync<AddPersonResponseModel>(request);
                if ((int)response.StatusCode == 200)
                {
                    return new Tuple<string, AddPersonResponseModel>(" ", response.Data);
                }
                else
                {
                    error = response.Content;
                }
                return new Tuple<string, AddPersonResponseModel>(error, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Tuple<string, AddPersonResponseModel>(ex.Message, null);
            }
        }

        public async Task<Tuple<string, List<AddPersonResponseModel>, int>> GetStaffs()
        {
            string error = "";
            try
            {
                var client = new RestClient(AppConfig.BaseURL);
                var request = new RestRequest("api/faceauth/get-staffs", Method.GET);
                var response = await client.ExecuteAsync<List<AddPersonResponseModel>>(request);
                if ((int)response.StatusCode == 200)
                {
                    return new Tuple<string, List<AddPersonResponseModel>, int>(" ", response.Data, (int)response.StatusCode);
                }
                else
                {
                    error = response.Content;
                    return new Tuple<string, List<AddPersonResponseModel>, int>(error, null, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Tuple<string, List<AddPersonResponseModel>, int>(ex.Message, null, 0);
            }
        }

        public async Task<Tuple<string, List<GetLogsResponseModel>, int>> GetLogs()
        {
            string error = "";
            try
            {
                var client = new RestClient(AppConfig.BaseURL);
                var request = new RestRequest("api/faceauth/get-logs", Method.GET);
                var response = await client.ExecuteAsync<List<GetLogsResponseModel>>(request);
                if ((int)response.StatusCode == 200)
                {
                    return new Tuple<string, List<GetLogsResponseModel>, int>(" ", response.Data,(int)response.StatusCode);
                }
                else
                {
                    error = response.Content;
                    return new Tuple<string, List<GetLogsResponseModel>, int>(error, null,0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Tuple<string, List<GetLogsResponseModel>, int>(ex.Message, null, 0);
            }
        }
    }
}
