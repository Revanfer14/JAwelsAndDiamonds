# 💎 JewelsAndDiamonds - Pattern Software Design' Final Project

**JewelsAndDiamonds** adalah sebuah web aplikasi e-commerce sederhana yang dibuat menggunakan **ASP.NET Web Forms**, **C#**, dan **CSS**, dengan arsitektur **Domain-Driven Design (DDD)** untuk memisahkan tanggung jawab antar lapisan secara bersih dan terstruktur. Aplikasi ini memiliki tampilan **user-friendly**, memudahkan pengguna untuk menjelajahi dan membeli perhiasan secara online.

---

## 🧱 Tech Stack

- **Frontend**: ASP.NET Web Forms, HTML, CSS  
- **Backend**: C#  
- **Architecture**: Domain-Driven Design (DDD)  
- **Database**: SQL Server (Entity Framework)
- **Reporting**: SAP Crystal Reports

---

## 🧠 Arsitektur Domain-Driven Design (DDD)

Aplikasi ini mengimplementasikan pola **DDD** dengan pembagian lapisan berikut:

- **Models** → merepresentasikan struktur dan entitas domain (MsUser, Jewel, Cart, Transaction, dll)  
- **Handlers** → menangani business logic ringan seperti validasi, session, autentikasi  
- **Controllers** → berisi business logic utama (misalnya update password, checkout, manipulasi cart)  
- **Views (UI)** → halaman ASPX yang hanya berfungsi sebagai lapisan presentasi  

---

## 👤 Role & Fitur

### 🔑 Guest
- 🔍 View Jewels
- 🔐 Login
- 📝 Register

### 🛍️ Customer
- 🔍 View Jewels
- ➕ Add Jewels to Cart
- ✏️ Update Cart Item
- ❌ Remove / Clear Cart
- 💳 Checkout Cart
- 👤 View Profile
- 🔑 Change Password
- 📜 View Transactions History
- 📄 View Transaction Details

### 🛠️ Admin
- 📦 View Jewels
- ➕ Insert New Jewels
- ✏️ Update Jewels
- ❌ Delete Jewels
- 👤 View Profile
- 🔑 Change Password
- 📬 Handle Orders
- 📊 View Transactions Report

---

## 🚀 Cara Menjalankan

1. **Clone** repository ini
2. Buka di **Visual Studio 2022**
3. Restore NuGet packages
4. Run projectnya
---

## 📌 License

Proyek ini dibuat untuk keperluan pembelajaran akademik dan tidak ditujukan untuk produksi.

---

