using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pandora.NetStandard.Core.Util
{
    public class BLResponse
    {
        public List<string> Errors { get; set; }

        public bool HasError { get { return Errors.Any(); } }

        public int ErrorsCount { get { return Errors.Count; } }

        public HttpStatusCode ResponseCode { get; set; }

        public BLResponse()
        {
            Errors = new List<string>();
        }

        public static BLResponse GetVoidResponse()
        {
            return new BLResponse { ResponseCode = HttpStatusCode.OK };
        }
    }

    public class BLSingleResponse<TDto> : BLResponse
    {
        public TDto Data { get; set; }
    }

    public class BLListResponse<TDto> : BLResponse
    {
        public IEnumerable<TDto> Data { get; set; }
    }

    public class BLPagedResponse<TDto> : BLListResponse<TDto>
    {
        public int CurrentPage { get; set; }

        public int RowsPerPage { get; set; }

        public int CollectionLength { get; set; }

        public double TotalPages { get; set; }
    }

}
