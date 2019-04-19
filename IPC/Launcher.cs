using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatLauncher.Utils;

namespace VRChatLauncher.IPC
{
    class Launcher
    {
        tiesky.com.SharmIpc sm = null;
        public void Init() {
            if (sm != null) return;
            Logger.Log("Starting IPC Server");
            sm = new tiesky.com.SharmIpc("vrchatlauncher" , this.RemoteCall);
        }

        public void Dispose() {
            if (sm != null) {
                Logger.Log("Disposing IPC Server");
                sm.Dispose();
                sm = null;
            }
        }
        Tuple<bool, byte[]> RemoteCall(byte[] data)
        {
            var ret = new Message(string.Empty, false).ToTuple();
            if (data.Length < 1) return ret;
            var str = ToString(data);
            Logger.Trace("Got IPC Message:", str);
            var cmd = str.Split(new[] { ' ' }, 2);
            var command = cmd[0].ToLower();
            var argument = string.Empty;
            if (cmd.Length > 1) argument = cmd[1];
            switch (command) {
                case "islauncherrunning":
                    ret = new Message("yes").ToTuple();
                    Utils.Utils.BringSelfToFront();
                    foreach (var arg in argument.Split(' ')) {
                        if(arg.ToLower().StartsWith("vrchat://"))
                            Game.SendCommand(arg);
                    }
                    break;
                default:
                    break;
            }
            return ret;
        }
        /*public void AsyncRemoteCallHandler(ulong msgId, byte[] data)
        {
            var ret = new Message(string.Empty, msgId);
            sm.AsyncAnswerOnRemoteCall(ret.Id, ret.ToTuple());
            if (data.Length < 1) return;
            var str = ToString(data);
            Logger.Trace("Got IPC Message async:", str);
        }*/

        public Message MakeRemoteRequestWithResponse(Message message, int timeout = 100) {
            Logger.Trace("Awaiting sync IPC Message for:", message.Str);
            var data = sm.RemoteRequest(message.Bytes, null, timeout);
            var ret = new Message(data.Item2, data.Item1);
            Logger.Trace("Recieved sync IPC Response:", ret.Str);
            return ret;
        }
        /*public async Task<Message> MakeRemoteRequestWithResponseAsync(Message message) {
            Logger.Trace("Awaiting async IPC Message for:", message.Str);
            var data = await sm.RemoteRequestAsync(message.Bytes);
            var ret = new Message(data.Item2, data.Item1);
            Logger.Trace("Recieved async IPC Response:", ret.Str);
            return ret;
        }*/

        public bool MakeRemoteRequestWithoutResponse(Message message) {
            Logger.Trace("Sending IPC Message:", message.Str);
            return sm.RemoteRequestWithoutResponse(message.Bytes);
        }

        private static string ToString(byte[] data) {
            if (data == null) return string.Empty;
            return Encoding.Default.GetString(data);
        }
        private static byte[] ToByteArray(string data) {
            if (string.IsNullOrEmpty(data)) return new byte[] {};
            return Encoding.UTF8.GetBytes(data);
        }
        private static byte[] barray(byte[] data)
        {
            if (data == null) return new byte[] { };
            return data;
        }
        public class Message {
            public bool Send;
            public byte[] Bytes = new byte[] { };
            public string Str;
            public ulong Id;
            public Message(string data, bool send = true) {
                Send = send; Bytes = ToByteArray(data); Str = data;
            }
            public Message(byte[] data, bool send = true) {
                Send = send; Bytes = barray(data); Str = Launcher.ToString(data);
            }
            public Message(string data, ulong id) {
                Send = true; Bytes = ToByteArray(data); Str = data; ; Id = id;
            }
            public Message(byte[] data, ulong id) {
                Send = true; Bytes = barray(data); Str = Launcher.ToString(data); Id = id;
            }
            public Tuple<bool, byte[]> ToTuple() {
                return new Tuple<bool, byte[]>(Send, Bytes);
            }
        }
    }
}
