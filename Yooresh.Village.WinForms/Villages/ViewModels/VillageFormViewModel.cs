using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using Yooresh.Client.WinForms.Common;
using Yooresh.Client.WinForms.Common.ViewModels;
using Yooresh.Client.WinForms.Models;

namespace Yooresh.Client.WinForms.Villages.ViewModels;

public class VillageFormViewModel : BaseViewModel
{
    public Village Village { get; set; }

    public VillageFormViewModel(IRestClient restClient)
        : base(restClient)
    {
    }

    public async Task<Village> GetVillage()
    {
        var request = new RestRequest
        {
            Method = Method.Get,
            Resource = "/api/Villages",
            Authenticator = new HttpBasicAuthenticator(Statics.Email, Statics.Password)
        };

        var response = await RestClient.ExecuteAsync(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var village = JsonConvert.DeserializeObject<Village>(response.Content);
            Village = village;
            return village;
        }

        throw new Exception($"Login failed for unknown reason.{Environment.NewLine}Make sure you are connected to the Internet");
    }
}
