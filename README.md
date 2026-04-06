# WinformAppDemo

## 介绍

基于Winform框架实现的上位机程序架构demo

## 程序架构

该程序架构设计借鉴了MVC架构的设计思想，但是因Winform自身的特殊性，因此与MVC架构不会完全相同

### Form层

负责实现窗口程序

窗口程序是由Form.Designer.cs文件和Form.cs文件组成，前者是负责页面布局设计（即开发者对控件用到的拖拉拽所生成的自动代码都是存放于此处，这点类似于View层，不过不建议开发者手动改动此处），后者主要是用来处理业务逻辑（一般靠控件的事件来触发，如点击事件，加载事件等），但是也可以承担页面布局设计（如有些控件需要依据条件来动态显示，这时候直接靠拖拽的方式已经无法实现，只能完全通过设计程序的方式来实现），所以后者既像Controller层，又像View层。因此将MVC架构中的View层和Controller层合并在一起，设计成一个Form层，Form.Designer.cs（也就是拖来拽）专门设计用户交互界面，Form.cs专门处理业务逻辑，以及依据业务需求，适当地更新界面显示状态。

因此设计Forms文件夹，负责存放窗口程序，至于主窗口程序是否也放入其中请开发者自行决定，在此demo中并没有这么做

### 数据层

#### 数据库数据访问层

与MVC的Model层基本上是一样的。不过该架构demo使用的访问数据库的框架是ado.net，如果需要EntityFramework等其他数据库框架请酌情参考

因此设计DataAccess文件夹，负责处理与数据库之间交互的程序


#### 硬件设备数据访问层

上位机与web不同

### 数据层

安装教程

1. xxxx
2. xxxx
3. xxxx

#### 使用说明

1. xxxx
2. xxxx
3. xxxx

#### 参与贡献

1. Fork 本仓库
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request

#### 特技

1. 使用 Readme\_XXX.md 来支持不同的语言，例如 Readme\_en.md, Readme\_zh.md
2. Gitee 官方博客 [blog.gitee.com](https://blog.gitee.com)
3. 你可以 [https://gitee.com/explore](https://gitee.com/explore) 这个地址来了解 Gitee 上的优秀开源项目
4. [GVP](https://gitee.com/gvp) 全称是 Gitee 最有价值开源项目，是综合评定出的优秀开源项目
5. Gitee 官方提供的使用手册 [https://gitee.com/help](https://gitee.com/help)
6. Gitee 封面人物是一档用来展示 Gitee 会员风采的栏目 [https://gitee.com/gitee-stars/](https://gitee.com/gitee-stars/)
