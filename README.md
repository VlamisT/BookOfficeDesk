# BookOfficeDesk

Set Up Repeated Execution (Optional)
Use macOS Automator or launchd to schedule the application to run every 7 days:
Save the application as an executable:
bash
Copy code
dotnet publish -c Release
Create a launchd plist file:
xml
Copy code
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
Save the file as com.example.OfficeSpaceBookingApp.plist in ~/Library/LaunchAgents/.
Load the job:
bash
Copy code
launchctl load ~/Library/LaunchAgents/com.example.OfficeSpaceBookingApp.plist
