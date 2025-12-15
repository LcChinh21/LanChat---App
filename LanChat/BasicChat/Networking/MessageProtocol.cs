using System;
using System.Collections.Generic;

namespace BasicChat.Networking
{
    public enum MessageType
    {
        LOGIN_REQUEST,
        LOGIN_RESPONSE,
        REGISTER_REQUEST,
        REGISTER_RESPONSE,
        GROUP_MESSAGE,
        PRIVATE_MESSAGE,
        USER_LIST,
        USER_JOINED,
        USER_LEFT,
        GROUP_JOIN,
        GROUP_LEAVE,
        CREATE_GROUP_REQUEST,
        CREATE_GROUP_RESPONSE,
        GROUP_INVITE_REQUEST,
        GROUP_INVITE_RESPONSE,
        LOAD_GROUP_REQUEST,
        LOAD_GROUP_RESPONSE
    }

    public class ChatMessage
    {
        public MessageType Type { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public bool Success { get; set; }
        public string[] UserList { get; set; }
        public DateTime Timestamp { get; set; }

        public string GroupName { get; set; }

        public Dictionary<string, List<string>> GroupList = new Dictionary<string, List<string>>();

        public ChatMessage()
        {
            Timestamp = DateTime.Now;
        }

        public string ToProtocolString()
        {
            string userListStr = UserList != null ? string.Join(",", UserList) : "";
            return $"{(int)Type}|{Sender ?? ""}|{Receiver ?? ""}|{Content ?? ""}|{Success}|{userListStr}|{Timestamp:yyyy-MM-dd HH:mm:ss}";
        }

        public static ChatMessage FromProtocolString(string data)
        {
            try
            {
                string[] parts = data.Split(new char[] { '|' }, 7);
                if (parts.Length < 7) return null;

                var msg = new ChatMessage
                {
                    Type = (MessageType)int.Parse(parts[0]),
                    Sender = parts[1],
                    Receiver = parts[2],
                    Content = parts[3],
                    Success = bool.Parse(parts[4])
                };

                if (!string.IsNullOrEmpty(parts[5]))
                {
                    msg.UserList = parts[5].Split(',');
                }

                if (DateTime.TryParse(parts[6], out DateTime ts))
                {
                    msg.Timestamp = ts;
                }

                return msg;
            }
            catch
            {
                return null;
            }
        }
    }
}
