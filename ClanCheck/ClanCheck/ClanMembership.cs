using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanCheck
{
    public class ClanMembership
    {
        public Response Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public MessageData MessageData { get; set; }
    }

    public class DestinyUserInfo
    {
        public string iconPath { get; set; }
        public int membershipType { get; set; }
        public string membershipId { get; set; }
        public string displayName { get; set; }
    }

    public class BungieNetUserInfo
    {
        public string iconPath { get; set; }
        public int membershipType { get; set; }
        public string membershipId { get; set; }
        public string displayName { get; set; }
    }

    public class ClanMember
    {
        public DestinyUserInfo destinyUserInfo { get; set; }
        public BungieNetUserInfo bungieNetUserInfo { get; set; }
        public bool hasPendingApplication { get; set; }
        public bool hasRated { get; set; }
        public string approvalDate { get; set; }
        public int rating { get; set; }
        public string groupId { get; set; }
        public int membershipType { get; set; }
        public string membershipId { get; set; }
        public bool isMember { get; set; }
        public int memberType { get; set; }
        public bool isOriginalFounder { get; set; }
    }

    public class Query
    {
        public string groupId { get; set; }
        public int memberType { get; set; }
        public int platformType { get; set; }
        public int sort { get; set; }
        public string nameSearch { get; set; }
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
    }

    public class Response
    {
        public List<ClanMember> results { get; set; }
        public int totalResults { get; set; }
        public bool hasMore { get; set; }
        public Query query { get; set; }
        public bool useTotalResults { get; set; }

        public List<DestinyAccount> destinyAccounts { get; set; }
        public BungieNetUser bungieNetUser { get; set; }
        public List<Clan> clans { get; set; }
        public List<object> destinyAccountErrors { get; set; }
    }

    public class MessageData
    {
    }
}
