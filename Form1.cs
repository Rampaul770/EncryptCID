using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Text;
using System.Runtime.InteropServices;
using System.Management;

namespace CPUID
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
		private System.Windows.Forms.TextBox txtKeysID;
        private System.Windows.Forms.Label label1;
        private Button btnCreateKeys;
        private TextBox txtNewKeysID;
        private Label label2;
        private Label label3;
        private TextBox txtUnlockKey;
        private Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtKeysID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateKeys = new System.Windows.Forms.Button();
            this.txtNewKeysID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnlockKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtKeysID
            // 
            this.txtKeysID.Location = new System.Drawing.Point(120, 24);
            this.txtKeysID.Name = "txtKeysID";
            this.txtKeysID.Size = new System.Drawing.Size(280, 20);
            this.txtKeysID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Validation Keys";
            // 
            // btnCreateKeys
            // 
            this.btnCreateKeys.Location = new System.Drawing.Point(11, 50);
            this.btnCreateKeys.Name = "btnCreateKeys";
            this.btnCreateKeys.Size = new System.Drawing.Size(75, 23);
            this.btnCreateKeys.TabIndex = 0;
            this.btnCreateKeys.Text = "Create Keys";
            this.btnCreateKeys.Click += new System.EventHandler(this.btnCreateKeys_Click);
            // 
            // txtNewKeysID
            // 
            this.txtNewKeysID.Location = new System.Drawing.Point(120, 88);
            this.txtNewKeysID.Name = "txtNewKeysID";
            this.txtNewKeysID.Size = new System.Drawing.Size(280, 20);
            this.txtNewKeysID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Serial Keys";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(92, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "ZFKey.key";
            // 
            // txtUnlockKey
            // 
            this.txtUnlockKey.Location = new System.Drawing.Point(120, 114);
            this.txtUnlockKey.Name = "txtUnlockKey";
            this.txtUnlockKey.PasswordChar = '*';
            this.txtUnlockKey.Size = new System.Drawing.Size(280, 20);
            this.txtUnlockKey.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Unlock Key";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(424, 146);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUnlockKey);
            this.Controls.Add(this.txtNewKeysID);
            this.Controls.Add(this.txtKeysID);
            this.Controls.Add(this.btnCreateKeys);
            this.Name = "Form1";
            this.Text = "Create ZFKeys";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		#region Get CPU Info
		public class GetInfo
		{
        
			/// <summary>
			/// return Volume Serial Number from hard drive
			/// </summary>
			/// <param name="strDriveLetter">[optional] Drive letter</param>
			/// <returns>[string] VolumeSerialNumber</returns>
			public string GetVolumeSerial(string strDriveLetter)
			{
				if( strDriveLetter=="" || strDriveLetter==null) strDriveLetter="C";
				ManagementObject disk = 
					new ManagementObject("win32_logicaldisk.deviceid=\"" + strDriveLetter +":\"");
				disk.Get();
				return disk["VolumeSerialNumber"].ToString();
			}
        
			/// <summary>
			/// Returns MAC Address from first Network Card in Computer
			/// </summary>
			/// <returns>[string] MAC Address</returns>
			public string GetMACAddress()
			{
				ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection moc = mc.GetInstances();
				string MACAddress=String.Empty;
				foreach(ManagementObject mo in moc)
				{
					if(MACAddress==String.Empty)  // only return MAC Address from first card
					{
						if((bool)mo["IPEnabled"] == true) MACAddress= mo["MacAddress"].ToString() ;
					}
					mo.Dispose();
				}
				MACAddress=MACAddress.Replace(":","");
				return MACAddress;
			}
			/// <summary>
			/// Return processorId from first CPU in machine
			/// </summary>
			/// <returns>[string] ProcessorId</returns>
			public string GetCPUId()
			{
				string cpuInfo =  String.Empty;
				string temp=String.Empty;
				ManagementClass mc = new ManagementClass("Win32_Processor");
				ManagementObjectCollection moc = mc.GetInstances();
				foreach(ManagementObject mo in moc)
				{
					if(cpuInfo==String.Empty) 
					{// only return cpuInfo from first CPU
						cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
					}             
				}
				return cpuInfo;
			}
		}
		#endregion

        private void btnCreateKeys_Click(object sender, EventArgs e)
        {
            if (!txtUnlockKey.Text.ToUpper().Equals("APIN LUPO"))
            {
                MessageBox.Show("Password Salah");
                return;
            }

            string encryptz = EncryptMYKEYID(txtKeysID.Text);

            System.IO.FileStream file;
            string STR_KEY_FILE = "ZFKey.key";

            file = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + @"\" + STR_KEY_FILE, System.IO.FileMode.Create);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(file);

            writer.WriteLine(encryptz);

            writer.Close();
            file.Close();

            txtNewKeysID.Text = encryptz;
            MessageBox.Show("File Keys has been successfully Created!!!", "My Programs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string EncryptMYKEYID()
        {
            return EncryptMYKEYID(string.Empty);
        }

        private string EncryptMYKEYID(string ValidationKey)
        {
            DateTime now = DateTime.Now;
            string strTgl = string.Empty;
            string cpuID = string.Empty;

            if (ValidationKey == string.Empty)
            {
                try
                {
                    GetInfo cpuInfo = new GetInfo();

                    cpuID = cpuInfo.GetCPUId();
                }
                catch
                {
                    MessageBox.Show("Error Get Encryption Keys", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }

            strTgl = now.Year.ToString("0000") + now.Month.ToString("00") + now.Day.ToString("00");

            System.Text.StringBuilder strEncrypt = new System.Text.StringBuilder();
            char myCodeDecrypt;
            int[] SecretCode = new int[] { 7, 10, 5, 14, 20, 3, 11, 9, 25 };

            string strResult = string.Empty;

            for (int i = 0, idxPjg = strTgl.Length, idxCode = 0, pjgIdxCode = 9; i < idxPjg; i++)
            {
                myCodeDecrypt = (char)((int)((char)strTgl[i]) + SecretCode[idxCode++]);
                if (idxCode >= pjgIdxCode)
                    idxCode = 0;

                strEncrypt.Append(myCodeDecrypt);
            }

            for (int i = 0, idxPjg = cpuID.Length, idxCode = 0, pjgIdxCode = 9; i < idxPjg; i++)
            {
                myCodeDecrypt = (char)((int)((char)cpuID[i]) + SecretCode[idxCode++]);
                if (idxCode >= pjgIdxCode)
                    idxCode = 0;

                strEncrypt.Append(myCodeDecrypt);
            }

            strResult = strEncrypt.ToString();
            return strResult;
        }
	}
}
