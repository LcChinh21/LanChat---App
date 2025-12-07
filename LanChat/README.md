# LanChat - Ung Dung Chat Mang LAN

Ung dung chat WinForms C# voi kien truc Client-Server, ho tro chat nhom va chat rieng.

## Yeu Cau He Thong

- **Hệ điều hành**: Windows 10/11
- **IDE**: Visual Studio 2022 (hoac moi hon)
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

## Cai Dat

### Buoc 1: Cau Hinh Database

1. Mo SQL Server Management Studio (SSMS)
2. Ket noi vao SQL Server Express (thong thuong la `.\SQLEXPRESS`)
3. Chay script sau de tao database va bang:

```sql
CREATE DATABASE LanChatDB;
GO

USE LanChatDB;
GO

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO
```

### Buoc 2: Mo Solution

1. Mo file `BasicChat.sln` bang Visual Studio 2022
2. Build solution (Ctrl + Shift + B)

### Buoc 3: Chay Server

1. Click chuot phai vao project `ServerLogConsole`
2. Chon "Set as Startup Project"
3. Nhan F5 de chay
4. Click nut "Chay Server" (port mac dinh: 9999)

### Buoc 4: Chay Client

1. Mo them mot instance Visual Studio
2. Mo cung Solution
3. Click chuot phai vao project `BasicChat`
4. Chon "Set as Startup Project"
5. Nhan F5 de chay
6. Dang ky tai khoan moi hoac dang nhap

## Huong Dan Su Dung

### Server
- Nhap port (mac dinh 9999)
- Click "Chay Server" de bat dau
- Xem log ket noi, dang nhap, tin nhan trong cua so

### Client
1. **Dang ky**: Neu chua co tai khoan, click "Dang ky", nhap username va password
2. **Dang nhap**: Nhap username, password, dia chi server (mac dinh: 127.0.0.1:9999)
3. **Chat nhom**: Chon "Chat Nhom" - tin nhan gui den tat ca nguoi online
4. **Chat rieng**: Chon "Chat Rieng" - chon nguoi nhan tu danh sach ben phai

## Tinh Nang

- Dang ky / Dang nhap tai khoan
- Chat nhom (gui tin nhan cho tat ca)
- Chat rieng (gui tin nhan 1-1)
- Hien thi danh sach nguoi online
- Thong bao khi co nguoi tham gia / roi khoi
- Giao dien don gian, de su dung

## Luu Y

- Server phai chay truoc khi Client ket noi
- Mac dinh su dung SQL Server Express voi Windows Authentication
- Neu dung LocalDB, thay doi connection string trong `DatabaseHelper.cs`:
  ```csharp
  _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LanChatDB;Integrated Security=True";
  ```

## Cau Hinh Nang Cao

### Doi Port Server
Thay doi gia tri trong `txtPort` khi chay server

### Doi Dia Chi Server
Trong form dang nhap, nhap dia chi IP va port cua server (vi du: `192.168.1.100:9999`)

### Chay Tren Nhieu May
1. Chay server tren 1 may
2. Tren cac may khac, chay client va nhap dia chi IP cua may chay server

## Tac Gia

Du an hoc tap WinForms C# - Kien truc Client-Server
