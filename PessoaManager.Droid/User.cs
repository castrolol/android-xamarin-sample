using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace PessoaManager.Droid
{
    public class User
    {
       public String Login
        {
            get;
            set;
        }

        [JsonProperty("avatar_url")]
        public String AvatarUrl
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public int Followers
        {
            get;
            set;
        }

        public int Following
        {
            get;
            set;
        }

    }
}
