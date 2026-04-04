using WinformAppDemo.DataAccess.Repositories;
using WinformAppDemo.HardwareAccess.Plcs;
using WinformAppDemo.Properties;
using WinformAppDemo.Utils.ConfigReaders;
using WinformAppDemo.Utils.Configs;
using WinformAppDemo.Utils.UI;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timers = System.Timers;
using WinformAppDemo.HardwareAccess.Ohmmeters;
using WinformAppDemo.HardwareAccess.Scanners;

namespace WinformAppDemo
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 日志对象字段
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger("MainLogger");
        /// <summary>
        /// 控件国际化字典项
        /// </summary>
        private readonly Dictionary<Control, string> controlsResxDic;
        /// <summary>
        /// 主线plc操作器字段
        /// </summary>
        private MainLinePlcOperator mainLinePlcOperator;
        /// <summary>
        /// 辅线plc操作器字段
        /// </summary>
        private DoorLinePlcOperator doorLinePlcOperator;
        /// <summary>
        /// 电阻仪操作器字段
        /// </summary>
        private OhmmeterOperator ohmmeterOperator;
        /// <summary>
        /// 扫码枪操作器字段
        /// </summary>
        private ScannerOperator scannerOperator;
        /// <summary>
        /// 操作用户表的仓储对象字段
        /// </summary>
        private UserRepository userRepository;

        public MainForm()
        {
            InitializeComponent();

            //初始化控件国际化字典项
            controlsResxDic = InitControlsResxDic();

            //初始化设置语言选择下拉框数据
            InitUICBoxLanSettingData();
        }

        /// <summary>
        /// 初始化控件国际化字典项
        /// </summary>
        private Dictionary<Control, string> InitControlsResxDic()
        {
            var controlsResxDic = new Dictionary<Control, string>
            {
                [uiLabLanSet] = nameof(uiLabLanSet),
                [tabPageProdInfo] = nameof(tabPageProdInfo),
                [tabPageInfoQuery] = nameof(tabPageInfoQuery),
            };

            return controlsResxDic;
        }

        /// <summary>
        /// 初始化设置语言选择下拉框数据
        /// </summary>
        private void InitUICBoxLanSettingData()
        {
            //初始化语言选择下拉框设置
            uiCBoxLanSetting.ValueMember = "Id";
            uiCBoxLanSetting.DisplayMember = "Name";
            uiCBoxLanSetting.DataSource = new List<KeyValueItem>
            {
                new KeyValueItem
                {
                    Id = "en-us",
                    Name = "English"
                },
                new KeyValueItem
                {
                    Id = "zh-cn",
                    Name = "中文"
                },
            };
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            //将窗体最大化且不占用桌面的任务栏
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            try
            {
                // 读取配置文件
                var config = ConfigReader.Read();

                // 初始化主线PLC操作器任务
                var mainLinePlcOperatorTask = Task.Run(() => new MainLinePlcOperator(config.MainLinePlcConfig));
                // 初始化辅线PLC操作器任务
                var doorLinePlcOperatorTask = Task.Run(() => new DoorLinePlcOperator(config.DoorLinePlcConfig));
                // 初始化电阻仪操作器任务
                var ohmmeterOperatorTask = Task.Run(() => new OhmmeterOperator(config.OhmmeterSpConfig));
                // 初始化扫码枪操作器任务
                var scannerOperatorTask = Task.Run(() => new ScannerOperator(config.ScannerSpConfig));

                await Task.WhenAll(mainLinePlcOperatorTask, doorLinePlcOperatorTask, ohmmeterOperatorTask, scannerOperatorTask);

                // 初始化主线PLC操作器
                mainLinePlcOperator = mainLinePlcOperatorTask.Result;
                // 初始化辅线PLC操作器
                doorLinePlcOperator = doorLinePlcOperatorTask.Result;
                // 初始化电阻仪操作器
                ohmmeterOperator = ohmmeterOperatorTask.Result;
                // 初始化电阻仪定时器任务
                var ohmmeterTimerTask = new Task(OnOhmmeterTimerElapsed);
                ohmmeterTimerTask.Start();
                // 初始化扫码枪操作器
                scannerOperator = scannerOperatorTask.Result;
                scannerOperator.BarcodeReceived += OnBarcodeReceived;

                // 获取主线状态
                uiSwitchSetLineState.Active = await mainLinePlcOperator.GetLineStateAsync();

                // 初始化用户仓储对象
                userRepository = new UserRepository();

                // 假如有一个界面是显示用户信息的, 写此处只是为了示例
                var userEntities = userRepository.GetUsers();
                // 转换dto并显示在界面上, 省略转换代码

            }
            catch (Exception ex)
            {
                log.Error($"主窗体加载异常: {ex}");
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 读取电阻值定时器事件, 获取电阻仪数值并更新到界面上
        /// </summary>
        private void OnOhmmeterTimerElapsed()
        {
            try
            {
                while (true)
                {
                    Invoke(new Action(() =>
                    {
                        uiTxtBoxResistance.Text = ohmmeterOperator.SimpleMeasureResistance().ToString();
                    }));

                    /// 每隔一秒读取一次电阻值
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                log.ErrorFormat("电阻仪定时器异常: {0}", ex);
            }
        }

        /// <summary>
        /// 处理扫码枪接收条码数据事件, 将条码数据显示到界面上
        /// </summary>
        /// <param name="barcode"></param>
        private void OnBarcodeReceived(string barcode)
        {
            BeginInvoke(new Action(() =>
            {
                uiTxtBarcode.Text = barcode;
            }));
        }

        /// <summary>
        /// 语言选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UICBoxLanSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedVal = uiCBoxLanSetting.SelectedValue.ToString();

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedVal);

            foreach (var controlsResxItem in controlsResxDic)
            {
                var control = controlsResxItem.Key;
                var resourceName = controlsResxItem.Value;

                control.Text = Resources.ResourceManager.GetString(resourceName);
            }
        }

        /// <summary>
        /// 鼠标进入关闭控件区域内触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBoxClose_MouseEnter(object sender, EventArgs e)
        {
            const string imageFile = @"Images\close_white.png";
            picBoxClose.Image = Image.FromFile(imageFile);
            picBoxClose.BackColor = Color.Red;
        }

        /// <summary>
        /// 鼠标离开关闭控件区域时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBoxClose_MouseLeave(object sender, EventArgs e)
        {
            const string imageFile = @"Images\close_black.png";
            picBoxClose.Image = Image.FromFile(imageFile);
            picBoxClose.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 关闭控件点击事件, 关闭主窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBoxClose_Click(object sender, EventArgs e)
        {
            try
            {
                mainLinePlcOperator?.Dispose();
                doorLinePlcOperator?.Dispose();
                //关闭主窗体
                Close();
            }
            catch (Exception ex)
            {
                log.Error($"关闭窗口时异常: {ex}");
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 鼠标进入最小化控件区域内触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBoxMinus_MouseEnter(object sender, EventArgs e)
        {
            picBoxMinus.BackColor = Color.LightGray;
        }

        /// <summary>
        /// 鼠标离开最小化控件区域内触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBoxMinus_MouseLeave(object sender, EventArgs e)
        {
            picBoxMinus.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 最小化控件点击事件, 最小化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicBoxMinus_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private async void UISwitchSetLineState_ActiveChanged(object sender, EventArgs e)
        {
            try
            {
                await mainLinePlcOperator.SetLineStateAsync(uiSwitchSetLineState.Active);
            }
            catch (Exception ex)
            {
                log.Error($"设置产线状态时异常: {ex}");
                MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
