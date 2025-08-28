# 📦 StockSystem

A simple **inventory management system** written in C# with **JSON persistence**.  
This project was created for learning purposes, focusing on:

- Object-Oriented Programming (OOP)
- Data persistence using JSON
- Basic CRUD operations (Create, Read, Update, Delete)
- Console-based interaction

---

## 🚀 Features

- Add new products (with name, quantity, price).
- List all products.
- Update stock quantities.
- Remove products.
- Save and load data from a JSON file automatically.

---

## 🛠️ Technologies

- C# (.NET 6+)
- System.Text.Json for JSON serialization
- Console Application

---

## 📂 Project Structure

StockSystem/
├── Program.cs # Main entry point
├── Models/ # Contains Product.cs
├── Services/ # Contains InventoryService.cs
├── stock.json # Data file generated after first run
└── README.md

---

## ▶️ How to Run

1. Clone the repository:
   ```bash
   git clone git@github.com:Leinad0202/StockSystem.git

2. Navigate to the project folder:
   ```bash
   cd StockSystem

3. Build and run:
   ```bash
   dotnet run

## 📖 Future Improvements

Add a search system by product name or ID.

Implement categories for products.

Add unit tests.

Create a GUI (Windows Forms/WPF/MAUI).

## 📜 License

This project is licensed under the MIT License.
Feel free to use and modify it!
