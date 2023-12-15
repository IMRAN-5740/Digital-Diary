using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Models.ViewModels.Administration.Transportations;
using Digital.Diary.Models.ViewModels.Miscellaneous;
using Digital.Diary.Services.Abstractions.Administration.Transportation;
using Digital.Diary.Services.Abstractions.Miscellaneous;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Miscellaneous
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _service;

        public BankController(IBankService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var entities = _service.GetAll();

            if (!entities.Any())
            {
                return BadRequest("No entity Found");
            }
            var entityListVMs = new List<BankVm>();

            foreach (var entity in entities)
            {
                var entityVm = new BankVm()
                {
                    Id = entity.Id,
                    BankName = entity.BankName,
                    Email = entity.Email,
                    BranchName = entity.BranchName,
                    WebAddress = entity.WebAddress,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] BankVm createModel)
        {
            if (ModelState.IsValid)
            {
                Bank finalEntity = createModel.ToModel();
                finalEntity.Id = Guid.NewGuid();
                var result = _service.Create(finalEntity);
                if (result.IsSucced)
                {
                    ModelState.Clear();
                    return Ok(result);
                }
                if (result.ErrorMessages.Any())
                {
                    foreach (var error in result.ErrorMessages)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return Ok(result);
                }
            }

            return Ok(createModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, BankVm editModel)
        {
            Bank finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.BankName = finalEntity.BankName;
            existingEntity.Email = finalEntity.Email;
            existingEntity.BranchName = finalEntity.BranchName;
            existingEntity.WebAddress = finalEntity.WebAddress;

            var result = _service.Update(existingEntity);
            if (result.IsSucced)
            {
                ModelState.Clear();
                return Ok(result);
            }
            if (result.ErrorMessages.Any())
            {
                foreach (var error in result.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return Ok(finalEntity);
        }

        [HttpGet]
        [Route("Details/{id:Guid}")]
        public IActionResult Details(Guid id)
        {
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            var entity = new BankVm()
            {
                Id = existingEntity.Id,
                BankName = existingEntity.BankName,
                Email = existingEntity.Email,
                BranchName = existingEntity.BranchName,
                WebAddress = existingEntity.WebAddress,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, BankVm deleteModel)
        {
            Bank finalEntity = deleteModel.ToModel();

            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }

            var result = _service.Remove(existingEntity);
            if (result.IsSucced)
            {
                ModelState.Clear();
                return Ok(result);
            }
            if (result.ErrorMessages.Any())
            {
                foreach (var error in result.ErrorMessages)
                {
                    ModelState.AddModelError("", error);
                }
                return Ok(result);
            }
            return Ok();
        }
    }
}