using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Helpers.Articles.Response
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class GetOneResult<TEntity> : Result where TEntity : class, new()
    {
        public TEntity Entity { get; set; }
    }
    public class GetManyResult<TEntity> : Result where TEntity : class, new()
    {
        public IEnumerable<TEntity> Result { get; set; }
    }
}
