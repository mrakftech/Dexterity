using System.Text;
using Shared.Wrapper;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Blazor.FileManager;

namespace Services.Features.Settings.Service;

public class FileService : IFileManagerService
{
    private readonly List<FileManagerDirectoryContent> _copyFiles = new();
    private readonly List<FileManagerDirectoryContent> _data = new();

    public FileService()
    {
        GetData();
    }
    public async Task<IResult> CreateWordFile(string fileName, string content)
    {
        try
        {
            var root = CreateDirectory("Letters");
            var path = Path.Combine(root, $"temp.html");
            await File.WriteAllTextAsync(path, content);

            //Load an existing HTML file.
            await using var inputFileStream =
                new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var document = new WordDocument(inputFileStream, FormatType.Html);

            //Save the Word document as DOCX format.
            await using var outputFileStream =
                new FileStream(Path.Combine(root, $"{fileName}.docx"), FileMode.Create, FileAccess.ReadWrite);
            document.Save(outputFileStream, FormatType.Docx);

            return await Result.SuccessAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return await Result.FailAsync();
        }
    }

    public string GetFilePath(string folderName)
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot/Files/{folderName}");
    }

    private static string CreateDirectory(string folderName)
    {
        var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot/Files/{folderName}");
        var exists = Directory.Exists(root);
        if (!exists)
            Directory.CreateDirectory(root);
        return root;
    }

    private void GetData()
    {
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterPath = "",
            FilterId = "",
            HasChild = true,
            Id = "0",
            IsFile = false,
            Name = "Files",
            ParentId = null,
            ShowHiddenItems = false,
            Size = 1779448,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/",
            FilterPath = "/",
            HasChild = false,
            Id = "1",
            IsFile = false,
            Name = "Documents",
            ParentId = "0",
            ShowHiddenItems = false,
            Size = 680786,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/",
            FilterPath = "/",
            HasChild = false,
            Id = "2",
            IsFile = false,
            Name = "Downloads",
            ParentId = "0",
            ShowHiddenItems = false,
            Size = 6172,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/",
            FilterPath = "/",
            HasChild = false,
            Id = "3",
            IsFile = false,
            Name = "Music",
            ParentId = "0",
            ShowHiddenItems = false,
            Size = 20,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/",
            FilterPath = "/",
            HasChild = false,
            Id = "4",
            IsFile = false,
            Name = "Videos",
            ParentId = "0",
            ShowHiddenItems = false,
            Size = 20,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/1/",
            FilterPath = "/Documents/",
            HasChild = false,
            Id = "5",
            IsFile = true,
            Name = "EJ2 File Manager.docx",
            ParentId = "1",
            ShowHiddenItems = false,
            Size = 12403,
            Type = ".docx"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/1/",
            FilterPath = "/Documents/",
            HasChild = false,
            Id = "6",
            IsFile = true,
            Name = "EJ2 File Manager.pdf",
            ParentId = "1",
            ShowHiddenItems = false,
            Size = 90099,
            Type = ".pdf"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/1/",
            FilterPath = "/Documents/",
            HasChild = false,
            Id = "7",
            IsFile = true,
            Name = "File Manager PPT.pptx",
            ParentId = "1",
            ShowHiddenItems = false,
            Size = 578010,
            Type = ".pptx"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/1/",
            FilterPath = "/Documents/",
            HasChild = false,
            Id = "8",
            IsFile = true,
            Name = "File Manager.txt",
            ParentId = "1",
            ShowHiddenItems = false,
            Size = 274,
            Type = ".txt"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/2/",
            FilterPath = "/Downloads/",
            HasChild = false,
            Id = "9",
            IsFile = true,
            Name = "Sample Work Sheet.xlsx",
            ParentId = "2",
            ShowHiddenItems = false,
            Size = 6172,
            Type = ".xlsx"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/3/",
            FilterPath = "/Music/",
            HasChild = false,
            Id = "10",
            IsFile = true,
            Name = "Music.mp3",
            ParentId = "3",
            ShowHiddenItems = false,
            Size = 10,
            Type = ".mp3"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/3/",
            FilterPath = "/Music/",
            HasChild = false,
            Id = "11",
            IsFile = true,
            Name = "Sample Music.mp3",
            ParentId = "3",
            ShowHiddenItems = false,
            Size = 10,
            Type = ".mp3"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/4/",
            FilterPath = "/Videos/",
            HasChild = false,
            Id = "12",
            IsFile = true,
            Name = "Demo Video.mp4",
            ParentId = "4",
            ShowHiddenItems = false,
            Size = 10,
            Type = ".mp4"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/4/",
            FilterPath = "/Videos/",
            HasChild = false,
            Id = "13",
            IsFile = true,
            Name = "Sample Video.mp4",
            ParentId = "4",
            ShowHiddenItems = false,
            Size = 10,
            Type = ".mp4"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/",
            FilterPath = "/",
            HasChild = true,
            Id = "14",
            IsFile = false,
            Name = "Pictures",
            ParentId = "0",
            ShowHiddenItems = false,
            Size = 1092490,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/",
            FilterPath = "/Pictures/",
            HasChild = false,
            Id = "15",
            IsFile = false,
            Name = "Employees",
            ParentId = "14",
            ShowHiddenItems = false,
            Size = 324650,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/15/",
            FilterPath = "/Pictures/Employees/",
            HasChild = false,
            Id = "16",
            IsFile = true,
            Name = "1.png",
            ParentId = "15",
            ShowHiddenItems = false,
            Size = 49792,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/15/",
            FilterPath = "/Pictures/Employees/",
            HasChild = false,
            Id = "17",
            IsFile = true,
            Name = "2.png",
            ParentId = "15",
            ShowHiddenItems = false,
            Size = 50801,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/15/",
            FilterPath = "/Pictures/Employees/",
            HasChild = false,
            Id = "18",
            IsFile = true,
            Name = "3.png",
            ParentId = "15",
            ShowHiddenItems = false,
            Size = 48951,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/15/",
            FilterPath = "/Pictures/Employees/",
            HasChild = false,
            Id = "19",
            IsFile = true,
            Name = "4.png",
            ParentId = "15",
            ShowHiddenItems = false,
            Size = 46393,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/15/",
            FilterPath = "/Pictures/Employees/",
            HasChild = false,
            Id = "20",
            IsFile = true,
            Name = "5.png",
            ParentId = "15",
            ShowHiddenItems = false,
            Size = 66523,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/15/",
            FilterPath = "/Pictures/Employees/",
            HasChild = false,
            Id = "21",
            IsFile = true,
            Name = "6.png",
            ParentId = "15",
            ShowHiddenItems = false,
            Size = 62190,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/",
            FilterPath = "/Pictures/",
            HasChild = false,
            Id = "22",
            IsFile = false,
            Name = "Foods",
            ParentId = "14",
            ShowHiddenItems = false,
            Size = 299969,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/22/",
            FilterPath = "/Pictures/Foods/",
            HasChild = false,
            Id = "23",
            IsFile = true,
            Name = "bread.png",
            ParentId = "22",
            ShowHiddenItems = false,
            Size = 100486,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/22/",
            FilterPath = "/Pictures/Foods/",
            HasChild = false,
            Id = "24",
            IsFile = true,
            Name = "doughnut.png",
            ParentId = "22",
            ShowHiddenItems = false,
            Size = 99344,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/22/",
            FilterPath = "/Pictures/Foods/",
            HasChild = false,
            Id = "25",
            IsFile = true,
            Name = "nuggets.png",
            ParentId = "22",
            ShowHiddenItems = false,
            Size = 100139,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/",
            FilterPath = "/Pictures/",
            HasChild = false,
            Id = "26",
            IsFile = false,
            Name = "Nature",
            ParentId = "14",
            ShowHiddenItems = false,
            Size = 467871,
            Type = "folder"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/26/",
            FilterPath = "/Pictures/Nature/",
            HasChild = false,
            Id = "27",
            IsFile = true,
            Name = "bird.png",
            ParentId = "26",
            ShowHiddenItems = false,
            Size = 102182,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/26/",
            FilterPath = "/Pictures/Nature/",
            HasChild = false,
            Id = "28",
            IsFile = true,
            Name = "sea.png",
            ParentId = "26",
            ShowHiddenItems = false,
            Size = 97145,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/26/",
            FilterPath = "/Pictures/Nature/",
            HasChild = false,
            Id = "29",
            IsFile = true,
            Name = "seaview.png",
            ParentId = "26",
            ShowHiddenItems = false,
            Size = 95866,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/26/",
            FilterPath = "/Pictures/Nature/",
            HasChild = false,
            Id = "30",
            IsFile = true,
            Name = "snow.png",
            ParentId = "26",
            ShowHiddenItems = false,
            Size = 74666,
            Type = ".png"
        });
        _data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/14/26/",
            FilterPath = "/Pictures/Nature/",
            HasChild = false,
            Id = "31",
            IsFile = true,
            Name = "snowfall.png",
            ParentId = "26",
            ShowHiddenItems = false,
            Size = 98012,
            Type = ".png"
        });
    }

    public async Task<FileManagerResponse<FileManagerDirectoryContent>> ReadAsync(string path,
        List<FileManagerDirectoryContent> fileDetails)
    {
        var response = new FileManagerResponse<FileManagerDirectoryContent>();
        if (path == "/")
        {
            var parentId = _data
                .Where(x => x.FilterPath == string.Empty)
                .Select(x => x.Id).First();
            response.CWD = _data.First(x => x.FilterPath == string.Empty);
            response.Files = _data
                .Where(x => x.ParentId == parentId).ToList();
        }
        else
        {
            var id = fileDetails.Count > 0 && fileDetails[0] != null
                ? fileDetails[0].Id
                : _data
                    .Where(x => x.FilterPath == path)
                    .Select(x => x.ParentId).First();
            response.CWD = _data
                .Where(x => x.Id == (fileDetails.Count > 0 && fileDetails[0] != null ? fileDetails[0].Id : id)).First();
            response.Files = _data
                .Where(x => x.ParentId == (fileDetails.Count > 0 && fileDetails[0] != null ? fileDetails[0].Id : id))
                .ToList();
        }

        await Task.Yield();
        return await Task.FromResult(response);
    }

    public async Task<FileManagerResponse<FileManagerDirectoryContent>> DeleteAsync(string path,
        List<FileManagerDirectoryContent> fileDetails)
    {
        var response = new FileManagerResponse<FileManagerDirectoryContent>();
        var idsToDelete = fileDetails.Cast<FileManagerDirectoryContent>().Select(x => x.Id).ToList();
        var parentId = fileDetails[0].ParentId;
        idsToDelete.AddRange(_data.Where(file => idsToDelete.Contains((file).ParentId)).Select(file => (file).Id));
        _data.RemoveAll(file => idsToDelete.Contains((file).Id));
        response.Files = fileDetails.ToList();
        _data.Where(x => parentId == x.Id).Select(x => x).FirstOrDefault()!.HasChild =
            _data.Count(x => (parentId == x.ParentId) && x.IsFile == false) > 0;
        return await Task.FromResult(response);
    }

    public async Task<FileManagerResponse<FileManagerDirectoryContent>> CreateAsync(string path, string name,
        FileManagerDirectoryContent fileDetails)
    {
        var response = new FileManagerResponse<FileManagerDirectoryContent>();
        var newFolder = new List<FileManagerDirectoryContent>();
        var idValue = _data.Select(x => x).Select(x => x.Id).ToArray().Select(int.Parse).ToArray().Max();
        await Task.Yield();
        newFolder.Add(new FileManagerDirectoryContent()
        {
            Id = (idValue + 1).ToString(),
            Name = name,
            Size = 0,
            DateCreated = DateTime.Now,
            DateModified = DateTime.Now,
            Type = "",
            ParentId = fileDetails.Id,
            HasChild = false,
            FilterPath = path,
            FilterId = fileDetails.FilterId + fileDetails.Id + "/",
            IsFile = false,
        });
        response.Files = newFolder;
        _data.AddRange(newFolder);
        _data.Select(x => x).Where(x => x.Id == fileDetails.Id).FirstOrDefault().HasChild = true;
        return await Task.FromResult(response);
    }

    public Task<FileManagerResponse<FileManagerDirectoryContent>> SearchAsync(string path, string searchString)
    {
        var response = new FileManagerResponse<FileManagerDirectoryContent>();
        var i = new Char[] {'*'};
        var searchFiles = _data.Select(x => x)
            .Where(x => x.Name.ToLower().Contains(searchString.TrimStart(i).TrimEnd(i).ToLower())).Select(x => x)
            .ToArray();
        response.Files = searchFiles.ToList();
        return Task.FromResult(response);
    }

    public async Task<FileManagerResponse<FileManagerDirectoryContent>> RenameAsync(string path, string newName,
        FileManagerDirectoryContent fileDetails)
    {
        var renameResponse = new FileManagerResponse<FileManagerDirectoryContent>();
        renameResponse.Files = new List<FileManagerDirectoryContent>();
        var data = _data.Where(x => x.Id == fileDetails.Id).FirstOrDefault();
        _data.Remove(data);
        var renamedFile = new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = data.DateCreated,
            DateModified = DateTime.Now,
            FilterId = data.FilterId,
            FilterPath = data.FilterPath,
            HasChild = data.IsFile ? false : data.HasChild,
            Id = data.Id,
            IsFile = data.IsFile,
            Name = newName,
            ParentId = data.ParentId,
            ShowHiddenItems = data.ShowHiddenItems,
            Size = data.Size,
            Type = data.Type
        };
        renameResponse.Files.Add(renamedFile);
        _data.AddRange(renameResponse.Files);
        var idsToRename = new List<string>() {fileDetails.Id};
        idsToRename.AddRange(_data.Where(file => idsToRename.Contains(file.ParentId)).Select(file => file.Id));
        foreach (var child in _data.Where(x => idsToRename.Contains(x.Id)))
        {
            var filterIds = child.FilterId.Split('/');
            var filterPath = new StringBuilder();
            for (var i = 0; i < filterIds.Length - 1; i++)
            {
                if (filterIds[i] == "0")
                {
                    filterPath.Append("/");
                }
                else
                {
                    var fileName = _data.FirstOrDefault(x => x.Id == filterIds[i])?.Name;
                    filterPath.Append(fileName).Append("/");
                }
            }

            child.FilterPath = filterPath.ToString();
        }

        await Task.Yield();
        return await Task.FromResult(renameResponse);
    }

    public async Task<FileManagerResponse<FileManagerDirectoryContent>> MoveAsync(string path,
        FileManagerDirectoryContent targetData, List<FileManagerDirectoryContent> fileDetails)
    {
        var moveresponse = new FileManagerResponse<FileManagerDirectoryContent>();
        moveresponse.Files = new List<FileManagerDirectoryContent>();
        foreach (var file in fileDetails)
        {
            var data = _data.Where(x => x.Id == file.Id).FirstOrDefault();
            _data.Remove(data);
            var movedFile = new FileManagerDirectoryContent()
            {
                CaseSensitive = false,
                DateCreated = data.DateCreated,
                DateModified = data.DateModified,
                FilterId = $"{targetData.FilterId}{targetData.Id}/",
                FilterPath = $"{targetData.FilterPath.Replace(@"\", "/", StringComparison.Ordinal)}{targetData.Name}/",
                HasChild = data.IsFile ? false : data.HasChild,
                Id = data.Id,
                IsFile = data.IsFile,
                Name = data.Name,
                ParentId = targetData.Id,
                ShowHiddenItems = data.ShowHiddenItems,
                Size = data.Size,
                Type = data.Type
            };
            moveresponse.Files.Add(movedFile);
        }

        _data.AddRange(moveresponse.Files);
        await Task.Yield();
        return await Task.FromResult(moveresponse);
    }

    public async Task<FileManagerResponse<FileManagerDirectoryContent>> CopyAsync(string path,
        FileManagerDirectoryContent targetData, List<FileManagerDirectoryContent> data)
    {
        var copyResponse = new FileManagerResponse<FileManagerDirectoryContent>();
        var children = _data.Where(x => x.ParentId == data[0].Id).Select(x => x.Id).ToList();
        if (children.IndexOf(targetData.Id) != -1 || data[0].Id == targetData.Id)
        {
            var er = new ErrorDetails();
            er.Code = "400";
            er.Message = "The destination folder is the subfolder of the source folder.";
            copyResponse.Error = er;
            return await Task.FromResult(copyResponse);
        }

        foreach (var item in data)
        {
            try
            {
                var idValue = _data.Select(x => x).Select(x => x.Id).ToArray().Select(int.Parse).ToArray().Max();
                if (item.IsFile)
                {
                    var i = _data.Where(x => x.Id == item.Id).Select(x => x).ToList();
                    var createData = new FileManagerDirectoryContent()
                    {
                        Id = (idValue + 1).ToString(),
                        Name = item.Name,
                        Size = i[0].Size,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        Type = i[0].Type,
                        HasChild = false,
                        ParentId = targetData.Id,
                        IsFile = true,
                        FilterPath = targetData.FilterPath + targetData.Name + "/",
                        FilterId = targetData.FilterId + targetData.Id + "/"
                    };
                    _copyFiles.Add(createData);
                    _data.Add(createData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                return null;
            }
        }

        foreach (var item in data)
        {
            try
            {
                if (!item.IsFile)
                {
                    this.CopyFolderItems(item, targetData, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                return null;
            }
        }

        await Task.Yield();
        copyResponse.Files = _copyFiles;
        return await Task.FromResult(copyResponse);
    }

    private void CopyFolderItems(FileManagerDirectoryContent item, FileManagerDirectoryContent target,
        bool isTargetData)
    {
        if (!item.IsFile)
        {
            var idVal = _data.Select(x => x).Select(x => x.Id).ToArray().Select(int.Parse).ToArray().Max();
            var i = _data.Where(x => x.Id == item.Id).Select(x => x).ToList();
            var createData = new FileManagerDirectoryContent()
            {
                Id = (idVal + 1).ToString(),
                Name = item.Name,
                Size = 0,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Type = "folder",
                HasChild = false,
                ParentId = target.Id,
                IsFile = false,
                FilterPath = target.FilterPath + target.Name + "/",
                FilterId = target.FilterId + target.Id + "/"
            };
            if (isTargetData)
            {
                _copyFiles.Add(createData);
            }

            _data.Add(createData);
            if (target.HasChild == false)
            {
                _data.Where(x => x.Id == target.Id).Select(x => x).ToList()[0].HasChild = true;
            }
        }

        var childs = _data.Where(x => x.ParentId == item.Id).Select(x => x).ToArray();
        var idValue = _data.Select(x => x).Select(x => x.Id).ToArray().Select(int.Parse).ToArray().Max();
        if (childs.Length > 0)
        {
            foreach (var child in childs)
            {
                if (child.IsFile)
                {
                    var idVal = _data.Select(x => x).Select(x => x.Id).ToArray().Select(int.Parse).ToArray().Max();
                    var createData = new FileManagerDirectoryContent()
                    {
                        Id = (idVal + 1).ToString(),
                        Name = child.Name,
                        Size = child.Size,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        Type = child.Type,
                        HasChild = false,
                        ParentId = idValue.ToString(),
                        IsFile = true,
                        FilterPath = target.FilterPath + target.Name + "/",
                        FilterId = target.FilterId + target.Id + "/"
                    };
                    _data.Add(createData);
                }
            }

            foreach (var child in childs)
            {
                if (!child.IsFile)
                {
                    this.CopyFolderItems(child,
                        _data.Where(x => x.Id == (idValue).ToString()).Select(x => x).ToArray()[0], false);
                }
            }
        }
    }
}