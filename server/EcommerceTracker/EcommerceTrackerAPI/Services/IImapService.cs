using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using EcommerceTrackerAPI.Models;

namespace EcommerceTrackerAPI.Services
{
    public interface IImapService
    {
        bool TestConnection(ImapConnection connection);
        bool TestCredentials(ImapConnection connection, ImapLogin login);
    }
}