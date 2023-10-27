using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Net;
using RestSharp;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using WindowsInput.Native;
using WindowsInput;
using System.Security.Policy;
using System;

namespace GetRaceInfo
{
    public partial class Form1 : Form
    {
        ChromeDriver g_driver;
        ChromeOptions g_options;
        ChromeDriverService g_driverService;
        SelectElement g_selectOption;
        bool g_init = false;
        bool g_local_flag = false;
        Dictionary<int, string> g_monthDictionary = new Dictionary<int, string>
        {
            { 1, "January" },
            { 2, "February" },
            { 3, "March" },
            { 4, "April" },
            { 5, "May" },
            { 6, "June" },
            { 7, "July" },
            { 8, "August" },
            { 9, "September" },
            { 10, "October" },
            { 11, "November" },
            { 12, "December" }
        };
        List<string> g_allURL = new List<string>();
        List<string> g_allPdfName = new List<string>();
        public Form1()
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (!g_local_flag)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            //textBox1.Clear();
            if (g_init)
            {
                DateTime startTime = dateTimePicker_start.Value;
                DateTime endTime = dateTimePicker_end.Value;
                for (int i = startTime.Year; i < endTime.Year + 1; i++)
                {
                    //遍历需要处理的年份
                    SelectElement yearSelector = new SelectElement(g_driver.FindElement(By.Name("YEAR")));
                    yearSelector.SelectByText(i.ToString());
                    IWebElement searchButton = g_driver.FindElement(By.CssSelector("input[value='Search']"));
                    searchButton.Click();
                    //遍历需要处理的月份
                    if (i == endTime.Year)
                    {
                        if (i == startTime.Year)
                        {
                            for (int j = startTime.Month; j < endTime.Month + 1; j++)
                            {
                                GetAllURL(j.ToString());
                            }
                        }
                        else
                        {
                            for (int j = 1; j < endTime.Month + 1; j++)
                            {
                                GetAllURL(j.ToString());
                            }
                        }
                    }
                    else
                    {
                        if (i == startTime.Year)
                        {
                            for (int j = startTime.Month; j < 13; j++)
                            {
                                GetAllURL(j.ToString());
                            }
                        }
                        else
                        {
                            for (int j = 1; j < 13; j++)
                            {
                                GetAllURL(j.ToString());
                            }
                        }
                    }
                }
                DownloadPDF();
            }
            ParsePDF();



        }
        public void DownloadPDF()
        {

            string trackPattern = "track=([A-Z]+)";
            string datePattern = "raceDate=([0-9/]+)";
            string cyPattern = "cy=([A-Z]+)";

            Match trackMatch;
            Match dateMatch;
            Match cyMatch;

            for (int i = 0; i < g_allURL.Count; i++)
            {
                g_driver.Navigate().GoToUrl(g_allURL[i]);
                IWebElement fullCard = g_driver.FindElement(By.CssSelector("a[target='new']"));
                string fullCardUrl = fullCard.GetAttribute("href");
                g_driver.Navigate().GoToUrl(fullCard.GetAttribute("href"));
                IWebElement fullPdf = g_driver.FindElements(By.CssSelector("a[class='button btn-block returnIndex']"))[1];
                string pdfUrl = fullPdf.GetAttribute("href");
                g_driver.Navigate().GoToUrl(pdfUrl);
                //Thread.Sleep(1000);



                Thread.Sleep(int.Parse(textBox_delay.Text) / 2);



                InputSimulator simulator = new InputSimulator();
                simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_S);
                Thread.Sleep(int.Parse(textBox_delay.Text) / 2);
                // 输入文件名（假设文件名是 "text1"）/html/body/embed
                //SendKeys.SendWait(pdfName);





                trackMatch = Regex.Match(fullCardUrl, trackPattern);
                dateMatch = Regex.Match(fullCardUrl, datePattern);
                cyMatch = Regex.Match(fullCardUrl, cyPattern);

                string track = trackMatch.Groups[1].Value;
                string date = dateMatch.Groups[1].Value;
                string cy = cyMatch.Groups[1].Value;
                string dateFormat = DateTime.Parse(date).ToString("MMddyy");
                //string pdfUrl = $"https://www.equibase.com/static/chart/pdf/{track}{dateFormat}{cy}.pdf";
                string pdfName = textBox_save_path.Text + $"\\{track}{dateFormat}{cy}";
                if (File.Exists(pdfName + ".pdf"))
                {
                    File.Delete(pdfName + ".pdf");
                }
                //g_driver.Navigate().GoToUrl($"{pdfUrl}");

                //string pdfName = textBox_save_path.Text + $"\\{i}.pdf";
                //SaveRemoteFile(pdfName, pdfUrl);
                //g_allPdfName.Add(pdfName);
                simulator.Keyboard.TextEntry(pdfName);
                Thread.Sleep(int.Parse(textBox_delay.Text));
                // 模拟按下Enter键以确认保存
                //simulator.Keyboard.KeyPress(VirtualKeyCode.TAB);
                simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                //simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                //SendKeys.SendWait("{ENTER}");
                Thread.Sleep(int.Parse(textBox_delay.Text) / 2);
                g_allPdfName.Add(pdfName + ".pdf");
                //ConvertUrlToPdf(pdfUrl, pdfName);




                //using (HttpClient client = new HttpClient())
                //{
                //    byte[] pdfBytes = client.GetByteArrayAsync(pdfUrl).Result;
                //    //Thread.Sleep(1000);
                //    // 将获取到的 PDF 数据保存到本地
                //    string pdfName = textBox_save_path.Text + $"\\{i}.pdf";
                //    File.WriteAllBytes(pdfName, pdfBytes);
                //    g_allPdfName.Add(pdfName);

                //}
                //using (RestClient client = new RestClient(pdfUrl))
                //{
                //    var request = new RestRequest("GET");

                //    RestResponse response = client.Execute(request);

                //    if (response.IsSuccessful)
                //    {
                //        string pdfName = $"{i}.pdf";
                //        File.WriteAllBytes(pdfName, response.RawBytes);
                //        Console.WriteLine("文件下载成功！");
                //    }
                //    else
                //    {
                //        Console.WriteLine($"HTTP请求失败: {response.StatusCode} - {response.StatusDescription}");
                //    }
                //}





            }
            //g_driver.Quit();
            this.WindowState = FormWindowState.Normal;
        }

        public void ParsePDF()
        {
            StringBuilder writeToFileText = new StringBuilder();
            var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");
            worksheet.Cells[1, 1].Value = "Date";
            worksheet.Cells[1, 2].Value = "horse number";

            worksheet.Cells[1, 4].Value = "Win";
            worksheet.Cells[1, 5].Value = "Place";
            worksheet.Cells[1, 6].Value = "Show";
            int startRow = 2;
            foreach (var pdfName in g_allPdfName)
            {
                string pdfFilePath = pdfName; // 替换为你的 PDF 文件的路径
                //string startText = "Pgm Horse Name Start Str 1 Str Fin";
                //string endText = "Trainers";
                Dictionary<int, string> dic_horseName;

                using (PdfReader pdfReader = new PdfReader(pdfFilePath))
                {

                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    //for (int page = 1; page <= 1; page++)
                    {

                        dic_horseName = new Dictionary<int, string>();
                        string raceIdx = "";
                        string track = "";
                        string outputDate_1 = "";
                        string outputDate_2 = "";
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string pageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                        if (!pageText.Contains("Pgm Horse Name Start"))
                        {
                            continue;
                        }
                        // 查找指定的文本起始位置
                        string startText = "";
                        string endText = "\n";
                        int startIndex = pageText.IndexOf(startText);
                        int endIndex = pageText.IndexOf(endText);
                        if (startIndex != -1 && endIndex != -1)
                        {
                            string relevantText = pageText.Substring(startIndex, endIndex - startIndex + endText.Length);
                            //string relevantText = pageText.Substring(startIndex);
                            string[] lines = relevantText.Split('\n');

                            foreach (string line in lines)
                            {
                                // 处理每一行文本，例如，打印到控制台
                                //if (line.Split(' ').Count() >= 4 && !line.StartsWith("Pgm"))
                                if (line.Contains("Race") || line.Contains("-"))
                                {
                                    string[] arr_line = line.Split("-");
                                    track = Regex.Replace(arr_line[0], "[^a-zA-Z0-9\\s]", "");



                                    string raceDate = arr_line[1];
                                    // 将日期字符串解析为 DateTime 对象
                                    DateTime date = DateTime.Parse(raceDate);
                                    CultureInfo culture = new CultureInfo("en-US");
                                    // 将日期格式化为 "MMMM dS yyyy" 格式
                                    string formattedDate = date.ToString("MMMM d", culture) + GetDaySuffix(date.Day) + date.ToString(" yyyy");
                                    // 输出日期对应的英文星期几
                                    string dayOfWeek = date.ToString("dddd", culture);
                                    outputDate_1 = dayOfWeek + " " + formattedDate;
                                    outputDate_2 = date.ToString("MMddyyyy");
                                    if (page == 1)
                                    {
                                        writeToFileText.AppendLine(outputDate_1);
                                        writeToFileText.AppendLine(outputDate_2);
                                        writeToFileText.AppendLine();
                                    }
                                    raceIdx = arr_line[2];
                                    writeToFileText.AppendLine(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(track.Trim().ToLower()) + " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(raceIdx.Trim().ToLower()));


                                    //string cleanedString = Regex.Replace(line, "[^a-zA-Z0-9\\s]", "");
                                    //textBox1.AppendText(line);
                                    //textBox1.AppendText(Environment.NewLine);
                                }

                            }
                        }
                        //time
                        startText = "at:";
                        endText = "Start:";
                        startIndex = pageText.IndexOf(startText) + 4;
                        endIndex = pageText.IndexOf(endText) - 7;
                        if (startIndex != -1 && endIndex > 0)
                        {
                            string relevantText = pageText.Substring(startIndex, endIndex - startIndex + endText.Length);
                            //string relevantText = pageText.Substring(startIndex);
                            string[] lines = relevantText.Split('\n');

                            foreach (string line in lines)
                            {

                                string raceTime = line.Trim();
                                writeToFileText.AppendLine(raceTime);
                                //textBox1.AppendText(line);
                                //textBox1.AppendText(Environment.NewLine);


                            }
                        }
                        //race info
                        startText = "Pgm Horse Name Start";
                        endText = "Trainers";
                        startIndex = pageText.IndexOf(startText);
                        endIndex = pageText.IndexOf(endText);
                        if (startIndex != -1 && endIndex != -1)
                        {
                            string relevantText = pageText.Substring(startIndex, endIndex - startIndex + endText.Length);
                            //string relevantText = pageText.Substring(startIndex);
                            string[] lines = relevantText.Split('\n');

                            foreach (string line in lines)
                            {
                                if (line.Split(' ').Count() >= 4 && !line.StartsWith("Pgm"))
                                {
                                    string[] arr_pgmHorseName = line.Split(" ");
                                    int pgm = int.Parse(arr_pgmHorseName[0]);
                                    string horseName = string.Join(" ", arr_pgmHorseName.SkipLast(2).Skip(1).ToArray());
                                    dic_horseName.Add(pgm, horseName.Replace(".","").Replace("'",""));

                                }

                                //textBox1.AppendText(line);
                                //textBox1.AppendText(Environment.NewLine);


                            }
                        }

                        if (checkBox_sort.Checked == true)
                        {
                            foreach (var item in dic_horseName.Keys.OrderBy(key => key))
                            {
                                writeToFileText.AppendLine(item + " " + dic_horseName[item]);
                            }
                        }
                        else
                        {
                            foreach (var item in dic_horseName.Keys)
                            {
                                writeToFileText.AppendLine(item + " " + dic_horseName[item]);
                            }
                        }

                        writeToFileText.AppendLine();

                        if (checkBox_pool.Checked == true)
                        {


                            // 添加一个工作表

                            if (page == 1)
                            {
                                worksheet.Cells[1, 3].Value = track;
                                worksheet.Cells[startRow, 1].Value = ".." + outputDate_2;
                                startRow++;
                            }
                            worksheet.Cells[startRow, 1].Value = raceIdx;
                            // 写入数据到单元格





                            Console.WriteLine("Excel 文件写入成功！");

                            startText = "Pgm Horse Win";
                            endText = "Wager Type";
                            startIndex = pageText.IndexOf(startText);
                            endIndex = pageText.IndexOf(endText);
                            if (startIndex != -1 && endIndex != -1)
                            {
                                string relevantText = pageText.Substring(startIndex, endIndex - startIndex + endText.Length);
                                //string relevantText = pageText.Substring(startIndex);
                                string[] lines = relevantText.Split('\n');

                                string[] arr_first = lines[1].Split(" ");
                                worksheet.Cells[startRow, 2].Value = arr_first[0];
                                worksheet.Cells[startRow, 3].Value = dic_horseName[int.Parse(arr_first[0])];
                                int curCol = 4;
                                foreach (var item in arr_first.Skip(1 + dic_horseName[int.Parse(arr_first[0])].Split(" ").Count()))
                                {
                                    worksheet.Cells[startRow, curCol].Value = item;
                                    curCol++;
                                }
                                startRow++;
                                string[] arr_second = lines[2].Split(" ");
                                worksheet.Cells[startRow, 2].Value = arr_second[0];
                                worksheet.Cells[startRow, 3].Value = dic_horseName[int.Parse(arr_second[0])];
                                curCol = 5;
                                foreach (var item in arr_second.Skip(1 + dic_horseName[int.Parse(arr_second[0])].Split(" ").Count()))
                                {
                                    worksheet.Cells[startRow, curCol].Value = item;
                                    curCol++;
                                }
                                startRow++;
                                string[] arr_thrid = lines[3].Split(" ");
                                worksheet.Cells[startRow, 2].Value = arr_thrid[0];
                                worksheet.Cells[startRow, 3].Value = dic_horseName[int.Parse(arr_thrid[0])];
                                curCol = 6;
                                foreach (var item in arr_thrid.Skip(1 + dic_horseName[int.Parse(arr_thrid[0])].Split(" ").Count()))
                                {
                                    worksheet.Cells[startRow, curCol].Value = item;
                                    curCol++;
                                }
                                startRow++;
                                startRow++;

                            }
                        }
                        //string[] lines = pageText.Split('\n');

                        //foreach (string line in lines)
                        //{
                        //    // 处理每一行文本，例如，打印到控制台
                        //    string processedLine = ProcessLine(line);
                        //    textBox1.AppendText(line);
                        //    textBox1.AppendText(Environment.NewLine);
                        //}
                    }
                }
            }
            
            File.WriteAllText(textBox_save_path.Text + "\\output.txt", writeToFileText.ToString());
            // 保存工作簿到文件
            if (checkBox_pool.Checked)
            {
                worksheet.Cells.AutoFitColumns();
                var fileInfo = new System.IO.FileInfo(textBox_save_path.Text + "\\output.xlsx");
                package.SaveAs(fileInfo);
            }
            MessageBox.Show("OK");
        }


        public string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 13)
            {
                return "th";
            }

            switch (day % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }
        public void GetAllURL(string month)
        {
            IWebElement monthTable = g_driver.FindElement(By.Id($"mon{month}"));
            IWebElement tableDate = monthTable.FindElements(By.ClassName("fullwidth"))[1];
            IList<IWebElement> lst_date = tableDate.FindElements(By.TagName("td"));
            foreach (var item in lst_date)
            {
                try
                {
                    IWebElement font_td = item.FindElement(By.TagName("a"));
                    DateTime curDate = DateTime.Parse(font_td.GetAttribute("title"));
                    if (curDate.Date >= dateTimePicker_start.Value.Date && curDate.Date <= dateTimePicker_end.Value.Date)
                    {
                        g_allURL.Add(font_td.GetAttribute("href"));
                    }
                    else if (curDate.Date > dateTimePicker_end.Value.Date)
                    {
                        return;
                    }
                    //textBox1.AppendText(font_td.GetAttribute("title"));

                    //textBox1.AppendText(Environment.NewLine);
                }
                catch { }

            }
        }
        private void comboBox_trackid_SelectedIndexChanged(object sender, EventArgs e)
        {
            g_selectOption = new SelectElement(g_driver.FindElement(By.Name("trackid")));

            g_selectOption.SelectByText(comboBox_trackid.SelectedItem.ToString());



        }


        private void dateTimePicker_start_Leave(object sender, EventArgs e)
        {
            if (dateTimePicker_start.Value <= DateTime.Now)
            {
                SelectElement monthSelector = new SelectElement(g_driver.FindElement(By.Name("month")));
                monthSelector.SelectByText(g_monthDictionary[dateTimePicker_start.Value.Month]);
                SelectElement yearSelector = new SelectElement(g_driver.FindElement(By.Name("YEAR")));
                yearSelector.SelectByText(dateTimePicker_start.Value.Year.ToString());
                IWebElement searchButton = g_driver.FindElement(By.CssSelector("input[value='Search']"));
                searchButton.Click();
            }
        }

        private void button_init_Click(object sender, EventArgs e)
        {
            g_local_flag = false;
            comboBox_trackid.SelectedIndexChanged -= comboBox_trackid_SelectedIndexChanged;
            comboBox_trackid.SelectedIndex = -1;
            comboBox_trackid.SelectedIndexChanged += comboBox_trackid_SelectedIndexChanged;
            comboBox_trackid.Items.Clear();

            g_driver.Navigate().GoToUrl("https://www.equibase.com/premium/eqbRaceChartCalendar.cfm?refresh=1");
            IWebElement trackidSelector = g_driver.FindElement(By.Name("trackid"));

            g_selectOption = new SelectElement(trackidSelector);
            IList<IWebElement> lst_option = g_selectOption.Options;
            foreach (IWebElement trackid in lst_option.Skip(1))
            {
                comboBox_trackid.Items.Add(trackid.Text);
            }
            g_init = true;
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            g_allPdfName.Clear();
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "PDF|*.pdf";
            diag.Multiselect = true;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in diag.FileNames)
                {
                    g_allPdfName.Add(item);
                }
                g_local_flag = true;
                //tbInputFile.Text = diag.FileName;
            }
            //ParsePDF();

        }

        private void button_open_browser_Click(object sender, EventArgs e)
        {
            g_options = new ChromeOptions();
            g_driverService = ChromeDriverService.CreateDefaultService();
            g_driverService.HideCommandPromptWindow = true;
            g_driver = new ChromeDriver(g_driverService, g_options);
            g_driver.Navigate().GoToUrl("https://www.equibase.com/premium/eqbRaceChartCalendar.cfm?refresh=1");


        }

        private void button_save_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox_save_path.Text = dialog.SelectedPath;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_driver != null)
            {
                g_driver.Quit();
            }
            
        }
    }
}