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
- ✅ HTML reporting
- ✅ Parallel test execution using ThreadLocal & NUnit ParallelScope

🟡 Work in progress:
- 🟡 Extend End-to-End test flow (e.g., cart, checkout)
- CI integration (GitHub Actions)

---

# Technologies Used

- **C# (.NET 8)**
- **Selenium WebDriver**
- **NUnit** (Test framework)
- **WebDriverManager** (Driver binaries management)
- **ExtentReports** (HTML reports)
- **Page Object Model** (Design pattern)
- **App.config** (Environment config)
- **ThreadLocal<T>** (WebDriver instance isolation for parallelism)

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

To run all tests:

- 'bash'
- dotnet test

To run tests by category:

- 'bash'

- dotnet test --filter "Category=Smoke"
- dotnet test --filter "Category=Negative"
- dotnet test --filter "Category=End2End"

---

# Author
Nikodem C — Automation QA Enthusiast
GitHub: [https://github.com/Nikodem-c]
