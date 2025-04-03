# Lumos Decoration - Backend

## Overview

Lumos Decoration is an e-commerce platform where customers can place orders for decorations, employees manage orders, and admins oversee operations.

This repository contains the **backend API**, built using **C# .NET (ASP.NET Core)** with **JWT authentication, role-based access, and file handling**.

---

## Tech Stack

- **ASP.NET Core** - Backend API
- **Entity Framework Core** - ORM for database management
- **SQL Server / MySQL** - Database
- **JWT Authentication** - Secure login & role-based access
- **Swagger** - API documentation

---

## Features

### **Customer**
- Register & login with **JWT authentication**
- Browse products & place orders
- View order history

### **Employee**
- View & manage assigned orders
- Update order status
- Track earnings & allowances

### **Admin**
- Manage users, employees & products
- Oversee orders & reports

### **Authentication & Authorization**
- Secure **JWT-based authentication**
- **Role-based access control (RBAC)** for Admin, Employee, and Customer

### **File Upload Handling**
- Customers & employees can upload images
- Uploaded files are stored in **`wwwroot/uploads/`**

