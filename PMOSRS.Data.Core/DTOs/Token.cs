using System;

namespace PMOSRS.Data.Core.DTOs
{
    public class Token
    {
        public string AccessToken { get; set; }

        public DateTime Expiration { get; set; }
    }
}
