# Selenium Demo Automation Project

---

# Project Status

- ✅ Base class browser setup implemented
- ✅ JsonReader utility for data extraction from JSON
- ✅ LoginPage Page Object Model implemented
- ✅ ProductsPage Page Object Model implemented
- ✅ CartPage Page Object Model implemented
- ✅ End2End test setup up to ProductsPage
- ✅ Smoke test setup
- ✅ App.config for browser selection
- ✅ Data.json for storing login & product data

🟡 Work in progress:
- 🟡 Extend End-to-End test flow (e.g., cart, checkout)
- HTML reporting
- CI integration (GitHub Actions)

---

# Technologies Used

- C# (.NET 8)
- Selenium WebDriver
- NUnit (Test framework)
- WebDriverManager (Driver binaries management)
- Page Object Model (Design pattern)
- App.config (Environment config)
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
