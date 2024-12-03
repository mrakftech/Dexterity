using Shared.Wrapper;
using Syncfusion.Blazor.FileManager;

namespace Services.Features.Settings.Service;

public interface IFileManagerService
{
    Task<IResult> CreateWordFile(string fileName, string content);

    string GetFilePath(string folderName);
    string GetTempPath();
    string GetRootPath();


    public Task<FileManagerResponse<FileManagerDirectoryContent>> DeleteAsync(string path,
        List<FileManagerDirectoryContent> fileDetails);

    Task<FileManagerResponse<FileManagerDirectoryContent>> ReadAsync(string path,
        List<FileManagerDirectoryContent> fileDetails);

    Task<FileManagerResponse<FileManagerDirectoryContent>> CreateAsync(string path, string name,
        FileManagerDirectoryContent fileDetails);

    Task<FileManagerResponse<FileManagerDirectoryContent>> SearchAsync(string path, string searchString);

    Task<FileManagerResponse<FileManagerDirectoryContent>> RenameAsync(string path, string newName,
        FileManagerDirectoryContent fileDetails);

    Task<FileManagerResponse<FileManagerDirectoryContent>> MoveAsync(string path,
        FileManagerDirectoryContent targetData, List<FileManagerDirectoryContent> fileDetails);

    Task<FileManagerResponse<FileManagerDirectoryContent>> CopyAsync(string path,
        FileManagerDirectoryContent targetData, List<FileManagerDirectoryContent> data);
}