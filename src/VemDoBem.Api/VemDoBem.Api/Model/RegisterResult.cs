using System.Collections.Generic;

namespace VemDoBem.Api.Model
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
