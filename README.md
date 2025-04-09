# Web IoT - ESP32 Device Management System

Web IoT is a modern ASP.NET Core web application for managing and controlling ESP32 devices through USB/Serial communication.

## Features

- User authentication and authorization
- Device management (add, edit, delete)
- Real-time device monitoring with SignalR
- Interactive device control panel
- Data visualization with Chart.js
- Responsive design with Bootstrap 5

## Prerequisites

- .NET 8.0 SDK
- SQL Server or SQL Server LocalDB
- Visual Studio 2022 or VS Code
- Arduino IDE (for ESP32 programming)

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/yourusername/web_iot.git
cd web_iot
```

2. Update the database connection string in `appsettings.json` if needed.

3. Open a terminal in the project directory and run:
```bash
dotnet restore
dotnet ef database update
dotnet run
```

4. Upload the ESP32 code:
   - Open `ESP32/device_code.ino` in Arduino IDE
   - Select your ESP32 board and port
   - Upload the code

5. Access the application:
   - Open a browser and navigate to `https://localhost:5001`
   - Register a new account
   - Add your ESP32 device using the correct port name

## Project Structure

- `Controllers/`: MVC and API controllers
- `Models/`: Data models and view models
- `Views/`: Razor views
- `Services/`: Business logic and device communication
- `Data/`: Entity Framework context and migrations
- `wwwroot/`: Static files (CSS, JS, images)
- `ESP32/`: Arduino code for ESP32 devices

## Device Communication

The system communicates with ESP32 devices through USB/Serial ports. The protocol includes:

- Commands:
  - `LED_ON`: Turn on the LED
  - `LED_OFF`: Turn off the LED
  - `STATUS`: Get device status

- Data Format:
  - From device: `temperature,humidity,buttonState`
  - Status response: `LED:state,BUTTON:state,TEMP:value,HUM:value`

## Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature-name`
3. Commit your changes: `git commit -m 'Add feature'`
4. Push to the branch: `git push origin feature-name`
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details. 