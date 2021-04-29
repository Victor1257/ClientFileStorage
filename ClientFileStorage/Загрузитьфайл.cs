using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace ClientFileStorage
{
    public class Загрузитьфайл
    {
        public string Link;
        public string IdUser;
        public HttpClient client;

        public Загрузитьфайл(string Link1, string IdUser1, HttpClient httpClient)
        {
            Link = Link1;
            IdUser = IdUser1;
            client = httpClient;
        }


        public async void загрузитьФайлToolStripMenuItem_Click1(string FileNamePath,bool IsFile,int id,string MustBeEx)
        {
            var fileName = new DirectoryInfo(FileNamePath).Name;
            long Size = new System.IO.FileInfo(FileNamePath).Length;
            try
            {
                using (FileStream FS = new FileStream(FileNamePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    HttpResponseMessage response = await client.PostAsync("api/user8/Upload?fileName="+fileName, new StreamContent(FS));
                    //await _connection.InvokeAsync("WriteToDataBase", fileName, IdUser,IsFile,Size);
                    //await _connection.InvokeAsync("Executed", true, IdUser, id,MustBeEx);
                }
                string[] data = new string[3];
                data[0] = "fileName";
                data[1] = "IsFile";
                data[2] = "Size";
                var js = JsonSerializer.Serialize(data);
                HttpContent c = new StringContent(js, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync("api/user9/WriteToDataBase",c);
                responseMessage.EnsureSuccessStatusCode();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                File.Delete(FileNamePath); 
            }
        }
    }
}

