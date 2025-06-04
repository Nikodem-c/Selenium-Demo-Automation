# Selenium Demo Automation Project

This is a personal automation testing project using **Selenium WebDriver** with **C# (.NET 8)** and **NUnit** on www.saucedemo.com demo website.  
The goal is to build a professional, maintainable framework for web UI testing — suitable for portfolio and job-ready demonstration.

---

# Project Status

- ✅ Base class browser setup implemented
- ✅ `JsonReader` utility for data extraction from JSON
- ✅ `LoginPage` Page Object Model implemented
- ✅ `ProductsPage` Page Object Model implemented
- ✅ `CartPage` Page Object Model implemented
- ✅ `End2End` test setup up to `ProductsPage`
- ✅ `App.config` for browser selection
- ✅ `Data.json` for storing login & product data

🟡 Work in progress:
- 🟡 Extend End-to-End test flow (e.g., cart, checkout)
- 🟡 `CheckOutPage` Page Object Model
- 🟡 Smoke test
- HTML reporting
- CI integration (GitHub Actions)

---

# Technologies Used

- **C# (.NET 8)**
- **Selenium WebDriver**
- **NUnit** (Test framework)
- **WebDriverManager** (Driver binaries management)
- **Page Object Model** (Design pattern)
- **App.config** (Environment config)

---

# Folder Structure
│ SauceDemoAutomation

├── Utilities/ # Base class, Data.json, JsonReader.cs

├── Pages/ # Page Objects: LoginPage, ProductsPage, CartPage

├── Tests/ # Test classes (End-to-End, smoke, etc.)

├── App.config # Browser configuration (Chrome, Firefox, Edge)

└── README.md # This file

---

# How to Run

> 💡 Prerequisites: .NET 8 SDK installed

App.config defines which browser is launched by default.

'bash'

dotnet test

---

# Author
Nikodem C — Automation QA Enthusiast
GitHub: [https://github.com/Nikodem-c]
