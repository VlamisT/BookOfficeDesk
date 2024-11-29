
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
```

---

## **Setup Instructions**

### Step 1: Clone the Repository

Clone this repository to your local machine:

```bash
git clone https://github.com/example/office-space-booking.git
```

Navigate to the project folder:

```bash
cd office-space-booking
```

### Step 2: Install Dependencies

Restore the required dependencies:

```bash
dotnet restore
```

---

## **Running the Application**

Run the application using the following command:

```bash
dotnet run --project OfficeSpaceBookingApp
```

---

## **Automate Execution (Optional)**

To schedule the app to run every 7 days:

### Step 1: Publish the Application

Publish the app as a standalone executable:

```bash
dotnet publish -c Release
```

The executable will be available in:

```bash
bin/Release/net8.0/publish/
```

### Step 2: Create a launchd Configuration

Create a new file called `com.example.OfficeSpaceBookingApp.plist` with the following content:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>Label</key>
    <string>com.example.OfficeSpaceBookingApp</string>
    <key>ProgramArguments</key>
    <array>
        <string>/path/to/OfficeSpaceBookingApp</string>
    </array>
    <key>StartInterval</key>
    <integer>604800</integer> <!-- 7 days in seconds -->
</dict>
</plist>
```

Replace `/path/to/OfficeSpaceBookingApp` with the full path to your published executable (e.g., `/Users/username/OfficeSpaceBookingApp/bin/Release/net8.0/publish/OfficeSpaceBookingApp`).

Save the file to `~/Library/LaunchAgents/`:

```bash
mv com.example.OfficeSpaceBookingApp.plist ~/Library/LaunchAgents/
```

### Step 3: Load and Start the Task

Run the following command to load the task:

```bash
launchctl load ~/Library/LaunchAgents/com.example.OfficeSpaceBookingApp.plist
```

---

## **Managing the Scheduled Task**

Verify the job is loaded:

```bash
launchctl list | grep com.example.OfficeSpaceBookingApp
```

Unload the job (if needed):

```bash
launchctl unload ~/Library/LaunchAgents/com.example.OfficeSpaceBookingApp.plist
```

### View Logs (Optional)

Add the following keys to the `.plist` file to capture output:

```xml
<key>StandardOutPath</key>
<string>/path/to/log/output.log</string>
<key>StandardErrorPath</key>
<string>/path/to/log/error.log</string>
```

---

## **License**

This project is licensed under the MIT License - see the LICENSE file for details.
