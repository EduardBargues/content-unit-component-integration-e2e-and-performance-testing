using System;
using System.Collections.Generic;

namespace WebApi
{
    public interface IRepository
    {
        Call Save();
        List<Call> Get();
    }
    public class Repository : IRepository
    {
        private readonly List<Call> _calls = new List<Call>();

        public List<Call> Get()
        {
            return _calls;
        }

        public Call Save()
        {
            var call = new Call()
            {
                Id = Guid.NewGuid(),
                Time = DateTime.Now
            };
            _calls.Add(call);
            return call;
        }
    }
}
