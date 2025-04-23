using Services.Features.Settings.Dtos.FileManager;
using Services.State;
using Shared.Constants.Module.Consultation;
using Shared.Wrapper;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace Services.Features.Settings.Service;

public class FileManagerService : IFileManagerService
{
    public async Task<IResult> CreateWordFile(string fileName, string content, string foldername)
    {
        try
        {
            var root = GetPatientDirectoryPath(foldername);
            var tempPath = Path.Combine(GetTempPath(), $"{ApplicationState.Patient.GetSelectPatientId()}-temp.html");
            await File.WriteAllTextAsync(tempPath, content);

            //Load an existing HTML file.
            await using var inputFileStream =
                new FileStream(tempPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var document = new WordDocument(inputFileStream, FormatType.Html);
            inputFileStream.Close();

            //Save the Word document as DOCX format.
            await using var outputFileStream =
                new FileStream(Path.Combine(root, $"{fileName}.docx"), FileMode.Create, FileAccess.ReadWrite);
            document.Save(outputFileStream, FormatType.Docx);
            outputFileStream.Close();

            File.Delete(tempPath);
            return await Result.SuccessAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return await Result.FailAsync();
        }
    }

    public string GetPatientDirectoryPath(string folderName)
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            $"wwwroot/Files/{ApplicationState.Patient.GetSelectPatientId()}/{folderName}");
    }


    public string GetTempPath()
    {
        CreateDirectoryInWwwRoot("Temp");
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/Temp");
    }

    public string GetRootPath()
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            $"wwwroot/Files/{ApplicationState.Patient.GetSelectPatientId()}");
    }

    public void CreatePatientDefualtDirectories(Guid patientId)
    {
        CreateDirectory(patientId.ToString());
        // foreach (var item in ConsultationConstants.DocumentConstant.DocumentCategoryList)
        // {
        //     CreateDirectory($"{patientId}/{item.Name}");
        // }
    }

    private static string CreateDirectory(string folderName)
    {
        CreateDirectoryInWwwRoot("Files");
        var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot/Files/{folderName}");
        var exists = Directory.Exists(root);
        if (!exists)
            Directory.CreateDirectory(root);
        return root;
    }

    private static void CreateDirectoryInWwwRoot(string folderName)
    {
        var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"wwwroot/{folderName}");
        var exists = Directory.Exists(root);
        if (!exists)
            Directory.CreateDirectory(root);
    }
}