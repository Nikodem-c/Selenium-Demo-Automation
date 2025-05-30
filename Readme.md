# Selenium Automation Demo Project

This is a personal automation testing project using **Selenium WebDriver** with **C# (.NET 8)** and **NUnit** on www.saucedemo.com demo website.  
The goal is to build a professional, maintainable framework for web UI testing — suitable for portfolio and job-ready demonstration.

---

# Project Status

✅ Base test setup implemented  
✅ App.config for browser selection  
✅ Initial folder structure:  
- `Utilities/` (Base classes)  
- `Pages/` (Page Object Model - LoginPage placeholder created)
- `Tests/` (Contains a demo test for initial setup)

🟡 Work in progress:
- LoginPage implementation
- Data-driven login test
- HTML reporting
- CI integration (GitHub Actions)

---

# Technologies Used

- C# (.NET 8)
- Selenium WebDriver
- NUnit
- WebDriverManager
- App.config configuration
- Page Object Pattern (Ongoing)

---

# Folder Structure
│
├── Utilities/ # Base classes like browser setup
├── Pages/ # Page Object Models (LoginPage, etc.)
├── Tests/ # Test classes (End-to-End, smoke, etc.)
├── App.config # Browser config
└── README.md # This file

---

# How to Run

> 💡 Prerequisites: .NET 8 SDK installed

App.config defines which browser is launched by default.

`bash`
dotnet test

---

# Author
Nikodem C — Automation QA Enthusiast
GitHub: [https://github.com/Nikodem-c]