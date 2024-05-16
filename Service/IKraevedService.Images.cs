﻿using KraevedAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KraevedAPI.Service
{
    public partial interface IKraevedService
    {
        Task<List<string>> UploadImages(IEnumerable<IFormFile> imageFiles);
    }
}
