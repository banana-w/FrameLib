using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FrameLib.Drive
{
    public class GoogleDrive
    {
        public static string DriveDownloadFile(string authPath, string saveFilePath, string name)
        {
            string fullFilePath = null;
            try
            {

                // Create Drive API service.
                UserCredential credential;
                string[] Scopes = { DriveService.Scope.Drive };
                using (var fileStream = new FileStream(authPath, FileMode.Open, FileAccess.Read))
                {
                    string credentialPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(fileStream).Secrets,
                         Scopes,
                         "user",
                         CancellationToken.None,
                         new FileDataStore(credentialPath, true)).Result;
               
                }
                var service = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                });
                var listSearchFiles = DriveList.ListFiles(service, new DriveList.FilesListOptionalParms() {Q = $"name contains '{name}'" });

                string saveTo = saveFilePath; //"D:/testmagik"

                var request = service.Files.Get(listSearchFiles.Files[0].Id);
                string fileName = request.Execute().Name;
                string fileExtension = Path.GetExtension(fileName);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                string uniqueFileName = $"{fileNameWithoutExtension}_{DateTime.Now.Ticks}{fileExtension}";
                fullFilePath = Path.Combine(saveTo, uniqueFileName);

                var stream = new FileStream(fullFilePath, FileMode.CreateNew, FileAccess.Write);

                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the
                // download is completed or failed.
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine($"{progress.BytesDownloaded * 0.001} KB");
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download complete.");
                                    stream.Flush();
                                    stream.Close();
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {
                                    Console.WriteLine("Download failed.");
                                    break;
                                }
                        }
                    };
                request.Download(stream);
                stream.Close();
                return fullFilePath;

            }
            catch (Exception e)
            {
                // TODO(developer) - handle error appropriately
                if (e is AggregateException)
                {
                    Console.WriteLine("Credential Not found");
                }
                else
                {
                    throw;
                }
            }
            return fullFilePath;
        }
        public static Google.Apis.Drive.v3.Data.File DriveUploadToFolder
            (string authPath,string filePath, string folderId)
        {
            try
            {
                // Create Drive API service.
                UserCredential credential;
                string[] Scopes = { DriveService.Scope.Drive };
                using (var fileStream = new FileStream(authPath, FileMode.Open, FileAccess.Read))
                {
                    string credentialPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(fileStream).Secrets,
                         Scopes,
                         "user",
                         CancellationToken.None,
                         new FileDataStore(credentialPath, true)).Result;

                }
                var service = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                });

                // Upload file photo.jpg in specified folder on drive.
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = "photo.jpg",
                    Parents = new List<string>
                    {
                        folderId
                    }
                };
                FilesResource.CreateMediaUpload request;
                // Create a new file on drive.
                using (var stream = new FileStream(filePath,
                           FileMode.Open))
                {
                    // Create a new file, with metadata and stream.
                    request = service.Files.Create(
                        fileMetadata, stream, "image/jpeg");
                    request.Fields = "id";
                    request.Upload();
                }
                var file = request.ResponseBody;
                // Prints the uploaded file id.
                Console.WriteLine("File ID: " + file.Id);
                return file;
            }
            catch (Exception e)
            {
                // TODO(developer) - handle error appropriately
                if (e is AggregateException)
                {
                    Console.WriteLine("Credential Not found");
                }
                else if (e is FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
                else if (e is DirectoryNotFoundException)
                {
                    Console.WriteLine("Directory Not found");
                }
                else
                {
                    throw;
                }
            }
            return null;
        }

    }
}
