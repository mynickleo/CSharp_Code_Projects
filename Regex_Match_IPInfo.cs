        
        //---> MAIN Code <---//
        private void button1_Click(object sender, EventArgs e) //Обработка кнопки - Получить IP Info
        {
            string line = "";

            using (WebClient webClient = new WebClient())
                line = webClient.DownloadString($"http://free.ipwhois.io/json/{ipInfoTextBox.Text}");

            Match match = Regex.Match(line, "\"continent\":\"(.*?)\",(.*?)\"country\":\"(.*?)\",(.*?)\"region\":\"(.*?)\",(.*?)\"city\":\"(.*?)\",(.*?)\"timezone_gmt\":\"(.*?)\",");

            labelIPInfo.Text = match.Groups[1].Value + "\n" + match.Groups[3].Value + "\n" + match.Groups[5].Value + "\n" + match.Groups[7].Value + "\n" + match.Groups[9].Value + " GMT";
        }
        //---> End <---//

        private void ipInfoTextBox_TextChanged(object sender, EventArgs e) //Input Label, который дает вводить только цифры и .
        {
            if (Regex.IsMatch(ipInfoTextBox.Text, "[^0-9-.]"))
            {
                ipInfoTextBox.Text = ipInfoTextBox.Text.Remove(ipInfoTextBox.Text.Length - 1);
                ipInfoTextBox.SelectionStart = ipInfoTextBox.TextLength;
            }
        }

        //---> Обработчики кнопок на форме
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                button1_Click(button1, null);
        }

        private void ipInfoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                button1_Click(button1, null);
        }
        //<---end