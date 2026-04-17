# Host Program Framework Demo

## Introduction

An upper computer program architecture demo based on the WinForms framework. This project aims to provide a clear and extensible architectural reference for WinForms applications in the field of industrial automation, helping developers quickly build stable and reliable upper computer systems.

## Program Architecture

The design of this program architecture draws on the ideas of MVC, but due to the specific characteristics of WinForms, it is not exactly the same as classic MVC.

### Directory Structure

```
WinformAppDemo/
├── DataAccess/ # Database interaction
│ ├── Entities/ # Entity classes
│ ├── Repositories/ # Repository classes
│ └── DbConnectionHelper.cs
├── Dtos/
├── Forms/
├── HardwareAccess/ # Hardware interaction
│ ├── Ohmmeters/
│ ├── Plcs/
│ ├── Scanners/
│ ├── PlcConnectionHelper.cs
│ └── SerialPortConnectionHelper.cs
├── Images/
├── Utils/ # Utility classes
├── App.config
├── Config.xml
├── log4net.config
├── MainForm.cs
├── packages.config
└── Program.cs
```

### Form Layer

Responsible for implementing the window forms. A form consists of `Form.Designer.cs` and `Form.cs`. The former handles the layout design (i.e., auto-generated code from dragging and dropping controls, similar to the View layer; it is not recommended to modify it manually). The latter mainly handles business logic (triggered by control events such as clicks, loads, etc.), but can also handle dynamic layout design (e.g., when controls need to be shown/hidden conditionally, which cannot be achieved by drag-and-drop alone). Thus, `Form.cs` acts like both a Controller and a View. Therefore, the View and Controller layers of MVC are merged into a single Form layer: `Form.Designer.cs` focuses on the user interface, and `Form.cs` focuses on business logic and updating the UI as needed.

Hence the `Forms` folder is designed to store form programs. Whether to put the main form in this folder is up to the developer; in this demo, it is not placed there.

### Data Layer

#### Data Access Layer for Database (DataAccess)

This is essentially the same as the Model layer in MVC. The demo uses ADO.NET as the database access framework. If you need Entity Framework or other frameworks, please adjust accordingly.

Therefore, the `DataAccess` folder is designed to handle database interaction.

**This layer is further divided into three parts:**

- **Entities**: Stores entity classes that map to database tables.
- **Repositories**: Stores data manipulation logic. For example, to perform CRUD on a `User` table, create a `UserRepository` class and implement the methods there. The same applies to other tables. For multi-table queries, determine the main table and place the query logic in the corresponding repository.
- **DbConnectionHelper**: Creates database connection objects.

#### Data Access Layer for Hardware (HardwareAccess)

Unlike web applications, an upper computer needs to communicate with hardware. This layer handles hardware interaction logic.

Hence the `HardwareAccess` folder is designed to store hardware interaction code.

##### How to Subdivide the Hardware Access Layer

Based on actual requirements, identify the types of hardware to interact with and create corresponding subfolders under `HardwareAccess`. For example, this demo interacts with three types of hardware: an ohmmeter, a PLC, and a barcode scanner, so three folders are created: `Ohmmeters`, `Plcs`, and `Scanners`.

##### Naming Conventions for Hardware Operator Classes

- If only one device of a given type exists: `[HardwareEnglishName]Operator`, e.g., `PlcOperator`, `OhmmeterOperator`.
- If two or more devices exist (rare): `[Responsibility][HardwareEnglishName]Operator`, e.g., `MainLinePlcOperator`, `DoorLinePlcOperator`.

##### Method Design

Design methods based on actual business needs. For example, for the main PLC that controls the main line conveyor and reports its status, design two methods: `SetLineState` (to control the conveyor) and `GetLineState` (to get the status).

##### Why Not Design a Common Reusable Class?

Because third-party hardware communication libraries already provide this functionality very well. Wrapping them again adds little value and reduces code readability.

##### ConnectionHelper Class

Design corresponding `ConnectionHelper` classes based on the actual communication method (serial port, TCP, etc.). Place them directly under the `HardwareAccess` folder. For example, `PlcConnectionHelper` (PLC communication), `SerialPortConnectionHelper` (serial communication), and similarly for TCP.

### Utils

`Utils` stores common utility programs for convenient use by the Form layer and Data layer. How to subdivide it depends on actual requirements.

### Dtos

Stores Data Transfer Objects. It is recommended not to display database query results directly; instead, convert entities to DTOs and pass DTOs to the UI. Similarly, when editing, convert DTOs to entities before updating the database. For more information about DTOs, please search online; many bloggers have explained it in detail, so it is not repeated here.

## Technology Stack

- **Framework**: WinForms (.NET)
- **Development Framework**: .NET Framework 4.8
- **Database**: SQL Server
- **PLC Communication**: HslCommunication
- **UI Components**: SunnyUI
- **Logging**: log4net

> **Note:** This demo uses the above libraries for demonstration purposes. If you use other databases or hardware communication libraries, please replace the corresponding modules as needed.

## Configuration Instructions

- **Database Connection Configuration**: Configure in the `connectionStrings` section of the `App.config` file.
- **Hardware Device Connection Configuration**: Configure in the `Config.xml` file. This file contains detailed comments, and you can add or modify configuration items according to your actual business needs.

## License

This project is licensed under LGPL-3.0. See the [LICENSE](LICENSE) file for details.

## 💡 Tips

Writing code is not easy. If this project helps you, you are welcome to buy me a coffee ☕️

Related images are stored in: `/images/misc/` (click to see – no pressure, it's entirely voluntary)

Thank you to every friend. Your encouragement is my motivation to continue sharing.
