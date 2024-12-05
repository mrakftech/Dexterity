using Services.Features.Settings.Dtos.FileManager;
using Shared.Wrapper;
using Syncfusion.Blazor.FileManager;

namespace Services.Features.Settings.Service;

public interface IFileManagerService
{
    Task<IResult> CreateWordFile(string fileName, string content,string foldername);
    string GetPatientDirectoryPath(string folderName);
    string GetTempPath();
    string GetRootPath();
    void CreatePatientDefualtDirectories(Guid patientId);
}