using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueToothPrinter.DependencyServices
{
    /// <summary>
    /// We need to create an interface for DependencyService (Android-iOS-UWP)
    /// </summary>
    public interface IBlueToothService
    {
        IList<string> GetDeviceList();
        Task Print(string deviceName, string text);
    }
}