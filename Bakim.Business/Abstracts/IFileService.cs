
using Bakim.Core.Utilities.Results;
using Bakim.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Business.Abstracts
{

    public interface IFileService
    {
        Task<IResult> Add(IFormFile file, ApplicationUser user);
        Task<IResult> AddForStock(IFormFile file,Stock stock);
        Task<IResult> AddForVarlik(IFormFile file,Varlik varlik);
        Task<IResult> AddForIsEmri(IFormFile file, WorkTask workTask);

    }

}
