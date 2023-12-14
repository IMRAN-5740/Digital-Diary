using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Models.ViewModels.Administration.Transportations;
using Digital.Diary.Services.Abstractions.Administration.Transportation;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Administration.Transportation
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _service;

        public TransportController(ITransportService service)
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
            var entityListVMs = new List<TransportVm>();

            foreach (var entity in entities)
            {
                var entityVm = new TransportVm()
                {
                    Id = entity.Id,
                    BusName = entity.BusName,
                    StartingPoint = entity.StartingPoint,
                    EndingPoint = entity.EndingPoint,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] TransportVm createModel)
        {
            if (ModelState.IsValid)
            {
                Transport finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, TransportVm editModel)
        {
            Transport finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.BusName = finalEntity.BusName;
            existingEntity.StartingPoint = finalEntity.StartingPoint;
            existingEntity.EndingPoint = finalEntity.EndingPoint;

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
            var entity = new TransportVm()
            {
                Id = existingEntity.Id,
                BusName = existingEntity.BusName,
                StartingPoint = existingEntity.StartingPoint,
                EndingPoint = existingEntity.EndingPoint,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, TransportVm deleteModel)
        {
            Transport finalEntity = deleteModel.ToModel();

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