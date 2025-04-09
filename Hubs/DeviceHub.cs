using Microsoft.AspNetCore.SignalR;
using WebIot.Models;

namespace WebIot.Hubs
{
    public class DeviceHub : Hub
    {
        public async Task SendDeviceData(string deviceId, string data)
        {
            await Clients.All.SendAsync("ReceiveDeviceData", deviceId, data);
        }

        public async Task SendDeviceStatus(string deviceId, bool isConnected)
        {
            await Clients.All.SendAsync("ReceiveDeviceStatus", deviceId, isConnected);
        }

        public async Task SendDeviceCommand(string deviceId, string command)
        {
            await Clients.All.SendAsync("ReceiveDeviceCommand", deviceId, command);
        }
    }
} 