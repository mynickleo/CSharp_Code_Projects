        //Есть панель Panel 1 - объект для Drag and Drop


        private void panel1_DragDrop(object sender, DragEventArgs e) //Перетащили и отпустили
        {
            label1.Text = "Перетащите сюда файл";

            List<string> paths = new List<string>();

            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))
                if (Directory.Exists(obj))
                    paths.AddRange(Directory.GetFiles(obj, "*.*", SearchOption.AllDirectories));
                else
                    paths.Add(obj);

            label2.Text = string.Join("\r\n", paths);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e) //Только перетаскиваем, НО еще не отпустили
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                label1.Text = "Отпустите мышь";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panel1_DragLeave(object sender, EventArgs e) //Вышли за пределы Panel 1
        {
            label1.Text = "Перетащите сюда файл";
        }