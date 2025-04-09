using System.IO.Ports;
using Microsoft.Extensions.Logging;
using WebIot.Models;

namespace WebIot.Services
{
    public interface ISerialPortService
    {
        Task<bool> ConnectToDevice(Device device);
        Task DisconnectFromDevice(Device device);
        Task SendCommand(Device device, string command);
        Task<string> ReadData(Device device);
    }

    public class SerialPortService : ISerialPortService, IDisposable
    {
        private readonly ILogger<SerialPortService> _logger;
        private readonly Dictionary<string, SerialPort> _activePorts = new();

        public SerialPortService(ILogger<SerialPortService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> ConnectToDevice(Device device)
        {
            try
            {
                if (_activePorts.ContainsKey(device.PortName))
                {
                    _logger.LogWarning($"Port {device.PortName} is already in use");
                    return false;
                }

                var serialPort = new SerialPort(device.PortName, device.BaudRate)
                {
                    ReadTimeout = 5000,
                    WriteTimeout = 5000
                };

                serialPort.Open();
                _activePorts[device.PortName] = serialPort;

                _logger.LogInformation($"Connected to device {device.Name} on port {device.PortName}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error connecting to device {device.Name}");
                return false;
            }
        }

        public async Task DisconnectFromDevice(Device device)
        {
            try
            {
                if (_activePorts.TryGetValue(device.PortName, out var serialPort))
                {
                    serialPort.Close();
                    serialPort.Dispose();
                    _activePorts.Remove(device.PortName);
                    _logger.LogInformation($"Disconnected from device {device.Name}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error disconnecting from device {device.Name}");
            }
        }

        public async Task SendCommand(Device device, string command)
        {
            try
            {
                if (_activePorts.TryGetValue(device.PortName, out var serialPort))
                {
                    serialPort.WriteLine(command);
                    _logger.LogInformation($"Sent command to device {device.Name}: {command}");
                }
                else
                {
                    _logger.LogWarning($"Device {device.Name} is not connected");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending command to device {device.Name}");
            }
        }

        public async Task<string> ReadData(Device device)
        {
            try
            {
                if (_activePorts.TryGetValue(device.PortName, out var serialPort))
                {
                    var data = serialPort.ReadLine();
                    _logger.LogInformation($"Received data from device {device.Name}: {data}");
                    return data;
                }
                else
                {
                    _logger.LogWarning($"Device {device.Name} is not connected");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error reading data from device {device.Name}");
                return string.Empty;
            }
        }

        public void Dispose()
        {
            foreach (var port in _activePorts.Values)
            {
                try
                {
                    port.Close();
                    port.Dispose();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error disposing serial port");
                }
            }
            _activePorts.Clear();
        }
    }
} 