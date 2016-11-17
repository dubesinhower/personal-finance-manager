using System;
using System.Diagnostics;
using System.Net.Sockets;
using EcommerceTrackerAPI.Models;
using MailKit.Net.Imap;
using MailKit.Security;

namespace EcommerceTrackerAPI.Services
{
    public class ImapService: IImapService
    {
        public bool TestConnection(ImapConnection connection)
        {
            var connectionSuccess = true;
            var client = new ImapClient {ServerCertificateValidationCallback = (s, c, h, e) => true};
            try
            {
                // TODO: don't accept all SSL certificates
                client.Connect(connection.IpAddress, connection.Port, true);
            }
            catch (SocketException exception)
            {
                Debug.WriteLine(exception);
                connectionSuccess = false;
            }
            finally
            {
                client.Dispose();
            }
            return connectionSuccess;
        }

        public bool TestCredentials(ImapConnection connection, ImapLogin login)
        {
            var credentialsValid = true;
            var client = new ImapClient { ServerCertificateValidationCallback = (s, c, h, e) => true };
            try
            {
                // TODO: don't accept all SSL certificates
                client.Connect(connection.IpAddress, connection.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(login.Username, login.Password);
            }
            catch (AuthenticationException exception)
            {
                Debug.WriteLine(exception);
                credentialsValid = false;
            }
            finally
            {
                client.Dispose();
            }
            return credentialsValid;
        }
    }
}