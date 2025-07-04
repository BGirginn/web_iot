# Web IoT - ASP.NET Core IoT Device Management Platform

A comprehensive web-based IoT device management platform built with ASP.NET Core 8.0, designed for managing IoT devices, executing code remotely, and collecting measurement data.

## 🌟 Features

- **Device Management**: Register, configure, and monitor IoT devices
- **Code Editor**: Write and execute code on IoT devices with syntax highlighting
- **Real-time Data**: Collect and visualize measurement data from connected devices
- **Multi-language Support**: Turkish and English localization
- **RESTful API**: Complete API with Swagger documentation
- **Responsive Design**: Modern Bootstrap-based UI that works on all devices
- **Database Integration**: Entity Framework Core with SQL Server

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 8.0
- **Database**: SQL Server with Entity Framework Core 8.0
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap
- **API Documentation**: Swagger/OpenAPI
- **Localization**: Built-in .NET localization support
- **IDE**: Visual Studio compatible

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express edition or higher)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (optional but recommended)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/BGirginn/web_iot.git
cd web_iot/base-model/web_iot
```

### 2. Configure Database Connection

Update the connection string in `Program.cs` or `appsettings.json`:

```csharp
"Server=YOUR_SERVER_NAME;Database=WebIoTDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

### 3. Run Database Migrations

```bash
dotnet ef database update
```

### 4. Build and Run

```bash
dotnet build
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

### 5. Access Swagger API Documentation

Navigate to `https://localhost:5001/swagger` to explore the API endpoints.

## 📖 Project Structure

```
web_iot/
├── base-model/web_iot/          # Main application
│   ├── Controllers/             # MVC Controllers
│   │   ├── DeviceController.cs  # Device management
│   │   ├── CodeController.cs    # Code execution
│   │   └── HomeController.cs    # Main pages
│   ├── Models/                  # Data models
│   │   ├── Device.cs           # Device entity
│   │   ├── DeviceCode.cs       # Code entity
│   │   └── Measurement.cs      # Measurement data
│   ├── Views/                   # Razor views
│   ├── wwwroot/                # Static files
│   ├── Data/                   # Entity Framework context
│   └── Migrations/             # Database migrations
├── v1.0/                       # Version 1.0 documentation
└── README.md                   # This file
```

## 🎯 Usage

### Device Management

1. **Register a Device**: Add new IoT devices with device name, type, and specifications
2. **Configure Device**: Set up device parameters and connection settings
3. **Monitor Status**: View real-time device status and health information

### Code Execution

1. **Write Code**: Use the integrated code editor with syntax highlighting
2. **Support Languages**: C, C++, Python, JavaScript, and more
3. **Execute Remotely**: Send code to devices and execute remotely
4. **View Results**: Monitor execution results and logs

### Data Collection

1. **Measurement Data**: Collect sensor data from connected devices
2. **Real-time Updates**: View live data streams from IoT devices
3. **Data Visualization**: Charts and graphs for measurement analysis

## 🌐 API Endpoints

The application provides a comprehensive RESTful API. Key endpoints include:

- `GET /api/devices` - List all devices
- `POST /api/devices` - Create a new device
- `GET /api/devices/{id}` - Get device details
- `PUT /api/devices/{id}` - Update device
- `DELETE /api/devices/{id}` - Remove device
- `POST /api/devices/{id}/code` - Execute code on device
- `GET /api/measurements` - Get measurement data

For complete API documentation, visit `/swagger` when running the application.

## 🌍 Localization

The application supports multiple languages:
- **Turkish (tr-TR)**: Default language
- **English (en-US)**: Secondary language

Language can be switched using the dropdown in the navigation bar.

## 📁 Database Schema

### Device Table
- `Id` (Primary Key)
- `DeviceName` (Required)
- `DeviceType` (Required)
- `VendorId`, `ProductId`, `FirmwareVersion`
- `UserId` (Foreign Key)

### DeviceCode Table
- `Id` (Primary Key)
- `Title` (Required)
- `Content` (Code content)
- `Language` (Programming language)
- `DeviceId` (Foreign Key)

### Measurement Table
- Stores sensor data and measurements from IoT devices

## 🔧 Development

### Adding New Features

1. Create new controllers in the `Controllers/` directory
2. Add corresponding models in `Models/`
3. Create views in `Views/ControllerName/`
4. Update database schema using Entity Framework migrations

### Running Tests

```bash
dotnet test
```

### Code Style

The project follows standard C# coding conventions and uses:
- Entity Framework Core for data access
- Dependency injection for services
- MVC pattern for web interface
- Repository pattern for data operations

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines

- Follow C# coding standards
- Add unit tests for new features
- Update documentation for API changes
- Ensure localization support for new strings
- Test on both supported languages

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Bora Girgin** - *Initial work* - [BGirginn](https://github.com/BGirginn)

## 🐛 Issues and Support

If you encounter any issues or need support:

1. Check the [Issues](https://github.com/BGirginn/web_iot/issues) section
2. Create a new issue with detailed description
3. Provide steps to reproduce the problem
4. Include system information and logs

## 🚧 Roadmap

### Current Version (v1.0)
- [x] Basic device management
- [x] Code editor integration
- [x] Database setup
- [x] API with Swagger documentation
- [x] Multi-language support

### Future Enhancements
- [ ] Real-time notifications
- [ ] Advanced data visualization
- [ ] Mobile application
- [ ] Docker containerization
- [ ] Cloud deployment support
- [ ] User authentication system
- [ ] Advanced device monitoring
- [ ] Data export functionality

## 📞 Contact

For questions or suggestions, please contact:
- **Email**: girginbora30@gmail.com
- **Location**: Sakarya, Turkey
- **GitHub**: [@BGirginn](https://github.com/BGirginn)

---

*This project is part of an electrical and electronic engineering study focused on IoT device management and remote code execution.*