
private void button1_Click(){
    using(WebClient webClient = new WebClient()){
        webClient.DownloadProgressChanged += (s, e) => {progressBar1.Value = e.ProgressPercentage;};
        webClient.DownloadFileAsync(new Uri("yourURL"), @"C:\");
    }
}

private void button1_Click(){
    using(WebClient webClient = new WebClient){
        webClient.DownloadProgressChanged += (s, e) =>
        {
            label1.Text = $"Downloading: {e.ProgressPercentage}%";
            progressBar1.Value = e.ProgressPercentage;
        };
        webClient.DownloadFileAsync(new Uri("yourURL"), @"C:\");
    }
}