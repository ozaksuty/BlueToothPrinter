using BlueToothPrinter.DependencyServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace BlueToothPrinter.ViewModels
{
    public class PrintPageViewModel
    {
        private readonly IBlueToothService _blueToothService;

        private IList<string> _deviceList;
        public IList<string> DeviceList
        {
            get
            {
                if (_deviceList == null)
                    _deviceList = new ObservableCollection<string>();
                return _deviceList;
            }
            set
            {
                _deviceList = value;
            }
        }

        private string _printMessage;
        public string PrintMessage
        {
            get
            {
                return _printMessage;
            }
            set
            {
                _printMessage = value;
            }
        }

        private string _selectedDevice;
        public string SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
            }
        }

        /// <summary>
        /// Print text-message
        /// </summary>
        public ICommand PrintCommand => new Command(async () =>
        {
            PrintMessage += " Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            await _blueToothService.Print(SelectedDevice, PrintMessage);
        });

        public PrintPageViewModel()
        {
            _blueToothService = DependencyService.Get<IBlueToothService>();
            BindDeviceList();
        }

        /// <summary>
        /// Get Bluetooth device list with DependencyService
        /// </summary>
        void BindDeviceList()
        {
            var list = _blueToothService.GetDeviceList();
            DeviceList.Clear();
            foreach (var item in list)
                DeviceList.Add(item);
        }
    }
}