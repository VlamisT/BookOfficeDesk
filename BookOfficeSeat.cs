using Microsoft.Playwright;

namespace BookSeat;

abstract class BookOfficeSeat
{
    static async Task Main()
    {
        Console.WriteLine("Starting booking task...");

        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        try
        {
            
            string url = "https://kaizengaming.officespacesoftware.com/";
            await page.GotoAsync(url);
            Console.WriteLine($"Accessed {url} at {DateTime.Now}");
           
            await page.ClickAsync("[class='MuiTypography-root jss85 jss154 MuiTypography-body1 MuiTypography-displayBlock']");
            
            await page.ClickAsync("[data-testid='date-select-input']");
            var targetDate = DateTime.Now.AddDays(7);
            var targetDay = targetDate.Day.ToString();
            // Ensure the target date is visible
            while (true)
            {
                // Check if the target date is visible
                var dateIsVisible = await page.Locator($"text='{targetDay}'").IsVisibleAsync();
                if (dateIsVisible)
                    break;

                // Click the next button to navigate to the next month
                await page.ClickAsync("[data-testid='picker-navbar-next-button']");
            }
            
            await page.ClickAsync($"text=\"{targetDate.Day}\"");

            // Time picker
            await page.ClickAsync("[data-testid='time-picker']");
            await page.ClickAsync("li[data-value='10:00 AM']");

            
            await page.Locator("[class='MuiFormControl-root-559 jss719'] [data-testid='time-picker']").Nth(1).ClickAsync();
            await page.ClickAsync("[class='jss717']:has-text('8h')");
            
            var seatOptions = await page.Locator("[data-testid='book-button']").ElementHandlesAsync();
            var random = new Random();
            await seatOptions[random.Next(seatOptions.Count)].ClickAsync();

            Console.WriteLine("Seat booked successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            await browser.CloseAsync();
        }
    }
}