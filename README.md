# WinformAppDemo

## 介绍

基于Winform框架实现的上位机程序架构demo。该项目旨在为工业自动化领域的Winform应用程序提供一套清晰、可扩展的架构参考，帮助开发者快速构建稳定可靠的上位机系统。

## 程序架构

该程序架构设计借鉴了MVC架构的设计思想，但是因Winform自身的特殊性，因此与MVC架构不会完全相同。

### 目录结构

WinformAppDemo/
├── DataAccess/ # 数据库交互 <br />
│   ├── Entities/ # 实体类
│   ├── Repositories/ # 仓储类
│   └── DbConnectionHelper.cs
├── Dtos/
├── Forms/
├── HardwareAccess/ # 硬件交互
│   ├── Ohmmeters/
│   ├── Plcs/
│   ├── Scanners/
│   ├── PlcConnectionHelper.cs
│   └── SerialPortConnectionHelper.cs
├── Images/
├── Utils/ # 工具类
├── App.config
├── Config.xml
├── log4net.config
├── MainForm.cs
├── packages.config
└── Program.cs

### Form层

负责实现窗口程序。窗口程序是由Form.Designer.cs文件和Form.cs文件组成，前者是负责页面布局设计（即开发者对控件用到的拖拽所生成的自动代码都是存放于此处，这点类似于View层，不过不建议开发者手动改动此处），后者主要是用来处理业务逻辑（一般靠控件的事件来触发，如点击事件，加载事件等），但是也可以承担页面布局设计（如有些控件需要依据条件来动态显示，这时候直接靠拖拽的方式已经无法实现，只能完全通过设计程序的方式来实现），所以后者既像Controller层，又像View层。因此将MVC架构中的View层和Controller层合并在一起，设计成一个Form层，Form.Designer.cs（也就是拖来拽）专门设计用户交互界面，Form.cs专门处理业务逻辑，以及依据业务需求，适当地更新界面显示状态。

因此设计Forms文件夹，负责存放窗口程序，至于主窗口程序是否也放入其中请开发者自行决定，在此demo中并没有这么做。

### 数据层

#### 与数据库交互的数据访问层（DataAccess）

与MVC的Model层基本上是一样的。不过该架构demo使用的访问数据库的框架是ado.net，如果需要EntityFramework等其他数据库框架请酌情参考。

因此设计DataAccess文件夹，负责处理与数据库之间交互的程序。

**该层中又细分如下三个部分: **

- **Entities**: 负责存放与表相映射的实体类。
- **Repositories**: 负责存放操作数据表的程序，如需要对User表进行增删改查，那就设计一个UserRepository类，在该类中实现增删改查的程序，对其他表也是同理。如果涉及到多表联查的话，那就确定哪个表是主表，并将查询程序放到与主表相关的Repository类中。
- **DbConnectionHelper**: 创建数据库连接对象。

#### 与硬件设备交互的数据访问层（HardwareAccess）

上位机与web不同，需要与硬件做通讯，因此该层是负责处理与硬件交互逻辑的。

因此设计HardwareAccess文件夹，负责处理与硬件之间的交互的程序。

##### 对与硬件设备交互的数据访问层如何进行细致的划分

结合现场实际需求，了解需要交互的硬件种类有哪些，并在HardwareAccess文件下设置与之相关的文件夹。例如，此demo程序中需要交互的硬件设备类型有三种，分别是电阻仪、plc和扫码枪，因此就设置三个文件夹: "Ohmmeters"，负责存放电阻仪交互程序、"Plcs"，负责存放plc交互程序、"Scanners"，负责存放扫码枪交互程序。

##### 硬件交互的操作类如何命名

如果当前设备类型下仅有一台，其命名规则是: 硬件设备的英文名称 + Operator，如plc的就是"PlcOperator"，电阻仪的就是"OhmmeterOperator"。

如果当前设备类型下有两台或两台以上的设备（一般情况下较少），其命名规则: 该设备在产线中承担的职责 + 硬件设备的英文名称 + Operator，例如产线中有两个plc，一个是主线plc，另一个是辅线plc，二者承担的职责不同，因此主线的plc命名为"MainLinePlcOperator"，辅线的plc命名为"DoorLinePlcOperator"。

##### 类中方法如何设计

请结合实际的业务需求来设计相应的函数。例如，主线plc中有控制主线输送和主线输送状态这两个操作，那就照此设计两个函数: "SetLineState"，控制主线输送、"GetLineState"，获取主线输送状态。

##### 为什么不设计一个比较公共的类以此来复用呢？

因为负责与硬件通讯的第三方工具包已经把这个做了，而且做的已经非常好了，如果再实现无非就是给它套了个壳子，个人建议不要这样，意义不大，要尽量提高代码可阅读性

##### ConnectionHelper类

根据与硬件通讯的实际方式，来设计相应的ConnectionHelper类，直接放在HardwareAccess文件夹下即可，如plc通讯，设置"PlcConnectionHelper"类（plc特殊一点，所以单独设置一个），如串口通讯，设置"SerialPortConnectionHelper"类，如果是tcp通讯，也是同理。

### Utils

Utils负责存放一些公共的工具程序，以供Form层和数据层方便调用，其内部划分方式也是结合实际需求来定。

### Dtos

负责存放数据传输对象，建议在查询时，不要把从数据库中查询的数据直接显示，而是查询之后的实体转化成dto，由dto传给界面显示，编辑数据也是如此，编辑之后生成的dto转化为实体，再编辑到数据库中，至于Dto是什么，可以上网进行查阅，已经有很多博主解释的很详细了，这里不再赘述了。

## 技术栈

- **框架**: Winform (.NET)
- **开发框架:** .Net Framework 4.8
- **数据库**: SQL Server
- **PLC通讯**: HslCommunication
- **UI组件**: SunnyUI
- **日志**: log4net

  ***说明:* *****本 Demo 实际使用了上述库进行演示，若你使用其他数据库或硬件通信库，请自行替换对应模块。***

## 配置说明

* **数据库连接配置: **在 `App.config`文件中的 `connectionStrings`标签中进行配置
* **硬件设备连接配置: **在 `Config.xml`文件中进行配置，该配置文件有详细的注释说明，且也可以结合自身实际业务需求，适当对config文件增添配置内容

## 许可证

本项目采用的是LGPL-3.0。详情请参阅[LICENSE](LICENSE)文件。

## 💡 小贴士

写码不易，如果这个项目对你有帮助，欢迎请我喝杯咖啡☕️

相关图片存放在: `/images/misc/`（点进去看看就懂了～量力而行，不勉强）

感谢每一位朋友，你的鼓励是我持续分享的动力。
