using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
	static void Main()
	{
		// Generate 1000 numbers, each 11 digits long, starting with '2' and ending with '7'
		string[] numbers = GenerateNumbers(1000);

		// Set up the ChromeDriver
		using (IWebDriver driver = new ChromeDriver())
		{
			

			foreach (var number in numbers)
			{
				driver.Navigate().GoToUrl("http://a.com/login");
				// Find the username input field and set the value
				IWebElement usernameField = driver.FindElement(By.Id("username"));
				usernameField.Clear();
				usernameField.SendKeys(number);

				// Find the submit button and click it
				IWebElement submitButton = driver.FindElement(By.ClassName("submit"));
				submitButton.Click();

				Console.WriteLine("Submitted number: " + number);


			}
		}
	}

	static string[] GenerateNumbers(int count)
	{
		string[] numbers = new string[count];
		Random random = new Random();

		for (int i = 0; i < count; i++)
		{
			// Generate the number: start with '2', end with '7', and 9 random digits in between
			numbers[i] = "3" + new string('0', 9) + "7";
			for (int j = 1; j < 10; j++)
			{
				numbers[i] = numbers[i].Substring(0, j) + random.Next(0, 10).ToString() + numbers[i].Substring(j + 1);
			}
		}

		return numbers;
	}
}
