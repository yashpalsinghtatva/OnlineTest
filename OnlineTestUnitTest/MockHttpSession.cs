using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineTest.Models;
using Newtonsoft.Json;

namespace OnlineTestUnitTest
{
    public class MockHttpSession : ISession
    {
        Dictionary<string, object> sessionStorage = new Dictionary<string, object>();

        public object this[string name]
        {
            get { return sessionStorage[name]; }
            set { sessionStorage[name] = value; }
        }

        string ISession.Id
        {
            get
            {
                return new Guid().ToString();
            }
        }

        bool ISession.IsAvailable
        {
            get
            {
                return true;
            }
        }

        IEnumerable<string> ISession.Keys
        {
            get { return sessionStorage.Keys; }
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        void ISession.Clear()
        {
            sessionStorage.Clear();
        }
        void ISession.Remove(string key)
        {
            sessionStorage.Remove(key);
        }

        void ISession.Set(string key, byte[] value)
        {
            sessionStorage[key] = value;
        }
        void SetObjectAsJson(string key, object value)
        {
            sessionStorage[key] = JsonConvert.SerializeObject(value);
        }
        bool ISession.TryGetValue(string key, out byte[] value)
        {
            if (sessionStorage[key] != null)
            {
                value = (byte[])sessionStorage[key]; //Encoding.UTF8.GetBytes(sessionStorage[key].ToString())
                return true;
            }
            else
            {
                value = null;
                return false;
            }

        }

    }
}
