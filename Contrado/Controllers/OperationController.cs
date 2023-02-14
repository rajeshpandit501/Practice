using Contrado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contrado.Controllers
{
    
    [ApiController]
    public class OperationController : ControllerBase
    {

        public static List<FileParameters> ConList = new List<FileParameters>();

        [Route("api/[controller]/FetchDataFromCsv")]
        [HttpPost]
        public ActionResult FetchDataFromCsv([FromForm]UploadCsvFileRequest request)
        {
            UploadCsvFileResponse response = new UploadCsvFileResponse();
            string path = "Uploads/" + request.File.FileName;
            try
            {
                using(FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    request.File.CopyTo(stream);
                }
                ConList = response.responseResult(request, path);


                return Ok(ConList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        [Route("api/[controller]/Delete_Consignment/{id}")]
        [HttpDelete]
        public ActionResult Delete_Consignment(int id)
        {
            FileParameters obj = ConList.Find(r=>r.Consignment_number==id);
            ConList.Remove(obj);
            return Ok(ConList);
        }

        [Route("api/[controller]/GetAllConsignment")]
        [HttpGet]

        public ActionResult GetAllConsignment()
        {
            var list = ConList;
            return Ok(list);
        }

        [Route("api/[controller]/UpdateList")]
        [HttpPut]
        public ActionResult UpdateList(FileParameters obj)
        {
            var list = ConList;
            var old_obj = new FileParameters();
            old_obj = list.Where(r => r.Consignment_number==obj.Consignment_number).First();
            var index_of_old_obj = list.IndexOf(old_obj);
            ConList[index_of_old_obj] = obj;
            return Ok(ConList);
        }


        [Route("api/[controller]/UploadToDatabase")]
        [HttpPost]
        public ActionResult UploadToDatabase()
        {           
            DBList.PersistentList.AddRange(ConList);
            return Ok(DBList.PersistentList);
        }
    }
}
