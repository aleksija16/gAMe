using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMe
{
    public static class SessionManager
    {
        public static ISession session;

        public static async Task<ISession> GetSessionAsync()
        {
            if (session == null)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                session = await cluster.ConnectAsync("game");
            }

            return session;
        }
    }
}
