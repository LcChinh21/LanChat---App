using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        LOAD_GROUP_RESPONSE,
        FILE_SEND,
        GROUP_REMOVE_MEMBER,
        ADD_MEMBER_REQUEST,
        ADD_MEMBER_RESPONSE,
        HISTORY_REQUEST,
        HISTORY_RESPONSE,
        SEARCH_USER_REQUEST,
        SEARCH_USER_RESPONSE
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

        public List<ChatMessage> HistoryList { get; set; } = new List<ChatMessage>();

        public ChatMessage()
        {
            Timestamp = DateTime.Now;
        }

        public string ToProtocolString()
        {
            string userListStr = UserList != null ? string.Join(",", UserList) : "";

            string groupListStr = "";
            if (GroupList != null && GroupList.Count > 0)
            {
                var groupParts = GroupList.Select(kvp =>
                    $"{kvp.Key}:{string.Join(",", kvp.Value)}"
                );
                groupListStr = string.Join(";", groupParts);
            }

            string historyStr = "";
            if (HistoryList != null && HistoryList.Count > 0)
            {
                var historyParts = HistoryList.Select(m =>
                    $"{m.Sender}|{Convert.ToBase64String(Encoding.UTF8.GetBytes(m.Content))}|{m.Timestamp:yyyy-MM-dd HH:mm:ss}"
                );
                historyStr = string.Join(";", historyParts);
            }

            return $"{(int)Type}|{Sender ?? ""}|{Receiver ?? ""}|{Content ?? ""}|{Success}|{userListStr}|{Timestamp:yyyy-MM-dd HH:mm:ss}|{groupListStr}|{historyStr}";
        }

        public static ChatMessage FromProtocolString(string data)
        {
            try
            {
                string[] parts = data.Split(new char[] { '|' }, 9);
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

                if (parts.Length > 7 && !string.IsNullOrEmpty(parts[7]))
                {
                    string[] groups = parts[7].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string g in groups)
                    {
                        string[] gParts = g.Split(new char[] { ':' }, 2);
                        if (gParts.Length == 2)
                        {
                            string gName = gParts[0];
                            string[] gMembers = gParts[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            msg.GroupList[gName] = new List<string>(gMembers);
                        }
                    }
                }

                if (parts.Length > 8 && !string.IsNullOrEmpty(parts[8]))
                {
                    string[] msgs = parts[8].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string mStr in msgs)
                    {
                        string[] mParts = mStr.Split(new char[] { '|' }, 3);
                        if (mParts.Length == 3)
                        {
                            try
                            {
                                string content = Encoding.UTF8.GetString(Convert.FromBase64String(mParts[1]));
                                msg.HistoryList.Add(new ChatMessage
                                {
                                    Sender = mParts[0],
                                    Content = content,
                                    Timestamp = DateTime.Parse(mParts[2])
                                });
                            }
                            catch { }
                        }
                    }
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
