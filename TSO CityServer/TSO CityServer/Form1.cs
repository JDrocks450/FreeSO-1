﻿/*The contents of this file are subject to the Mozilla Public License Version 1.1
(the "License"); you may not use this file except in compliance with the
License. You may obtain a copy of the License at http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS" basis,
WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
the specific language governing rights and limitations under the License.

The Original Code is the TSO CityServer.

The Initial Developer of the Original Code is
Mats 'Afr0' Vederhus. All Rights Reserved.

Contributor(s): ______________________________________.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Timers;
using TSO_CityServer.Network;


namespace TSO_CityServer
{
    public partial class Form1 : Form
    {
        private CityListener m_Listener;
        private LoginClient m_LoginClient;

        private System.Timers.Timer m_PulseTimer;

        public Form1()
        {
            InitializeComponent();

            bool FoundConfig = ConfigurationManager.LoadCityConfig();

            Logger.Initialize("Log.txt");
            Logger.WarnEnabled = true;
            Logger.DebugEnabled = true;

            if (!FoundConfig)
            {
                Logger.LogWarning("Couldn't find a ServerConfig.ini file!");
                //TODO: This doesn't work...
                Application.Exit();
            }

            m_Listener = new CityListener();
            m_Listener.OnReceiveEvent += new OnReceiveDelegate(m_Listener_OnReceiveEvent);

            m_LoginClient = new LoginClient("127.0.0.1", 2108);
            m_LoginClient.OnNetworkError += new NetworkErrorDelegate(m_LoginClient_OnNetworkError);
            m_LoginClient.Connect();

            //Send a pulse to the LoginServer every second.
            m_PulseTimer = new System.Timers.Timer(1000);
            m_PulseTimer.AutoReset = true;
            m_PulseTimer.Elapsed += new ElapsedEventHandler(m_PulseTimer_Elapsed);
            m_PulseTimer.Start();

            m_Listener.Initialize(2107);
        }

        /// <summary>
        /// Sends a pulse to the LoginServer, to let it know this server is alive.
        /// </summary>
        private void m_PulseTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PacketStream Packet = new PacketStream(0x02, 3);
            Packet.WriteByte(0x02);
            Packet.WriteUInt16(3);
            Packet.Flush();
            m_LoginClient.Send(Packet.ToArray());

            Packet.Dispose();
        }

        /// <summary>
        /// Event triggered if a network error occurs while communicating with
        /// the LoginServer.
        /// </summary>
        /// <param name="Exception"></param>
        private void m_LoginClient_OnNetworkError(SocketException Exc)
        {
            MessageBox.Show(Exc.ToString());
            Application.Exit();
        }

        private void m_Listener_OnReceiveEvent(PacketStream P, CityClient Client)
        {
            byte ID = (byte)P.ReadByte();

            switch (ID)
            {
                case 0x00:
                    PacketHandlers.HandleCharacterCreate(P, Client);
                    break;
                case 0x01:
                    PacketHandlers.HandleClientKeyReceive(P, Client);
                    break;
            }
        }
    }
}
