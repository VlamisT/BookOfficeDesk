# BookOfficeDesk
# **Office Space Seat Booking App**

This is a **C# console application** that automates the process of booking a random seat on [Kaizen Gaming Office Space](https://kaizengaming.officespacesoftware.com/). The app selects a date 7 days from the current day, chooses a time, and books a random available seat.

---

## **Features**

- Automatically selects a date **7 days from today**.
- Chooses a time (default: **10:00 AM**) and duration (**8 hours**).
- Randomly selects an available seat to book.
- Supports automated execution every **7 days** using macOS `launchd`.

---

## **Prerequisites**

- macOS with [.NET SDK](https://dotnet.microsoft.com/download) installed (tested on **.NET 8.0**).
- [Microsoft Playwright](https://playwright.dev/) installed for browser automation.

### **Install Playwright**
Run the following commands to install Playwright:
```bash
dotnet tool install --global Microsoft.Playwright.CLI
playwright install
