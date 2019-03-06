using System.Collections.Generic;
using System.Linq;

namespace NetCore.Core.Bases
{
    public class BLResponse<TDto>
    {
        public TDto Data { get; set; }

        public int Count { get { return Errors.Count; } }

        public bool HasErrors { get { return Errors.Any(); } }

        public string ErrorCode { get; set; }

        public List<string> Errors { get; set; }

        public BLResponse()
        {
            Errors = new List<string>();
        }
    }
}
