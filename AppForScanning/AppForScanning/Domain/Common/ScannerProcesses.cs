using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AppForScanning.Domain.Extensions;
using AppForScanning.Domain.Models;
using WIA;

namespace AppForScanning.Domain.Common
{
    public class ScannerProcesses
    {
        public void LoadScannersFromOperationSystemDrivers(out Dictionary<string, DeviceInfo> dictionaryScanners, out string defaultScannerName)
        {
            try
            {
                dictionaryScanners = new Dictionary<string, DeviceInfo>();
                defaultScannerName = string.Empty;

                var deviceManager = new DeviceManager();

                foreach (var item in deviceManager.DeviceInfos)
                {
                    if (item is DeviceInfo deviceInfo && deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                    {
                        var deviceName = deviceInfo.Properties["Name"].get_Value() as string;

                        if (!string.IsNullOrEmpty(deviceName))
                        {
                            if (!dictionaryScanners.ContainsKey(deviceName))
                                dictionaryScanners.Add(deviceName, deviceInfo);
                        }
                    }
                }

                if (dictionaryScanners.Count > 0)
                {
                    var commonDialog = new WIA.CommonDialog();
                    var defaultScannerDevice = commonDialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false);

                    if (defaultScannerDevice != null)
                    {
                        defaultScannerName = defaultScannerDevice.Properties["Name"].get_Value() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ImageFile GetImageFileFromScanner(Scanner scanner, int resolution = 150, int width_pixel = 1250, int height_pixel = 1700, int color_mode = 1)
        {
            try
            {
                if (scanner != null && scanner.Device != null &&
                    !string.IsNullOrEmpty(scanner.FilePathForSaveScanDocument))
                {
                    var scannerItem = scanner.Device.Items[1];
                    ScannerSettings.SetScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, 0, 0, color_mode);

                    try
                    {
                        var dlg = new WIA.CommonDialog();
                        object scanResult = dlg.ShowTransfer(scannerItem, "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}", true);

                        if (scanResult != null)
                        {
                            return (ImageFile)scanResult;
                        }

                        throw new Exception("Не удалось получить документ из сканера");
                    }
                    catch (COMException comException)
                    {
                        // Convert the error code to UINT
                        uint errorCode = (uint)comException.ErrorCode;

                        // See the error codes
                        if (errorCode == 0x80210006)
                        {
                            throw new Exception("The scanner is busy or isn't ready");
                        }
                        else if (errorCode == 0x80210064)
                        {
                            throw new Exception("The scanning process has been cancelled.");
                        }
                        else if (errorCode == 0x8021000C)
                        {
                            throw new Exception("There is an incorrect setting on the WIA device.");
                        }
                        else if (errorCode == 0x80210005)
                        {
                            throw new Exception("The device is offline. Make sure the device is powered on and connected to the PC.");
                        }
                        else if (errorCode == 0x80210001)
                        {
                            throw new Exception("An unknown error has occurred with the WIA device.");
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}