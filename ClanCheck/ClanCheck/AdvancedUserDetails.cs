using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanCheck
{
    public class AdvancedUserDetails
    {
        public Response Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public MessageData MessageData { get; set; }
    }

    public class UserInfo
    {
        public string iconPath { get; set; }
        public int membershipType { get; set; }
        public string membershipId { get; set; }
        public string displayName { get; set; }
    }

    public class Race
    {
        public long raceHash { get; set; }
        public int raceType { get; set; }
        public string raceName { get; set; }
        public string raceNameMale { get; set; }
        public string raceNameFemale { get; set; }
        public string raceDescription { get; set; }
        public object hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }

    public class Gender
    {
        public object genderHash { get; set; }
        public int genderType { get; set; }
        public string genderName { get; set; }
        public string genderDescription { get; set; }
        public object hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }

    public class CharacterClass
    {
        public object classHash { get; set; }
        public int classType { get; set; }
        public string className { get; set; }
        public string classNameMale { get; set; }
        public string classNameFemale { get; set; }
        public string classIdentifier { get; set; }
        public string mentorVendorIdentifier { get; set; }
        public object hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }

    public class LevelProgression
    {
        public int dailyProgress { get; set; }
        public int weeklyProgress { get; set; }
        public int currentProgress { get; set; }
        public int level { get; set; }
        public int step { get; set; }
        public int progressToNextLevel { get; set; }
        public int nextLevelAt { get; set; }
        public long progressionHash { get; set; }
    }

    public class Character
    {
        public string characterId { get; set; }
        public object raceHash { get; set; }
        public object genderHash { get; set; }
        public object classHash { get; set; }
        public object emblemHash { get; set; }
        public Race race { get; set; }
        public Gender gender { get; set; }
        public CharacterClass characterClass { get; set; }
        public string emblemPath { get; set; }
        public string backgroundPath { get; set; }
        public int level { get; set; }
        public int powerLevel { get; set; }
        public DateTime dateLastPlayed { get; set; }
        public string membershipId { get; set; }
        public int membershipType { get; set; }
        public LevelProgression levelProgression { get; set; }
        public bool isPrestigeLevel { get; set; }
        public int genderType { get; set; }
        public int classType { get; set; }
        public double percentToNextLevel { get; set; }
        public long currentActivityHash { get; set; }
    }

    public class DestinyAccount
    {
        public UserInfo userInfo { get; set; }
        public int grimoireScore { get; set; }
        public List<Character> characters { get; set; }
        public string lastPlayed { get; set; }
        public int versions { get; set; }
    }

    public class BungieNetUser
    {
        public string membershipId { get; set; }
        public string uniqueName { get; set; }
        public string displayName { get; set; }
        public int profilePicture { get; set; }
        public int profileTheme { get; set; }
        public int userTitle { get; set; }
        public string successMessageFlags { get; set; }
        public bool isDeleted { get; set; }
        public string about { get; set; }
        public string firstAccess { get; set; }
        public string lastUpdate { get; set; }
        public string xboxDisplayName { get; set; }
        public bool showActivity { get; set; }
        public string locale { get; set; }
        public bool localeInheritDefault { get; set; }
        public bool showGroupMessaging { get; set; }
        public string profilePicturePath { get; set; }
        public string profileThemeName { get; set; }
        public string userTitleDisplay { get; set; }
        public string statusText { get; set; }
        public string statusDate { get; set; }
    }

    public class Clan
    {
        public string groupId { get; set; }
        public int platformType { get; set; }
    }
}
