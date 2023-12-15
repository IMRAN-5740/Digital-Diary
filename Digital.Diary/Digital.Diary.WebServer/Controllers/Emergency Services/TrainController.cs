using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Models.ViewModels.Emergency_Services;
using Digital.Diary.Services.Abstractions.Emergency_Services;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Emergency_Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase

    {
        private readonly ITrainService _service;

        public TrainController(ITrainService service)
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
            var entityListVMs = new List<TrainVm>();

            foreach (var entity in entities)
            {
                var entityVm = new TrainVm()
                {
                    Id = entity.Id,
                    TrainName = entity.TrainName,
                    TrainDescription = entity.TrainDescription,
                    StartingPoint = entity.StartingPoint,
                    EndingPoint = entity.EndingPoint,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] TrainVm createModel)
        {
            if (ModelState.IsValid)
            {
                Train finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, TrainVm editModel)
        {
            Train finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.TrainName = finalEntity.TrainName;
            existingEntity.TrainDescription = finalEntity.TrainDescription;
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
            var entity = new TrainVm()
            {
                Id = existingEntity.Id,
                TrainName = existingEntity.TrainName,
                TrainDescription = existingEntity.TrainDescription,
                StartingPoint = existingEntity.StartingPoint,
                EndingPoint = existingEntity.EndingPoint,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, TrainVm deleteModel)
        {
            Train finalEntity = deleteModel.ToModel();

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
            }
            return Ok();
        }
    }
}