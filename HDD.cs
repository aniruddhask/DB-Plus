using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;


namespace CompleteDataBaseAccess
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class HDD
    {
        public HDD()
        { }

        private const int CREATE_NEW = 1;
        private const int OPEN_EXISTING = 3;
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const int FILE_SHARE_READ = 0x1;
        private const int FILE_SHARE_WRITE = 0x2;
        private const int VER_PLATFORM_WIN32_NT = 2;
        private const int DFP_RECEIVE_DRIVE_DATA = 0x7C088;
        private const int INVALID_HANDLE_VALUE = -1;


        public enum DriveTypes { Fixed, Removable, Unknown };
        public string[] DriveStrings = { "Fixed", "Removable", "Unknown" };

        [StructLayout(LayoutKind.Sequential, Size = 8)]
        private class IDEREGS
        {
            public byte Features;
            public byte SectorCount;
            public byte SectorNumber;
            public byte CylinderLow;
            public byte CylinderHigh;
            public byte DriveHead;
            public byte Command;
            public byte Reserved;
        }

        [StructLayout(LayoutKind.Sequential, Size = 32)]
        private class SENDCMDINPARAMS
        {
            public int BufferSize;
            public IDEREGS DriveRegs;
            public byte DriveNumber;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public int[] Reserved2;
            public SENDCMDINPARAMS()
            {
                DriveRegs = new IDEREGS();
                Reserved = new byte[3];
                Reserved2 = new int[4];
            }
        }
        [StructLayout(LayoutKind.Sequential, Size = 12)]
        private class DRIVERSTATUS
        {
            public byte DriveError;
            public byte IDEStatus;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public int[] Reserved2;
            public DRIVERSTATUS()
            {
                Reserved = new byte[2];
                Reserved2 = new int[2];
            }
        }
        /*[StructLayout(LayoutKind.Sequential, Size=12)]
        private class DRIVERSTATUS
        {
        public byte DriveError;
        public byte IDEStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)] public byte []Reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)] public int []Reserved2;
        public DRIVERSTATUS()
        {
        Reserved = new byte[1];
        Reserved2 = new int[1];
        }
        }*/

        [StructLayout(LayoutKind.Sequential)]
        private class IDSECTOR
        {
            public short GenConfig;
            public short NumberCylinders;
            public short Reserved;
            public short NumberHeads;
            public short BytesPerTrack;
            public short BytesPerSector;
            public short SectorsPerTrack;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public short[] VendorUnique;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public char[] SerialNumber;
            public short BufferClass;
            public short BufferSize;
            public short ECCSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public char[] FirmwareRevision;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
            public char[] ModelNumber;
            public short MoreVendorUnique;
            public short DoubleWordIO;
            public short Capabilities;
            public short Reserved1;
            public short PIOTiming;
            public short DMATiming;
            public short BS;
            public short NumberCurrentCyls;
            public short NumberCurrentHeads;
            public short NumberCurrentSectorsPerTrack;
            public int CurrentSectorCapacity;
            public short MultipleSectorCapacity;
            public short MultipleSectorStuff;
            public int TotalAddressableSectors;
            public short SingleWordDMA;
            public short MultiWordDMA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 382)]
            public byte[] Reserved2;
            public IDSECTOR()
            {
                VendorUnique = new short[3];
                Reserved2 = new byte[382];
                FirmwareRevision = new char[8];
                SerialNumber = new char[20];
                ModelNumber = new char[40];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private class SENDCMDOUTPARAMS
        {
            public int BufferSize;
            public DRIVERSTATUS Status;
            public IDSECTOR IDS;
            public SENDCMDOUTPARAMS()
            {
                Status = new DRIVERSTATUS();
                IDS = new IDSECTOR();
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int CloseHandle(int hObject);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        int dwShareMode,
        int lpSecurityAttributes,
        int dwCreationDisposition,
        int dwFlagsAndAttributes,
        int hTemplateFile
        );
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int DeviceIoControl(
        int hDevice,
        int dwIoControlCode,
        [In(), Out()] SENDCMDINPARAMS lpInBuffer,
        int lpInBufferSize,
        [In(), Out()] SENDCMDOUTPARAMS lpOutBuffer,
        int lpOutBufferSize,
        ref int lpBytesReturned,
        int lpOverlapped
        );

        private string SwapChars(char[] chars)
        {
            for (int i = 0; i <= chars.Length - 2; i += 2)
            {
                char t;
                t = chars[i];
                chars[i] = chars[i + 1];
                chars[i + 1] = t;
            }
            string s = new string(chars);
            return s;
        }

        public Hashtable getInfo()
        {
            string serialNumber = " ", model = " ", firmware = " ";
            Hashtable htHardDiskDriveDetails = new Hashtable();
            DriveTypes driveType = DriveTypes.Unknown;
            int handle, returnSize = 0;
            int driveNumber = 0;
            SENDCMDINPARAMS sci = new SENDCMDINPARAMS();
            SENDCMDOUTPARAMS sco = new SENDCMDOUTPARAMS();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                handle = CreateFile("\\\\.\\PhysicalDrive" + "0", GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
            else // for win'9x
                handle = CreateFile("\\\\.\\Smartvsd", 0, 0, 0, CREATE_NEW, 0, 0);
            if (handle != INVALID_HANDLE_VALUE)
            {
                sci.DriveNumber = (byte)driveNumber;
                sci.BufferSize = Marshal.SizeOf(sco);
                sci.DriveRegs.DriveHead = (byte)(0xA0 | driveNumber << 4);
                sci.DriveRegs.Command = 0xEC;
                sci.DriveRegs.SectorCount = 1;
                sci.DriveRegs.SectorNumber = 1;
                if (DeviceIoControl(handle, DFP_RECEIVE_DRIVE_DATA, sci, Marshal.SizeOf(sci), sco, Marshal.SizeOf(sco), ref returnSize, 0) != 0)
                {
                    serialNumber = SwapChars(sco.IDS.SerialNumber);
                    model = SwapChars(sco.IDS.ModelNumber);
                    firmware = SwapChars(sco.IDS.FirmwareRevision);
                }
                htHardDiskDriveDetails.Add("SerialNumber", serialNumber);
                htHardDiskDriveDetails.Add("Model", model);
                htHardDiskDriveDetails.Add("Firmware", firmware);
                if ((sco.IDS.GenConfig & 0x80) == 0x40)
                    driveType = DriveTypes.Removable;
                else if ((sco.IDS.GenConfig & 0x40) == 0x40)
                    driveType = DriveTypes.Fixed;
                else
                    driveType = DriveTypes.Unknown;
                CloseHandle(handle);
                htHardDiskDriveDetails.Add("Type", DriveStrings[(int)driveType]);
                return htHardDiskDriveDetails;
            }
            else
            {
                return htHardDiskDriveDetails;
            }
        }
    }
}
