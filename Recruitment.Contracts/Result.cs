using System.Collections.Generic;

namespace Recruitment.Contracts
{
    public class Result<T>
    {
        public T Data { get; set; }

        public List<string> ErrorCodes { get; set; }

    }
}
