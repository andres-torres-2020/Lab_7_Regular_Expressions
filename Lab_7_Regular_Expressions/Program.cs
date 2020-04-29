using System;
using System.Text.RegularExpressions;

namespace Lab_7_Regular_Expressions
{
    class Program
    {
        delegate bool Validate(string input);

        static void Main(string[] args)
        {
            // single name
            GetUserInput("name", "(example, Andy)", IsValidName);
            //IsValidName("Hello"); // valid
            //("Dbaataooooooooooooooooooooooozu"); // invalid - more than 30 chars

            // e-mail address
            GetUserInput("email", "(example, atorres@grandc.co)", IsValidEmail);
            //IsValidEmail("atorres@grandcirc.co"); // valid
            //IsValidEmail("a2a@grandcircus.co"); // invalid, short name
            //IsValidEmail("a@g.co"); // invalid

            // phone
            GetUserInput("phone", "(example, 333-444-5555)", IsValidPhoneNumber);
            //IsValidPhoneNumber("000-111-2222"); // valid
            //IsValidPhoneNumber("000-1e1-2222"); // invalid

            // date
            GetUserInput("date", "(dd/mm/yyyy)", IsValidDate);
            //IsValidDate("00/11/2222"); // valid
            //IsValidDate("00/e1/2222"); // invalid
            //IsValidDate("00/11/222"); // invalid

            // HTML validation
            IsValidHtmlElement_ExtraCredit("<P>some stuff...</p>"); // valid
            IsValidHtmlElement_ExtraCredit("[j]some stuff....[/j]"); // invalid
            IsValidHtmlElement_ExtraCredit("<html><body>some stuff...</body></html>"); // valid
        }
        private static void GetUserInput(string inputType, string promptExample, Validate IsValid)
        {
            Console.Write($"Please enter a valid {promptExample} : ");
            string response = Console.ReadLine().Trim();
            if (IsValid(response))
            {
                Console.WriteLine($"{inputType} is valid!\n");
            }
            else
            {
                Console.WriteLine($"Sorry, {inputType} is not valid!\n");
            }
        }
        public static bool IsValidName(string name)
        {
            // Names can only have alphabets,
            // they should start with a capital letter,
            // and they have a maximum length of 30.
            return Regex.IsMatch(name, "^[A-Z][a-z]{1,29}$");
        }
        public static bool IsValidEmail(string email)
        {
            // An email should be in the following format:
            // 
            // {combination of alphanumeric characters, with a length between 5 and 30, and there are no special characters}
            // @
            // {combination of alphanumeric characters, with a length between 5 and 10, and there are no special characters}
            // .
            // {domain can be a combination of alphanumeric characters with a length of two or three}

            return Regex.IsMatch(email, "^[a-zA-Z0-9]{5,30}[@][a-zA-Z0-9]{5,10}[.][a-zA-Z0-9]{2,3}$");
        }
        public static bool IsValidPhoneNumber(string phone)
        {
            // A phone number should be in the following format:
            //   {area code of 3 digits} - {3 digits} - {4 digits}
            return Regex.IsMatch(phone, "^[0-9]{3}-[0-9]{3}-[0-9]{4}$");
        }
        public static bool IsValidDate(string dt)
        {
            // validate date based on the following format: (dd/mm/yyyy)
            return Regex.IsMatch(dt, "^[0-9]{2}[/][0-9]{2}[/][0-9]{4}$");
        }
        /*
                public static void IsValidName(string name)
                {
                    // Names can only have alphabets,
                    // they should start with a capital letter,
                    // and they have a maximum length of 30.
                    if (Regex.IsMatch(name, "^[A-Z][a-z]{1,29}$"))
                    {
                        Console.WriteLine($"{name} is valid");
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not valid");
                    }
                }
                public static void IsValidEmail(string email)
                {
                    // An email should be in the following format:
                    // 
                    // {combination of alphanumeric characters, with a length between 5 and 30, and there are no special characters}
                    // @
                    // {combination of alphanumeric characters, with a length between 5 and 10, and there are no special characters}
                    // .
                    // {domain can be a combination of alphanumeric characters with a length of two or three}

                    if (Regex.IsMatch(email, "^[a-zA-Z0-9]{5,30}[@][a-zA-Z0-9]{5,10}[.][a-zA-Z0-9]{2,3}$"))
                    {
                        Console.WriteLine($"{email} is valid");
                    }
                    else
                    {
                        Console.WriteLine($"{email} is not valid");
                    }
                }
                public static void IsValidPhoneNumber(string phone)
                {
                    // A phone number should be in the following format:
                    //   {area code of 3 digits} - {3 digits} - {4 digits}
                    if (Regex.IsMatch(phone, "^[0-9]{3}-[0-9]{3}-[0-9]{4}$"))
                    {
                        Console.WriteLine($"{phone} is valid");
                    }
                    else
                    {
                        Console.WriteLine($"{phone} is not valid");
                    }
                }
                public static void IsValidDate(string dt)
                {
                    // validate date based on the following format: (dd/mm/yyyy)
                    if (Regex.IsMatch(dt, "^[0-9]{2}[/][0-9]{2}[/][0-9]{4}$"))
                    {
                        Console.WriteLine($"{dt} is valid");
                    }
                    else
                    {
                        Console.WriteLine($"{dt} is not valid");
                    }
                }
        */
        public static void IsValidHtmlElement_ExtraCredit(string html)
        {
            // validate HTML elements
            //
            // (Example: <p> </p> is a valid html element, and < h1<h1> is not valid.
            // Don’t worry about special cases where you have self - contained HTML elements).

            if (Regex.IsMatch(html, "^<[a-zA-Z]{1,}>.*<[/][a-zA-Z]{1,}>$"))
            {
                Console.WriteLine($"{html} is valid");
            }
            else
            {
                Console.WriteLine($"{html} is not valid");
            }
        }
    }
}
