using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace PhotoHome.Helpers
{
	public class UploadFileHelper
	{
		public async static Task<string> UploadFile(IFormFile file)
		{
			string link = Guid.NewGuid().ToString();

			using var fileStream = new FileStream(@$"wwwroot/uploadedImages/{link}{Path.GetExtension(file.FileName)}", FileMode.Create);

			await file.CopyToAsync(fileStream);

			return fileStream.Name;
		}
	}
}
