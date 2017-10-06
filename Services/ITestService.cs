using System.Collections.Generic;
using StartEx.Domain;
using StartEx.Models.Request;

namespace StartEx.Services
{
    public interface ITestService
    {
        List<jobs> GetAllJobs();
        int Insert(addJob model);
        void Delete(int Id);
        void Update(updateJob model);
    }
}