# LanChat - Ung Dung Chat Mang LAN

Ung dung chat WinForms C# voi kien truc Client-Server, ho tro chat nhom va chat rieng.

## Yeu Cau He Thong

- **Framework**: .NET 6.0 Windows
- **Database**: SQL Server Express (LocalDB hoac SQLEXPRESS)

## Cau Truc Du An

```
LanChat/
├── BasicChat.sln              # Solution file
├── BasicChat/                  # Client Project
│   ├── BasicChat.csproj
│   ├── Program.cs
│   ├── DangNhap.cs            # Form dang nhap
│   ├── DangKy.cs              # Form dang ky
│   ├── FormChat.cs            # Form chat chinh
│   └── Networking/
│       ├── ClientSocket.cs     # Xu ly ket noi TCP client
│       └── MessageProtocol.cs  # Protocol truyen tin nhan
│
└── ServerLogConsole/          # Server Project
    ├── ServerLogConsole.csproj
    ├── Program.cs
    ├── Form1.cs               # Giao dien server voi log
    ├── DatabaseHelper.cs      # Xu ly database
    └── Networking/
        ├── ServerSocket.cs     # Xu ly TCP server, nhieu client
        └── MessageProtocol.cs  # Protocol truyen tin nhan
```

## Tac Gia

Du an LanChat WinForm - Do an mon hoc IT008
