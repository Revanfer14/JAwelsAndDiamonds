# 💎 JewelsAndDiamonds - Final Project for Pattern Software Design (4th Semester)

**JewelsAndDiamonds** is a simple e-commerce web application built using **ASP.NET Web Forms**, **C#**, and **CSS**, with a **Domain-Driven Design (DDD)** architecture to clearly and structurally separate responsibilities across layers. The application features a **user-friendly** interface, making it easy for users to browse and purchase jewelry online.

---

## 🧱 Tech Stack

- **Frontend**: ASP.NET Web Forms, HTML, CSS  
- **Backend**: C#  
- **Architecture**: Domain-Driven Design (DDD)  
- **Database**: SQL Server (Entity Framework)
- **Reporting**: SAP Crystal Reports

---

## 🧠 Domain-Driven Design (DDD) Architecture

This application implements the **DDD** pattern with the following layer separation:

- **Models** → represent the structure and domain entities (MsUser, Jewel, Cart, Transaction, etc.)
- **Handlers** → handle lightweight business logic such as validation, session, authentication
- **Controllers** → contain the main business logic (e.g., password updates, checkout, cart manipulation)  
- **Views (UI)** → ASPX pages that function solely as the presentation layer

---

## 👤 Roles and Features

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

## 📷 Documentation (some pages)
![Home](https://github.com/user-attachments/assets/66b930c3-c1a9-4f22-bf98-f23ee04b709d)
![Register](https://github.com/user-attachments/assets/5560e9bb-97e8-4850-bbbe-ed0aa4964ccc)
![HandleOrder](https://github.com/user-attachments/assets/2031ce41-4ddd-4fe9-b380-3f93e6f97e63)
![Cart](https://github.com/user-attachments/assets/eb7dbcee-4e78-47db-bfda-ff07679734b7)

---

## 🚀 How to run local

1. **Clone** this repository
2. Open in **Visual Studio 2022**
3. Restore NuGet packages
4. Run the project
---

## 📌 License

This project was created for academic learning purposes and is not intended for production use.

---

