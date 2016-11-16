using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClanCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var userList = new List<ClanMember>();
            var advancedUserList = new List<HelperUserModel>();

            //var groupDetails = MakeBungieRequest("Group/Name/Avalanche UK/");
            var currentPage = 1;
            var fullClan = false;

            do
            {
                var groupMembers = MakeBungieRequest($"Group/1486166/ClanMembers/?currentPage={currentPage++}&platformType=1");
                var serializedMembers = JsonConvert.DeserializeObject<ClanMembership>(groupMembers);
                userList.AddRange(serializedMembers.Response.results.ToList());

                if (!serializedMembers.Response.hasMore)
                    fullClan = true;

            } while (!fullClan);

            foreach (var user in userList)
            {
                var advancedUserDetails = JsonConvert.DeserializeObject<AdvancedUserDetails>(MakeBungieRequest($"User/GetBungieAccount/{user.membershipId}/1"));
                var lastPlayed = advancedUserDetails.Response.destinyAccounts[0].characters.Max(c => c.dateLastPlayed);

                var helperModel = new HelperUserModel()
                {
                    Username = advancedUserDetails.Response.bungieNetUser.displayName,
                    Gamertag = advancedUserDetails.Response.bungieNetUser.xboxDisplayName,
                    LastSeen = lastPlayed
                };

                advancedUserList.Add(helperModel);
            }

            using (var w = new StreamWriter(@"C:\Users\MattB\Desktop\ClanDetails.csv"))
            {
                foreach(var user in advancedUserList)
                {
                    var line = string.Format("{0},{1},{2}", user.Username, user.Gamertag, user.LastSeen);
                    w.WriteLine(line);
                    w.Flush();
                }
            }
        }

        private static string MakeBungieRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://www.bungie.net/Platform/{url.Trim()}");

            request.Headers.Add("X-API-Key", @"C95158E80AD34135845C7D6118F2A7B2");
            request.Headers.Add("X-csrf", @"6645961750234506012");
            request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            request.Accept = "*/*";
            request.KeepAlive = true;
            request.AutomaticDecompression = DecompressionMethods.GZip;
            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.CachePolicy = noCachePolicy;

            var response = (HttpWebResponse)request.GetResponse();
            var responseHeader = response.Headers.ToString();

            // Open the stream using a StreamReader for easy access.
            var reader = new StreamReader(response.GetResponseStream());
            var responseBody = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            response.Close();

            return responseBody;
        }
    }

    public class HelperUserModel
    {
        public string Username { get; set; }
        public string Gamertag { get; set; }
        public DateTime LastSeen { get; set; }
    }
}
