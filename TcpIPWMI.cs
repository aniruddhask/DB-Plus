using System;
using System.Management;
using System.Windows.Forms;

namespace CompleteDataBaseAccess
{

    public class TcpIPWMI
    {

        public void setIP(string IPAddress, string SubnetMask, string Gateway)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if (!(bool)objMO["IPEnabled"])
                    continue;

                try
                {
                    ManagementBaseObject objNewIP = null;
                    ManagementBaseObject objSetIP = null;
                    ManagementBaseObject objNewGate = null;
                    objNewIP = objMO.GetMethodParameters("EnableStatic");
                    objNewGate = objMO.GetMethodParameters("SetGateways");

                    objNewGate["DefaultIPGateway"] = new string[] { Gateway };
                    objNewGate["GatewayCostMetric"] = new int[] { 1 };
                    objNewIP["IPAddress"] = new string[] { IPAddress };
                    objNewIP["SubnetMask"] = new string[] { SubnetMask };
                    objSetIP = objMO.InvokeMethod("EnableStatic", objNewIP, null);
                    objSetIP = objMO.InvokeMethod("SetGateways", objNewGate, null);

                    MessageBox.Show("Updated IPAddress!" + IPAddress);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Set IP : " + ex.Message);

                }

            }
        }

        public void ListIP()
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if (!(bool)objMO["ipEnabled"])
                    continue;

                MessageBox.Show(objMO["Caption"] + "," + objMO["ServiceName"] + "," + objMO["MACAddress"]);
                string[] ipaddresses = (string[])objMO["IPAddress"];
                string[] subnets = (string[])objMO["IPSubnet"];
                string[] gateways = (string[])objMO["DefaultIPGateway"];

                foreach (string sGate in gateways)


                    MessageBox.Show("Ipaddress");
                foreach (string sIP in ipaddresses)
                    MessageBox.Show(sIP);

                foreach (string sNet in subnets)
                    MessageBox.Show(sNet);
            }

        }

        public TcpIPWMI()
        {

        }


    }
}
