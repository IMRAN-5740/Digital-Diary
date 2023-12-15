using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Models.ViewModels.Emergency_Services;
using Digital.Diary.Services.Abstractions.Emergency_Services;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Diary.WebServer.Controllers.Emergency_Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestHouseController : ControllerBase
    {
        private readonly IGuestHouseService _service;

        public GuestHouseController(IGuestHouseService service)
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
            var entityListVMs = new List<GuestHouseVm>();

            foreach (var entity in entities)
            {
                var entityVm = new GuestHouseVm()
                {
                    Id = entity.Id,
                    HouseName = entity.HouseName,
                    Email = entity.Email,
                    PhoneNum = entity.PhoneNum,
                };
                entityListVMs.Add(entityVm);
            }
            return Ok(entityListVMs);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] GuestHouseVm createModel)
        {
            if (ModelState.IsValid)
            {
                GuestHouse finalEntity = createModel.ToModel();
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
        public IActionResult Update([FromRoute] Guid id, GuestHouseVm editModel)
        {
            GuestHouse finalEntity = editModel.ToModel();
            var existingEntity = _service.GetFirstOrDefault(x => x.Id == id);
            if (existingEntity == null)
            {
                return BadRequest("No entity found");
            }
            existingEntity.HouseName = finalEntity.HouseName;
            existingEntity.Email = finalEntity.Email;
            existingEntity.PhoneNum = finalEntity.PhoneNum;

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
            var entity = new GuestHouseVm()
            {
                Id = existingEntity.Id,
                HouseName = existingEntity.HouseName,
                Email = existingEntity.Email,
                PhoneNum = existingEntity.PhoneNum,
            };

            return Ok(entity);
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id, GuestHouseVm deleteModel)
        {
            GuestHouse finalEntity = deleteModel.ToModel();

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