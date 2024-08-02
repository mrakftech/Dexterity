using Services.Features.Appointments.Dtos;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Components;
using Services.Contracts.Repositroy;

namespace Services.Features.Appointments.Service
{
    public class AppointmentDataAdaptor : DataAdaptor
    {
        private readonly IAppointmentService _unitOfWork;

        public AppointmentDataAdaptor(IAppointmentService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        List<AppointmentDto> EventData;

        //Performs Read operation
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            IDictionary<string, object> Params = dataManagerRequest.Params;
            DateTime start = DateTime.Parse((string)Params["StartDate"]);
            DateTime end = DateTime.Parse((string)Params["EndDate"]);
            EventData = await _unitOfWork.GetAllAppointments(start, end);
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = EventData, Count = EventData.Count() } : EventData;
        }

        //Performs Insert operation
        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _unitOfWork.CreateAppointment(data as AppointmentDto);
            return data;
        }

        //Performs Update operation
        public async override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _unitOfWork.UpdateAppointment(data as AppointmentDto);
            return data;
        }

        //Performs Delete operation
        public async override Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)
        {
            int id = (int)data;
            await _unitOfWork.DeleteAppointment(id);
            return data;
        }
        //Performs Batch update operations
        public async override Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
        {
            object records = deletedRecords;
            List<AppointmentDto> deleteData = deletedRecords as List<AppointmentDto>;
            if (deleteData != null)
            {
                foreach (var data in deleteData)
                {
                    await _unitOfWork.DeleteAppointment(data.Id);
                }
            }
            List<AppointmentDto> addData = addedRecords as List<AppointmentDto>;
            if (addData != null)
            {
                foreach (var data in addData)
                {
                    await _unitOfWork.CreateAppointment(data);
                    records = addedRecords;
                }
            }
            List<AppointmentDto> updateData = changedRecords as List<AppointmentDto>;
            if (updateData != null)
            {
                foreach (var data in updateData)
                {
                    await _unitOfWork.UpdateAppointment(data);
                    records = changedRecords;
                }
            }
            return records;
        }
    }
}
