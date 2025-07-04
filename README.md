# Web IoT - IoT Device Management Platform

A comprehensive web-based platform for Internet of Things (IoT) device management, built with modern web technologies including C#, HTML, CSS, and JavaScript. This platform provides real-time device monitoring, code management, and data collection capabilities for IoT projects.

## 🚀 Project Overview

Web IoT is an ASP.NET Core 8.0 application designed to simplify IoT device management through a user-friendly web interface. The platform enables users to:

- **Device Management**: Register, configure, and monitor IoT devices
- **Code Management**: Create, edit, and deploy code to IoT devices with syntax highlighting
- **Data Collection**: Collect and visualize sensor measurements (temperature, humidity, etc.)
- **Multi-language Support**: Available in Turkish and English
- **RESTful API**: Comprehensive API for device integration and third-party applications

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0
- **Language**: C#
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **API Documentation**: Swagger/OpenAPI

### Frontend
- **Markup**: HTML5 with Razor Views
- **Styling**: CSS3 with Bootstrap
- **Scripting**: JavaScript
- **Localization**: Multi-language support (Turkish/English)

### Development Tools
- **.NET**: 8.0 SDK
- **IDE**: Visual Studio 2022 or VS Code
- **Database**: SQL Server Express or SQL Server

## 📋 Prerequisites

Before setting up the project, ensure you have the following installed:

### Required Software
- **.NET 8.0 SDK** or later - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** (Express, LocalDB, or full version) - [Download here](https://www.microsoft.com/sql-server/sql-server-downloads)
- **Visual Studio 2022** (recommended) or **VS Code** with C# extension

### Optional but Recommended
- **Git** for version control
- **Postman** or similar tool for API testing
- **Node.js** (if extending frontend functionality)

## 🔧 Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/BGirginn/web_iot.git
cd web_iot
```

### 2. Navigate to Project Directory
```bash
cd base-model/web_iot
```

### 3. Configure Database Connection
Edit `appsettings.json` and update the connection string to match your SQL Server setup:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WebIoTDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 4. Restore Dependencies
```bash
dotnet restore
```

### 5. Create and Update Database
```bash
dotnet ef database update
```

### 6. Build the Project
```bash
dotnet build
```

### 7. Run the Application
```bash
dotnet run
```

The application will be available at:
- **HTTPS**: `https://localhost:7001`
- **HTTP**: `http://localhost:5000`
- **Swagger API**: `https://localhost:7001/swagger`

## 📁 Project Structure

```
web_iot/
├── base-model/web_iot/          # Main application
│   ├── Controllers/             # MVC Controllers and API Controllers
│   │   ├── HomeController.cs    # Main web interface
│   │   ├── DeviceController.cs  # Device management
│   │   └── CodeController.cs    # API for code management
│   ├── Models/                  # Data models
│   │   ├── Device.cs           # IoT device entity
│   │   ├── DeviceCode.cs       # Device code entity
│   │   ├── Measurement.cs      # Sensor measurement entity
│   │   └── AppUser.cs          # User management
│   ├── Views/                   # Razor views
│   │   ├── Home/               # Home page views
│   │   ├── Device/             # Device management views
│   │   └── Shared/             # Shared layouts and components
│   ├── Data/                    # Entity Framework context
│   ├── Migrations/              # Database migrations
│   ├── wwwroot/                 # Static files (CSS, JS, images)
│   └── Program.cs              # Application entry point
└── v1.0/                       # Version documentation
```

## 🌟 Features

### Device Management
- Register and configure IoT devices
- Track device information (name, type, vendor, firmware version)
- Associate devices with user accounts

### Code Management
- Create and edit device code with syntax highlighting
- Support for multiple programming languages (C, C++, Python, JavaScript)
- Version control for device code
- RESTful API for code deployment

### Data Collection
- Real-time sensor data collection
- Temperature and humidity monitoring
- Timestamp tracking for all measurements
- Data visualization capabilities

### User Interface
- Responsive web design
- Multi-language support (Turkish/English)
- Intuitive device management interface
- Real-time updates and notifications

### API Integration
- RESTful API endpoints
- Swagger/OpenAPI documentation
- JSON-based data exchange
- Easy integration with IoT devices and third-party applications

## 🔌 API Endpoints

### Device Code Management
- `GET /api/Code/{id}` - Retrieve device code
- `PUT /api/Code/{id}` - Update device code

### Device Management
- Device CRUD operations through web interface
- RESTful endpoints for device registration and management

For complete API documentation, visit `/swagger` when the application is running.

## 🤝 Contributing

We welcome contributions to the Web IoT project! Please follow these guidelines:

### Getting Started
1. **Fork** the repository
2. **Clone** your fork to your local machine
3. **Create** a new branch for your feature or bugfix
4. **Make** your changes following the coding standards
5. **Test** your changes thoroughly
6. **Submit** a pull request with a clear description

### Coding Standards
- Follow **C# coding conventions**
- Use **meaningful variable and method names**
- **Comment** complex logic and algorithms
- Write **unit tests** for new functionality
- Ensure **responsive design** for UI changes

### Development Workflow
```bash
# Create a new feature branch
git checkout -b feature/your-feature-name

# Make your changes and commit
git add .
git commit -m "Add your descriptive commit message"

# Push to your fork
git push origin feature/your-feature-name

# Create a pull request on GitHub
```

### Code Review Process
- All changes require **code review**
- Ensure **tests pass** before submitting PR
- **Documentation** should be updated for new features
- Follow **semantic versioning** for releases

### Reporting Issues
- Use GitHub Issues to report bugs
- Provide **detailed description** and **reproduction steps**
- Include **system information** and **error messages**
- Label issues appropriately (bug, enhancement, question)

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## 🆘 Support

For support and questions:
- **GitHub Issues**: [Report bugs or request features](https://github.com/BGirginn/web_iot/issues)
- **Documentation**: Check the `/swagger` endpoint for API documentation
- **Wiki**: Visit the project wiki for detailed guides

## 🗺️ Roadmap

### Current Version (v1.0)
- Basic device management
- Code editing and deployment
- Sensor data collection
- Multi-language support

### Planned Features
- Real-time dashboards
- Advanced analytics
- Mobile application
- Cloud deployment options
- Enhanced security features
- Device firmware updates
- Notification system

## 🏗️ Development

### Running in Development Mode
```bash
# Enable development environment
export ASPNETCORE_ENVIRONMENT=Development

# Run with hot reload
dotnet watch run
```

### Database Migrations
```bash
# Add new migration
dotnet ef migrations add YourMigrationName

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

### Testing
```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test YourTestProject.csproj
```

---

**Built with ❤️ for the IoT community**