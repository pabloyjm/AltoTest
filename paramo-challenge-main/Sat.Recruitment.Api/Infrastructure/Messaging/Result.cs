using System;

namespace Sat.Recruitment.Api.Infrastructure.Messaging
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
