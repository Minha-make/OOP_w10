- **Ma sinh vien:** 202418890
- **Ho ten:** Nguyen Minh Ha
- **Lop:** Lap trinh huong doi tuong (OOP)

---

## 1. Vi tri su dung tung Pattern va Loi ich

| Pattern | Vi tri su dung trong ma nguon | Loi ich dat duoc |
| :--- | :--- | :--- |
| **Factory Pattern** | Lop `DeviceFactory` (phuong thuc `Create`) | - Tach biet logic khoi tao cac doi tuong thiet bi cu the (`SmartLight`, `SmartFan`, `SmartDoor`) ra khoi client.<br>- Client chi can phu thuoc vao abstraction `IDevice` va truyen vao chuoi dinh danh loai thiet bi thay vi goi truc tiep `new`. |
| **Singleton Pattern** | Lop `HomeConfiguration` (su dung `Lazy<HomeConfiguration>`) | - Dam bao cau hinh chung cua toan bo ngoi nha (`HomeName`, `NightLightLevel`) chi co duy nhat mot the hien duoc tao ra trong toan bo ung dung.<br>- Khoi tao luoi (lazy initialization) va an toan luong (thread-safe). |
| **Facade Pattern** | Lop `SmartHomeFacade` (phuong thuc `GoToWork`, `GoToSleep`) | - Cung cap mot giao dien cap cao don gian de dieu phoi mot nhom thao tac phuc tap tren nhieu thiet bi khac nhau.<br>- Giam su phu thuoc (coupling) giua client va cac lop thiet bi con. |

---

## 2. Han che cua thiet ke

- **Han che:** `DeviceFactory` su dung cau truc `switch` theo chuoi ky tu nen khi can them thiet bi moi (vi du `SmartCamera`), lap trinh vien bat buoc phai sua doi truc tiep ma nguon cua lop `DeviceFactory` (vi pham nguyen ly Open/Closed Principle - OCP).

---

## 3. Tra loi cau hoi ly thuyet va phan bien

### A. Cau hoi phan tich (Phan C)
1. **Factory da che giau dieu gi doi voi client?**
   - Factory che giau viec chon va goi constructor cua lop cu the nao (`SmartLight`, `SmartFan`, `SmartDoor`), quy tac anh xa tu chuoi loai thiet bi (`"light"`, `"fan"`, `"door"`) sang lop tuong ung, cung nhu quy trinh chuan hoa chuoi dau vao (`Trim()`, `ToLowerInvariant()`).
2. **Khi them `SmartCamera`, nhung thanh phan nao can sua?**
   - Can tao moi lop `SmartCamera` (cai dat `IDevice`).
   - Sua phuong thuc `Create` trong `DeviceFactory` de bo sung nhanh case moi (`"camera" => new SmartCamera(name)`).

### B. Cau hoi phan bien (Phan D)
1. **Constructor phai co muc truy cap nao?**
   - Constructor phai co muc truy cap `private` de ngan chan cac doi tuong ben ngoai goi `new HomeConfiguration()`, dam bao kiem soat chat che viec khoi tao thong qua thuoc tinh `Instance`.
2. **Vi sao lop duoc danh dau `sealed`?**
   - Danh dau `sealed` nham ngan chan cac lop khac ke thua `HomeConfiguration`. Neu cho phep ke thua, lop con co the pha vo tinh duy nhat cua the hien Singleton (vi du bang cach dinh nghia lai constructor hoac tao ra instance cua lop con).
3. **Singleton gay kho khan gi cho unit test?**
   - Singleton tao ra trang thai toan cuc (global state) dung chung giua cac ca kiem thu, dan den viec cac test case co the phu thuoc lan nhau va gay ra hieu ung le (side-effects).
   - Singleton co constructor private nen rat kho hoac khong the mock/stub bang cac thu vien kiem thu, gay can tro viec viet unit test doc lap.
4. **Neu dung .NET Dependency Injection voi lifetime `AddSingleton`, co con nhat thiet phai tu cai Singleton pattern khong?**
   - Khong nhat thiet. Khi su dung DI container voi `services.AddSingleton<HomeConfiguration>()`, container se chiu trach nhiem quan ly vong doi va dam bao chi cap phat mot the hien duy nhat trong suot vong doi ung dung. Khi do lop co the co constructor `public` binh thuong, giup ma nguon linh hoat hon va rat de dang mock khi viet kiem thu.

### C. Cau hoi tong ket (Phan G)
1. **Factory dang che giau quyet dinh thiet ke nao?**
   - Factory che giau quyet dinh lua chon kieu lop cu the (concrete type selection) va cach thuc tao ra doi tuong do. Client chi lam viec dua tren hop dong truu tuong (`IDevice`).
2. **Singleton bao dam dieu gi, nhung tao ra rui ro nao?**
   - **Bao dam:** Duy nhat mot the hien cua lop ton tai trong toan bo ung dung va cung cap mot diem truy cap toan cuc thong nhat.
   - **Rui ro:** Dong vai tro nhu bien toan cuc (global state), lam tang su phu thuoc ngam (hidden coupling) giua cac thanh phan trong chuong trinh, kho kiem thu va vi pham nguyen ly Single Responsibility Principle (lop vua quan ly du lieu vua tu quan ly vong doi cua minh).
3. **Facade khac Factory o muc dich chinh nhu the nao?**
   - **Factory** thuoc nhom *Creational Pattern* (mau khoi tao), muc dich chinh la quan ly va che giau quy trinh tao lap doi tuong.
   - **Facade** thuoc nhom *Structural Pattern* (mau cau truc), muc dich chinh la cung cap giao dien cap cao don gian hon de dieu khien mot tap hop cac doi tuong/he thong con phuc tap da ton tai.
4. **Neu bo `SmartHomeFacade`, client se phai biet them nhung chi tiet nao?**
   - Client se phai truc tiep nam giu va quan ly tung thiet bi rieng le (`IDevice light`, `IDevice fan`, `ILockable door`).
   - Client phai tu nho va thuc hien chinh xac quy trinh/thu tu cac buoc cho tung kich ban (vi du khi di ngu phai tu tat quat, khoa cua, bat den, doc `NightLightLevel` tu `HomeConfiguration` va in ra thong bao). Dieu nay lam ma nguon cua client tro nen cong kenh va phu thuoc chat che vao cau truc cua tung thiet bi.

---
