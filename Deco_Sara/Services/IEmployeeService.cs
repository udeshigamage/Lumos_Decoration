﻿using Deco_Sara.DTO;
using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IEmployeeService
    {
         Task<(IEnumerable<ViewUserDTO> Employees, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10, string searchterm = "");
        

        

        Task<Message<string>> UpdateAsync(int id, UpdateUserDTO updatedEmployee);

       Task<Message<string>> DeactivateAsync(int id);

        Task<Message<string>> ActiveAsync(int id);

        Task<List<ListuserDTO>> GetAllEmployeelistAsync();

        Task<(List<Order>, int totalcount)> GetordersbyEmplyeeid(int emploeeid, int page = 1, int pagesize = 5);

        Task<int> GetCountconfirmedordersbyEmplyeeid(int emploeeid);

        Task<int> GetCountprocessingdordersbyEmplyeeid(int emploeeid);



    }
}
