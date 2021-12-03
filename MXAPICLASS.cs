using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MXAPICLASS
    {
        private string ApiBaseUri { get; set; }
        private string ClientId { get; set; }
        private string ApiKey { get; set; }
        private string Base64Authorization { get; set; }

        public MXAPICLASS()
        {
            SetConfigSettings();
        }

        private void SetConfigSettings()
        {
            ApiBaseUri = "https://int-api.mx.com/";
            ClientId = "25f81b9f-f8fc-42d9-bb9c-661fdd987115";
            ApiKey = "f1a3b84b5ff6c84c76bcdec0a36c84e17c59e8f4";
            Base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ClientId}:{ApiKey}"));
        }

        //GET {{baseUrl}}/users/:user_guid/accounts?page=1&records_per_page=10
        public object ListAccounts(string userId,string PageNo, string recordsperpage)
        {
            string apiCall = $"{ApiBaseUri}users/{userId}/accounts?page={PageNo}&records_per_page={recordsperpage}";
            return MxApiGetCall(apiCall, true);
        }
        //GET {{baseUrl}}/users/:user_guid/accounts/:account_guid
        public object ReadAccount(string userId, string accountId, string recordsperpage)
        {
            string apiCall = $"{ApiBaseUri}users/{userId}/accounts{accountId}";
            return MxApiGetCall(apiCall, true);
        }
        //PUT {{baseUrl}}/users/:user_guid/members/:member_guid/accounts/:account_guid
        //GET {{baseUrl}}/users/:user_guid/accounts/:account_guid/account_numbers?page=1&records_per_page=10
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/account_numbers?page=1&records_per_page=10
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/account_owners?page=1&records_per_page=10
        //GET {{baseUrl}}/users/:user_guid/categories?page=1&records_per_page=10
        //POST {{baseUrl}}/users/:user_guid/categories
        //GET {{baseUrl}}/users/:user_guid/categories/default
        //DELETE {{baseUrl}}/users/:user_guid/categories/:category_guid
        //GET {{baseUrl}}/users/:user_guid/categories/:category_guid
        //PUT {{baseUrl}}/users/:user_guid/categories/:category_guid
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/challenges?page=1&records_per_page=10
        //POST {{baseUrl}}/users/:user_guid/connect_widget_url
        //GET {{baseUrl}}/institutions/:institution_code/credentials?page=1&records_per_page=10
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/credentials?page=1&records_per_page=10
        //POST {{baseUrl}}/transactions/enhance
        //GET {{baseUrl}}/users/:user_guid/holdings?from_date=2015-09-20&page=1&records_per_page=10&to_date=2019-10-20
        //GET {{baseUrl}}/users/:user_guid/holdings/:holding_guid
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/holdings?from_date=2015-09-20&page=1&records_per_page=10&to_date=2019-10-20
        //GET {{baseUrl}}/institutions?name=chase&supports_account_identification=true&supports_account_statement=true&supports_account_verification=true&supports_transaction_history=true
        //GET {{baseUrl}}/institutions/favorites?page=1&records_per_page=10
        //GET {{baseUrl}}/institutions/:institution_code
        //GET {{baseUrl}}/users/:user_guid/members?page=1&records_per_page=10
        //POST {{baseUrl}}/users/:user_guid/members
        //DELETE {{baseUrl}}/users/:user_guid/members/:member_guid
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid
        //PUT {{baseUrl}}/users/:user_guid/members/:member_guid
        //POST {{baseUrl}}/users/:user_guid/members/:member_guid/aggregate
        //POST {{baseUrl}}/users/:user_guid/members/:member_guid/check_balance
        //POST {{baseUrl}}/users/:user_guid/members/:member_guid/extend_history
        //POST {{baseUrl}}/users/:user_guid/members/:member_guid/fetch_statements
        //POST {{baseUrl}}/users/:user_guid/members/:member_guid/identify
        //PUT {{baseUrl}}/users/:user_guid/members/:member_guid/resume
        //POST {{baseUrl}}/users/:user_guid/members/:member_guid/verify
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/status
        //GET {{baseUrl}}/merchants?page=1&records_per_page=10
        //GET {{baseUrl}}/merchants/:merchant_guid
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/oauth_window_uri?referral_source=APP&ui_message_webview_url_scheme=mx
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/statements?page=1&records_per_page=10
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/statements/:statement_guid
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/statements/{{statement_guid}}.pdf
        //GET {{baseUrl}}/users/:user_guid/tags?page=1&records_per_page=10
        //POST {{baseUrl}}/users/:user_guid/tags
        //DELETE {{baseUrl}}/users/:user_guid/tags/:tag_guid
        //GET {{baseUrl}}/users/:user_guid/tags/:tag_guid
        //PUT {{baseUrl}}/users/:user_guid/tags/:tag_guid
        //GET {{baseUrl}}/users/:user_guid/taggings?page=1&records_per_page=10
        //POST {{baseUrl}}/users/:user_guid/taggings
        //DELETE {{baseUrl}}/users/:user_guid/taggings/:tagging_guid
        //GET {{baseUrl}}/users/:user_guid/taggings/:tagging_guid
        //PUT {{baseUrl}}/users/:user_guid/taggings/:tagging_guid
        //GET {{baseUrl}}/users/:user_guid/accounts/:account_guid/transactions?from_date=2015-09-20&page=1&records_per_page=10&to_date=2019-10-20
        //GET {{baseUrl}}/users/:user_guid/members/:member_guid/transactions?from_date=2015-09-20&page=1&records_per_page=10&to_date=2019-10-20
        //GET {{baseUrl}}/users/:user_guid/tags/:tag_guid/transactions
        //GET {{baseUrl}}/users/:user_guid/transactions?from_date=2015-09-20&page=1&records_per_page=10&to_date=2019-10-20
        //GET {{baseUrl}}/users/:user_guid/transactions/:transaction_guid
        //PUT {{baseUrl}}/users/:user_guid/transactions/:transaction_guid
        //GET {{baseUrl}}/users/:user_guid/transaction_rules?page=1&records_per_page=10
        //POST {{baseUrl}}/users/:user_guid/transaction_rules
        //DELETE {{baseUrl}}/users/:user_guid/transaction_rules/:transaction_rule_guid
        //GET {{baseUrl}}/users/:user_guid/transaction_rules/:transaction_rule_guid
        //PUT {{baseUrl}}/users/:user_guid/transaction_rules/:transaction_rule_guid
        //GET {{baseUrl}}/users?page=1&records_per_page=10
        public object ListofUsers(string startpage, string recordsperpage)
        {
            string apiCall = $"{ApiBaseUri}users?page={startpage}&records_per_page={recordsperpage}";
            return MxApiGetCall(apiCall, true);
        }
        //POST {{baseUrl}}/users
        public object CreateUser(string id, bool is_disabled, string email, string firstname, string lastname )
        {
            string apiCall = $"{ApiBaseUri}users";
            Root root = new Root()
            {
                user = new User()
                {
                    id = id,
                    is_disabled = is_disabled,
                    email = email,                    
                    metadata = firstname
                },
            };
            return MxApiPostCall(apiCall, true, root);
        }
        //DELETE {{baseUrl}}/users/:user_guid
        //GET {{baseUrl}}/users/:user_guid
        //PUT {{baseUrl}}/users/:user_guid
        //POST {{baseUrl}}/users/:user_guid/widget_urls
        private object MxApiGetCall(string apiCall, bool addAcceptHeader = false)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",$"{Base64Authorization}");
                    if (addAcceptHeader)
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/vnd.mx.api.v1+json");

                    var responseTask = httpClient.GetAsync(apiCall);
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        return readTask.Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private object MxApiPostCall(string apiCall, bool addAcceptHeader = false, object content = null)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", $"{Base64Authorization}");
                    if (addAcceptHeader)
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/vnd.mx.api.v1+json");

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    string json = JsonConvert.SerializeObject(content);
                    StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                    var responseTask = httpClient.PostAsync(apiCall,data);
                    var result =  responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        return readTask.Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public class User
        {
            public string email { get; set; }
            public string id { get; set; }
            public bool is_disabled { get; set; }
            public string metadata { get; set; }
        }
        public class Metadata
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
        }
        public class Root
        {
            public User user { get; set; }
        }
    }
}
