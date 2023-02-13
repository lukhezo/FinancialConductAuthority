using FinancialConductAuthority.Response;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace FinancialConductAuthority
{
    class Program
    {
        private static readonly Uri BaseAddress = new Uri("https://register.fca.org.uk/services/");

        static async Task Main(string[] args)
        {
            Console.Title = "Financial Conduct Authority - Proof of Concept v " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            bool isNumeric;
            string firmReferenceNumber; 
            do
            {
                Console.Write("Please enter a firm reference number:");
                firmReferenceNumber = Console.ReadLine().Trim();
                isNumeric = int.TryParse(firmReferenceNumber, out _);
                Console.WriteLine();
            } while (!isNumeric);

            ConsoleKeyInfo cki;
            Console.WriteLine("View API responses in console screen or web browser (Y/N):");
            do
            {
                cki = Console.ReadKey();
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");

                if (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("View API responses in console screen or web browser (Y/N):");
                    Console.WriteLine($"You entered {cki.Key}");
                }


            } while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);


            Console.WriteLine();

            int choice = -1;

            while (choice != 20)
            {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine();
                Console.WriteLine("1. Firm");
                Console.WriteLine("2. Other Names");
                Console.WriteLine("3. Address");
                Console.WriteLine("4. Individuals");
                Console.WriteLine("5. Permissions");
                Console.WriteLine("6. Requirements");
                Console.WriteLine("7. Regulators");
                Console.WriteLine("8. Passports & Permissions");
                Console.WriteLine("9. Waivers");
                Console.WriteLine("10. Exclusions");
                Console.WriteLine("11. Disciplinary History");
                Console.WriteLine("12. Appointed Representative");
                Console.WriteLine("13. Individual Details");
                Console.WriteLine("20. Exit");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (System.FormatException)
                {
                    // Set to invalid value
                    choice = -1;
                }

                switch (choice)
                {
                    case 1:
                        await Firm(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 2:
                        await OtherNames(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 3:
                        await Address(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 4:
                        await Individuals(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 5:
                        await Permissions(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 6:
                        await Requirements(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 7:
                        await Regulators(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 8:
                        await Passports(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 9:
                        await Waivers(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 10:
                        await Exclusions(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 11:
                        await DisciplinaryHistory(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 12:
                        await AppointedRepresentative(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 13:
                        await IndividualDetails(firmReferenceNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 20:
                        // Exit the program
                        Console.WriteLine("Goodbye...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }


        private static async Task Firm(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<FirmResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task OtherNames(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Names";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<OtherNamesResponse>(response);

            //Just for Viewing in Console Screen
            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);
        
            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Address(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Address";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<AddressResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Individuals(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Individuals";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<IndividualsResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Permissions(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Permissions";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<PermissionsResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Requirements(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Requirements";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<IndividualsResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Regulators(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Regulators";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<RegulatorsResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Passports(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Passports";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<PassportResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

   

            foreach (var d in obj.Data)
            {
                foreach (var p in d.Passports)
                {
                    var permissionQuery = $"V0.1/Firm/{firmReferenceNumber}/Passports/{p.Country}/Permission/";
                    var permissionResponse = await client.GetStringAsync(permissionQuery);
                    var permissionObj = JsonConvert.DeserializeObject<PermissionResponse>(permissionResponse);
                    formattedReponse += Environment.NewLine;
                    formattedReponse += JsonConvert.SerializeObject(permissionObj, Formatting.Indented);
                }
            }

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }



        private static async Task Waivers(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Waivers";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<WaiversResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Exclusions(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/Exclusions";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<ExclusionsResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }


        private static async Task DisciplinaryHistory(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/DisciplinaryHistory";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<DisciplinaryHistoryResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task AppointedRepresentative(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");

            var query = $"V0.1/Firm/{firmReferenceNumber}/AR";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<AppointedRepresentativeResponse>(response);

            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task IndividualDetails(string firmReferenceNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Auth-Email", "ira.lukhezo@brokernetwork.co.uk");
            client.DefaultRequestHeaders.Add("X-Auth-Key", "64b5bb69fc3efad3cf253931f67bbd8e");
           
            var iQuery = $"V0.1/Firm/{firmReferenceNumber}/Individuals";
            var iResponse = await client.GetStringAsync(iQuery);
            var iObj = JsonConvert.DeserializeObject<IndividualsResponse>(iResponse);
          
            string formattedReponse = "";
            //string formattedReponse = JsonConvert.SerializeObject(iObj, Formatting.Indented);

            foreach (var info in iObj.Data)
            {
                var query = $"V0.1/Individuals/{info.IRN}";
                var response = await client.GetStringAsync(query);
                var obj = JsonConvert.DeserializeObject<InvidualDetailsResponse>(response);
                formattedReponse += JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            
            //foreach (var info in iObj.Data)
            //{
            //    var cfQuery = $"V0.1/Individuals/{info.IRN}/CF";
            //    var cfResponse = await client.GetStringAsync(cfQuery);
            //    var cfObj = JsonConvert.DeserializeObject<ControlledFunctionResponse>(cfResponse);
            //    formattedReponse += JsonConvert.SerializeObject(cfObj, Formatting.Indented);
            //}

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        public static void OpenInWebBrowser(string formattedReponse)
        {
            string file = Path.GetTempPath() + Guid.NewGuid().ToString() + ".json";
            File.WriteAllText(file, formattedReponse);

            var StartInfo = new ProcessStartInfo()
            {
                Arguments = file,
                FileName = "msedge.exe",
                //FileName = "iexplore.exe",
                UseShellExecute = true
            };
            Process.Start(StartInfo);
        }
    }
}
