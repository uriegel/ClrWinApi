using System.ComponentModel;
using System.Net;
using ClrWinApi;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var netResource = new NetResource()
{
    Scope = ResourceScope.GlobalNetwork,
    ResourceType = ResourceType.Disk,
    DisplayType = ResourceDisplaytype.Share,
    RemoteName = @"\\cas-storage\transfer"
};

var credentials = new NetworkCredential("", "", "");

var userName = string.IsNullOrEmpty(credentials.Domain)
    ? credentials.UserName
    : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

var result = Api.WNetAddConnection2(netResource, credentials.Password, userName, 0);
if (result != 0)
   throw new Win32Exception(result);

result = Api.WNetCancelConnection2(netResource.RemoteName, 0, true);
if (result != 0)
    throw new Win32Exception(result);
